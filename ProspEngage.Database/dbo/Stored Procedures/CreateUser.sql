CREATE PROCEDURE [dbo].[CreateUser]
    @Name VARCHAR(255),
    @Age INT,
    @ID INT OUTPUT
AS
BEGIN
    INSERT INTO [dbo].[User] ([Name], [Age])
    VALUES (@Name, @Age);
    SET @ID = SCOPE_IDENTITY();
END
GO
