USE [DIASOFT]
GO
/****** Object:  StoredProcedure [dbo].[spen_TEMPTABLE]    Script Date: 10.01.2018 10:01:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[spen_TEMPTABLE]( 	 
  @QUERYSTRING text   
) AS 

Exec(@QUERYSTRING)





