USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_UserLockInfo]    Script Date: 10.01.2018 10:02:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_UserLockInfo]
  @EntityID INT,
  @ObjectID INT,
  @SID      INT OUTPUT,
  @Result   INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

  DECLARE @LockCode NVARCHAR(255), @LockCode2 NVARCHAR(255), @trancount_in INT,
    @LockCodeInSysLockInfo NCHAR(32)
  -- 1. Получим код блокировки
  EXEC dbo.spen_UserLock_GetCode @EntityID = @EntityID,
                            @ObjectID = @ObjectID,
                            @LockCode = @LockCode OUTPUT

  -- 2. Путем некоторых ухищрений получим по коду блокировки значение,
  -- которым блокировка идентифицируется в таблице syslockinfo
  SET @LockCode2 = 'TEST'+SUBSTRING(@LockCode, 5, 255)
  SET @trancount_in = @@TRANCOUNT
  IF @trancount_in=0
    BEGIN TRAN
  EXEC sp_getapplock @Resource=@LockCode2, @LockMode='Shared', @LockOwner='Transaction', @LockTimeout=0

  SELECT @LockCodeInSysLockInfo = LEFT(@LockCode,4)+SUBSTRING(rsc_text,5,255)
  FROM master..syslockinfo
  WHERE left(rsc_text,4)='TEST' AND rsc_type=10 AND req_mode=3 AND req_spid=@@spid
  -- 3. Теперь получим SPID того процесса, который наложил требуемую блокировку
  SELECT @SID = req_spid
  FROM master..syslockinfo
  WHERE rsc_text = @LockCodeInSysLockInfo

  SET @Result = CASE WHEN @SID IS NULL THEN 1 ELSE 0 END

  EXEC sp_releaseapplock @Resource=@LockCode2, @LockOwner='Transaction'
  IF @trancount_in=0
    COMMIT TRAN  

  RETURN 0
END
