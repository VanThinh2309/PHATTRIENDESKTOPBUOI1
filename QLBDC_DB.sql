/* =========================================================================
   DỰ ÁN: QUẢN LÝ CỬA HÀNG BÁN ĐỒ CHƠI TRẺ EM (QuanLyBanDoChoi)
   CƠ SỞ DỮ LIỆU: SQL SERVER (ĐÃ TỐI ƯU HOÀN CHỈNH)
   ========================================================================= */

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QLBDC_DB')
BEGIN
    CREATE DATABASE QLBDC_DB;
END
GO

USE QLBDC_DB;
GO

/* =========================================================================
   1. XÓA BẢNG CŨ (Theo đúng thứ tự khóa ngoại)
   ========================================================================= */
DROP TABLE IF EXISTS ChiTietPhieuNhap;
DROP TABLE IF EXISTS PhieuNhap;
DROP TABLE IF EXISTS NhaCungCap;
DROP TABLE IF EXISTS SanPham_NenTang;
DROP TABLE IF EXISTS ChiTietHoaDon;
DROP TABLE IF EXISTS HoaDon;
DROP TABLE IF EXISTS SanPham;
DROP TABLE IF EXISTS KhachHang;
DROP TABLE IF EXISTS NenTang;
DROP TABLE IF EXISTS LoaiDoChoi;
GO

/* =========================================================================
   2. KHỞI TẠO CÁC BẢNG (DATABASE SCHEMA)
   ========================================================================= */

-- 2.1. LOẠI ĐỒ CHƠI
CREATE TABLE LoaiDoChoi
(
    MaLoai CHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500)
);
GO

-- 2.2. NỀN TẢNG BÁN HÀNG (ĐÃ XÓA FACEBOOK)
CREATE TABLE NenTang
(
    MaNenTang CHAR(10) PRIMARY KEY,
    TenNenTang NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- 2.3. KHÁCH HÀNG
CREATE TABLE KhachHang
(
    MaKH CHAR(10) PRIMARY KEY,
    TenKH NVARCHAR(150) NOT NULL,
    SDT VARCHAR(15) UNIQUE,
    DiemTichLuy INT NOT NULL DEFAULT 0,
    HangKhachHang NVARCHAR(50) NOT NULL DEFAULT N'Đồng',
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

-- 2.4. SẢN PHẨM
CREATE TABLE SanPham
(
    MaSP CHAR(10) PRIMARY KEY,
    MaLoai CHAR(10) REFERENCES LoaiDoChoi(MaLoai) ON UPDATE CASCADE ON DELETE SET NULL,
    TenSP NVARCHAR(200) NOT NULL,
    DoTuoi NVARCHAR(50),
    TenXuatXu NVARCHAR(100),
    Hang NVARCHAR(100),
    GiaNhap DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (GiaNhap >= 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    TonKho INT NOT NULL DEFAULT 0 CHECK (TonKho >= 0),
    HinhAnh NVARCHAR(500),
    TrangThai BIT NOT NULL DEFAULT 1
);
GO

-- 2.5. SẢN PHẨM - NỀN TẢNG
CREATE TABLE SanPham_NenTang
(
    MaSP CHAR(10) REFERENCES SanPham(MaSP) ON DELETE CASCADE,
    MaNenTang CHAR(10) REFERENCES NenTang(MaNenTang) ON DELETE CASCADE,
    GiaTrenSan DECIMAL(18,2) NULL,
    LinkSan NVARCHAR(500) NULL,
    TrangThaiDongBo NVARCHAR(50) DEFAULT N'Đồng bộ OK',
    PRIMARY KEY (MaSP, MaNenTang)
);
GO

-- 2.6. HÓA ĐƠN
CREATE TABLE HoaDon
(
    MaHD CHAR(10) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaKH CHAR(10) REFERENCES KhachHang(MaKH) ON UPDATE CASCADE ON DELETE SET NULL,
    MaNenTang CHAR(10) REFERENCES NenTang(MaNenTang) ON UPDATE CASCADE ON DELETE SET NULL,
    GhiChu NVARCHAR(500),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    PhuongThucThanhToan NVARCHAR(50) NOT NULL DEFAULT N'Tiền mặt',
    TrangThai NVARCHAR(50) NOT NULL DEFAULT N'Đang xử lý',
    DiaChi NVARCHAR(255),
    DonViVanChuyen NVARCHAR(100),
    CONSTRAINT CK_HoaDon_PhuongThucThanhToan
        CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản', N'Thu hộ'))
);
GO

-- 2.7. CHI TIẾT HÓA ĐƠN
CREATE TABLE ChiTietHoaDon
(
    MaHD CHAR(10) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaSP CHAR(10) REFERENCES SanPham(MaSP) ON UPDATE CASCADE,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaHD, MaSP)
);
GO

-- 2.8. NHÀ CUNG CẤP
CREATE TABLE NhaCungCap
(
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC NVARCHAR(200) NOT NULL,
    SDT VARCHAR(20),
    DiaChi NVARCHAR(255)
);
GO

-- 2.9. PHIẾU NHẬP HÀNG (LIÊN KẾT KHÓA NGOẠI VỚI NHÀ CUNG CẤP)
CREATE TABLE PhieuNhap
(
    MaPN VARCHAR(20) PRIMARY KEY,
    NgayNhap DATETIME NOT NULL DEFAULT GETDATE(),
    MaNCC VARCHAR(20) REFERENCES NhaCungCap(MaNCC) ON UPDATE CASCADE ON DELETE SET NULL,
    NguoiLap NVARCHAR(100) DEFAULT N'Quản Lý',
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TongTien >= 0),
    GhiChu NVARCHAR(500)
);
GO

-- 2.10. CHI TIẾT PHIẾU NHẬP
CREATE TABLE ChiTietPhieuNhap
(
    MaPN VARCHAR(20) REFERENCES PhieuNhap(MaPN) ON DELETE CASCADE,
    MaSP CHAR(10) REFERENCES SanPham(MaSP) ON UPDATE CASCADE,
    SoLuongNhap INT NOT NULL CHECK (SoLuongNhap > 0),
    DonGiaNhap DECIMAL(18,2) NOT NULL CHECK (DonGiaNhap >= 0),
    ThanhTien AS (SoLuongNhap * DonGiaNhap),
    PRIMARY KEY (MaPN, MaSP)
);
GO

/* =========================================================================
   3. DỮ LIỆU MẪU (MOCK DATA)
   ========================================================================= */

-- 3.1. LOẠI ĐỒ CHƠI
INSERT INTO LoaiDoChoi (MaLoai, TenLoai, MoTa) VALUES
('L001', N'Đồ chơi giáo dục & Trí tuệ', N'Giúp phát triển trí tuệ, khả năng tư duy logic'),
('L002', N'Thú nhồi bông & Gấu bông', N'Các loại thú bông cao cấp mềm mịn, an toàn'),
('L003', N'Xe mô hình & Điều khiển từ xa', N'Xe ô tô, xe máy điều khiển từ xa cao cấp'),
('L004', N'Lắp ráp & Xếp hình khối', N'Các bộ Lego, Nanoblock phát triển trí tuệ'),
('L005', N'Búp bê & Nhà búp bê', N'Các dòng búp bê Barbie, công chúa thời trang'),
('L006', N'Đồ chơi vận động ngoài trời', N'Xe chòi chân, cầu trượt, ván trượt'),
('L007', N'Điện tử', N'Đồ chơi điện tử, máy chơi game, thiết bị thông minh'),
('L008', N'Mô hình', N'Các loại mô hình nhân vật, mô hình trưng bày');
GO

-- 3.2. NỀN TẢNG (ĐÃ BỎ FACEBOOK)
INSERT INTO NenTang (MaNenTang, TenNenTang) VALUES
('NT001', N'Tại quầy'),
('NT003', N'TikTok Shop'),
('NT004', N'Shopee'),
('NT005', N'Tại quầy, Tiktok Shop'),
('NT006', N'Tại quầy, Shopee'),
('NT007', N'Tất cả các kênh');
GO

-- 3.3. KHÁCH HÀNG
INSERT INTO KhachHang (MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai) VALUES
('KH001', N'Nguyễn Văn An', '0901000001', 120, N'Bạc', 1),
('KH002', N'Trần Thị Bình', '0901000002', 250, N'Bạc', 1);
GO

-- 3.4. NHÀ CUNG CẤP
INSERT INTO NhaCungCap (MaNCC, TenNCC, SDT, DiaChi) VALUES
('NCC01', N'Công ty TNHH Lego Việt Nam', '02838221100', N'Q1, TP. Hồ Chí Minh'),
('NCC02', N'Nhà phân phối Miniso & Mattel', '02839112233', N'Q3, TP. Hồ Chí Minh'),
('NCC03', N'Xưởng Đồ Chơi Gỗ Kim Long', '0903123456', N'Tân Bình, TP. Hồ Chí Minh'),
('NCC04', N'Tổng Kho Đồ Chơi Antona', '0918999888', N'Hoàng Mai, Hà Nội');
GO

-- 3.5. SẢN PHẨM (BỔ SUNG ĐẦY ĐỦ SP011 CÙNG BẢNG GIÁ)
INSERT INTO SanPham (MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, GiaNhap, DonGia, TonKho, HinhAnh, TrangThai) VALUES
('SP001', 'L002', N'Gấu bông Teddy Nơ', N'0-3 tuổi', N'Việt Nam', N'Gund', 100000, 150000, 45, 'teddy.jpg', 1),
('SP002', 'L002', N'Gấu bông Capybara ôm cam', N'3-6 tuổi', N'Trung Quốc', N'Miniso', 120000, 180000, 30, 'capybara.jpg', 1),
('SP003', 'L003', N'Xe ô tô Drift điều khiển từ xa', N'6-12 tuổi', N'Nhật Bản', N'Tomy', 240000, 350000, 20, 'xe_drift.jpg', 1),
('SP004', 'L003', N'Xe cứu hỏa phun nước mini', N'3-6 tuổi', N'Việt Nam', N'WinFun', 80000, 120000, 50, 'cuu_hoa.jpg', 1),
('SP005', 'L001', N'Bảng ghép chữ cái tiếng Việt gỗ', N'3-6 tuổi', N'Việt Nam', N'Antona', 60000, 95000, 60, 'chu_cai.jpg', 1),
('SP007', 'L004', N'Bộ Lego City Đồn Cảnh Sát', N'6-12 tuổi', N'Đan Mạch', N'LEGO', 350000, 490000, 25, 'lego_city.jpg', 1),
('SP009', 'L005', N'Búp bê công chúa Elsa Disney', N'3-6 tuổi', N'Mỹ', N'Mattel', 150000, 230000, 40, 'elsa.jpg', 1),
('SP010', 'L005', N'Búp bê thời trang Barbie sành điệu', N'6-12 tuổi', N'Mỹ', N'Barbie', 190000, 280000, 25, 'barbie.jpg', 1),
('SP011', 'L001', N'Đất nặn an toàn vi sinh 12 màu', N'6-12 tuổi', N'Việt Nam', N'Kim Long', 0, 40000, 2, 'dat_nan.jpg', 1),
('SP015', 'L006', N'Xe trượt Scooter 3 bánh phát sáng', N'3-6 tuổi', N'Đức', N'Globber', 450000, 650000, 15, 'scooter.jpg', 1),
('SP016', 'L006', N'Bộ bóng rổ treo tường trẻ em', N'6-12 tuổi', N'Việt Nam', N'Antona', 120000, 190000, 25, 'bong_ro.jpg', 1),
('SP017', 'L001', N'Bộ đồ chơi bác sĩ vali kéo', N'3-6 tuổi', N'Trung Quốc', N'Bowa', 110000, 170000, 20, 'bac_si.jpg', 1),
('SP018', 'L001', N'Đàn Organ Karaoke mini cho bé', N'3-6 tuổi', N'Việt Nam', N'WinFun', 210000, 320000, 18, 'organ.jpg', 1);
GO

-- 3.6. SẢN PHẨM - NỀN TẢNG (LIÊN KẾT KÊNH CHUẨN)
INSERT INTO SanPham_NenTang (MaSP, MaNenTang, GiaTrenSan) VALUES
('SP001', 'NT001', 150000), ('SP001', 'NT003', 155000),
('SP002', 'NT001', 180000), ('SP002', 'NT004', 185000),
('SP003', 'NT001', 350000),
('SP007', 'NT004', 490000),
('SP011', 'NT001', 40000),
('SP015', 'NT001', 650000), ('SP015', 'NT003', 660000),
('SP016', 'NT001', 190000),
('SP017', 'NT001', 170000),
('SP018', 'NT001', 320000);
GO

-- 3.7. MẪU PHIẾU NHẬP HÀNG & CHI TIẾT (ĐỂ TEST MÀN HÌNH LỊCH SỬ NHẬP KHO)
INSERT INTO PhieuNhap (MaPN, NgayNhap, MaNCC, NguoiLap, TongTien, GhiChu) VALUES
('PN261001001', GETDATE()-2, 'NCC01', N'Nguyễn Văn Quản Lý', 13300000, N'Nhập bổ sung đợt 1 tháng 10'),
('PN261001002', GETDATE()-5, 'NCC03', N'Trần Thị Thu Kho', 6100000, N'Nhập đồ chơi gỗ và đất nặn');
GO

INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap) VALUES
('PN261001001', 'SP007', 20, 350000),
('PN261001001', 'SP003', 15, 240000),
('PN261001002', 'SP005', 50, 60000),
('PN261001002', 'SP011', 100, 25000);
GO