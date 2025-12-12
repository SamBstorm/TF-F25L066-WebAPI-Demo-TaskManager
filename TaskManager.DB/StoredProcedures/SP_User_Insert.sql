CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(320),
	@password NVARCHAR(128)
AS
BEGIN
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	INSERT INTO [User]([Email],[Password],[Salt])
		OUTPUT [inserted].[UserId]
		VALUES(@email, [dbo].[SF_HashAndSalt](@password,@salt), @salt)
END
