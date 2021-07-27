CREATE PROCEDURE [dbo].[MMSP_DeleteCategory]
	@Id int
AS
	DELETE FROM [Category] WHERE Id = @Id;
RETURN 0
