CREATE DATABASE THIETKE_GD_QLBANHANG
GO
USE THIETKE_GD_QLBANHANG
GO

CREATE TABLE NGUOIDUNG
(
	Username varchar(200) PRIMARY KEY,
	Password varchar(200),
	FirstName nvarchar(100),
	LastName nvarchar(100)
)
GO 

INSERT INTO NGUOIDUNG VALUES('admin','admin123', N'Nguyễn Thành',N'Đặng')
INSERT INTO NGUOIDUNG VALUES('ketoan','kt123', N'Nguyễn Vĩnh',N'Kỳ')
INSERT INTO NGUOIDUNG VALUES('banhang','bh123', N'Đỗ Hồng',N'Phấn')


