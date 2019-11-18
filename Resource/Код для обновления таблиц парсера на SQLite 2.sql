--Подготовка таблиц для парсера.

/*
DROP TABLE fbaEntityParent; 
DROP TABLE fbaAttrParser;
DROP TABLE fbaAttrParent;

CREATE TABLE fbaEntityParent (
   EnChildID INTEGER,
   EnBrief2  TEXT, 
   EnID      INTEGER, 
   EnBrief1  TEXT,  
   ParentID  INTEGER, 
   EnBriefName2 TEXT,  
   EnBriefName1 TEXT,
   NumLevel  INTEGER,
   EnBrief2_TableName TEXT,         --Главная таблица сущности EnBrief2.  
   EnBrief2_TableIDFieldName TEXT,  --ИД поля автоинкремента таблицы сущности EnBrief2.   
   EnBrief1_TableName TEXT,         --Главная таблица сущности EnBrief1.  
   EnBrief1_TableIDFieldName TEXT  --ИД поля автоинкремента таблицы сущности EnBrief1.   
);

CREATE TABLE fbaAttrParser (
  ID                  INTEGER,                                             
  EntityID            INTEGER,                                       
  Attr_EntityID       INTEGER,                                   
  Attr_Name           TEXT,                            
  Attr_Brief          TEXT,                            
  Attr_Type           TEXT,                            
  Attr_Kind           TEXT,                            
  Attr_Mask           TEXT,                            
  Attr_Feature        TEXT,                            
  Attr_NameOrder      TEXT,                            
  Attr_Code           TEXT,                            
  Attr_Comment        TEXT,                            
  Table_ID            INTEGER,                                       
  Table_Field         TEXT,                            
  Table_Field2        TEXT,                            
  Ref_EntityID        INTEGER,                                   
  Ref_AttrID          INTEGER,  
  Table_Name          TEXT,     --Данные по таблице, в которой находится атрибут. Имя таблицы.   
  Table_IDFieldName   TEXT,     --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)"
  Table_Type          INTEGER,  --Тип таблицы (Главная или Историчная)           
  Table_Feature       INTEGER,  --Свойства таблицы.                              
  Ref_EntityBrief     TEXT,     --Сокращение сущности для атрибута Ссылки или Массива            "
  Ref_AttrBrief       TEXT,     --Сокращение атрибута сущности для атрибута Ссылки или Массива   "
  Ref_AttrName        TEXT,     --Наименование атрибута сущности для атрибута Ссылки или Массива "
  Attr_EntityBrief    TEXT      --Сокращение сущности, к которой относится атрибут.     
);

--=====================================================================
--Таблица #AttrParent с атрибутами. Для каждой сущности весь полный список атрибутов, включая предков. "
--DROP TABLE fbaAttrParent;
CREATE TABLE fbaAttrParent (
    Pos                       INTEGER,
    ID                        INTEGER,
    EntityID                  INTEGER,
    Attr_EntityID             INTEGER,
    Attr_Name                 TEXT,
    Attr_Brief                TEXT,
    Attr_Type                 INTEGER,
    Attr_Kind                 INTEGER,
    Attr_Mask                 TEXT,
    Attr_Feature              INTEGER,
    Attr_NameOrder            INTEGER,
    Attr_Code                 TEXT,
    Attr_Comment              TEXT,
    Table_ID                  INTEGER,
    Table_Field               TEXT,
    Table_Field2              TEXT,
    Ref_EntityID              INTEGER,
    Ref_AttrID                INTEGER,
    Table_Name                TEXT,
    Table_IDFieldName         TEXT,
    Table_Type                INTEGER,
    Table_Feature             INTEGER,
    Ref_EntityBrief           TEXT,
    Ref_AttrBrief             TEXT,
    Ref_AttrName              TEXT,
    Attr_EntityBrief          TEXT,
    EnChildID                 INTEGER,
    EnBrief2                  TEXT,
    EnID                      INTEGER,
    EnBrief1                  TEXT,
    ParentID                  INTEGER,
    EnBriefName2              TEXT,
    EnBriefName1              TEXT,
    NumLevel                  INTEGER,
    EnBrief2_TableName        TEXT,
    EnBrief2_TableIDFieldName TEXT,
    EnBrief1_TableName        TEXT,
    EnBrief1_TableIDFieldName TEXT,
    DATA_TYPE                 TEXT,
    CHARACTER_MAXIMUM_LENGTH  INTEGER,
    NUMERIC_PRECISION         INTEGER,
    NUMERIC_PRECISION_RADIX   INTEGER
);


*/ 

DELETE FROM fbaEntityParent; 
DELETE FROM fbaAttrParser;
DELETE FROM fbaAttrParent;

--Таблица #EntityParent с деревом сущностей.  
INSERT INTO  fbaEntityParent (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1, NumLevel)
SELECT * FROM
(WITH Parents (EnChildID, EnBrief2, EnID, EnBrief1, ParentID, EnBriefName2, EnBriefName1, NumLevel) AS  
      (                                                                
        SELECT                                                         
          ID       AS EnChildID,                                             
          Brief    AS EnBrief2,                                           
          ID       AS EnID,                                                  
          Brief    AS EnBrief1,                                           
          ParentID,                                                    
          Name     AS EnBriefName2,                                        
          Name     AS EnBriefName1,                                        
          0        AS NumLevel                                                
        FROM fbaEntity                                                  
        UNION ALL                                                      
        SELECT                                                         
          p.EnChildID,                                                   
          p.EnBrief2,                                                    
          e.ID     AS EnID,                                                
          e.Brief  AS EnBrief1,                                         
          e.ParentID,                                                  
          p.EnBriefName2 AS EnBriefName2,                              
          e.Name   AS EnBriefName1,                                      
          (p.NumLevel + 1) as NumLevel                                 
        FROM fbaEntity e INNER JOIN Parents p ON p.ParentID = e.ID      
      ) SELECT * FROM Parents ORDER BY EnBrief2, EnBrief1
);       
 
--Данные по таблице для сущности EnBrief2 
--EnID - это EnBrief1
--EnChildID - это EnBrief2 
UPDATE fbaEntityParent SET EnBrief2_TableName        = (SELECT Name        FROM fbaTable t1 WHERE fbaEntityParent.EnChildID = t1.TableEntityID);
UPDATE fbaEntityParent SET EnBrief2_TableIDFieldName = (SELECT IDFieldName FROM fbaTable t1 WHERE fbaEntityParent.EnChildID = t1.TableEntityID);
                                                                      
--Данные по таблице для сущности EnBrief1                               
UPDATE fbaEntityParent SET EnBrief1_TableName        = (SELECT Name        FROM fbaTable t1 WHERE fbaEntityParent.EnID = t1.TableEntityID);
UPDATE fbaEntityParent SET EnBrief1_TableIDFieldName = (SELECT IDFieldName FROM fbaTable t1 WHERE fbaEntityParent.EnID = t1.TableEntityID); 
--select * from fbatable
--=====================================================================

--Таблица #AttrParser с атрибутами  
INSERT INTO fbaAttrParser (
 ID,                                             
  EntityID,                                       
  Attr_EntityID,                                  
  Attr_Name,                                      
  Attr_Brief,                                     
  Attr_Type,                                      
  Attr_Kind,                                      
  Attr_Mask,                                      
  Attr_Feature,                                   
  Attr_NameOrder,                                 
  Attr_Code,                                      
  Attr_Comment,                                   
  Table_ID,                                       
  Table_Field,                                    
  Table_Field2,                                   
  Ref_EntityID,                                   
  Ref_AttrID) 
SELECT 
 AttributeID ,                                            
  EntityID,                                    
  AttributeEntityID,                                
  Name,                                   
  Brief,                                     
  Type,                                  
  Kind,                                     
  Mask,                                    
  Feature,                                  
  ObjectNameOrder,                                 
  Code,                                     
  Description,                                 
  TableID,                                     
  FieldName,                                 
  FieldName2,                                  
  RefEntityID,                               
  RefAttributeID FROM fbaAttribute;                  

--Данные по таблице атрибута 
UPDATE fbaAttrParser SET Table_Name        = (SELECT t1.Name        FROM fbaTable t1 WHERE fbaAttrParser.Table_ID = t1.TableID);         
UPDATE fbaAttrParser SET Table_IDFieldName = (SELECT t1.IDFieldName FROM fbaTable t1 WHERE fbaAttrParser.Table_ID = t1.TableID);    
UPDATE fbaAttrParser SET Table_Feature     = (SELECT t1.Feature     FROM fbaTable t1 WHERE fbaAttrParser.Table_ID = t1.TableID);    
UPDATE fbaAttrParser SET Table_Type        = (SELECT t1.Type        FROM fbaTable t1 WHERE fbaAttrParser.Table_ID = t1.TableID);                                      
--Данные для атрибута Ссылки или Массива.
UPDATE fbaAttrParser SET Ref_EntityBrief = (SELECT t1.Brief FROM fbaEntity t1    WHERE fbaAttrParser.Ref_EntityID = t1.ID);                               
UPDATE fbaAttrParser SET Ref_AttrBrief   = (SELECT t1.Brief FROM fbaAttribute t1 WHERE fbaAttrParser.Ref_AttrID = t1.AttributeID and fbaAttrParser.Ref_EntityID = t1.AttributeEntityID);
UPDATE fbaAttrParser SET Ref_AttrName   = (SELECT t1.Name FROM fbaAttribute t1 WHERE fbaAttrParser.Ref_AttrID = t1.AttributeID and fbaAttrParser.Ref_EntityID = t1.AttributeEntityID);
--Сущность атрибута 
UPDATE fbaAttrParser SET  Attr_EntityBrief = (SELECT  t1.Brief FROM fbaEntity t1 WHERE fbaAttrParser.Attr_EntityID = t1.ID);                                                  
--select * from fbaAttrParser order by Attr_entityID;    
--select * from fbaEntity order by ID;        
--select * from fbaAttribute order by AttributeEntityID;   
               

--delete from fbaAttrParent
INSERT INTO fbaAttrParent
   (--fbaAttrParser
    Pos,
    ID,
    EntityID,
    Attr_EntityID,
    Attr_Name,
    Attr_Brief,
    Attr_Type,
    Attr_Kind,
    Attr_Mask,
    Attr_Feature,
    Attr_NameOrder,
    Attr_Code,
    Attr_Comment,
    Table_ID,
    Table_Field,
    Table_Field2,
    Ref_EntityID,
    Ref_AttrID,
    Table_Name,
    Table_IDFieldName,
    Table_Type,
    Table_Feature,
    Ref_EntityBrief,
    Ref_AttrBrief,
    Ref_AttrName,
    Attr_EntityBrief,
    --fbaEntityParent
    EnChildID,
    EnBrief2,
    EnID,
    EnBrief1,
    ParentID,
    EnBriefName2,
    EnBriefName1,
    NumLevel,
    EnBrief2_TableName,
    EnBrief2_TableIDFieldName,
    EnBrief1_TableName,
    EnBrief1_TableIDFieldName) 
SELECT ((select count(*) from fbaAttrParser b  where t1.id >= b.id)-1) as Pos, 
    t1.ID,
    t1.EntityID,
    t1.Attr_EntityID,
    t1.Attr_Name,
    t1.Attr_Brief,
    t1.Attr_Type,
    t1.Attr_Kind,
    t1.Attr_Mask,
    t1.Attr_Feature,
    t1.Attr_NameOrder,
    t1.Attr_Code,
    t1.Attr_Comment,
    t1.Table_ID,
    t1.Table_Field,
    t1.Table_Field2,
    t1.Ref_EntityID,
    t1.Ref_AttrID,
    t1.Table_Name,
    t1.Table_IDFieldName,
    t1.Table_Type,
    t1.Table_Feature,
    t1.Ref_EntityBrief,
    t1.Ref_AttrBrief,
    t1.Ref_AttrName,
    t1.Attr_EntityBrief, 
    t2.EnChildID,
    t2.EnBrief2,
    t2.EnID,
    t2.EnBrief1,
    t2.ParentID,
    t2.EnBriefName2,
    t2.EnBriefName1,
    t2.NumLevel,
    t2.EnBrief2_TableName,
    t2.EnBrief2_TableIDFieldName,
    t2.EnBrief1_TableName,
    t2.EnBrief1_TableIDFieldName            
  --INTO #AttrParent 
FROM fbaAttrParser t1                                 
LEFT JOIN fbaEntityParent t2 ON t2.EnID = t1.Attr_EntityID             
ORDER BY EnBrief2, NumLevel desc, Table_Type, Table_Name, t1.Attr_Brief      
  


--select * FROM fbaAttrParent order by EnBrief2, NumLevel desc, Table_Type, Table_Name, Attr_Brief 
--select * FROM fbaAttrParent order by Attr_EntityID, Attr_Brief

--select *  FROM fbaAttrParser
--select * from fbaEntity
--select * from fbaAttribute
--select * from fbaTable


--SELECT ROW_NUMBER() OVER(ORDER BY EnBrief2) Pos, t1.*, t2.*            
--  INTO #AttrParent FROM #AttrParser t1                                 
--  LEFT JOIN #EntityParent t2 ON t2.EnID = t1.Attr_EntityID             
--  ORDER BY EnBrief2, NumLevel desc, Table_Type, Table_Name, t1.Attr_Brief              

--UPDATE #AttrParent   SET Pos = Pos - 1                                 
--=====================================================================

--=====================================================================
--Таблица #AttrChild с атрибутами. Для каждой сущности список атрибутов потомков.      
--Работает, но пока отключено.                                         
--SELECT ROW_NUMBER() OVER(ORDER BY Attr_EntityID, Attr_Brief) Pos, t1.*, t2.*        
--  INTO #AttrChild FROM #AttrParser t1                                
--  RIGHT JOIN #EntityParent t2 ON t2.EnChildID = t1.Attr_EntityID AND t1.Attr_Brief IS NOT NULL --1716 Расчетный документ  
--UPDATE #AttrChild SET Pos = Pos - 1                                  
--=====================================================================

--=====================================================================               
--Результат 2 таблицы.                                                  
--SELECT * INTO dbo.fbaEntityParser FROM #EntityParser                   
--SELECT * INTO dbo.fbaAttrParent   FROM #AttrParent                     
--SELECT 1                                                                                                                                                                    
--===================================================================== + ParserSys.CR;

--SELECT                                                                 
--  AttributeID       AS ID,                                             
--  EntityID          AS EntityID,                                       
--  AttributeEntityID AS Attr_EntityID,                                  
--  Name              AS Attr_Name,                                      
--  Brief             AS Attr_Brief,                                     
--  Type              AS Attr_Type,                                      
--  Kind              AS Attr_Kind,                                      
--  Mask              AS Attr_Mask,                                      
--  Feature           AS Attr_Feature,                                   
--  ObjectNameOrder   AS Attr_NameOrder,                                 
--  Code              AS Attr_Code,                                      
--  Description       AS Attr_Comment,                                   
--  TableID           AS Table_ID,                                       
---  FieldName         AS Table_Field,                                    
--  FieldName2        AS Table_Field2,                                   
--  RefEntityID       AS Ref_EntityID,                                   
--  RefAttributeID    AS Ref_AttrID                                      
--INTO #AttrParser                                                       
--FROM enAttribute                                                       

--ALTER TABLE #AttrParser ADD Table_Name varchar(100);          --Данные по таблице, в которой находится атрибут. Имя таблицы.   
--ALTER TABLE #AttrParser ADD Table_IDFieldName varchar(100);   --Данные по таблице, в которой находится атрибут. ID поля автоинкремена в таблице. (Поле внешенего ключа)"
--ALTER TABLE #AttrParser ADD Table_Type int;                   --Тип таблицы (Главная или Историчная)           
--ALTER TABLE #AttrParser ADD Table_Feature int;                --Свойства таблицы.                              
--ALTER TABLE #AttrParser ADD Ref_EntityBrief varchar(100);     --Сокращение сущности для атрибута Ссылки или Массива            "
--ALTER TABLE #AttrParser ADD Ref_AttrBrief varchar(100);       --Сокращение атрибута сущности для атрибута Ссылки или Массива   "
--ALTER TABLE #AttrParser ADD Ref_AttrName varchar(100);        --Наименование атрибута сущности для атрибута Ссылки или Массива "
--ALTER TABLE #AttrParser ADD Attr_EntityBrief varchar(100);    --Сокращение сущности, к которой относится атрибут.              "


--Данные по таблице атрибута                                           
--UPDATE #AttrParser SET                                                 
--  #AttrParser.Table_Name        = t1.Name,                             
--  #AttrParser.Table_IDFieldName = t1.IDFieldName,                      
--  #AttrParser.Table_Feature     = t1.Feature,                          
--  #AttrParser.Table_Type        = t1.Type                              
--FROM enTable t1                                                        
--WHERE #AttrParser.Table_ID = t1.TableID                                

--Данные для атрибута Ссылки или Массива.                              
--UPDATE #AttrParser SET Ref_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Ref_EntityID = t1.ID 


--UPDATE #AttrParser SET Ref_AttrBrief   = t1.Brief,                     
--                      Ref_AttrName    = t1.Name                       
--FROM enAttribute t1                                                    
--WHERE #AttrParser.Ref_AttrID = t1.AttributeID and #AttrParser.Ref_EntityID = t1.AttributeEntityID         

--Сущность атрибута                                                    
--UPDATE #AttrParser SET Attr_EntityBrief = t1.Brief FROM enEntity t1 WHERE #AttrParser.Attr_EntityID = t1.ID 
--=====================================================================
