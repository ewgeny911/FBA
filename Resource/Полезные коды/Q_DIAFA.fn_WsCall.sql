USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [Q_DIAFA].[fn_WsCall]    Script Date: 10.01.2018 10:05:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
ALTER FUNCTION [Q_DIAFA].[fn_WsCall](@requestUrl [nvarchar](200), @username [nvarchar](100), @password [nvarchar](100), @requestXml [nvarchar](max))
RETURNS [nvarchar](max) WITH EXECUTE AS CALLER
AS 
EXTERNAL NAME [WsCall].[UserDefinedFunctions].[fn_ws_call]