CREATE PROCEDURE [dbo].[MMSP_AddTransaction]
	@UserAccount INT,
	@Description NVARCHAR(50),
	@ExpenseOrIncome BIT,
	@Amount FLOAT,
	@CategoryId INT
AS
	INSERT INTO [Transaction] ([UserAccount], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (@UserAccount, GETDATE(), @Description, @ExpenseOrIncome, @Amount, @CategoryId);
RETURN 0
