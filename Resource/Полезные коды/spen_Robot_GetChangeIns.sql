USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_Robot_GetChangeIns]    Script Date: 13.03.2019 10:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
ALTER PROCEDURE [dbo].[spen_Robot_GetChangeIns] (@DateChange datetime, @UserID int, @StatusID int, @CID int, @AID int) 
AS
  --Пример вызова: 
  --EXEC [dbo].[spen_Robot_GetChangeIns] NULL, 361, NULL, 5144077, 0 

  --Вызов хранимки для того чтобы внести в таблицу все изменения по застрахованным по договору и(или) допу 
  --Здесь StatusID - это ИД Статус Объекта доп.соглашения или договора.
  --Параметр обязательный потому что переводов в "Проведено", например, у доп. соглашения может быть несколько и 
  --на каждое проведение может добавится какое-то количество застрахованных. 
  --Например, загрузили застрахованных в договор, перевели в "Действует". Потом вспомнили, что забыли догрузить ещёё 5 чел.
  --Опять перевели договор в "Проект", догрузили ещё этих 5 чел. и опять перевели в "Действует".
  --У застрахованных у всех одно Основание и другие атрибуты, поэтому только по данным Застрахованных 
  --не определить, на каком изменении статуса они были добавлены. Единственный способ определить, что это новые застрахованнные,
  --это посмотреть нет ли в таблице dbo.Robot_ChangeDate застрахвоанных, у которых опреация Прикрепление и такие-же CID и AID.  
  
  
  DELETE FROM dbo.Robot_ChangeDate WHERE ISNULL(StatusID, 0) = ISNULL(@StatusID, 0)
  
  INSERT INTO dbo.Robot_ChangeDate 
      ([DateChange]
      ,[DateCreate]
      ,[UserID]
      ,[StatusID]
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
      ,[OldAddress]
      ,[PrePay])  
  EXEC [dbo].[spen_Robot_GetChangeAID] @DateChange, @UserID, @StatusID, @CID, @AID, 0
          
  --SELECT * FROM  dbo.Robot_ChangeDate
  --DELETE FROM dbo.Robot_ChangeDate

  --SELECT COUNT(LPU) AS LPU, COUNT(Insured) AS CountInsured, COUNT(*) AS CountRows FROM dbo.Robot_ChangeDate 
  --WHERE ISNULL(StatusID, 0) = ISNULL(@StatusID, 0) AND CID = @CID AND AID = @AID --GROUP BY LPU
   
  SELECT COUNT(DISTINCT LPU) AS CountLPU, COUNT(DISTINCT Insured) AS CountInsured, COUNT(*) AS CountRows FROM dbo.Robot_ChangeDate              
  WHERE ISNULL(StatusID, 0) = ISNULL(@StatusID, 0) AND CID = @CID AND AID = @AID      
        
        --SELECT     DISTINCT LPU FROM dbo.Robot_ChangeDate   
   --EXEC [dbo].[spen_Robot_GetChangeIns] 361, 7608695, 4264894, 5144055
   --select top 100 * from dbo.Robot_ChangeDate
    --EXEC [dbo].[spen_Robot_GetChangeIns] 361, 7608695, 4264894, 5144055
   --SELECT t2.Kod, COUNT(Insured) AS CountIns 
   --FROM dbo.Robot_ChangeDate t1
   --  LEFT JOIN LPU t2 ON t2.ID = t1.LPU
   --  WHERE DateCur = GETDATE()
   --GROUP BY t2.Kod
  

   /*select top 10 * from LPU
   Select * From LPUUnitLetter
   Select * From LPU
   Select * From AdressType
   Select * From RepTempl
   Select * From Robot_ChangeDate
   delete from Robot_ChangeDate
   
   SELECT * FROM
   (
   SELECT 
     t2.LPUID, 
     t6.Kod AS Area, 
     t4.Kod AS LPUCode, 
     t4.Name AS LPUName, 
     t2.TypeOfLetter, 
     t2.TemplateID, 
     t3.Name AS TemplateName, 
     t3.Brief AS TemplateBrief,  
     t5.Name AS SendingType, 
     t3.RepType, 
     t4.Email,
     Count(t1.LPU) AS InsCount
   FROM dbo.Robot_ChangeDate t1
     LEFT OUTER JOIN LPUUnitLetter t2 ON t2.LPUID        = t1.LPU       
     LEFT OUTER JOIN RepTempl      t3 ON t3.RepTemplID   = t2.TemplateID
     LEFT OUTER JOIN LPU           t4 ON t4.ID           = t1.LPU   
     LEFT OUTER JOIN AdressType    t5 ON t5.AdressTypeID = t4.MethodOfSending
     LEFT OUTER JOIN Area          t6 ON t6.AreaID = t4.Area    
   WHERE 
     DateCur = '2018-12-28 00:00:00.000'    
     AND t2.TypeOfLetter < 13
     AND ISNULL(t2.PrintLetter, 0) = 1     
     --AND t1.CID = 12345
     --AND t2.AID = 12345
     --AND t1.LPU = 823
     --AND t2.TemplateID = 12345
   GROUP BY 
     t2.LPUID, 
     t6.Kod, 
     t4.Kod, 
     t4.Name, 
     t2.TypeOfLetter, 
     t2.TemplateID, 
     t3.Name, 
     t3.Brief, 
     t5.Name, 
     t3.RepType,
     t4.Email 
   ) tob





Select TypeOfLetter, COUNT(*) From LPUUnitLetter group by TypeOfLetter order by TypeOfLetter

Select t2.*, t3.RepType From LPUUnitLetter t2
LEFT OUTER JOIN RepTempl t3 ON t3.RepTemplID   = t2.TemplateID
where  t2.TypeOfLetter = 2


select * from RepTempl
*/