CREATE PROCEDURE [dbo].[MMSP_DeleteCategory]
	@Id int,
	@UserId int
AS
	DELETE FROM [Category] WHERE Id = @Id and UserId = @UserId;
RETURN 0
