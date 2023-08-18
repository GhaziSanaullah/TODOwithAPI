IF EXISTS (SELECT 1 FROM sys.tables WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[4099_Student]'))
DROP TABLE [4099_Student]
BEGIN
	CREATE TABLE [4099_Student] (
		Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
		FirstName varchar(30) NOT NULL,
		LastName varchar (30) NOT NULL,
		Address varchar (100) NOT NULL,
		Age INT NOT NULL,
		PhoneNo INT NOT NULL)
END