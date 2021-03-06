USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_SendInsuredBLList]    Script Date: 10.01.2018 10:00:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spen_SendInsuredBLList]
AS
BEGIN 
  --Описание:
  --Хранимая процедура которая запускается по таймеру на форме TimerWorkFU или по джобу в MSSQL.
  --Для формирвоания текста XML списка застрахованных для передачи в "Черный список"
  --ИД договоров и доп. соглашений берутся отсюда: SELECT * FROM dbo.UploadContractsToBL   
  --Возвращает таблицу сформирванных XML: Статус, Кол-во застрахованных
  --Пример вызова (процедура без параметров): 
  --EXEC [dbo].[spen_SendInsuredBLList]
  
  --Тестирование:
  --select * from dbo.UploadContractsToBL
  --select top 100 * from Q_DIAFA.DATA_OUT_LOG order by RECORD_DATE desc
  --select top 100 * from Q_DIAFA.DATA_OUT order by RECORD_DATE desc
  --Update dbo.UploadContractsToBL set Status = 'Новый' where CID = 35
  
  DECLARE @CID int = 0
  DECLARE @AID int = 0
  DECLARE @ObjectID int
  DECLARE @ObjectEnID int
  DECLARE @UserName varchar(100)
  DECLARE @KindDocument int
  DECLARE @Status varchar(15)
  DECLARE @CountIns int
  DECLARE @WTime datetime

  --Select * from UploadContractsToBL 
  --DECLARE @ResultXML TABLE ([Status] varchar(max), CountIns int, CID int, AID int, UserName varchar(max))   
  DECLARE ListDoc CURSOR DYNAMIC FOR 
    SELECT DISTINCT TOP 10000 --!
      EOT_1.KindDocument, 
      EOT_2.Brief as UserName,  
      EOT_1.ObjectID, 
      EOT_1.ObjectEnID, 
      EOT_1.WTime 
    FROM dbo.UploadContractsToBL EOT_1
      Left Outer Join ApplicationUser EOT_2 On EOT_2.UserID = EOT_1.UserID 
    WHERE [EOT_1].[Status] = 'Новый'
    ORDER BY EOT_1.WTime
  
  --IF (@@CURSOR_ROWS = 0) --Кол-во записей в курсоре.
  --BEGIN
  --  SELECT 'Нет записей' as [Status], 0 as CountIns, 0 as CID, 0 as AID, 'diasoft' as UserName
  --  RETURN
  --END
   
  OPEN ListDoc  
  FETCH FIRST FROM ListDoc INTO @KindDocument, @UserName, @ObjectID, @ObjectEnID, @WTime
  WHILE @@Fetch_Status = 0
  BEGIN
    IF (@ObjectEnID = 1694) --1694 - ДогСтрах
    BEGIN 
      SET @CID = @ObjectID
      SET @AID = 0 
    END 
    IF (@ObjectEnID = 1640) --1640 - ДопСоглашение
    BEGIN 
      SET @CID = 0 
      SET @AID = @ObjectID
    END 
	   
    --Вызов хранимки spen_SendInsuredBLOne для формирования XML.
    --В Шину (PUT_VALUE) вставится уже в хранимке spen_SendInsuredBLOne
    --INSERT INTO @ResultXML ([Status], CountIns, CID, AID, UserName) 	
	  EXEC [dbo].[spen_SendInsuredBLOne] @CID, @AID, @UserName, 0
    
	--SELECT TOP 1 @Status = Status, @CountIns = CountIns FROM @ResultXML   
    --UPDATE dbo.UploadContractsToBL SET [Status] = @Status, UTime = GetDate() WHERE ObjectID = @ObjectID        
    
	FETCH NEXT FROM ListDoc INTO @KindDocument, @UserName, @ObjectID, @ObjectEnID, @WTime
  END 
  
  CLOSE ListDoc
  DEALLOCATE ListDoc
  --SELECT * FROM @ResultXML
END

--INSERT INTO dbo.UploadContractsToBL (EntityID, KindDocument, UserID, [Status], WTime, ObjectID, OnjectEnID) VALUES (1883, 0, 361, 'Íîâûé', GetDate(), 1868668, 1694) 
