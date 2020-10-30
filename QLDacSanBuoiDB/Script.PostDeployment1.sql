/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE QLBiaDB
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
INSERT INTO dbo.tbl_DiaChi VALUES(N'An Giang');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bà Rịa - Vũng Tàu');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bắc Giang');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bắc Kạn');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bạc Liêu');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bắc Ninh');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bến Tre');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Định');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Dương');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Phước');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Bình Thuận');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Cà Mau');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Cao Bằng');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đắk Lắk');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đắk Nông');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Điện Biên');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đồng Nai');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Đồng Tháp');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Gia Lai');
INSERT INTO dbo.tbl_DiaChi VALUES(N'Hà Giang');

SELECT * FROM dbo.tbl_DiaChi;

SET IDENTITY_INSERT tbl_TinTuc ON

-- Thêm loại sản phẩm
TRUNCATE TABLE dbo.tbl_LoaiSP;

INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bia Việt');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bia Hơi');
INSERT INTO dbo.tbl_LoaiSP VALUES(N'Bia Nhập Khẩu');

SELECT * FROM dbo.tbl_LoaiSP;


-- Thêm sản phẩm
TRUNCATE TABLE dbo.tbl_SanPham;


SELECT * FROM dbo.tbl_SanPham;

TRUNCATE TABLE dbo.tbl_Users;

INSERT INTO dbo.tbl_Users VALUES('ad', 'ad', 'ad', 'ad', 'ad', 'ad', 2);

SELECT * FROM dbo.tbl_Users;
