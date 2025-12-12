CREATE PROCEDURE [dbo].[SP_User_Get_Creator_ByTaskId]
	@taskId UNIQUEIDENTIFIER
AS
	SELECT	[UserId],
			[Email],
			[Role],
			[CreationDate],
			[DisableDate]
		FROM	[User] 
		WHERE	[UserId] = (SELECT	[CreatorId]
								FROM [Task]
								WHERE [TaskId] = @taskId)
RETURN 0
