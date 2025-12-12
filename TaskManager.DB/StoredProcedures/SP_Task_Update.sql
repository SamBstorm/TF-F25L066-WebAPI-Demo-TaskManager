CREATE PROCEDURE [dbo].[SP_Task_Update]
	@taskId UNIQUEIDENTIFIER,
	@title NVARCHAR(256),
	@description NVARCHAR(MAX),
	@deadLine DATETIME2
AS
BEGIN
	UPDATE [Task]
		SET [Title] = @title,
			[Description] = @description,
			[DeadLine] = @deadLine
		WHERE [TaskId] = @taskId
END
