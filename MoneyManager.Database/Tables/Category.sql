CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [BudgetLimit] FLOAT NULL, 
    [UserId] INT NOT NULL, 
    CONSTRAINT [FK_Category_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
