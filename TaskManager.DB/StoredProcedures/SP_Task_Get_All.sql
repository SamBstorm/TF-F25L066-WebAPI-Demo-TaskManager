CREATE PROCEDURE [dbo].[SP_Task_Get_All]
AS
	SELECT	[TaskId],
			[Title],
			[Description],
			[CreatorId],
			[CreationDate],
			[DeadLine]
		FROM [Task]
RETURN 0
