CREATE PROCEDURE [dbo].[MMSP_RegisterUser]
	@Username NVARCHAR(50),
	@Email NVARCHAR(384),
	@Password NVARCHAR(20)
AS
BEGIN
	INSERT INTO [User] (Username, EmailAddress, Password) VALUES 
	(@Username, @Email, HASHBYTES('SHA2_512', dbo.MMSF_GetPreSalt() + @Password + dbo.MMSF_GetPostSalt()));

	RETURN 0;
END
