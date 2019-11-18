USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_Robot_GetDateChange]    Script Date: 06.03.2019 11:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
ALTER PROCEDURE [dbo].[spen_Robot_GetDateChange] (@DateChange datetime, @CID int, @AID int, @Test int) 
AS
  --Данная процедура формирует таблицу, в которой есть ИД договоров и доп. соглашений, статус которых был изменён:
  --1. Если это договор, то статус изменён на "Действует".
  --2. Если это доп. соглашение, то статус изменён на "Проведено".
  --Другие статусы не учитываются и в результирующую таблицу не попадают.
  --Эта хранимка нужна для робота отправки писем в ЛПУ.
  --Используется только в модуле DMS_CLPU_Print_FaceLetterRobot_FU.    
 
  --Пример вызова: 
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-02-13 10:10:00.000', 0, 0, 2 
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-02-12 10:10:00.000', 3773137, 4686601, 2
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-04-01 00:00:00.000', 0, 0, 2
     
  IF (@Test NOT IN (0,1,2)) 
  BEGIN
    SELECT 
    'Неверный вызов. Параметр Test может принимать одно из следующих значений: ' + CHAR(13) + CHAR(10) +
    '0 - Нормальная работа' + CHAR(13) + CHAR(10) +
    '1 - Количество документов к обработке' + CHAR(13) + CHAR(10) +
    '2 - Детальный список документов к обработке' AS ErrorText
    RETURN
  END  

  --Если дата была п ередана вместе с временем, то время убираем.
  --Далее в запросах также идет поиск без времени.
  --Нам нужно получить
  SET @DateChange = CAST(@DateChange AS Date)
 
  /*
  --Договора
  SELECT DISTINCT
    t1.ИДОбъекта         AS StatusID,
    t1.ДатаИзменения     AS DateChange,
    t1.Объект.ИДОБъекта  AS CID,
    0                    AS AID,
    t4.Номер             AS Number,
    t1.Пользователь.Наим AS Imp
  FROM СтатусОбъекта t1
    LEFT JOIN ДогСтрах       t2 ON t2.ИДОбъекта  = t1.Объект.ИДОБъекта
    LEFT JOIN ДопСоглашение  t3 ON t3.Документ   = t1.Объект.ИДОБъекта
    LEFT JOIN Документ       t4 ON t4.ИДОбъекта  = t1.Объект.ИДОБъекта
   WHERE t1.Объект.ИДСущности = 1694
         AND CAST(t1.ДатаИзменения AS Date) = '21.12.2018'
         AND (t3.Документ IS NULL OR t2.ДатаНачала = t3.ДатаНачала) --Это если договор и доп от одной даты, то договор мы включаем в список.
         AND t1.Статус.Сокр = 'Действует'
         AND t2.ТипДогСтрах < 3

  --Объединяем договора и допсы в одну таблицу.
  UNION ALL

  --ДопСоглашения
  SELECT--TOP 1 --DISTINCT
    t1.ИДОбъекта        AS StatusID,
    t1.ДатаИзменения    AS DateChange,
    t3.ИДОбъекта        AS CID,
    t1.Объект.ИДОБъекта AS AID,
    t4.Номер            AS Number,
    t1.Пользователь.Наим AS Imp
  FROM СтатусОбъекта t1
    LEFT JOIN ДопСоглашение  t2 ON t2.ИДОбъекта  = t1.Объект.ИДОБъекта
    LEFT JOIN ДогСтрах       t3 ON t3.ИДОбъекта  = t2.Документ
    LEFT JOIN Документ       t4 ON t4.ИДОбъекта  = t1.Объект.ИДОБъекта
   WHERE t1.Объект.ИДСущности = 1640
         AND CAST(t1.ДатаИзменения AS Date) = '12.02.2019'
         AND t3.ИДОбъекта IS NOT NULL
         AND t1.Статус.Сокр = 'Проведено'
         AND t3.ТипДогСтрах < 3
         AND t2.ВидДок.Сокр <> 'ТехническоеДопСогл'
  */

  --Формируем полную таблицу изменений договорор и доп. соглашений по дате (@DateChange), которая передана в этой процедуру.
  --т.е. поиск всех договоров и допсов, у которых дата изменения статуса = @DateChange
   
  --1. Договора
  SELECT CONVERT(bit, 0) Checked, StatusID, DateChange, CID, AID, Number, Imp, COUNT(t1.ID) AS CountIns, (((COUNT(t1.ID) * 240) / 60000) + 5) AS PrepareSec, CAST(NULL As int) AS TotalSec, CAST(NULL As int) AS TotalMin 
  INTO #tob FROM
  ( 
  Select
  Distinct
  EOT_1.ID         "StatusID",
  EOT_1.DateChange "DateChange",
  EOT_1.ObjectID   "CID",
  0 "AID",
  EOT_13.Number "Number",
  EOT_14.Name "Imp"
From
  StatusObject EOT_1
  Left Outer Join Status EOT_15
    On EOT_15.ID = EOT_1.Status_ID
  Left Outer Join ApplicationUser EOT_14
    On EOT_14.UserID = EOT_1.ApplicationUser_ID
  LEFT JOIN ContractIns EOT_2 Left Outer Join ContractIns_Hist_StartDate EOT_6
    On (EOT_6.ID = EOT_2.CID) And (EOT_6.StateDate = (
      Select
        Max(StateDate)
      From
        ContractIns_Hist_StartDate
      Where
        (StateDate <= Convert(DateTime, '20300225 23:59:59', 112)) And (EOT_2.CID = ID)
    ))
    On EOT_2.CID = EOT_1.ObjectID
  LEFT JOIN AdditionAgreement EOT_11 On EOT_11.Document = EOT_1.ObjectID
  LEFT JOIN Document EOT_13 On EOT_13.DocumentID = EOT_1.ObjectID
Where
  EOT_1.ObjectEntityID = 1694 
  AND CAST(EOT_1.DateChange AS Date) = @DateChange 
  AND (EOT_11.Document IS NULL OR EOT_6.StartDate = EOT_11.StartDate) 
  AND EOT_15.Brief = 'Действует' 
  AND EOT_2.TypeContract < 3
  AND (EOT_1.ObjectID = @CID OR @CID = 0)
  AND (@AID = 0)

  --Объединяем договора и допсы в одну таблицу.
  Union All
  
  --2. ДопСоглашения  
 Select
  EOT_1.ID         "StatusID",
  EOT_1.DateChange "DateChange",
  EOT_4.CID        "CID",
  EOT_1.ObjectID   "AID",
  EOT_13.Number    "Number",
  EOT_14.Name      "Imp"
From
  StatusObject EOT_1
  Left Outer Join Status EOT_15
    On EOT_15.ID = EOT_1.Status_ID
  Left Outer Join ApplicationUser EOT_14
    On EOT_14.UserID = EOT_1.ApplicationUser_ID
  LEFT JOIN AdditionAgreement EOT_2 Inner Join Document EOT_3
    On EOT_3.DocumentID = EOT_2.ID
    On EOT_2.ID = EOT_1.ObjectID
  Left Outer Join KindDocument EOT_16 Inner Join KindObject EOT_17
    On EOT_17.ID = EOT_16.ID
    On EOT_16.ID = EOT_3.KindDocument
  LEFT JOIN ContractIns EOT_4
    On EOT_4.CID = EOT_2.Document
  LEFT JOIN Document EOT_13
    On EOT_13.DocumentID = EOT_1.ObjectID
Where
  EOT_1.ObjectEntityID = 1640 
  AND CAST(EOT_1.DateChange AS Date) = @DateChange 
  AND EOT_4.CID IS NOT NULL 
  AND EOT_15.Brief = 'Проведено' 
  AND EOT_4.TypeContract < 3 
  AND EOT_17.Brief <> 'ТехническоеДопСогл'
  AND (EOT_4.CID = @CID OR @CID = 0)
  AND (EOT_1.ObjectID = @AID OR @AID = 0)
   ) tob
  LEFT JOIN RelContFace t1 on t1.ContractID = tob.CID
  GROUP BY StatusID, DateChange, CID, AID, Number, Imp
  

  --Вычисляем примерное время, поиска всех изменений по найденным договороам и доп. соглашениям
  --Это время равно работе процедуры dbo.spen_Robot_GetChangeAID, которая будет вызываться в клиентском 
  --коде цикле по каждой записи в таблице #tob. Это просто для удобства, чтобы на клиенте это не считать.
  UPDATE #tob SET TotalSec = (SELECT SUM(PrepareSec) FROM #tob)
  UPDATE #tob SET TotalMin = (SELECT TOP 1 (TotalSec / 60.00) + 1 FROM #tob)           
   
  DECLARE @DocCount int
  SELECT @DocCount = COUNT(*) FROM #tob 

  IF (@Test = 0) 
  BEGIN
    SELECT * FROM #tob ORDER BY Number
    RETURN
  END

  IF (@Test = 1) 
  BEGIN
    SELECT @DocCount AS DocCount
    RETURN
  END

  IF (@Test = 2) 
  BEGIN
    SELECT * FROM #tob ORDER BY DateChange
    RETURN
  END  



  --Храним изменения не более суток
  /*DELETE FROM dbo.Robot_DateChange --WHERE DateCur < CAST(GETDATE() AS Date)  
  DECLARE @StatusID int 
  DECLARE ListDoc CURSOR DYNAMIC FOR SELECT StatusID, CID, AID FROM #tob ORDER BY CID, AID                
  OPEN ListDoc 
  FETCH FIRST FROM ListDoc INTO @CID, @AID
  WHILE @@Fetch_Status = 0
  BEGIN
  
    --Вызов хранимки для того чтобы внести в таблицу все изменения по застрахованным по договору и(или) допу    
    INSERT INTO     
    dbo.Robot_DateChange 
        ([StatusID]
      ,[CID]
      ,[AID]
      ,[DateCur]
      ,[DateCur_1]
      ,[DatePrev]
      ,[IsLong]
      ,[IDV]
      ,[Insured]
      ,[ActionIns]
      ,[ActionPers]
      ,[ActionAdr]
      ,[ChangeVar]
      ,[ChangeProgram]
      ,[ChangeFam]
      ,[ChangeIm]
      ,[ChangeOt]
      ,[ChangeBirth]
      ,[OV]
      ,[OFil]
      ,[OldBirthDate]
      ,[LPU]
      ,[Programms]
      ,[IDProgrammss]
      ,[IDProgramms]
      ,[FIO]
      ,[Policy]
      ,[PolicyStart]
      ,[PolicyEnd]
      ,[StartDate]
      ,[Enddate]
      ,[Name1]
      ,[Name2]
      ,[Name3]
      ,[BirthDate]
      ,[OldName1]
      ,[OldName2]
      ,[OldName3]
      ,[PhoneHome]
      ,[PhoneWork]
      ,[PhoneMobile]
      ,[Sex]
      ,[Position]
      ,[InsurerName]
      ,[RelInsurer]
      ,[WorkPlace]
      ,[InsRegion]
      ,[WorkPlaceAddr]
      ,[SSDate]
      ,[Address]
      ,[OldAddress])  
    EXEC [dbo].[spen_Robot_GetChangeAID] @StatusID, @CID, @AID
          
    FETCH NEXT FROM ListDoc INTO @StatusID, @CID, @AID
  END 
  
  CLOSE ListDoc
  DEALLOCATE ListDoc
  
  SELECT @DocCount AS DocCount, COUNT(*) AS InsCount FROM dbo.Robot_DateChange WHERE DateCur = @DateChange
  */
       
  --SELECT LPU, COUNT(*) AS CountIns FROM dbo.Robot_DateChange WHERE DateCur = GETDATE() GROUP BY LPU
  --SELECT LPU AS "LPU ID", COUNT(*) AS "Количество застрахованных" FROM dbo.Robot_DateChange WHERE DateCur = GETDATE() GROUP BY LPU