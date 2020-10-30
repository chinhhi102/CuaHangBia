USE QLDacSanBuoiDB
GO

-- Thêm các tỉnh
TRUNCATE TABLE dbo.tbl_DiaChi;

INSERT INTO dbo.tbl_DiaChi VALUES(N'Hồ Chí Minh');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Hà Nội');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Dương');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Tiền Giang');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đà Lạt');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đà Nẵng');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Định');

SELECT * FROM dbo.tbl_DiaChi;

-- Thêm loại sản phẩm
TRUNCATE TABLE dbo.tbl_LoaiSP;

INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi năm roi');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi da xanh');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi Diễn');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi Đoan Hùng');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi Phúc Trạch');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi Tân Triều');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bưởi Luận Văn');

SELECT * FROM dbo.tbl_LoaiSP;


-- Thêm sản phẩm
TRUNCATE TABLE dbo.tbl_SanPham;


SELECT * FROM dbo.tbl_SanPham;

TRUNCATE TABLE dbo.tbl_Users;

INSERT INTO dbo.tbl_Users VALUES('ad', 'ad', 'ad', 'ad', 'ad', 'ad', 2);

SELECT * FROM dbo.tbl_Users;