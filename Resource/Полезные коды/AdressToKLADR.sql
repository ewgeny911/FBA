USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[AdressToKLADR]    Script Date: 13.03.2019 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[AdressToKLADR]
    @address nvarchar(max) -- Адрес, который нужно разбить по КЛАДР.   
AS
BEGIN
  --Процедура разбивает по КЛАДР адрес.  
  --Пример вызова:  EXEC [dbo].[AdressToKLADR] '121108, Россия, г. Москва, ул. Герасима курина, дом 16'
   --Пример вызова:  EXEC [dbo].[AdressToKLADR] '350000, Краснодарский край, Краснодар г, им Гоголя ул, дом № 23, корпус А, кв.111
   --Пример вызова:  EXEC [dbo].[AdressToKLADR] '190000, Россия, г. Санкт-Петербург, ул. Бухарестская, дом 110, кв. 198'
  DECLARE @res varchar(max)
  DECLARE @Requset1 varchar(max) 

  SELECT @Requset1 = '<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:cle="http://clean.soap.cleaner.hflabs.ru">'+
     '<soapenv:Header/>' +
     '<soapenv:Body>' +
        '<cle:doCleanRequest>'+        
           '<data>id</data>'+      
           '<data>additional info</data>'+
           --'<data>121108, Россия, г. Москва, ул. Герасима курина, дом 16</data>'+
           '<data>' + @address + '</data>'+
          '<mapping>clean-address</mapping>'+  
        '</cle:doCleanRequest>'+
     '</soapenv:Body>'+
  '</soapenv:Envelope>'    

  DECLARE @response varchar(max)
  
  EXEC dbo.YS_test_soap_request
    @url         = 'http://10.177.102.108:18080/factor-service-vtbi/services/CleanService?wsdl' 
	 ,@result      = @res
	 ,@method      = 'POST'
	 ,@soap_action = 'doCall'
	 ,@request     = @Requset1
   ,@responseout = @response OUT

  SET @response = REPLACE(@response, '<?xml version=''1.0'' encoding=''utf-8''?>', '')

  DECLARE @xml xml
  SET @xml = @response

  ;WITH XMLNAMESPACES ('http://schemas.xmlsoap.org/soap/envelope/' as [soapenv],'http://clean.soap.cleaner.hflabs.ru' as [ns2])
  SELECT
     Cl.value('data[1]',  'varchar(1000)') as id
    ,Cl.value('data[2]', 'varchar(1000)') as additionalInfo
    ,Cl.value('data[3]', 'varchar(1000)') as rawSource
    ,Cl.value('data[4]', 'varchar(1000)') as fullAddress
    ,Cl.value('data[5]', 'varchar(1000)') as postalCode
    ,Cl.value('data[6]', 'varchar(1000)') as kladrPostalCode
    ,Cl.value('data[7]', 'varchar(1000)') as country
    ,Cl.value('data[8]', 'varchar(1000)') as regionType
    ,Cl.value('data[9]', 'varchar(1000)') as region
    ,Cl.value('data[10]', 'varchar(1000)') as rayonType
    ,Cl.value('data[11]', 'varchar(1000)') as rayon
    ,Cl.value('data[12]', 'varchar(1000)') as cityType
    ,Cl.value('data[13]', 'varchar(1000)') as city
    ,Cl.value('data[14]', 'varchar(1000)') as settlementType
    ,Cl.value('data[15]', 'varchar(1000)') as settlement
    ,Cl.value('data[16]', 'varchar(1000)') as streetType
    ,Cl.value('data[17]', 'varchar(1000)') as street
    ,Cl.value('data[18]', 'varchar(1000)') as houseNumber
    ,Cl.value('data[19]', 'varchar(1000)') as militaryNumber
    ,Cl.value('data[20]', 'varchar(1000)') as postalBox
    ,Cl.value('data[21]', 'varchar(1000)') as korpus
    ,Cl.value('data[22]', 'varchar(1000)') as stroenie
    ,Cl.value('data[23]', 'varchar(1000)') as vladenie
    ,Cl.value('data[24]', 'varchar(1000)') as hostel
    ,Cl.value('data[25]', 'varchar(1000)') as [floor]
    ,Cl.value('data[26]', 'varchar(1000)') as entrance
    ,Cl.value('data[27]', 'varchar(1000)') as section
    ,Cl.value('data[28]', 'varchar(1000)') as flat
    ,Cl.value('data[29]', 'varchar(1000)') as flat2
    ,Cl.value('data[30]', 'varchar(1000)') as office
    ,Cl.value('data[31]', 'varchar(1000)') as office2
    ,Cl.value('data[32]', 'varchar(1000)') as room
    ,Cl.value('data[33]', 'varchar(1000)') as room2
    ,Cl.value('data[34]', 'varchar(1000)') as district
    ,Cl.value('data[35]', 'varchar(1000)') as reserv1
    ,Cl.value('data[36]', 'varchar(1000)') as reserv2
    ,Cl.value('data[37]', 'varchar(1000)') as reserv3
    ,Cl.value('data[38]', 'varchar(1000)') as reserv4
    ,Cl.value('data[39]', 'varchar(1000)') as reserv5
    ,Cl.value('data[40]', 'varchar(1000)') as qualityCode
    ,Cl.value('data[41]', 'varchar(1000)') as validationCode
    ,Cl.value('data[42]', 'varchar(1000)') as validationExtension
    ,Cl.value('data[43]', 'varchar(1000)') as fiasActualityDate
    ,Cl.value('data[44]', 'varchar(1000)') as kladrCode
    ,Cl.value('data[45]', 'varchar(1000)') as fiasId
    ,Cl.value('data[46]', 'varchar(1000)') as fiasLevel
    ,Cl.value('data[47]', 'varchar(1000)') as okatoCode
    ,Cl.value('data[48]', 'varchar(1000)') as fnsNumber
    ,Cl.value('data[49]', 'varchar(1000)') as timezoneUTC
    ,Cl.value('data[50]', 'varchar(1000)') as timezoneMSK
    ,Cl.value('data[51]', 'varchar(1000)') as fiasIdRegion
    ,Cl.value('data[52]', 'varchar(1000)') as fiasIdRayon
    ,Cl.value('data[53]', 'varchar(1000)') as fiasIdCity
    ,Cl.value('data[54]', 'varchar(1000)') as fiasIdNp
    ,Cl.value('data[55]', 'varchar(1000)') as fiasIdStreet
    ,Cl.value('data[56]', 'varchar(1000)') as fiasIdExtra
    ,Cl.value('data[57]', 'varchar(1000)') as fiasIdHouse
  FROM @xml.nodes('//soapenv:Envelope/soapenv:Body/ns2:doCleanResponse') col(Cl)

 END

