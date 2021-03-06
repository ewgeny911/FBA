USE [DIASOFT_test2]
GO
/****** Object:  StoredProcedure [dbo].[spen_SaveObject]    Script Date: 19.12.2018 13:22:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- 
/*
EXEC spen_SaveObject3 'INSERT', 10, 'Застрахованный',  '19000101 00:00:00.000', 
'ДатаНачала', '20150101 00:00:00.000',  
'Примечание', 'вгвв',
'ДатаОкончания', '20150101 00:00:00.000', 
'Регион',  81,  
'ФЛ',      1858557,  
'Полис',   85563,  
'Филиал', 'Филиал № 7806 Банка ВТБ 24 (закрытое акционерное общество) в г. Санкт-Петербурге' 
*/    

/*
EXEC spen_SaveObject 'DELETE', 134, 'ДогСтрах',  '19000101 00:00:00.000', 
'ДатаНачала', '20150101 00:00:00.000',  
'ДатаОкончания', '20150101 00:00:00.000',
'Ремарка', 'вгвв', 
'ДатаПодписания', '20150101 00:00:00.000',
'Номер',       'A126077-0045445', 
'ВидСтрах',     2,  
'Организация',  3,  
'Примечание', 'вгвв', 
'ТипДогСтрах', 6
*/


/*
EXEC spen_SaveObject 'INSERT', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', 'ааа',  
'Симптом', 'ббб',
'ЛПУ', 'ввв', 
'ПринявшийВызов',  'ггг'
*/ 

/*
EXEC spen_SaveObject4 'SELECT', 10, 'ЗаявкаСМП',  '19000101 00:00:00.000', 
'СогласованиеУслуг', '',  
'Симптом', '',
'ЛПУ', '', 
'ПринявшийВызов',  ''
*/ 


/*
EXEC spen_SaveObject4 'SELECT', 134, 'ДогСтрах',  '19000101 00:00:00.000', 
'ДатаНачала',     '',  
'ДатаОкончания',  '',
'Ремарка',        '', 
'ДатаПодписания', '',
'Номер',          '', 
'ВидСтрах',       '',  
'Организация',    '', 
'Примечание',     '', 
'ТипДогСтрах',    ''
*/
      

ALTER PROCEDURE [dbo].[spen_SaveObject] (
   @Operation VARCHAR(100)
  ,@ObjectID int
  ,@EntityBrief VARCHAR(100)
  ,@StateDate VARCHAR(100) = '1900-01-01 00:00:00.000'
  ,@ParName1 VARCHAR(100)  = NULL, @ParValue1 VARCHAR(MAX)  = NULL         
  ,@ParName2 VARCHAR(100)  = NULL, @ParValue2 VARCHAR(MAX)  = NULL  
  ,@ParName3 VARCHAR(100)  = NULL, @ParValue3 VARCHAR(MAX)  = NULL  
  ,@ParName4 VARCHAR(100)  = NULL, @ParValue4 VARCHAR(MAX)  = NULL  
  ,@ParName5 VARCHAR(100)  = NULL, @ParValue5 VARCHAR(MAX)  = NULL  
  ,@ParName6 VARCHAR(100)  = NULL, @ParValue6 VARCHAR(MAX)  = NULL  
  ,@ParName7 VARCHAR(100)  = NULL, @ParValue7 VARCHAR(MAX)  = NULL  
  ,@ParName8 VARCHAR(100)  = NULL, @ParValue8 VARCHAR(MAX)  = NULL  
  ,@ParName9 VARCHAR(100)  = NULL, @ParValue9 VARCHAR(MAX)  = NULL  
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
  ,@ParName25 VARCHAR(100) = NULL, @ParValue25 VARCHAR(MAX) = NULL   
) AS
BEGIN
  SET @StateDate = '''' + @StateDate + ''''
  SET @Operation = UPPER(@Operation)

  DECLARE @SQL VARCHAR(MAX) = ''
  DECLARE @ObjectIDStr VARCHAR(MAX) = CAST(@ObjectID AS VARCHAR(100))

  DECLARE @Par TABLE (ParName VARCHAR(100), ParValue VARCHAR(MAX), 
    SQLSelect VARCHAR(MAX),
    SQLInsert VARCHAR(MAX),
    SQLUpdate VARCHAR(MAX),
    SQLDelete VARCHAR(MAX),
    EntityID int, Attr_Brief VARCHAR(100), Table_Name VARCHAR(100), Table_Type VARCHAR(100), 
    Table_Field VARCHAR(100), Table_IDFieldName VARCHAR(100), LevelTop int, 
    LevelTop1 VARCHAR(100), LevelTop2 VARCHAR(100), IDENTITYStr VARCHAR(100),
    DATA_TYPE VARCHAR(100),
    CHARACTER_MAXIMUM_LENGTH int,
    NUMERIC_PRECISION int,
    NUMERIC_PRECISION_RADIX int  
  )
  
  IF (@ParName1  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName1,  @ParValue1)
  IF (@ParName2  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName2,  @ParValue2)
  IF (@ParName3  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName3,  @ParValue3)
  IF (@ParName4  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName4,  @ParValue4)
  IF (@ParName5  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName5,  @ParValue5)
  IF (@ParName6  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName6,  @ParValue6)
  IF (@ParName7  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName7,  @ParValue7)
  IF (@ParName8  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName8,  @ParValue8)
  IF (@ParName9  IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName9,  @ParValue9)
  IF (@ParName10 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName10, @ParValue10)
  IF (@ParName11 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName11, @ParValue11)
  IF (@ParName12 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName12, @ParValue12)
  IF (@ParName13 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName13, @ParValue12)
  IF (@ParName14 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName14, @ParValue12)
  IF (@ParName15 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName15, @ParValue12)
  IF (@ParName16 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName16, @ParValue12)
  IF (@ParName17 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName17, @ParValue12)
  IF (@ParName18 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName18, @ParValue12)
  IF (@ParName19 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName19, @ParValue12)
  IF (@ParName20 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName20, @ParValue12)
  IF (@ParName21 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName21, @ParValue12)
  IF (@ParName22 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName22, @ParValue12)
  IF (@ParName23 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName23, @ParValue12)
  IF (@ParName24 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName24, @ParValue12)
  IF (@ParName25 IS NOT NULL) INSERT INTO  @Par (ParName, ParValue) VALUES (@ParName25, @ParValue12)

  IF (@Operation = '')
  BEGIN
    UPDATE @Par SET 
      Attr_Brief               = t1.Attr_Name, 
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

  --select * from arhAttrParent  where EnBrief2  = 'ДогСтрах'


  UPDATE @Par SET ParValue = '''' + REPLACE(ParValue, '''', '''''') + '''' WHERE DATA_TYPE = 'varchar' OR DATA_TYPE = 'datetime'
        
  SELECT
    ROW_NUMBER() OVER(ORDER BY LevelTop DESC, Table_Type) Pos,
    SQLSelect,
    SQLInsert,
    SQLUpdate, 
    SQLDelete,
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
    (CASE WHEN Table_Type = 2 THEN @StateDate + ','  ELSE '' END) AS StateDate3
  INTO #Par2   
  FROM @Par t1
  GROUP BY
    SQLSelect,
    SQLInsert,
    SQLUpdate,
    SQLDelete, 
    EntityID, 
    Table_Name, 
    Table_Type, 
    Table_IDFieldName, 
    LevelTop,
    LevelTop1,
    LevelTop2,
    IDENTITYStr
                
  UPDATE #Par2 SET IDENTITYStr = ';' + CHAR(10) + 'SET @ID = SCOPE_IDENTITY() ' WHERE Pos = 1
  UPDATE #Par2 SET LevelTop1 = Table_IDFieldName + ', ', 
                   LevelTop2 = '@ID, '   WHERE Pos <> 1  

  UPDATE #Par2 SET  
    SQLSelect = 'SELECT ' + ParamStr0 + ' FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr,
    SQLInsert = 'INSERT INTO ' + Table_Name + '(' + LevelTop1 + 'EntityID, ' + StateDate2 + ParamStr2 + ') VALUES (' + LevelTop2 + CAST(EntityID AS VARCHAR(100)) + ', ' + StateDate3 + ParamStr3 + ') ' + IDENTITYStr,    
    SQLUpdate = 'UPDATE ' + Table_Name + ' SET ' + ParamStr1 + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr + StateDate1,
    SQLDelete = 'DELETE FROM ' + Table_Name + ' WHERE ' + Table_IDFieldName + ' = ' + @ObjectIDStr

  IF (@Operation = 'SELECT') SET @SQL = (SELECT SQLSelect  + '; ' + CHAR(10) FROM #Par2 t2 FOR XML PATH('')) + CHAR(10)
  IF (@Operation = 'INSERT') SET @SQL = ' DECLARE @ID int ' + CHAR(10) + (SELECT SQLInsert + '; ' + CHAR(10) FROM #Par2 t2 FOR XML PATH('')) + CHAR(10) + ' SELECT @ID AS ID '
  IF (@Operation = 'UPDATE') SET @SQL = (SELECT SQLUpdate  + '; ' + CHAR(10) FROM #Par2 t2 FOR XML PATH('')) + CHAR(10) + ' SELECT 1 AS ID '
  IF (@Operation = 'DELETE') SET @SQL = (SELECT SQLDelete  + '; ' + CHAR(10) FROM #Par2 t2 FOR XML PATH('')) + CHAR(10) + ' SELECT 1 AS ID '
           
  SET @SQL = ' BEGIN TRY BEGIN TRAN ' + CHAR(10) + @SQL + CHAR(10) + ' COMMIT TRAN END TRY BEGIN CATCH ROLLBACK TRAN SELECT 0 AS ID END CATCH '
  
  --EXEC (@SQL)
  SELECT @SQL as SQLText
  SELECT * FROM #Par2              
  --select * from arhAttrParent where EnChildID= 1694
END







