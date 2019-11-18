--=====================================================================
--Подготовка талиц для парсера.
BEGIN TRY DROP TABLE #AttrParser END TRY BEGIN CATCH END CATCH 
BEGIN TRY DROP TABLE #EntityParent END TRY BEGIN CATCH END CATCH 
BEGIN TRY DROP TABLE #EntityParser END TRY BEGIN CATCH END CATCH 
BEGIN TRY DROP TABLE #AttrParent END TRY BEGIN CATCH END CATCH
BEGIN TRY DROP TABLE #AttrChild END TRY BEGIN CATCH END CATCH  
--=====================================================================
 
--=====================================================================
--Таблица #EntityParser с сущностями.           
SELECT ROW_NUMBER() OVER(ORDER BY ID) Pos, * 
  INTO #EntityParser FROM enEntity

ALTER TABLE #EntityParser ADD Table_ID varchar(100)
ALTER TABLE #EntityParser ADD Table_Name varchar(100)
ALTER TABLE #EntityParser ADD Table_IDFieldName varchar(100)

UPDATE #EntityParser SET Table_ID    = t2.TableID,
                   Table_Name        = t2.Name,
                   Table_IDFieldName = t2.IDFieldName                  
FROM enTable t2 WHERE t2.TableEntityID = #EntityParser.ID AND t2.Type = 1
UPDATE #EntityParser SET Pos = Pos - 1
--===================================================================== 
   
--=====================================================================                     
--Таблица #EntityParent с деревом сущностей.
;WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1) AS
      (
        SELECT 
          ID AS EnChildID, 
          Brief AS EnBrief2, 
          ID as EnID, 
          Brief as EnBrief1, 
          ParentID, 
          Name as EnBriefName2, 
          Name as EnBriefName1        
        FROM enEntity
        UNION ALL
        SELECT 
          EnChildID, 
          EnBrief2, 
          e.ID as EnID, 
          e.Brief as EnBrief1, 
          e.ParentID, 
          p.EnBriefName2 as EnBriefName2, 
          e.Name as EnBriefName1          
        FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID
      ) SELECT * INTO #EntityParent FROM Parents ORDER BY EnBrief2, EnBrief1; 
	  
ALTER TABLE #EntityParent ADD EnBrief2_TableName varchar(100);         --Главная таблица сущности EnBrief2.
ALTER TABLE #EntityParent ADD EnBrief2_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief2.
ALTER TABLE #EntityParent ADD EnBrief1_TableName varchar(100);         --Главная таблица сущности EnBrief1.
ALTER TABLE #EntityParent ADD EnBrief1_TableIDFieldName varchar(100);  --ИД поля автоинкремента таблицы сущности EnBrief1.	  

--Данные по таблице для сущности EnBrief2
UPDATE #EntityParent SET 
  #EntityParent.EnBrief2_TableName        = t1.Table_Name, 
  #EntityParent.EnBrief2_TableIDFieldName = t1.Table_IDFieldName
FROM #EntityParser t1 WHERE #EntityParent.EnBrief2 = t1.Brief

--Данные по таблице для сущности EnBrief1
UPDATE #EntityParent SET 
  #EntityParent.EnBrief1_TableName        = t1.Table_Name, 
  #EntityParent.EnBrief1_TableIDFieldName = t1.Table_IDFieldName
FROM #EntityParser t1 WHERE #EntityParent.EnBrief1 = t1.Brief 	       
--=====================================================================  
 
--=====================================================================       
--Таблица #AttrParser с атрибутами
SELECT 
  AttributeID       AS ID,
  EntityID          AS EntityID,
  AttributeEntityID AS Attr_EntityID,
  Name              AS Attr_Name, 
  Brief             AS Attr_Brief,
  Type              AS Attr_Type,
  Kind              AS Attr_Kind,                             
  Mask              AS Attr_Mask,
  Feature           AS Attr_Feature,
  ObjectNameOrder   AS Attr_NameOrder,
  Code              AS Attr_Code,
  Description       AS Attr_Comment,
  TableID           AS Table_ID,
  FieldName         AS Table_Field,
  FieldName2        AS Table_Field2,
  RefEntityID       AS Ref_EntityID,
  RefAttributeID    AS Ref_AttrID
INTO #AttrParser     
FROM enAttribute 
     
ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в котрой находится атрибут. Имя таблицы.
ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в котрой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)
ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)
ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.
ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива
ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива
ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к котрой относится атрибут.


--Данные по таблице атрибута
UPDATE #AttrParser SET 
  #AttrParser.Table_Name        = t1.Name, 
  #AttrParser.Table_IDFieldName = t1.IDFieldName,
  #AttrParser.Table_Feature     = t1.Feature,
  #AttrParser.Table_Type        = t1.Type
FROM enTable t1 
WHERE #AttrParser.Table_ID = t1.TableID

--Данные для атрибута Ссылки или Массива.
UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID 
UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief, 
                 Ref_AttrName    = t1.Name 
FROM enAttribute t1 
WHERE #AttrParser.Ref_AttrID = t1.AttributeID and #AttrParser.Ref_EntityID = t1.AttributeEntityID

--Сущность атрибута 
UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID 
--=====================================================================   

--=====================================================================       
--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков.
SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.* 
  INTO #AttrParent FROM #AttrParser t1 
  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID
UPDATE #AttrParent   SET Pos = Pos - 1 
--=====================================================================   

--=====================================================================       
--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.
--t2.EnChildID, t2.EnBrief2, t2.EnID, t2.EnBrief1, t2.ParentID 
SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.* 
  INTO #AttrChild FROM #AttrParser t1 
  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ  
UPDATE #AttrChild SET Pos = Pos - 1                                                  
--=====================================================================   

--=====================================================================
--Результат 5 таблиц. #AttrParser не используем, поэтому 4.   
--SELECT * FROM #EntityParent 
SELECT * FROM #EntityParser ORDER BY Pos
SELECT * FROM #AttrParent   ORDER BY Pos
SELECT * FROM #AttrChild    ORDER BY Pos
SELECT * FROM enEntity      ORDER BY ID  
SELECT * FROM enAttribute   ORDER BY AttributeID  
SELECT * FROM enTable       ORDER BY TableID  		
--=====================================================================   