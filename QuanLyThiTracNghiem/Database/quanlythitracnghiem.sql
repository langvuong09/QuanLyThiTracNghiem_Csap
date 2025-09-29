-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th9 29, 2025 lúc 08:32 AM
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
-- Cấu trúc bảng cho bảng `chucnang`
--

CREATE TABLE `chucnang` (
  `maChucNang` int(11) NOT NULL,
  `tenChucNang` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `chucnang`
--

INSERT INTO `chucnang` (`maChucNang`, `tenChucNang`) VALUES
(1, 'Người dùng'),
(2, 'Học phần'),
(3, 'Câu hỏi'),
(4, 'Môn học'),
(5, 'Chương'),
(6, 'Phân công'),
(7, 'Đề thi'),
(8, 'Nhóm quyền'),
(9, 'Thông báo');

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
-- Cấu trúc bảng cho bảng `ctnhomquyen`
--

CREATE TABLE `ctnhomquyen` (
  `maQuyen` int(11) NOT NULL,
  `maChucNang` int(11) NOT NULL,
  `xem` int(11) NOT NULL,
  `them` int(11) NOT NULL,
  `capNhat` int(11) NOT NULL,
  `xoa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `ctnhomquyen`
--

INSERT INTO `ctnhomquyen` (`maQuyen`, `maChucNang`, `xem`, `them`, `capNhat`, `xoa`) VALUES
(1, 1, 1, 1, 1, 1),
(1, 2, 1, 1, 1, 1),
(1, 3, 1, 1, 1, 1),
(1, 4, 1, 1, 1, 1),
(1, 5, 1, 1, 1, 1),
(1, 6, 1, 1, 1, 1),
(1, 7, 1, 1, 1, 1),
(1, 8, 1, 1, 1, 1),
(1, 9, 1, 1, 1, 1);

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
  `gioiTinh` varchar(11) DEFAULT NULL,
  `ngaySinh` date DEFAULT NULL,
  `anhDaiDien` varchar(255) DEFAULT NULL,
  `maQuyen` int(11) NOT NULL
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
  `maQuyen` int(11) NOT NULL,
  `tenQuyen` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `nhomquyen`
--

INSERT INTO `nhomquyen` (`maQuyen`, `tenQuyen`) VALUES
(1, 'admin'),
(2, 'giáo viên'),
(3, 'sinh viên');

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
  `maQuyen` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `sinhvien`
--

INSERT INTO `sinhvien` (`maSinhVien`, `hoVaTen`, `email`, `gioiTinh`, `ngaySinh`, `anhDaiDien`, `maQuyen`) VALUES
('111111', 'Cường', 'cuong@gmail.comm', 'Nam', '2004-01-20', 'hello', 1),
('3122410043', 'Cao Tiến Cường', 'cuong@gmail.com', 'Nam', '2000-01-01', 'default.jpg', 3),
('3122410351', 'Quyên', 'skjnas@gmail.com', 'Nam', '2000-01-01', 'default.jpg', 3);

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
('111111', '123456', 1),
('3122410043', 'cuonghero9a', 1),
('3122410351', '1234@q', 1);

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
-- Chỉ mục cho bảng `chucnang`
--
ALTER TABLE `chucnang`
  ADD PRIMARY KEY (`maChucNang`);

--
-- Chỉ mục cho bảng `chuong`
--
ALTER TABLE `chuong`
  ADD KEY `fk_chuong_monhoc` (`maMonHoc`);

--
-- Chỉ mục cho bảng `ctnhomquyen`
--
ALTER TABLE `ctnhomquyen`
  ADD KEY `fk_ctnhomquyen_nhomquyen` (`maQuyen`),
  ADD KEY `fk_ctnhomquyen_chucnang` (`maChucNang`);

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
  ADD KEY `fk_giaovien_nhomquyen` (`maQuyen`);

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
  ADD PRIMARY KEY (`maQuyen`);

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
  ADD KEY `fk_sinhvien_nhomquyen` (`maQuyen`);

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
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `bailam`
--
ALTER TABLE `bailam`
  MODIFY `maBaiLam` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `cauhoi`
--
ALTER TABLE `cauhoi`
  MODIFY `maCauHoi` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `chucnang`
--
ALTER TABLE `chucnang`
  MODIFY `maChucNang` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT cho bảng `dekiemtra`
--
ALTER TABLE `dekiemtra`
  MODIFY `maDe` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `nhom`
--
ALTER TABLE `nhom`
  MODIFY `maNhom` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `nhomquyen`
--
ALTER TABLE `nhomquyen`
  MODIFY `maQuyen` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `phancong`
--
ALTER TABLE `phancong`
  MODIFY `maPhanCong` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `thongbao`
--
ALTER TABLE `thongbao`
  MODIFY `maThongBao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

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
-- Các ràng buộc cho bảng `ctnhomquyen`
--
ALTER TABLE `ctnhomquyen`
  ADD CONSTRAINT `fk_ctnhomquyen_chucnang` FOREIGN KEY (`maChucNang`) REFERENCES `chucnang` (`maChucNang`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ctnhomquyen_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE;

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
  ADD CONSTRAINT `fk_giaovien_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE,
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
  ADD CONSTRAINT `fk_sinhvien_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE;

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
