CREATE PROCEDURE [dbo].[GetUserById]
    @ID INT
AS
BEGIN
    SELECT ID, Name, Age
    FROM [dbo].[User]
    WHERE ID = @ID;
END
GO
