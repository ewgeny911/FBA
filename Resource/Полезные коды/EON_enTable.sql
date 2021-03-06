USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [dbo].[EON_enTable]    Script Date: 03.07.2018 11:40:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Function [dbo].[EON_enTable](@ObjectID int)
Returns varchar(200) As
Begin
  Declare @R varchar(200)
/*------------------------------*/
Select
@R
=
RTrim(
IsNull(
EOT_1.Name,
'')
+
Case
When
EOT_1.Name
is
null
Then
''
Else
' '
End
+
IsNull(
dbo.eo_ObjectName(EOT_2.EntityID, EOT_2.ID),
''))
From
enTable EOT_1
Left Outer Join enEntity EOT_2 On 
EOT_2.ID
=
EOT_1.TableEntityID
Where
(
EOT_1.TableID
=
@ObjectID)
/*------------------------------*/
  Return @R
End
