CREATE TABLE [dbo].[tbl_ChiTietGioHang]
(
	[ChiTietGioHangID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SanPhamID] INT NULL, 
    [SL] INT NULL, 
    [DonGia] FLOAT NULL, 
    [GioHangID] INT NOT NULL, 
    [NgayThem] DATE NULL
)
