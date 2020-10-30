CREATE TABLE [dbo].[tbl_ChiTietDonDatHang]
(
	[ChiTietDonDatHangID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SanPhamID] INT NULL, 
    [SL] INT NULL, 
    [DonGia] FLOAT NULL, 
    [DonDatHangID] INT NOT NULL, 
    [NgayDat] DATE NULL
)
