USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_SaveAttr]    Script Date: 10.01.2018 10:00:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Травин Е.В.
-- Create date: 30.12.2014
-- Description:	Различная работа с атрибатами: Создание, Удаление, Изменение.
-- =============================================
ALTER PROCEDURE [dbo].[spen_SaveAttr] (
  @Operation int,
  --@Operation - тип операции которую нужно произвести с атрибутом и/или полем таблицы
  --1  Создать атрибут и поле в таблице.
  --2  Удалить атрибут и поле в таблице.  
  --3  Изменить атрибут.
  
  @EntityID int,               --ID собственной сущности атрибута.
  @EntityBrief VARCHAR(100),   --Сокращение сущности. атрибута
  @EntityName VARCHAR(100),    --Имя собственной сущности атрибута. Можно указывать что-то одно или @EntityID или @EntityBrief или @EntityName.  
  @TableID int,                --ID собственной таблицы атрибута.
  @TableName VARCHAR(100),     --Имя собственной таблицы атрибута.  Можно указывать что-то одно или @TableID или @TableName.
  @FieldName  VARCHAR(100),    --Имя поля в таблице атрибута.
  @Name VARCHAR(100),          --Наименование атрибута.
  @Brief VARCHAR(100),         --Сокращение атрибута.
  @Mask VARCHAR(100),          --Тип поля (@S50, @N1, @N10, @D6, @N-23.2).
  @TypeFiledName VARCHAR(100), --Тип поля (varchar(X), int, datetime и др.).  timestamp 
  @ObjectNameOrder int,        --Порядок в наименовании объекта. Это используется для специального атрибута НаимОбъекта.  
  @Kind int, 
  --@AttrKind - ВидАтрибута.
  --1	Атрибут из базы данных
  --2	Системный атрибут
  --3	Вычисляемый атрибут на MSQL
  --4	Вычисляемый атрибут на DelphiScript
  --5	Вычисляемый жестко атрибут 
   
  @Type int,
  --@AttrType - ТипАтрибута.
  --1   Поле
  --2	Ссылка
  --3	Универсальная ссылка
  --4	Массив связанных объектов   

  @Feature int,     --Если 0, то атрибут обычный, выводится в гибких таблицах. Далее пока неизвестно.
  @FieldName2 VARCHAR(100), --Пока неизвестно. Не используется.
  
  --Cсылка:
  @RefEntityID int,                --Ссылка на сущность.  
  @RefAttributeID int,             --Ссылка на атрибут для массивов.  
  @RefEntityBrief VARCHAR(100),    --Ссылка на сущность.  
  @RefAttributeBrief VARCHAR(100), --Ссылка на атрибут для массивов.   
  
  @SameCode int,            --Если 1, то код вычисляемого атрибута одинаков и для MSSQL и для Oracle, иначе 0.
  @Code VARCHAR(max),       --Если атрибут вычисляемый то здесь, код вычисляемого атрибута MSSQL.
  @CodeORA VARCHAR(max),    --Если атрибут вычисляемый то здесь, код вычисляемого атрибута ORACLE.
  @Description VARCHAR(max) --Текстовое описание назначения атрибута.
) AS

  --Следующие три переменные для возвращения результата.
  DECLARE @Descr VARCHAR(max)
  DECLARE @Result int --Или код ошибки или 0. 0 - ошибок нет.
  DECLARE @FID int --ID созданного поля в enAttribute.
  
  DECLARE @Temp int
  DECLARE @ExtField int
  DECLARE @AttributeID int
  DECLARE @EXEC varchar(1000) 
  DECLARE @ForignKeyName varchar(100)
  SET @Descr = ''
  SET @Result = 0
  SET @FID = 0
  SELECT @TableID = 0  WHERE @TableID is null
  SELECT @EntityID = 0 WHERE @EntityID is null
  SELECT @EntityName = '' WHERE @EntityName is null
  SELECT @TableName  = '' WHERE @TableName is null
  SELECT @FieldName  = '' WHERE @FieldName is null
  
  --Определяем сущность  
  select @EntityID  = ID, @EntityName = Name, @EntityBrief = Brief from enEntity where @EntityID = ID OR @EntityName = Name OR @EntityBrief = Brief   
  
  --Определяем таблицу как первую из списка таблиц сущности.
  select @TableID = TableID, @TableName = Name from enTable where TableEntityID = (select TableEntityID from enTable where TableEntityID = @EntityID group by TableEntityID having Count(*) = 1)  

  --Определяем имя поля
  select @FieldName = FieldName, @Brief = Brief, @Name = Name from enAttribute where @FieldName = FieldName OR @Brief = Brief OR @Name = Name 
      
  --Определяем ссылку на сущность. 
  SELECT @RefEntityBrief = Name, @RefEntityID = ID from enEntity where @RefEntityID = ID OR @RefEntityBrief = Name  
  
  --Проверяем есть ли реально поле в таблице
  SET @ExtField = 0
  SELECT @ExtField = 1 FROM information_schema.COLUMNS t1 WHERE t1.TABLE_NAME = @TableName and t1.COLUMN_NAME = @FieldName
  
  --Проверяем есть ли атрибут а таблице атрибутов.
  SET @AttributeID = 0
  SELECT @AttributeID = AttributeID FROM enAttribute WHERE TableID = @TableID and FieldName = @FieldName 
     
  IF @EntityID = 0
  BEGIN
    SET @Result = 1 
    SET @Descr = @Descr + 'Не найдена сущность с сокращением "' + @EntityBrief + '"' + CHAR(13) + CHAR(10)
  END 
 
  --====================================================================================================  
  --Если Операция создания атрибута
  --====================================================================================================  
  IF (@Operation = 1) AND (@Result = 0)  
  BEGIN  
    IF (@FieldName = '') AND (@Type <> 4) 
    BEGIN
      SET @Descr = @Descr + 'Не определено поле атрибута' + CHAR(13) + CHAR(10)
      SET @Result = 1   
    END
    
    IF (@TypeFiledName = '') AND (@Type <> 4)  
    BEGIN
      SET @Descr = @Descr + 'Не определен тип поля атрибута' + CHAR(13) + CHAR(10)
      SET @Result = 1    
    END
    
                  
    --Создание поля
    IF (@ExtField = 0) AND (@FieldName <> '') AND (@TypeFiledName <> '') AND (@Result = 0) 
    BEGIN
      SET @EXEC = 'ALTER TABLE dbo.' + @TableName + ' ADD ' + @FieldName  + ' ' + @TypeFiledName
      EXEC (@EXEC)
      SET @ExtField = 1
      SET @Descr = @Descr + 'Создано поле: ' + @TableName + '.' + @FieldName + ' ' + @TypeFiledName + CHAR(13) + CHAR(10)
    END
    
    IF (@ExtField = 0) AND (@Result = 0) AND (@Type <> 4)  
    BEGIN
      SET @Descr = @Descr + 'Ошибка создания поля: ' + @TableName + '.' + @FieldName + ' ' + @TypeFiledName + CHAR(13) + CHAR(10) 
      SET @Result = 1    
    END
    
    --Добавление в таблицу атрибутов      
    IF (@AttributeID = 0) AND (@Result = 0)  
    BEGIN
      INSERT INTO enAttribute (EntityID, AttributeEntityID, Name, Brief, Type, Kind, TableID, 
                               FieldName, FieldName2, Mask, RefEntityID, RefAttributeID, 
                               Feature, ObjectNameOrder, Code, CODEORA, Description, SameCode)
                               
      VALUES                  (3,       @EntityID, @Name, @Brief, @Type,  @Kind, @TableID,
                               @FieldName, NULL, @Mask, @RefEntityID, @RefAttributeID,
                               @Feature, @ObjectNameOrder, @Code, @CODEORA, @Description, @SameCode)
                               
      SET @Descr = @Descr + 'Добавлена запись в таблицу атрибутов.' + CHAR(13) + CHAR(10)
      --Возвращаем ID созданного атрибута.                         
      select @FID = SCOPE_IDENTITY()                                                                                        
    END 
                
    --Создание внешей ссылки (Внешнего ключа на уровне СУБД) 
    IF (@Type = 2) AND (@Result = 0) 
    BEGIN           
      --Определяем главную таблицу сущности на которую ссылемся по ID сущности.
      --Определяем ключевое поле сущности на которую ссылаемся.
      --Все историчные таблицы должны иметь hist в имени. Это правило.
      DECLARE @RefTableID     int            
      DECLARE @RefTableName   VARCHAR(100) 
      DECLARE @RefIDFieldName VARCHAR(100)         
      
      --select ИДОбъекта, ПолеИДОбъекта, Наим  from ТаблицаСущности where Сущность = 1694 and not (Наим like '%hist%')     
      Select top 1 @RefTableID     = TableID, 
                   @RefIDFieldName = IDFieldName, 
                   @RefTableName   = Name 
      From enTable Where TableEntityID = @RefEntityID and not (Name like '%hist%')
          
      --Здесь имя внешнего ключа составляется так:FK_ИмяТаблицыГдеССылка_ИмяПоляССылки_ИмяТаблицыНаКоторуюУказываетВнешнийКлюч
      SET @ForignKeyName = @TableName + '_' + @FieldName + '_' + @RefTableName
      SET @EXEC =  'ALTER TABLE [dbo].[' + @TableName + '] WITH NOCHECK ADD CONSTRAINT [FK_' + @ForignKeyName + '] FOREIGN KEY ([' + @FieldName + '])' + CHAR(13) + CHAR(10) +
                   'REFERENCES [dbo].[' + @RefTableName + '] (['  + @RefIDFieldName + '])'                           
      EXEC (@EXEC)
      SET @Descr = @Descr + 'Добавлен внешний ключ с именем ' + @ForignKeyName + CHAR(13) + CHAR(10)                        
    END
    
    --Универсальная ссылка. Пока не сделано.
    IF (@Type = 3) AND (@Result = 0) 
    BEGIN      
      --Ссылка на атрибут.  
      --SELECT @RefAttributeBrief = Brief, @RefAttributeID = AttributeID FROM enAttribute WHERE @RefAttributeBrief = Brief OR @RefAttributeID = AttributeID 
      select 1
    END                          
  END
  
  
  --==================================================================================================== 
  --Если Операция удаления атрибута:
  --==================================================================================================== 
  IF (@Operation = 2) AND (@Result = 0) 
  BEGIN     
    --Удаление внешнего ключа на уровне СУБД.      
    SET @ForignKeyName = ''
    SET @EXEC = ''
    select @ForignKeyName = CONSTRAINT_NAME from INFORMATION_SCHEMA.KEY_COLUMN_USAGE where TABLE_NAME = @TableName and COLUMN_NAME = @FieldName
	IF @ForignKeyName <> ''
	BEGIN	
      SET @EXEC = 'ALTER TABLE [dbo].[' + @TableName + '] DROP CONSTRAINT [' + @ForignKeyName + '] ' + CHAR(13) + CHAR(10)         
      EXEC (@EXEC)
      SET @Descr = @Descr + 'Удален внешний ключ с именем ' + @ForignKeyName + ' таблицы ' + @TableName + CHAR(13) + CHAR(10)                      
    END
          
    --Сначала удаляем поле из таблицы.  
    IF @ExtField = 1
    BEGIN
      SET @EXEC = 'ALTER TABLE dbo.' + @TableName + ' DROP COLUMN ' + @FieldName + ' ' + CHAR(13) + CHAR(10) 
      EXEC (@EXEC)
      SET @Descr = @Descr + 'Удалено поле ' + @FieldName + ' таблицы ' + @TableName + CHAR(13) + CHAR(10)          
    END
    
    --Если поле удалено, то удаляем атрибут из таблицы атрибутов.
    --Здесь ещё сделать проверку на то что на атрибут есть ссылка с сущности ОтношениеЗапросАтрибут.  
    IF @AttributeID > 0
    BEGIN                       
      SET @EXEC = 'delete from enAttribute where AttributeID = ' + CAST(@AttributeID AS VARCHAR(100)) + CHAR(13) + CHAR(10) 
      EXEC (@EXEC) 
      SET @Descr = @Descr + 'Удалена запись из таблицы атрибутов ID' + CAST(@AttributeID AS VARCHAR(100)) + CHAR(13) + CHAR(10)  
    END   
        
    --select @AttributeID as AttributeID, @TableName as TableName, @FieldName as FieldName, @ForignKeyName as ForignKeyName, @EXEC as sEXEC
    --return 
    EXEC (@EXEC)                                    
  END
  
  --==================================================================================================== 
  --Если Операция изменения атрибута:
  --==================================================================================================== 
  IF (@Operation = 3) AND (@Result = 0) 
  BEGIN  
    --Изменение поля
    IF @ExtField = 1
    BEGIN
      SET @EXEC =  'ALTER TABLE dbo.' + @TableName + ' ALTER COLUMN ' + @FieldName  + ' ' + @Mask
      EXEC (@EXEC)
    END
   
    --Изменение атрибута. Пока для ссылок не сделано.  
    IF @AttributeID > 0
    BEGIN
      UPDATE enAttribute SET AttributeEntityID = @EntityID, 
                             Name        = @Name, 
                             Brief       = @Brief, 
                             Type        = @Type, 
                             Kind        = @Kind, 
                             TableID     = @TableID, 
                             FieldName   = @FieldName, 
                             FieldName2  = @FieldName2, 
                             Mask        = @Mask, 
                             RefEntityID = @RefEntityID, 
                             RefAttributeID  = @RefAttributeID, 
                             Feature         = @Feature, 
                             ObjectNameOrder = @ObjectNameOrder, 
                             Code        = @Code, 
                             CODEORA     = @CODEORA, 
                             Description = @Description, 
                             SameCode    = @SameCode
                                                                                              
    END                  
  END
  
  select @Result as Result, @FID as FID, @Descr as Descr

   