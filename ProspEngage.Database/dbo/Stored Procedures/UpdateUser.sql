CREATE PROCEDURE [dbo].[UpdateUser]
    @ID INT,
    @Name VARCHAR(255),
    @Age INT
AS
BEGIN
    UPDATE [dbo].[User]
    SET Name = @Name, Age = @Age
    WHERE ID = @ID;
END
GO
