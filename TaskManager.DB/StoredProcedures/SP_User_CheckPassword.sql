CREATE PROCEDURE [dbo].[SP_User_CheckPassword]
	@email NVARCHAR(320),
	@password NVARCHAR(128)
AS
BEGIN
	SELECT	[UserId],
			[Email],
			[Role],
			[CreationDate],
			[DisableDate]
		FROM [User]
		WHERE	[Email] = @email
			AND	[Password] = [dbo].[SF_HashAndSalt](@password, [Salt])
			AND [DisableDate] IS NULL
END