create database QLPG1
go
use QLPG1
go
create table Roles
(
	id_Role int primary key identity not null,
	Roles nvarchar(500)
)
go
create table Account
(
	id int primary key identity not null,
	id_Role int,
	Username varchar(500),
	TenNV nvarchar(500),
    SDT char(100),
	Email varchar(500),
	Pass varchar(200) ,
	foreign key(id_Role) references dbo.Roles(id_Role)
)
go
create table GoiTap
(
	id_GT int primary key identity not null,
	TenGoiTap nvarchar(700),
    ThoiGianHieuLuc datetime,
    ChiPhi money
)
go
create table ThanhVien
(
	id_TV int primary key identity not null,
	TenTV nvarchar(500),
	SDT varchar(250),
	Email varchar(500),
	TenGT nvarchar(700), 
    NgayTao datetime   --ngày đăng ký tập thử
)
go
--DELETE FROM ThanhVien
create table HoiVien
(
	id_HV int primary key identity not null,
    id_TV int,
	HinhAnh nvarchar(255), 
	NgaySinh datetime,
	CCCD char(100),
	TinhTrang bit,
	NgayGiaNhap datetime,  --ngày đk hội viên
	foreign key(id_TV) references dbo.ThanhVien(id_TV)
)
go
CREATE TABLE BuoiTap
(
    id_BT int primary key identity not null,
    id_HV int,
    NgayThamGia datetime, --ngày hội viên đến tập 
    DaDiemDanh bit,
    foreign key(id_HV) references dbo.HoiVien(id_HV)
)
go
create table ChiTietDK_GoiTap
(
             id_CTDKGoiTap int primary key identity not null,
             id_GT int,
             id_HV int,
			 NgayBatDau datetime,
             NgayKetThuc datetime,
             ThanhTien money ,
             foreign key(id_GT) references dbo.GoiTap(id_GT),
             foreign key(id_HV) references dbo.HoiVien(id_HV)  
)
go
--INSERT INTO ChiTietDK_GoiTap (id_GT, id_HV, ThanhTien)
--VALUES (1, 1, 1000000), VALUES (Cycling, Nguyễn Văn A, 1000000)



