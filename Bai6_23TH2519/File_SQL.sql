-- Tạo cơ sở dữ liệu QLNV_MãSV
CREATE DATABASE QLNV_23TH2519;
GO

-- Sử dụng cơ sở dữ liệu QLNV_MãSV
USE QLNV_23TH2519;
GO

-- Tạo bảng Phòng ban
CREATE TABLE PhongBan (
    id_PhongBan INT PRIMARY KEY,
    TenPhongBan NVARCHAR(100) NOT NULL
);
GO

-- Tạo bảng Nhân viên với cột id_NV tự động tăng
CREATE TABLE NhanVien (
    id_NV INT PRIMARY KEY,
    HoNV NVARCHAR(50) NOT NULL,
    TenNV NVARCHAR(50) NOT NULL,
    GioiTinh BIT,
    NgaySinh DATE,
    Luong DECIMAL(18, 2),
    AnhNV VARBINARY(MAX),
    DiaChi NVARCHAR(200),
    id_PhongBan INT,
    FOREIGN KEY (id_PhongBan) REFERENCES PhongBan(id_PhongBan)
);


CREATE TABLE QuanTri
(
	Email varchar(50) PRIMARY KEY,
	Admin bit,
	HoTen nvarchar(50),
	Password nvarchar(50)
)
GO


-- Thêm dữ liệu vào bảng PhongBan
INSERT INTO PhongBan (id_PhongBan, TenPhongBan)
VALUES 
(1, N'Phòng Kế Toán'),
(2, N'Phòng Nhân Sự'),
(3, N'Phòng IT');

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (id_NV, HoNV, TenNV, GioiTinh, NgaySinh, Luong, AnhNV, DiaChi, id_PhongBan)
VALUES 
(001, N'Nguyễn', N'Văn A', 1, '1990-01-01', 1000.00, NULL, N'123 Đường A', 1),
(002, N'Trần', N'Thị B', 0, '1992-02-02', 1200.00, NULL, N'456 Đường B', 2),
(003, N'Lê', N'Văn C', 1, '1994-03-03', 1500.00, NULL, N'789 Đường C', 3);

-- Thêm dữ liệu vào bảng QuanTri
INSERT INTO QuanTri (Email, Admin, HoTen, Password)
VALUES 
('admin@thuanpc.com', 1, N'Administrator', '123123');
