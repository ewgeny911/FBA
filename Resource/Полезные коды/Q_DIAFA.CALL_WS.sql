USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [Q_DIAFA].[CALL_WS]    Script Date: 10.01.2018 10:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER FUNCTION [Q_DIAFA].[CALL_WS](
  @handler    VARCHAR(512),
  @requestXml VARCHAR(MAX),
  @URI        VARCHAR(2000),
  @UserName   VARCHAR(100) = '', -- Domain\UserName or UserName
  @Password   VARCHAR(100) = ''
)
  RETURNS NVARCHAR(MAX)
AS
  BEGIN
    DECLARE 
	 @requestBody VARCHAR(MAX)
    ,@objectID INT
	,@hResult INT
	,@len INT
    ,@source VARCHAR(255)
	,@desc VARCHAR(255)
    ,@responseBody VARCHAR(MAX)
	,@l_created varchar(30)
	,@l_nonce varbinary(32)
	,@l_username varchar(512)
	,@l_password varchar(512)
	,@l_hpwd varbinary(1024)
 
 set @l_created = convert(varchar(23), SYSUTCDATETIME(), 126) + 'Z'
 set @l_nonce = HASHBYTES ('SHA1', convert(varbinary(23), @@PACK_SENT) + convert(varbinary(23), @@PACK_RECEIVED) + convert(varbinary(23), @@PROCID)) --CRYPT_GEN_RANDOM(16)
 set @l_username = @UserName
 set @l_password = @Password
 set @l_hpwd = HASHBYTES ('SHA1', @l_nonce + convert(varbinary(max), @l_created) + convert(varbinary(max), @l_password))

    SET @requestBody = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:ser="http://server.ws/"><soapenv:Header>'
   
   IF @l_username IS NOT NULL
   SET @requestBody = @requestBody + '<wsse:Security soapenv:mustUnderstand="1" xmlns:wsse="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd" xmlns:wsu="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd">
   <wsse:UsernameToken wsu:Id="UsernameToken"><wsse:Username>'
         + @l_username
         + '</wsse:Username><wsse:Password Type="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest">'
         + cast('' as xml).value('xs:base64Binary(sql:variable("@l_hpwd"))', 'varchar(max)')
         + '</wsse:Password><wsse:Nonce EncodingType="http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary">'
         + cast('' as xml).value('xs:base64Binary(sql:variable("@l_nonce"))', 'varchar(max)')
         + '</wsse:Nonce><wsu:Created>'
         + @l_created
         + '</wsu:Created></wsse:UsernameToken></wsse:Security>'
   
   SET @requestBody = @requestBody + '</soapenv:Header>
   <soapenv:Body>
      <ser:doCall>
        <ser:handler>' + @handler + '</ser:handler>
         <ser:requestXml>' + @requestXml + '</ser:requestXml>      </ser:doCall>
   </soapenv:Body>
</soapenv:Envelope>'

    SET @len = len(@requestBody)

    EXEC @hResult = sp_OACreate 'MSXML2.ServerXMLHTTP', @objectID OUT
    IF @hResult <> 0
      BEGIN
        EXEC sp_OAGetErrorInfo @objectID, @source OUT, @desc OUT
        EXEC sp_OADestroy @objectID
        RETURN @hResult + ' ' + @source + ' ' + @desc
      END

    EXEC @hResult = sp_OAMethod @objectID, 'open', null, 'POST', @URI, 'false', @UserName, @Password
    IF @hResult <> 0
      BEGIN
        EXEC sp_OAGetErrorInfo @objectID, @source OUT, @desc OUT
        EXEC sp_OADestroy @objectID
        RETURN @hResult + ' ' + @source + ' ' + @desc
      END

    EXEC @hResult = sp_OAMethod @objectID, 'setRequestHeader', null, 'Content-Type', 'text/xml; charset=UTF-8'
    EXEC @hResult = sp_OAMethod @objectID, 'setRequestHeader', null, 'Content-Length', @len

    EXEC @hResult = sp_OAMethod @objectID, 'send', null, @requestBody
    IF @hResult <> 0
      BEGIN
        EXEC sp_OAGetErrorInfo @objectID, @source OUT, @desc OUT
        EXEC sp_OADestroy @objectID
        RETURN @hResult + ' ' + @source + ' ' + @desc
      END
    DECLARE @statusText   VARCHAR(1000), @status VARCHAR(1000)

    EXEC sp_OAGetProperty @objectID, 'StatusText', @statusText OUT
    EXEC sp_OAGetProperty @objectID, 'Status', @status OUT

    EXEC sp_OAGetProperty @objectID, 'responseText', @responseBody OUT
    IF @hResult <> 0
      BEGIN
        EXEC sp_OAGetErrorInfo @objectID, @source OUT, @desc OUT
        EXEC sp_OADestroy @objectID
        RETURN @hResult + ' ' + @source + ' ' + @desc
      END
    EXEC sp_OADestroy @objectID

    SET @requestBody = @responseBody
    
    IF cast(@responseBody as xml)
.exist('declare namespace soap="http://schemas.xmlsoap.org/soap/envelope/";
declare namespace ws="http://server.ws/";
/soap:Envelope/soap:Body/ws:doCallResponse/ws:return') = 1
    SET @requestBody = cast(@responseBody as xml)
.query('declare namespace soap="http://schemas.xmlsoap.org/soap/envelope/";
declare namespace ws="http://server.ws/";
/soap:Envelope/soap:Body/ws:doCallResponse/ws:return').value('.','varchar(max)')
else
    SET @requestBody = cast(@responseBody as xml)
.query('declare namespace soap="http://schemas.xmlsoap.org/soap/envelope/";
declare namespace ws="http://server.ws/";
/soap:Envelope/soap:Body/soap:Fault/faultstring').value('.','varchar(max)')

RETURN @requestBody
  END;
