USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_UserLockInfo2]    Script Date: 10.01.2018 10:02:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_UserLockInfo2] 
  @EntityID INT,
  @ObjectID INT,
  @LockInfo VARCHAR(150) OUTPUT,
  @SID      INT OUTPUT
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

  SELECT @LockInfo = US.Brief + '|' + SS.Brief + '|' + HostName
  FROM master.dbo.sysprocesses SP
  INNER JOIN ApplicationUser US ON CONVERT(INT,SUBSTRING(SP.context_info,1,4)) = US.UserID
  INNER JOIN enSubSystem SS ON CONVERT(INT,SUBSTRING(SP.context_info,5,4)) = SS.SubSystemID
  WHERE SP.SPID = @SID

  EXEC sp_releaseapplock @Resource=@LockCode2, @LockOwner='Transaction'
  IF @trancount_in=0
    COMMIT TRAN  
END

