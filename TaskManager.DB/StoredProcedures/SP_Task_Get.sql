CREATE PROCEDURE [dbo].[SP_Task_Get]
	@taskId UNIQUEIDENTIFIER
AS
	SELECT	[TaskId],
			[Title],
			[Description],
			[CreatorId],
			[CreationDate],
			[DeadLine]
		FROM [Task]
		WHERE [TaskId] = @taskId
RETURN 0
