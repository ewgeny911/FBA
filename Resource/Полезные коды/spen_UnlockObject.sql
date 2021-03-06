USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_UnlockObject]    Script Date: 10.01.2018 10:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_UnlockObject]
@EntityID INT,
@ObjectID INT,
@Result   INT OUTPUT
AS
BEGIN
  DECLARE @LockCode NVARCHAR(255)

  EXEC dbo.spen_UserLock_GetCode @EntityID = @EntityID,
                            @ObjectID = @ObjectID,
                            @LockCode = @LockCode OUTPUT
  EXEC @Result=sp_releaseapplock @Resource=@LockCode, @LockOwner='Session'

  RETURN @Result
END
