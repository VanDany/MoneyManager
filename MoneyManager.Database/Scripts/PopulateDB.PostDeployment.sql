/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
--SET IDENTITY_INSERT [Category] ON;
--INSERT INTO [Category] ([Id], [Name], [UserId]) VALUES (1, 'Loyer', 1);
--INSERT INTO [Category] ([Id], [Name], [UserId]) VALUES (2, 'Alimentation', 1);
--INSERT INTO [Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (3, 'Loisirs', 100, 1);
--SET IDENTITY_INSERT [Category] OFF;

SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [EmailAddress], [Password], [Xp], [Level]) VALUES (1, N'Dany', N'dany@gmail.com', 0x334FB4564FFCF6569293C9BCDCA646BF34A7CF2CE1A85B7E295305CE77D9F216519DD1A64AA71C9E063A3AF56F3C957A708814C5EE155615B813D40CD90D233B, 0, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (1, N'Alimentation', 400, 1)
INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (2, N'Sport', 50, 1)
INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (4, N'Transport', 30, 1)
INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (5, N'Vêtements', 60, 1)
INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (7, N'Ventes Marketplace', NULL, 1)
INSERT [dbo].[Category] ([Id], [Name], [BudgetLimit], [UserId]) VALUES (8, N'Poker', 50, 1)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([Id], [UserId], [Description]) VALUES (1, 1, N'Courant')
INSERT [dbo].[UserAccount] ([Id], [UserId], [Description]) VALUES (2, 1, N'Epargne')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
GO
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (2, 1, CAST(N'2021-08-16T09:33:21.0000000' AS DateTime2), N'Courses Colruyt', 1, 71.13, 1)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (3, 1, CAST(N'2021-08-16T09:33:54.0000000' AS DateTime2), N'Resto', 1, 45, 1)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (5, 1, CAST(N'2021-08-16T09:34:52.0000000' AS DateTime2), N'Piscine', 1, 2.9, 2)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (6, 1, CAST(N'2021-08-16T09:35:42.0000000' AS DateTime2), N'Jeu switch - Zelda', 0, 35, 7)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (7, 1, CAST(N'2021-08-16T09:36:22.0000000' AS DateTime2), N'tee-shirts', 1, 27.97, 5)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (9, 1, CAST(N'2021-08-16T09:38:52.0000000' AS DateTime2), N'Frites', 1, 4, 1)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (13, 1, CAST(N'2021-08-16T09:43:26.0000000' AS DateTime2), N'Tennis', 1, 27, 2)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (14, 2, CAST(N'2021-08-16T09:44:21.0000000' AS DateTime2), N'Tournoi pokerstars', 1, 25, 8)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (17, 2, CAST(N'2021-08-16T09:45:34.0000000' AS DateTime2), N'gain tournoi pokerstars', 0, 8.7, 8)
INSERT [dbo].[Transaction] ([Id], [UserAccountId], [DateTransact], [Description], [ExpenseOrIncome], [Amount], [CategoryId]) VALUES (18, 1, CAST(N'2021-08-16T09:50:13.0000000' AS DateTime2), N'Poivrons', 1, 2.72, 1)
SET IDENTITY_INSERT [dbo].[Transaction] OFF