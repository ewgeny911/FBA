USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_Robot_GetDateChange]    Script Date: 06.03.2019 11:42:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
ALTER PROCEDURE [dbo].[spen_Robot_GetDateChange] (@DateChange datetime, @CID int, @AID int, @Test int) 
AS
  --������ ��������� ��������� �������, � ������� ���� �� ��������� � ���. ����������, ������ ������� ��� ������:
  --1. ���� ��� �������, �� ������ ������ �� "���������".
  --2. ���� ��� ���. ����������, �� ������ ������ �� "���������".
  --������ ������� �� ����������� � � �������������� ������� �� ��������.
  --��� �������� ����� ��� ������ �������� ����� � ���.
  --������������ ������ � ������ DMS_CLPU_Print_FaceLetterRobot_FU.    
 
  --������ ������: 
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-02-13 10:10:00.000', 0, 0, 2 
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-02-12 10:10:00.000', 3773137, 4686601, 2
  -- EXEC [dbo].[spen_Robot_GetDateChange] '2019-04-01 00:00:00.000', 0, 0, 2
     
  IF (@Test NOT IN (0,1,2)) 
  BEGIN
    SELECT 
    '�������� �����. �������� Test ����� ��������� ���� �� ��������� ��������: ' + CHAR(13) + CHAR(10) +
    '0 - ���������� ������' + CHAR(13) + CHAR(10) +
    '1 - ���������� ���������� � ���������' + CHAR(13) + CHAR(10) +
    '2 - ��������� ������ ���������� � ���������' AS ErrorText
    RETURN
  END  

  --���� ���� ���� � ������� ������ � ��������, �� ����� �������.
  --����� � �������� ����� ���� ����� ��� �������.
  --��� ����� ��������
  SET @DateChange = CAST(@DateChange AS Date)
 
  /*
  --��������
  SELECT DISTINCT
    t1.���������         AS StatusID,
    t1.�������������     AS DateChange,
    t1.������.���������  AS CID,
    0                    AS AID,
    t4.�����             AS Number,
    t1.������������.���� AS Imp
  FROM ������������� t1
    LEFT JOIN ��������       t2 ON t2.���������  = t1.������.���������
    LEFT JOIN �������������  t3 ON t3.��������   = t1.������.���������
    LEFT JOIN ��������       t4 ON t4.���������  = t1.������.���������
   WHERE t1.������.���������� = 1694
         AND CAST(t1.������������� AS Date) = '21.12.2018'
         AND (t3.�������� IS NULL OR t2.���������� = t3.����������) --��� ���� ������� � ��� �� ����� ����, �� ������� �� �������� � ������.
         AND t1.������.���� = '���������'
         AND t2.����������� < 3

  --���������� �������� � ����� � ���� �������.
  UNION ALL

  --�������������
  SELECT--TOP 1 --DISTINCT
    t1.���������        AS StatusID,
    t1.�������������    AS DateChange,
    t3.���������        AS CID,
    t1.������.��������� AS AID,
    t4.�����            AS Number,
    t1.������������.���� AS Imp
  FROM ������������� t1
    LEFT JOIN �������������  t2 ON t2.���������  = t1.������.���������
    LEFT JOIN ��������       t3 ON t3.���������  = t2.��������
    LEFT JOIN ��������       t4 ON t4.���������  = t1.������.���������
   WHERE t1.������.���������� = 1640
         AND CAST(t1.������������� AS Date) = '12.02.2019'
         AND t3.��������� IS NOT NULL
         AND t1.������.���� = '���������'
         AND t3.����������� < 3
         AND t2.������.���� <> '������������������'
  */

  --��������� ������ ������� ��������� ��������� � ���. ���������� �� ���� (@DateChange), ������� �������� � ���� ���������.
  --�.�. ����� ���� ��������� � ������, � ������� ���� ��������� ������� = @DateChange
   
  --1. ��������
  SELECT CONVERT(bit, 0) Checked, StatusID, DateChange, CID, AID, Number, Imp, COUNT(t1.ID) AS CountIns, (((COUNT(t1.ID) * 240) / 60000) + 5) AS PrepareSec, CAST(NULL As int) AS TotalSec, CAST(NULL As int) AS TotalMin 
  INTO #tob FROM
  ( 
  Select
  Distinct
  EOT_1.ID         "StatusID",
  EOT_1.DateChange "DateChange",
  EOT_1.ObjectID   "CID",
  0 "AID",
  EOT_13.Number "Number",
  EOT_14.Name "Imp"
From
  StatusObject EOT_1
  Left Outer Join Status EOT_15
    On EOT_15.ID = EOT_1.Status_ID
  Left Outer Join ApplicationUser EOT_14
    On EOT_14.UserID = EOT_1.ApplicationUser_ID
  LEFT JOIN ContractIns EOT_2 Left Outer Join ContractIns_Hist_StartDate EOT_6
    On (EOT_6.ID = EOT_2.CID) And (EOT_6.StateDate = (
      Select
        Max(StateDate)
      From
        ContractIns_Hist_StartDate
      Where
        (StateDate <= Convert(DateTime, '20300225 23:59:59', 112)) And (EOT_2.CID = ID)
    ))
    On EOT_2.CID = EOT_1.ObjectID
  LEFT JOIN AdditionAgreement EOT_11 On EOT_11.Document = EOT_1.ObjectID
  LEFT JOIN Document EOT_13 On EOT_13.DocumentID = EOT_1.ObjectID
Where
  EOT_1.ObjectEntityID = 1694 
  AND CAST(EOT_1.DateChange AS Date) = @DateChange 
  AND (EOT_11.Document IS NULL OR EOT_6.StartDate = EOT_11.StartDate) 
  AND EOT_15.Brief = '���������' 
  AND EOT_2.TypeContract < 3
  AND (EOT_1.ObjectID = @CID OR @CID = 0)
  AND (@AID = 0)

  --���������� �������� � ����� � ���� �������.
  Union All
  
  --2. �������������  
 Select
  EOT_1.ID         "StatusID",
  EOT_1.DateChange "DateChange",
  EOT_4.CID        "CID",
  EOT_1.ObjectID   "AID",
  EOT_13.Number    "Number",
  EOT_14.Name      "Imp"
From
  StatusObject EOT_1
  Left Outer Join Status EOT_15
    On EOT_15.ID = EOT_1.Status_ID
  Left Outer Join ApplicationUser EOT_14
    On EOT_14.UserID = EOT_1.ApplicationUser_ID
  LEFT JOIN AdditionAgreement EOT_2 Inner Join Document EOT_3
    On EOT_3.DocumentID = EOT_2.ID
    On EOT_2.ID = EOT_1.ObjectID
  Left Outer Join KindDocument EOT_16 Inner Join KindObject EOT_17
    On EOT_17.ID = EOT_16.ID
    On EOT_16.ID = EOT_3.KindDocument
  LEFT JOIN ContractIns EOT_4
    On EOT_4.CID = EOT_2.Document
  LEFT JOIN Document EOT_13
    On EOT_13.DocumentID = EOT_1.ObjectID
Where
  EOT_1.ObjectEntityID = 1640 
  AND CAST(EOT_1.DateChange AS Date) = @DateChange 
  AND EOT_4.CID IS NOT NULL 
  AND EOT_15.Brief = '���������' 
  AND EOT_4.TypeContract < 3 
  AND EOT_17.Brief <> '������������������'
  AND (EOT_4.CID = @CID OR @CID = 0)
  AND (EOT_1.ObjectID = @AID OR @AID = 0)
   ) tob
  LEFT JOIN RelContFace t1 on t1.ContractID = tob.CID
  GROUP BY StatusID, DateChange, CID, AID, Number, Imp
  

  --��������� ��������� �����, ������ ���� ��������� �� ��������� ���������� � ���. �����������
  --��� ����� ����� ������ ��������� dbo.spen_Robot_GetChangeAID, ������� ����� ���������� � ���������� 
  --���� ����� �� ������ ������ � ������� #tob. ��� ������ ��� ��������, ����� �� ������� ��� �� �������.
  UPDATE #tob SET TotalSec = (SELECT SUM(PrepareSec) FROM #tob)
  UPDATE #tob SET TotalMin = (SELECT TOP 1 (TotalSec / 60.00) + 1 FROM #tob)           
   
  DECLARE @DocCount int
  SELECT @DocCount = COUNT(*) FROM #tob 

  IF (@Test = 0) 
  BEGIN
    SELECT * FROM #tob ORDER BY Number
    RETURN
  END

  IF (@Test = 1) 
  BEGIN
    SELECT @DocCount AS DocCount
    RETURN
  END

  IF (@Test = 2) 
  BEGIN
    SELECT * FROM #tob ORDER BY DateChange
    RETURN
  END  



  --������ ��������� �� ����� �����
  /*DELETE FROM dbo.Robot_DateChange --WHERE DateCur < CAST(GETDATE() AS Date)  
  DECLARE @StatusID int 
  DECLARE ListDoc CURSOR DYNAMIC FOR SELECT StatusID, CID, AID FROM #tob ORDER BY CID, AID                
  OPEN ListDoc 
  FETCH FIRST FROM ListDoc INTO @CID, @AID
  WHILE @@Fetch_Status = 0
  BEGIN
  
    --����� �������� ��� ���� ����� ������ � ������� ��� ��������� �� �������������� �� �������� �(���) ����    
    INSERT INTO     
    dbo.Robot_DateChange 
        ([StatusID]
      ,[CID]
      ,[AID]
      ,[DateCur]
      ,[DateCur_1]
      ,[DatePrev]
      ,[IsLong]
      ,[IDV]
      ,[Insured]
      ,[ActionIns]
      ,[ActionPers]
      ,[ActionAdr]
      ,[ChangeVar]
      ,[ChangeProgram]
      ,[ChangeFam]
      ,[ChangeIm]
      ,[ChangeOt]
      ,[ChangeBirth]
      ,[OV]
      ,[OFil]
      ,[OldBirthDate]
      ,[LPU]
      ,[Programms]
      ,[IDProgrammss]
      ,[IDProgramms]
      ,[FIO]
      ,[Policy]
      ,[PolicyStart]
      ,[PolicyEnd]
      ,[StartDate]
      ,[Enddate]
      ,[Name1]
      ,[Name2]
      ,[Name3]
      ,[BirthDate]
      ,[OldName1]
      ,[OldName2]
      ,[OldName3]
      ,[PhoneHome]
      ,[PhoneWork]
      ,[PhoneMobile]
      ,[Sex]
      ,[Position]
      ,[InsurerName]
      ,[RelInsurer]
      ,[WorkPlace]
      ,[InsRegion]
      ,[WorkPlaceAddr]
      ,[SSDate]
      ,[Address]
      ,[OldAddress])  
    EXEC [dbo].[spen_Robot_GetChangeAID] @StatusID, @CID, @AID
          
    FETCH NEXT FROM ListDoc INTO @StatusID, @CID, @AID
  END 
  
  CLOSE ListDoc
  DEALLOCATE ListDoc
  
  SELECT @DocCount AS DocCount, COUNT(*) AS InsCount FROM dbo.Robot_DateChange WHERE DateCur = @DateChange
  */
       
  --SELECT LPU, COUNT(*) AS CountIns FROM dbo.Robot_DateChange WHERE DateCur = GETDATE() GROUP BY LPU
  --SELECT LPU AS "LPU ID", COUNT(*) AS "���������� ��������������" FROM dbo.Robot_DateChange WHERE DateCur = GETDATE() GROUP BY LPU