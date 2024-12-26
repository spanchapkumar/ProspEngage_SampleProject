CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
    SELECT ID, Name, Age
    FROM [dbo].[User];
END
GO
