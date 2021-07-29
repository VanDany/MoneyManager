CREATE PROCEDURE [dbo].[MMSP_AddCategory]
	@Name NVARCHAR(50),
	@BudgetLimit FLOAT,
	@UserId INT
AS
BEGIN
	INSERT INTO [Category] ([Name], [BudgetLimit], [UserId]) VALUES (@Name, @BudgetLimit, @UserId);
	RETURN 0
END
