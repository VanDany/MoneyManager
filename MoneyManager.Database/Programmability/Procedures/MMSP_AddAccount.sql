CREATE PROCEDURE [dbo].[MMSP_AddAccount]
	@UserId INT,
	@Description NVARCHAR(50)
AS
BEGIN
	INSERT INTO [UserAccount] ([UserId], [Description]) VALUES (@UserId, @Description);
	RETURN 0
END
