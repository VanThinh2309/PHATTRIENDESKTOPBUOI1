DROP TABLE IF EXISTS ChiTietHoaDon
DROP TABLE IF EXISTS HoaDon
DROP TABLE IF EXISTS SanPham
DROP TABLE IF EXISTS KhachHang
DROP TABLE IF EXISTS NenTang
DROP TABLE IF EXISTS LoaiDoChoi
GO


/* =========================================================
   1. LOAI DO CHOI
   ========================================================= */

CREATE TABLE LoaiDoChoi
(
    MaLoai CHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500)
)
GO


/* =========================================================
   2. SAN PHAM
   ========================================================= */

CREATE TABLE SanPham
(
    MaSP CHAR(10) PRIMARY KEY,
    MaLoai CHAR(10) REFERENCES LoaiDoChoi(MaLoai),
    TenSP NVARCHAR(200) NOT NULL,
    DoTuoi NVARCHAR(50),
    TenXuatXu NVARCHAR(100),
    Hang NVARCHAR(100),
    DonGia DECIMAL(18,2) NOT NULL
        CHECK (DonGia >= 0),
    TonKho INT NOT NULL DEFAULT 0
        CHECK (TonKho >= 0),
    HinhAnh NVARCHAR(500),
    -- 1 = Còn bán, 0 = Ngừng bán
    TrangThai BIT NOT NULL DEFAULT 1
)
GO


/* =========================================================
   3. KHACH HANG
   ========================================================= */

CREATE TABLE KhachHang
(
    MaKH CHAR(10) PRIMARY KEY, 
    TenKH NVARCHAR(150) NOT NULL, 
    SDT VARCHAR(15) UNIQUE, 
    DiemTichLuy INT NOT NULL DEFAULT 0, 
    HangKhachHang NVARCHAR(50) NOT NULL DEFAULT N'Đồng',
    TrangThai BIT NOT NULL DEFAULT 1
)
GO


/* =========================================================
   4. NEN TANG
   ========================================================= */

CREATE TABLE NenTang
(
    MaNenTang CHAR(10) PRIMARY KEY,
    TenNenTang NVARCHAR(100) NOT NULL UNIQUE
)
GO


/* =========================================================
   5. HOA DON
   ========================================================= */

CREATE TABLE HoaDon
(
    MaHD CHAR(10) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaKH CHAR(10) REFERENCES KhachHang(MaKH),
    MaNenTang CHAR(10) REFERENCES NenTang(MaNenTang),
    GhiChu NVARCHAR(500),
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (TongTien >= 0),
    -- Tiền mặt / Chuyển khoản / Thu hộ
    PhuongThucThanhToan NVARCHAR(50)
        NOT NULL DEFAULT N'Tiền mặt',
    -- Đang xử lý / Đã thanh toán / Đã giao / Đã hủy
    TrangThai NVARCHAR(50)
        NOT NULL DEFAULT N'Đang xử lý',
    DiaChi NVARCHAR(255),
    DonViVanChuyen NVARCHAR(100),
    CONSTRAINT CK_HoaDon_PhuongThucThanhToan
        CHECK (PhuongThucThanhToan IN
        (N'Tiền mặt', N'Chuyển khoản', N'Thu hộ'))
)
GO


/* =========================================================
   6. CHI TIET HOA DON
   ========================================================= */

CREATE TABLE ChiTietHoaDon
(
    MaHD CHAR(10) REFERENCES HoaDon(MaHD),
    MaSP CHAR(10) REFERENCES SanPham(MaSP),
    SoLuong INT NOT NULL
        CHECK (SoLuong > 0),
    -- Giá sản phẩm tại thời điểm bán
    DonGia DECIMAL(18,2) NOT NULL
        CHECK (DonGia >= 0),

    PRIMARY KEY (MaHD, MaSP)
)
GO


/* =========================================================
   7. DU LIEU LOAI DO CHOI
   ========================================================= */

INSERT INTO LoaiDoChoi (MaLoai, TenLoai, MoTa)
VALUES
('L001', N'Đồ chơi giáo dục', N'Giúp phát triển trí tuệ và tư duy cho bé'),
('L002', N'Gấu bông', N'Các loại thú nhồi bông mềm mại, an toàn'),
('L003', N'Xe đồ chơi', N'Mô hình các phương tiện giao thông, điều khiển từ xa'),
('L004', N'Đồ chơi lắp ráp', N'Rèn luyện tính kiên nhẫn và sáng tạo'),
('L005', N'Búp bê', N'Các dòng búp bê thời trang và công chúa')
GO


/* =========================================================
   8. DU LIEU SAN PHAM
   ========================================================= */

INSERT INTO SanPham
(
    MaSP,
    MaLoai,
    TenSP,
    DoTuoi,
    TenXuatXu,
    Hang,
    DonGia,
    TonKho,
    HinhAnh,
    TrangThai
)
VALUES
('SP001', 'L002', N'Gấu bông Teddy', N'0-3 tuổi', N'Việt Nam', N'Gund', 150000, 30, NULL, 1),
('SP002', 'L002', N'Gấu bông Capybara', N'3-6 tuổi', N'Trung Quốc', N'Miniso', 180000, 25, NULL, 1),
('SP003', 'L003', N'Xe ô tô điều khiển', N'6-12 tuổi', N'Nhật Bản', N'Tomy', 350000, 15, NULL, 1),
('SP004', 'L003', N'Xe cứu hỏa mini', N'3-6 tuổi', N'Việt Nam', N'WinFun', 120000, 40, NULL, 1),
('SP005', 'L001', N'Bộ xếp hình chữ cái', N'3-6 tuổi', N'Việt Nam', N'Antona', 90000, 50, NULL, 1),
('SP006', 'L001', N'Bộ học toán thông minh', N'6-12 tuổi', N'Nhật Bản', N'Learning Resources', 160000, 35, NULL, 1),
('SP007', 'L004', N'Bộ Lego thành phố', N'6-12 tuổi', N'Trung Quốc', N'LEGO', 450000, 20, NULL, 1),
('SP008', 'L004', N'Robot lắp ráp', N'Trên 12 tuổi', N'Mỹ', N'Hasbro', 550000, 12, NULL, 1),
('SP009', 'L005', N'Búp bê công chúa', N'3-6 tuổi', N'Hàn Quốc', N'Mattel', 220000, 25, NULL, 1),
('SP010', 'L005', N'Búp bê thời trang', N'6-12 tuổi', N'Mỹ', N'Barbie', 280000, 18, NULL, 1),
('SP011', 'L001', N'Đàn piano mini', N'3-6 tuổi', N'Nhật Bản', N'WinFun', 200000, 20, NULL, 1),
('SP012', 'L001', N'Bộ bác sĩ nhí', N'3-6 tuổi', N'Việt Nam', N'Antona', 175000, 30, NULL, 1),
('SP013', 'L003', N'Máy bay mô hình', N'Trên 12 tuổi', N'Trung Quốc', N'Tomy', 320000, 14, NULL, 1),
('SP014', 'L004', N'Rubik 3x3', N'Trên 12 tuổi', N'Nhật Bản', N'Rubik', 100000, 45, NULL, 1),
('SP015', 'L002', N'Gấu bông thỏ trắng', N'0-3 tuổi', N'Hàn Quốc', N'Miniso', 140000, 28, NULL, 1)
GO


/* =========================================================
   9. DU LIEU KHACH HANG
   ========================================================= */

INSERT INTO KhachHang 
( 
    MaKH, 
    TenKH, 
    SDT, 
    DiemTichLuy,
    HangKhachHang
) 
VALUES 
('KH001', N'Nguyễn Văn An', '0901000001', 120, N'Bạc'), 
('KH002', N'Trần Thị Bình', '0901000002', 250, N'Bạc'), 
('KH003', N'Lê Minh Châu', '0901000003', 80, N'Đồng'), 
('KH004', N'Phạm Hoàng Nam', '0901000004', 320, N'Vàng'), 
('KH005', N'Võ Ngọc Anh', '0901000005', 150, N'Bạc'), 
('KH006', N'Đặng Minh Khang', '0901000006', 60, N'Đồng'), 
('KH007', N'Nguyễn Thảo Vy', '0901000007', 400, N'Vàng'), 
('KH008', N'Lê Quốc Bảo', '0901000008', 100, N'Bạc'); 
GO


/* =========================================================
   10. DU LIEU NEN TANG
   ========================================================= */

INSERT INTO NenTang
(
    MaNenTang,
    TenNenTang
)
VALUES
('NT001', N'Facebook'),
('NT002', N'TikTok'),
('NT003', N'Shopee'),
('NT004', N'Lazada')
GO


/* =========================================================
   11. DU LIEU HOA DON
   ========================================================= */

INSERT INTO HoaDon
(
    MaHD,
    NgayLap,
    MaKH,
    MaNenTang,
    GhiChu,
    TongTien,
    PhuongThucThanhToan,
    TrangThai,
    DiaChi,
    DonViVanChuyen
)
VALUES

-- TẠI QUẦY
('HD001', '2026-08-20 09:15:00', 'KH001', NULL, N'Mua tại cửa hàng', 330000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),
('HD002', '2026-08-21 10:30:00', 'KH002', NULL, N'Khách lấy hóa đơn VAT', 450000, N'Chuyển khoản', N'Đã thanh toán', NULL, NULL),
('HD003', '2026-08-22 14:20:00', 'KH003', NULL, NULL, 220000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),
('HD004', '2026-08-23 16:45:00', 'KH004', NULL, N'Quà tặng sinh nhật', 550000, N'Chuyển khoản', N'Đã thanh toán', NULL, NULL),
('HD005', '2026-08-24 11:10:00', 'KH005', NULL, NULL, 175000, N'Tiền mặt', N'Đã thanh toán', NULL, NULL),

-- ONLINE - FACEBOOK
('HD006', '2026-08-24 19:30:00', 'KH006', 'NT001', N'Giao buổi tối', 500000, N'Thu hộ', N'Đang xử lý', N'123 Lê Lợi, Q.1, TP.HCM', N'Giao Hàng Nhanh'),
('HD007', '2026-08-25 08:40:00', 'KH007', 'NT001', NULL, 360000, N'Chuyển khoản', N'Đã thanh toán', N'456 Nguyễn Huệ, Q.1, TP.HCM', N'Viettel Post'),
('HD008', '2026-08-26 13:15:00', 'KH008', 'NT001', N'Gọi trước khi giao', 450000, N'Thu hộ', N'Đã giao', N'789 Cách Mạng T8, Q.3, TP.HCM', N'Giao Hàng Tiết Kiệm'),

-- ONLINE - TIKTOK
('HD009', '2026-08-26 15:30:00', 'KH001', 'NT002', NULL, 700000, N'Thu hộ', N'Đang xử lý', N'12 Điện Biên Phủ, Q.Bình Thạnh, TP.HCM', N'J&T Express'),
('HD010', '2026-08-27 09:45:00', 'KH002', 'NT002', N'Gói quà cẩn thận', 280000, N'Chuyển khoản', N'Đã thanh toán', N'34 Võ Thị Sáu, Q.3, TP.HCM', N'Giao Hàng Nhanh'),

-- ONLINE - SHOPEE
('HD011', '2026-08-27 14:10:00', 'KH003', 'NT003', NULL, 550000, N'Thu hộ', N'Đã giao', N'56 Hoàng Văn Thụ, Q.Phú Nhuận, TP.HCM', N'SPX Express'),
('HD012', '2026-08-28 10:20:00', 'KH004', 'NT003', N'Đã áp voucher giảm giá', 450000, N'Chuyển khoản', N'Đã thanh toán', N'78 Lý Thường Kiệt, Q.10, TP.HCM', N'SPX Express'),

-- ONLINE - LAZADA
('HD013', '2026-08-28 17:00:00', 'KH005', 'NT004', NULL, 420000, N'Thu hộ', N'Đang xử lý', N'90 Trần Hưng Đạo, Q.5, TP.HCM', N'Lazada Express'),
('HD014', '2026-08-29 12:25:00', 'KH006', 'NT004', NULL, 320000, N'Chuyển khoản', N'Đã giao', N'11 Nguyễn Trãi, Q.5, TP.HCM', N'LEX Express'),
('HD015', '2026-08-30 09:30:00', 'KH007', 'NT001', N'Khách hủy do đổi ý', 730000, N'Thu hộ', N'Đã hủy', N'456 Nguyễn Huệ, Q.1, TP.HCM', N'Giao Hàng Tiết Kiệm')
GO


/* =========================================================
   12. DU LIEU CHI TIET HOA DON
   ========================================================= */

INSERT INTO ChiTietHoaDon
(
    MaHD,
    MaSP,
    SoLuong,
    DonGia
)
VALUES
('HD001', 'SP001', 1, 150000),
('HD001', 'SP002', 1, 180000),
('HD002', 'SP007', 1, 450000),
('HD003', 'SP009', 1, 220000),
('HD004', 'SP008', 1, 550000),
('HD005', 'SP012', 1, 175000),
('HD006', 'SP003', 1, 350000),
('HD006', 'SP001', 1, 150000),
('HD007', 'SP002', 2, 180000),
('HD008', 'SP007', 1, 450000),
('HD009', 'SP003', 2, 350000),
('HD010', 'SP010', 1, 280000),
('HD011', 'SP008', 1, 550000),
('HD012', 'SP007', 1, 450000),
('HD013', 'SP009', 1, 220000),
('HD013', 'SP011', 1, 200000),
('HD014', 'SP013', 1, 320000),
('HD015', 'SP007', 1, 450000),
('HD015', 'SP010', 1, 280000)
GO


/* =========================================================
   13. KIEM TRA DU LIEU
   ========================================================= */

SELECT * FROM LoaiDoChoi
SELECT * FROM SanPham
SELECT * FROM KhachHang
SELECT * FROM NenTang
SELECT * FROM HoaDon
SELECT * FROM ChiTietHoaDon
GO