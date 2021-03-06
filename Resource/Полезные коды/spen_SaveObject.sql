USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_SaveObject]    Script Date: 10.01.2018 10:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- exec spen_SaveObject 0, 'Застрахованный',      'ДатаНачала', '20150101 00:00:00.000', '',    'Примечание', 'в  г  вв', '' 
-- exec spen_SaveObject 0, 'ДокНаИсхОплату',  'ДатаДок', '20150101 00:00:00.000', '',  'Примечание', 'вгвв', '',  'ДогСтрах', 12345, ''  

ALTER PROCEDURE [dbo].[spen_SaveObject] (
  @ID int, @EnName VARCHAR(100)
  ,@ParName1 VARCHAR(100),         @ParValue1 sql_variant,         @ParSD1 VARCHAR(100)
  ,@ParName2 VARCHAR(100) = NULL,  @ParValue2 sql_variant = NULL,  @ParSD2 VARCHAR(100) = NULL
  ,@ParName3 VARCHAR(100) = NULL,  @ParValue3 sql_variant = NULL,  @ParSD3 VARCHAR(100) = NULL
  ,@ParName4 VARCHAR(100) = NULL,  @ParValue4 sql_variant = NULL,  @ParSD4 VARCHAR(100) = NULL
  ,@ParName5 VARCHAR(100) = NULL,  @ParValue5 sql_variant = NULL,  @ParSD5 VARCHAR(100) = NULL
  ,@ParName6 VARCHAR(100) = NULL,  @ParValue6 sql_variant = NULL,  @ParSD6 VARCHAR(100) = NULL
  ,@ParName7 VARCHAR(100) = NULL,  @ParValue7 sql_variant = NULL,  @ParSD7 VARCHAR(100) = NULL  
  ,@ParName8 VARCHAR(100) = NULL,  @ParValue8 sql_variant = NULL,  @ParSD8 VARCHAR(100) = NULL 
  ,@ParName9 VARCHAR(100) = NULL,  @ParValue9 sql_variant = NULL,  @ParSD9 VARCHAR(100) = NULL 
  ,@ParName10 VARCHAR(100) = NULL, @ParValue10 sql_variant = NULL, @ParSD10 VARCHAR(100) = NULL 
  ,@ParName11 VARCHAR(100) = NULL, @ParValue11 sql_variant = NULL, @ParSD11 VARCHAR(100) = NULL 
  ,@ParName12 VARCHAR(100) = NULL, @ParValue12 sql_variant = NULL, @ParSD12 VARCHAR(100) = NULL 
) AS

/*
  DROP TABLE #Par
  DROP TABLE #TempAttr
  DROP TABLE #TreeTempTable
  DROP TABLE #Res 
*/

CREATE TABLE #Par (EnName VARCHAR(100), ParName VARCHAR(100), ParValue sql_variant, ParSD VARCHAR(100))
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName1, @ParValue1, @ParSD1)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName2, @ParValue2, @ParSD2)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName3, @ParValue3, @ParSD3)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName4, @ParValue4, @ParSD4)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName5, @ParValue5, @ParSD5)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName6, @ParValue6, @ParSD6)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName7, @ParValue7, @ParSD7)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName8, @ParValue8, @ParSD7)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName9, @ParValue9, @ParSD7)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName10, @ParValue10, @ParSD7)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName11, @ParValue11, @ParSD7)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES (@EnName, @ParName12, @ParValue12, @ParSD7)
DELETE FROM #Par WHERE ParName is NULL

/*
truncate table #Par
DECLARE @dt datetime
DECLARE @EnName varchar(100)
SET @dt = GETDATE()
SET @EnName = (select top 1 EnName from #Par) 
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES ('ДогСтрах', 'Номер', '11-22-33', NULL)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES ('ДогСтрах', 'ДатаНачала', '01.01.2013', '01.01.2000')
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES ('ДогСтрах', 'ДатаОкончания', '01.01.2014', '01.01.2000')
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES ('ДогСтрах', 'ТребуетВыгрузки', '1', NULL)
INSERT INTO  #Par (EnName, ParName, ParValue, ParSD) VALUES ('ДогСтрах', 'ВалютаОплаты', '1', NULL)
SELECT * FROM #Par
*/


--DECLARE @EntityName VARCHAR(100)
--SET @EntityName = 'ДогСтрах'
--Здесь получаем список атрибутов, котрые заданы во входящих параметрах, по каждому атрибуту: ИД Атрибута, 
--Сокр атрибута, Сокр сущности, ИД сущности
--Имя таблицы, Тип таблицы (историчная или нет), Ключевое поле таблицы (IDO), Поле таблицы.
SELECT AttrID, AttrName, EntityBrief, EntityID, TableName, TableType, IDO, FieldName INTO #TempAttr FROM
(
SELECT
  Distinct
  EOT_1.AttributeID AttrID,
  EOT_1.Brief "AttrName",
  EOT_4.Brief "EntityBrief",
  EOT_4.ID "EntityID",
  EOT_5.Name "TableName",
  EOT_5.Type "TableType",
  EOT_5.IDFieldName "IDO",
  EOT_1.FieldName "FieldName"
FROM
  enAttribute EOT_1
  Left Outer Join enTable EOT_5
    On EOT_5.TableID = EOT_1.TableID
  Left Outer Join enEntity EOT_4
    On EOT_4.ID = EOT_1.AttributeEntityID
WHERE
  EOT_4.Brief = (select top 1 EnName from #Par)  --@EnName 
  and EOT_1.Brief IN (SELECT ParName FROM #Par) and EOT_1.Type IN (1 , 2)
Union
SELECT
  Distinct
  EOT_8.AttributeID "AttrID",
  EOT_8.Brief "AttrName",
  EOT_9.Brief "EntityBrief",
  EOT_9.ID "EntityID",
  EOT_10.Name "TableName",
  EOT_10.Type "TableType",
  EOT_10.IDFieldName "IDO",
  EOT_8.FieldName "FieldName"
FROM
  enAttribute EOT_2
  Left Outer Join enEntity EOT_6
    On EOT_6.ID = EOT_2.AttributeEntityID
  Left Outer Join enEntity EOT_7
    On EOT_7.ID = EOT_6.ParentID
  Left Outer Join enAttribute EOT_8
    On EOT_8.AttributeEntityID = EOT_7.ID
  Left Outer Join enTable EOT_10
    On EOT_10.TableID = EOT_8.TableID
  Left Outer Join enEntity EOT_9
    On EOT_9.ID = EOT_8.AttributeEntityID
WHERE
  EOT_6.Brief = (select top 1 EnName from #Par)  --@EnName 
  and EOT_7.ID is not null and EOT_8.Brief IN (SELECT ParName FROM #Par) and EOT_8.Type IN (1 , 2)
Union
SELECT
  Distinct
  EOT_14.AttributeID "AttrID",
  EOT_14.Brief "AttrName",
  EOT_15.Brief "EntityBrief",
  EOT_15.ID "EntityID",
  EOT_16.Name "TableName",
  EOT_16.Type "TableType",
  EOT_16.IDFieldName "IDO",
  EOT_14.FieldName "FieldName"
FROM
  enAttribute EOT_3
  Left Outer Join enEntity EOT_11
    On EOT_11.ID = EOT_3.AttributeEntityID
  Left Outer Join enEntity EOT_12
    On EOT_12.ID = EOT_11.ParentID
  Left Outer Join enEntity EOT_13
    On EOT_13.ID = EOT_12.ParentID
  Left Outer Join enAttribute EOT_14
    On EOT_14.AttributeEntityID = EOT_13.ID
  Left Outer Join enTable EOT_16
    On EOT_16.TableID = EOT_14.TableID
  Left Outer Join enEntity EOT_15
    On EOT_15.ID = EOT_14.AttributeEntityID
WHERE
  EOT_11.Brief = (select top 1 EnName from #Par)  --@EnName 
    and EOT_13.ID is not null and EOT_14.Brief IN (SELECT ParName FROM #Par) and EOT_14.Type IN (1 , 2)
 ) t1 
--SELECT * FROM  #TempAttr 
   

CREATE TABLE #TreeTempTable(EntityID int, ParentID int, EntityBrief VARCHAR(100), TableType int, TableName VARCHAR(100), IDO VARCHAR(100));

--Ищем предков сущности.
--Здесь получаем информацию по сущностям, чтобы определить иерархию наследовния сущностей.
--т.к. при записи потомка в таблицу родителя вс равно ОБЯЗАТЕЛЬНО нужно втавлять запись.
--Колонки: ИДСущности, Имя таблицы, Сокр сущности, Тип таблицы (историчная или нет), Имя таблицы, Ключевое поле таблицы (IDO)
WITH Parents(ID, ParentID, Brief, Type, Name, IDO) as
  (
    SELECT EOT_1.ID, EOT_1.ParentID, EOT_1.Brief, EOT_2.Type, EOT_2.Name, EOT_2.IDFieldName
    FROM enEntity EOT_1
      inner Join enTable EOT_2 On EOT_2.TableEntityID = EOT_1.ID
    WHERE EOT_1.Brief = (select top 1 EnName from #Par)
    and EOT_2.Type = 1 
    
    UNION ALL
    SELECT EOT_1.ID, EOT_1.ParentID, EOT_1.Brief, EOT_2.Type, EOT_2.Name, EOT_2.IDFieldName
    FROM enEntity EOT_1
      inner join Parents p on p.ParentID = EOT_1.ID
      inner Join enTable EOT_2 On EOT_2.TableEntityID = EOT_1.ID
    WHERE EOT_2.Type = 1
  )
INSERT INTO #TreeTempTable(EntityID, ParentID, EntityBrief, TableType, TableName, IDO) SELECT ID, ParentID, Brief, Type, Name, IDO FROM Parents --WHERE ParentID is not NULL;
   
  --SELECT * FROM #TempAttr order by EntityID
  --SELECT * FROM #TreeTempTable order by EntityID
  --SELECT * FROM #Res 
 --А здесь соединяем информацию по атрибутам, с информацией по вложенности сущностей. В результате получаем таблицу #Res, которая по сути является результатом. 
 --В ней содержится вся информация чтобы создать новый объект. Чтобы создать объект нужно ПРОЙТИСЬ ПО НЕЙ ЦИКЛОМ. 
 --От предков до последней сущности - потомка.
 --Колонки: ИДСущности, Имя таблицы, Тип таблицы (историчная или нет), Ключевое поле таблицы (IDO), ИД Предка сущности (ParentID),
 --Имя атрибута, Имя поля в таблице, Записываемое значение, Записываемое значение в виде строки (с кавычками), Дата состояния (это только для историчных атрибутов),
 --Дата состояния в виде строки (с кавычками), Тип поля. 
SELECT
  ISNull(t1.EntityID, t2.EntityID)   as EntityID,
  ISNull(t1.TableName, t2.TableName) as TableName,
  ISNull(t1.TableType, t2.TableType) as TableType, 
  ISNull(t1.IDO, t2.IDO)             as IDO,
  ISNull(t2.ParentID, t3.ParentID)   as ParentID,
  t1.AttrName, 
  t1.FieldName
INTO #Res  
FROM #TempAttr t1
FULL OUTER JOIN #TreeTempTable t2 on t1.TableName = t2.TableName 
  LEFT JOIN #TreeTempTable t3 on t3.EntityID = t1.EntityID
ORDER BY ParentID, TableName
   
  
ALTER TABLE #Res add ParValue    sql_variant
ALTER TABLE #Res add ParVALUEStr VARCHAR(max)
ALTER TABLE #Res add ParSD       VARCHAR(100)
ALTER TABLE #Res add ParSDStr    VARCHAR(100)
ALTER TABLE #Res add TypeData    VARCHAR(100)
ALTER TABLE #Res add SQLStr      VARCHAR(max)
ALTER TABLE #Res add ParID       int
  
UPDATE #Res SET #Res.ParValue = #Par.ParValue, #Res.ParSD = #Par.ParSD FROM #Par WHERE #Res.AttrName = #Par.ParName 
UPDATE #Res SET #Res.TypeData = t1.DATA_TYPE FROM information_schema.COLUMNS t1 WHERE t1.TABLE_NAME = #Res.TableName and t1.COLUMN_NAME = #Res.FieldName
  
--Здесь сначала переводим строку во время, а затем время в определенном формате в строку.
UPDATE #Res SET ParValueStr = '''' + CONVERT(VARCHAR(100), CONVERT(datetime, ParValue, 121), 121) + '''' WHERE (TypeData = 'datetime')
UPDATE #Res SET ParSDStr    = '''' + CONVERT(VARCHAR(100), CONVERT(datetime, ParSD, 121), 121) + ''''
  
--Для типа строки и времени добавляем кавычки
UPDATE #Res SET ParValueStr = '''' + CAST(ParValue AS VARCHAR(8000)) + ''''  WHERE (TypeData = 'varchar')
  
--Для остальных типов оставляем как есть.
UPDATE #Res SET ParValueStr = CAST(ParValue AS VARCHAR(8000))  WHERE (TypeData <> 'varchar') and (TypeData <> 'datetime')
  
--Дату состояния
UPDATE #Res SET ParSDStr   = '''' + CONVERT(varchar(30), GETDATE(), 121) + '''' where ParSDStr is null
--SELECT * FROM #Par
--SELECT * FROM #Res 


--==================================================================
--CREATE TABLE #SQL (SQLNum int, SQLStr VARCHAR(max))
--TRUNCATE TABLE #SQL
--UPDATE #Res SET IDO = 'ID' WHERE IDO = '_ID'
 
DECLARE Res Cursor dynamic For SELECT AttrName, TableName, IDO, FieldName, ParentID, TableType, ParValueStr, ParSDStr, TypeData, EntityID FROM #Res order by ParentID, TableType
OPEN Res
 
DECLARE @AttrName     VARCHAR(100)
DECLARE @TableName    VARCHAR(100)
DECLARE @IDO          VARCHAR(100)
DECLARE @CurIDO       VARCHAR(100)
DECLARE @FieldName    VARCHAR(100)
DECLARE @ParentID     int
DECLARE @TableType    int
DECLARE @ParValueStr  VARCHAR(max)
DECLARE @ParSDStr     VARCHAR(100)
DECLARE @TypeData     VARCHAR(100)
DECLARE @EntityID     VARCHAR(100)
  
DECLARE @SQLNum       int
DECLARE @SQLStr       VARCHAR(max)
DECLARE @SQLStrAll    VARCHAR(max)
DECLARE @AttrStr      VARCHAR(max)
DECLARE @ValStr       VARCHAR(max)
DECLARE @CurTable     VARCHAR(100)
DECLARE @CurTableType int
DECLARE @TempVALUES   VARCHAR(100)
DECLARE @ParID        int
DECLARE @CurEntity    int
DECLARE @IDStr        VARCHAR(100)
DECLARE @CurParSDStr  VARCHAR(100)
  
SET @SQLNum    = 0
SET @SQLStr    = ''
SET @AttrStr   = ''
SET @ValStr    = ''
SET @CurEntity = 0
SET @CurIDO    = ''
SET @ParSDStr  = ''
SET @ParID     = 0
SET @CurTableType = 0
SET @CurParSDStr = ''
SET @IDStr = CAST(@ID AS VARCHAR(100))  
 
 
--Это если INSERT нового объекта
IF @ID = 0 
BEGIN
  SET @SQLStrAll = 'DECLARE @ParID int ' + CHAR(13) + CHAR(10)
  FETCH FROM Res INTO @AttrName, @TableName, @IDO, @FieldName, @ParentID, @TableType, @ParValueStr, @ParSDStr, @TypeData, @EntityID 
  SET @CurTable = @TableName
  WHILE @@FETCH_Status = 0
  BEGIN  
    IF @CurTable <> @TableName 
    BEGIN
      SET @SQLNum = @SQLNum + 1
     
      IF @CurTableType = 2 
      BEGIN
        SET @AttrStr = @AttrStr + ', ' + 'StateDate'
        SET @ValStr  = @ValStr  + ', ' + @CurParSDStr
      END         
      
      --Когда у нас есть что вставлять - есть какие либо значения атрибутов.
      IF @AttrStr is not NULL 
      BEGIN
        IF @ParID > 0 
        BEGIN
          SET @AttrStr = @AttrStr + ',' + CAST(@CurIDO AS VARCHAR(100))  
          SET @ValStr  = @ValStr  + ', @ParID' 
        END   
        SET @SQLStr = 'INSERT INTO ' + @CurTable + ' (EntityID' + @AttrStr + ') VALUES (' + CAST(@CurEntity AS VARCHAR(100)) + @ValStr + ')'   
      END
      
      --Если значений атрибутов нет - то вставляем в таблицу пустышку. Это может быть например когда мы сохраняем атрибут потомка, а нам для сохранения этого атрибута нужно 
      --вставить запись в таблицу родителя. Этот INSERT вставляет в таблицу родителя (может быть несколько родителей)
      IF @AttrStr is NULL 
      BEGIN
        IF @ParID > 0  
          SET @SQLStr =  'INSERT INTO ' + @CurTable + ' (EntityID, ' + @CurIDO + ') VALUES (' + CAST(@CurEntity AS VARCHAR(100)) + ', @ParID)'  
        ELSE
          SET @SQLStr =  'INSERT INTO ' + @CurTable + ' (EntityID) VALUES (' + CAST(@CurEntity AS VARCHAR(100)) + ')'  
      END     
     
      --Для теста:                                    
      --UPDATE #Res SET SQLStr = @SQLStr WHERE TableName = @CurTable
      IF @ParID = 0 
      BEGIN             
        SET @SQLStr = @SQLStr + CHAR(13) + CHAR(10) + 'SELECT @ParID = SCOPE_IDENTITY()' 
        --Для теста:
        SET @ParID = 1
        --UPDATE #Res SET ParID = @ParID 
      END
     
      --Получаем ИДОбъекта - @ParID
      SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + @SQLStr  
      SET @CurTable  = @TableName         
      SET @AttrStr   = ''
      SET @ValStr    = ''             
    END 
    
    IF @CurTable = @TableName 
    BEGIN
      SET @CurEntity    = @EntityID
      SET @AttrStr      = @AttrStr + ', ' + @FieldName 
      SET @ValStr       = @ValStr  + ', ' + @ParValueStr
      SET @CurIDO       = @IDO
      SET @CurParSDStr  = @ParSDStr
      SET @CurTableType = @TableType                
    END     
      
    FETCH FROM Res INTO @AttrName, @TableName, @IDO, @FieldName, @ParentID, @TableType, @ParValueStr, @ParSDStr, @TypeData, @EntityID 
  END

  --=============================
  --Если есть какие либо значения атрибутов  
  IF @AttrStr is not NULL 
  BEGIN 
    --Если таблица историчная, то добавляем дату состояния
    IF @TableType = 2 
    BEGIN
      SET @AttrStr = @AttrStr + ',' + 'StateDate'
      SET @ValStr  = @ValStr  + ',' + @CurParSDStr
    END 
    
    --У нас уже есть ИДОбъекта
    IF @ParID > 0
    BEGIN
      SET @AttrStr = @AttrStr + ',' + @CurIDO  
      SET @ValStr  = @ValStr  + ', @ParID' 
    END
   
    SET @SQLStr = 'INSERT INTO ' + @CurTable + '(EntityID' + @AttrStr + ') VALUES (' + CAST(@CurEntity AS VARCHAR(100)) + @ValStr + ')'       
  END
  
  IF @AttrStr is NULL 
    SET @SQLStr =  'INSERT INTO ' + @CurTable + '(EntityID, ' + @CurIDO + ') VALUES (' + CAST(@CurEntity AS VARCHAR(100)) + ', @ParID)' 
  
  --Для теста:
  --UPDATE #Res SET SQLStr = @SQLStr WHERE TableName = @CurTable  
  SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + @SQLStr

  IF @SQLNum = 0  
    SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + 'SELECT @ParID = SCOPE_IDENTITY()' 
   
  SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + 'SELECT @ParID as ID'
END


--Это если UPDATE объекта
IF @ID > 0 
BEGIN
  SET @SQLStrAll = ''
  DECLARE @SetStr varchar(100)   
  FETCH FROM Res INTO @AttrName, @TableName, @IDO, @FieldName, @ParentID, @TableType, @ParValueStr, @ParSDStr, @TypeData, @EntityID 
  SET @CurTable = @TableName
  WHILE @@FETCH_Status = 0
  BEGIN  
    IF @CurTable <> @TableName 
    BEGIN
      IF @CurTableType = 2       
        SET @ValStr = ' AND StateDate = ' + @CurParSDStr                  
     
      --Когда у нас есть что вставлять - есть какие либо значения атрибутов.
      IF @SetStr <> '' 
        SET @SQLStr = 'UPDATE ' + @CurTable + ' SET ' + @SetStr + ' WHERE ' + @CurIDO + ' = ' + @IDStr + @ValStr
            
      --Для теста:                                    
      --UPDATE #Res SET SQLStr = @SQLStr WHERE TableName = @CurTable
     
      --Получаем ИДОбъекта - @ParID
      SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + @SQLStr  
      SET @CurTable  = @TableName          
      SET @ValStr    = ''
      SET @SetStr    = ''             
    END 
    
    IF (@CurTable = @TableName) AND (@ParValueStr is not NULL)
    BEGIN      
      IF @SetStr <> '' 
        SET @SetStr = @SetStr + ', '
        
      SET @SetStr       = @FieldName + ' = ' + @ParValueStr    
      SET @CurIDO       = @IDO
      SET @CurParSDStr  = @ParSDStr
      SET @CurTableType = @TableType                
    END     
      
    FETCH FROM Res INTO @AttrName, @TableName, @IDO, @FieldName, @ParentID, @TableType, @ParValueStr, @ParSDStr, @TypeData, @EntityID 
  END
   --==========================================================
  --Если не для всех таблиц сформирован UPDATE
  --==========================================================
  IF (@SetStr is not NULL)
  BEGIN
   --Если есть какие либо значения атрибутов  
   --Если таблица историчная, то добавляем дату состояния 
    IF @CurTableType = 2       
      SET @ValStr = ' AND StateDate = ' + @CurParSDStr
                      
    --Когда у нас есть что вставлять - есть какие либо значения атрибутов.     
    SET @SQLStr = 'UPDATE ' + @CurTable + ' SET ' + @SetStr + ' WHERE ' + @CurIDO + ' = ' + @IDStr + @ValStr
    
    --Для теста:
    --UPDATE #Res SET SQLStr = @SQLStr  WHERE TableName = @CurTable  
    SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + @SQLStr
  END
  SET @SQLStrAll = @SQLStrAll + CHAR(13) + CHAR(10) + 'SELECT ' + @IDStr + ' as Result'
END

--Для теста: 
--SELECT @TempVALUES as TempVALUES, @ParID as ParID, @CurEntity as CurEntity, @AttrStr as AttrStr, @ValStr as ValStr, @SQLStr as SQLStr, @CurTable as CurTable, @SQLNum as SQLNum 
--SELECT * FROM #Res 
--SELECT @SQLStrAll as SQLStrAll
 
 
CLOSE Res
DEALLOCATE Res
SELECT * from #TempAttr
SELECT * from #TreeTempTable
SELECT * FROM #Res 
--SELECT @SQLStrAll
--EXEC (@SQLStrAll) 
 

--DECLARE @ParID int  
--INSERT INTO Document(EntityID, Number, IsImpExp) VALUES (1563, '11-22-33', 1)  
--SELECT @ParID = SCOPE_IDENTITY()  
--INSERT INTO ContractIns(EntityID, CID) VALUES (1694, @ParID)  
--INSERT INTO ContractIns_Hist_StartDate(EntityID, StartDate,StateDate,ID) VALUES (1694, '2014-01-01 00:00:00.000','2014-11-05 17:26:20.007', @ParID)
 