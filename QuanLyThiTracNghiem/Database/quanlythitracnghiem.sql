-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th9 22, 2025 lúc 08:53 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlythitracnghiem`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `bailam`
--

CREATE TABLE `bailam` (
  `maBaiLam` int(11) NOT NULL,
  `maSinhVien` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `maDe` int(11) NOT NULL,
  `tongDiem` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cauhoi`
--

CREATE TABLE `cauhoi` (
  `maCauHoi` int(11) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `maChuong` int(11) NOT NULL,
  `doKho` varchar(50) NOT NULL,
  `noiDungCauHoi` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cauhoi-dekiemtra`
--

CREATE TABLE `cauhoi-dekiemtra` (
  `maDe` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietbailam`
--

CREATE TABLE `chitietbailam` (
  `maBaiLam` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL,
  `maDapAnDuocChon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chuong`
--

CREATE TABLE `chuong` (
  `maChuong` int(11) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `tenChuong` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dapan`
--

CREATE TABLE `dapan` (
  `maDapAn` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL,
  `tenDapAn` varchar(255) NOT NULL,
  `dungSai` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dekiemtra`
--

CREATE TABLE `dekiemtra` (
  `maDe` int(11) NOT NULL,
  `tenDe` varchar(255) NOT NULL,
  `thoiGianBatDau` datetime NOT NULL,
  `thoiGianKetThuc` datetime NOT NULL,
  `thoiGianCanhBao` datetime NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `soCauDe` int(11) NOT NULL,
  `soCauTrungBinh` int(11) NOT NULL,
  `soCauKho` int(11) NOT NULL,
  `trangThai` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dekiemtra-nhom`
--

CREATE TABLE `dekiemtra-nhom` (
  `maDe` int(11) NOT NULL,
  `maNhom` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `giaovien`
--

CREATE TABLE `giaovien` (
  `maGiaoVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `tenGiaoVien` varchar(50) NOT NULL,
  `email` varchar(255) NOT NULL,
  `SDT` varchar(11) NOT NULL,
  `moTa` varchar(255) DEFAULT NULL,
  `quyen` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `monhoc`
--

CREATE TABLE `monhoc` (
  `maMonHoc` varchar(11) NOT NULL,
  `tenMonHoc` varchar(50) NOT NULL,
  `tinChi` int(11) NOT NULL,
  `soTietLyThuyet` int(11) NOT NULL,
  `soTietThucHanh` int(11) NOT NULL,
  `heSo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhom`
--

CREATE TABLE `nhom` (
  `maNhom` int(11) NOT NULL,
  `tenNhom` varchar(255) NOT NULL,
  `ghiChu` varchar(255) DEFAULT NULL,
  `maMonHoc` varchar(50) NOT NULL,
  `maGiaoVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `namHoc` int(11) NOT NULL,
  `hocKy` int(11) NOT NULL,
  `soLuong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhomquyen`
--

CREATE TABLE `nhomquyen` (
  `quyen` varchar(50) NOT NULL,
  `thamGiaHoatDong` int(1) NOT NULL,
  `qlDeThi` int(1) NOT NULL,
  `qlSinhVien` int(1) NOT NULL,
  `qlGiaoVien` int(1) NOT NULL,
  `qlNhom` int(1) NOT NULL,
  `qlPhanCong` int(1) NOT NULL,
  `qlMon` int(1) NOT NULL,
  `qlCauHoi` int(1) NOT NULL,
  `qlThongBao` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhomquyen`
--

INSERT INTO `nhomquyen` (`quyen`, `thamGiaHoatDong`, `qlDeThi`, `qlSinhVien`, `qlGiaoVien`, `qlNhom`, `qlPhanCong`, `qlMon`, `qlCauHoi`, `qlThongBao`) VALUES
('sinhvien', 1, 0, 0, 0, 0, 0, 0, 0, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `nhomthamgia`
--

CREATE TABLE `nhomthamgia` (
  `maNhom` int(11) NOT NULL,
  `maSinhVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phancong`
--

CREATE TABLE `phancong` (
  `maPhanCong` int(11) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `maGiaoVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sinhvien`
--

CREATE TABLE `sinhvien` (
  `maSinhVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `hoVaTen` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `gioiTinh` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ngaySinh` date DEFAULT NULL,
  `anhDaiDien` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `quyen` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `sinhvien`
--

INSERT INTO `sinhvien` (`maSinhVien`, `hoVaTen`, `email`, `gioiTinh`, `ngaySinh`, `anhDaiDien`, `quyen`) VALUES
('111111', 'Cường', 'cuong@gmail.comm', 'Nam', '2004-01-20', 'hello', 'sinhvien');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `taikhoan`
--

CREATE TABLE `taikhoan` (
  `ma` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `trangThai` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `taikhoan`
--

INSERT INTO `taikhoan` (`ma`, `password`, `trangThai`) VALUES
('111111', '123456', 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `thongbao`
--

CREATE TABLE `thongbao` (
  `maThongBao` int(11) NOT NULL,
  `tenThongBao` varchar(255) NOT NULL,
  `noiDung` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `thongbao-nhom`
--

CREATE TABLE `thongbao-nhom` (
  `maNhom` int(11) NOT NULL,
  `maThongBao` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `bailam`
--
ALTER TABLE `bailam`
  ADD PRIMARY KEY (`maBaiLam`),
  ADD KEY `fk_bailam_sinhvien` (`maSinhVien`),
  ADD KEY `fk_bailam_made` (`maDe`);

--
-- Chỉ mục cho bảng `cauhoi`
--
ALTER TABLE `cauhoi`
  ADD PRIMARY KEY (`maCauHoi`),
  ADD KEY `fk_cauhoi_chuong` (`maChuong`),
  ADD KEY `fk_cauhoi_monhoc` (`maMonHoc`);

--
-- Chỉ mục cho bảng `cauhoi-dekiemtra`
--
ALTER TABLE `cauhoi-dekiemtra`
  ADD KEY `fk_cauhoi-dekiemtra_cauhoi` (`maCauHoi`),
  ADD KEY `fk_cauhoi-dekiemtra_dekiemtra` (`maDe`);

--
-- Chỉ mục cho bảng `chitietbailam`
--
ALTER TABLE `chitietbailam`
  ADD KEY `fk_chitietbailam_bailam` (`maBaiLam`),
  ADD KEY `fk_chitietbailam_cauhoi` (`maCauHoi`);

--
-- Chỉ mục cho bảng `chuong`
--
ALTER TABLE `chuong`
  ADD KEY `fk_chuong_monhoc` (`maMonHoc`);

--
-- Chỉ mục cho bảng `dapan`
--
ALTER TABLE `dapan`
  ADD KEY `fk_dapan_cauhoi` (`maCauHoi`);

--
-- Chỉ mục cho bảng `dekiemtra`
--
ALTER TABLE `dekiemtra`
  ADD PRIMARY KEY (`maDe`);

--
-- Chỉ mục cho bảng `dekiemtra-nhom`
--
ALTER TABLE `dekiemtra-nhom`
  ADD KEY `fk_dekiemtra-nhom_dekiemtra` (`maDe`),
  ADD KEY `fk_dekiemtra-hom_nhom` (`maNhom`);

--
-- Chỉ mục cho bảng `giaovien`
--
ALTER TABLE `giaovien`
  ADD PRIMARY KEY (`maGiaoVien`),
  ADD KEY `fk_giaovien_quyen` (`quyen`);

--
-- Chỉ mục cho bảng `monhoc`
--
ALTER TABLE `monhoc`
  ADD PRIMARY KEY (`maMonHoc`);

--
-- Chỉ mục cho bảng `nhom`
--
ALTER TABLE `nhom`
  ADD PRIMARY KEY (`maNhom`);

--
-- Chỉ mục cho bảng `nhomquyen`
--
ALTER TABLE `nhomquyen`
  ADD PRIMARY KEY (`quyen`);

--
-- Chỉ mục cho bảng `nhomthamgia`
--
ALTER TABLE `nhomthamgia`
  ADD KEY `fk_nhomthamgia_sinhvien` (`maSinhVien`),
  ADD KEY `fk_nhomthamgia_nhom` (`maNhom`);

--
-- Chỉ mục cho bảng `phancong`
--
ALTER TABLE `phancong`
  ADD PRIMARY KEY (`maPhanCong`),
  ADD KEY `fk_phancong_monhoc` (`maMonHoc`),
  ADD KEY `fk_phancong_giaovien` (`maGiaoVien`);

--
-- Chỉ mục cho bảng `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD PRIMARY KEY (`maSinhVien`),
  ADD KEY `fk_sinhvien_nhomquyen` (`quyen`);

--
-- Chỉ mục cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`ma`);

--
-- Chỉ mục cho bảng `thongbao`
--
ALTER TABLE `thongbao`
  ADD PRIMARY KEY (`maThongBao`);

--
-- Chỉ mục cho bảng `thongbao-nhom`
--
ALTER TABLE `thongbao-nhom`
  ADD KEY `fk_thongbao-nhom_nhom` (`maNhom`),
  ADD KEY `fk_thongbao-nhom_thongbao` (`maThongBao`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `bailam`
--
ALTER TABLE `bailam`
  ADD CONSTRAINT `fk_bailam_made` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bailam_sinhvien` FOREIGN KEY (`maSinhVien`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `cauhoi`
--
ALTER TABLE `cauhoi`
  ADD CONSTRAINT `fk_cauhoi_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `cauhoi-dekiemtra`
--
ALTER TABLE `cauhoi-dekiemtra`
  ADD CONSTRAINT `fk_cauhoi-dekiemtra_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_cauhoi-dekiemtra_dekiemtra` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `chitietbailam`
--
ALTER TABLE `chitietbailam`
  ADD CONSTRAINT `fk_chitietbailam_bailam` FOREIGN KEY (`maBaiLam`) REFERENCES `bailam` (`maBaiLam`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_chitietbailam_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `chuong`
--
ALTER TABLE `chuong`
  ADD CONSTRAINT `fk_chuong_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `dapan`
--
ALTER TABLE `dapan`
  ADD CONSTRAINT `fk_dapan_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `dekiemtra-nhom`
--
ALTER TABLE `dekiemtra-nhom`
  ADD CONSTRAINT `fk_dekiemtra-hom_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_dekiemtra-nhom_dekiemtra` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `giaovien`
--
ALTER TABLE `giaovien`
  ADD CONSTRAINT `fk_giaovien_quyen` FOREIGN KEY (`quyen`) REFERENCES `nhomquyen` (`quyen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_giaovien_taikhoan` FOREIGN KEY (`maGiaoVien`) REFERENCES `taikhoan` (`ma`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `nhomthamgia`
--
ALTER TABLE `nhomthamgia`
  ADD CONSTRAINT `fk_nhomthamgia_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_nhomthamgia_sinhvien` FOREIGN KEY (`maSinhVien`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `phancong`
--
ALTER TABLE `phancong`
  ADD CONSTRAINT `fk_phancong_giaovien` FOREIGN KEY (`maGiaoVien`) REFERENCES `giaovien` (`maGiaoVien`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_phancong_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD CONSTRAINT `fk_sinhvien_nhomquyen` FOREIGN KEY (`quyen`) REFERENCES `nhomquyen` (`quyen`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD CONSTRAINT `fk_sinhvien_taikhoan` FOREIGN KEY (`ma`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `thongbao-nhom`
--
ALTER TABLE `thongbao-nhom`
  ADD CONSTRAINT `fk_thongbao-nhom_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_thongbao-nhom_thongbao` FOREIGN KEY (`maThongBao`) REFERENCES `thongbao` (`maThongBao`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
