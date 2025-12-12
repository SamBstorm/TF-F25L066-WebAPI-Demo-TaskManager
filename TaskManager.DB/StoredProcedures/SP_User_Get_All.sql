CREATE PROCEDURE [dbo].[SP_User_Get_All]
AS
	SELECT	[UserId],
			[Email],
			[Role],
			[CreationDate],
			[DisableDate]
		FROM [User]
		WHERE [DisableDate] IS NULL
RETURN 0
