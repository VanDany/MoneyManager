CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserAccountId] INT NOT NULL, 
    [DateTransact] DATETIME2(0) NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [ExpenseOrIncome] BIT NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_User] FOREIGN KEY ([UserAccountId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Transaction_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
