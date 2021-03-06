USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [Q_DIAFA].[DOCALL]    Script Date: 10.01.2018 10:05:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*
SELECT [Q_DIAFA].[DOCALL] ('RLS.Resolve', '
<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<RequestResolve schemaVersion="1.0" xmlns="http://ws.rls10" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
xsi:schemaLocation="http://ws.rls10 http://integration.vtbins.ru/schema/wsrls-1.0.xsd">
        <RltId>PERSONS</RltId>
        <Source>
                <Id>4534578</Id>
                <SysId>DIAFA</SysId>
                <Type>PERSONS</Type>
        </Source>
        
</RequestResolve>
') as Result
*/


ALTER FUNCTION [Q_DIAFA].[DOCALL](
  @p_handler    NVARCHAR(512),
  @p_requestXml NVARCHAR(MAX)
)
  RETURNS NVARCHAR(MAX)
AS
BEGIN
  SET @p_requestXml = '<![CDATA[' + @p_requestXml + ']]>'
--  RETURN ISNULL(Q_DIAFA.CALL_WS(@p_handler, @p_requestXml, 'http://ws-prod:8080/WebService', N'DIAFA', N'Q49XbxxC'), '0');
    RETURN ISNULL(Q_DIAFA.CALL_WS_CLR(@p_handler, @p_requestXml, 'http://ws-prod:8080/WebService', N'DIAFA', N'Q49XbxxC'), '0');
END