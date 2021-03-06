USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_EntityOperation]    Script Date: 10.01.2018 9:55:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Травин Е.В.
-- Create date: 21.12.2014
-- Description:	Создание сущности
-- Параметы: @Operation = 1 - Создание сущности 
--           @Operation = 2 - Удаление сущности 
--           @Operation = 3 - Изменение сущности (Изменение имени, сокращения, описания, измнение имени главной таблицы сущности)
--           @Operation = 4 - Добавление новой таблицы к сущности.
--В MasterSQL нужно добавить команды:
-- CREATE ENTITY EntityName = 'EntityName', 
--               EntityBrief = 'EntityBrief', 
--               ParrentID = 12345, 
--               EntityDescription = 'EntityDescription',
--               TableName  = 'MainTableName';
--
-- DROP ENTITY EntityName = 'EntityName'; 
-- DROP ENTITYTABLE TableName = 'TableName';
-- ALTER ENTITY EntityName = 'EntityName',
--              EntityBrief = 'EntityBrief';
-- ALTER ENTITYTABLE TableName = 'TableName';  

/*Пример вызова:
1. Создание сущности:
EXEC [dbo].[spen_EntityOperation]
@Operation = 1,
@EntityID = 0,
@EntityName = 'Новая сущность 19',
@EntityBrief = 'НоваяСущность19',
@ParentID = 0,
@EntityDescription = 'Опсиание: В этой сущности хранится...',
@TableID = 0,
@TableName = 'A_TableNewEntity19',
@UserID = 361,
@TableKind = 0

2. Изменение сущности и имени таблицы:
EXEC [dbo].[spen_EntityOperation]
@Operation = 3,
@EntityID = 0,
@EntityName = 'Новая сущность 20', 
@EntityBrief = 'НоваяСущность20',
@ParentID = 0,
@EntityDescription = 'Новое опиcание: В этой сущности хранится...',  
@TableID = 4534,
@TableName = 'A_TableNewEntity20',
@UserID = 361,
@TableKind = 0

3. Удаление сущности и всех таблиц сущности (ссылок на таблицы уже не должно быть):
Можно указывать или ID или Имя или Сокращение сущности.
EXEC [dbo].[spen_EntityOperation]
@Operation = 3,
@EntityID = 0,
@EntityName = '',
@EntityBrief = 'НоваяСущность20',
@ParentID = 0,
@EntityDescription = '',
@TableID = 0,
@TableName = '',
@UserID = 361,
@TableKind = 0
*/         
-- =============================================
ALTER PROCEDURE [dbo].[spen_EntityOperation](@Operation int, 
                                             @EntityID int,
                                             @EntityName varchar(100),
                                             @EntityBrief varchar(100),
                                             @ParentID int,
                                             @EntityDescription  varchar(max),
                                             @TableID int,
                                             @TableName varchar(100),                                                 
                                             @UserID int,
                                             @TableKind int)
AS
BEGIN
  declare @QueryText varchar(max)
  declare @Result int
  declare @Ext int
  declare @TableNameOld varchar(100)

  select @EntityID    = IsNull(@EntityID, 0)
  select @TableID     = IsNull(@TableID,  0)

  select @EntityName  = IsNull(@EntityName,  '')
  select @EntityBrief = IsNull(@EntityBrief, '')

  select @TableName   = Name from enTable where TableID = @TableID and IsNull(@TableName, '') = '' and @TableID > 0
  select @TableName   = IsNull(@TableName, '')


  --=========================================================================
  --Поиск уже существующей таблицы сущности, и создание если не существует.
  --=========================================================================
  IF (@Operation in (1,4)) and (@TableName <> '') 
  BEGIN
    set @Ext = 0
    select @Ext = 1 FROM information_schema.COLUMNS t1 WHERE t1.TABLE_NAME = @TableName
 
    IF @Ext = 0 
    BEGIN  
     --select 1213 as eer
     --return
    set @QueryText = 
      'CREATE TABLE [dbo].[' + @TableName + '](' + CHAR(13) + CHAR(10) +
	  '[ID] [int] IDENTITY(1,1) NOT NULL,'          + CHAR(13) + CHAR(10) +
	  '[EntityID] [int] NOT NULL, '                 + CHAR(13) + CHAR(10) +	
	  '[UserCreate] [int] NOT NULL, '               + CHAR(13) + CHAR(10) +	
	  '[UserChange] [int] NULL, '                   + CHAR(13) + CHAR(10) +	
	  '[DateCreate] [datetime] NOT NULL, '          + CHAR(13) + CHAR(10) +	
	  '[DateChange] [datetime] NULL, '              + CHAR(13) + CHAR(10) +	
      'CONSTRAINT [PK_' + @TableName + '] PRIMARY KEY CLUSTERED ' + CHAR(13) + CHAR(10) +
      '([ID] ASC)WITH (PAD_INDEX  = OFF, '          + CHAR(13) + CHAR(10) +
      '                 STATISTICS_NORECOMPUTE  = OFF, ' + CHAR(13) + CHAR(10) +
      '                 IGNORE_DUP_KEY = OFF,  '    + CHAR(13) + CHAR(10) +
      '                 ALLOW_ROW_LOCKS  = ON, '    + CHAR(13) + CHAR(10) +
      '                 ALLOW_PAGE_LOCKS  = ON,'    + CHAR(13) + CHAR(10) + 
      '                 FILLFACTOR = 90) '          + CHAR(13) + CHAR(10) +
      'ON [PRIMARY]) ON [PRIMARY]'                  + CHAR(13) + CHAR(10)
     EXEC (@QueryText)
    END
  END


  --=========================================================================
  --Создание сущности и создание, если не существует.
  --=========================================================================
  IF (@Operation = 1) 
  BEGIN
    ----select 11 as ddf
    --return
    --Добавление в табличку сущностей
    set @Ext = 0
    select @Ext = IsNull((select CASE 
                          WHEN Name = @EntityName THEN 1 
                          WHEN Brief = @EntityBrief THEN 2 
                          ELSE 0
                        END
                        from enEntity where Name = @EntityName or Brief = @EntityBrief), 0)
                        
    if (@Ext = 0) and (@EntityName <> '') and (@EntityBrief <> '')
    BEGIN
      insert into enEntity (EntityID, Name, Brief, ParentID, ClassKey, Feature, Description) 
      values (1, @EntityName, @EntityBrief, @ParentID, @TableName, 0, @EntityDescription) 
      select @EntityID = SCOPE_IDENTITY()
    END
  
    --Добавление в табличку таблиц
    set @Ext = 0
    select @Ext = 1 from enTable where Name = @TableName
                        
    if (@Ext = 0) and (@EntityID > 0) and (@TableName <> '')
    BEGIN
      insert into enTable(EntityID, TableEntityID, Name, IDFieldName, Type) values (2, @EntityID, @TableName, 'ID', 1) 
      select @Result = SCOPE_IDENTITY()
    END ELSE
    BEGIN
      --Если табличка уже записана в enTable то обновляем ссылку на сущность.
      update enTable set TableEntityID = @EntityID where Name = @TableName   
    END
  END    

--=========================================================================
  --Добавление таблицы
  --=========================================================================
  IF (@Operation = 4) 
  BEGIN
    --Получаем ID сущности
    select @EntityID = ID from enEntity where @EntityID = ID OR @EntityName = Name OR @EntityBrief = Brief 
    
    --Добавление в табличку таблиц
    set @Ext = 0
    select @Ext = 1 from enTable where Name = @TableName
                        
    if (@Ext = 0) and (@EntityID > 0) and (@TableName <> '')
    BEGIN
      insert into enTable(EntityID, TableEntityID, Name, IDFieldName, Type) values (2, @EntityID, @TableName, 'ID', @TableKind) 
      select @Result = SCOPE_IDENTITY()
    END ELSE
    BEGIN
      --Если табличка уже записана в enTable то обновляем ссылку на сущность.
      update enTable set TableEntityID = @EntityID where Name = @TableName   
    END
  END    


  --=========================================================================
  --Удаление таблицы сущности или самой сущности.
  --Если удаляется таблица, то нужно передать ID или Имя таблицы.
  --Если удаляется сущность, то также нужно передать или ID или Имя или Сокращение сущьноти.   
  --=========================================================================
  IF (@Operation = 2)
  BEGIN  
    --Удаление сущности.
    IF (@EntityID > 0) OR (@EntityName <> '') OR (@EntityBrief <> '')
    BEGIN
      --Получаем ID сущности
      select @EntityID = ID from enEntity where 
        @EntityID = ID OR @EntityName = Name OR @EntityBrief = Brief 
         
      --Удаление всех таблиц сущности
      Declare EnTables Cursor For
      select Name from enTable where TableEntityID = @EntityID
      Open EnTables
      Fetch first From EnTables Into @TableName
      while @@Fetch_Status = 0
      begin 
        if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[' + @TableName + ']') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
        BEGIN
          exec('drop table [dbo].[' + @TableName + ']')
        END
        Fetch next From EnTables Into @TableName
      end
      Close EnTables
      Deallocate EnTables
      --Удаление из описания
      delete from enTable where TableEntityID = @EntityID
      delete from enEntity where ID = @EntityID
    END
  END
  
  
  --=========================================================================
  --Изменение сущности
  --=========================================================================
  IF (@Operation = 3)
  BEGIN 
    --Изменение сущности
    IF (@EntityID > 0)
    BEGIN
      --select 148
      --return
      update enEntity set Name        = (CASE WHEN @EntityName = 'OLDVALUE' THEN Name ELSE @EntityName END), 
                          Brief       = (CASE WHEN @EntityBrief = 'OLDVALUE' THEN Brief ELSE @EntityBrief END),  
                          Description = (CASE WHEN @EntityDescription = 'OLDVALUE' THEN Description ELSE @EntityDescription END)  
      where ID = @EntityID
    END
  
    --Изменение имени таблицы сущности
    --return
    IF (@TableID > 0)
    BEGIN  
      select @TableNameOld = Name from enTable where TableID = @TableID 
      select @TableNameOld = IsNull(@TableNameOld, '') 
      set @Ext = 0
      select @Ext = 1 FROM information_schema.COLUMNS t1 WHERE t1.TABLE_NAME = @TableNameOld
      
      --select @TableID as TableID, @TableName as TableName, @TableNameOld as TableNameOld, @Ext as Ext
      --return
      
      IF (@TableNameOld <> @TableName) AND (@TableNameOld <> '') AND (@TableName <> '') AND (@Ext = 1)
      BEGIN
        EXEC sp_rename @TableNameOld, @TableName      
        update enTable set Name = @TableName where TableID = @TableID
      END   
    END     
    select 'Выполнено.' as Result
  END
  --=========================================================================



  SELECT @Result as Result
END

--select top 10 * from enTable


  --select top 10 * from Area
  
   /*select @TableNameOld = IsNull(Name, '') from enTable where TableID = @TableID   
    IF @TableNameOld = '' 
    BEGIN
      select 'Не найдена таблица для изменения имени, заданная по ID.' as Result
      RETURN
    END
    
    set @Ext = 0
    select @Ext = 1 FROM information_schema.COLUMNS t1 WHERE t1.TABLE_NAME = @TableName --#Res.TableName --and t1.COLUMN_NAME = #Res.FieldName
    IF (@Ext = 0) 
    BEGIN
      select 'Не найдена таблица для измнения имени, заданная по ID.' as Result
      RETURN
    END 
    */  
    
    --select @TableName

--select * from enTable


  
        --select * from enTable                   
  --IF @Ext = 1
  --  Select 'Сущность с таким именем уже существует' as Result
  --IF @Ext = 2
  --  Select 'Сущность с таким сокращением уже существует' as Result 
  --IF @Ext > 0 RETURN
  --=========================================================================
  
  
 
  
  
  
  
  
  --IF (@Ext = 1) and (@Operation <> 3)
  --BEGIN
  --  Select 'Таблица с таким именем уже существует' as Result
  --  RETURN
  --END

  --Возвращаем ID уже созданной сущности
  
  

--declare @TableName varchar(100)
--declare @TableID int

--set @TableID = 80
--set @TableName = 'dfgdfg'  