USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_Robot_GetChangeAID]    Script Date: 11.03.2019 11:21:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================
--Author:		Травин Е.В.
--Create date: 25.02.2019
--Description: Получение таблицы с изменениями по застрахованным, по определенному состоянию договора. 
--=============================================
ALTER PROCEDURE [dbo].[spen_Robot_GetChangeAID] (
  @DateChange datetime,
  @UserID int,
  @StatusID int,
  @CID int,
  @AID int,
  @Test int  
) AS  


  --Пример вызова:   
  -- EXEC [dbo].[spen_Robot_GetChangeAID] Null, 361, 0, 4287550, 5082269, 1 
  /* 
 
   EXEC [dbo].[spen_Robot_GetChangeAID] '2019-01-23 00:00:00', 361, 0, 3473739, 5211874, 1
   EXEC [dbo].[spen_Robot_GetChangeAID] '2019-01-23 00:00:00', 361, 0, 5095070, 0, 0
   
  */

  --Эта хранимка нужна для робота отправки писем в ЛПУ. 
  --Данная хранимка возвращает таблицу, в которой собраны все изменения по допсу (если допса нет, т.е. AID = 0, то на состояние договора)
  --Изменения такие: Прикрепленные, Открепленные, Изменившие ФИО, Дату рождения, Адрес, Пролонгированные, Изменившие программу ЛПУ. 
  --Об изменениях говорит поле ActionIns: 
  --ActionIns   = 1   Прикрепленные. 
  --ActionIns   = -1  Открепленные.   
  --ActionIns   = 3   Изменившие программу.
  --ActionPers  = 1   Изменившие персональные данные, это Фимилия, Имя, Отчество, Дата рождения.
  --ActionAdr   = 1   Изменившие Адрес.
  --ChangeFam   = 1   Изменившие Фамилию.
  --ChangeIm    = 1   Изменившие Имя.
  --ChangeOt    = 1   Изменившие Отчество
  --ChangeBirth = 1   Изменившие Дату рождения.
  --Пролонгированных мы не отделяем от прикрепленных.  У пролонгирвоанных ActionIns   = 1 и их не отделить от остальных.
  --Все изменения в рамках ИД ЛПУ. 
  --Входящие параметры. Только ИД Договороа и ИД Допса. 
  --Если допса нет, то @AID = 0. Остальные все параметры расчетные.

  --IF OBJECT_ID(N'tempdb..#Ins0')       IS NOT NULL DROP TABLE [dbo].[#Ins0]
  --IF OBJECT_ID(N'tempdb..#Ins1')       IS NOT NULL DROP TABLE [dbo].[#Ins1]
  --IF OBJECT_ID(N'tempdb..#Ins2')       IS NOT NULL DROP TABLE [dbo].[#Ins2]
  --IF OBJECT_ID(N'tempdb..#Ins3')       IS NOT NULL DROP TABLE [dbo].[#Ins3]
  --IF OBJECT_ID(N'tempdb..#ResIns1')    IS NOT NULL DROP TABLE [dbo].[#ResIns1]
  --IF OBJECT_ID(N'tempdb..#ResIns2')    IS NOT NULL DROP TABLE [dbo].[#ResIns2]
  --IF OBJECT_ID(N'tempdb..#ResIns3')    IS NOT NULL DROP TABLE [dbo].[#ResIns3]
  --IF OBJECT_ID(N'tempdb..#ResInsSUM')  IS NOT NULL DROP TABLE [dbo].[#ResInsSUM]
  --IF OBJECT_ID(N'tempdb..#ChangeProg') IS NOT NULL DROP TABLE [dbo].[#ChangeProg]
  --IF OBJECT_ID(N'tempdb..#Cont')       IS NOT NULL DROP TABLE [dbo].[#Cont] 
  
                                             
   --Результат 
  CREATE TABLE #ResIns1 (Insured int, ActionIns int, ActionPers int, ActionAdr int, ChangeVar int, FaceID int, OV int, CurV int, LPU int, ProgName varchar(max), ProgCode varchar(max), PrePay int)                         
                                                       
  --======================================================
  --1. Получение различных дат и основания: @DateCur, @DateCur_1, @DatePrev, @Reason.
  --======================================================
  DECLARE @DateCur     datetime = '19000101 00:00:00'   --Дата начала допса или 1900.01.01 в случае договора, если допсов нет.
  DECLARE @DateCur_1   datetime = @DateCur - 1          --@DateCur минус 1 день.   
  DECLARE @Reason      int      = @CID                  --Основание. Договор или допс.
  DECLARE @IsLong      int      = 0                     --Признак, что доп.соглашение является доп. соглашением о пролонгации.
  
  --Дата начала предыдущего допса (если он есть, если нет, то дата начала договора).  
  DECLARE @DatePrev    datetime = @DateCur              
  SELECT TOP 1 @DatePrev = StartDate FROM ContractIns_Hist_StartDate WHERE ID = @CID 
 
  --Получаем даты текущего допса (договора и предыдущего)
  IF (@AID > 0)
  BEGIN
    SET @Reason = @AID 
    SELECT @DateCur   = t1.StartDate, 
           @DatePrev  = t1.StartDate, 
           @DateCur_1 = t1.StartDate - 1, 
           @IsLong    = (CASE WHEN t2.KindDocument = 16 THEN 1 ELSE 0 END) 
    FROM AdditionAgreement t1
      LEFT JOIN Document t2 ON t2.DocumentID = t1.ID
    WHERE t1.Document = @CID AND t1.ID = @AID

    --Поиск @DatePrev.
    DECLARE @StartDateTemp datetime
    SELECT TOP 1 @StartDateTemp = StartDate FROM AdditionAgreement WHERE Document = @CID AND StartDate < @DateCur ORDER BY StartDate DESC
    --SELECT TOP 1 StartDate FROM AdditionAgreement WHERE Document = @CID AND StartDate < @DateCur ORDER BY StartDate DESC
    --Дата начала предыдущего допса (если он есть, если нет, то дата начала договора).  
    IF (@StartDateTemp IS NOT NULL) SET @DatePrev = @StartDateTemp 
  END 
  
  DECLARE @ContractDateEnd datetime
  --Здесь берём ищем дату окончания договора. Нам нужно её найти на дату до пролонгации. Поэтому берём на дату @DatePrev.
  SELECT  @ContractDateEnd = EOT_1.EndDate FROM
    ContractIns_Hist_EndDate EOT_1
  WHERE EOT_1.ID = @CID AND 
    EOT_1.StateDate = (SELECT MAX(t2.StateDate) FROM ContractIns_Hist_EndDate t2 WHERE (t2.StateDate <= @DatePrev) And (EOT_1.ID = t2.ID))

 
   
  --Проверка 
  --SELECT @CID AS CID, @AID AS AID, @DateCur AS DateCur, @DateCur_1 AS DateCur_1, @DatePrev AS DatePrev, @Reason AS Reason, @IsLong AS IsLong
 
  --======================================================
  --2. (Часть 1) Поиск застрахованных, с которыми произошла операция.
  --======================================================  
   SELECT
     EOT_1.ID     AS Insured, 
            
    --Разделено на четыре CASE потому что эти все Action могут происходить одновременно.
    --Пролонгация со одновременно со сменой варианта и смена фамилии и адреса.
    (CASE     
          WHEN EOT_1.ReasonDoc           = @Reason                          THEN  1 --Прикрепленные    
          WHEN EOT_1.ReasonDocOFF        = @Reason                          THEN -1 --Открепленные
          WHEN @IsLong = 1 AND EOT_10.StateDate = @DateCur AND EOT_1.ReasonDoc <> @Reason THEN  1 --Пролонгируемые
          WHEN EOT_11.ContractVariantID <> EOT_12.ContractVariantID         THEN  1 --Смена варианта (Здесь 1, как прикрепленные, -1 как открепленные, удет добавлен позже)          
          ELSE 0
    END) AS ActionIns, 
           
    (CASE WHEN EOT_100.FaceID > 0                                           THEN 1 ELSE 0 END) AS ActionPers, --Смена персональных данных (Фамилия, Имя, Отчество, дата рождения)
    (CASE WHEN EOT_101.AddressID > 0                                        THEN 1 ELSE 0 END) AS ActionAdr,  --Смена фактического адреса. Если человек прикрепился, то будет 1 и до этого WHEN не дойдет.     
    
    --Изменивших вариант, нужно разбить на три группа, Прикрепленные, Отерепленные, сменившие программу.
    --Это поле будет равно 1, для того чтобы после разбиения изменивших варианта и изменения пля ActionIns на -1 и 1,
    --можно было  понять, кто из застрахованных менял вариант.
    --Здесь такой же код как и в CASE выше.
    (CASE WHEN EOT_11.ContractVariantID <> EOT_12.ContractVariantID         THEN  1 ELSE 0 END) ChangeVar,  
                  
    --ISNULL(EOT_101.AddressID, 0) AddressID,
    EOT_1.FaceID,
    ISNULL(EOT_11.ContractVariantID, 0) AS OV,    --Предыдущий вариант
    ISNULL(EOT_12.ContractVariantID, 0) AS CurV   --Текущий вариант
  INTO #Ins0 --Все застраховнные по договору, которые были активны на дату допа минус один день.
  FROM
    RelContFace EOT_1
  
    --Предыдущий ВариантЗастрахованный
    LEFT OUTER JOIN RelContFace_Hist_FaceVariant EOT_6 ON (EOT_6.ID = EOT_1.ID) And (EOT_6.StateDate = (SELECT Max(StateDate) FROM RelContFace_Hist_FaceVariant WHERE (StateDate <= @DateCur_1) AND (EOT_1.ID = ID)))
    LEFT OUTER JOIN FaceVariant EOT_11 ON EOT_11.ID = EOT_6.FaceVariant
 
    --Текущий ВариантЗастрахованный
    LEFT OUTER JOIN RelContFace_Hist_FaceVariant EOT_7 ON (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (SELECT Max(StateDate) FROM RelContFace_Hist_FaceVariant WHERE (StateDate <= @DateCur) AND (EOT_1.ID = ID)))  
    LEFT OUTER JOIN FaceVariant EOT_12 ON EOT_12.ID = EOT_7.FaceVariant

    --Предыдущий ВариантДогСтрах
    LEFT OUTER JOIN ContractVariant EOT_16 ON EOT_16.ID = EOT_11.ContractVariantID

    --Текущий ВариантДогСтрах
    LEFT OUTER JOIN ContractVariant EOT_17 ON EOT_17.ID = EOT_12.ContractVariantID

    --Ищем пролонгируемых, у них дата состояния атрибута дата окончания совпадает с датой начала допса.
    LEFT OUTER JOIN RelContFace_Hist_EndDate EOT_10 ON (EOT_10.ID = EOT_1.ID) And (EOT_10.StateDate = (SELECT Max(StateDate) FROM RelContFace_Hist_EndDate WHERE (StateDate <= @DateCur) AND (EOT_1.ID = ID)))  
    
    --Ищем изменивших фамилию, имя, отчество, дату рождения.
    --Если допника нет, то тут всегда пусто. Именить ФИО и ДР можно толко по допсу.  Изменения между датой начала договора и датой начала допса.
    LEFT OUTER JOIN FacePerson EOT_100 ON @AID > 0 AND EOT_100.FaceID = EOT_1.FaceID AND EOT_100.DateChange between @DatePrev and @DateCur

    --Ищем изменивших адрес
    --Если допника нет, то тут всегда пусто. Именить адрес можно толко по допсу. Изменения между датой начала договора и датой начала допса.
    LEFT OUTER JOIN  [Address] EOT_101 ON @AID > 0 AND EOT_101.FaceID = EOT_1.FaceID AND EOT_101.AdressTypeID = 5 AND EOT_101.DateReg between @DatePrev and @DateCur
        
    WHERE    
      EOT_1.ContractID = @CID AND EOT_10.EndDate >= @DateCur_1
  --Проверка select COUNT(*) from #Ins0

  --======================================================  
  --Все застрахованные, по которым была какая либо операция.
  --======================================================  
  SELECT * INTO #Ins1 FROM #Ins0 WHERE ActionIns > 0 OR ActionPers > 0 OR ActionAdr > 0-- OR ChangeVar > 0  
 --Проверка select * from #Ins1

  --======================================================
  --3. (Часть 1) Джойним с содержимым по договору, чтобы получить список ЛПУ
  --======================================================
  --DISTINCT потому, что бывает ситуация когда прямо в одной программе несколько одинаковых ЛПУ.
  SELECT DISTINCT * INTO #Ins2 FROM
  (
    --Берём всех. 
    SELECT t1.Insured, t1.ActionIns, t1.ActionPers, t1.ActionAdr, t1.ChangeVar, t1.FaceID, t1.OV, t1.CurV, t2.LPU, ISNULL(EOT_26.Name, EOT_25.Name) AS ProgName,  EOT_26.Code AS ProgCode, EOT_21.[Attach] AS PrePay
    FROM #Ins1 t1
      LEFT OUTER JOIN ContractVariantProgram EOT_21 ON EOT_21.Rel_ContractVariant = t1.CurV                       
      LEFT OUTER JOIN ContractVariantContent t2     ON t2.ContractVariantProgram = EOT_21.ID 
      LEFT OUTER JOIN InsProgram             EOT_25 ON EOT_25.ID = EOT_21.InsProgram
      LEFT OUTER JOIN CodeRefBook            EOT_26 ON EOT_26.ID = EOT_25.CodeListLPUID 
    WHERE EOT_25.ProgList = 1 
          AND t2.ProgList = 1 --16 сек.          
    UNION ALL
      
    --Добавляем тех, кто изменил вариант, как открепившийся. ContractVariantProgram по старому варианту. ActionIns = -1.
    SELECT t1.Insured, -1 AS ActionIns, t1.ActionPers, t1.ActionAdr, t1.ChangeVar, t1.FaceID, t1.OV, t1.CurV, t2.LPU, ISNULL(EOT_26.Name, EOT_25.Name) AS ProgName,  EOT_26.Code AS ProgCode, EOT_21.[Attach] AS PrePay
    FROM #Ins1 t1
      LEFT OUTER JOIN ContractVariantProgram EOT_21 ON EOT_21.Rel_ContractVariant = t1.OV                       
      LEFT OUTER JOIN ContractVariantContent t2     ON t2.ContractVariantProgram = EOT_21.ID 
      LEFT OUTER JOIN InsProgram             EOT_25 ON EOT_25.ID = EOT_21.InsProgram
      LEFT OUTER JOIN CodeRefBook            EOT_26 ON EOT_26.ID = EOT_25.CodeListLPUID 
    WHERE EOT_25.ProgList = 1 
          AND t2.ProgList = 1
          AND t1.ChangeVar = 1 --6 сек.          
  ) tdist

  --======================================================
  --4. (Часть 2) Ищем все ЛПУ которые добавились в договор страхования или открепились. 
  --В результате добавления ВариантДогСтрах в ДогСтрах или программы с ЛПУ в ВариантДогСтрах или просто ЛПУ добавилось в программу.
  --ProgList = 1 --Отправлять списки в ЛПУ. 
  --======================================================  
  SELECT DISTINCT   
    EOT_1.ID,
    EOT_1.Rel_ContractVariant AS ContractVariant,    
    (CASE 
      WHEN EOT_1.DateStart = @DateCur THEN 1  --WHEN EOT_1.DateStart = @DateCur   THEN 1 
      WHEN EOT_1.DateEnd   = @DateCur_1 THEN -1 --WHEN EOT_1.DateEnd   = @DateCur_1 THEN -1 
    END) ActionIns,
    EOT_1.LPU, 
    EOT_2.ID  AS ProgID,   
    ISNULL(EOT_7.Name, EOT_6.Name) AS ProgName,
    EOT_7.Code AS ProgCode,
    EOT_2.[Attach] AS PrePay
  INTO #Cont
  FROM
    ContractVariantContent EOT_1
    Left Outer Join ContractVariant EOT_8 On EOT_8.ID = EOT_1.Rel_ContractVariant
    Left Outer Join ContractVariantProgram EOT_2 On EOT_2.ID = EOT_1.ContractVariantProgram
    Left Outer Join InsProgram EOT_6 On EOT_6.ID = EOT_2.InsProgram
    Left Outer Join CodeRefBook EOT_7 On EOT_7.ID = EOT_6.CodeListLPUID
  WHERE    
    EOT_8.Contract_ID = @CID AND 
    EOT_6.ProgList    = 1    AND 
    EOT_1.ProgList    = 1    AND 
    (EOT_1.DateStart = @DateCur OR EOT_1.DateEnd = @DateCur_1) 
   
  --Если варианты по договору на данном состоянии договора не менялись, и выполнено условие, что мы стоим на допсе. 
  DECLARE @CountRec int
  SELECT @CountRec = COUNT(*) FROM #Cont  
  IF ((@CountRec > 0) AND (@AID > 0)) 
  BEGIN
    --======================================================
    --5. (Часть 2) Получаем список застрахованных, из списка изменения состава ЛПУ. 
    --======================================================     
    SELECT DISTINCT
      t0.Insured,   
      t1.ActionIns,
      t0.ActionPers,  
      t0.ActionAdr, 
      t0.ChangeVar,
      t0.FaceID,
      t0.OV,
      t0.CurV,             
      t1.LPU,
      t1.ProgName,
      t1.ProgCode,
      t1.PrePay
      INTO #Ins3
    FROM
      #Ins0 t0
      --Джойним только с теущим вариантом. Потому, что в шаблонах ЛПУ нет колонки предыдущий список программ, а есть только список актуальных программ.
      INNER JOIN #Cont t1 ON t1.ContractVariant = t0.CurV 
    --(508272 row(s) affected)   
    --Выполняется 2 сек.   

    --======================================================
    --6. Соединяем части 1 и 2.
    --======================================================
    INSERT INTO #ResIns1
    SELECT Insured, ActionIns, ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay
    FROM 
    (
      --Список застраховнных, у которых была какая либо операция или смена ФИО, ДР, адреса.      
      SELECT Insured, ActionIns, ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay FROM #Ins2
      
      UNION
       
      --Список застраховнных, у которых были внесены изменения в список ЛПУ в варианте.
      SELECT Insured, ActionIns, ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay FROM #Ins3
    
    ) t1 
    --Запрос выполняется 11 сек. (798353 row(s) affected)
    --Проверка SELECT TOP 100 * FROM #ResIns1
  END ELSE
  BEGIN
    INSERT INTO #ResIns1 SELECT Insured, ActionIns, ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay FROM #Ins2
  END

  --======================================================
  --7. Собираем через запятую все названия программ для каждого варианта и ЛПУ.
  --======================================================    
  SELECT Insured, SUM(ActionIns) AS ActionIns,  ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay 
  INTO #ResInsSUM
  FROM #ResIns1 
  GROUP BY Insured,  ActionPers, ActionAdr, ChangeVar, FaceID, OV, CurV, LPU, ProgName, ProgCode, PrePay
  --Запрос выполяняется 10 сек. (794742 row(s) affected)

  --======================================================   
  --8. Проставляем список программ через запятую. 
  --Перед этой операцией нужно сделать SUM(ActionIns) c с крипировкой по всем полям #ResIns1. 
  --======================================================   
  SELECT DISTINCT
    t1.Insured, 
    t1.ActionIns,
    t1.ActionPers, 
    t1.ActionAdr, 
    t1.ChangeVar, 
    t1.FaceID, 
    t1.OV, 
    t1.CurV, 
    t1.LPU,
    0 as ChangeProgram,     
    t1.PrePay,
    STUFF((SELECT ', ' + t2.ProgName 
            FROM #ResInsSUM t2 
            WHERE --t2.ChangeVar  = 1 AND 
                  t2.Insured    = t1.Insured   AND 
                  (t2.ActionIns = t1.ActionIns OR t2.ActionIns = 0) AND
                  t2.LPU        = t1.LPU                              
    FOR XML PATH('')), 1, 2, '') AS ProgListName,
    
    STUFF((SELECT ', ' + t2.ProgCode 
            FROM #ResInsSUM t2 
            WHERE --t2.ChangeVar  = 1 AND 
                  t2.Insured    = t1.Insured   AND 
                  (t2.ActionIns = t1.ActionIns OR t2.ActionIns = 0) AND
                  t2.LPU        = t1.LPU                              
    FOR XML PATH('')), 1, 2, '') AS ProgListCode
    INTO #ResIns2 
    FROM #ResInsSUM t1 
    --1м.12 сек.

  --======================================================   
  --9. Определяем, кто изменил программу. 
  --======================================================       
  --drop table #ResIns2
  --drop table #ChangeProg
  SELECT t2.* 
  INTO #ChangeProg 
  FROM #ResIns2 t2                               --where ChangeVar = 1
  INNER JOIN (SELECT Insured, LPU FROM #ResIns2  GROUP BY Insured, LPU HAVING COUNT(*) > 1) t1 ON t2.Insured = t1.Insured and t2.LPU = t1.LPU  
  
  --Обновляем поле, у кого ChangeProgram = 1, тех нужно выводить в таблице изменивших программу.
  --если написать UPDATE .. SET ... FROM (...) t1 то почему-то медленнее работает, чем если в двух разных запросах. --#ResIns2.ActionIns = 1 AND 
  UPDATE #ResIns2 SET ChangeProgram = 1 FROM #ChangeProg t1 WHERE #ResIns2.Insured = t1.Insured AND #ResIns2.LPU = t1.LPU   
  DELETE FROM #ResIns2 WHERE ChangeProgram = 1 AND ActionIns = -1     
  DELETE FROM #ResIns2 WHERE ActionIns = 0    
  UPDATE #ResIns2 SET ActionIns = 3 WHERE ChangeProgram = 1 --Изменившие программу.  

  --======================================================   
  --10. Удаляем все ЛПУ, у которых нет активных шаблонов.
  --======================================================  
   /*SELECT DISTINCT ЛПУ FROM МодульПисемВЛПУ 
    WHERE
      ТипПисьма <= 12
      AND ПризнакВыгрузки = 1
      AND ШаблонОтчета > 0
      AND ШаблонОтчета.ТипОтчета > 0
      AND ШаблонОтчета.ТипОтчета < 4
   ORDER BY ЛПУ
  */
 
  --Удалем все ЛПУ, которые не попали в список.
  DELETE FROM #ResIns2 WHERE LPU NOT IN 
  (SELECT DISTINCT
    EOT_1.LPUID  
  FROM
    LPUUnitLetter EOT_1
    LEFT OUTER JOIN RepTempl EOT_2 ON EOT_2.RepTemplID = EOT_1.TemplateID
  WHERE
    EOT_1.TypeOfLetter   <= 12  --Шаблоны свыше 12 - это для выгрузки в ассиатнсы.
    AND EOT_1.PrintLetter = 1   --Признак активности шаблона
    AND EOT_1.TemplateID  > 0   --Прикреплен файл шаблона
    AND EOT_2.RepType     > 0   --Тип шаблона только Word или Excel
    AND EOT_2.RepType     < 4   --Тип шаблона только Word или Excel
  )
        
  --======================================================
  --11. Получение страхователя по договору
  --======================================================
  DECLARE @InsurerName varchar(1000)
  SELECT
    @InsurerName = ISNULL(t2.Name, t3.Name) 
  FROM ContractIns t1 
    LEFT OUTER JOIN FaceJuridical t2 ON t2.FaceID = t1.InsurerID
    LEFT OUTER JOIN FacePerson    t3 ON t3.FaceID = t1.InsurerID
  WHERE t1.CID = @CID 
  --Проверка
  --SELECT @InsurerName AS InsurerName

  --======================================================
  --12. Обогащаем различными данными застрахованных.
  --======================================================
  --DROP TABLE #ResIns3
   SELECT  DISTINCT
    @DateChange AS DateChange,
    GETDATE() AS DateCreate, 
    @UserID AS UserID,    
    @StatusID AS StatusDate,
    @CID AS CID, 
    @AID AS AID, 
    @DateCur AS DateCur,
    @DateCur_1 AS DateCur_1, 
    @DatePrev AS DatePrev , 
    @IsLong   AS IsLong,
    0 AS ID,     
    t1.Insured,
    t1.ActionIns,
    t1.ActionPers, 
    t1.ActionAdr, 
    t1.ChangeVar, 
    t1.ChangeProgram, 
    0 AS ChangeFam,
    0 AS ChangeIm,    
    0 AS ChangeOt,
    0 AS ChangeBirth,        
    t1.OV           AS OV,     
    t4.Filial       AS OFil, 
    t3.OldBirthDate AS OldBirthDate,
    t1.LPU,
    t1.ProgListName AS Programms,
    t1.ProgListCode AS IDProgrammss,
    1 AS IDProgramms, 
    (t3.Name + IsNull(' ' + t3.FirstName, '') + IsNull(' ' + t3.Secondname, '')) AS FIO,
    t2.Number       AS Policy,  
    t2.DateStart    AS PolicyStart, 
    t2.DateStop     AS PolicyEnd,  
    t2.DateStart    AS StartDate,   --Одинаково что полис, что застрахованный.
    t2.DateStop     AS Enddate,     --Одинаково что полис, что застрахованный.
    t3.Name         AS Name1, 
    t3.FirstName    AS Name2,
    t3.Secondname   AS Name3,
    t3.BirthDate    AS BirthDate,
    t3.OldName1     AS OldName1,
    t3.OldName2     AS OldName2,
    t3.OldName3     AS OldName3,  
    t3.Phone1       AS PhoneHome,
    t3.Phone2       AS PhoneWork,
    t3.MobilePhone  AS PhoneMobile,
    t3.Sex          AS Sex,
    t3.JobTitle     AS Position,     
    @InsurerName    AS InsurerName, 
    t6.Name         AS RelInsurer,  
    t5.Name         AS WorkPlace,  --Не работает
    t7.Name         AS InsRegion,  --работает, Было t4.Filial.
    
    ISNULL(t4.Adress, 
     (SELECT TOP 1 ta.[Address] FROM [Address] ta WHERE ta.FaceID = t5.FaceID AND ta.AdressTypeID IN (1,2) ORDER BY ta.AdressTypeID DESC)        
    )  AS WorkPlaceAddr, 
     
    t2.DateStart    AS SSDate,     --Одинаково что полис, что застрахованный.                
    --t8.[Address]    AS [Address],  
     (SELECT TOP 1 ta.[Address] FROM [Address] ta WHERE ta.FaceID = t1.FaceID  AND ta.AdressTypeID = 5 ORDER BY ta.DateReg DESC) AS [Address],
    ''              AS OldAddress,  --Не работает
    --t1.FaceID       AS FaceID,      --ФЛ ИД
    --t5.FaceID       AS FL_UL_ID,    --ФЛ.ЮЛ ИД
    ISNULL(t1.PrePay, 0) AS PrePay,
    (CASE WHEN ISNULL(t1.PrePay, 0) = 0 THEN 'факт' ELSE 'предоплата' END) PayFact                            
  INTO #ResIns3       
  FROM #ResIns2 as t1
    LEFT OUTER JOIN InsPolicy     t2 ON t2.RelContFace = t1.Insured
    LEFT OUTER JOIN FacePerson    t3 ON t3.FaceID      = t1.FaceID
    LEFT OUTER JOIN RelContFace   t4 ON t4.ID          = t1.Insured
    LEFT OUTER JOIN FaceJuridical t5 ON t5.FaceID      = t3.FaceJurID
    LEFT OUTER JOIN SimpleRefBook t6 ON t6.ID          = t4.SimplerRefBookID
    LEFT OUTER JOIN Area          t7 ON t7.AreaID      = t4.AreaID --Было t5.AreaID
    LEFT OUTER JOIN (SELECT MAX(DateReg) AS DateReg, AddressID, FaceID, [Address] FROM [Address] t1 WHERE t1.AdressTypeID = 5 GROUP BY AddressID, FaceID, [Address]) t8 ON t8.FaceID = t1.FaceID       
  --13 сек.

   --======================================================
  --13. Проставляем для удобства, чтобы потом в коде проще условия выборки делать.
  --====================================================== 
  --ActionPers нужно для того что нам нужны изменения только по данному допсу. Если застрахванный изменил персональные даные на другом допсе, то не выводим.
  UPDATE #ResIns3 SET ChangeFam    = 1 WHERE ActionPers = 1 AND Name1 <> OldName1
  UPDATE #ResIns3 SET ChangeIm     = 1 WHERE ActionPers = 1 AND Name2 <> OldName2
  UPDATE #ResIns3 SET ChangeOt     = 1 WHERE ActionPers = 1 AND Name3 <> OldName3
  UPDATE #ResIns3 SET ChangeBirth  = 1 WHERE ActionPers = 1 AND BirthDate <> OldBirthDate
  UPDATE #ResIns3 SET StartDate = @DateCur WHERE ActionIns = 1 OR ChangeProgram = 1  OR ChangeVar = 1
  UPDATE #ResIns3 SET WorkPlace = InsurerName WHERE WorkPlace IS NULL AND InsurerName IS NOT NULL
  --Выполнение всего всех запросов примерно 3 мин. 

  IF (@Test = 0)
  BEGIN
    SELECT * FROM #ResIns3
  END

  IF (@Test = 1)
  BEGIN
    --SELECT @CID AS CID, @AID AS AID, @DateCur AS DateCur, @DateCur_1 AS DateCur_1, @DatePrev AS DatePrev, @Reason AS Reason, @IsLong AS IsLong    
    SELECT * FROM #Ins0
    SELECT * FROM #Ins1
    SELECT * FROM #Ins2
    SELECT * FROM #Cont
    --SELECT * FROM #Ins3
    SELECT * FROM #ResIns1
    SELECT * FROM #ResInsSUM
    SELECT * FROM #ResIns2
    SELECT * FROM #ChangeProg
    IF OBJECT_ID('dbo.A_test_getChangeAID','U') IS NOT NULL 
       BEGIN  
         DROP TABLE dbo.A_test_getChangeAID       
       END
    SELECT * into dbo.A_test_getChangeAID FROM #ResIns3
  END


  --select * from dbo.A_test_getChangeAID where LPU =  11096
  --SELECT * FROM arhProgUpdate

       




--SELECT * FROM A_test_getChangeAID  WHERE LPU = 2431 AND PrePay = 0

--select 5800.82 + 5800.82 + 5479.41 +  5479.41 

--select * from AdressType



--SELECT TOP 1 AddressID, FaceID, [Address] FROM [Address] t1 WHERE t1.AdressTypeID = 5 and t1.FaceID = 4274699 ORDER BY DateReg DESC


--SELECT * from dbo.Robot_ChangeDate
--SELECT * from dbo.Robot_ChangeDate 

--SELECT CONVERT(varchar(10),  BirthDate, 104) FROM dbo.Robot_ChangeDate 


--60000 строймат.
--select 100000 + 45000 + 50000 + 60000 

--select 225 - 140 = 85.

--периметр
--select 6.1 + 6 + 3.7 + 4.3 + 3.7 + 1.4  + 6 = 31.2

--select 32 * 500 = 16000

--select * from 