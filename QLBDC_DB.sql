/* =========================================================================
   DỰ ÁN: QUẢN LÝ CỬA HÀNG BÁN ĐỒ CHƠI TRẺ EM (QuanLyBanDoChoi)
   CƠ SỞ DỮ LIỆU: SQL SERVER
   ========================================================================= */

-- Tạo cơ sở dữ liệu nếu chưa tồn tại
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'QuanLyBanDoChoi')
BEGIN
    CREATE DATABASE QuanLyBanDoChoi;
END
GO

USE QuanLyBanDoChoi;
GO

/* =========================================================================
   1. XÓA BẢNG CŨ (Theo đúng thứ tự khóa ngoại để tránh xung đột)
   ========================================================================= */

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

-- 2.1. LOẠI ĐỒ CHƠI (LoaiDoChoi)
CREATE TABLE LoaiDoChoi
(
    MaLoai CHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500)
);
GO

-- 2.2. NỀN TẢNG BÁN HÀNG (NenTang: Cửa hàng, Shopee, TikTok, v.v.)
CREATE TABLE NenTang
(
    MaNenTang CHAR(10) PRIMARY KEY,
    TenNenTang NVARCHAR(100) NOT NULL UNIQUE
);
GO

-- 2.3. KHÁCH HÀNG (KhachHang)
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

-- 2.4. SẢN PHẨM (SanPham)
CREATE TABLE SanPham
(
    MaSP CHAR(10) PRIMARY KEY,
    MaLoai CHAR(10) REFERENCES LoaiDoChoi(MaLoai) ON UPDATE CASCADE ON DELETE SET NULL,
    TenSP NVARCHAR(200) NOT NULL,
    DoTuoi NVARCHAR(50),
    TenXuatXu NVARCHAR(100),
    Hang NVARCHAR(100),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    TonKho INT NOT NULL DEFAULT 0 CHECK (TonKho >= 0),
    HinhAnh NVARCHAR(500),
    TrangThai BIT NOT NULL DEFAULT 1 -- 1 = Còn bán, 0 = Ngừng bán
);
GO

-- 2.5. HÓA ĐƠN (HoaDon)
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

-- 2.6. CHI TIẾT HÓA ĐƠN (ChiTietHoaDon - Khóa chính phức hợp MaHD + MaSP)
CREATE TABLE ChiTietHoaDon
(
    MaHD CHAR(10) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    MaSP CHAR(10) REFERENCES SanPham(MaSP) ON UPDATE CASCADE,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    PRIMARY KEY (MaHD, MaSP)
);
GO

/* =========================================================================
   3. CHÈN DỮ LIỆU MẪU (MOCK DATA)
   ========================================================================= */

-- 3.1. Dữ liệu LoaiDoChoi (8 dòng)
INSERT INTO LoaiDoChoi (MaLoai, TenLoai, MoTa) VALUES
('L001', N'Đồ chơi giáo dục & Trí tuệ', N'Giúp phát triển trí tuệ, khả năng tư duy logic và giải quyết vấn đề'),
('L002', N'Thú nhồi bông & Gấu bông', N'Các loại thú bông cao cấp chất liệu mềm mịn, an toàn tuyệt đối'),
('L003', N'Xe mô hình & Điều khiển từ xa', N'Xe ô tô, xe máy, xe chuyên dụng điều khiển từ xa cao cấp'),
('L004', N'Lắp ráp & Xếp hình khối', N'Các bộ Lego, Nanoblock phát triển kỹ năng lắp ráp và tính kiên nhẫn'),
('L005', N'Búp bê & Nhà búp bê', N'Các dòng búp bê Barbie, công chúa thời trang và phụ kiện nhà ở'),
('L006', N'Đồ chơi vận động ngoài trời', N'Xe chòi chân, cầu trượt, ván trượt, bóng rổ cho bé vận động khỏe khoắn'),
('L007', N'Đồ chơi nhà bếp & Hướng nghiệp', N'Bộ dụng cụ bác sĩ, nấu ăn, thợ cơ khí nhập vai hướng nghiệp'),
('L008', N'Nhạc cụ & Âm thanh thiếu nhi', N'Đàn organ, đàn guitar mini, trống đồ chơi kích thích thính giác');
GO

-- 3.2. Dữ liệu NenTang (6 dòng)
INSERT INTO NenTang (MaNenTang, TenNenTang) VALUES
('NT001', N'Tại quầy (Offline)'),
('NT002', N'Facebook'),
('NT003', N'TikTok Shop'),
('NT004', N'Shopee'),
('NT005', N'Lazada'),
('NT006', N'Website Cửa Hàng');
GO

-- 3.3. Dữ liệu KhachHang (10 dòng)
INSERT INTO KhachHang (MaKH, TenKH, SDT, DiemTichLuy, HangKhachHang, TrangThai) VALUES
('KH001', N'Nguyễn Văn An',     '0901000001', 120, N'Bạc',       1),
('KH002', N'Trần Thị Bình',     '0901000002', 250, N'Bạc',       1),
('KH003', N'Lê Minh Châu',      '0901000003', 80,  N'Đồng',      1),
('KH004', N'Phạm Hoàng Nam',    '0901000004', 320, N'Vàng',      1),
('KH005', N'Võ Ngọc Anh',       '0901000005', 150, N'Bạc',       1),
('KH006', N'Đặng Minh Khang',   '0901000006', 60,  N'Đồng',      1),
('KH007', N'Nguyễn Thảo Vy',    '0901000007', 480, N'Kim Cương', 1),
('KH008', N'Lê Quốc Bảo',       '0901000008', 100, N'Bạc',       1),
('KH009', N'Hoàng Yến Nhi',     '0901000009', 20,  N'Đồng',      1),
('KH010', N'Bùi Đức Phúc',      '0901000010', 310, N'Vàng',      1);
GO

-- 3.4. Dữ liệu SanPham (15 dòng)
INSERT INTO SanPham (MaSP, MaLoai, TenSP, DoTuoi, TenXuatXu, Hang, DonGia, TonKho, HinhAnh, TrangThai) VALUES
('SP001', 'L002', N'Gấu bông Teddy Nơ', N'0-3 tuổi', N'Việt Nam', N'Gund', 150000, 45, 'teddy.jpg', 1),
('SP002', 'L002', N'Gấu bông Capybara ôm cam', N'3-6 tuổi', N'Trung Quốc', N'Miniso', 180000, 30, 'capybara.jpg', 1),
('SP003', 'L003', N'Xe ô tô Drift điều khiển từ xa', N'6-12 tuổi', N'Nhật Bản', N'Tomy', 350000, 20, 'xe_drift.jpg', 1),
('SP004', 'L003', N'Xe cứu hỏa phun nước mini', N'3-6 tuổi', N'Việt Nam', N'WinFun', 120000, 50, 'cuu_hoa.jpg', 1),
('SP005', 'L001', N'Bảng ghép chữ cái tiếng Việt gỗ', N'3-6 tuổi', N'Việt Nam', N'Antona', 95000, 60, 'chu_cai.jpg', 1),
('SP006', 'L001', N'Bộ học toán bàn tính thông minh', N'6-12 tuổi', N'Mỹ', N'Learning Resources', 160000, 35, 'ban_tinh.jpg', 1),
('SP007', 'L004', N'Bộ Lego City Đồn Cảnh Sát', N'6-12 tuổi', N'Đan Mạch', N'LEGO', 490000, 25, 'lego_city.jpg', 1),
('SP008', 'L004', N'Robot biến hình Transformers', N'Trên 12 tuổi', N'Mỹ', N'Hasbro', 550000, 15, 'transformers.jpg', 1),
('SP009', 'L005', N'Búp bê công chúa Elsa Disney', N'3-6 tuổi', N'Mỹ', N'Mattel', 230000, 40, 'elsa.jpg', 1),
('SP010', 'L005', N'Búp bê thời trang Barbie sành điệu', N'6-12 tuổi', N'Mỹ', N'Barbie', 280000, 25, 'barbie.jpg', 1),
('SP011', 'L008', N'Đàn Piano mini kèm micro', N'3-6 tuổi', N'Nhật Bản', N'WinFun', 210000, 20, 'piano_mini.jpg', 1),
('SP012', 'L007', N'Bộ đồ chơi bác sĩ 18 chi tiết', N'3-6 tuổi', N'Việt Nam', N'Antona', 175000, 35, 'bac_si.jpg', 1),
('SP013', 'L003', N'Máy bay trực thăng cảm ứng', N'Trên 12 tuổi', N'Trung Quốc', N'Tomy', 320000, 18, 'truc_thang.jpg', 1),
('SP014', 'L001', N'Khối Rubik 3x3 MoYu Speed', N'Trên 12 tuổi', N'Trung Quốc', N'MoYu', 110000, 80, 'rubik.jpg', 1),
('SP015', 'L006', N'Xe trượt Scooter 3 bánh phát sáng', N'3-6 tuổi', N'Đức', N'Globber', 650000, 15, 'scooter.jpg', 1);
GO

-- 3.5. Dữ liệu HoaDon (15 dòng)
INSERT INTO HoaDon 
(MaHD, NgayLap, MaKH, MaNenTang, GhiChu, TongTien, PhuongThucThanhToan, TrangThai, DiaChi, DonViVanChuyen) 
VALUES
('HD001', '2026-08-20 09:15:00', 'KH001', 'NT001', N'Khách mua trực tiếp tại quầy', 330000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),
('HD002', '2026-08-21 10:30:00', 'KH002', 'NT001', N'Khách quét mã VietQR', 490000, N'Chuyển khoản', N'Đã thanh toán', NULL, NULL),
('HD003', '2026-08-22 14:20:00', 'KH003', 'NT001', N'Mua làm quà sinh nhật cho bé', 230000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),
('HD004', '2026-08-23 16:45:00', 'KH004', 'NT001', N'Khách tích điểm thành viên', 550000, N'Chuyển khoản', N'Đã thanh toán', NULL, NULL),
('HD005', '2026-08-24 11:10:00', 'KH005', 'NT001', N'Khách quen', 175000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),
('HD006', '2026-08-24 19:30:00', 'KH006', 'NT002', N'Giao hàng giờ hành chính', 500000, N'Thu hộ', N'Đang xử lý', N'123 Lê Lợi, P.Bến Nghé, Quận 1, TP.HCM', N'Giao Hàng Nhanh'),
('HD007', '2026-08-25 08:40:00', 'KH007', 'NT002', N'Đóng gói cẩn thận', 360000, N'Chuyển khoản', N'Đã thanh toán', N'456 Nguyễn Huệ, P.Bến Nghé, Quận 1, TP.HCM', N'Viettel Post'),
('HD008', '2026-08-26 13:15:00', 'KH008', 'NT002', N'Gọi trước khi giao 15 phút', 490000, N'Thu hộ', N'Đã giao', N'789 Cách Mạng Tháng 8, Quận 3, TP.HCM', N'Giao Hàng Tiết Kiệm'),
('HD009', '2026-08-26 15:30:00', 'KH001', 'NT003', N'Đơn hàng TikTok Live', 700000, N'Thu hộ', N'Đang xử lý', N'12 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', N'J&T Express'),
('HD010', '2026-08-27 09:45:00', 'KH002', 'NT003', N'Gói quà kèm thiệp chúc mừng', 280000, N'Chuyển khoản', N'Đã thanh toán', N'34 Võ Thị Sáu, Quận 3, TP.HCM', N'Giao Hàng Nhanh'),
('HD011', '2026-08-27 14:10:00', 'KH003', 'NT004', N'Đơn hàng Shopee Mall', 550000, N'Thu hộ', N'Đã giao', N'56 Hoàng Văn Thụ, Quận Phú Nhuận, TP.HCM', N'SPX Express'),
('HD012', '2026-08-28 10:20:00', 'KH004', 'NT004', N'Áp mã giảm giá sàn 50k', 490000, N'Chuyển khoản', N'Đã thanh toán', N'78 Lý Thường Kiệt, Quận 10, TP.HCM', N'SPX Express'),
('HD013', '2026-08-28 17:00:00', 'KH005', 'NT005', N'Giao cuối tuần', 440000, N'Thu hộ', N'Đang xử lý', N'90 Trần Hưng Đạo, Quận 5, TP.HCM', N'Lazada Express'),
('HD014', '2026-08-29 12:25:00', 'KH006', 'NT005', N'Đã đồng kiểm khi nhận', 320000, N'Chuyển khoản', N'Đã giao', N'11 Nguyễn Trãi, Quận 5, TP.HCM', N'LEX Express'),
('HD015', '2026-08-30 09:30:00', 'KH007', 'NT006', N'Khách đặt qua Website', 770000, N'Thu hộ', N'Đang xử lý', N'88 Phạm Ngọc Thạch, Quận 3, TP.HCM', N'Giao Hàng Nhanh');
GO

-- 3.6. Dữ liệu ChiTietHoaDon (20 dòng)
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia) VALUES
('HD001', 'SP001', 1, 150000),
('HD001', 'SP002', 1, 180000),
('HD002', 'SP007', 1, 490000),
('HD003', 'SP009', 1, 230000),
('HD004', 'SP008', 1, 550000),
('HD005', 'SP012', 1, 175000),
('HD006', 'SP003', 1, 350000),
('HD006', 'SP001', 1, 150000),
('HD007', 'SP002', 2, 180000),
('HD008', 'SP007', 1, 490000),
('HD009', 'SP003', 2, 350000),
('HD010', 'SP010', 1, 280000),
('HD011', 'SP008', 1, 550000),
('HD012', 'SP007', 1, 490000),
('HD013', 'SP009', 1, 230000),
('HD013', 'SP011', 1, 210000),
('HD014', 'SP013', 1, 320000),
('HD015', 'SP007', 1, 490000),
('HD015', 'SP010', 1, 280000),
('HD015', 'SP014', 1, 110000);
GO

/* =========================================================
   4. CÂU LỆNH KIỂM TRA DỮ LIỆU ĐÃ NẠP
   ========================================================= */

SELECT COUNT(*) AS TongSoLoaiDoChoi FROM LoaiDoChoi;
SELECT COUNT(*) AS TongSoNenTang FROM NenTang;
SELECT COUNT(*) AS TongSoKhachHang FROM KhachHang;
SELECT COUNT(*) AS TongSoSanPham FROM SanPham;
SELECT COUNT(*) AS TongSoHoaDon FROM HoaDon;
SELECT COUNT(*) AS TongSoChiTietHoaDon FROM ChiTietHoaDon;
GO
