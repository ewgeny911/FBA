USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [dbo].[UpperFirstLetter]    Script Date: 14.03.2019 14:43:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[UpperFirstLetter](@before varchar(8000))
RETURNS varchar(8000) As
BEGIN
  SET @before = LTRIM(RTRIM(@before))
  --DECLARE @before VARCHAR(150) = 'МОСКВА FLOORING-REMPVAL INC'--'string!to string and?str.ing'
  DECLARE @after VARCHAR(255) = STUFF(LOWER(@before) , 1, 1, UPPER(SUBSTRING(@before,1,1)))

  DECLARE @i INT = 2
  DECLARE @symbol CHAR(1)

  WHILE @i <= LEN(@before)
  BEGIN
      SET @symbol = SUBSTRING(@before, @i, 1)
      IF @symbol IN (' ', '!', '.', '?', '-')
          IF @i + 1 <= LEN(@before)
              IF @symbol != '''' OR UPPER(SUBSTRING(@before, @i + 1, 1)) != 'S'
                  SET @after = STUFF(@after, @i + 1, 1,UPPER(SUBSTRING(@before, @i + 1, 1)))
      SET @i = @i + 1
  END
    
  SET @after = REPLACE(@after, ', ул Им ', ', ул им. ')
  SET @after = REPLACE(@after, ', Ул ', ', ул. ')
  SET @after = REPLACE(@after, ', Г ', ', г. ')
  SET @after = REPLACE(@after, ', Дом ', ', дом ')
  SET @after = REPLACE(@after, ', Квартира ', ', кв. ')  
  SET @after = REPLACE(@after, ', Квартира ', ', кв. ')
  SET @after = REPLACE(@after, 'г. Санкт-Петербург, г. Санкт-Петербург', 'г. Санкт-Петербург')
  SET @after = REPLACE(@after, 'г. Москва, г. Москва', 'г. Москва')
  SET @after = LEFT(@after, LEN(@after) - PATINDEX('%[^,]%', REVERSE(@after)) + 1)  --Убираем последнюю запятую, если есть.

  RETURN @after  
END

 