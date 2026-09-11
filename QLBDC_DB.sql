

DROP TABLE IF EXISTS ChiTietHoaDon
DROP TABLE IF EXISTS HoaDon
DROP TABLE IF EXISTS SanPham
DROP TABLE IF EXISTS KhachHang
DROP TABLE IF EXISTS NenTang
DROP TABLE IF EXISTS DoTuoi
DROP TABLE IF EXISTS XuatXu
DROP TABLE IF EXISTS LoaiDoChoi
GO


/* =========================================================
   1. LOAI DO CHOI
   ========================================================= */

CREATE TABLE LoaiDoChoi
(
    MaLoai CHAR(10) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE
)
GO


/* =========================================================
   2. XUAT XU
   ========================================================= */

CREATE TABLE XuatXu
(
    MaXuatXu CHAR(10) PRIMARY KEY,
    TenXuatXu NVARCHAR(100) NOT NULL UNIQUE
)
GO


/* =========================================================
   3. DO TUOI
   ========================================================= */

CREATE TABLE DoTuoi
(
    MaDoTuoi CHAR(10) PRIMARY KEY,
    TenDoTuoi NVARCHAR(50) NOT NULL UNIQUE
)
GO


/* =========================================================
   4. SAN PHAM
   ========================================================= */

CREATE TABLE SanPham
(
    MaSP CHAR(10) PRIMARY KEY,

    TenSP NVARCHAR(200) NOT NULL,

    Hang NVARCHAR(100),

    MaLoai CHAR(10) REFERENCES LoaiDoChoi(MaLoai),

    MaXuatXu CHAR(10) REFERENCES XuatXu(MaXuatXu),

    MaDoTuoi CHAR(10) REFERENCES DoTuoi(MaDoTuoi),

    DonGia DECIMAL(18,2) NOT NULL
        CHECK (DonGia >= 0),

    TonKho INT NOT NULL DEFAULT 0
        CHECK (TonKho >= 0),

    HinhAnh NVARCHAR(500),

    -- 1 = Còn bán
    -- 0 = Ngừng bán
    TrangThai BIT NOT NULL DEFAULT 1
)
GO


/* =========================================================
   5. KHACH HANG
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
   6. NEN TANG
   ========================================================= */

CREATE TABLE NenTang
(
    MaNenTang CHAR(10) PRIMARY KEY,
    TenNenTang NVARCHAR(100) NOT NULL UNIQUE
)
GO


/* =========================================================
   7. HOA DON
   ========================================================= */

CREATE TABLE HoaDon
(
    MaHD CHAR(10) PRIMARY KEY,
    NgayLap DATETIME NOT NULL DEFAULT GETDATE(),
    MaKH CHAR(10) REFERENCES KhachHang(MaKH),
    MaNenTang CHAR(10) REFERENCES NenTang(MaNenTang),
    -- 0 = Tại quầy
    -- 1 = Online
    LoaiHoaDon BIT NOT NULL,
    TongTien DECIMAL(18,2) NOT NULL DEFAULT 0
        CHECK (TongTien >= 0),
    -- Tiền mặt / Chuyển khoản / Thu hộ
    PhuongThucThanhToan NVARCHAR(50)
        NOT NULL DEFAULT N'Tiền mặt',
    -- Đang xử lý / Đã thanh toán / Đã giao / Đã hủy
    TrangThai NVARCHAR(50)
        NOT NULL DEFAULT N'Đang xử lý',
    CONSTRAINT CK_HoaDon_PhuongThucThanhToan
        CHECK (PhuongThucThanhToan IN
        (N'Tiền mặt', N'Chuyển khoản', N'Thu hộ'))
)
GO


/* =========================================================
   8. CHI TIET HOA DON
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
   9. DU LIEU LOAI DO CHOI
   ========================================================= */

INSERT INTO LoaiDoChoi (MaLoai, TenLoai)
VALUES
('L001', N'Đồ chơi giáo dục'),
('L002', N'Gấu bông'),
('L003', N'Xe đồ chơi'),
('L004', N'Đồ chơi lắp ráp'),
('L005', N'Búp bê')
GO


/* =========================================================
   10. DU LIEU XUAT XU
   ========================================================= */

INSERT INTO XuatXu (MaXuatXu, TenXuatXu)
VALUES
('XX001', N'Việt Nam'),
('XX002', N'Nhật Bản'),
('XX003', N'Hàn Quốc'),
('XX004', N'Trung Quốc'),
('XX005', N'Mỹ')
GO


/* =========================================================
   11. DU LIEU DO TUOI
   ========================================================= */

INSERT INTO DoTuoi (MaDoTuoi, TenDoTuoi)
VALUES
('DT001', N'0-3 tuổi'),
('DT002', N'3-6 tuổi'),
('DT003', N'6-12 tuổi'),
('DT004', N'Trên 12 tuổi')
GO


/* =========================================================
   12. DU LIEU SAN PHAM
   ========================================================= */

INSERT INTO SanPham
(
    MaSP,
    TenSP,
    Hang,
    MaLoai,
    MaXuatXu,
    MaDoTuoi,
    DonGia,
    TonKho,
    HinhAnh,
    TrangThai
)
VALUES
('SP001', N'Gấu bông Teddy', N'Gund', 'L002', 'XX001', 'DT001', 150000, 30, NULL, 1),
('SP002', N'Gấu bông Capybara', N'Miniso', 'L002', 'XX004', 'DT002', 180000, 25, NULL, 1),
('SP003', N'Xe ô tô điều khiển', N'Tomy', 'L003', 'XX002', 'DT003', 350000, 15, NULL, 1),
('SP004', N'Xe cứu hỏa mini', N'WinFun', 'L003', 'XX001', 'DT002', 120000, 40, NULL, 1),
('SP005', N'Bộ xếp hình chữ cái', N'Antona', 'L001', 'XX001', 'DT002', 90000, 50, NULL, 1),
('SP006', N'Bộ học toán thông minh', N'Learning Resources', 'L001', 'XX002', 'DT003', 160000, 35, NULL, 1),
('SP007', N'Bộ Lego thành phố', N'LEGO', 'L004', 'XX004', 'DT003', 450000, 20, NULL, 1),
('SP008', N'Robot lắp ráp', N'Hasbro', 'L004', 'XX005', 'DT004', 550000, 12, NULL, 1),
('SP009', N'Búp bê công chúa', N'Mattel', 'L005', 'XX003', 'DT002', 220000, 25, NULL, 1),
('SP010', N'Búp bê thời trang', N'Barbie', 'L005', 'XX005', 'DT003', 280000, 18, NULL, 1),
('SP011', N'Đàn piano mini', N'WinFun', 'L001', 'XX002', 'DT002', 200000, 20, NULL, 1),
('SP012', N'Bộ bác sĩ nhí', N'Antona', 'L001', 'XX001', 'DT002', 175000, 30, NULL, 1),
('SP013', N'Máy bay mô hình', N'Tomy', 'L003', 'XX004', 'DT004', 320000, 14, NULL, 1),
('SP014', N'Rubik 3x3', N'Rubik', 'L004', 'XX002', 'DT004', 100000, 45, NULL, 1),
('SP015', N'Gấu bông thỏ trắng', N'Miniso', 'L002', 'XX003', 'DT001', 140000, 28, NULL, 1)
GO


/* =========================================================
   13. DU LIEU KHACH HANG
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
   14. DU LIEU NEN TANG
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
   15. DU LIEU HOA DON
   ========================================================= */

INSERT INTO HoaDon
(
    MaHD,
    NgayLap,
    MaKH,
    MaNenTang,
    LoaiHoaDon,
    TongTien,
    PhuongThucThanhToan,
    TrangThai
)
VALUES

-- TẠI QUẦY

('HD001', '2026-08-20 09:15:00', 'KH001', NULL, 0, 330000, N'Tiền mặt', N'Đã thanh toán'),

('HD002', '2026-08-21 10:30:00', 'KH002', NULL, 0, 450000, N'Chuyển khoản', N'Đã thanh toán'),

('HD003', '2026-08-22 14:20:00', 'KH003', NULL, 0, 220000, N'Tiền mặt', N'Đã thanh toán'),

('HD004', '2026-08-23 16:45:00', 'KH004', NULL, 0, 550000, N'Chuyển khoản', N'Đã thanh toán'),

('HD005', '2026-08-24 11:10:00', 'KH005', NULL, 0, 175000, N'Tiền mặt', N'Đã thanh toán'),


-- ONLINE - FACEBOOK

('HD006', '2026-08-24 19:30:00', 'KH006', 'NT001', 1, 500000, N'Thu hộ', N'Đang xử lý'),

('HD007', '2026-08-25 08:40:00', 'KH007', 'NT001', 1, 360000, N'Chuyển khoản', N'Đã thanh toán'),

('HD008', '2026-08-26 13:15:00', 'KH008', 'NT001', 1, 450000, N'Thu hộ', N'Đã giao'),


-- ONLINE - TIKTOK

('HD009', '2026-08-26 15:30:00', 'KH001', 'NT002', 1, 700000, N'Thu hộ', N'Đang xử lý'),

('HD010', '2026-08-27 09:45:00', 'KH002', 'NT002', 1, 280000, N'Chuyển khoản', N'Đã thanh toán'),


-- ONLINE - SHOPEE

('HD011', '2026-08-27 14:10:00', 'KH003', 'NT003', 1, 550000, N'Thu hộ', N'Đã giao'),

('HD012', '2026-08-28 10:20:00', 'KH004', 'NT003', 1, 450000, N'Chuyển khoản', N'Đã thanh toán'),


-- ONLINE - LAZADA

('HD013', '2026-08-28 17:00:00', 'KH005', 'NT004', 1, 420000, N'Thu hộ', N'Đang xử lý'),

('HD014', '2026-08-29 12:25:00', 'KH006', 'NT004', 1, 320000, N'Chuyển khoản', N'Đã giao'),

('HD015', '2026-08-30 09:30:00', 'KH007', 'NT001', 1, 730000, N'Thu hộ', N'Đã hủy')
GO


/* =========================================================
   16. DU LIEU CHI TIET HOA DON
   ========================================================= */

INSERT INTO ChiTietHoaDon
(
    MaHD,
    MaSP,
    SoLuong,
    DonGia
)
VALUES

-- HD001 = 150000 + 180000 = 330000

('HD001', 'SP001', 1, 150000),

('HD001', 'SP002', 1, 180000),


-- HD002 = 450000

('HD002', 'SP007', 1, 450000),


-- HD003 = 220000

('HD003', 'SP009', 1, 220000),


-- HD004 = 550000

('HD004', 'SP008', 1, 550000),


-- HD005 = 175000

('HD005', 'SP012', 1, 175000),


-- HD006 = 350000 + 150000 = 500000

('HD006', 'SP003', 1, 350000),

('HD006', 'SP001', 1, 150000),


-- HD007 = 180000 x 2 = 360000

('HD007', 'SP002', 2, 180000),


-- HD008 = 450000

('HD008', 'SP007', 1, 450000),


-- HD009 = 350000 x 2 = 700000

('HD009', 'SP003', 2, 350000),


-- HD010 = 280000

('HD010', 'SP010', 1, 280000),


-- HD011 = 550000

('HD011', 'SP008', 1, 550000),


-- HD012 = 450000

('HD012', 'SP007', 1, 450000),


-- HD013 = 220000 + 200000 = 420000

('HD013', 'SP009', 1, 220000),

('HD013', 'SP011', 1, 200000),


-- HD014 = 320000

('HD014', 'SP013', 1, 320000),


-- HD015 = 450000 + 280000 = 730000

('HD015', 'SP007', 1, 450000),

('HD015', 'SP010', 1, 280000)
GO


/* =========================================================
   17. KIEM TRA DU LIEU
   ========================================================= */

SELECT * FROM LoaiDoChoi
SELECT * FROM XuatXu
SELECT * FROM DoTuoi
SELECT * FROM SanPham
SELECT * FROM KhachHang
SELECT * FROM NenTang
SELECT * FROM HoaDon
SELECT * FROM ChiTietHoaDon
GO
