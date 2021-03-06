USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_ObjectsWithReference]    Script Date: 10.01.2018 9:59:58 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER Procedure [dbo].[spen_ObjectsWithReference] ( @EntityID int, @ObjectID int) AS
Begin
  Declare @ID int
  Declare @Parents Table (EntityID int)
  create Table #Objects (EntityID int, ObjectID int, AttributeBrief nvarchar(150)) 
  Declare @ABrief nvarchar(150) 
  Declare @TName nvarchar(150), @AFieldName nvarchar(150) 
  Declare @AID int, @AFieldName2 nvarchar(150), @TIDFieldName nvarchar(150)
  Declare @GoSQL nvarchar(500), @EntStr nvarchar(500) 

  set @EntStr = str(@EntityID)

  Select @ID = ParentID From enEntity Where ID = @EntityID
  while @ID is not null
  begin
    Insert @Parents Values (@ID)
    set @EntStr = @EntStr + ', ' + str(@ID)
    Select @ID = ParentID From enEntity Where ID = @ID
  end

  Insert @Parents Values (@EntityID)

  --Ссылки
  Declare LookUpsCursor Cursor For
  select A.AttributeID, A.Brief, T.Name, T.IDFieldName, A.FieldName from enAttribute A, enEntity E, enTable T 
    where A.refentityid in (select EntityID from @Parents) AND
    A.TableID = T.TableID AND E.ID = A.AttributeEntityID AND
    A.Type = 2 AND A.Kind = 1 and not (A.RefEntityID is null or A.RefEntityID = 0)

  Open LookUpsCursor
  Fetch From LookUpsCursor Into @AID, @ABrief, @TName, @TIDFieldName, @AFieldName
  while @@Fetch_Status = 0
  begin  
    set @GoSQL = 'select EntityID, ' + @TIDFieldName + ' as ObjectID, ''' + @ABrief + ''' as AttributeBrief' +
      ' from ' + @TName + ' where ' + @AFieldName + ' = ' + str(@ObjectID )

    INSERT #Objects EXECUTE (@GoSQL)  

    Fetch From LookUpsCursor Into @AID, @ABrief, @TName, @TIDFieldName, @AFieldName
  end

  Close LookUpsCursor
  Deallocate LookUpsCursor

  --Универсальные Ссылки
  Declare LookUpsCursor Cursor For
  select A.AttributeID, A.Brief, T.Name, T.IDFieldName, A.FieldName, A.FieldName2 from enAttribute A, enEntity E, enTable T 
    where A.TableID = T.TableID AND E.ID = A.AttributeEntityID AND
    A.Type = 3 AND A.Kind = 1

  Open LookUpsCursor
  Fetch From LookUpsCursor Into @AID, @ABrief, @TName, @TIDFieldName, @AFieldName, @AFieldName2
  while @@Fetch_Status = 0
  begin  
    set @GoSQL = 'select EntityID, ' + @TIDFieldName + ' as ObjectID, ''' + @ABrief + ''' as AttributeBrief ' +
        + ' from ' + @TName + 
        + ' where ' + @AFieldName + ' = ' + str(@ObjectID ) + 
        + ' and ' + @AFieldName2 + ' in ( '+ @EntStr + ' )'

    INSERT #Objects EXECUTE (@GoSQL)  

    Fetch From LookUpsCursor Into @AID, @ABrief, @TName, @TIDFieldName, @AFieldName, @AFieldName2
  end

  Close LookUpsCursor
  Deallocate LookUpsCursor
  select distinct * from #Objects
  drop table #Objects
  return
end