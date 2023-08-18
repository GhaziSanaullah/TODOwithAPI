IF EXISTS (SELECT 1 FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[GetStudentList]'))
    DROP PROCEDURE GetStudentList;
GO

CREATE PROCEDURE GetStudentList
AS
BEGIN
    SELECT Id, FirstName, LastName, Address, Age, PhoneNo FROM [4099_Student];
END