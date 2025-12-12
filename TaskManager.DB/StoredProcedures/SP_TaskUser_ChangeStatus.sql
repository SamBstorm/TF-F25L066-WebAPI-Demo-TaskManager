CREATE PROCEDURE [dbo].[SP_TaskUser_ChangeStatus]
	@userId UNIQUEIDENTIFIER,
	@taskId UNIQUEIDENTIFIER,
	@status VARCHAR(12),
	@comment NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO [User_Task]([UserId], [TaskId], [Status], [Comment])
		OUTPUT [inserted].[UserTaskId]
		VALUES (@userId, @taskId, @status, @comment)
END
