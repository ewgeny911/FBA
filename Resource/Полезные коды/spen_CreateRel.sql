USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_CreateRel]    Script Date: 10.01.2018 9:58:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  --==============================================================================================================
-- Author:		Травин Е.В.
-- Create date: 28.12.2013
-- Description:	Создание объектов сущностей:
--   ВариантЗастрахованный, 
--   ОтношениеВариантЗастрахованныйПериодРассрочки,
--   ОтношениеПрограммаСтрахованияПериодРассрочки.
-- Если нужно создать только  ОтношениеВариантЗастрахованныйПериодРассрочки и 
-- ОтношениеПрограммаСтрахованияПериодРассрочки, то для вызова процедуры нужно 
-- указать только @InsID, @ContractID, @StateDate, остальные параметры могут быть NULL.
-- Повторный возов процедуры не создает лишних записей.
-- Если нужно создать ещё и ВариантЗастрахованный, в параметрах нужно указать остальные параметры. 
--
-- Описание параметров:
-- @InsID        - Застрахованный
-- @ContractID    - ДогСтрах
-- @FaceVariantID - ВариантЗастрахованный
-- @ContractVariantID - ВариантДогСтрах
-- @Reason - Основание (Для ВариантЗастрахованный)
-- @ReasonOFF - ОснованиеОткрпеления (Для ВариантЗастрахованный)
-- @StateDate - Дата состояния, на которую создаются (или добавляются) историчные атрибуты.
-- @StartDate - Дата начала (Для ВариантЗастрахованный)
-- @@EndDate - Дата окончания (Для ВариантЗастрахованный)
--
-- Пример вызова:
/*
EXEC	[dbo].[spen_CreateRel]
		@InsID = 622929,
		@ContractID = 552588,
		@FaceVariantID = NULL,
		@ContractVariantID = NULL, 
		@Reason = NULL,
		@ReasonOFF = NULL,
		@StateDate = NULL,
		@StartDate = NULL,
		@EndDate   = NULL
GO
*/
  --==============================================================================================================
ALTER PROCEDURE [dbo].[spen_CreateRel] (@InsID int, @ContractID int, @FaceVariantID int, @ContractVariantID int, @Reason int, @ReasonOFF int, 
                                @StateDate datetime, @StartDate datetime, @EndDate datetime)
AS
BEGIN
  --==============================================================================================================
  --Описание логики процедуры:
  --1. Поиск ВариантЗастрахованный
  --2. Если не найден ВариантЗастрахованный, то создается новый (При этом обязательно 
  -- чтобы в процедуру были переданы все необходимые параметры для его создания)
  --3. Получение списка периодов рассрочки
  --4. Получение списка программ по варианту
  --5. Далее два цикла. Один вложенный в другой:
  --Для каждого периода создается запись в ОтношениеВариантЗастрахованныйПериодРассрочки.
  --далее для каждой созданной записи в ОтношениеВариантЗастрахованныйПериодРассрочки создается
  --запись в ОтношениеПрограммаСтрахованияПериодРассрочки по числу программ в варианте.
  --Если например на договоре страхования 12 периодов, а на варианте застрахованного 5 программ, то в 
  --ОтношениеВариантЗастрахованныйПериодРассрочки будет 12 записей, а в ОтношениеПрограммаСтрахованияПериодРассрочки 
  --будет (12 * 5) = 60 записей.
  --Здесь также есть проверка на наличие уже существующих записей. Если запись (Объект) уже есть, то 
  --новая запись не добавляется. Также проверка на историчные состояние. Если оно есть, то новое состояние не добавляется.
  --============================================================================================================
    
    
    
  --==============================================================================================================
  --Локальные переменные  
  declare @ContractCreditPeriodID int          --ИД Периода рассрочки
  declare @RelFaceVariantCreditPeriodID int    --ИД ОтношениеВариантЗастрахованныйПериодРассрочки
  declare @ContractVariantProgramID int        --ИД ПрограммаВариантДогСтрах
  declare @RelVariantProgramCreditPeriodID int --ИД ОтношениеПрограммаСтрахованияПериодРассрочки
  
  --Для проверки кол-ва записей, котроые нужно создать, если кол-во совпадает, то ничего создавать не нужно.
  declare @CheckCountID int
  set @CheckCountID = 0
  --==============================================================================================================

  
  --==============================================================================================================
  --Получение и программ и ВариантЗастрахованный, ВариантДогСтрах одним запросом.
  --Пока не используется.
  /*Select
  Distinct
  EOT_7.FaceVariant "FaceVariantID",
  EOT_11.ContractVariantID "ContractVariantID",
  EOT_21.ContractVariantProgram "ContractVariantProgramID"
From
  RelContFace EOT_1
  Left Outer Join RelContFace_Hist_FaceVariant EOT_7
    On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (
      Select
        Max(StateDate)
      From
        RelContFace_Hist_FaceVariant
      Where
        (StateDate <= Convert(DateTime, @StateDate, 112)) And (EOT_1.ID = ID)
    ))
  Left Outer Join FaceVariant EOT_11
    On EOT_11.ID = EOT_7.FaceVariant
  Left Outer Join ContractVariant EOT_16
    On EOT_16.ID = EOT_11.ContractVariantID
  Left Outer Join ContractVariantContent EOT_21
    On EOT_21.Rel_ContractVariant = EOT_16.ID
Where
  EOT_1.ID = @InsID AND @StateDate between EOT_21.DateStart and IsNull(EOT_21.DateEnd, @StateDate)
  */

  --==============================================================================================================
  --Для отладки:
  --select top 10 * from FaceVariant
  --select top 10 * from FaceVariant_Hist_StartDate
  --select top 10 * from FaceVariant_Hist_EndDate
  --select top 10 * from FaceVariant_Hist_Prem
  --select top 10 * from FaceVariant_Hist_Amount
  --select top 10 * from RelFaceVariantCreditPeriod 
  --select top 10 * from RelFaceVariantCreditPeriod_Hist 
  --select top 10 * from RelVariantProgramCreditPeriod 
  --select top 10 * from RelVariantProgramCreditPeriod_Hist 
  --select top 10 * from ContractCreditPeriod
  --==============================================================================================================
  

  --==============================================================================================================
  --Если параметр ВариантЗастрахованный не передан в процедуру, пытаемся его определить.
  --Если он не будет найден, то будет создана новая запись в ВариантЗастрахованный. 
  --ВариантЗастрахованный здесь нужен обязательно, т.к. на него есть ссылка в ОтношениеВариантЗастрахованныйПериодРассрочки.
  --Исходный запрос:
  --select Вариант as FaceVariantID, Вариант.ВариантДогСтрах as ContractVariantID
  --from Застрахованный
  --where ИДОбъекта = @InsID and ДатаСостОбъекта = '01.01.1900' 
 IF (@FaceVariantID = 0) or  (@FaceVariantID is null) 
 begin 
    Select top 1
      @FaceVariantID = EOT_7.FaceVariant,
      @ContractVariantID = EOT_11.ContractVariantID
    From 
      RelContFace EOT_1
    Left Outer Join RelContFace_Hist_FaceVariant EOT_7 On (EOT_7.ID = EOT_1.ID) And (EOT_7.StateDate = (Select Max (StateDate) From RelContFace_Hist_FaceVariant Where (StateDate <= Convert(DateTime, @StateDate, 112)) And (EOT_1.ID = ID)))
    Left Outer Join FaceVariant EOT_11 On EOT_11.ID = EOT_7.FaceVariant
    Where
      EOT_1.ID = @InsID
 end
 --==============================================================================================================
  
  
 --==============================================================================================================
  --Вставка записи в ВариантЗастрахованный. 
  --здесь строки между begin и end не будут выполняться почти никогда.
  IF (@FaceVariantID = 0) or  (@FaceVariantID is null) 
  begin
    insert into FaceVariant (EntityID, FaceID, ContractVariantID, Reason) values (1711, @InsID, @ContractVariantID, @Reason)
    select @FaceVariantID = SCOPE_IDENTITY()

    insert into FaceVariant_Hist_StartDate (ID, StateDate, EntityID, StartDate) values (@FaceVariantID, @StateDate, 1711, @StartDate)
    insert into FaceVariant_Hist_EndDate   (ID, StateDate, EntityID, EndDate)   values (@FaceVariantID, @StateDate, 1711, @EndDate)
  end
  
  --if not exists(select top 1 * from FaceVariant_Hist_Prem where ID = @FaceVariantID and StateDate = @StateDate)--    --
  --  insert into FaceVariant_Hist_Prem      (ID, StateDate, EntityID) values (@FaceVariantID, @StateDate, 1711)--
 
  --if not exists(select top 1 * from FaceVariant_Hist_Amount where ID = @FaceVariantID and StateDate = @StateDate)--   
  --  insert into FaceVariant_Hist_Amount    (ID, StateDate, EntityID) values (@FaceVariantID, @StateDate, 1711)--
  --==============================================================================================================
  
  
  
  --==============================================================================================================
  if @CheckCountID = 1
  begin
  --Далее некоторый способ сократить время выполнения данной хранимки.
  --Проверяется кол-во объектов в ОтношениеПрограммаСтрахованияПериод рассрочки с максимально возможным, котрое нужно создать,
  --если кол-во совпадает, то ничего не делаем и выходим из процедуры. Код несколько длинный, но выполняется быстро и
  --во многих случаях уменьшит время работы данной хранимки, т.к. не нужно проходить по циклам ниже.
  --Данный блок кода можно убрать совсем - это никак не повлияет на правильность работы данной хранимой процедуры.
  --Данный код это переведенный с Master-SQL:
  /*select sum(CountRelID) as CountRelID, sum(NeedRelID)  as NeedRelID
  from
  (select 0 as CountRelID, (ВариантДогСтрах.ДогСтрах.ПериодыРассрочки.КоличОбъектовМассива *
                            ВариантДогСтрах.ПрограммаВариантДогСтрах.КоличОбъектовМассива) as NeedRelID
  From ВариантЗастрахованный
  where ИДОбъекта = 742357
  union all
  select count(ИДОБъекта) as CountRelID, 0 as NeedRelID
  Из  ОтношениеПрограммаСтрахованияПериодРассрочки
  где ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный = 742357 AND
  Премия.ДатаСостАтрибута = '01.01.2014' AND
  ПремияКВозврату.ДатаСостАтрибута = '01.01.2014' AND
  ОтношениеВариантЗастрахованныйПериодРассрочки.Премия.ДатаСостАтрибута = '01.01.2014' AND
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияДМС.ДатаСостАтрибута = '01.01.2014' AND
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияВЗР.ДатаСостАтрибута = '01.01.2014' AND
  ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияНС.ДатаСостАтрибута = '01.01.2014'
  ) t1
  */
  declare @CountRelID int
  declare @NeedRelID int
  
  Select
  @CountRelID = Sum(CountRelID),
  @NeedRelID  = Sum(NeedRelID)
From
  (
    Select
      0 CountRelID,
      (EOT_22.N * EOT_24.N) NeedRelID
    From
      FaceVariant EOT_1
      Left Outer Join ContractVariant EOT_8
        On EOT_8.ID = EOT_1.ContractVariantID
      Left Outer Join (
        Select
          EOT_25.Rel_ContractVariant F,
          Count(*)
          N
        From
          ContractVariantProgram EOT_25
        Group By
          EOT_25.Rel_ContractVariant
      ) EOT_24
        On EOT_24.F = EOT_8.ID
      Left Outer Join ContractIns EOT_13
        On EOT_13.CID = EOT_8.Contract_ID
      Left Outer Join (
        Select
          EOT_23.ContractID F,
          Count(*)
          N
        From
          ContractCreditPeriod EOT_23
        Group By
          EOT_23.ContractID
      ) EOT_22
        On EOT_22.F = EOT_13.CID
    Where
      EOT_1.ID = @FaceVariantID 
    Union
All
    Select
      Count(EOT_6.RelVariantProgramCreditPeriodID)
      CountRelID,
      0 NeedRelID
    From
      RelVariantProgramCreditPeriod EOT_6
      Left Outer Join RelVariantProgramCreditPeriod_Hist EOT_7
        On (EOT_7.RelVariantProgramCreditPeriod_HistID = EOT_6.RelVariantProgramCreditPeriodID) And (EOT_7.StateDate = (
          Select
            Max(StateDate)
          From
            RelVariantProgramCreditPeriod_Hist
          Where
            (StateDate <= Convert(DateTime, @StateDate, 112)) And (EOT_6.RelVariantProgramCreditPeriodID = RelVariantProgramCreditPeriod_HistID)
        ))
      Left Outer Join RelFaceVariantCreditPeriod EOT_29 Left Outer Join RelFaceVariantCreditPeriod_Hist EOT_30
        On (EOT_30.RelFaceVariantCreditPeriod_HistID = EOT_29.RelFaceVariantCreditPeriodID) And (EOT_30.StateDate = (
          Select
            Max(StateDate)
          From
            RelFaceVariantCreditPeriod_Hist
          Where
            (StateDate <= Convert(DateTime, @StateDate, 112)) And (EOT_29.RelFaceVariantCreditPeriodID = RelFaceVariantCreditPeriod_HistID)
        ))
        On EOT_29.RelFaceVariantCreditPeriodID = EOT_6.RelFaceVariantCreditPeriodID
    Where
      EOT_29.FaceVariantID = @FaceVariantID  AND EOT_7.StateDate = @StateDate AND EOT_7.StateDate = @StateDate AND EOT_30.StateDate = @StateDate AND EOT_30.StateDate = @StateDate AND EOT_30.StateDate = @StateDate AND EOT_30.StateDate = @StateDate
  ) t1
  
  --Если @CountRelID = @NeedIDRel то выходим и дальнейший код не делаем.
  if @CountRelID = @NeedRelID 
    return
  end  
    
   --==============================================================================================================
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
   --==============================================================================================================
  --Получение списка периодов рассрочки
  Declare Periods Cursor For
  select ContractCreditPeriodID from ContractCreditPeriod where ContractID = @ContractID
  Open Periods
  --==============================================================================================================
  
  
  --==============================================================================================================
  --Получение списка программ по варианту
  --Исходный запрос:
  --select distinct ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах as IDProgram 
  --From ВариантЗастрахованный
  --where ВариантДогСтрах = @ContractVariantID AND
  --@StateDate between ВариантДогСтрах.Содержимое.ДатаПрикрепления and
  --isnull(ВариантДогСтрах.Содержимое.ДатаОткрепления, @StateDate)
  --Запрос после перевода:
  Declare Programs Cursor dynamic For  
  Select
    Distinct
    EOT_11.ContractVariantProgram "IDProgram"
  From
    FaceVariant EOT_1
    Left Outer Join ContractVariant EOT_6
      On EOT_6.ID = EOT_1.ContractVariantID
    Left Outer Join ContractVariantContent EOT_11
      On EOT_11.Rel_ContractVariant = EOT_6.ID
    Left Outer Join ContractVariantProgram EOT_12 Left Outer Join ContractVariantProgram_Hist_Premium EOT_14
      On (EOT_14.ID = EOT_12.ID) And (EOT_14.StateDate = (
        Select
          Max(StateDate)
        From
          ContractVariantProgram_Hist_Premium
        Where
          (StateDate <= @StateDate) And (EOT_12.ID = ID)
      ))
      On EOT_12.ID = EOT_11.ContractVariantProgram
  Where
    EOT_1.ContractVariantID = @ContractVariantID AND @StateDate between EOT_11.DateStart and IsNull(EOT_11.DateEnd, @StateDate)
    and EOT_14.Premium > 0
  
  Open Programs
  --==============================================================================================================
  
  
  --==============================================================================================================
  --Вставка записей в ОтношениеВариантЗастрахованныйПериодРассрочки
  --Таблицы:
  --RelFaceVariantCreditPeriod
  --RelFaceVariantCreditPeriod_Hist
  Fetch From Periods Into @ContractCreditPeriodID
  while @@Fetch_Status = 0
  begin 
      --=====>>>>> ОтношениеВариантЗастрахованныйПериодРассрочки ======================
      --Вставка в главную таблицу ОтношениеВариантЗастрахованныйПериодРассрочки (RelFaceVariantCreditPeriod)
      --Сначала проверка на наличие такой записи, если не найдено, то вставляем
      set @RelFaceVariantCreditPeriodID = 0
      select @RelFaceVariantCreditPeriodID = RelFaceVariantCreditPeriodID from RelFaceVariantCreditPeriod where FaceVariantID = @FaceVariantID and ContractCreditPeriodID = @ContractCreditPeriodID
      if (@RelFaceVariantCreditPeriodID = 0)
      begin  
        insert into RelFaceVariantCreditPeriod (EntityID, FaceVariantID, ContractCreditPeriodID) values (1810, @FaceVariantID , @ContractCreditPeriodID)     
        select @RelFaceVariantCreditPeriodID = SCOPE_IDENTITY()
      end
     
      --Вставка в историчную таблицу ОтношениеВариантЗастрахованныйПериодРассрочки (RelFaceVariantCreditPeriod_Hist)
      --Если не найдено такого историчногог состояния, то вставляем
      --if not exists(select top 1 * from  RelFaceVariantCreditPeriod_Hist where RelFaceVariantCreditPeriod_HistID = @RelFaceVariantCreditPeriodID and StateDate = @StateDate)--
      --  insert into RelFaceVariantCreditPeriod_Hist (RelFaceVariantCreditPeriod_HistID, StateDate, EntityID) values (@RelFaceVariantCreditPeriodID, @StateDate, 1810) --
      --=====<<<<< ОтношениеВариантЗастрахованныйПериодРассрочки ======================
     
     
      --=====>>>>> ОтношениеПрограммаСтрахованияПериодРассрочки ======================
      --Вставка записей в ОтношениеПрограммаСтрахованияПериодРассрочки
      --Таблицы:
      --RelVariantProgramCreditPeriod
      --RelVariantProgramCreditPeriod_Hist
      Fetch first From Programs Into @ContractVariantProgramID
      while @@Fetch_Status = 0
      begin
          --Вставка в главную таблицу ОтношениеПрограммаСтрахованияПериодРассрочки (RelVariantProgramCreditPeriod)
          set @RelVariantProgramCreditPeriodID = 0
          select @RelVariantProgramCreditPeriodID = RelVariantProgramCreditPeriodID from RelVariantProgramCreditPeriod where RelFaceVariantCreditPeriodID = @RelFaceVariantCreditPeriodID and ContractVariantProgramID = @ContractVariantProgramID
       
          if @RelVariantProgramCreditPeriodID = 0 
          begin
            insert into RelVariantProgramCreditPeriod (EntityID, RelFaceVariantCreditPeriodID, ContractVariantProgramID) values (1812, @RelFaceVariantCreditPeriodID , @ContractVariantProgramID)     
            --select @RelVariantProgramCreditPeriodID = SCOPE_IDENTITY()
          end
          
           --Вставка в историчную таблицу ОтношениеПрограммаСтрахованияПериодРассрочки (RelVariantProgramCreditPeriod_Hist)
          --if not exists(select top 1 * from RelVariantProgramCreditPeriod_Hist where RelVariantProgramCreditPeriod_HistID = @RelVariantProgramCreditPeriodID and StateDate = @StateDate)-- 
          --  insert into RelVariantProgramCreditPeriod_Hist (RelVariantProgramCreditPeriod_HistID, StateDate, EntityID) values (@RelVariantProgramCreditPeriodID, @StateDate, 1812) --  
       
          Fetch next From Programs Into @ContractVariantProgramID
      end
      --=====<<<<< ОтношениеПрограммаСтрахованияПериодРассрочки ======================
     
      Fetch From Periods Into @ContractCreditPeriodID
  end
  --==============================================================================================================
  
  
  --==============================================================================================================
  Close Periods
  Deallocate Periods
  Close Programs
  Deallocate Programs
  --==============================================================================================================
     
  --==============================================================================================================   
  --Результат ВариантЗастрахованный.ИДобъекта
  select @FaceVariantID as FaceVariantID
  --==============================================================================================================
END

--Ниже находится аналог данной функции на прикладном коде платформы Master (не удалять, возможно понадобится):
/*
//==============================================================================
// Создание ВариантЗастрахованный
// InsID    - Застрахованный
// CID      - Договор
// VarInsID - ВариантЗастрахованный
// VarCID   - ВариантДогСтрах
// Reason, ReasonOFF - Основание и ОснованиеОткрепления
// SD - текущая дата
// DateBeg, DateEnd - даты действия ВариантЗастрахованный
// Два логическихъ варианта вызова функции:
// 1. У нас есть Застрахованный и у него есть ВариантЗастрахованный и для него нужно
// создать недостающие периоды
// 2. У нас есть Застрахованный и нужно создать с нуля все объекты, включая ВариантЗастрахованный
//==============================================================================
function CreateVar(InsID, CID, VarInsID, VarCID, Reason, ReasonOFF: integer; SD, DateBeg, DateEnd: TDateTime): integer;
var ObVariant : TenObject;
    IDOb : integer;
    MyDateN, MyDateK : DateTime;
    arSum : Variant;
begin
  if VarInsID = 0 then
  begin
    ObVariant := enManager.NewOByB['ВариантЗастрахованный'];
    ObVariant.NewStateDate(SD);
    ObVariant.AByB['ВариантДогСтрах'].AsInteger := VarCID;
    if Reason <> 0     then ObVariant.AByB['Основание'].AsInteger := Reason;
    if ReasonOFF <> 0  then ObVariant.AByB['ОснованиеОткрепления'].AsInteger := ReasonOFF;
    if DateBeg <> null then ObVariant.AByB['ДатаНачала'].AsDateTime := DateBeg;
    if DateEnd <> null then ObVariant.AByB['ДатаОкончания'].AsDateTime := DateEnd;
    SetAttrStateDate(ObVariant, SD);
    ObVariant.Write;
    VarInsID := ObVariant.ID;
    ObVariant.Free;
  end;

  CreateRel(InsID, CID, VarInsID, VarCID, SD);
  Result := VarInsID;
end;


//==============================================================================
// Создание Отношений:
// ОтношениеВариантаЗастрахованныйПериодРассрочки
// ОтношениеПрограммаСтрахованияПериодРассрочки
// Для создания отношений нужно знать либо Застрахованный либо ВариантЗастрахованный
// и обязательно ДогСтрах, т.к. нужно знать все периоды рассрочки
//==============================================================================
procedure CreateRel(InsID, CID, VarInsID, VarCID: integer; SD: TDateTime);
--var
  SQL : string;

  IDPeriod, IDRelVarPeriod, IDProgram: integer;
  StateDateStr: string;
  qNeedCreateRel: TencQuery;
  qProgram, qPeriod: TencQuery;
begin
  StateDateStr := DateTimeToSQLStr(SD);
  qProgram := TencQuery.Create(nil);
  qPeriod := TencQuery.Create(nil);

  //Получение ИД программ застрахованного
  //Либо у нас есть ВариантЗастрахованный
  //Либо у нас есть Застрахованный

  if (VarInsID > 0) then
  begin
  SQL := 'select Distinct ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах as IDProgram From ' + CR +
         'ВариантЗастрахованный ' + CR +
         'where ИДОбъекта =  ' + IntToStr(VarInsID) + ' AND ' + CR +
         'ISNULL(ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах.Депозит, 0) = 0  AND ' + CR +
         'ВариантДогСтрах.Содержимое.ДатаПрикрепления <= ''' + StateDateStr + ''' AND ' + CR +
         '(ВариантДогСтрах.Содержимое.ДатаОткрепления is null OR ' + CR +
             'ВариантДогСтрах.Содержимое.ДатаОткрепления >= ''' + StateDateStr + ''')';
      Query1(qProgram, SQL);
   end
   else if (InsID > 0) then
   begin
     SQL := 'select Distinct Вариант, Вариант.ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах as IDProgram From ' + CR +
            'Застрахованный ' + CR +
            'where ИДОбъекта =  ' + IntToStr(InsID) + CR +
            'and ДатаСостОбъекта = ''' + StateDateStr + ''' and ' + CR +
            'ISNULL(Вариант.ВариантДогСтрах.Содержимое.ПрограммаВариантДогСтрах.Депозит, 0) = 0  AND ' + CR +
            'Вариант.ВариантДогСтрах.Содержимое.ДатаПрикрепления <= ''' + StateDateStr + ''' AND ' + CR +
            '(Вариант.ВариантДогСтрах.Содержимое.ДатаОткрепления is null OR ' + CR +
               'Вариант.ВариантДогСтрах.Содержимое.ДатаОткрепления >=  ''' + StateDateStr + ''')';
    Query1(qProgram, SQL);
    VarInsID := qProgram.FieldbyName('Вариант').AsInteger;
  end;



  //Сравниваем по количеству записей в ОтношениеПрограммаСтрахованияПериодРассрочки.
  //Если совпадает с тем количеством, котрое нужно создать (т.е. уже все создано), то по циклам (процедура CreateRel) не пробегаем.
  SQL := 'select sum(CountIDRel) as CountIDRel, sum(NeedRelID)  as NeedRelID ' + CR +
  'from ' + CR +
  '(select 0 as CountIDRel, (ВариантДогСтрах.ДогСтрах.ПериодыРассрочки.КоличОбъектовМассива * ' + CR +
                            'ВариантДогСтрах.ПрограммаВариантДогСтрах.КоличОбъектовМассива) as NeedRelID ' + CR +
  'From ВариантЗастрахованный ' + CR +
  'where ИДОбъекта = ' + IntToStr(VarInsID) + CR +
  'union all ' + CR +
  'select count(ИДОБъекта) as CountIDRel, 0 as NeedRelID ' + CR +
  'Из  ОтношениеПрограммаСтрахованияПериодРассрочки ' + CR +
  'где ОтношениеВариантЗастрахованныйПериодРассрочки.ВариантЗастрахованный = ' + IntToStr(VarInsID) + ' AND ' + CR +
  'Премия.ДатаСостАтрибута = ''' + StateDateStr + ''' AND ' + CR +
  'ПремияКВозврату.ДатаСостАтрибута = ''' + StateDateStr + ''' AND ' + CR +
  'ОтношениеВариантЗастрахованныйПериодРассрочки.Премия.ДатаСостАтрибута = ''' + StateDateStr + ''' AND ' + CR +
  'ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияДМС.ДатаСостАтрибута = ''' + StateDateStr + ''' AND ' + CR +
  'ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияВЗР.ДатаСостАтрибута = ''' + StateDateStr + ''' AND ' + CR +
  'ОтношениеВариантЗастрахованныйПериодРассрочки.ПремияНС.ДатаСостАтрибута = ''' + StateDateStr + ''' ' + CR +
  ') t1 ';

  qNeedCreateRel := TencQuery.Create(nil);
  Query1(qNeedCreateRel, SQL);
  if (qNeedCreateRel.FieldByName('CountIDRel').AsInteger = qNeedCreateRel.FieldByName('NeedRelID').AsInteger) and
     (qNeedCreateRel.FieldByName('NeedRelID').AsInteger > 0)
   then exit;



  SQL := 'select ИДОбъекта as IDPeriod from ПериодРассрочкиДогСтрах where ДогСтрах = ' + IntToStr(CID);
  Query1(qPeriod, SQL);

  qPeriod.First;
  while not qPeriod.EOF do
  begin
    IDPeriod := qPeriod.FieldByName('IDPeriod').AsInteger;
    IDRelVarPeriod := SaveRelVariantPeriod(VarInsID, IDPeriod, SD);
    qProgram.First;
    while not qProgram.EOF do
    begin
      IDProgram := qProgram.FieldByName('IDProgram').AsInteger;
      SaveRelProgramPeriod(IDRelVarPeriod, IDProgram, SD);
      qProgram.Next;
    end;
    qPeriod.Next;
  end;
  qProgram.Free;
  qPeriod.Free;
end;


//==============================================================================
// Сохранить объект "Отношение Вариант по застрахованному - Период рассрочки"
// Возвращает ИД объекта
//==============================================================================
function SaveRelVariantPeriod(VarInsID, IDPeriod: Integer; SD: DateTime): Integer;
--var
  Ob : TenObject;
  ObID : Integer;
begin
  Result := 0;
  if VarInsID = 0 then exit;
  ObID := VarToInt( GetAttrByWhere('ОтношениеВариантЗастрахованныйПериодРассрочки', 'ИДОбъекта',
                     'ВариантЗастрахованный = ' + IntToStr(VarInsID) + ' AND ПериодРассрочкиДогСтрах = ' + IntToStr(IDPeriod)) );
  if ObID = 0 then
    Ob := enManager.NewOByB['ОтношениеВариантЗастрахованныйПериодРассрочки']
  else
    Ob := enManager.ODByB['ОтношениеВариантЗастрахованныйПериодРассрочки', ObID, SD];

  Ob.AByB['ВариантЗастрахованный'].AsInteger := VarInsID;
  Ob.AByB['ПериодРассрочкиДогСтрах'].AsInteger := IDPeriod;
  Ob.AByB['Премия'].NewStateDate(SD);
  Ob.AByB['ПремияВЗР'].NewStateDate(SD);
  Ob.AByB['ПремияНС'].NewStateDate(SD);
  Ob.AByB['ПремияДМС'].NewStateDate(SD);
  Ob.Write;
  Result := Ob.ID;
  Ob.Free;
end;


//==============================================================================
// Сохранить объект "Отношение Программа страхования - Период рассрочки" с премией
// Возвращает ИД объекта
//==============================================================================
function SaveRelProgramPeriod(IDRelVariantPeriod, IDProgram: Integer; SD : TDateTime): Integer;
--var
  Ob : TenObject;
  ObID : Integer;
begin
  Result := 0;
  if IDRelVariantPeriod = 0 then
    Exit;
  ObID := VarToInt(GetAttrByWhere('ОтношениеПрограммаСтрахованияПериодРассрочки', 'ИДОбъекта',
                     'ОтношениеВариантЗастрахованныйПериодРассрочки = ' + IntToStr(IDRelVariantPeriod) + ' AND ПрограммаВариантДогСтрах = ' + IntToStr(IDProgram)) );
  if ObID = 0 then
    Ob := enManager.NewOByB['ОтношениеПрограммаСтрахованияПериодРассрочки']
  else
    Ob := enManager.ODByB['ОтношениеПрограммаСтрахованияПериодРассрочки', ObID, SD];

  Ob.AByB['ОтношениеВариантЗастрахованныйПериодРассрочки'].AsInteger := IDRelVariantPeriod;
  Ob.AByB['ПрограммаВариантДогСтрах'].AsInteger := IDProgram;
  Ob.AByB['Премия'].NewStateDate(SD);
  Ob.AByB['ПремияКВозврату'].NewStateDate(SD);

  Ob.Write;
  Result := Ob.ID;
  Ob.Free;
end; 

*/
