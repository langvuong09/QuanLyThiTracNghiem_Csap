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

--
-- Dumping data for table `cauhoi`
--

INSERT INTO `cauhoi` (`maCauHoi`, `maMonHoc`, `maChuong`, `doKho`, `noiDungCauHoi`) VALUES
-- Câu hỏi CT101 - Lập trình C
(1, 'CT101', 1, 'De', 'Ngôn ngữ C được phát triển vào năm nào?'),
(2, 'CT101', 1, 'De', 'Ai là người phát triển ngôn ngữ C?'),
(3, 'CT101', 2, 'TrungBinh', 'Cấu trúc điều khiển nào được sử dụng để lặp?'),
(4, 'CT101', 2, 'TrungBinh', 'Câu lệnh if-else thuộc loại cấu trúc nào?'),
(5, 'CT101', 3, 'Kho', 'Hàm trong C có thể trả về bao nhiêu giá trị?'),

-- Câu hỏi CT102 - Cấu trúc dữ liệu
(6, 'CT102', 6, 'De', 'Ngăn xếp hoạt động theo nguyên tắc nào?'),
(7, 'CT102', 6, 'De', 'Hàng đợi hoạt động theo nguyên tắc nào?'),
(8, 'CT102', 7, 'TrungBinh', 'Danh sách liên kết có ưu điểm gì?'),
(9, 'CT102', 8, 'TrungBinh', 'Cây nhị phân có bao nhiêu con tối đa?'),
(10, 'CT102', 9, 'Kho', 'Thuật toán sắp xếp nào có độ phức tạp O(n log n)?'),

-- Câu hỏi CT103 - Cơ sở dữ liệu
(11, 'CT103', 11, 'De', 'CSDL là viết tắt của gì?'),
(12, 'CT103', 11, 'De', 'Mô hình quan hệ được đề xuất bởi ai?'),
(13, 'CT103', 12, 'TrungBinh', 'Khóa chính trong bảng có đặc điểm gì?'),
(14, 'CT103', 13, 'TrungBinh', 'SQL là viết tắt của gì?'),
(15, 'CT103', 14, 'Kho', 'Chuẩn hóa dữ liệu nhằm mục đích gì?'),

-- Câu hỏi CT104 - OOP
(16, 'CT104', 16, 'De', 'OOP là viết tắt của gì?'),
(17, 'CT104', 16, 'De', 'Tính đóng gói trong OOP có nghĩa là gì?'),
(18, 'CT104', 17, 'TrungBinh', 'Lớp và đối tượng khác nhau như thế nào?'),
(19, 'CT104', 18, 'TrungBinh', 'Kế thừa cho phép làm gì?'),
(20, 'CT104', 19, 'Kho', 'Đa hình trong OOP được thể hiện như thế nào?'),

-- Câu hỏi CT105 - Mạng máy tính
(21, 'CT105', 21, 'De', 'Mạng LAN là gì?'),
(22, 'CT105', 21, 'De', 'Mạng WAN là gì?'),
(23, 'CT105', 22, 'TrungBinh', 'Mô hình OSI có bao nhiêu tầng?'),
(24, 'CT105', 23, 'TrungBinh', 'TCP/IP có bao nhiêu tầng?'),
(25, 'CT105', 24, 'Kho', 'Subnet mask có chức năng gì?');

-- --------------------------------------------------------

--
-- Table structure for table `cauhoi-dekiemtra`
--

CREATE TABLE `cauhoi-dekiemtra` (
  `maDe` int(11) NOT NULL,
  `maCauHoi` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `cauhoi-dekiemtra`
--

INSERT INTO `cauhoi-dekiemtra` (`maDe`, `maCauHoi`) VALUES
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5),
(2, 6), (2, 7), (2, 8), (2, 9), (2, 10),
(3, 11), (3, 12), (3, 13), (3, 14), (3, 15),
(4, 16), (4, 17), (4, 18), (4, 19), (4, 20),
(5, 21), (5, 22), (5, 23), (5, 24), (5, 25);

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

--
-- Dumping data for table `dapan`
--

INSERT INTO `dapan` (`maDapAn`, `maCauHoi`, `tenDapAn`, `dungSai`) VALUES
-- Đáp án cho câu hỏi 1
(1, 1, '1972', 1),
(2, 1, '1970', 0),
(3, 1, '1975', 0),
(4, 1, '1980', 0),

-- Đáp án cho câu hỏi 2
(5, 2, 'Dennis Ritchie', 1),
(6, 2, 'Bjarne Stroustrup', 0),
(7, 2, 'James Gosling', 0),
(8, 2, 'Guido van Rossum', 0),

-- Đáp án cho câu hỏi 3
(9, 3, 'for, while, do-while', 1),
(10, 3, 'if, else', 0),
(11, 3, 'switch, case', 0),
(12, 3, 'break, continue', 0),

-- Đáp án cho câu hỏi 4
(13, 4, 'Cấu trúc điều kiện', 1),
(14, 4, 'Cấu trúc lặp', 0),
(15, 4, 'Cấu trúc nhảy', 0),
(16, 4, 'Cấu trúc hàm', 0),

-- Đáp án cho câu hỏi 5
(17, 5, 'Chỉ một giá trị', 1),
(18, 5, 'Nhiều giá trị', 0),
(19, 5, 'Không giới hạn', 0),
(20, 5, 'Tùy thuộc vào kiểu dữ liệu', 0),

-- Đáp án cho câu hỏi 6
(21, 6, 'LIFO (Last In First Out)', 1),
(22, 6, 'FIFO (First In First Out)', 0),
(23, 6, 'Random', 0),
(24, 6, 'Priority', 0),

-- Đáp án cho câu hỏi 7
(25, 7, 'FIFO (First In First Out)', 1),
(26, 7, 'LIFO (Last In First Out)', 0),
(27, 7, 'Random', 0),
(28, 7, 'Priority', 0),

-- Đáp án cho câu hỏi 8
(29, 8, 'Dễ dàng thêm/xóa phần tử', 1),
(30, 8, 'Truy cập nhanh', 0),
(31, 8, 'Tiết kiệm bộ nhớ', 0),
(32, 8, 'Sắp xếp tự động', 0),

-- Đáp án cho câu hỏi 9
(33, 9, '2 con', 1),
(34, 9, '1 con', 0),
(35, 9, '3 con', 0),
(36, 9, 'Không giới hạn', 0),

-- Đáp án cho câu hỏi 10
(37, 10, 'Merge Sort', 1),
(38, 10, 'Bubble Sort', 0),
(39, 10, 'Selection Sort', 0),
(40, 10, 'Insertion Sort', 0);

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

--
-- Dumping data for table `dekiemtra`
--

INSERT INTO `dekiemtra` (`maDe`, `tenDe`, `thoiGianBatDau`, `thoiGianKetThuc`, `thoiGianCanhBao`, `maMonHoc`, `soCauDe`, `soCauTrungBinh`, `soCauKho`, `trangThai`) VALUES
-- Đề thi từ ngày 21/10/2025 trở đi
(1, 'Đề thi giữa kỳ - Lập trình C', '2025-10-21 08:00:00', '2025-10-21 10:00:00', '2025-10-21 09:45:00', 'CT101', 5, 10, 5, 1),
(2, 'Đề thi cuối kỳ - Cấu trúc dữ liệu', '2025-10-25 14:00:00', '2025-10-25 16:30:00', '2025-10-25 16:15:00', 'CT102', 8, 12, 10, 1),
(3, 'Đề luyện tập - Cơ sở dữ liệu', '2025-10-22 19:00:00', '2025-10-22 21:00:00', '2025-10-22 20:45:00', 'CT103', 3, 7, 5, 1),
(4, 'Đề thi giữa kỳ - OOP', '2025-10-23 09:00:00', '2025-10-23 11:00:00', '2025-10-23 10:45:00', 'CT104', 6, 8, 6, 1),
(5, 'Đề thi cuối kỳ - Mạng máy tính', '2025-10-28 13:00:00', '2025-10-28 15:30:00', '2025-10-28 15:15:00', 'CT105', 7, 10, 8, 1),
(6, 'Đề luyện tập - Hệ điều hành', '2025-10-24 20:00:00', '2025-10-24 22:00:00', '2025-10-24 21:45:00', 'CT106', 4, 6, 5, 1),
(7, 'Đề thi giữa kỳ - Phân tích hệ thống', '2025-10-26 10:00:00', '2025-10-26 12:00:00', '2025-10-26 11:45:00', 'CT107', 5, 8, 7, 1),
(8, 'Đề thi cuối kỳ - Trí tuệ nhân tạo', '2025-10-30 15:00:00', '2025-10-30 17:30:00', '2025-10-30 17:15:00', 'CT108', 8, 12, 10, 1),
(9, 'Đề luyện tập - Lập trình web', '2025-10-27 18:00:00', '2025-10-27 20:00:00', '2025-10-27 19:45:00', 'CT109', 3, 5, 4, 1),
(10, 'Đề thi giữa kỳ - Khai phá dữ liệu', '2025-10-29 11:00:00', '2025-10-29 13:00:00', '2025-10-29 12:45:00', 'CT110', 6, 9, 7, 1),
-- Đề thi với thời gian động để test các trạng thái
(11, 'Đề thi đang mở - Lập trình C', NOW(), DATE_ADD(NOW(), INTERVAL 2 HOUR), DATE_ADD(NOW(), INTERVAL 1 HOUR 45 MINUTE), 'CT101', 3, 5, 2, 1),
(12, 'Đề thi sắp diễn ra - OOP', DATE_ADD(NOW(), INTERVAL 1 HOUR), DATE_ADD(NOW(), INTERVAL 3 HOUR), DATE_ADD(NOW(), INTERVAL 2 HOUR 45 MINUTE), 'CT104', 4, 6, 3, 1),
(13, 'Đề thi đã kết thúc - Cơ sở dữ liệu', DATE_SUB(NOW(), INTERVAL 3 HOUR), DATE_SUB(NOW(), INTERVAL 1 HOUR), DATE_SUB(NOW(), INTERVAL 1 HOUR 15 MINUTE), 'CT103', 5, 7, 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `dekiemtra-nhom`
--

CREATE TABLE `dekiemtra-nhom` (
  `maDe` int(11) NOT NULL,
  `maNhom` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dekiemtra-nhom`
--

INSERT INTO `dekiemtra-nhom` (`maDe`, `maNhom`) VALUES
(1, 1), (1, 2),
(2, 3), (2, 4),
(3, 5), (3, 6),
(4, 7), (4, 8),
(5, 9), (5, 10);

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

--
-- Dumping data for table `giaovien`
--

INSERT INTO `giaovien` (`maGiaoVien`, `tenGiaoVien`, `email`, `gioiTinh`, `ngaySinh`, `anhDaiDien`, `maQuyen`) VALUES
('111111', 'Nguyễn Văn Admin', 'admin@university.edu.vn', 'Nam', '1980-01-01', 'admin.jpg', 1);

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

--
-- Dumping data for table `nhom`
--

INSERT INTO `nhom` (`maNhom`, `tenNhom`, `ghiChu`, `maMonHoc`, `maGiaoVien`, `namHoc`, `hocKy`, `soLuong`) VALUES
(1, 'Nhóm CT101-01', 'Nhóm học lập trình C cơ bản', 'CT101', '111111', 2024, 1, 30),
(2, 'Nhóm CT101-02', 'Nhóm học lập trình C cơ bản', 'CT101', '111111', 2024, 1, 25),
(3, 'Nhóm CT102-01', 'Nhóm học cấu trúc dữ liệu', 'CT102', '111111', 2024, 1, 28),
(4, 'Nhóm CT102-02', 'Nhóm học cấu trúc dữ liệu', 'CT102', '111111', 2024, 1, 32),
(5, 'Nhóm CT103-01', 'Nhóm học cơ sở dữ liệu', 'CT103', '111111', 2024, 1, 26),
(6, 'Nhóm CT103-02', 'Nhóm học cơ sở dữ liệu', 'CT103', '111111', 2024, 1, 29),
(7, 'Nhóm CT104-01', 'Nhóm học OOP', 'CT104', '111111', 2024, 1, 27),
(8, 'Nhóm CT104-02', 'Nhóm học OOP', 'CT104', '111111', 2024, 1, 31),
(9, 'Nhóm CT105-01', 'Nhóm học mạng máy tính', 'CT105', '111111', 2024, 1, 24),
(10, 'Nhóm CT105-02', 'Nhóm học mạng máy tính', 'CT105', '111111', 2024, 1, 33);

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

--
-- Dumping data for table `phancong`
--

INSERT INTO `phancong` (`maPhanCong`, `maMonHoc`, `maGiaoVien`) VALUES
(1, 'CT101', '111111'),
(2, 'CT102', '111111'),
(3, 'CT103', '111111'),
(4, 'CT104', '111111'),
(5, 'CT105', '111111'),
(6, 'CT106', '111111'),
(7, 'CT107', '111111'),
(8, 'CT108', '111111'),
(9, 'CT109', '111111'),
(10, 'CT110', '111111');

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
-- --------------------------------------------------------
--
-- Dumping data for table `bailam`
--

INSERT INTO `bailam` (`maBaiLam`, `maSinhVien`, `maDe`, `tongDiem`) VALUES
(1, '3122410006', 1, 8.5),
(2, '111111', 1, 7.2),
(3, '3122410006', 2, 9.0),
(4, '111111', 2, 6.8),
(5, '3122410006', 3, 8.0);

-- --------------------------------------------------------
--
-- Dumping data for table `chitietbailam`
--

INSERT INTO `chitietbailam` (`maBaiLam`, `maCauHoi`, `maDapAnDuocChon`) VALUES
-- Bài làm 1 của sinh viên 3122410006 cho đề thi 1
(1, 1, 1),  -- Câu 1: Chọn đáp án đúng (1972)
(1, 2, 5),  -- Câu 2: Chọn đáp án đúng (Dennis Ritchie)
(1, 3, 9),  -- Câu 3: Chọn đáp án đúng (for, while, do-while)
(1, 4, 13), -- Câu 4: Chọn đáp án đúng (Cấu trúc điều kiện)
(1, 5, 17), -- Câu 5: Chọn đáp án đúng (Chỉ một giá trị)

-- Bài làm 2 của sinh viên 111111 cho đề thi 1
(2, 1, 2),  -- Câu 1: Chọn đáp án sai (1970)
(2, 2, 5),  -- Câu 2: Chọn đáp án đúng (Dennis Ritchie)
(2, 3, 10), -- Câu 3: Chọn đáp án sai (if, else)
(2, 4, 13), -- Câu 4: Chọn đáp án đúng (Cấu trúc điều kiện)
(2, 5, 18), -- Câu 5: Chọn đáp án sai (Nhiều giá trị)

-- Bài làm 3 của sinh viên 3122410006 cho đề thi 2
(3, 6, 21), -- Câu 6: Chọn đáp án đúng (LIFO)
(3, 7, 25), -- Câu 7: Chọn đáp án đúng (FIFO)
(3, 8, 29), -- Câu 8: Chọn đáp án đúng (Dễ dàng thêm/xóa phần tử)
(3, 9, 33), -- Câu 9: Chọn đáp án đúng (2 con)
(3, 10, 37),-- Câu 10: Chọn đáp án đúng (Merge Sort)

-- Bài làm 4 của sinh viên 111111 cho đề thi 2
(4, 6, 22), -- Câu 6: Chọn đáp án sai (FIFO)
(4, 7, 25), -- Câu 7: Chọn đáp án đúng (FIFO)
(4, 8, 30), -- Câu 8: Chọn đáp án sai (Truy cập nhanh)
(4, 9, 33), -- Câu 9: Chọn đáp án đúng (2 con)
(4, 10, 38),-- Câu 10: Chọn đáp án sai (Bubble Sort)

-- Bài làm 5 của sinh viên 3122410006 cho đề thi 3
(5, 11, 41),-- Câu 11: Chọn đáp án đúng (CSDL)
(5, 12, 45),-- Câu 12: Chọn đáp án đúng (E.F. Codd)
(5, 13, 49),-- Câu 13: Chọn đáp án đúng (Không trùng lặp)
(5, 14, 53),-- Câu 14: Chọn đáp án đúng (Structured Query Language)
(5, 15, 57);-- Câu 15: Chọn đáp án đúng (Giảm dư thừa dữ liệu)

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
