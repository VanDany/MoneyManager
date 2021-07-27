CREATE PROCEDURE [dbo].[MMSP_AddCategory]
	@Name NVARCHAR(50),
	@BudgetLimit FLOAT
AS
BEGIN
	INSERT INTO [Category] ([Name], [BudgetLimit]) VALUES (@Name, @BudgetLimit);
	RETURN 0
END
