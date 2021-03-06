USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_GetData]    Script Date: 10.01.2018 9:58:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spen_GetData] (@TextXMLOUT varchar(max) OUT, @TextXML varchar(max), @AsXML int = 0) 
AS 
BEGIN

--Хранимая процедура для оформления полиса ВЗР
  --DECLARE 
  --select * from dbo.A_GetDataLog
  --delete from  dbo.A_GetDataLog
  --Insert into dbo.A_GetDataLog (UserName, SQLText) values ('1', @TextXML)
  /*SELECT
    '01.01.2015'      as BirthDay,
    1234              as OrgId,
    'ВТБ Страхование' as OrgName
  RETURN
  */
  --Хранимая процедура на входе принимает XML, на выходе также XML.
  /*


  DECLARE @TextXML varchar(max) 
  DECLARE @TextXMLOUT varchar(max) 
  SET @TextXML = '<?xml version="1.0" encoding="UTF-8"?>
  <RequestGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <FirstName>FirstName1830404</FirstName>
  <LastName>Филимонихина</LastName>
  <MiddleName>SecondName1830404</MiddleName>
  <PolicyNumber>77050102-00492-00002</PolicyNumber>
  </RequestGetData>'
  EXEC [dbo].[spen_GetData] @TextXMLOUT, @TextXML, 1

  DECLARE @TextXML varchar(max) 
  DECLARE @TextXMLOUT varchar(max) 
  SET @TextXML = '<?xml version="1.0" encoding="UTF-8"?>
  <RequestGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <FirstName>Юлия</FirstName>
  <LastName>Третьякова</LastName>
  <MiddleName>Александровна</MiddleName>
  <PolicyNumber>01050100-04377-0002</PolicyNumber>
  </RequestGetData>'
  EXEC [dbo].[spen_GetData_NEW] @TextXMLOUT, @TextXML, 1
  
  
  DECLARE @TextXML varchar(max) 
  DECLARE @TextXMLOUT varchar(max) 
  SET @TextXML = '<?xml version="1.0" encoding="UTF-8"?>
  <RequestGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <FirstName>Илья</FirstName>
  <LastName>Волынкин</LastName>
  <MiddleName>Александрович</MiddleName>
  <PolicyNumber>77050102-00528-00034</PolicyNumber>
  </RequestGetData>'
  EXEC [dbo].[spen_GetData_NEW] @TextXMLOUT, @TextXML, 1
                                        
    

  DECLARE @TextXML varchar(max) 
  DECLARE @TextXMLOUT varchar(max) 
  SET @TextXML = '<?xml version="1.0" encoding="UTF-8"?>
  <RequestGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <FirstName>Владимир</FirstName>
  <LastName>Копылов</LastName>
  <MiddleName>Игоревич</MiddleName>
  <PolicyNumber>77050102-00753</PolicyNumber> 
  </RequestGetData>'
  EXEC [dbo].[spen_GetData_NEW] @TextXMLOUT, @TextXML, 1
  
  DECLARE @TextXML varchar(max) 
  DECLARE @TextXMLOUT varchar(max) 
  SET @TextXML = '<?xml version="1.0" encoding="UTF-8"?>
  <RequestGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <FirstName>Анастасия</FirstName>
  <LastName>Надеждина</LastName>
  <MiddleName>Андреевна</MiddleName>
  <PolicyNumber>77050102-00753-61216</PolicyNumber> 
  </RequestGetData>'
  EXEC [dbo].[spen_GetData] @TextXMLOUT, @TextXML, 1
                                        
       
    
                                        
  --Получение тестовых данных по ВЗР
  select --top 1
    ДогСтрах.Номер,
    Полис.Номер,
    ФЛ.ФИОПолные,
    ФЛ.ДатаРождения,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МногократнаяПоездка,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МаксСрок,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.СуммаВЗРДоллары,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.СуммаВЗРЕвро,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортЛат,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортРус,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.Примечание,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.Премия,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.Сумма,
    Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.Код,
    ДатаНачала,
    ДатаОкончания
  from Застрахованный
  where Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.ВидСтрахРиска = 3
  and ДатаОкончания > GetDate()
  
  Номер	Номер_1	ФИОПолные	ДатаРождения	МногократнаяПоездка	МаксСрок	СуммаВЗРДоллары	СуммаВЗРЕвро	ВидСпорта	СпортЛат	СпортРус	Примечание	Премия	Сумма	Код	ДатаНачала	ДатаОкончания
  01050100-04377	01050100-04377-0002	Третьякова Юлия Александровна	01.09.1987	1	30	50000	35000							ВЗР_Эконом_30 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-0003	Абрашина Маргарита Евгеньевна	24.02.1955	1	60	50000	35000	14	Mountain skiing, diving	Горнолыжный спорт, дайвинг	8		0	ВЗР_Стандарт+. Горнолыжный спорт, дайвинг_60 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-0004	Агоштон Владимир Иванович	11.11.1960	1	30	50000	35000							ВЗР_Эконом_30 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-0009	Антоненко Дмитрий Анатольевич	10.03.1974	1	60	50000	35000	14	Mountain skiing, diving	Горнолыжный спорт, дайвинг	8		0	ВЗР_Стандарт+. Горнолыжный спорт, дайвинг_60 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-0011	Баев Сергей Юрьевич	14.11.1973	1	60	50000	35000	14	Mountain skiing, diving	Горнолыжный спорт, дайвинг	8		0	ВЗР_Стандарт+. Горнолыжный спорт, дайвинг_60 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-0015	Безлихотнова Анастасия Александровна	26.06.1986	1	30	50000	35000							ВЗР_Эконом_30 дней	01.04.2011	30.04.2018
  01050100-04377	01050100-04377-02369	Самусенок Светлана Викторовна	22.12.1993	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02370	Сапронов Юрий Сергеевич	18.12.1992	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02363	Лапшин Александр Владимирович	04.08.1990	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02364	Литвинова Мария Сергеевна	19.01.1994	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02365	Михантьева Александра Александровна	28.12.1988	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02366	Новиков Владимир Николаевич	07.12.1986	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02367	Пашков Дмитрий Александрович	11.01.1990	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02368	Решетняк Илья Леонидович	21.07.1991	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018
  01050100-04377	01050100-04377-02357	Илишкин Иван Саналович	28.05.1993	1	30	50000	35000							ВЗР_Эконом_30 дней	15.11.2017	30.04.2018


  SELECT 
    @FirstName, 
    @LastName,
    @MiddleName, 
    @PolicyNumber, 
    @SchemaVersion, 
    @InsID,
    @ContractID,
    @InsurerID,
    @EntityID,
    @FaceID,
    @SportRus,
    @SportLat,
    @MaxPeriod,
    @VZRProgramID,
    @VZRProductID,
    @InsProgramBeginDate,
    @InsProgramEndDate, 
    @MedInsSumUsd, 
    @MedInsSumEur
    
    SELECT * from @SportTable 
  */

  DECLARE @XMLData xml
  DECLARE @XMLText varchar(max)
  DECLARE @XMLError varchar(1000)
  DECLARE @FIOPolis varchar(100)
  DECLARE @FirstName     varchar(500)
  DECLARE @LastName      varchar(500)
  DECLARE @MiddleName    varchar(500)
  DECLARE @PolicyNumber  varchar(500)
  
  DECLARE @InsID        int = 0
  DECLARE @ContractID   int = 0
  DECLARE @InsurerID    int = 0
  DECLARE @EntityID     int = 0  
  DECLARE @FaceID       int = 0

  DECLARE @Birthday     date
  DECLARE @OrgID        int = 0
  DECLARE @OrgName      varchar(250)
  DECLARE @OrgInn       varchar(50)
  DECLARE @OrgKpp       varchar(50)
  DECLARE @OrgPhone     varchar(50)
  DECLARE @PhoneM       varchar(50)
  DECLARE @PhoneW       varchar(50)
  DECLARE @PhoneH       varchar(50)
  DECLARE @SportRus     varchar(250)
  DECLARE @SportLat     varchar(250)
  DECLARE @MaxPeriod    int = 0
  DECLARE @VzrProgramID int = 0
  DECLARE @VzrProductID int = 0
  DECLARE @InsProgramBeginDate varchar(10)
  DECLARE @InsProgramEndDate varchar(10)
  DECLARE @MedInsSumUsd NUMERIC(31,2)
  DECLARE @MedInsSumEur NUMERIC(31,2)
  DECLARE @VZRProgramName varchar(250)
  DECLARE @VZRProductName varchar(250)
  DECLARE @Multitrip     int = 0

  --Следующие переменные чтобы определить, что срок действия полиса застрахованного уже истек (или не начался)
  DECLARE @StartDate datetime
  DECLARE @EndDate datetime
  DECLARE @ErrorMes varchar(1000) = ''
  DECLARE @ErrorCode varchar(3)   = ''
  DECLARE @xml xml

  --Дополнительные теги
  DECLARE @CorpContrNumber    varchar(50)
  DECLARE @CorpContrSignDate  datetime
  DECLARE @IsPrintVzrPrem     int = 0 --VZRPrint      int = 0
  DECLARE @VzrPremRUB         NUMERIC(31,2) = 0 
  DECLARE @PolicyCodification varchar(50)
  DECLARE @IsInsuredPersonDoc int = 0  -- @DULObligatory     int = 0
  DECLARE @MedInsVariant      varchar(250)
  DECLARE @DayAddCount        int = 3
  DECLARE @ContractNumber     varchar(50)



  --Разбор с помощью XQuery:
  /*
  SET @xml = @TextXML
  SELECT 
      @FirstName     = p.value('(FirstName/text())[1]',     'varchar(255)'),
      @LastName      = p.value('(LastName/text())[1]',      'varchar(255)'),
      @MiddleName    = p.value('(MiddleName/text())[1]',    'varchar(255)'),       
      @PolicyNumber  = p.value('(PolicyNumber/text())[1]',  'varchar(255)'),
      @SchemaVersion = p.value('(SchemaVersion/text())[1]', 'varchar(255)')                         
  from @xml.nodes('/RequestGetData') as u(p)
  --Проверка
  --SELECT @FirstName, @LastName, @MiddleName, @PolicyNumber, @SchemaVersion
  */
  
  --Так разбор надежнее: 
  SET @FirstName    = [dbo].[fn_StringBetweenString](@TextXML, '<FirstName>',    '</FirstName>')
  SET @LastName     = [dbo].[fn_StringBetweenString](@TextXML, '<LastName>',     '</LastName>')
  SET @MiddleName   = [dbo].[fn_StringBetweenString](@TextXML, '<MiddleName>',   '</MiddleName>')
  SET @PolicyNumber = [dbo].[fn_StringBetweenString](@TextXML, '<PolicyNumber>', '</PolicyNumber>')
  SET @FIOPolis = @LastName + ' ' + @FirstName + ' ' + @MiddleName + ' ' + @PolicyNumber


  /*--Сначала поиск застрахованного
   SELECT top 1
      @InsID               = ИДОбъекта,
      @StartDate           = ДатаНачала,
      @EndDate             = ДатаОкончания,
	    @InsProgramBeginDate = CONVERT(varchar(10), ДатаНачала, 120),
      @InsProgramEndDate   = CONVERT(varchar(10), ДатаОкончания, 120),
    FROM Застрахованный
    WHERE Полис.Номер  = 'тест-00001-00043'  --'@PolicyNumber'
       AND ФЛ.НаФа     = 'Бовт'              --@LastName'
       AND ФЛ.Имя      = 'Георгий'           --'@FirstName'
       AND ФЛ.Отчество = 'Георгович'         --'@MiddleName'
  */


  --Сначала поиск застрахованного
  IF (@PolicyNumber  = '77050102-00753') 
  BEGIN
	  Select
	    Top 1
	    @InsID     = EOT_1.ID,
	    @StartDate = EOT_8.StartDate,
	    @EndDate   = EOT_10.EndDate,
	    @InsProgramBeginDate = CONVERT(varchar(10), EOT_8.StartDate, 120),
	    @InsProgramEndDate   = CONVERT(varchar(10), EOT_10.EndDate, 120),
	    @Birthday  = EOT_11.BirthDate,
      @ContractNumber = EOT_21.Number
	  From
	    RelContFace EOT_1
	    Left Outer Join RelContFace_Hist_StartDate EOT_8
		  On (EOT_8.ID = EOT_1.ID) And (EOT_8.StateDate = (
		    Select Max(StateDate) From RelContFace_Hist_StartDate
		    Where
			  (StateDate <= (GetDate()+90000)) And (EOT_1.ID = ID)
		  ))
	    Left Outer Join RelContFace_Hist_EndDate EOT_10
		  On (EOT_10.ID = EOT_1.ID) And (EOT_10.StateDate = (
		    Select Max(StateDate) From RelContFace_Hist_EndDate
		    Where
			  (StateDate <= (GetDate()+90000)) And (EOT_1.ID = ID)
		  ))
	    Left Outer Join ContractIns EOT_13 Inner Join Document EOT_21
		  On EOT_21.DocumentID = EOT_13.CID
		  On EOT_13.CID = EOT_1.ContractID
	    Left Outer Join FacePerson EOT_11
		  On EOT_11.FaceID = EOT_1.FaceID
	  Where
	    EOT_21.Number = @PolicyNumber AND EOT_11.Name = @LastName AND EOT_11.FirstName = @FirstName AND EOT_11.SecondName = @MiddleName  
  END ELSE
  BEGIN
    --Сначала поиск застрахованного
    SELECT TOP 1
	    @InsID     = EOT_1.ID,
	    @StartDate = EOT_8.StartDate,
	    @EndDate   = EOT_10.EndDate,
	    @InsProgramBeginDate = CONVERT(varchar(10), EOT_8.StartDate, 120),
	    @InsProgramEndDate   = CONVERT(varchar(10), EOT_10.EndDate, 120),
	    @Birthday  = EOT_12.BirthDate,
      @ContractNumber = EOT_211.Number
    From RelContFace EOT_1
	    Left Outer Join RelContFace_Hist_StartDate EOT_8
		  On (EOT_8.ID = EOT_1.ID) And (EOT_8.StateDate = (Select Max(StateDate)  From RelContFace_Hist_StartDate
		    Where (StateDate <= (GetDate()+90000)) AND (EOT_1.ID = ID)))
	  
      Left Outer Join RelContFace_Hist_InsPolicy EOT_9
		  On (EOT_9.ID = EOT_1.ID) And (EOT_9.StateDate = (Select Max(StateDate) From RelContFace_Hist_InsPolicy 
		    Where (StateDate <= (GetDate()+90000)) AND (EOT_1.ID = ID)))
	    Left Outer Join RelContFace_Hist_EndDate EOT_10
		  On (EOT_10.ID = EOT_1.ID) And (EOT_10.StateDate = (Select Max(StateDate) From RelContFace_Hist_EndDate
        Where (StateDate <= (GetDate()+90000)) AND (EOT_1.ID = ID)))
	    Left Outer Join FacePerson EOT_12 On EOT_12.FaceID = EOT_1.FaceID
	    Left Outer Join InsPolicy EOT_11 On EOT_11.ID = EOT_9.InsPolicy
      --Добавляем номер договора.
      Left Outer Join ContractIns EOT_131 Inner Join Document EOT_211
		  On EOT_211.DocumentID = EOT_131.CID
		  On EOT_131.CID = EOT_1.ContractID
	  Where
	    EOT_11.Number         = @PolicyNumber 
	    AND EOT_12.Name       = @LastName 
	    AND EOT_12.FirstName  = @FirstName 
	    --AND ISNULL(EOT_12.SecondName, '') = ISNULL(@MiddleName, '')
    END

  
    /*IF (@ContractNumber IN 
    (     
    --Банк ВТБ
    '77050102-00753', 
    
    --Максима Телеком
    '77050102-00769',
    
    --Остальные договоры -Группа АФК
    '77050103-00075',
    '77050103-00074',
    '77050103-00073',
    '77050103-00072',
    '77050103-00071',
    '77050103-00070',
    '77050103-00069',
    '77050103-00068',
    '77050103-00067',
    '77050103-00066',
    '77050103-00065',
    '77050103-00064',
    '77050103-00063',
    '77050103-00062',
    '77050103-00061',
    '77050103-00060',
    '77050103-00059',
    '77050103-00058',
    '77050103-00057',
    '77050103-00056',
    '77050103-00055',
    '77050103-00054',
    '77050103-00053',
    '77050103-00052',
    '77050103-00051',
    '77050103-00050',
    '77050103-00049',
    '77050103-00048',
    '77050103-00047',
    '77050103-00046',
    '77050103-00045',
    '77050103-00044',
    '77050103-00043'))
  BEGIN
    SET @DayAddCount = 20
  END 
  */
  SET @DayAddCount = 20
    --Коды ошибок:
    --500 - Застрахованный не найден.
    --501 - Срок действия полиса ещё не начался.
    --502 - Срок действия полиса уже закончился.
    --503 - Застрахованный найден, но у него нет программы ВЗР.  
    --Сообщение об ошибке должно быть такого вида: 
    SET @XMLError = '<?xml version="1.0" encoding="UTF-8"?>'
    + '<ResponseGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:vtbinsc="http://vtbins.ru/schema/common10" xmlns:wsrls="http://ws.rls10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">' 
    + '  <Errors>'
    + '    <vtbinsc:ErrorInfo>'
    + '      <vtbinsc:ErrorType>WARNING</vtbinsc:ErrorType>'
    + '      <vtbinsc:ErrorCode>КодОшибки</vtbinsc:ErrorCode>'
    + '      <vtbinsc:ErrorMessage>СообщениеОбОшибке</vtbinsc:ErrorMessage>'
    + '    </vtbinsc:ErrorInfo>'
    + '  </Errors>'
    + '</ResponseGetData>'

    --500 - Застрахованный не найден.
    IF @InsID = 0 
    BEGIN
      SET @ErrorCode = '500'
      SET @ErrorMes  = 'Застрахованный не найден: ' + IsNull(@FIOPolis, '')    
    END  

    --501 - Срок действия полиса ещё не начался.
    IF (@StartDate > (Getdate() + @DayAddCount)) AND (@ErrorMes = '')
    BEGIN
      SET @ErrorCode = '501'
      SET @ErrorMes  = 'Застрахованный найден, но срок действия полиса ещё не начался: ' + IsNull(@FIOPolis, '')   
    END

    --502 - Срок действия полиса уже закончился.
    IF (@EndDate < Getdate()) AND (@ErrorMes = '')
    BEGIN
      SET @ErrorCode = '502'
      SET @ErrorMes  = 'Застрахованный найден, но срок действия полиса уже закончился: ' + IsNull(@FIOPolis, '')   
    END

    IF (@ErrorMes <> '')
    BEGIN   
      SET @XMLError = REPLACE(@XMLError, 'КодОшибки', @ErrorCode) 
      SET @XMLError = REPLACE(@XMLError, 'СообщениеОбОшибке', @ErrorMes)   
	
	
	    IF @AsXML = 0 
	    BEGIN 
	      SET @TextXMLOUT = @XMLError 
        SELECT @XMLError as Result
      END ELSE
	    BEGIN
	      SET @XMLError = REPLACE(@XMLError, '<?xml version="1.0" encoding="UTF-8"?>', '') 	   
	      SET @xml = @XMLError
	      SELECT @xml
      END
      RETURN
    END

  /*--Поиск остальных данных.
  --Первый и второй вариант нужны. Не удалять. Первый вариан чтобы тестировать, второй чтобы получить SQL.
  --Первый вариант:
 SELECT TOP 1
      ДогСтрах, 
	  ДогСтрах.Страхователь, 
	  ДогСтрах.Страхователь.ИДСущностиОбъекта, 
	  ФЛ,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортРус,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортЛат,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МаксСрок,
	  Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МногократнаяПоездка,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР.Сокр as VZRProductID,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР.ПродуктВЗР.Наим as VZRProductName,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог as VZRProgramID,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.Наим as VZRProgramName,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СуммаВЗРДоллары as MedInsSumUsd,
      Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СуммаВЗРЕвро as MedInsSumEur,
	 	  
	  ДогСтрах.Номер,
	  ДогСтрах.ДатаПодписания,
	  Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ПечатьПремииВЗР,
	  Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.Премия as ПремияВЗРRUB,
	  ДогСтрах.КодУчета
	  ДогСтрах.ТребуетсяДУЛ
    FROM Застрахованный
        WHERE ИДОБъекта = @InsID
    and Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.ВидСтрахРиска.Сокр = 'ВЗР'
    and ДатаСостОбъекта = GetDate()
    and Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.ДатаСостОбъекта = GetDate()

   --Второй вариант:
  SELECT TOP 1
      @ContractID     = ДогСтрах,
      @InsurerID      = ДогСтрах.Страхователь,
      @EntityID       = ДогСтрах.Страхователь.ИДСущностиОбъекта,
      @FaceID         = ФЛ,
      @SportRus       = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортРус,
      @SportLat       = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ВидСпорта.СпортЛат,
      @MaxPeriod      = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МаксСрок,
	  @Multitrip      = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.МногократнаяПоездка,
      @VZRProductID   = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР.ПродуктВЗР,
      @VZRProductName = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР.ПродуктВЗР.Наим,
      @VZRProgramID   = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР,
      @VZRProgramName = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ТипПрограммыВЗР.Сокр,
      @MedInsSumUsd   = ROUND(Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СуммаВЗРДоллары, 2),
      @MedInsSumEur   = ROUND(Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СуммаВЗРЕвро, 2),	  	
	  @CorpContrNumber     = ДогСтрах.Номер,
	  @CorpContrSignDate   = ДогСтрах.ДатаПодписания,
	  @IsPrintVzrPrem      = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.СтрахПрог.ПечатьПремииВЗР,
	  @VzrPremRUB          = Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.Премия as ПремияВЗРRUB,
	  @PolicyCodification  = ДогСтрах.КодУчета,
	  @IsInsuredPersonDoc  = ДогСтрах.ТребуетсяДУЛ		
	FROM Застрахованный
        WHERE
    ИДОБъекта = @InsID
    and Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.ВидСтрахРиска.Сокр = 'ВЗР'
    and ДатаСостОбъекта = GetDate()
    and Вариант.ВариантДогСтрах.ПрограммаВариантДогСтрах.ДатаСостОбъекта = GetDate()
  */
  

/*Select
  Top 1
  @ContractID = EOT_1.ContractID,
  @InsurerID = EOT_11.InsurerID,
  @EntityID = EOT_20.EntityID,
  @FaceID = EOT_1.FaceID,
  @SportRus = EOT_36.NameRus,
  @SportLat = EOT_36.NameLat,
  @MaxPeriod = EOT_35.MaxPeriod,
  @Multitrip = NULLIF(EOT_35.Multitrip, 0),   
  @VZRProductID = IsNull(EOT_37.VZRProduct, 0),
  @VZRProductName = EOT_38.Name, 
  @VZRProgramID = IsNull(EOT_37.ID, 0), ---- @VZRProgramID = EOT_31.InsProgram,
  @VZRProgramName = EOT_37.Brief,
  @MedInsSumUsd = ROUND(EOT_34.AmountVZRUSD, 2),
  @MedInsSumEur = ROUND(EOT_34.AmountVZREURO, 2)
From
  RelContFace EOT_1

  Left Outer Join RelContFace_Hist_FaceVariant EOT_7
    On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (
      Select
        Max(StateDate)
      From
        RelContFace_Hist_FaceVariant
      Where
        (StateDate <= GetDate()) And (EOT_1.ID = ID)
    ))
  Left Outer Join FaceVariant EOT_21
    On EOT_21.ID = EOT_7.FaceVariant
  Left Outer Join ContractVariant EOT_26
    On EOT_26.ID = EOT_21.ContractVariantID
  Left Outer Join ContractVariantProgram EOT_31 Left Outer Join ContractVariantProgram_Hist_Amount EOT_34
    On (EOT_34.ID = EOT_31.ID) And (EOT_34.StateDate = (
      Select
        Max(StateDate)
      From
        ContractVariantProgram_Hist_Amount
      Where
        (StateDate <= GetDate()) And (EOT_31.ID = ID)
    ))
    On EOT_31.Rel_ContractVariant = EOT_26.ID
  Left Outer Join InsRiskType EOT_39
    On EOT_39.InsRiskTypeID = EOT_31.InsRiskTypeID
  Left Outer Join InsProgram EOT_35
    On EOT_35.ID = EOT_31.InsProgram
  Left Outer Join VZRProgramType EOT_37
    On EOT_37.ID = EOT_35.VZRProgramType
  Left Outer Join VZRProduct EOT_38
    On EOT_38.ID = EOT_37.VZRProduct
  Left Outer Join SportKind EOT_36
    On EOT_36.ID = EOT_35.SportKind
  Left Outer Join ContractIns EOT_11
    On EOT_11.CID = EOT_1.ContractID
  Left Outer Join Face EOT_20
    On EOT_20.FaceID = EOT_11.InsurerID
Where
  EOT_1.ID = @InsID and EOT_39.Brief = 'ВЗР'
*/




Select
Top 1
@ContractID         = EOT_1.ContractID,
@InsurerID          = EOT_11.InsurerID,
@EntityID           = EOT_20.EntityID,
@FaceID             = EOT_1.FaceID ,
@SportRus           = EOT_36.NameRus,
@SportLat           = EOT_36.NameLat,
@MaxPeriod          = EOT_35.MaxPeriod,
@Multitrip          = EOT_35.Multitrip,
@VZRProductID       = EOT_37.VZRProduct,
@VZRProductName     = EOT_38.Name,
@VZRProgramID       = EOT_35.VZRProgramType,
@VZRProgramName     = EOT_37.Brief,
@MedInsSumUsd       = ROUND(EOT_34.AmountVZRUSD, 2),
@MedInsSumEur       = ROUND(EOT_34.AmountVZREURO, 2),
@CorpContrNumber    = EOT_19.Number,
@CorpContrSignDate  = EOT_19.SignDate,
@IsPrintVzrPrem     = ISNULL(EOT_35.VZRPrint, 0),  
@VzrPremRUB         = EOT_33.Premium,
@PolicyCodification = EOT_11.CodeAccount,
@IsInsuredPersonDoc = ISNULL(EOT_11.DULObligatory, 0),
@MedInsVariant      = LTRim(Rtrim(EOT_26.Name)) 

/*EOT_1.ContractID  as ContractID,
EOT_11.InsurerID   as InsurerID,
EOT_20.EntityID   as EntityID,
EOT_1.FaceID      as FaceID,
EOT_36.NameRus    as SportRus,
EOT_36.NameLat    as SportLat ,
EOT_35.MaxPeriod  as MaxPeriod,
EOT_35.Multitrip  as Multitrip,
EOT_37.VZRProduct as VZRProductID, 
EOT_38.Name                     as VZRProductName,
EOT_35.VZRProgramType           as VZRProgramID,
EOT_37.Brief                    as VZRProgramName,
ROUND(EOT_34.AmountVZRUSD, 2)   as MedInsSumUsd ,
ROUND(EOT_34.AmountVZREURO, 2)  as MedInsSumEur,
EOT_19.Number                   as CorpContrNumber ,
EOT_19.SignDate                 as CorpContrSignDate,
ISNULL(EOT_11.VZRPrint, 0)      as IsPrintVzrPrem ,  
ROUND(EOT_33.Premium, 2)        as VzrPremRUB,
EOT_11.CodeAccount              as PolicyCodification,
ISNULL(EOT_11.DULObligatory, 0) as IsInsuredPersonDoc,
EOT_39.Brief                    as RiskName
*/

From
RelContFace EOT_1
Left Outer Join RelContFace_Hist_FaceVariant EOT_7 On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant Where (StateDate <= (GetDate() + 9000)) And (EOT_1.ID = ID)))
Left Outer Join FaceVariant EOT_21 On
EOT_21.ID
=
EOT_7.FaceVariant
Left Outer Join ContractVariant EOT_26 On
EOT_26.ID
=
EOT_21.ContractVariantID
Left Outer Join ContractVariantProgram EOT_31
Left Outer Join ContractVariantProgram_Hist_Premium EOT_33 On (EOT_33.ID = EOT_31.ID) And (EOT_33.StateDate = (Select Max (StateDate) From ContractVariantProgram_Hist_Premium Where (StateDate <=(GetDate() + 9000)) And (EOT_31.ID = ID)))
Left Outer Join ContractVariantProgram_Hist_Amount EOT_34 On (EOT_34.ID = EOT_31.ID) And (EOT_34.StateDate = (Select Max (StateDate) From ContractVariantProgram_Hist_Amount Where (StateDate <= (GetDate() + 9000)) And (EOT_31.ID = ID))) On
EOT_31.Rel_ContractVariant = EOT_26.ID
Left Outer Join InsRiskType EOT_39 On
EOT_39.InsRiskTypeID
=
EOT_31.InsRiskTypeID
Left Outer Join InsProgram EOT_35 On
EOT_35.ID
=
EOT_31.InsProgram
Left Outer Join VZRProgramType EOT_37 On
EOT_37.ID
=
EOT_35.VZRProgramType
Left Outer Join InsProduct EOT_38 On
EOT_38.InsProductID
=
EOT_37.VZRProduct
Left Outer Join SportKind EOT_36 On
EOT_36.ID
=
EOT_35.SportKind
Left Outer Join ContractIns EOT_11
Inner Join Document EOT_19 On
EOT_19.DocumentID = EOT_11.CID On
EOT_11.CID
=
EOT_1.ContractID
Left Outer Join Face EOT_20 On
EOT_20.FaceID
=
EOT_11.InsurerID
Where
EOT_1.ID
=
@InsID
--and EOT_39.Brief = 'ВЗР'
ORDER BY ISNULL(EOT_39.Brief, 'ДМС')


  --503 - Застрахованный найден, но у него нет программы ВЗР. 
  --IF (@VzrProgramID = 0) 
  --BEGIN
  --  SET @ErrorCode = '503'
  --  SET @ErrorMes  = 'Застрахованный найден, но у него нет программы ВЗР: ' + @FIOPolis    
  --  SET @XMLError = REPLACE(@XMLError, 'КодОшибки', @ErrorCode) 
  --  SET @XMLError = REPLACE(@XMLError, 'СообщениеОбОшибке', @ErrorMes)      
  --  SET @TextXMLOUT = @XMLError
  --  SELECT @XMLError as Result   
  --  RETURN      
  --END

  --Проверка
  /*SELECT  @InsID  as InsID,
    @ContractID   as ContractID,
    @InsurerID    as InsurerID, 
    @EntityID     as EntityID,
    @FaceID       as FaceID,
    @SportRus     as SportRus,
    @SportLat     as SportLat,
    @MaxPeriod    as MaxPeriod,
    @VZRProductID as VZRProductID,
    @VZRProductName as VZRProductName,
    @VZRProgramID   as VZRProgramID,
    @VZRProgramName as VZRProgramName,
    @InsProgramBeginDate as InsProgramBeginDate,
    @InsProgramEndDate   as InsProgramEndDate,
    @MedInsSumUsd   as MedInsSumUsd,
    @MedInsSumEur   as MedInsSumEur,
	@VZRPrint       as VZRPrint,
    @DULObligatory 	as DULObligatory
    RETURN */

  --Если страхователь является ФЛ
  IF @EntityID = 1561
  BEGIN
    /* SELECT ДатаРождения as Birthday,
         ИДОбъекта    as OrgID,
         ФИОПолное    as OrgName,
         ИНН          as INN,
         NULL         as KPP,
         ТелефонМобильный as PhoneM,
         ТелефонРабочий   as PhoneW,
         ТелефонДомашний  as PhoneH
    from ФЛ where ИДОбъекта = 234334*/

    SELECT TOP 1
      --@Birthday = CAST(EOT_1.BirthDate as Date),
      @OrgID    = EOT_1.FaceID,
      @OrgName  = (EOT_1.Name + ' ' + IsNull(EOT_1.FirstName, '') + ' ' + IsNull(EOT_1.SecondName, '')), --ФИОПолное
      @OrgInn   = EOT_2.INN ,
      @OrgKpp   = NULL,
      @PhoneM   = EOT_1.MobilePhone,
      @PhoneW   = EOT_1.Phone2,
      @PhoneH   = EOT_1.Phone1
    FROM
      FacePerson EOT_1
        Inner Join Face EOT_2 ON EOT_2.FaceID = EOT_1.FaceID
    WHERE
      EOT_1.FaceID = @InsurerID
    
    --Вариант 1.
    --Приведем к NULL если пусто, так как в XML NULL не попадает с помощью FOR XML PATH,
    --поэтому если телефон пустой, то лишней запятой не будет.
    --IF @PhoneM = '' 
    --  SET @PhoneM = NULL
    --IF @PhoneW = '' 
    --  SET @PhoneW = NULL
    --IF @PhoneH = '' 
    --  SET @PhoneH = NULL

    --Приводим все телефоны в одну строку через запятую.
    --SET @OrgPhone = STUFF((SELECT ',' + phone from (SELECT @PhoneM as phone UNION SELECT @PhoneW as phone UNION SELECT @PhoneH as phone) t1 FOR XML PATH('')), 1, 1, '')
    
    --Вариант 2.
    SET @OrgPhone = ''
    IF (@OrgPhone = '') AND (@PhoneM <> '') SET @OrgPhone = @PhoneM
    IF (@OrgPhone = '') AND (@PhoneW <> '') SET @OrgPhone = @PhoneW
    IF (@OrgPhone = '') AND (@PhoneH <> '') SET @OrgPhone = @PhoneH
    
    SET @OrgPhone = REPLACE(@OrgPhone, ' ', '')
    SET @OrgPhone = REPLACE(@OrgPhone, ';', ',')
    --SELECT LEFT(@OrgPhone, CHARINDEX(',', @OrgPhone)-1) WHERE  CHARINDEX(',', @OrgPhone) > 0
    SET @OrgPhone = dbo.ReplacePattern(@OrgPhone, '%[^-0-9()+]%', '')    
  END 
 
  --Если страхователь не ФЛ
  IF (@EntityID <> 1561)
  BEGIN
    /*SELECT NULL as Birthday,
       ИДОбъекта    as OrgID,
       НаФа         as OrgName,
       ИНН          as INN,
       КПП          as KPP,
       Телефон      as Phone
    from ЮЛ where ИДОбъекта = 234334 */
    
    /*SELECT
      --@Birthday =  NULL,
      @OrgID    = EOT_1.FaceID,
      --@OrgName  = EOT_1.Name,
      @OrgInn   = EOT_2.INN,
      @OrgKpp   = EOT_1.KPP,
      @OrgPhone = EOT_1.Phone1,

      @OrgName = (CASE
                    WHEN (EOT_1.JuridicalOrgStatusID IS NULL OR LEN(EOT_3.Brief) = 0) THEN EOT_1.Name
                    ELSE EOT_3.Brief + ' ' + EOT_1.Name
                  END)
    FROM
      FaceJuridical EOT_1
      Inner Join Face EOT_2 ON EOT_2.FaceID = EOT_1.FaceID
      Left Outer Join JuridicalOrgStatus EOT_3 On EOT_3.JuridicalOrgStatusID = EOT_1.JuridicalOrgStatusID
    WHERE EOT_1.FaceID = @InsurerID*/

	Select
	  @OrgID   = EOT_1.FaceID,
	  @OrgName = (Case
		When (
		  Select
			Top 1
			1 Column1
		  From
			(
			  Select
				EOT_3.Name Наим
			  From
				JuridicalOrgStatus EOT_3
			  Where
				IsNull(EOT_3.Name, '')
				<> '' and CHARINDEX(EOT_3.Name, EOT_1.Name)
				between 1 and 4
			  Union
				All
			  Select
				EOT_4.Brief Сокр
			  From
				JuridicalOrgStatus EOT_4
			  Where
				IsNull(EOT_4.Brief, '')
				<> '' and PATINDEX(EOT_4.Brief + '[ ("'',.]%', EOT_1.Name)
				between 1 and 4
			) Костыль
		) = 1 Then IsNull(EOT_1.Name, '')
		Else IsNull(EOT_5.Brief + ' ', '')
		+ IsNull(EOT_1.Name, '')
	  End),
	  @OrgInn   = EOT_2.INN,
	  @OrgKpp   = EOT_1.KPP,
	  @OrgPhone = EOT_1.Phone1
	From
	  FaceJuridical EOT_1
	  Inner Join Face EOT_2
		On EOT_2.FaceID = EOT_1.FaceID
	  Left Outer Join JuridicalOrgStatus EOT_5
		On EOT_5.JuridicalOrgStatusID = EOT_1.JuridicalOrgStatusID
	Where
	  EOT_1.FaceID = @InsurerID
  END
  
  /*--Проверка 
  SELECT 
    @Birthday as Birthday,
    @OrgID    as OrgID,
    @OrgName  as OrgName,
    @OrgInn   as OrgInn,
    @OrgKpp   as OrgKpp,
    @PhoneM   as PhoneM,
    @PhoneW   as PhoneW, 
    @PhoneH   as PhoneH, 
    @OrgInn   as OrgInn,
    @OrgKpp   as OrgKpp,
    @OrgPhone as OrgPhone

    RETURN */

  --Разделяем по запятым виды спорта. 
  --Важно чтобы в списке видов спорта на русском и английском было одинаковое кол-во запятых. Здесь нет проверки на это.   
  DECLARE @SportTable TABLE (ID int, SportRus varchar(250), SportLat varchar(250))
  INSERT INTO @SportTable
  SELECT t1.ArrayID AS ID, 
         t1.CharValue AS SportRus, 
         t2.CharValue AS SportLat 
  FROM [dbo].[fnen_StrToArray](@SportRus, ',') t1 
  LEFT JOIN (SELECT t2.ArrayID, t2.CharValue FROM [dbo].[fnen_StrToArray](@SportLat, ',') t2) t2 ON t1.ArrayID = t2.ArrayID
   
  --Проверка 
  --SELECT * FROM @SportTable
  --RETURN

  SELECT @XMLData = 
    (SELECT @Birthday as BirthDay, 
           @OrgID as OrgId,
           --NULL as Errors,   
           @OrgName as OrgName,
           @OrgInn as OrgInn,
           @OrgKpp as OrgKpp,   
           @OrgPhone as OrgPhone,
           (SELECT CAST(@VZRProductID as varchar(100)) AS Id,
                   'DIAFA' AS SysId,
                   'PRODUCTS_TYPE' AS [Type] WHERE @VZRProductID > 0 FOR XML PATH(''), TYPE) AS "VzrProductId",
            
           (SELECT CAST(@VZRProgramID as varchar(100)) AS Id,
                   'DIAFA' AS SysId,
                   'VZRPROGRAMMS_TYPE' AS [Type] WHERE @VZRProgramID > 0 FOR XML PATH(''), TYPE) AS "VzrProgramId",                         
           @InsProgramBeginDate as InsProgramBeginDate,
           @InsProgramEndDate as InsProgramEndDate,
           @MaxPeriod  as MaxInsPeriod, 		   
           @MedInsSumUsd as MedInsSumUsd,
           @MedInsSumEur as MedInsSumEur,          
           (select dbo.fn_IntToBool(sign(count(*)))  from @SportTable) as SportActivity,		   
           --@MaxPeriod as SportActivity,
           (SELECT SportLat as KindOfSportsLat, SportRus as KindOfSportsRus from @SportTable FOR XML PATH('KindOfSports'), TYPE) AS "SportList",
		   dbo.fn_IntToBool(@Multitrip)  as MultiTrip,		
		   @CorpContrNumber    as CorpContrNumber,
		   @CorpContrSignDate  as CorpContrSignDate ,
		   dbo.fn_IntToBool(@IsPrintVzrPrem) as IsPrintVzrPrem,  
		   @VzrPremRUB         as VzrPremRUB,
		   @PolicyCodification as PolicyCodification,
		   dbo.fn_IntToBool(@IsInsuredPersonDoc) as IsInsuredPersonDoc,
       @MedInsVariant      as MedInsVariant                  
       FOR XML PATH(''), TYPE) --ResponseGetData
   
  SET @XMLText = '<?xml version="1.0" encoding="UTF-8"?>' + CHAR(13) + CHAR(10) + 
                 '<ResponseGetData schemaVersion="1.0" xsi:schemaLocation="http://vtbins.ru/schema/getdata10 getdata-1.0.xsd" xmlns="http://vtbins.ru/schema/getdata10" xmlns:vtbinsc="http://vtbins.ru/schema/common10" xmlns:wsrls="http://ws.rls10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">' + 
                 CAST(@XMLData as varchar(max)) + '</ResponseGetData>'
    --Добавялем пространство имен
  SET @XMLText = REPLACE(@XMLText, '<Id>',     '<wsrls:Id>')  
  SET @XMLText = REPLACE(@XMLText, '</Id>',    '</wsrls:Id>') 
  SET @XMLText = REPLACE(@XMLText, '<SysId>',  '<wsrls:SysId>') 
  SET @XMLText = REPLACE(@XMLText, '</SysId>', '</wsrls:SysId>')
  SET @XMLText = REPLACE(@XMLText, '<Type>',   '<wsrls:Type>') 
  SET @XMLText = REPLACE(@XMLText, '</Type>',  '</wsrls:Type>')  
                      
  IF @AsXML = 0 
  BEGIN  
	SET @TextXMLOUT = @XMLText
    SELECT  @XMLText as Result
  END ELSE
  BEGIN
	SET @XMLText = REPLACE(@XMLText, '<?xml version="1.0" encoding="UTF-8"?>', '') 	   
	SET @xml = @XMLText
	SELECT @xml --Результат как XML. Удобно для отладки.
  END


  
  /*
  --На входе:
  FirstName - Имя застрахованного
  LastName - Фамилия застрахованного
  MiddleName - Отчество застрахованного
  PolicyNumber - Серия и номер полиса
  schemaVersion - Номер версии схемы

  --На выходе:
  BirthDay - Дата рождения страхователя
  OrgId - Идентификатор организации страхователя
  Errors - Список ошибок
  OrgName - Наименование организации страхователя
  OrgInn - ИНН организации страхователя
  OrgKpp - КПП организации страхователя
  OrgPhone - Номер телефона организации Страхователя
  VzrProductId - Идентификатор продукта ВЗР в договоре ДМС Type = PRODUCTS_TYPE 
  VzrProgramId - Код программы страхования ВЗР Type = VZRPROGRAMMS_TYPE
  InsProgramBeginDate - Дата начала действия программы
  InsProgramEndDate - Дата окончания действия программы
  MedInsSumUsd - Страховая сумма (по риску мед. расходы) в Долларах США
  MedInsSumEur - Страховая cумма (по риску мед. расходы) в Eвро
  SportActivity - Признак того, что застрахованный  будет заниматься спортом в течение срока действия договора страхования
  SportList - Список видов спорта
      KindOfSports - Вид спорта
      KindOfSportsLat - Латинское наименование вида спорта
      KindOfSportsRus - Русское наименование вида спорта

      KindOfSports - Вид спорта
      KindOfSportsLat - Латинское наименование вида спорта
      KindOfSportsRus - Русское наименование вида спорта


  --Схема XSD:
  <xs:sequence>
				<xs:element name="FirstName" type="xs:string">
					<xs:annotation>
						<xs:documentation>Имя застрахованного</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="LastName" type="xs:string">
					<xs:annotation>
						<xs:documentation>Фамилия застрахованного</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="MiddleName" type="xs:string">
					<xs:annotation>
						<xs:documentation>Отчество застрахованного</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="PolicyNumber" type="xs:string">
					<xs:annotation>
						<xs:documentation>Серия и номер полиса</xs:documentation>
					</xs:annotation>
				</xs:element>
			</xs:sequence>
			<xs:attribute name="schemaVersion" use="required">
				<xs:annotation>
					<xs:documentation>Номер версии схемы</xs:documentation>
				</xs:annotation>
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:enumeration value="1.0"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:attribute>
		</xs:complexType>

  <xs:documentation>Ответ на запрос данных о страхователе</xs:documentation>
		</xs:annotation>
		<xs:complexType>
			<xs:sequence>
				<xs:element name="BirthDay" type="xs:date" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Дата рождения страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="OrgId" type="xs:string" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Идентификатор организации страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="Errors" type="vtbinsc:ErrorListType" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Список ошибок</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="OrgName" type="xs:string" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Наименование организации страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="OrgInn" type="xs:string" minOccurs="0">
					<xs:annotation>
						<xs:documentation>ИНН организации страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="OrgKpp" type="xs:string" minOccurs="0">
					<xs:annotation>
						<xs:documentation>КПП организации страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="OrgPhone" type="xs:string" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Номер телефона организации Страхователя</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="VzrProductId" type="wsrls:ObjIdType" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Идентификатор продукта ВЗР в договоре ДМС Type = PRODUCTS_TYPE </xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="VzrProgramId" type="wsrls:ObjIdType" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Код программы страхования ВЗР Type = VZRPROGRAMMS_TYPE</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="InsProgramBeginDate" type="xs:date" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Дата начала действия программы</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="InsProgramEndDate" type="xs:date" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Дата окончания действия программы</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="MedInsSumUsd" type="xs:decimal" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Страховая сумма (по риску мед. расходы) в Долларах США</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="MedInsSumEur" type="xs:decimal" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Страховая cумма (по риску мед. расходы) в Eвро</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="SportActivity" type="xs:boolean" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Признак того, что застрахованный  будет заниматься спортом в течение срока действия договора страхования</xs:documentation>
					</xs:annotation>
				</xs:element>
				<xs:element name="SportList" minOccurs="0">
					<xs:annotation>
						<xs:documentation>Список видов спорта</xs:documentation>
					</xs:annotation>
					<xs:complexType>
						<xs:sequence>
							<xs:element name="KindOfSports" maxOccurs="unbounded">
								<xs:annotation>
									<xs:documentation>Вид спорта</xs:documentation>
								</xs:annotation>
								<xs:complexType>
									<xs:sequence>
										<xs:element name="KindOfSportsLat" type="xs:string">
											<xs:annotation>
												<xs:documentation>Латинское наименование вида спорта</xs:documentation>
											</xs:annotation>
										</xs:element>
										<xs:element name="KindOfSportsRus" type="xs:string">
											<xs:annotation>
												<xs:documentation>Русское наименование вида спорта</xs:documentation>
											</xs:annotation>
										</xs:element>
									</xs:sequence>
								</xs:complexType>
							</xs:element>
						</xs:sequence>
					</xs:complexType>
				</xs:element>
			</xs:sequence>
			<xs:attribute name="schemaVersion" use="required">
				<xs:annotation>
					<xs:documentation>Номер версии схемы</xs:documentation>
				</xs:annotation>
				<xs:simpleType>
					<xs:restriction base="xs:string">
						<xs:enumeration value="1.0"/>
					</xs:restriction>
				</xs:simpleType>
			</xs:attribute>
		</xs:complexType>
	</xs:element>
  */
END

