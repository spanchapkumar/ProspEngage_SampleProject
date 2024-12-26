CREATE PROCEDURE [dbo].[DeleteUser]
    @ID INT
AS
BEGIN
    DELETE FROM [dbo].[User]
    WHERE ID = @ID;
END
GO
