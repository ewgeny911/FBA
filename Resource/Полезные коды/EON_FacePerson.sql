USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [dbo].[EON_FacePerson]    Script Date: 03.07.2018 11:36:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Function [dbo].[EON_FacePerson](@ObjectID int)
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
EOT_1.FirstName,
'')
+
Case
When
EOT_1.FirstName
is
null
Then
''
Else
' '
End
+
IsNull(
EOT_1.SecondName,
''))
From
FacePerson EOT_1
Where
(
EOT_1.FaceID
=
@ObjectID)
/*------------------------------*/
  Return @R
End
