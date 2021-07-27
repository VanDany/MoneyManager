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
SET IDENTITY_INSERT [Category] ON;
INSERT INTO [Category] ([Id], [Name]) VALUES (1, 'Loyer');
INSERT INTO [Category] ([Id], [Name]) VALUES (2, 'Alimentation');
INSERT INTO [Category] ([Id], [Name], [BudgetLimit]) VALUES (3, 'Loisirs', 100);
SET IDENTITY_INSERT [Category] OFF;