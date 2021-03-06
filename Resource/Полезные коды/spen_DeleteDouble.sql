USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_DeleteDouble]    Script Date: 10.01.2018 9:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
/*
  Author:		Травин Е.В.
  Create date: 23.01.2014
  Description:	Удаление дублей. 
  Хранимка для дедубликации объектов в БД. 
  Параметры: 
  @EntityBrief - Сущность сокращение. Например Застрахованный
  @IDFROM  - ИД Объекта, которой нужно удалить.
  @IDTO    - ИД Объекта, на который нужно перекинуть ссылки, при удалении @IDFROM. 
           --Т.е. все ссылки на объект @IDFROM будут перекинуты на @IDTO.

  @Test    - Если указан @Test = 0, то это рабочий режим. Ссылки на объект будут подменены, а сам объект удален.
  
  Если @Test = 1,  то вместо действий будет возвращен результат какие таблицы будут обновлены и текст SQL запросов 
                   для обновления ссылок и удаления объекта.
  
  Если @Test = 2,  то будет проведена проверка, если ли удаляемый объект в БД. Результат таблица из одной колонки CNT и одной записи,
                   если CNT > 0, то есть, 0 - объекта нет. 
				           Число CNT показывает во скольких таблицах находится объект в БД. 
				           Так как технически объект может быть раскидан по нескольким таблицам в БД.
                   Текст запросов SQLExists показывает есть ли объект в БД и во скольких таблицах находится. 
                   Проверяются таблицы предков и таблицы самой сущности объекта (историчные).
  
  Если @Test = 3, текст запросов SQLLink показывает сколько объектов ссылается на удаляемый объект. 
                  Проверяются ссылки на предков тоже. Т.е. 3 - покажет количество ссылок на объект из других объектов.
    
  Если @Test = 4, Подменятся только ссылки, дублируемый объект не будет удален.

  Если @Test = 5, Будут показаны таблицы (и созданы SQL запросы для изменения ссылок на удляемый 
                  объект - т.е. обновления только тех таблиц, в которых находятся ссылки на удаляемый объект).  
  Пример вызова: 
  Если нужно только удалить объект, а подменять нечего не нужно, то в @IDTO нужно передать NULL или 0. Однако, 
  если на объект что-то ссылается а в @IDTO передан 0, то он удален не будет.
  DROP TABLE dbo.DeleteDoubleSQL 
  delete from  dbo.DeleteDoubleSQL where EntityBrief = 'ДогСтрах'
  EXEC [dbo].[spen_DeleteDouble] 'ДогСтрах', 1236606, 1236607, 1  

  delete from  dbo.DeleteDoubleSQL where EntityBrief = 'Лицо'
  EXEC [dbo].[spen_DeleteDouble] 'Лицо', 864348, 864347, 5  

  EXEC [dbo].[spen_DeleteDouble] 'Документ', 3651, 3652, 1 

  с 1045799  на 313916
  EXEC [dbo].[spen_DeleteDouble] 'ПрограммаВариантДогСтрах', 1045799, 313916, 1     
 

 SELECT * FROM dbo.DeleteDoubleSQL 
 delete from  dbo.DeleteDoubleSQL where EntityBrief = 'ПрограммаВариантДогСтрах'
 --SELECT TOP 1 Updated FROM dbo.DeleteDoubleSQL WHERE EntityBrief =       'ПрограммаВариантДогСтрах'
 EXEC [dbo].[spen_DeleteDouble] 'ПрограммаВариантДогСтрах', 693176, 313916, 1   
 EXEC [dbo].[spen_DeleteDouble] 'ВариантДогСтрах', 355096, 205318, 1   
 
 delete from dbo.DeleteDoubleSQL where EntityBrief = 'ЮЛ'
 EXEC [dbo].[spen_DeleteDouble] 'ЮЛ', 259445, 181294 , 1

--alter table dbo.DeleteDoubleSQL add SQLUpdateObject varchar(max)

  --==========================================================
  Результат выглядит так:
  Обновление:
  UPDATE Account SET OwnerObjectID = 23456 WHERE OwnerObjectID = 12345 AND OwnerEntityID = 1696
  UPDATE AccountTypeContents SET RefObjectID = 23456 WHERE RefObjectID = 12345 AND RefEntityID = 1696
  UPDATE ComplexTrans SET OObjectID = 23456 WHERE OObjectID = 12345 AND OEntityID = 1696
  UPDATE ContractLimit SET ObjectID = 23456 WHERE ObjectID = 12345 AND ObjectEntityID = 1696
  UPDATE ContractLPU SET Executor = 23456 WHERE Executor = 12345
  UPDATE ContractProgramContent SET LPU = 23456 WHERE LPU = 12345
  UPDATE ContractVariantContent SET LPU = 23456 WHERE LPU = 12345
  UPDATE enObjectLock SET LockObjectID = 23456 WHERE LockObjectID = 12345 AND LockEntityID = 1696
  UPDATE enSolutionStuffObject SET RefObjectID = 23456 WHERE RefObjectID = 12345 AND RefEntityID = 1696
  .....
  и другие запросы.

  Удаление:
  DELETE FROM LPU WHERE ID = 12345
  .....
  и другие запросы.
*/




--=======================================================================================================
ALTER PROCEDURE [dbo].[spen_DeleteDouble](@EntityBrief varchar(100), @IDFROM int, @IDTO int, @Test int = 0)
AS
BEGIN 
  --DROP TABLE dbo.DeleteDoubleSQL 
  --TRUNCATE TABLE dbo.DeleteDoubleSQL
  --INSERT INTO dbo.DeleteDoubleSQL
  --SELECT * FROM dbo.DeleteDoubleSQL
  --DELETE FROM dbo.DeleteDoubleSQL WHERE EntityBrief = 'Застрахованный'

  --Проверяем последнюю дату обновления таблицы ключей в БД
  --Если больше 1 дня, то обновляем.
  --Если таблицы нет, или она пуста, то создастся. 
  --Это сделано для ускорения, так как получать таблицу dbo.ALLForeignKey очень долго - около 4 сек.
  DECLARE @Updated datetime  
  DECLARE @SQLDelete varchar(max) = ''
  DECLARE @SQLUpdate varchar(max) = ''
  DECLARE @SQLExists varchar(max) = ''
  DECLARE @SQLLink   varchar(max) = ''

  --Тут следующая ситуация. В @SQLUpdate (и соотвтетственно в поле SQLUpdate) будут записаны запросы ДЛЯ ВСЕХ ТАБЛИЦ которые обновят ссылку на объект,
  --Поэтому получается довольно длинная портянка запросов UPDATE - там будут все таблицы, котрые могут ссылаться на удаляемы объект сущности.
  --Но если нам нужно получить текст запросов UPDATE для конкретного объекта с конкретным ID, то для начала нужно проверить в каких таблицах есть ссылка на удалемый объект сущности.
  --и в зависимости от этого сформировать текст SQL запросов. И этот текст запросов вернуть. В таблицу dbo.DeleteDoubleSQL нет смысла записывать текст этих запросов, 
  --так как для разных ИД Объекта будет разный список запросов. 
  DECLARE @SQLUpdateObject varchar(max)

  IF @IDTO IS NULL
    SET @IDTO = 0

  IF @IDFROM IS NULL
  BEGIN
    SELECT 'Параметр @IDFROM не может быть NULL' as Result
  END

  --Если таблицы dbo.DeleteDoubleSQL  нет, то она создается. select * from dbo.DeleteDoubleSQL
  --alter table dbo.DeleteDoubleSQL add SQLUpdateObject varchar(max)
  IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'DeleteDoubleSQL') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
  BEGIN
     SET @Updated = (SELECT TOP 1 Updated FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief)
  END ELSE
  BEGIN
    --select * from dbo.DeleteDoubleSQL
     CREATE TABLE dbo.DeleteDoubleSQL 
	   (Updated datetime, 
	    EntityBrief varchar(100), --Сущность сокращение
	    SQLUpdate   varchar(max), --Собственно запросы для дедубликации
		SQLDelete   varchar(max), --Для удаления объекта
		SQLExists   varchar(max), --Проверка на существование объкта
		SQLLink     varchar(max),  
        SQLUpdateObject varchar(max), --Это получение запросов с помощью которых можно определить какие именно таблицы нужно обновить, чтобы выполнить дедубликацию.
		                              --т.е. поиск не просто таблиц в БД, а поиск в самих таблицах дедублицируемого объекта. И если в таблице есть ссылка на дедублицируемый объект,
									  --то такая таблица включается в список таблиц к котрым будет применён UPDATE. А SQLUpdate содержит просто список таблиц (всех) - независимо есть там что обновлять или нет.
		SQLDeleteUpdate varchar(max))	--Это для отмены дедублиукации 
     SET @Updated = '19000101 00:00:00.000'
  END  

  --Если прошел больше чем день, то обновляем запросы в таблице dbo.DeleteDoubleSQL, так как могли добавится/удалиться/измениться атрибуты, таблицы/поля в БД.
  IF (GetDate() - ISNULL(@Updated, '19000101 00:00:00.000')) > 1 
  BEGIN
    --RETURN
    --Определяем ИДОБъекта сущности.
	  DECLARE @EntityID int
	  SELECT @EntityID = EOT_1.ID FROM enEntity EOT_1 WHERE EOT_1.Brief = @EntityBrief
   
	  --Добавяем обычные ссылки 
	  SELECT 
    --FK.CONSTRAINT_NAME as ForeignKey, 
	  --FK.TABLE_CATALOG as FROM_TABLE_CATALOG,
	  --FK.TABLE_SCHEMA  as FROM_TABLE_SCHEMA,
	  FK.TABLE_NAME    as FROM_TABLE_NAME,
	  FK.COLUMN_NAME   as FROM_COLUMN_NAME,
      --PK.TABLE_CATALOG as TO_TABLE_CATALOG,
      --PK.TABLE_SCHEMA  as TO_TABLE_SCHEMA,
	  PK.TABLE_NAME    as TO_TABLE_NAME,
	  PK.COLUMN_NAME   as TO_COLUMN_NAME
	  INTO #Tabl1
    FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE PK
      JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C ON PK.CONSTRAINT_CATALOG=C.UNIQUE_CONSTRAINT_CATALOG AND PK.CONSTRAINT_SCHEMA=C.UNIQUE_CONSTRAINT_SCHEMA AND PK.CONSTRAINT_NAME=C.UNIQUE_CONSTRAINT_NAME
      JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE FK ON C.CONSTRAINT_CATALOG=PK.CONSTRAINT_CATALOG AND C.CONSTRAINT_SCHEMA=FK.CONSTRAINT_SCHEMA AND C.CONSTRAINT_NAME=FK.CONSTRAINT_NAME AND PK.ORDINAL_POSITION=FK.ORDINAL_POSITION
    ORDER BY FK.CONSTRAINT_NAME, PK.ORDINAL_POSITION
    
	  --Для теста, потом нужно раскомментировать:
    --select * into #Tabl1 from dbo.ALLForeignKey

	  --Получаем всю таблицу вложенности по сущностям. Какие таблицы входят в сущность, включая родителей сущности. 
	  --Здесь все сущности без исключения.
	  ;WITH Parents(ChildID, NameEn, ID, Brief, ParentID) AS
      (
        SELECT ID AS ChildID, Brief AS NameEn, ID, Brief, ParentID from enEntity
        --where ID = 1717 --Для теста
        UNION ALL
        SELECT ChildID, NameEn, e.ID, e.Brief, e.ParentID 
	    FROM enEntity e INNER JOIN Parents p ON p.ParentID = e.ID
      ) SELECT * INTO #Tabl2 FROM Parents ORDER BY NameEn, Brief  	
	  --select * from #Tabl2

    --Получаем имя и ID таблиц в #Tabl3
    --и отбираем таблицы по той сущности которую будем дедублицировать.
	  --Здесь уже происходит отбор и проставляются имена таблиц.
	  --Здесь ORDER BY DESC нужен чтобы сначала удалить объект из вложенных сущностей (потомков), 
	  --а после удалить из родительских сущностей. Хотя в принципе это не нужно. 
	  --Внешних ключей между потомками и родителями (сущностями) нет. 
	  --Поэтому технически можно удалять в любом порядке.
   
    --Это предки и сам объект удаляемой сущности
    SELECT t1.Name as TABLE_NAME, t1.IDFieldName as COLUMN_NAME, t2.ParentID INTO #Tabl3 
	  FROM #Tabl2 t2 LEFT JOIN enTable t1 ON t1.TableEntityID = t2.ID WHERE t2.NameEn = @EntityBrief ORDER BY t2.ParentID DESC
    
    --Это потомки объекта удаляемой сущности
    INSERT INTO #Tabl3
      SELECT t1.Name as TABLE_NAME, t1.IDFieldName as COLUMN_NAME, t2.ChildID as ParentID
	    FROM #Tabl2 t2 
      LEFT JOIN enTable t1 ON t1.TableEntityID = t2.ChildID WHERE t2.Brief = @EntityBrief AND NameEn <> @EntityBrief   
      ORDER BY t2.ChildID DESC
    
    --select * from #Tabl3
    --return

    --Здесь все таблицы которые имеют ключи.
    SELECT FROM_TABLE_NAME as TABLE_NAME, FROM_COLUMN_NAME as COLUMN_NAME
	  INTO #Tabl4 FROM #Tabl1 WHERE TO_TABLE_NAME IN (SELECT TABLE_NAME FROM #Tabl3)
    ALTER TABLE #Tabl4 ADD ENTITY VARCHAR(200)	
		
	  --Добавляем универсальные ссылки
    /*Выбрать
	  Таблица.Наим 'TO_TABLE_NAME',
	  Поле 'TO_COLUMN_NAME',
	  Поле2 'TO_ENTITY_NAME',
	  --CAST(ИДОбъекта as Varchar(100)),
	  Тип Из АтрибутСущности where Тип = 3 */
    INSERT INTO #Tabl4
    SELECT
      EOT_2.Name       "TABLE_NAME",
      EOT_1.FieldName  "COLUMN_NAME",
      EOT_1.FieldName2 "ENTITY" --Это не имя сущности. В этом поле содержится имя поля в котором содержится ИД сущности.
    FROM
      enAttribute EOT_1
    Left Outer Join enTable EOT_2 On EOT_2.TableID = EOT_1.TableID
    WHERE
      EOT_1.Type = 3 --3 - это тип Универсальные ссылки.   

    --Создание SQL запросов на обновление. Чтобы подменить все ссылки на удаляемый объект на другой объект. 
    SET @SQLUpdateObject = 'DECLARE @SQLUpdateObject varchar(max)' + CHAR(13) + CHAR(10) + 'SET @SQLUpdateObject = ''''' + CHAR(13) + CHAR(10)   
    DECLARE @TABLE_NAME varchar(max)
    DECLARE @COLUMN_NAME varchar(max)
    DECLARE @ENTITY varchar(max)   
    DECLARE @RefCount int
    DECLARE ReplaceID CURSOR DYNAMIC FOR SELECT DISTINCT TABLE_NAME, COLUMN_NAME, ENTITY FROM #Tabl4
	  DECLARE @TempUpdate TABLE (SQLUpdate varchar(max), TABLE_NAME varchar(200), RefCount int)
    OPEN ReplaceID
    FETCH FROM ReplaceID INTO @TABLE_NAME, @COLUMN_NAME, @ENTITY
    WHILE @@Fetch_Status = 0
    BEGIN 
      --Если @ENTITY пусто, то это обычная ссылка, иначе универсальная.           
      IF ISNULL(@ENTITY, '') = ''
	    BEGIN
        SET @SQLUpdate = ' UPDATE ' + @TABLE_NAME + ' SET ' + @COLUMN_NAME + ' = 222222 WHERE ' + @COLUMN_NAME + ' = 111111 ' 	 		    		 
		    SET @SQLLink   = @SQLLink   + ' UNION ALL SELECT COUNT(*) AS CNT FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111 ' + CHAR(13) + CHAR(10)         	      
        --Сборка кода для получения кода UPDATE конкретного объекта.
        --Далее можно будет заменить 11111 и 22222 на конкретные ИД, и выполнить код в @SQLUpdateObject. На выходе будет текст SQL запросов UPDATE для конкретного объекта, 
        --который тоже нужно выполнить, чтобы заменить ссылки. Здесь без ENTITY, ниже тоже самое, но с ENTITY.
       SET @SQLUpdateObject = @SQLUpdateObject +     
          'SELECT @SQLUpdateObject = @SQLUpdateObject + ''UPDATE ' + @TABLE_NAME + ' SET ' + @COLUMN_NAME + ' = 222222 WHERE  ' + @COLUMN_NAME + ' = 111111'' + CHAR(13) + CHAR(10) WHERE ' +
          '(SELECT Count(*) from ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + '  = 111111) > 0 ' + CHAR(13) + CHAR(10)         
      END ELSE
	    BEGIN
        SET @SQLUpdate = ' UPDATE ' + @TABLE_NAME + ' SET ' + @COLUMN_NAME + ' = 222222 WHERE ' + @COLUMN_NAME + ' = 111111 AND ' + @ENTITY +' = ' + CAST(@EntityID AS VARCHAR(100))          		 
		    SET @SQLLink   = @SQLLink   + ' UNION ALL SELECT COUNT(*) AS CNT FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111 AND ' + @ENTITY +' = ' + CAST(@EntityID AS VARCHAR(100)) + CHAR(13) + CHAR(10)	   	   	   
       
        SET @SQLUpdateObject = @SQLUpdateObject +     
          'SELECT @SQLUpdateObject = @SQLUpdateObject + ''UPDATE ' + @TABLE_NAME + ' SET ' + @COLUMN_NAME + ' = 222222 WHERE  ' + @COLUMN_NAME + ' = 111111 AND ' + @ENTITY + ' = ' + CAST(@EntityID AS VARCHAR(100)) + ''' + CHAR(13) + CHAR(10) WHERE ' +
          '(SELECT Count(*) from ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + '  = 111111 AND ' + @ENTITY + ' = ' + CAST(@EntityID AS VARCHAR(100)) + ') > 0 ' + CHAR(13) + CHAR(10)         
      END
      SET @RefCount	= 0
      IF CHARINDEX('_RefCount', @TABLE_NAME) > 0
      BEGIN
        SET @RefCount	= 1
        SET @SQLDelete = @SQLDelete + ' DELETE FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111 ' + CHAR(13) + CHAR(10)
        SET @SQLUpdate = @SQLUpdate  + ' AND NOT EXISTS(SELECT 1 FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111)'       		 
      END
      SET @SQLUpdate = @SQLUpdate + CHAR(13) + CHAR(10) 
      INSERT INTO @TempUpdate (SQLUpdate, TABLE_NAME, RefCount) VALUES (@SQLUpdate, @TABLE_NAME, 0)		   
      FETCH FROM ReplaceID INTO @TABLE_NAME, @COLUMN_NAME, @ENTITY
    END


    CLOSE ReplaceID
    DEALLOCATE ReplaceID 
    
	  --Создание SQL запросов на удаление. После того как все ссылки на удаляемый объект изменены, объект можно удалить.
    --Удаление из таблиц _RefCount записывается в @SQLDelete при создани запросов UPDATE (выше)
	  --Собираем все таблицы в которых находится объект, включая родительские сущности. 		
    DECLARE DeleteID CURSOR DYNAMIC FOR SELECT TABLE_NAME, COLUMN_NAME FROM #Tabl3 ORDER BY ParentID DESC
    OPEN DeleteID
    FETCH FROM DeleteID INTO @TABLE_NAME, @COLUMN_NAME
    WHILE @@Fetch_Status = 0 
    BEGIN     
      SET @SQLDelete = @SQLDelete + ' DELETE FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111 ' + CHAR(13) + CHAR(10)	   	 
	    SET @SQLExists = @SQLExists + ' UNION ALL SELECT COUNT(*) CNT FROM ' + @TABLE_NAME + ' WHERE ' + @COLUMN_NAME + ' = 111111 ' + CHAR(13) + CHAR(10)	   
	    FETCH FROM DeleteID INTO @TABLE_NAME, @COLUMN_NAME
    END
    CLOSE DeleteID
    DEALLOCATE DeleteID
	
    DROP TABLE #Tabl1
	  DROP TABLE #Tabl2
	  DROP TABLE #Tabl3
	  DROP TABLE #Tabl4
	
    UPDATE @TempUpdate SET RefCount = 1 WHERE CHARINDEX('_RefCount', TABLE_NAME) > 0	
	  SELECT @SQLUpdate = @SQLUpdate + ' ' + SQLUpdate FROM @TempUpdate ORDER BY RefCount --FOR XML PATH('')
	  --SELECT @SQLUpdate
	  --RETURN
    SET @SQLUpdateObject = @SQLUpdateObject + CHAR(13) + CHAR(10) + 'SELECT @SQLUpdateObject as SQLUpdateObject'
	  SET @SQLLink   = 'SELECT SUM(CNT) as ObjectCount FROM (SELECT 0 as CNT '  + CHAR(13) + CHAR(10) + @SQLLink + ') T1'
	  SET @SQLExists = 'SELECT SUM(CNT) as ObjectCount FROM (SELECT 0 as CNT '  + CHAR(13) + CHAR(10) + @SQLExists + ') T1'
	  DELETE FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
	  INSERT INTO dbo.DeleteDoubleSQL (Updated, EntityBrief, SQLUpdate, SQLDelete, SQLExists, SQLLink, SQLUpdateObject) VALUES (GetDate(), @EntityBrief, @SQLUpdate, @SQLDelete, @SQLExists, @SQLLink, @SQLUpdateObject)	
  END

  --return
  --Если прошло меньше чем один день, с момент вызова хранимки для указанной сущности, то весь код  выше не выполняется, и выбираются уже готовые запросы из таблицы dbo.DeleteDoubleSQL.
  --Таблица dbo.DeleteDoubleSQL создается и заполняется в коде выше.
  --Если нужно подменить ссылки на объект и удалить его.
  
  --@Test = 0 -это рабочий режим. Ссылки на объект будут подменены, а сам объект удален.
  --@Test = 4 - подменятся только ссылки, дублируемый объект не будет удален.
  IF (@Test = 0) OR (@Test =4)
  BEGIN
    SELECT @SQLUpdate  = SQLUpdate, 
	         @SQLDelete  = SQLDelete,
	         @SQLExists  = SQLExists,
	         @SQLLink    = SQLLink
    FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief

    SET @SQLUpdate = REPLACE(@SQLUpdate, '111111', CAST(@IDFROM AS VARCHAR(100)))
    SET @SQLUpdate = REPLACE(@SQLUpdate, '222222', CAST(@IDTO AS VARCHAR(100)))  
    SET @SQLDelete = REPLACE(@SQLDelete, '111111', CAST(@IDFROM AS VARCHAR(100)))
    SET @SQLDelete = REPLACE(@SQLDelete, '222222', CAST(@IDTO AS VARCHAR(100)))  

	  BEGIN TRANSACTION   
    BEGIN TRY 
      EXEC (@SQLUpdate)
	    IF (@Test = 0) 
      BEGIN
        EXEC (@SQLDelete)      
      END
	    COMMIT TRANSACTION
      SELECT 'Успешно' as Result
    END TRY 
    BEGIN CATCH 
      ROLLBACK TRANSACTION
      SELECT 'Ошибка' as Result
    END CATCH  	
  END

  
  --Показываем все SQL запросы для подмены ссылок, удаления объекта, поиска объекта в БД, поиска ссылок на объект в БД.
  IF (@Test = 1)
  BEGIN
    DECLARE @DoubleSQL TABLE (Updated datetime, 
                                        EntityBrief varchar(100), 
                                        SQLUpdate varchar(max), 
                                        SQLDelete varchar(max), 
                                        SQLExists   varchar(max), 
                                        SQLLink     varchar(max),
                                        SQLUpdateObject varchar(max),
										SQLDeleteUpdate varchar(max))
    INSERT INTO  @DoubleSQL
      SELECT *  FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
    --SELECT * INTO #Result FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
        
    UPDATE @DoubleSQL SET SQLUpdate = REPLACE(SQLUpdate, '111111', CAST(@IDFROM AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLUpdate = REPLACE(SQLUpdate, '222222', CAST(@IDTO AS VARCHAR(100)))
  	UPDATE @DoubleSQL SET SQLDelete = REPLACE(SQLDelete, '111111', CAST(@IDFROM AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLDelete = REPLACE(SQLDelete, '222222', CAST(@IDTO AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLExists = REPLACE(SQLExists, '111111', CAST(@IDFROM AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLExists = REPLACE(SQLExists, '222222', CAST(@IDTO AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLLink   = REPLACE(SQLLink,   '111111', CAST(@IDFROM AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLLink   = REPLACE(SQLLink,   '222222', CAST(@IDTO AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLUpdateObject = REPLACE(SQLUpdateObject,   '111111', CAST(@IDFROM AS VARCHAR(100)))
	  UPDATE @DoubleSQL SET SQLUpdateObject = REPLACE(SQLUpdateObject,   '222222', CAST(@IDTO AS VARCHAR(100)))
    SELECT * FROM @DoubleSQL	
  END
  
  --Проверка, если ли удаляемый объект в БД. Результат таблица из одной колонки CNT и одной записи.
  IF (@Test = 2)
  BEGIN
    SELECT @SQLExists = SQLExists FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
    SET @SQLExists = REPLACE(@SQLExists, '111111', CAST(@IDFROM AS VARCHAR(100)))
    SET @SQLExists = REPLACE(@SQLExists, '222222', CAST(@IDTO AS VARCHAR(100)))
	  --SELECT @SQLExists as SQLExists --Для тестирования.
    EXEC (@SQLExists)
  END

  --Текст запросов SQLLink показывает сколько объектов ссылается на удаляемый объект. 
  --Проверяются ссылки на предков тоже. Т.е. 3 - покажет количество ссылок на объект из других объектов.
  IF (@Test = 3)
  BEGIN
    SELECT @SQLLink = SQLLink FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
    SET @SQLLink   = REPLACE(@SQLLink,    '111111', CAST(@IDFROM AS VARCHAR(100)))
    SET @SQLLink   = REPLACE(@SQLLink,    '222222', CAST(@IDTO AS VARCHAR(100)))
    SELECT @SQLLink = @SQLLink FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
	  --SELECT @SQLLink --Для тестирования.
    EXEC (@SQLLink)
  END

  --Будут показаны таблицы (и созданы SQL запросы для изменения ссылок на удляемый 
  --объект - т.е. обновления только тех таблиц, в которых находятся ссылки на удаляемый объект).
  IF (@Test = 5)
  BEGIN
    SELECT @SQLUpdateObject =  SQLUpdateObject FROM dbo.DeleteDoubleSQL WHERE EntityBrief = @EntityBrief
    SET @SQLUpdateObject = REPLACE(@SQLUpdateObject,   '111111', CAST(@IDFROM AS VARCHAR(100)))
	  SET @SQLUpdateObject = REPLACE(@SQLUpdateObject,   '222222', CAST(@IDTO AS VARCHAR(100)))
    --SELECT @SQLUpdateObject
    EXEC (@SQLUpdateObject)
  END

END


