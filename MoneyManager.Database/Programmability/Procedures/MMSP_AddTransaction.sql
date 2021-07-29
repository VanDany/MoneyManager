CREATE PROCEDURE [dbo].[MMSP_AddTransaction]
	@UserAccountId INT,
	@Description NVARCHAR(50),
	@ExpenseOrIncome BIT,
	@Amount FLOAT,
	@CategoryId INT
AS
	INSERT INTO [Transaction] ([UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (@UserAccountId, GETDATE(), @Description, @ExpenseOrIncome, @Amount, @CategoryId);
RETURN 0
