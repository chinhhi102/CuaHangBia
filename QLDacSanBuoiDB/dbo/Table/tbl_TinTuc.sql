CREATE TABLE [dbo].[tbl_TinTuc]
(
	[TinTucID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [NoiDung] NVARCHAR(MAX) NULL, 
    [NgayViet] DATE NULL, 
    [TieuDe] NVARCHAR(250) NULL, 
    [ImagePath] NVARCHAR(MAX) NULL
)
