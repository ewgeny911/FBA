USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_UserLock_GetCode]    Script Date: 10.01.2018 10:01:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_UserLock_GetCode]
  @EntityID INT,
  @ObjectID INT,
  @LockCode NVARCHAR(255) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

  DECLARE @RootEntityID INT

  -- 1. Получим ID корневой сущности
  SELECT TOP 1 @RootEntityID = ParentID
  FROM enEntity_LVL
  WHERE ObjectID = @EntityID
  ORDER BY ObjectLevel DESC

  IF @RootEntityID IS NULL
  BEGIN
    RAISERROR ('Сущность ИДСущности=%d не найдена !', 16,1, @EntityID)
    RETURN -999
  END
  -- 2. Поставим блокировку
  SET @LockCode='DS_MASTER_'+CONVERT(VARCHAR,@RootEntityID)+'_'+CONVERT(VARCHAR,@ObjectID)

  RETURN 0
END

