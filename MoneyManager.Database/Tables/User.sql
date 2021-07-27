CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [EmailAdress] NVARCHAR(50) NOT NULL, 
    [Password] BINARY(64) NOT NULL, 
    [Xp] INT NOT NULL DEFAULT 0, 
    [Level] INT NOT NULL DEFAULT 1
)
