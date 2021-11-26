-- Xac dinh cac thanh phan, cac bang trong BTL
USE MASTER 
GO

IF EXISTS(SELECT name FROM sys.databases WHERE name='QLQuanAoAdidas')
	DROP DATABASE QLQuanAoAdidas
GO

CREATE DATABASE QLQuanAoAdidas
GO

USE QLQuanAoAdidas
GO
-- NhanVien
--		MaNV
--		TenNV
--		SoDT
--		DiaChi
--		LuongCB
--		ChucVu
--		SoNgayCong
CREATE TABLE NhanVien
(
	MaNV int IDENTITY(1,1),
	TenNV nvarchar(30),
	SoDT varchar(10),
	DiaChi nvarchar(100),
	LuongCB money,
	SoCMT nvarchar(15),
	ChucVu nvarchar(20),
	PRIMARY KEY(MaNV)
)
GO

-- TaiKhoan
--		TenTaiKhoan
--		MatKhau
--		LoaiTaiKhoan
--		MaNV
CREATE TABLE TaiKhoan
(
	MaNV int,
	TenTaiKhoan varchar(20),
	MatKhau varchar(20),
	LoaiTaiKhoan varchar(20),
	PRIMARY KEY(MaNV),
	FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
)
GO
-- LoaiSP
--		MaLoaiSP
--		TenLoaiSP
CREATE TABLE LoaiSP
(
	MaLoai int IDENTITY(1,1),
	TenLoai nvarchar(30),
	PRIMARY KEY(MaLoai)
)
GO

-- SanPham

CREATE TABLE SanPham
(
	MaSP char(6),
	TenSP nvarchar(50),
	GiaBan money,
	Size varchar(20),
	Mau nvarchar(20),
	SLCon int,
	MaLoai int,
	PRIMARY KEY(MaSP),
	FOREIGN KEY(MaLoai) REFERENCES LoaiSP(MaLoai)
)
GO

-- NhaCC
CREATE TABLE NhaCC
(
	MaNCC char(6),
	TenNCC nvarchar(50),
	SoDT varchar(10),
	DiaChi nvarchar(100),
	Email varchar(50),
	NguoiLienHe nvarchar(50),
	PRIMARY KEY(MaNCC)
)
GO

-- DatHang

CREATE TABLE DatHangNhaCC
(
	MaDatHang char(6),
	MaNCC char(6),
	NgayLap datetime,
	NgayGiao datetime,
	NguoiLap nvarchar(30),
	TongTien money,
	PRIMARY KEY(MaDatHang),
	FOREIGN KEY(MaNCC) REFERENCES NhaCC(MaNCC)
)
GO
CREATE TABLE ChiTietDatHangNhaCC
(
	MaDatHang char(6),
	MaSP char(6),
	SLDat int,
	SLDatCon int,
	GiaDat money,
	PRIMARY KEY(MaDatHang, MaSP),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP),
	FOREIGN KEY(MaDatHang) REFERENCES DatHangNhaCC(MaDatHang)
)
GO

-- PhieuNhap
CREATE TABLE PhieuNhap
(
	MaPN char(6),
	MaDatHang char(6),
	NgayLap datetime,
	NguoiLap nvarchar(50),
	NguoiGiaoHang nvarchar(50),
	DiaDiemNhap nvarchar(100),
	MaNCC char(6),
	PRIMARY KEY(MaPN),
	FOREIGN KEY(MaNCC) REFERENCES NhaCC(MaNCC),
	FOREIGN KEY(MaDatHang) REFERENCES DatHangNhaCC(MaDatHang)
)
GO
CREATE TABLE ChiTietPhieuNhap
(
	MaPN char(6),
	MaSP char(6),
	SLNhap int,
	GiaNhap money,
	PRIMARY KEY(MaPN, MaSP),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP),
	FOREIGN KEY(MaPN) REFERENCES PhieuNhap(MaPN)
)
GO

CREATE TABLE HoaDon
(
	MaHD int IDENTITY(1,1),
	TenKH nvarchar(50),
	TenNguoiLap nvarchar(50),
	NgayLap datetime,
	PRIMARY KEY(MaHD)
)
GO
--		
-- ChiTietHoaDon
CREATE TABLE ChiTietHoaDon
(
	MaHD int,
	MaSP char(6),
	SLMua int,
	Gia money,
	PRIMARY KEY(MaHD, MaSP),
	FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
)
GO
--		
-- SuaHang
CREATE TABLE SuaHang
(
	MaSuaHang char(6),
	MaSP char(6),
	TenKH nvarchar(30),
	SoDT nvarchar(10),
	DiaChi nvarchar(100),
	TinhTrang nvarchar(100),
	NgayLap datetime,
	NgayTra datetime,
	PRIMARY KEY(MaSuaHang),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP)
)
GO
CREATE TABLE ChiTietPhieuSua
(
	MaSuaHang char(6),
	MaSP char(6),
	TinhTrang nvarchar(100),
	PRIMARY KEY(MaSuaHang, MaSP),
	FOREIGN KEY(MaSP) REFERENCES SanPham(MaSP),
	FOREIGN KEY(MaSuaHang) REFERENCES SuaHang(MaSuaHang)
)
GO
-- DoiHang
CREATE TABLE DoiTra
(
	MaDoiTra char(6),
	MaHD int,
	MaSP char(6),
	NgayDoiHang datetime,
	PRIMARY KEY(MaDoiTra),
	FOREIGN KEY(MaHD) REFERENCES HoaDon(MaHD),
	FOREIGN KEY(MaHD,MaSp) REFERENCES ChiTietHoaDon(MaHD,MaSP)

)
GO


-- Them du lieu
INSERT INTO NhaCC
VALUES ('CC0001',N'Công ty may Phú Xuân', '0336153418', N'Tân Dân, Sóc Sơn, Hà Nội','phuxuan@gmail.com',N'Mai Trung Quân')
INSERT INTO NhaCC 
VALUES ('CC0002',N'Công ty dệt Minh Thuận', '0334747242', N'Km6 Đường Giải Phóng, Q, Hoàng Mai, Hà Nội','minhThuan@gmail.com',N'Nguyễn Cẩm Thu')
INSERT INTO NhaCC
VALUES ('CC0003',N'Công ty may Hoàng Gia', '0947500763', N'Kim Sơn - Hà Nam','hoanggia@gmail.com',N'Nguyễn Bá Tiến')
INSERT INTO NhaCC
VALUES ('CC0004',N'Công ty may Tân Kỳ', '0944512784', N'287 Nguyễn Trãi, Võ Cường, Bắc Ninh','hoanggia@gmail.com',N'Nguyễn Hồng Phong')
INSERT INTO NhaCC
VALUES ('CC0005',N'Công Ty TNHH May Mặc Dony', '0331614398', N'Thổ Quan, Đống Đa, Hà Nội','dony@gmail.com',N'Trần Gia Bảo')
INSERT INTO NhaCC
VALUES ('CC0006',N'Công Ty TNHH Mỹ Anh', '0335274444', N'Km 18.5 QL 32, X. Đức Thượng, Hoài Đức, Hà Nội','myanh@gmail.com',N'Hà Mạnh Quang')
INSERT INTO NhaCC
VALUES ('CC0007',N'Công Ty TNHH Thương Mại May Tâm Thịnh Phát', '0366528833', N'Số 5, Đường T8, P. Tây Thạnh, Q. Tân Phú, Tp. Hồ Chí Minh','tamthinhphat@gmail.com',N'Nguyễn Trung Tín')
Go

INSERT INTO LoaiSP
VALUES (N'Áo')
INSERT INTO LoaiSP
VALUES (N'Quần')
INSERT INTO LoaiSP
VALUES (N'Giày')
GO

INSERT INTO SanPham
VALUES ('SP0001',N'Áo thun', 500000, 'L', N'Xanh',50,1)
INSERT INTO SanPham
VALUES ('SP0002',N'QUẦN SHORT 3 SỌC OWN THE RUN', 700000, 'L', N'Đỏ',55,2)
INSERT INTO SanPham
VALUES ('SP0003',N'Giày Run Falcon 2.0', 800000, 'XL', N'Đen',100,3)
INSERT INTO SanPham
VALUES ('SP0004',N'Quần Short Marathon 20', 750000, 'XL', N'Xanh',30,2)
INSERT INTO SanPham
VALUES ('SP0005',N'Quần short Tokyo Run Nam Chạy', 950000, 'XL', N'Đen',150,2)
INSERT INTO SanPham
VALUES ('SP0006',N'Giày Response Super 2.0', 950000, 'XL', N'Đen,Trắng',100,3)
INSERT INTO SanPham
VALUES ('SP0007',N'Giày SUPERNOVA', 1000000, 'XL', N'Trắng',100,3)
GO


INSERT INTO NhanVien
VALUES (N'Nguyễn Tiến Thành','0988888887',N'Bắc Ninh',2000000,'123456789123',N'Quản Lý')
INSERT INTO NhanVien
VALUES (N'Phạm Ngọc Trường','0983848586',N'Nghệ An',1000000,'123456787749',N'Nhân Viên')
INSERT INTO NhanVien
VALUES (N'Lê Tú Anh','0977788888',N'Nam Định',1000000,'123456784321',N'Nhân Viên')
GO


INSERT INTO TaiKhoan
VALUES (1,'tienthanh','123','QuanLy')
INSERT INTO TaiKhoan
VALUES (2,'phamngoctruong','123','Nhanvien')
INSERT INTO TaiKhoan
VALUES (3,'letuanh','235','Nhanvien')
INSERT INTO TaiKhoan
VALUES (3,'letuanh','235','Nhanvien')
INSERT INTO TaiKhoan
VALUES (3,'letuanh','235','Nhanvien')
GO

INSERT INTO DatHangNhaCC
VALUES ('MD0001','CC0001', GETDATE(),'10/09/2021', N'Lê Tú Anh',1000)
INSERT INTO DatHangNhaCC 
VALUES ('MD0002','CC0002',GETDATE(),'10/09/2021', N'Bế Xuân Viễn',2000)
INSERT INTO DatHangNhaCC
VALUES ('MD0003','CC0002', GETDATE(),'10/20/2021', N'Phạm Ngọc Trường',1500)
Go
select * from ChiTietDatHangNhaCC
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0001','SP0001',100,100,300000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0001','SP0002',150,150,400000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0001','SP0003',250,250,500000)

INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0002','SP0001',100,100,320000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0002','SP0002',150,150,450000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0002','SP0003',50,150,490000)

INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0003','SP0001',50,50,290000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0003','SP0003',50,50,520000)
INSERT INTO ChiTietDatHangNhaCC
VALUES ('MD0003','SP0004',40,40,440000)

INSERT INTO PhieuNhap
VALUES ('PN0001','MD0001',GETDATE(),N'Nguyễn Tiến Thành',N'Mai Trung Quân',N'29 Hai Bà Trưng - Hà Nội','CC0001')
INSERT INTO PhieuNhap
VALUES ('PN0002','MD0002',GETDATE(),N'Nguyễn Tiến Thành',N'Nguyễn Cẩm Thu',N'29 Hai Bà Trưng - Hà Nội','CC0002')


INSERT INTO ChiTietPhieuNhap
VALUES ('PN0001','SP0001',50,300000)
INSERT INTO ChiTietPhieuNhap
VALUES ('PN0001','SP0002',30,400000)


INSERT INTO ChiTietPhieuNhap
VALUES ('PN0002','SP0001',30,320000)
INSERT INTO ChiTietPhieuNhap
VALUES ('PN0002','SP0002',45,450000)
INSERT INTO ChiTietPhieuNhap
VALUES ('PN0002','SP0003',30,490000)



select * from SanPham
select * from TaiKhoan
select * from NhanVien
select * from ChiTietPhieuNhap
select * from PhieuNhap
select * from SuaHang
select * from HoaDon
select * from DatHangNhaCC
select * from ChiTietDatHangNhaCC
select * from NhaCC