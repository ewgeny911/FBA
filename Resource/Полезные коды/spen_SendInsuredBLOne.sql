USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_SendInsuredBLOne]    Script Date: 10.01.2018 10:00:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_SendInsuredBLOne] (@CID int, @AID int, @UserName varchar(100), @Test int)
AS
BEGIN 
  --Описание:
  --Хранимая процедура формирует текст в виде XML для отправки на сервис Черного Списка.
  --Пример того точ должна возвращать хранимая процедура внизу хранимой процедуры.

  --@Test = 2 Тестовый режим. Возвращаем как Текст.	Это то, что вставляется через PUT_VALUE
  --@Test = 1 Тестовый режим. Возвращаем как XML. Это удобно для отладки, так как к такому результату можно писать запросы и Management Studio может показывать с разбивкой по тегам:
	
  --Пример вызова: 
  --EXEC [dbo].[spen_SendInsuredBLOne] 1650922, 0, 'diasoft', 1 
  --EXEC [dbo].[spen_SendInsuredBLOne] 0, 1650922, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 911553, 0, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 0, 1824140, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 1846916, 0, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 0, 1023961, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 1097695, 0, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 0, 1023961, 'diasoft', 1
  -- EXEC [dbo].[spen_SendInsuredBLOne] 1910058, 0, 'diasoft', 1
  
  --insert into dbo.UploadContractsToBL (EntityID, KindDocument, UserID, Status, ObjectID, ObjectEnID) values (1883, 1, 361, 'Новый', 1098979, 1640) 
  
  --delete from dbo.UploadContractsToBL where DocNumber is null
  --Таблица, по которой выгружать:
  --SELECT * FROM dbo.UploadContractsToBL  where  ObjectID = 1097695
  
  --Входящие параметры по которым можно сделать XML - @CID и @AID.
  --Если делаем по договору, то @CID > 0, а @AID = 0,
  --Если делаем по доп. соглашению, то @CID = 0, а @AID > 0.
  --Все остальные параметры, такие как Пользователь, Историчная дата, 
  --на которую выбираются данные, и др. - определяются здесь по @CID или @AID. 
  --Код один. И для построения XML по договору и по доп. соглашению.
  --DECLARE @CID int = 911553 --Для теста самый большой договор 574474 --Маленький договор 911553
  --DECLARE @AID int = 0

  --Остальные локальные параметры:
  DECLARE @TypeDoc int
  DECLARE @Oper1 int = 1
  --операции с кодом 8 быть не может. Поэтому in (1,8,5) это тоже самое, что in (1,5).  
  --Вместо 8 можно взять любое число кроме 1,2,3,4,5 - любое, какая операция не существует
  --8 взято просто так.
  DECLARE @Oper2 int = 8 
  DECLARE @Oper3 int = 5 
  DECLARE @VidDoc int
  DECLARE @DateCheck datetime
  DECLARE @XMLData xml
  DECLARE @XMLText VARCHAR(MAX)
  DECLARE @CountIns int
  DECLARE @Reason int = 0
  SET @TypeDoc = 1 
  
  --По умолчанию, если не задано.
  IF ISNULL(@UserName, '') = '' 
  BEGIN
    SET @UserName = 'diasoft' 
  END      
  
  --Формирование по договору:
  IF (@CID > 0) AND (@AID = 0) 
  BEGIN
    --Нельзя брать для договора, дату начала договора, 
    --так как бываю договоры, где дата начала первого доп.соглашения равна дате начала договора.
    --Поэтому строго 1900-01-01:
    SET @DateCheck = '1900-01-01 00:00:00.000'
    SET @Reason = @CID
  END
  
  --Формирование по доп. соглашению: 
  IF (@CID = 0) AND (@AID > 0) 
  BEGIN
    SET @TypeDoc = 2 
    SELECT @VidDoc = EOT_2.KindDocument FROM Document EOT_2 WHERE EOT_2.DocumentID = @AID
    --Если Пролонгация (@VidDoc = 16) то меняем 1,0,5 на 1,3,5.
    IF (@VidDoc = 16) SET @Oper2 = 3 --3- замена варианта. 
    SELECT @CID = Document, @DateCheck = StartDate FROM AdditionAgreement WHERE ID = @AID 
    SET @Reason = @AID  
  END
  
  --Входящих ИД нет, это ошибка вызова - выходим:   
  IF (ISNULL(@CID, 0) = 0) AND (ISNULL(@AID, 0) = 0) 
  BEGIN
    SELECT 'Ошибка' AS Status, 0 AS CountIns, @CID AS CID, @AID AS AID, @UserName AS UserName 
    RETURN 
  END
     
  --Получаем кол-во Застрахованых, которые выгрузилось в XML, чтобы вернуть как результат хранимки:
  SELECT @CountIns = Count(EOT_1.ID) 
  FROM RelContFace EOT_1
    LEFT OUTER JOIN RelContFace_Hist_OperationType EOT_3 ON (EOT_3.ID = EOT_1.ID) And (EOT_3.StateDate = (
    SELECT Max(StateDate) From RelContFace_Hist_OperationType WHERE (StateDate <= @DateCheck) And (EOT_1.ID = ID)))
  WHERE EOT_1.ContractID = @CID AND ((EOT_1.ReasonDoc = @Reason) OR (@Oper2 = 3)) AND EOT_3.OperationType in (@Oper1, @Oper2, @Oper3) 
  
  --Входящих ИД нет, это ошибка вызова - выходим:   
  IF (@CountIns = 0) 
  BEGIN
    SELECT 'Успешно' AS Status, 0 AS CountIns, @CID AS CID, @AID AS AID, @UserName AS UserName
    RETURN 
    /*SELECT 'Успешно1212' AS Status, 0 AS CountIns,
      @CID AS CID, @AID AS AID, @UserName AS UserName, 
      @CountIns as CountIns,  @Reason as Reason,
      @Oper1 as Oper1, @Oper2 as Oper2, @Oper3 as Oper3,
      @DateCheck as DateCheck
    RETURN 
    */
  END
   
  --Объяснение формирвания FOR XML PATH
  --Пример: FOR XML PATH('securityobject'), TYPE) AS "objectinformation/securityobjects"
  --Здесь PATH('securityobject') означает что каждая строка этого вложенного селекта будет обрамляться тегом securityobject
  --т.е. сколько строк получилось, столько будет блоков <securityobject>..</securityobject>
  --'DIAFA' AS "objectinformation/idnamesystem" - это означает что 
  --конкретно это значение будет обрамлено тегом idnamesystem>, пример: <idnamesystem>DIAFA</idnamesystem> и притом все это будет помещено в тег <objectinformation>
  --если objectinformation не существует, то создаетс, иначе вставляется в него.
  --AS "objectinformation/securityobjects" означает что весь результат запроса помещается в в тег "objectinformation/securityobjects"
  --"objectinformation/securityobjects" - этот путь создается только если его нет, иначе результат вставляется в него.
     
  --Построение XML:  
  SELECT @XMLData = 
  (SELECT
    --Договор страхования  
    @TypeDoc                            AS "objectinformation/doctype",
    'DIAFA'                             AS "objectinformation/idnamesystem",
    EOT_101.Name                        AS "objectinformation/nameunit",
    @UserName                           AS "objectinformation/username",
    @Reason                             AS "objectinformation/idstatement",
    (SELECT TOP 1 DOC1.Number FROM Document DOC1 WHERE DOC1.DocumentID = @Reason) AS "objectinformation/docnumber",                
    (SELECT TOP 1 DOC2.SignDate FROM Document DOC2 WHERE DOC2.DocumentID = @Reason) AS "objectinformation/dateregistration",       
    LEFT(EOT_10.Name, 100)              AS "objectinformation/securityproduct",
    CAST(EOT_8.Amount AS Numeric(20,2)) AS "objectinformation/securitysum",

    --Страхователь  
    (SELECT
       EOT_1.InsurerID "idobject", 
       LEFT(EOT_110.Name, 150) "surname",
       LEFT(EOT_110.FirstName, 150) "name",
       LEFT(EOT_110.SecondName, 150) "patronymic",
       EOT_110.BirthDate "datebirth",
    
       --Документы (только если ФЛ)         
       (SELECT LEFT(LTRIM(RTRIM(EOT_81.PassportSer)), 30) "series", LEFT(LTRIM(RTRIM(EOT_81.PassportNum)), 30) "number" FROM PassportFace EOT_81 WHERE EOT_81.FaceID = EOT_910.FaceID FOR XML PATH('document'), TYPE) AS "documents",
    
       --Адреса
       (SELECT DISTINCT LEFT(LTRIM(RTRIM(EOT_123.Address)), 200) "address" FROM Address EOT_123 WHERE EOT_123.FaceID = EOT_910.FaceID FOR XML PATH(''), TYPE) AS "addresses", 
  
       --Телефоны если ЮЛ.
       (SELECT LTRIM(RTRIM(EOT_153.Phone1)) "phonenumber" FOR XML PATH(''), TYPE) AS "phones",  

       --Телефоны если ФЛ.
       (SELECT LTRIM(RTRIM(phonenumber)) AS phonenumber FROM 
       (SELECT EOT_192.MobilePhone "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_110.FaceID UNION
        SELECT EOT_192.Phone1      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_110.FaceID UNION   
        SELECT EOT_192.Phone2      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_110.FaceID) t1 
        WHERE phonenumber is not null FOR XML PATH(''), TYPE) AS "phones",      
       LEFT(LTRIM(RTRIM(EOT_910.INN)), 17) "inn",        
       LEFT(EOT_353.Name + ' ' + EOT_153.Name, 150) "orgname" --ОрганизационноПравовойСтатус.Наим + Имя компании                                                        
      FOR XML PATH('securityobject'), TYPE) AS "objectinformation/securityobjects" 
      
      --Застрахованные
      /*(SELECT 
         EOT_11.FaceID "idobject",
         LEFT(EOT_11.Name, 150) "surname",
         LEFT(EOT_11.FirstName, 150) "name",
         LEFT(EOT_11.SecondName, 150) "patronymic",
         EOT_11.BirthDate "datebirth",
   
         --Документы  
         (SELECT LEFT(LTRIM(RTRIM(EOT_81.PassportSer)), 30) "series", LEFT(LTRIM(RTRIM(EOT_81.PassportNum)), 30) "number" FROM PassportFace EOT_81 WHERE EOT_81.FaceID = EOT_11.FaceID FOR XML PATH('document'), TYPE) AS "documents",
    
         --Адреса
         (SELECT LEFT(LTRIM(RTRIM(EOT_123.Address)), 200) "address" FROM Address EOT_123 WHERE EOT_123.Address is not null and EOT_123.FaceID = EOT_11.FaceID FOR XML PATH(''), TYPE) AS "addresses",
    
         --Телефоны если ФЛ.
         (SELECT LTRIM(RTRIM(phonenumber)) AS phonenumber FROM 
         (SELECT EOT_192.MobilePhone "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID UNION
          SELECT EOT_192.Phone1      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID UNION   
          SELECT EOT_192.Phone2      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID) 
            t1 WHERE phonenumber IS NOT NULL
           FOR XML PATH(''), TYPE) AS "phones"
      FROM RelContFace EOT_31 
        LEFT OUTER JOIN RelContFace_Hist_OperationType EOT_3
          ON (EOT_3.ID = EOT_31.ID) And (EOT_3.StateDate = (SELECT Max(StateDate) FROM RelContFace_Hist_OperationType WHERE (StateDate <= @DateCheck) And (EOT_31.ID = ID)))
        LEFT OUTER JOIN FacePerson EOT_11 ON EOT_11.FaceID = EOT_31.FaceID
      WHERE EOT_31.ContractID = EOT_1.CID
      --Следующая строка работает так:
      --Если основание прикрепления Договор, то @Oper2 = 8 и условие работает просто как EOT_31.ReasonDoc = @CID, так как 3 <> 8.
      --Если основание прикрепления ДопСоглашение, но не доп. соглашение о пролонгации, то условие работает  как EOT_31.ReasonDoc = @AID, и опять 3 <> 8.
      --Если основание прикрепления ДопСоглашение, и вид его - соглашение о пролонгации, то условие выключается из работы совсем. Так как условие EOT_31.ReasonDoc = @Reason перестает работать, так как 3 = 3.
      --потому что @Oper2 становится равным 3. Суть в том, что нам нужно чтобы Основание прикрепления у застрахованного проверялось при любых документах кроме доп. соглашения о пролонгации.
      --А на допсе о пролрнгации это условие выключалось и действовало только условие EOT_3.OperationType in (1, 3, 5).
      AND ((EOT_31.ReasonDoc = @Reason) OR (@Oper2 = 3))
      --Если Вид документа не Доп. согалашение о пролонгации, то условие всегда будет равно EOT_3.OperationType in (1, 8, 5), чт тоже самое как (1, 5), потому что операции 8 не существует.
      --Если Вид документа является Доп. согалашением о пролонгации, то условие будет равно EOT_3.OperationType in (1, 3, 5).
      AND EOT_3.OperationType in (@Oper1, @Oper2, @Oper3)
      FOR XML PATH('securityobject'), TYPE) AS "objectinformation/securityobjects"
      */            

    --Конец подзапросов. 
  FROM
    ContractIns EOT_1
    LEFT OUTER JOIN DepartFaceJuridical EOT_101 On EOT_101.ID = EOT_1.OrgDepartment   
    LEFT OUTER JOIN ContractIns_Hist_StartDate EOT_5 ON (EOT_5.ID = EOT_1.CID) And (EOT_5.StateDate = (SELECT Max (StateDate) FROM ContractIns_Hist_StartDate WHERE (StateDate <= @DateCheck) And (EOT_1.CID = ID)))
    LEFT OUTER JOIN ContractIns_Hist_Amount EOT_8 ON (EOT_8.CID = EOT_1.CID) And (EOT_8.StateDate = (SELECT Max (StateDate) FROM ContractIns_Hist_Amount WHERE (StateDate <= @DateCheck) And (EOT_1.CID = CID)))
    INNER JOIN Document EOT_9 ON EOT_9.DocumentID = EOT_1.CID
    LEFT OUTER JOIN InsProduct EOT_10 ON EOT_10.InsProductID = EOT_1.InsProductID
    LEFT OUTER JOIN Face EOT_910 ON EOT_910.FaceID = EOT_1.InsurerID
    LEFT OUTER JOIN FacePerson EOT_110 ON EOT_110.FaceID = EOT_910.FaceID
    LEFT OUTER JOIN FaceJuridical EOT_153 ON EOT_153.FaceID = EOT_910.FaceID
    LEFT OUTER JOIN JuridicalOrgStatus EOT_353 ON EOT_353.JuridicalOrgStatusID = EOT_153.JuridicalOrgStatusID
  WHERE
    EOT_1.CID = @CID FOR XML PATH('crosssecurityrequest'), TYPE)  
     
  
  --select 'aaa', @Test, 1, 1, 'aaa'   
  --return
   
  --Рабочий режим. Отправлем в шину:
  IF (@Test = 0)
  BEGIN 
    SET @XMLText = '<?xml version="1.0" encoding="UTF-8"?>' + CONVERT(VARCHAR(MAX), @XMLData)   
       
    --38 это длина LEN('<?xml version="1.0" encoding="UTF-8"?>') 
    IF (LEN(@XMLText) > 38) AND (@CountIns > 0) 
    BEGIN
	  --DECLARE @PUTVALUE TABLE (ID int) 
	  --INSERT INTO @PUTVALUE
	  --DECLARE @res111 int
	 
      EXEC Q_DIAFA.PUT_VALUE @P_SYS_ID = 'ANY$Y$TEM', @P_DATA_TYPE = 50, @P_DATA_VALUE = @XMLText --WITH RESULT SETS 

      --Обновляем запись в табличке, необязательно указывать сущность, все равно у ДогСтрах и Допса не может быть одинаковых ИД.
      UPDATE dbo.UploadContractsToBL SET [Status] = 'Успешно', ErrMsg = '', UTime = GetDate(), XMLOUT = @XMLText where ObjectID = @Reason        
      SELECT 'Успешно' AS Status, @CountIns AS CountIns, @CID AS CID, @AID AS AID, CAST(@UserName AS VARCHAR(100)) AS UserName 
    END ELSE
    BEGIN
      UPDATE dbo.UploadContractsToBL SET [Status] = 'Ошибка', ErrMsg = '', UTime = GetDate(), XMLOUT = @XMLText where ObjectID = @Reason 
      SELECT 'Ошибка' AS Status, @CountIns AS CountIns, @CID AS CID, @AID AS AID, CAST(@UserName AS VARCHAR(100)) AS UserName 
    END         
  END
  
  --RETURN

  --Тестовый режим. Возвращаем как XML:
  --Это удобно для отладки, так как к такому результату можно писать запросы, 
  --и Management Studio может показывать с разбивкой по тегам:
  IF (@Test = 1)
  BEGIN 
    SELECT @XMLData 
  END
 
  --Тестовый режим. Возвращаем как Текст.
  --Это то, что вставляется через PUT_VALUE: 
  IF (@Test = 2)
  BEGIN 
    SET @XMLText = '<?xml version="1.0" encoding="UTF-8"?>' + CONVERT(VARCHAR(MAX), @XMLData) 
    SELECT @XMLText AS Result, @CountIns AS CountIns              
  END   
  
                    
  /* 
  Нижеследующие закоментаренные запросы не удалять!
  По ним был сделан код SQL. Если понадобится что-то изменить, они помогут при написании. 
  
  --Выборка атриботов по договору:
  select
    ИДОбъекта,
    Номер,
    ДатаПодписания,
    СтрахПродукт.Наим,
    Сумма
    Страхователь,
    Страхователь.НаФа,
    Страхователь.ИНН
  Из
    ДогСтрах
  where ИДобъекта = 911553
 
  --Выборка атрибутов Застрахованных:
  select
    Z1.ФЛ.ИДОбъекта AS "idobject",
    Z1.ФЛ.НаФа AS "surname",
    Z1.ФЛ.Имя AS "name",
    Z1.ФЛ.Отчество AS "patronymic",
    Z1.ФЛ.ДатаРождения AS "datebirth"
  from Застрахованный Z1
  where Z1.ДогСтрах = 911553
  and Z1.ДатаСостОбъекта = '01.01.1900' and Z1.Операция in (1,5,3)
    
  --Документы:
  select Серия, Номер from УдостоверенияФЛ where ФЛ = 56767 
  
  --Поиск адресов:
  --select Адрес from Адрес where Лицо = 56767 
 
  --Поиск телефонов:
  select Телефон from ЮЛ where ИДОбъекта = 443554
  select ТелефонМобильный, ТелефонРабочий, ТелефонДомашний from ФЛ where ИДОбъекта = 443554
  
  --Вид Доп. соглашения:
  select ВидДок from ДопСоглашение where ИДОбъекта = 23455
   
  --Поиск: ОрганизационноПравовойСтатус + ' ' + Имя компании.
  select  ОрганизационноПравовойСтатус.Наим + ' ' + НаФа from ЮЛ where ИДОбъекта = 721250   
  */ 
  
  --Пример того что должна возвращать хранимка:
  /*
  Пример вызова: 
  EXEC [dbo].[spen_SendInsuredBLOne] 911553, 0, 'diasoft', 2
  
  Результат:
  <?xml version="1.0" encoding="UTF-8"?>
  <crosssecurityrequest>
  <objectinformation>
    <doctype>1</doctype>
    <idnamesystem>DIAFA</idnamesystem>
    <nameunit>Отдел личного страхования</nameunit>
    <username>diasoft</username>
    <idstatement>911553</idstatement>
    <docnumber>77050102-00185</docnumber>
    <dateregistration>2014-12-22T00:00:00</dateregistration>
    <securityproduct>Комбинированное страхование (типовой)</securityproduct>
    <securitysum>13649000.00</securitysum>
    <securityobjects>
      <securityobject>
        <idobject>527345</idobject>
        <orgname>Общество с ограниченной ответственностью "МонАрх и Б"</orgname>
        <inn>1111111111</inn>
        <addresses>
          <address>103006, г. Москва,ул. М. Дмитровка, д.25, корп.3, офис 3</address>
        </addresses>
        <phones>
          <phonenumber>343455555555</phonenumber>
        </phones>
      </securityobject>
      <securityobject>
        <idobject>527348</idobject>
        <surname>Снижко</surname>
        <name>FirstName_    527348</name>
        <patronymic>SecondName_    527348</patronymic>
        <datebirth>1900-01-31T00:00:00</datebirth>
        <addresses>
          <address>Москва, ул.Ген.Дорохова, д.16А</address>
        </addresses>
        <phones>
          <phonenumber>(495)443-18-58</phonenumber>
          <phonenumber>8-903-263-02-33</phonenumber>
        </phones>
      </securityobject>
      <securityobject>
        <idobject>527349</idobject>
        <surname>Панчук</surname>
        <name>FirstName_    527349</name>
        <patronymic>SecondName_    527349</patronymic>
        <datebirth>1900-01-31T00:00:00</datebirth>
        <documents>
          <document>
            <series>222</series>
            <number>553</number>
          </document>
        </documents>
        <addresses>
          <address>Москва, ул.Ген.Дорохова, д.16А</address>
        </addresses>
        <phones>
          <phonenumber>(495)443-18-58</phonenumber>
          <phonenumber>8-905-501-37-83</phonenumber>
        </phones>
      </securityobject>
    </securityobjects>
  </objectinformation>
  </crosssecurityrequest>
  */
END


/*

  --Застрахованные (не убирать комментарий, возможно Застрахованные еще понадобятся)
    --===================================================================================
    (SELECT
    EOT_11.FaceID "idobject",
    LEFT(EOT_11.Name, 150) "surname",
    LEFT(EOT_11.FirstName, 150) "name",
    LEFT(EOT_11.SecondName, 150) "patronymic",
    EOT_11.BirthDate "datebirth",
   
    --Документы  
    (SELECT LEFT(LTRIM(RTRIM(EOT_81.PassportSer)), 30) "series", LEFT(LTRIM(RTRIM(EOT_81.PassportNum)), 30) "number" FROM PassportFace EOT_81 WHERE EOT_81.FaceID = EOT_11.FaceID FOR XML PATH('document'), TYPE) AS "documents",
    
    --Адреса
    (SELECT LEFT(LTRIM(RTRIM(EOT_123.Address)), 200) "address" FROM Address EOT_123 WHERE EOT_123.Address is not null and EOT_123.FaceID = EOT_11.FaceID FOR XML PATH(''), TYPE) AS "addresses",
    
     --Телефоны если ФЛ.
    (SELECT LTRIM(RTRIM(phonenumber)) AS phonenumber FROM 
    (SELECT EOT_192.MobilePhone "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID UNION
     SELECT EOT_192.Phone1      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID UNION   
     SELECT EOT_192.Phone2      "phonenumber" FROM FacePerson EOT_192 WHERE EOT_192.FaceID = EOT_11.FaceID) 
       t1 WHERE phonenumber is not null
      FOR XML PATH(''), TYPE) AS "phones"    
    FROM
      RelContFace EOT_31
      LEFT OUTER JOIN RelContFace_Hist_OperationType EOT_3
        ON (EOT_3.ID = EOT_31.ID) And (EOT_3.StateDate = (SELECT Max(StateDate) FROM RelContFace_Hist_OperationType WHERE (StateDate <= @DateCheck) And (EOT_31.ID = ID)))
      LEFT OUTER JOIN FacePerson EOT_11 ON EOT_11.FaceID = EOT_31.FaceID
    WHERE
      EOT_31.ContractID = EOT_1.CID
      --Следующая строка работает так:
      --Если основание прикрепления Договор, то @Oper2 = 8 и условие работает просто как EOT_31.ReasonDoc = @CID, так как 3 <> 8.
      --Если основание прикрепления ДопСоглашение, но не доп. соглашение о пролонгации, то условие работает  как EOT_31.ReasonDoc = @AID, и опять 3 <> 8.
      --Если основание прикрепления ДопСоглашение, и вид его - соглашение о пролонгации, то условие выключается из работы совсем. Так как условие EOT_31.ReasonDoc = @Reason перестает работать, так как 3 = 3.
      --потому что @Oper2 становится равным 3. Суть в том, что нам нужно чтобы Основание прикрепления у застрахованного проверялось при любых документах кроме доп. соглашения о пролонгации.
      --А на допсе о пролрнгации это условие выключалось и действовало только условие EOT_3.OperationType in (1, 3, 5).
      and ((EOT_31.ReasonDoc = @Reason) OR (@Oper2 = 3))
      --Если Вид документа не Доп. согалашение о пролонгации, то условие всегда будет равно EOT_3.OperationType in (1, 8, 5), чт тоже самое как (1, 5), потому что операции 8 не существует.
      --Если Вид документа является Доп. согалашением о пролонгации, то условие будет равно EOT_3.OperationType in (1, 3, 5).
      and EOT_3.OperationType in (@Oper1, @Oper2, @Oper3) FOR XML PATH(''), TYPE) AS "securityobject" 
     --===================================================================================
*/