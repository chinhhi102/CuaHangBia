CREATE TABLE [dbo].[tbl_Users]
(
	[UserID] INT NOT NULL  IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(15) NOT NULL, 
    [Role] INT NOT NULL DEFAULT 1, 
    PRIMARY KEY ([Username], [UserID])
)
