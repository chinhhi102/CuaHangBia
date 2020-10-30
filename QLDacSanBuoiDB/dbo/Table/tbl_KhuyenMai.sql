CREATE TABLE [dbo].[tbl_KhuyenMai]
(
	[KhuyenMaiID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SanPhamID] INT NULL, 
    [Mota] NVARCHAR(MAX) NOT NULL, 
    [GiaGiam] FLOAT NOT NULL, 
    [NgayBD] DATE NULL, 
    [NgayKT] DATE NULL
)
