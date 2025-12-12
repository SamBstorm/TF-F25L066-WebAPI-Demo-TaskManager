CREATE PROCEDURE [dbo].[SP_User_Get]
	@userId UNIQUEIDENTIFIER
AS
	SELECT	[UserId],
			[Email],
			[Role],
			[CreationDate],
			[DisableDate]
		FROM [User]
		WHERE [UserId] = @userId
RETURN 0
