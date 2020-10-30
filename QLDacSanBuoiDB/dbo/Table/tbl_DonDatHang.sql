CREATE TABLE [dbo].[tbl_DonDatHang]
(
	[DonDatHangID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [KhachHangID] INT NOT NULL, 
    [LoaiKhachHang] INT NULL, 
    [TrangThai] INT NULL DEFAULT 1 
)
