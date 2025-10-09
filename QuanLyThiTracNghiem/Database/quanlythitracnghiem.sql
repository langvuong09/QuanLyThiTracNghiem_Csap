-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 08, 2025 at 07:20 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `quanlythitracnghiem`
--

-- --------------------------------------------------------

--
-- Table structure for table `bailam`
--

CREATE TABLE `bailam` (
  `maBaiLam` int(11) NOT NULL,
  `maSinhVien` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `maDe` int(11) NOT NULL,
  `tongDiem` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `cauhoi`
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
-- Table structure for table `cauhoi-dekiemtra`
--

CREATE TABLE `cauhoi-dekiemtra` (
  `maDe` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `chitietbailam`
--

CREATE TABLE `chitietbailam` (
  `maBaiLam` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL,
  `maDapAnDuocChon` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `chucnang`
--

CREATE TABLE `chucnang` (
  `maChucNang` int(11) NOT NULL,
  `tenChucNang` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chucnang`
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
-- Table structure for table `chuong`
--

CREATE TABLE `chuong` (
  `maChuong` int(11) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `tenChuong` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `chuong`
--

INSERT INTO `chuong` (`maChuong`, `maMonHoc`, `tenChuong`) VALUES
(1, 'CT101', 'Giới thiệu ngôn ngữ C'),
(2, 'CT101', 'Cấu trúc điều khiển'),
(3, 'CT101', 'Hàm và mảng'),
(4, 'CT101', 'Con trỏ và chuỗi'),
(5, 'CT101', 'Tập tin và cấu trúc'),
(6, 'CT102', 'Ôn tập lập trình'),
(7, 'CT102', 'Ngăn xếp và hàng đợi'),
(8, 'CT102', 'Danh sách liên kết'),
(9, 'CT102', 'Cây nhị phân'),
(10, 'CT102', 'Thuật toán sắp xếp và tìm kiếm'),
(11, 'CT103', 'Khái niệm cơ sở dữ liệu'),
(12, 'CT103', 'Mô hình quan hệ'),
(13, 'CT103', 'SQL cơ bản'),
(14, 'CT103', 'Thiết kế cơ sở dữ liệu'),
(15, 'CT103', 'Quản lý cơ sở dữ liệu'),
(16, 'CT104', 'Khái niệm hướng đối tượng'),
(17, 'CT104', 'Lớp và đối tượng'),
(18, 'CT104', 'Kế thừa và đa hình'),
(19, 'CT104', 'Nạp chồng và trừu tượng'),
(20, 'CT104', 'Xử lý ngoại lệ'),
(21, 'CT105', 'Tổng quan về mạng'),
(22, 'CT105', 'Mô hình OSI'),
(23, 'CT105', 'Giao thức TCP/IP'),
(24, 'CT105', 'Địa chỉ IP và subnet'),
(25, 'CT105', 'Mạng LAN và WAN'),
(26, 'CT106', 'Khái niệm hệ điều hành'),
(27, 'CT106', 'Quản lý tiến trình'),
(28, 'CT106', 'Quản lý bộ nhớ'),
(29, 'CT106', 'Hệ thống tệp'),
(30, 'CT106', 'Đồng bộ và deadlock'),
(31, 'CT107', 'Khái niệm phân tích hệ thống'),
(32, 'CT107', 'Thu thập yêu cầu'),
(33, 'CT107', 'Mô hình hóa hệ thống'),
(34, 'CT107', 'Thiết kế hệ thống'),
(35, 'CT107', 'Triển khai và bảo trì'),
(36, 'CT108', 'Giới thiệu AI'),
(37, 'CT108', 'Tìm kiếm trạng thái'),
(38, 'CT108', 'Logic và suy luận'),
(39, 'CT108', 'Học máy cơ bản'),
(40, 'CT108', 'Ứng dụng AI'),
(41, 'CT109', 'HTML & CSS'),
(42, 'CT109', 'JavaScript cơ bản'),
(43, 'CT109', 'PHP và MySQL'),
(44, 'CT109', 'Xây dựng website động'),
(45, 'CT109', 'Bảo mật ứng dụng web'),
(46, 'CT110', 'Giới thiệu khai phá dữ liệu'),
(47, 'CT110', 'Tiền xử lý dữ liệu'),
(48, 'CT110', 'Phân cụm dữ liệu'),
(49, 'CT110', 'Phân loại dữ liệu'),
(50, 'CT110', 'Đánh giá mô hình');

-- --------------------------------------------------------

--
-- Table structure for table `ctnhomquyen`
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
-- Dumping data for table `ctnhomquyen`
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
-- Table structure for table `dapan`
--

CREATE TABLE `dapan` (
  `maDapAn` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL,
  `tenDapAn` varchar(255) NOT NULL,
  `dungSai` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `dekiemtra`
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
-- Table structure for table `dekiemtra-nhom`
--

CREATE TABLE `dekiemtra-nhom` (
  `maDe` int(11) NOT NULL,
  `maNhom` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `giaovien`
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
-- Table structure for table `monhoc`
--

CREATE TABLE `monhoc` (
  `maMonHoc` varchar(11) NOT NULL,
  `tenMonHoc` varchar(50) NOT NULL,
  `tinChi` int(11) NOT NULL,
  `soTietLyThuyet` int(11) NOT NULL,
  `soTietThucHanh` int(11) NOT NULL,
  `heSo` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `monhoc`
--

INSERT INTO `monhoc` (`maMonHoc`, `tenMonHoc`, `tinChi`, `soTietLyThuyet`, `soTietThucHanh`, `heSo`) VALUES
('CT101', 'Lập trình C cơ bản', 3, 30, 15, 1),
('CT102', 'Cấu trúc dữ liệu và giải thuật', 4, 45, 15, 2),
('CT103', 'Cơ sở dữ liệu', 3, 30, 15, 2),
('CT104', 'Lập trình hướng đối tượng', 3, 30, 15, 2),
('CT105', 'Mạng máy tính', 3, 30, 15, 2),
('CT106', 'Hệ điều hành', 3, 30, 15, 2),
('CT107', 'Phân tích và thiết kế hệ thống', 3, 30, 15, 2),
('CT108', 'Trí tuệ nhân tạo', 3, 30, 15, 3),
('CT109', 'Lập trình web', 3, 30, 15, 2),
('CT110', 'Khai phá dữ liệu', 3, 30, 15, 3);

-- --------------------------------------------------------

--
-- Table structure for table `nhom`
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
-- Table structure for table `nhomquyen`
--

CREATE TABLE `nhomquyen` (
  `maQuyen` int(11) NOT NULL,
  `tenQuyen` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `nhomquyen`
--

INSERT INTO `nhomquyen` (`maQuyen`, `tenQuyen`) VALUES
(1, 'admin'),
(2, 'giáo viên'),
(3, 'sinh viên');

-- --------------------------------------------------------

--
-- Table structure for table `nhomthamgia`
--

CREATE TABLE `nhomthamgia` (
  `maNhom` int(11) NOT NULL,
  `maSinhVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `phancong`
--

CREATE TABLE `phancong` (
  `maPhanCong` int(11) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `maGiaoVien` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sinhvien`
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
-- Dumping data for table `sinhvien`
--

INSERT INTO `sinhvien` (`maSinhVien`, `hoVaTen`, `email`, `gioiTinh`, `ngaySinh`, `anhDaiDien`, `maQuyen`) VALUES
('111111', 'Cường', 'cuong@gmail.comm', 'Nam', '2004-01-20', 'hello', 1),
('3122410006', 'Mai Anh', 'domaianhh20@gmail.com', 'Nam', '2000-01-01', 'default.jpg', 3);

-- --------------------------------------------------------

--
-- Table structure for table `taikhoan`
--

CREATE TABLE `taikhoan` (
  `ma` varchar(11) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `trangThai` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `taikhoan`
--

INSERT INTO `taikhoan` (`ma`, `password`, `trangThai`) VALUES
('111111', '123456', 1),
('3122410006', 'maianh23', 1);

-- --------------------------------------------------------

--
-- Table structure for table `thongbao`
--

CREATE TABLE `thongbao` (
  `maThongBao` int(11) NOT NULL,
  `tenThongBao` varchar(255) NOT NULL,
  `noiDung` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `thongbao-nhom`
--

CREATE TABLE `thongbao-nhom` (
  `maNhom` int(11) NOT NULL,
  `maThongBao` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bailam`
--
ALTER TABLE `bailam`
  ADD PRIMARY KEY (`maBaiLam`),
  ADD KEY `fk_bailam_sinhvien` (`maSinhVien`),
  ADD KEY `fk_bailam_made` (`maDe`);

--
-- Indexes for table `cauhoi`
--
ALTER TABLE `cauhoi`
  ADD PRIMARY KEY (`maCauHoi`),
  ADD KEY `fk_cauhoi_chuong` (`maChuong`),
  ADD KEY `fk_cauhoi_monhoc` (`maMonHoc`);

--
-- Indexes for table `cauhoi-dekiemtra`
--
ALTER TABLE `cauhoi-dekiemtra`
  ADD KEY `fk_cauhoi-dekiemtra_cauhoi` (`maCauHoi`),
  ADD KEY `fk_cauhoi-dekiemtra_dekiemtra` (`maDe`);

--
-- Indexes for table `chitietbailam`
--
ALTER TABLE `chitietbailam`
  ADD KEY `fk_chitietbailam_bailam` (`maBaiLam`),
  ADD KEY `fk_chitietbailam_cauhoi` (`maCauHoi`);

--
-- Indexes for table `chucnang`
--
ALTER TABLE `chucnang`
  ADD PRIMARY KEY (`maChucNang`);

--
-- Indexes for table `chuong`
--
ALTER TABLE `chuong`
  ADD PRIMARY KEY (`maChuong`),
  ADD KEY `fk_chuong_monhoc` (`maMonHoc`);

--
-- Indexes for table `ctnhomquyen`
--
ALTER TABLE `ctnhomquyen`
  ADD KEY `fk_ctnhomquyen_nhomquyen` (`maQuyen`),
  ADD KEY `fk_ctnhomquyen_chucnang` (`maChucNang`);

--
-- Indexes for table `dapan`
--
ALTER TABLE `dapan`
  ADD PRIMARY KEY (`maDapAn`),
  ADD KEY `fk_dapan_cauhoi` (`maCauHoi`);

--
-- Indexes for table `dekiemtra`
--
ALTER TABLE `dekiemtra`
  ADD PRIMARY KEY (`maDe`);

--
-- Indexes for table `dekiemtra-nhom`
--
ALTER TABLE `dekiemtra-nhom`
  ADD KEY `fk_dekiemtra-nhom_dekiemtra` (`maDe`),
  ADD KEY `fk_dekiemtra-hom_nhom` (`maNhom`);

--
-- Indexes for table `giaovien`
--
ALTER TABLE `giaovien`
  ADD PRIMARY KEY (`maGiaoVien`),
  ADD KEY `fk_giaovien_nhomquyen` (`maQuyen`);

--
-- Indexes for table `monhoc`
--
ALTER TABLE `monhoc`
  ADD PRIMARY KEY (`maMonHoc`);

--
-- Indexes for table `nhom`
--
ALTER TABLE `nhom`
  ADD PRIMARY KEY (`maNhom`);

--
-- Indexes for table `nhomquyen`
--
ALTER TABLE `nhomquyen`
  ADD PRIMARY KEY (`maQuyen`);

--
-- Indexes for table `nhomthamgia`
--
ALTER TABLE `nhomthamgia`
  ADD KEY `fk_nhomthamgia_sinhvien` (`maSinhVien`),
  ADD KEY `fk_nhomthamgia_nhom` (`maNhom`);

--
-- Indexes for table `phancong`
--
ALTER TABLE `phancong`
  ADD PRIMARY KEY (`maPhanCong`),
  ADD KEY `fk_phancong_monhoc` (`maMonHoc`),
  ADD KEY `fk_phancong_giaovien` (`maGiaoVien`);

--
-- Indexes for table `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD PRIMARY KEY (`maSinhVien`),
  ADD KEY `fk_sinhvien_nhomquyen` (`maQuyen`);

--
-- Indexes for table `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD PRIMARY KEY (`ma`);

--
-- Indexes for table `thongbao`
--
ALTER TABLE `thongbao`
  ADD PRIMARY KEY (`maThongBao`);

--
-- Indexes for table `thongbao-nhom`
--
ALTER TABLE `thongbao-nhom`
  ADD KEY `fk_thongbao-nhom_nhom` (`maNhom`),
  ADD KEY `fk_thongbao-nhom_thongbao` (`maThongBao`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bailam`
--
ALTER TABLE `bailam`
  ADD CONSTRAINT `fk_bailam_made` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_bailam_sinhvien` FOREIGN KEY (`maSinhVien`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `cauhoi`
--
ALTER TABLE `cauhoi`
  ADD CONSTRAINT `fk_cauhoi_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `cauhoi-dekiemtra`
--
ALTER TABLE `cauhoi-dekiemtra`
  ADD CONSTRAINT `fk_cauhoi-dekiemtra_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_cauhoi-dekiemtra_dekiemtra` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `chitietbailam`
--
ALTER TABLE `chitietbailam`
  ADD CONSTRAINT `fk_chitietbailam_bailam` FOREIGN KEY (`maBaiLam`) REFERENCES `bailam` (`maBaiLam`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_chitietbailam_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `chuong`
--
ALTER TABLE `chuong`
  ADD CONSTRAINT `fk_chuong_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `ctnhomquyen`
--
ALTER TABLE `ctnhomquyen`
  ADD CONSTRAINT `fk_ctnhomquyen_chucnang` FOREIGN KEY (`maChucNang`) REFERENCES `chucnang` (`maChucNang`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ctnhomquyen_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `dapan`
--
ALTER TABLE `dapan`
  ADD CONSTRAINT `fk_dapan_cauhoi` FOREIGN KEY (`maCauHoi`) REFERENCES `cauhoi` (`maCauHoi`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `dekiemtra-nhom`
--
ALTER TABLE `dekiemtra-nhom`
  ADD CONSTRAINT `fk_dekiemtra-hom_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_dekiemtra-nhom_dekiemtra` FOREIGN KEY (`maDe`) REFERENCES `dekiemtra` (`maDe`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `giaovien`
--
ALTER TABLE `giaovien`
  ADD CONSTRAINT `fk_giaovien_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_giaovien_taikhoan` FOREIGN KEY (`maGiaoVien`) REFERENCES `taikhoan` (`ma`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `nhomthamgia`
--
ALTER TABLE `nhomthamgia`
  ADD CONSTRAINT `fk_nhomthamgia_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_nhomthamgia_sinhvien` FOREIGN KEY (`maSinhVien`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `phancong`
--
ALTER TABLE `phancong`
  ADD CONSTRAINT `fk_phancong_giaovien` FOREIGN KEY (`maGiaoVien`) REFERENCES `giaovien` (`maGiaoVien`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_phancong_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `sinhvien`
--
ALTER TABLE `sinhvien`
  ADD CONSTRAINT `fk_sinhvien_nhomquyen` FOREIGN KEY (`maQuyen`) REFERENCES `nhomquyen` (`maQuyen`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `taikhoan`
--
ALTER TABLE `taikhoan`
  ADD CONSTRAINT `fk_sinhvien_taikhoan` FOREIGN KEY (`ma`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `thongbao-nhom`
--
ALTER TABLE `thongbao-nhom`
  ADD CONSTRAINT `fk_thongbao-nhom_nhom` FOREIGN KEY (`maNhom`) REFERENCES `nhom` (`maNhom`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_thongbao-nhom_thongbao` FOREIGN KEY (`maThongBao`) REFERENCES `thongbao` (`maThongBao`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
