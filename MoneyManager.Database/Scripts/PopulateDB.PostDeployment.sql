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