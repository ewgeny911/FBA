USE [SOVITA]
GO
/****** Object:  StoredProcedure [dbo].[YS_SOAPMethodCall]    Script Date: 10.01.2018 9:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[YS_SOAPMethodCall] (
	 @@URL		SysName
	,@@Header	XML	= NULL	OUTPUT
	,@@Body		XML	= NULL	OUTPUT
) AS BEGIN
	-- Для установки Proxy воспользуйтесь "proxycfg -u"

	DECLARE	 @OLEObject		Int
		,@HTTPStatus		Int
		,@ErrCode		Int
		,@ErrMethod		SysName
		,@ErrSource		SysName
		,@ErrDescription	SysName
		,@@SOAPAction		SysName
		,@Request		XML

	;WITH XMLNAMESPACES (
		 'http://www.w3.org/2001/XMLSchema-instance'	AS [xsi]
		,'http://www.w3.org/2001/XMLSchema'		AS [xsd]
		,'http://schemas.xmlsoap.org/soap/envelope/'	AS [soap])
	SELECT	 @@SOAPAction	= @@Body.value('namespace-uri(/*[1])','SysName') + @@Body.value('local-name(/*[1])','SysName')
		,@Request	= (
	SELECT	 @@Header	AS [soap:Header]
		,@@Body		AS [soap:Body]
	FOR	XML Path('soap:Envelope'),Type)

	EXEC @ErrCode = sys.sp_OACreate 'MSXML2.ServerXMLHTTP', @OLEObject OUT
	IF (@ErrCode = 0) BEGIN
		EXEC @ErrCode = sys.sp_OAMethod @OLEObject ,'open'		,NULL ,'POST' ,@@URL ,'false'				IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'open'		GOTO Error END
		EXEC @ErrCode = sys.sp_OAMethod @OLEObject ,'setRequestHeader'	,NULL ,'Content-Type'	,'text/xml; charset=utf-8'	IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'setRequestHeader'	GOTO Error END
		EXEC @ErrCode = sys.sp_OAMethod @OLEObject ,'setRequestHeader'	,NULL ,'SOAPAction'	,@@SOAPAction			IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'setRequestHeader'	GOTO Error END
		EXEC @ErrCode = sys.sp_OAMethod @OLEObject ,'send'		,NULL ,@Request						IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'send'		GOTO Error END

		EXEC @ErrCode = sys.sp_OAGetProperty @OLEObject ,'status' ,@HTTPStatus OUT						IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'status'		GOTO Error END
		IF (@HTTPStatus IN (200,500)) BEGIN
			DECLARE	@Response TABLE ( Response NVarChar(max) )
			INSERT	@Response
			EXEC @ErrCode = sys.sp_OAGetProperty @OLEObject ,'responseText'							IF (@ErrCode != 0) BEGIN SET @ErrMethod = 'responseText'	GOTO Error END

			;WITH XMLNAMESPACES (
				 'http://www.w3.org/2001/XMLSchema-instance'	AS [xsi]
				,'http://www.w3.org/2001/XMLSchema'		AS [xsd]
				,'http://schemas.xmlsoap.org/soap/envelope/'	AS [soap])
			SELECT	 @@Header	= R.X.query('/soap:Envelope/soap:Header/*')
				,@@Body		= R.X.query('/soap:Envelope/soap:Body/*')
			FROM	@Response CROSS APPLY (SELECT Convert(XML,Replace(Response,' encoding="utf-8"','')) AS X) R
			-- Fault
			;WITH XMLNAMESPACES (
				 'http://www.w3.org/2001/XMLSchema-instance'	AS [xsi]
				,'http://www.w3.org/2001/XMLSchema'		AS [xsd]
				,'http://schemas.xmlsoap.org/soap/envelope/'	AS [soap])
			SELECT	 @ErrMethod	= @@SOAPAction
				,@ErrSource	= @@Body.value('(/soap:Fault/faultcode)[1]'	,'SysName')
				,@ErrDescription= @@Body.value('(/soap:Fault/faultstring)[1]'	,'SysName')
			WHERE	@HTTPStatus = 500
		END ELSE
			SELECT	 @ErrMethod	= 'send'
				,@ErrSource	= 'spSOAPMethod'
				,@ErrDescription= 'Ошибоный статус HTTP ответа "' + Convert(VarChar,@HTTPStatus) + '"'

		GOTO Destroy
	Error:	EXEC @ErrCode = sys.sp_OAGetErrorInfo @OLEObject ,@ErrSource OUT ,@ErrDescription OUT
	Destroy:EXEC @ErrCode = sys.sp_OADestroy @OLEObject
		IF (@ErrSource IS NOT NULL) BEGIN
			RAISERROR('Ошибка при выполнении метода "%s" в "%s": %s',18,1,@ErrMethod,@ErrSource,@ErrDescription)
			IF (@@TranCount > 0 AND XACT_STATE() != 0)
				ROLLBACK
			RETURN	@@Error
		END
	END ELSE BEGIN
		RAISERROR('Ошибка при создании OLE объекта "MSXML2.ServerXMLHTTP"',18,1)
		RETURN	@@Error
	END
END
