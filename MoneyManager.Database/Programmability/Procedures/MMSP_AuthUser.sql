CREATE PROCEDURE [dbo].[MMSP_AuthUser]
	@Email NVARCHAR(384),
	@Password NVARCHAR(20)
AS
BEGIN
	SELECT [Id], Username, EmailAddress, Password, Xp, Level
	FROM [User] 
	WHERE EmailAddress = @Email
	AND Password = HASHBYTES('SHA2_512', dbo.MMSF_GetPreSalt() + @Password + dbo.MMSF_GetPostSalt());
	RETURN 0;
END
