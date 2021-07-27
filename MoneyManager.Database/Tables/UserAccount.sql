CREATE TABLE [dbo].[UserAccount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [FK_UserAccount_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
