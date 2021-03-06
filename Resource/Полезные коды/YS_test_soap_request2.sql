USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[YS_test_soap_request]    Script Date: 13.03.2019 14:11:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[YS_test_soap_request]
    @url nvarchar(max), -- Адрес сервера
    @result varchar(max) OUTPUT, -- Ответ
    @method nvarchar(max) = 'POST', -- Метод передачи
    @soap_action varchar(max) = NULL, -- Действие
    @request varchar(max) = NULL, -- Запрос
    @user_name varchar(max) = NULL, -- Имя пользователя
    @password varchar(max) = NULL, -- Пароль
    @responseout varchar(max) OUTPUT -- Ответ
AS
BEGIN  
/*
sample 

declare @res varchar(max)
       ,@Requset varchar(max) 


select @Requset = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:_13="http://hflabs.ru/cdi/soap/2_13">'+
   '<soapenv:Header/>' +
   '<soapenv:Body>' +
      '<_13:getByHID>'+
         '<_13:hid>212528204</_13:hid>'+
                  '<_13:partyType>PHYSICAL</_13:partyType>'+
      '</_13:getByHID>'+
   '</soapenv:Body>'+
'</soapenv:Envelope>'

--select @Requset

exec YS_test_soap_request
      @url = 'http://cdi-app-prod.inscapital.ru:8080/cdi/soap/services/2_13/PartyWS' 
	 ,@result = @res
	 ,@method  = 'POST'
	 ,@soap_action = 'http://hflabs.ru/cdi/soap/services/PartyWS/getByHID'
	 ,@request = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:_13="http://hflabs.ru/cdi/soap/2_13"><soapenv:Header/><soapenv:Body><_13:getByHID><_13:hid>212528204</_13:hid><_13:partyType>PHYSICAL</_13:partyType></_13:getByHID></soapenv:Body></soapenv:Envelope>'


select @res

*/




/*
  --Второй пример:
  declare @res varchar(max)
         ,@Requset1 varchar(max) 
         ,@responseout varchar(max) 

select @Requset1 = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:cle="http://clean.soap.cleaner.hflabs.ru">'+
   '<soapenv:Header/>' +
   '<soapenv:Body>' +
      '<cle:doCleanRequest>'+        
         '<data>id</data>'+      
         '<data>additional info</data>'+
         '<data>121108, Россия, г. Москва, ул. Герасима курина, дом 16</data>'+
        '<mapping>clean-address</mapping>'+  
      '</cle:doCleanRequest>'+
   '</soapenv:Body>'+
'</soapenv:Envelope>'    

exec YS_test_soap_request
    @url = 'http://10.177.102.108:18080/factor-service-vtbi/services/CleanService?wsdl' 
	 ,@result = @res
	 ,@method  = 'POST'
	 ,@soap_action = 'doCall'
	 ,@request = @Requset1
   ,@responseout = @responseout OUT
select @responseout AS response


*/

    SET NOCOUNT ON;
 
    DECLARE
        @ole_obj int, -- Ссылка на OLE объект
        @err int, -- Код ошибки
        @err_str varchar(max), -- Текст ошибки
        @err_src nvarchar(max), -- Источник ошибки
        @err_desc nvarchar(max), -- Описание ошибки
        @http_status int, -- Код ответа сервера
        @err_id int, -- Код ошибки процедуры sp_OAGetErrorInfo
        @ResolveTimeOut int = 300000, --120 * 1000, -- Время ожидания поиска хоста
        @ConnectTimeOut int = 300000,--10 * 1000, -- Время ожидания соединения
        @SendTimeOut int = 300000,--120 * 1000, -- Время ожидания отправки
        @ReceiveTimeOut int = 300000--240 * 1000 -- Время ожидания ответа
    
    set @responseout = ''
     
    EXEC @err = sys.sp_OACreate 'MSXML2.ServerXMLHTTP', @ole_obj OUTPUT
    IF @err = 0 BEGIN  
        EXEC @err = sys.sp_OAMethod @ole_obj, 'open',NULL,@method,@url,'FALSE' --,@user_name,@password
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошибка при выполнении метода "OPEN".' GOTO GETERROR END
     
            EXEC @err = sys.sp_OAMethod @ole_obj ,'setTimeouts' ,NULL , @ResolveTimeOut, @ConnectTimeOut, @SendTimeOut, @ReceiveTimeOut
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошибка при выполнении метода "setTimeouts".' GOTO GETERROR END
 
            EXEC @err = sys.sp_OAMethod @ole_obj ,'setRequestHeader'    ,NULL ,'Content-Type','text/xml; charset=utf-8'
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошибка при выполнении метода "setRequestHeader" (Content-Type).' GOTO GETERROR END
            
			print '@soap_action'
			print @soap_action
            IF @soap_action IS NOT NULL BEGIN
                EXEC @err = sys.sp_OAMethod @ole_obj ,'setRequestHeader'    ,NULL ,'SOAPAction', @soap_action
                IF @err <> 0 BEGIN SELECT @err_str = 'Ошибка при выполнении метода "setRequestHeader" (SOAPAction).' GOTO GETERROR END
            END
 
            EXEC @err = sys.sp_OAMethod @ole_obj,'send',NULL,@request
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошбика при выполнении метода "SEND".' GOTO GETERROR END
			print '@err send'
			print @err     

            EXEC @err = sys.sp_OAGetProperty @ole_obj ,'status', @http_status OUT
			print '@http_status'
			print @http_status
             
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошбика при получении HTTP статуса ответа: ' + CONVERT(varchar(max), @http_status) GOTO GETERROR END
            IF ISNULL(@http_status, -1) not in (200,500) BEGIN SELECT @err=-1, @err_str = 'Неверный статус HTTP ответа: ' + CONVERT(varchar(max), @http_status) GOTO GETERROR END      
         
            DECLARE @response TABLE (response varchar(max))
            INSERT INTO @response
            EXEC @err = sys.sp_OAGetProperty @ole_obj ,'responseText'--, @result OUT
			print @result
            print @err  
             
            IF @err <> 0 BEGIN SELECT @err_str = 'Ошбика при получении HTTP ответа.' GOTO GETERROR END
            
            SELECT @result = response FROM @response
			      --select response as ggg FROM @response
             --declare @ffff varchar(max)
            --EXEC @err = sys.sp_OAGetProperty @ole_obj ,'responseText', @ffff OUT
            --select @ffff as ffff

           select @responseout = response FROM @response
             
            IF @http_status = 500 BEGIN SELECT @err=-1, @err_str = 'Ошибка сервера HTTP 500: '+ @result GOTO GETERROR END
 
            GOTO DESTROYOLE
            GETERROR:BEGIN
			print 'GETERROR'
                EXEC @err_id = sys.sp_OAGetErrorInfo @ole_obj, @err_src OUTPUT, @err_desc OUTPUT
                IF @err_id = 0
                    SELECT @err_str += ' Источник: ' + ISNULL(@err_src,'NULL') + ' Описание: ' + ISNULL(@err_desc,'NULL') + ' Код ошибки: ' + CONVERT(varchar(max), @err)
                ELSE
                    SELECT @err_str += ' Процедура sp_OAGetErrorInfo вернула ошибку: ' + CONVERT(varchar(max), @err_id)
            END
            DESTROYOLE:EXEC sys.sp_OADestroy @ole_obj
			print 'DESTROYOLE'
            IF @err <> 0 RAISERROR(@err_str, 16, -1)
    END ELSE RAISERROR('Не удалось создать OLE объект "MSXML2.ServerXMLHTTP"', 16,-1)
    RETURN @err
END