CREATE PROCEDURE [dbo].[SP_Task_Insert]
	@title NVARCHAR(256),
	@description NVARCHAR(MAX),
	@creatorId UNIQUEIDENTIFIER,
	@deadLine DATETIME2
AS
BEGIN
	INSERT INTO [Task]([Title],[Description],[CreatorId],[DeadLine])
		OUTPUT [inserted].[TaskId]
		VALUES (@title, @description, @creatorId, @deadLine)
END
