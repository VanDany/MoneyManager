﻿CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserAccount] INT NOT NULL, 
    [DateTransact] DATETIME2 NOT NULL, 
    [Description] NVARCHAR(50) NULL, 
    [ExpenseOrIncome] BIT NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_User] FOREIGN KEY ([UserAccount]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Transaction_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)