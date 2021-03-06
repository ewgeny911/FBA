USE [DIASOFT_test2]
GO
/****** Object:  StoredProcedure [dbo].[spen_SaveObject]    Script Date: 28.12.2018 10:32:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
EXEC spen_SaveObject 2, 'INSERT', 10, 'Застрахованный',  '19000101 00:00:00.000', 
'ДатаНачала', '20150101 00:00:00.000',  
'Примечание', 'вгвв',
'ДатаОкончания', '20150101 00:00:00.000', 
'Регион',  81,  
'ФЛ',      1858557,  
'Полис',   85563,  
'Филиал', 'Филиал № 7806 Банка ВТБ 24 (закрытое акционерное общество) в г. Санкт-Петербурге' 
    
EXEC spen_SaveObject 1, 'UPDATE', 10, 'ВариантЗастрахованный',  '19000101 00:00:00.000', 
'Премия',    100,  
'ПремияДМС', 101,
'ПремияВЗР', 102, 
'Сумма',     1000,  
'СуммаДМС',  1001,  
'СуммаВЗР',  1002,  
'Основание', 4
 
 EXEC spen_SaveObject 1, 'INSERT', 10, 'ВариантЗастрахованный',  '19000101 00:00:00.000', 
'Премия',    100,  
'ПремияДМС', 101,
'ПремияВЗР', 102, 
'Сумма',     1000,  
'СуммаДМС',  1001,  
'СуммаВЗР',  1002,  
'Основание', 4
 
      
EXEC spen_SaveObject 1, 'UPDATE', 134, 'ДогСтрах',  '19000101 00:00:00.000', 
'ДатаНачала', '20150101 00:00:00.000',  
'ДатаОкончания', '20150101 00:00:00.000',
'Ремарка', 'вгвв', 
'ДатаПодписания', '20150101 00:00:00.000',
'Номер',       'A126077-0045445', 
'ВидСтрах',     2,  
'Организация',  3,  
'Примечание', 'вгвв', 
'ТипДогСтрах', 6

EXEC spen_SaveObject 1, 'UPDATE', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', 'ааа',  
'Симптом', 'ббб',
'ЛПУ', 'ввв', 
'ПринявшийВызов',  'ггг'


EXEC spen_SaveObject 1, 'INSERT', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', 'ааа',  
'Симптом', 'ббб',
'ЛПУ', 'ввв', 
'ПринявшийВызов',  'ггг'


EXEC spen_SaveObject 1, 'SELECT', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', '',  
'Симптом', '',
'ЛПУ', '', 
'ПринявшийВызов',  ''


EXEC spen_SaveObject 1, 'SELECT', 134, 'ДогСтрах',  '19000101 00:00:00.000', 
'ДатаНачала',     '',  
'ДатаОкончания',  '',
'Ремарка',        '', 
'ДатаПодписания', '',
'Номер',          '', 
'ВидСтрах',       '',  
'Организация',    '', 
'Примечание',     '', 
'ТипДогСтрах',    ''

 
EXEC spen_SaveObject 1, 'UPDATE', 134, 'ДогСтрах',  '19000101 00:00:00.000', 
'ДатаНачала',     '',  
'ДатаОкончания',  '',
'Ремарка',        '', 
'ДатаПодписания', '',
'Номер',          '', 
'ВидСтрах',       2,  
'Организация',    1, 
'Примечание',     '', 
'ТипДогСтрах',    6

EXEC spen_SaveObject 1, 'UPDATE', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', 9,  
'Симптом', '',
'ЛПУ', 8, 
'ПринявшийВызов',  ''

  
EXEC spen_SaveObject 1, 'DELETE', 134, 'ЗаявкаСМП',  '19000101 00:00:00.000'   
EXEC spen_SaveObject 1, 'DELETE', 134, 'ДогСтрах',  '19000101 00:00:00.000'   
EXEC spen_SaveObject 1, 'INSERT', 0,'ДогСтрах','','ВидДок','4'
EXEC spen_SaveObject 1, 'UPDATE', 844954,'ДогСтрах','','ВидДок','3'  
EXEC spen_SaveObject 1, 'UPDATE', 844954,'ДогСтрах','','ВидДок',''
EXEC spen_SaveObject 3, 'UPDATE', 844954,'ДогСтрах','','ВидДок','3' 
EXEC spen_SaveObject 0, 'UPDATE', 702110,'ДогСтрах','','ПосредникУправленческий',NULL
*/      

--@Mode = 0 - Рабочий режим. Все запросы выполняются. Запрос берётся из кэша или формируется заново, если в кэше нет такого.
--@Mode = 1 - Рабочий режим. Все запросы выполняются. Кэш не используется, выполняется всегда запрос сформированный заново.
--@Mode = 2 - Запросы не выполняются. Возврашается либо кешированный запрос, либо сформирвоанный заново, если кэшированого нет.
--@Mode = 3 - Запросы не выполняются. Кэш не используется, возвращается всегда сформированный заново запрос.
--@Mode = 4 - Запросы не выполняются. Кэш не используется, возвращается список таблиц и другася отладочная информация.
--@Mode = 5 - Запросы не выполняются. Использутся только кэш. Если запроса в кэше нет, то формирвоание заново не происходит. Возвращается запрос из кэша.

ALTER PROCEDURE [dbo].[spen_SaveObject] (
   @Mode int,
   @Operation VARCHAR(100)
  ,@ObjectID int
  ,@EntityBrief VARCHAR(100)
  ,@StateDate VARCHAR(100) = '1900-01-01 00:00:00.000'
  ,@ParName01 VARCHAR(100) = NULL, @ParValue01 VARCHAR(MAX) = NULL         
  ,@ParName02 VARCHAR(100) = NULL, @ParValue02 VARCHAR(MAX) = NULL  
  ,@ParName03 VARCHAR(100) = NULL, @ParValue03 VARCHAR(MAX) = NULL  
  ,@ParName04 VARCHAR(100) = NULL, @ParValue04 VARCHAR(MAX) = NULL  
  ,@ParName05 VARCHAR(100) = NULL, @ParValue05 VARCHAR(MAX) = NULL  
  ,@ParName06 VARCHAR(100) = NULL, @ParValue06 VARCHAR(MAX) = NULL  
  ,@ParName07 VARCHAR(100) = NULL, @ParValue07 VARCHAR(MAX) = NULL  
  ,@ParName08 VARCHAR(100) = NULL, @ParValue08 VARCHAR(MAX) = NULL  
  ,@ParName09 VARCHAR(100) = NULL, @ParValue09 VARCHAR(MAX) = NULL  
  ,@ParName10 VARCHAR(100) = NULL, @ParValue10 VARCHAR(MAX) = NULL 
  ,@ParName11 VARCHAR(100) = NULL, @ParValue11 VARCHAR(MAX) = NULL 
  ,@ParName12 VARCHAR(100) = NULL, @ParValue12 VARCHAR(MAX) = NULL
  ,@ParName13 VARCHAR(100) = NULL, @ParValue13 VARCHAR(MAX) = NULL  
  ,@ParName14 VARCHAR(100) = NULL, @ParValue14 VARCHAR(MAX) = NULL  
  ,@ParName15 VARCHAR(100) = NULL, @ParValue15 VARCHAR(MAX) = NULL 
  ,@ParName16 VARCHAR(100) = NULL, @ParValue16 VARCHAR(MAX) = NULL 
  ,@ParName17 VARCHAR(100) = NULL, @ParValue17 VARCHAR(MAX) = NULL
  ,@ParName18 VARCHAR(100) = NULL, @ParValue18 VARCHAR(MAX) = NULL
  ,@ParName19 VARCHAR(100) = NULL, @ParValue19 VARCHAR(MAX) = NULL
  ,@ParName20 VARCHAR(100) = NULL, @ParValue20 VARCHAR(MAX) = NULL
  ,@ParName21 VARCHAR(100) = NULL, @ParValue21 VARCHAR(MAX) = NULL 
  ,@ParName22 VARCHAR(100) = NULL, @ParValue22 VARCHAR(MAX) = NULL
  ,@ParName23 VARCHAR(100) = NULL, @ParValue23 VARCHAR(MAX) = NULL
  ,@ParName24 VARCHAR(100) = NULL, @ParValue24 VARCHAR(MAX) = NULL
) AS
BEGIN
  SET @StateDate = '''' + @StateDate + ''''
  SET @Operation = UPPER(@Operation)

  DECLARE @SQLText VARCHAR(MAX)
  DECLARE @SQLText_Value VARCHAR(MAX)
  DECLARE @ObjectIDStr VARCHAR(MAX) = CAST(@ObjectID AS VARCHAR(100))

  DECLARE @AttrList VARCHAR(MAX) = 
    ISNULL(@ParName01, '') + ',' + 
    ISNULL(@ParName02, '') + ',' + 
    ISNULL(@ParName03, '') + ',' + 
    ISNULL(@ParName04, '') + ',' +
    ISNULL(@ParName05, '') + ',' +
    ISNULL(@ParName06, '') + ',' +
    ISNULL(@ParName07, '') + ',' +
    ISNULL(@ParName08, '') + ',' +
    ISNULL(@ParName09, '') + ',' +
    ISNULL(@ParName10, '') + ',' +
    ISNULL(@ParName11, '') + ',' +
    ISNULL(@ParName12, '') + ',' +
    ISNULL(@ParName13, '') + ',' +
    ISNULL(@ParName14, '') + ',' +
    ISNULL(@ParName15, '') + ',' +
    ISNULL(@ParName16, '') + ',' +
    ISNULL(@ParName17, '') + ',' +
    ISNULL(@ParName18, '') + ',' +
    ISNULL(@ParName19, '') + ',' +
    ISNULL(@ParName20, '') + ',' +
    ISNULL(@ParName21, '') + ',' +
    ISNULL(@ParName22, '') + ',' +
    ISNULL(@ParName23, '') + ',' +
    ISNULL(@ParName24, '')
        
  IF (@Mode = 0) OR (@Mode = 2) OR (@Mode = 5) 
  BEGIN
    SELECT @SQLText = SQLText FROM arhQueryCache WHERE AttrList = @AttrList AND Operation = @Operation   
    
    --@Mode = 5 - Запросы не выполняются. Использутся только кэш. Если запроса в кэше нет, то формирвоание заново не происходит. Возвращается запрос из кэша.
    IF (@Mode = 5) AND (@SQLText IS NULL) 
    BEGIN   
      SELECT NULL AS SQLText
      RETURN
    END

    IF (@SQLText IS NOT NULL) 
    BEGIN
      --select * from arhQueryCache    
      --delete from arhQueryCache   
      SET @SQLText_Value = @SQLText
      SET @SQLText = REPLACE(@SQLText, '@StateDate', @StateDate)  
      SET @SQLText = REPLACE(@SQLText, '@ObjectID',  @ObjectID)  
      IF (@ParName01 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_01', @ParValue01)
      IF (@ParName02 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_02', @ParValue02)
      IF (@ParName03 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_03', @ParValue03)
      IF (@ParName04 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_04', @ParValue04)
      IF (@ParName05 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_05', @ParValue05)
      IF (@ParName06 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_06', @ParValue06)
      IF (@ParName07 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_07', @ParValue07)
      IF (@ParName08 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_08', @ParValue08)
      IF (@ParName09 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_09', @ParValue09)
      IF (@ParName10 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_10', @ParValue10)
      IF (@ParName11 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_11', @ParValue11)
      IF (@ParName12 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_12', @ParValue12)
      IF (@ParName13 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_13', @ParValue13)
      IF (@ParName14 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_14', @ParValue14)
      IF (@ParName15 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_15', @ParValue15)
      IF (@ParName16 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_16', @ParValue16)
      IF (@ParName17 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_17', @ParValue17)
      IF (@ParName18 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_18', @ParValue18)
      IF (@ParName19 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_19', @ParValue19)
      IF (@ParName20 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_20', @ParValue20)
      IF (@ParName21 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_21', @ParValue21)
      IF (@ParName22 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_22', @ParValue22)
      IF (@ParName23 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_23', @ParValue23)
      IF (@ParName24 IS NOT NULL) SET @SQLText = REPLACE(@SQLText, '@Value_24', @ParValue24)
      --@Mode = 0 - Рабочий режим. Все запросы выполняются. Запрос берётся из кэша или формируется заново, если в кэше нет такого.
      IF (@Mode = 0)
      BEGIN
        EXEC (@SQLText) 
        RETURN
      END
      --@Mode = 2 - Запросы не выполняются. Возврашается либо кешированный запрос, либо сформирвоанный заново, если кэшированого нет. 
      IF (@Mode = 2)
      BEGIN       
        SELECT @SQLText AS SQLText --, @SQLText_Value AS SQLText_Value    
        RETURN   
      END 
      --@Mode = 5 - Запросы не выполняются. Использутся только кэш. Если запроса в кэше нет, то формирвоание заново не происходит. Возвращается запрос из кэша.
      IF (@Mode = 5)
      BEGIN       
        SELECT @SQLText AS SQLText, @SQLText_Value AS SQLText_Value    
        RETURN   
      END      
    END
  END 

  DECLARE @Par TABLE (
    Value_ID VARCHAR(100),
    ParName VARCHAR(100), 
    ParValue VARCHAR(MAX), 
    SQLSelect VARCHAR(MAX),
    SQLInsert VARCHAR(MAX),
    SQLUpdate VARCHAR(MAX),
    SQLDelete VARCHAR(MAX),
    SQLInsertSD VARCHAR(MAX),
    EntityID int, 
    Attr_Brief VARCHAR(100), 
    Table_Name VARCHAR(100), 
    Table_Type VARCHAR(100), 
    Table_Field VARCHAR(100), 
    Table_IDFieldName VARCHAR(100), 
    LevelTop int, 
    LevelTop1 VARCHAR(100), 
    LevelTop2 VARCHAR(100), 
    IDENTITYStr VARCHAR(100),
    DATA_TYPE VARCHAR(100),
    CHARACTER_MAXIMUM_LENGTH int,
    NUMERIC_PRECISION int,
    NUMERIC_PRECISION_RADIX int  
  )
  
  IF (@Operation <> 'DELETE')
  BEGIN
    IF (@ParName01 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_01', @ParName01, @ParValue01)
    IF (@ParName02 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_02', @ParName02, @ParValue02)
    IF (@ParName03 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_03', @ParName03, @ParValue03)
    IF (@ParName04 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_04', @ParName04, @ParValue04)
    IF (@ParName05 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_05', @ParName05, @ParValue05)
    IF (@ParName06 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_06', @ParName06, @ParValue06)
    IF (@ParName07 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_07', @ParName07, @ParValue07)
    IF (@ParName08 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_08', @ParName08, @ParValue08)
    IF (@ParName09 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_09', @ParName09, @ParValue09)
    IF (@ParName10 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_10', @ParName10, @ParValue10)
    IF (@ParName11 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_11', @ParName11, @ParValue11)
    IF (@ParName12 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_12', @ParName12, @ParValue12)
    IF (@ParName13 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_13', @ParName13, @ParValue13)
    IF (@ParName14 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_14', @ParName14, @ParValue14)
    IF (@ParName15 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_15', @ParName15, @ParValue15)
    IF (@ParName16 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_16', @ParName16, @ParValue16)
    IF (@ParName17 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_17', @ParName17, @ParValue17)
    IF (@ParName18 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_18', @ParName18, @ParValue18)
    IF (@ParName19 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_19', @ParName19, @ParValue19)
    IF (@ParName20 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_20', @ParName20, @ParValue20)
    IF (@ParName21 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_21', @ParName21, @ParValue21)
    IF (@ParName22 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_22', @ParName22, @ParValue22)
    IF (@ParName23 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_23', @ParName23, @ParValue23)
    IF (@ParName24 IS NOT NULL) INSERT INTO  @Par (Value_ID, ParName, ParValue) VALUES ('@Value_24', @ParName24, @ParValue24)
  END
  
  IF ((@Operation = 'UPDATE') OR (@Operation = 'SELECT'))
  BEGIN
    UPDATE @Par SET 
      Attr_Brief               = t1.Attr_Brief, 
      EntityID                 = t1.EnChildID,     
      Table_Name               = t1.Table_Name,
      Table_Type               = t1.Table_Type,
      Table_Field              = t1.Table_Field,
      Table_IDFieldName        = t1.Table_IDFieldName,
      LevelTop                 = t1.NumLevel,--t1.LevelTop,    
      LevelTop1                = '',
      LevelTop2                = '',
      IDENTITYStr              = '',
      DATA_TYPE                = t1.DATA_TYPE,
      CHARACTER_MAXIMUM_LENGTH = t1.CHARACTER_MAXIMUM_LENGTH,
      NUMERIC_PRECISION        = t1.NUMERIC_PRECISION,
      NUMERIC_PRECISION_RADIX  = t1.NUMERIC_PRECISION_RADIX                                          
    FROM arhAttrParent t1 
    WHERE 
      t1.EnBrief2 = @EntityBrief 
      AND t1.Attr_Brief = ParName
  END 

  IF (@Operation = 'INSERT')
  BEGIN    
    UPDATE @Par SET 
      Attr_Brief               = t1.Attr_Brief, 
      EntityID                 = t1.EnChildID,
      Table_Name               = t1.Table_Name,
      Table_Type               = t1.Table_Type,
      Table_Field              = t1.Table_Field,
      Table_IDFieldName        = t1.Table_IDFieldName,
      LevelTop                 = t1.NumLevel,--t1.LevelTop,    
      LevelTop1                = '',
      LevelTop2                = '',
      IDENTITYStr              = '',
      DATA_TYPE                = t1.DATA_TYPE,
      CHARACTER_MAXIMUM_LENGTH = t1.CHARACTER_MAXIMUM_LENGTH,
      NUMERIC_PRECISION        = t1.NUMERIC_PRECISION,
      NUMERIC_PRECISION_RADIX  = t1.NUMERIC_PRECISION_RADIX                                          
    FROM arhAttrParent t1 
    WHERE 
      t1.EnBrief2 = @EntityBrief 
      AND t1.Attr_Brief = ParName

    MERGE @Par AS T_Base
	  USING 
      (SELECT DISTINCT t1.EntityID, t1.Table_Name, t1.Table_IDFieldName, t1.Table_Type, t1.NumLevel, '' AS LevelTop1, '' AS LevelTop2    
      FROM arhAttrParent t1 where t1.EnBrief2  = @EntityBrief AND t1.Attr_Type < 3 and  t1.Attr_Kind = 1)  
    AS T_Source 
	  ON (T_Base.Table_Name = T_Source.Table_Name) 
	  WHEN NOT MATCHED THEN 
		  INSERT (EntityID, Table_Name, Table_IDFieldName, Table_Type, LevelTop, LevelTop1, LevelTop2)	
		  VALUES (T_Source.EntityID, T_Source.Table_Name, T_Source.Table_IDFieldName, T_Source.Table_Type, T_Source.NumLevel, T_Source.LevelTop1, T_Source.LevelTop2);
  END

  IF (@Operation = 'DELETE')
  BEGIN
    INSERT INTO @Par (EntityID, Table_Name, Table_IDFieldName, Table_Type, LevelTop, LevelTop1, LevelTop2) 
    SELECT DISTINCT t1.EntityID, t1.Table_Name, t1.Table_IDFieldName, t1.Table_Type, t1.NumLevel, '', ''         
    FROM arhAttrParent t1 where t1.EnBrief2  = @EntityBrief AND t1.Attr_Type < 3 and  t1.Attr_Kind = 1 
  END

  DECLARE @EntityIDStr varchar(50)
  SELECT TOP 1 @EntityIDStr = EntityID FROM @Par
  UPDATE @Par SET ParValue = '''' + REPLACE(ParValue, '''', '''''') + '''', Value_ID = '''' + REPLACE(Value_ID, '''', '''''') + '''' 
  WHERE DATA_TYPE = 'varchar' OR DATA_TYPE = 'datetime' AND SUBSTRING(ParValue, 1, 1) <> '''' 
  
  
  --UPDATE @Par SET ParValue = 'NULL' WHERE DATA_TYPE = 'int' AND ParValue = '' --, Value_ID = 'NULL' 

  SELECT
    ROW_NUMBER() OVER(ORDER BY LevelTop DESC, Table_Type) Pos,
    SQLSelect,
    SQLInsert,
    SQLUpdate, 
    SQLDelete,
    SQLInsertSD,

    SQLSelect   AS SQLSelect_Value,   --Для кэширования
    SQLInsert   AS SQLInsert_Value,   --Для кэширования
    SQLUpdate   AS SQLUpdate_Value,   --Для кэширования
    SQLDelete   AS SQLDelete_Value,   --Для кэширования
    SQLInsertSD AS SQLInsertSD_Value, --Для кэширования
    
    EntityID, 
    Table_Name, 
    Table_Type, 
    Table_IDFieldName, 
    LevelTop,
    LevelTop1,
    LevelTop2,
    IDENTITYStr,
    SUBSTRING((SELECT ', ' + Table_Field + ' AS "' + ParName + '"' FROM @Par t2 WHERE t2.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr0,
    SUBSTRING((SELECT ', ' + Table_Field + ' = ' + ParValue FROM @Par t2 WHERE t2.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr1,
    SUBSTRING((SELECT ', ' + Table_Field FROM @Par t3 WHERE t3.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr2,
    SUBSTRING((SELECT ', ' + ParValue    FROM @Par t4 WHERE t4.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr3,
    (CASE WHEN Table_Type = 2 THEN ' AND StateDate = ' + @StateDate ELSE '' END) AS StateDate1,
    (CASE WHEN Table_Type = 2 THEN 'StateDate,'      ELSE '' END) AS StateDate2,
    (CASE WHEN Table_Type = 2 THEN @StateDate + ','  ELSE '' END) AS StateDate3,
    --Для поддержки кэширования
    SUBSTRING((SELECT ', ' + Table_Field + ' = ' + t5.Value_ID FROM @Par t5 WHERE t5.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr1_Value,
    SUBSTRING((SELECT ', ' + t6.Value_ID FROM @Par t6 WHERE t6.Table_Name = t1.Table_Name FOR XML PATH('')), 3, 10000000000) as ParamStr3_Value,
    (CASE WHEN Table_Type = 2 THEN ' AND StateDate = @StateDate' ELSE '' END) AS StateDate1_Value,
    (CASE WHEN Table_Type = 2 THEN '@StateDate, '  ELSE '' END) AS StateDate3_Value
    
  INTO #Par2   
  FROM @Par t1
  GROUP BY
    SQLSelect,
    SQLInsert,
    SQLUpdate,
    SQLDelete,
    SQLInsertSD, 
    EntityID, 
    Table_Name, 
    Table_Type, 
    Table_IDFieldName, 
    LevelTop,
    LevelTop1,
    LevelTop2,
    IDENTITYStr
                
  UPDATE #Par2 SET IDENTITYStr = ';' + CHAR(10) + 'SET @ID = SCOPE_IDENTITY() ' WHERE Pos = 1 --LevelTop = 0 AND Table_Type = 1--
  UPDATE #Par2 SET LevelTop1 = Table_IDFieldName + ', ', LevelTop2 = '@ID, '    WHERE Pos <> 1  

  --Получение запросов (SQLInsertSD) на вставку историчных состояний в историчные таблицы при операции UPDATE.
  --При UPDATE мы не апдейтим ближайшее историчное состояние, а создаем новое, если такого нет.  
  UPDATE #Par2 SET  
    SQLSelect = 'SELECT ' + ParamStr0 + ' FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr,
    SQLInsert = 'INSERT INTO ' + Table_Name + ' (' + LevelTop1 + 'EntityID, ' + StateDate2 + ParamStr2 + ') VALUES (' + LevelTop2 + @EntityIDStr + ', ' + StateDate3 + ParamStr3 + ')' + IDENTITYStr,    
    SQLUpdate = 'UPDATE ' + Table_Name + ' SET ' + ParamStr1 + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr + ' AND EntityID = ' + @EntityIDStr + StateDate1,
    SQLDelete = 'DELETE FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr,
    SQLInsertSD = (CASE WHEN Table_Type = 2 THEN 'INSERT INTO ' + Table_Name + ' (' + Table_IDFieldName + ', EntityID, StateDate) SELECT ' + @ObjectIDStr + ', ' + @EntityIDStr + ', ' + @StateDate + ' WHERE NOT EXISTS(SELECT 1 FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr + ' AND EntityID = ' + @EntityIDStr + ' AND StateDate = ' + @StateDate + ')' ELSE '' END)
    --Для кэширования
    ,SQLSelect_Value = 'SELECT ' + ParamStr0 + ' FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = @ObjectID',
    SQLInsert_Value = 'INSERT INTO ' + Table_Name + ' (' + LevelTop1 + 'EntityID, ' + StateDate2 + ParamStr2 + ') VALUES (' + LevelTop2 + @EntityIDStr + ', ' + StateDate3_Value + ParamStr3_Value + ')' + IDENTITYStr,    
    SQLUpdate_Value = 'UPDATE ' + Table_Name + ' SET ' + ParamStr1_Value + ' WHERE ' + Table_IDFieldName + ' = @ObjectID AND EntityID = ' + @EntityIDStr + StateDate1_Value,
    SQLDelete_Value = 'DELETE FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = @ObjectID',
    SQLInsertSD_Value = (CASE WHEN Table_Type = 2 THEN 'INSERT INTO ' + Table_Name + ' (' + Table_IDFieldName + ', EntityID, StateDate) SELECT @ObjectID, ' + @EntityIDStr + ', @StateDate WHERE NOT EXISTS(SELECT 1 FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = @ObjectID AND EntityID = ' + @EntityIDStr + ' AND StateDate = @StateDate)' ELSE '' END)
    
  --Можно такой вариант вместо того, котрый выше, через EXISTS
  --SQLInsertSD =
  -- 'MERGE ' + Table_Name + ' AS T_Base ' + CHAR(10) + 
	-- 'USING (SELECT ' + @EntityIDStr + ' AS EntityID, ' + @ObjectIDStr + ' AS ID, ' + @StateDate + ' AS StateDate) AS T_Source ' + CHAR(10) +   
	-- 'ON (T_Base.' + Table_IDFieldName + ' = T_Source.' + Table_IDFieldName + ') AND (T_Base.EntityID = T_Source.EntityID) AND (T_Base.StateDate = T_Source.StateDate) ' + CHAR(10) + 
	-- 'WHEN NOT MATCHED THEN ' + CHAR(10) + 
	-- 'INSERT (EntityID, ' + Table_IDFieldName + ', StateDate) VALUES (' + @EntityIDStr + ', ' + @ObjectIDStr + ', ' + @StateDate + '); ' + CHAR(10)

  --Сборка запросов. Обычные и для кэширования.
  DECLARE @TextError varchar(200) = 'SELECT 0 AS ID, (''Error '' + CONVERT(VARCHAR, ERROR_NUMBER()) + '':'' + ERROR_MESSAGE()) AS ErrorText'
  DECLARE @SQLInsertSD varchar (max) = ''
  IF (@Operation = 'UPDATE') 
  BEGIN
    SET @SQLInsertSD = (SELECT SQLInsertSD + '; ' + CHAR(10) FROM #Par2 t2 WHERE Table_Type = 2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) 
    SET @SQLText = ISNULL(@SQLInsertSD, '') + (SELECT SQLUpdate + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT 1 AS ID '
  END
  IF (@Operation = 'SELECT') SET @SQLText = (SELECT SQLSelect  + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10)
  IF (@Operation = 'INSERT') SET @SQLText = 'DECLARE @ID int ' + CHAR(10) + (SELECT SQLInsert + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop DESC, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT @ID AS ID'  
  IF (@Operation = 'DELETE') SET @SQLText = (SELECT SQLDelete + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT 1 AS ID '           
  SET @SQLText = 'BEGIN TRY BEGIN TRAN ' + CHAR(10) + CHAR(10) + @SQLText + CHAR(10) + 'COMMIT TRAN END TRY BEGIN CATCH ROLLBACK TRAN SELECT 0 AS ID, (''Error '' + CONVERT(VARCHAR, ERROR_NUMBER()) + '':'' + ERROR_MESSAGE()) AS ErrorText END CATCH '
  
  --Для кэширования
  DECLARE @SQLInsertSD_Value varchar (max) = ''
  IF (@Operation = 'UPDATE') 
  BEGIN
    SET @SQLInsertSD = (SELECT SQLInsertSD_Value + '; ' + CHAR(10) FROM #Par2 t2 WHERE Table_Type = 2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) 
    SET @SQLText_Value = ISNULL(@SQLInsertSD_Value, '') + (SELECT SQLUpdate_Value + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT 1 AS ID '
  END
  IF (@Operation = 'SELECT') SET @SQLText_Value = (SELECT SQLSelect_Value  + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10)
  IF (@Operation = 'INSERT') SET @SQLText_Value = 'DECLARE @ID int ' + CHAR(10) + (SELECT SQLInsert_Value + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop DESC, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT @ID AS ID'  
  IF (@Operation = 'DELETE') SET @SQLText_Value = (SELECT SQLDelete_Value + '; ' + CHAR(10) FROM #Par2 t2 ORDER BY LevelTop, Table_Type FOR XML PATH('')) + CHAR(10) + 'SELECT 1 AS ID '           
  SET @SQLText_Value = 'BEGIN TRY BEGIN TRAN ' + CHAR(10) + CHAR(10) + @SQLText_Value + CHAR(10) + 'COMMIT TRAN END TRY BEGIN CATCH ROLLBACK TRAN SELECT 0 AS ID, (''Error '' + CONVERT(VARCHAR, ERROR_NUMBER()) + '':'' + ERROR_MESSAGE()) AS ErrorText END CATCH '
  
  IF (@SQLText_Value IS NOT NULL)
    INSERT INTO arhQueryCache (EntityID, DateCreate, EntityBrief, Operation, AttrList, SQLText) VALUES (101, GETDATE(), @EntityBrief, @Operation, @AttrList, @SQLText_Value)

  --@Mode = 0 - Рабочий режим. Все запросы выполняются. Запрос берётся из кэша или формируется заново, если в кэше нет такого.
  --@Mode = 1 - Рабочий режим. Все запросы выполняются. Кэш не используется, выполняется всегда запрос сформированный заново.
  IF (@Mode = 0) OR (@Mode = 1)
  BEGIN
    EXEC (@SQLText)
    RETURN
  END
  
  --@Mode = 2 - Запросы не выполняются. Возврашается либо кешированный запрос, либо сформированный заново, если кэшированого нет.
  --@Mode = 3 - Запросы не выполняются. Кэш не используется, возвращается всегда сформированный заново запрос.
  IF (@Mode = 2) OR (@Mode = 3)
  BEGIN
    SELECT @SQLText AS SQLText
    RETURN
  END  

  --@Mode = 4 - Запросы не выполняются. Кэш не используется, возвращается список таблиц и другася отладочная информация.
  IF (@Mode = 4)
  BEGIN
    SELECT @SQLText AS SQLText
    SELECT @SQLText_Value AS SQLText_Value
    SELECT * FROM @Par ORDER BY LevelTop
    SELECT * FROM #Par2
    --SELECT @SQLInsertSD    
    --DROP TABLE dbo.arhQueryCache 
    --CREATE TABLE dbo.arhQueryCache 
    --(ID int, EntityID int, DateCreate datetime, DateChange datetime, UserCreateID int, UserChangeID int, EntityBrief int, AttrList varchar(max), 
    --Operation varchar(20), SQLText varchar(max))
    --EXEC (@SQL)
    --delete from arhQueryCache 
    --select * from arhQueryCache     
  END
END



