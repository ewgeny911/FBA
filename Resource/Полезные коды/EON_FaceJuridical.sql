USE [DIASOFT]
GO
/****** Object:  UserDefinedFunction [dbo].[EON_FaceJuridical]    Script Date: 03.07.2018 11:36:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Function [dbo].[EON_FaceJuridical](@ObjectID int)
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
''))
From
FaceJuridical EOT_1
Where
(
EOT_1.FaceID
=
@ObjectID)
/*------------------------------*/
  Return @R
End
