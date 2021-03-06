USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_LockObject]    Script Date: 10.01.2018 9:59:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_LockObject]
@EntityID INT,
@ObjectID INT,
@Result   INT OUTPUT
AS
BEGIN
  DECLARE @LockCode NVARCHAR(255)

  EXEC dbo.spen_UserLock_GetCode @EntityID = @EntityID,
                            @ObjectID = @ObjectID,
                            @LockCode = @LockCode OUTPUT
  EXEC @Result=sp_getapplock @Resource=@LockCode, @LockMode='Exclusive', @LockOwner='Session', @LockTimeout=0

  RETURN @Result
END
