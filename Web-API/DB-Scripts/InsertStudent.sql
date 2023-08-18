IF EXISTS (SELECT 1 FROM sys.procedures WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[InsertStudent]'))
    DROP PROCEDURE InsertStudent;
GO

CREATE PROCEDURE InsertStudent
    @firstName VARCHAR(30),
	@lastName VARCHAR(30),
	@studentAddress VARCHAR(100),
	@studentAge INT,
	@phoneNumber INT,

	@PKID int = 0 output
AS
BEGIN
    INSERT INTO [4099_Student] (FirstName, LastName, Address, Age, PhoneNo)
		VALUES (@firstName, @lastName, @studentAddress, @studentAge, @phoneNumber)

	SET @PKID = @@IDENTITY

	Select @PKID as PKID
END
