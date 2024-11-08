Create DATABASE QLDeCuong
go

use QLDeCuong
go

Create table Nganh(
MaNganh VarCHAR(7) NOT NULL,
TenNganh NVARCHAR(50) NOT NUll,
CONSTRAINT pk_Nganh Primary key(MaNganh)
)
Go

Create table Mon(
MaMon VarCHAR(7) NOT NULL,
TenMon NVARCHAR(50) NOT NUll,
MaNganh VarCHAR(7) NOT NULL,
CONSTRAINT pk_Mon Primary key(MaMon),
CONSTRAINT FK_Mon_Nganh FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh)
)
Go

Create table Quyen(
MaQuyen VarCHAR(7) NOT NULL,
TenQuyen NVARCHAR(50) NOT NUll,
CONSTRAINT pk_Quyen Primary key(MaQuyen)
)
Go

Create table NguoiDung(
MaND VarCHAR(7) NOT NULL,
Ten NVARCHAR(50) NOT NUll,
Email VarChar(50) NOT NUll,
MatKhau VarChar(50) NOT NUll,
MaQuyen VarCHAR(7) NOT NULL,
MaNganh VarCHAR(7) NOT NULL,
CONSTRAINT pk_NguoiDung Primary key(MaND),
CONSTRAINT FK_NguoiDung_Quyen FOREIGN KEY (MaQuyen) REFERENCES Quyen(MaQuyen),
CONSTRAINT FK_NguoiDung_Nganh FOREIGN KEY (MaNganh) REFERENCES Nganh(MaNganh),
)
Go

Create table LichSu(
MaLS VarCHAR(7) NOT NULL,
MaND VarCHAR(7) NOT NULL,
TenHD NVARCHAR(50) NOT NUll,
CONSTRAINT pk_LichSu Primary key(MaLS),
CONSTRAINT FK_LichSu_NguoiDung FOREIGN KEY (MaND) REFERENCES NguoiDung(MaND)
)
Go

Create table DeCuong(
MaDeCuong VarCHAR(7) NOT NULL,
TenDeCuong NVARCHAR(50) NOT NUll,
MaMon VarCHAR(7) NOT NULL,
CONSTRAINT pk_DeCuong Primary key(MaDeCuong),
CONSTRAINT FK_DeCuong_Mon FOREIGN KEY (MaMon) REFERENCES Mon(MaMon)
)
Go

Create table NguoiDung_DeCuong(
MaND_DC VarCHAR(7) NOT NULL,
MaDeCuong VarCHAR(7) NOT NULL,
MaND VarCHAR(7) NOT NULL,
CONSTRAINT pk_ND_DC Primary key(MaDeCuong),
CONSTRAINT FK_ND_DC_DeCuong FOREIGN KEY (MaDeCuong) REFERENCES DeCuong(MaDeCuong),
CONSTRAINT FK_ND_DC_NguoiDung FOREIGN KEY (MaND) REFERENCES NguoiDung(MaND)
)