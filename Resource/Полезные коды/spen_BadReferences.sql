USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_BadReferences]    Script Date: 10.01.2018 9:56:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Procedure [dbo].[spen_BadReferences] AS
Begin
  create Table #Objects (EntityID int, EntityName nvarchar(150), ObjectID int, AttrID int, AttrName nvarchar(150), ValEntityID int, ValObjectID int) 
  create Table #Entities (EntityID int) 
  Declare @AttributeID int, @AName nvarchar(150), @EID int, @EName nvarchar(150) 
  Declare @TName nvarchar(150), @AFieldName nvarchar(150) 
  Declare @AFieldName2 nvarchar(150), @TIDFieldName nvarchar(150)
  Declare @REID int, @RTName nvarchar(150), @RTIDFieldName nvarchar(150)
  Declare @GoSQL nvarchar(1000), @s nvarchar(500), @EntityID int

  --Ссылки
  Declare LookUpsCursor Cursor For
  select A.AttributeID, A.Name, E.ID, E.Name, T.Name, T.IDFieldName, A.FieldName, RE.ID, RT.Name, RT.IDFieldName 
    from enAttribute A, enEntity E, enTable T, enTable RT, enEntity RE
    where A.TableID = T.TableID AND A.RefEntityID = RE.ID AND 
    E.ID = A.AttributeEntityID AND
    RT.TableID = (Select Top 1 TableID from enTable where TableEntityID = A.RefEntityID AND Type = 1 order by TableID) AND
    A.Type = 2 AND A.Kind = 1 and not (A.RefEntityID is null or A.RefEntityID = 0)

  Open LookUpsCursor
  Fetch From LookUpsCursor Into @AttributeID, @AName, @EID, @EName, @TName, @TIDFieldName, @AFieldName, @REID, @RTName, @RTIDFieldName
  while @@Fetch_Status = 0
  begin  
    Declare EntitiesChildrens Cursor For
      select ObjectID as EntityID from dbo.fnen_enEntity_ParentID_SubLevels() where ParentID = @EID
    
    Open EntitiesChildrens  
    set @s = ''
    Fetch From EntitiesChildrens Into @EntityID
    while @@Fetch_Status = 0
    begin
      set  @s = @s + str(@EntityID) + ', '
      Fetch From EntitiesChildrens Into @EntityID
    end
    Close EntitiesChildrens
    Deallocate EntitiesChildrens
    set @s = @s + str(@EID)

    set @GoSQL = 'select ' + @TName + '.EntityID, ''' + @EName + ''', ' + 
      @TName + '.' + @TIDFieldName + ' as ObjectID, ' +
      str(@AttributeID) + ', ''' + @AName + ''', ' +
      str(@REID) + ', ' + @TName + '.' + @AFieldName + ' ' +
      ' from ' + @TName +
      ' where ' + @TName + '.' + 'EntityID in (' + @s + ') and ' +
      @TName + '.' + @AFieldName + ' is not null and not ' + @TName + '.' + @AFieldName  + ' = 0' +
      ' and not exists (select _' + @RTName + '.' + @RTIDFieldName + ' from ' + @RTName + ' as _' + @RTName +
      ' where _' + @RTName + '.' + @RTIDFieldName + ' = ' + @TName + '.' + @AFieldName + ')'

    INSERT #Objects EXECUTE (@GoSQL)

    Fetch From LookUpsCursor Into @AttributeID, @AName, @EID, @EName, @TName, @TIDFieldName, @AFieldName, @REID, @RTName, @RTIDFieldName
  end

  Close LookUpsCursor
  Deallocate LookUpsCursor

  --Универсальные Ссылки
  Declare LookUpsCursor Cursor For
  select A.AttributeID, A.Name, E.ID, E.Name, T.Name, T.IDFieldName, A.FieldName, A.FieldName2
    from enAttribute A, enEntity E, enTable T
    where A.TableID = T.TableID AND E.ID = A.AttributeEntityID AND
    A.Type = 3 AND A.Kind = 1

  Open LookUpsCursor
  Fetch From LookUpsCursor Into @AttributeID, @AName, @EID, @EName, @TName, @TIDFieldName, @AFieldName, @AFieldName2
  while @@Fetch_Status = 0
  begin  

    --Какие сущности нужно искать
    Declare EntitiesChildrens Cursor For
      select ObjectID as EntityID from dbo.fnen_enEntity_ParentID_SubLevels() where ParentID = @EID
    Open EntitiesChildrens  
    set @s = ''
    Fetch From EntitiesChildrens Into @EntityID
    while @@Fetch_Status = 0
    begin
      set  @s = @s + str(@EntityID) + ', '
      Fetch From EntitiesChildrens Into @EntityID
    end
    Close EntitiesChildrens
    Deallocate EntitiesChildrens
    set @s = @s + str(@EID)
    
    --Какие там привязанные сущности встречаются
    set @GoSQL = 'select ' + @AFieldName2 + ' as ObjectEntityID from ' + @TName +
      ' where ' + @TName + '.' + 'EntityID in (' + @s + ') and ' +
      @TName + '.' + @AFieldName2 + ' is not null and not ' + @TName + '.' + @AFieldName2  + ' = 0' +
      ' group by ' + @TName + '.' + @AFieldName2
    
    delete from #Entities
    
    INSERT #Entities EXECUTE (@GoSQL)

    Declare LinkedEntities Cursor For
      Select RE.EntityID, RT.Name, RT.IDFieldName From #Entities RE, 
        enTable RT 
        Where RT.TableID = (Select Top 1 TableID From enTable Where TableEntityID = RE.EntityID AND Type = 1 order by TableID)

    Open LinkedEntities
    Fetch From LinkedEntities Into @REID, @RTName, @RTIDFieldName
    while @@Fetch_Status = 0
    begin

      set @GoSQL = 'select ' + @TName + '.EntityID, ''' + @EName + ''', ' + 
        @TName + '.' + @TIDFieldName + ' as ObjectID, ' +
        str(@AttributeID) + ', ''' + @AName + ''', ' +
        @TName + '.' + @AFieldName2 + ', ' + @TName + '.' + @AFieldName + ' ' +
        ' from ' + @TName +
        ' where ' + @TName + '.' + 'EntityID in (' + @s + ') and ' + 
        @TName + '.' + @AFieldName2 + ' = ' + str(@REID) + ' and ' +
        @TName + '.' + @AFieldName + ' is not null and not ' + @TName + '.' + @AFieldName  + ' = 0' +
        ' and not exists (select _' + @RTName + '.' + @RTIDFieldName + ' from ' + @RTName + ' as _' + @RTName +
        ' where _' + @RTName + '.' + @RTIDFieldName + ' = ' + @TName + '.' + @AFieldName + ')'
  
      INSERT #Objects EXECUTE (@GoSQL)

      Fetch From LinkedEntities Into @REID, @RTName, @RTIDFieldName
    end
    Close LinkedEntities
    Deallocate LinkedEntities
    
    --Объект заполенен, но сущность не проставлена
    set @GoSQL = 'select ' + @TName + '.EntityID, ''' + @EName + ''', ' + 
      @TName + '.' + @TIDFieldName + ' as ObjectID, ' +
      str(@AttributeID) + ', ''' + @AName + ''', ' +
      @TName + '.' + @AFieldName2 + ', ' + @TName + '.' + @AFieldName + ' ' +
      ' from ' + @TName +
      ' where ' + @TName + '.' + 'EntityID in (' + @s + ') and ' + 
      '(' + @TName + '.' + @AFieldName2 + ' = 0 or ' + @TName + '.' + @AFieldName2 + ' is null) and ' +
      @TName + '.' + @AFieldName + ' is not null and not ' + @TName + '.' + @AFieldName  + ' = 0'

    INSERT #Objects EXECUTE (@GoSQL)

    Fetch From LookUpsCursor Into @AttributeID, @AName, @EID, @EName, @TName, @TIDFieldName, @AFieldName, @AFieldName2
  end

  Close LookUpsCursor
  Deallocate LookUpsCursor

  select * from #Objects
  drop table #Objects
  drop table #Entities
	return
end