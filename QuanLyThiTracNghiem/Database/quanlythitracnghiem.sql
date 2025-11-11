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
  `tongDiem` float NOT NULL,
  `thoiGianBatDau` datetime DEFAULT NULL,
  `thoiGianNopBai` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

INSERT INTO `bailam` (`maBaiLam`, `maSinhVien`, `maDe`, `tongDiem`, `thoiGianBatDau`, `thoiGianNopBai`) VALUES
(1, '3122410006', 1, 8.5, '2025-10-21 08:00:00', '2025-10-21 09:30:00'),
(2, '111111', 1, 7.2, '2025-10-21 08:05:00', '2025-10-21 09:25:00');

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
-- Chương 1: Giới thiệu và cơ bản
(1, 'CT101', 1, 'Dễ', 'Ngôn ngữ C được phát triển vào năm nào?'),
(2, 'CT101', 1, 'Dễ', 'Ai là người phát triển ngôn ngữ C?'),
(3, 'CT101', 1, 'Dễ', 'Biến trong C được khai báo như thế nào?'),
(4, 'CT101', 1, 'Dễ', 'Kiểu dữ liệu int trong C chiếm bao nhiêu byte?'),
(5, 'CT101', 1, 'Dễ', 'Hàm main() trong C có vai trò gì?'),

-- Chương 2: Cấu trúc điều khiển
(6, 'CT101', 2, 'Trung Bình', 'Cấu trúc điều khiển nào được sử dụng để lặp?'),
(7, 'CT101', 2, 'Trung Bình', 'Câu lệnh if-else thuộc loại cấu trúc nào?'),
(8, 'CT101', 2, 'Trung Bình', 'Vòng lặp for có cú pháp như thế nào?'),
(9, 'CT101', 2, 'Khó', 'Break và continue khác nhau như thế nào?'),
(10, 'CT101', 2, 'Dễ', 'Nêu cú pháp của vòng lặp while.'),

-- Chương 3: Hàm và mảng
(11, 'CT101', 3, 'Khó', 'Hàm trong C có thể trả về bao nhiêu giá trị?'),
(12, 'CT101', 3, 'Trung Bình', 'Mảng trong C bắt đầu từ chỉ số nào?'),
(13, 'CT101', 3, 'Trung Bình', 'Hàm malloc() dùng để làm gì?'),
(14, 'CT101', 3, 'Dễ', 'Mảng là gì trong C?'),
(15, 'CT101', 3, 'Dễ', 'Nêu cú pháp khai báo một hàm đơn giản.'),

-- Chương 4: Con trỏ và chuỗi
(16, 'CT101', 4, 'Khó', 'Con trỏ trong C là gì?'),
(17, 'CT101', 4, 'Dễ', 'Chuỗi trong C kết thúc bằng ký tự gì?'),
(18, 'CT101', 4, 'Dễ', 'Nêu cú pháp khai báo con trỏ.'),
(19, 'CT101', 4, 'Dễ', 'Hàm strlen() dùng để làm gì?'),
(20, 'CT101', 4, 'Trung Bình', 'Giải thích toán tử * và & khi làm việc với con trỏ.'),

-- Chương 5: Cấu trúc và File I/O
(21, 'CT101', 5, 'Trung Bình', 'File trong C được mở bằng hàm nào?'),
(22, 'CT101', 5, 'Khó', 'Struct trong C là gì?'),
(23, 'CT101', 5, 'Dễ', 'Nêu cú pháp khai báo một struct.'),
(24, 'CT101', 5, 'Dễ', 'Hàm fopen() có những chế độ mở file nào?'),
(25, 'CT101', 5, 'Trung Bình', 'Cách truy cập các thành viên của struct.'),

-- Câu hỏi CT102 - Cấu trúc dữ liệu
-- Chương 6: Mảng, Ngăn xếp, Hàng đợi
(26, 'CT102', 6, 'Dễ', 'Ngăn xếp hoạt động theo nguyên tắc nào?'),
(27, 'CT102', 6, 'Dễ', 'Hàng đợi hoạt động theo nguyên tắc nào?'),
(28, 'CT102', 6, 'Dễ', 'Array là cấu trúc dữ liệu gì?'),
(29, 'CT102', 6, 'Khó', 'Priority Queue hoạt động như thế nào?'),
(30, 'CT102', 6, 'Dễ', 'Nêu ưu điểm của mảng.'),

-- Chương 7: Danh sách liên kết
(31, 'CT102', 7, 'Trung Bình', 'Danh sách liên kết có ưu điểm gì?'),
(32, 'CT102', 7, 'Dễ', 'Linked List có ưu điểm gì so với Array?'),
(33, 'CT102', 7, 'Trung Bình', 'Doubly Linked List là gì?'),
(34, 'CT102', 7, 'Dễ', 'Nêu khái niệm về Node trong danh sách liên kết.'),
(35, 'CT102', 7, 'Dễ', 'Các loại danh sách liên kết cơ bản.'),

-- Chương 8: Cây
(36, 'CT102', 8, 'Trung Bình', 'Cây nhị phân có bao nhiêu con tối đa?'),
(37, 'CT102', 8, 'Trung Bình', 'Binary Tree có đặc điểm gì?'),
(38, 'CT102', 8, 'Khó', 'AVL Tree là gì?'),
(39, 'CT102', 8, 'Dễ', 'Nêu khái niệm về gốc (root) và lá (leaf) trong cây.'),
(40, 'CT102', 8, 'Dễ', 'Cây nhị phân tìm kiếm (BST) là gì?'),

-- Chương 9: Bảng băm và Cây tìm kiếm
(41, 'CT102', 9, 'Khó', 'Thuật toán sắp xếp nào có độ phức tạp O(n log n)?'),
(42, 'CT102', 9, 'Khó', 'Hash Table hoạt động như thế nào?'),
(43, 'CT102', 9, 'Trung Bình', 'Binary Search Tree là gì?'),
(44, 'CT102', 9, 'Dễ', 'Hàm băm (Hash function) là gì?'),
(45, 'CT102', 9, 'Dễ', 'Nêu ưu điểm của bảng băm.'),

-- Chương 10: Thuật toán sắp xếp và tìm kiếm
(46, 'CT102', 10, 'Dễ', 'Bubble Sort có độ phức tạp là gì?'),
(47, 'CT102', 10, 'Trung Bình', 'Quick Sort sử dụng kỹ thuật gì?'),
(48, 'CT102', 10, 'Dễ', 'Thuật toán tìm kiếm tuyến tính (Linear Search) hoạt động như thế nào?'),
(49, 'CT102', 10, 'Dễ', 'Nêu một thuật toán sắp xếp đơn giản khác Bubble Sort.'),
(50, 'CT102', 10, 'Trung Bình', 'Giải thích về thuật toán Merge Sort.'),

-- Câu hỏi CT103 - Cơ sở dữ liệu
-- Chương 11: Giới thiệu CSDL
(51, 'CT103', 11, 'Dễ', 'CSDL là viết tắt của gì?'),
(52, 'CT103', 11, 'Dễ', 'Mô hình quan hệ được đề xuất bởi ai?'),
(53, 'CT103', 11, 'Dễ', 'RDBMS là viết tắt của gì?'),
(54, 'CT103', 11, 'Dễ', 'Nêu một ví dụ về hệ quản trị cơ sở dữ liệu.'),
(55, 'CT103', 11, 'Dễ', 'Mục đích chính của cơ sở dữ liệu là gì?'),

-- Chương 12: Mô hình thực thể - quan hệ (ERD) và Khóa
(56, 'CT103', 12, 'Trung Bình', 'Khóa chính trong bảng có đặc điểm gì?'),
(57, 'CT103', 12, 'Dễ', 'Primary Key là gì?'),
(58, 'CT103', 12, 'Trung Bình', 'Foreign Key là gì?'),
(59, 'CT103', 12, 'Dễ', 'Thực thể (Entity) trong ERD là gì?'),
(60, 'CT103', 12, 'Dễ', 'Mối quan hệ (Relationship) trong ERD là gì?'),

-- Chương 13: Ngôn ngữ truy vấn SQL cơ bản
(61, 'CT103', 13, 'Trung Bình', 'SQL là viết tắt của gì?'),
(62, 'CT103', 13, 'Trung Bình', 'SELECT dùng để làm gì?'),
(63, 'CT103', 13, 'Dễ', 'INSERT INTO dùng để làm gì?'),
(64, 'CT103', 13, 'Trung Bình', 'JOIN trong SQL có mấy loại?'),
(65, 'CT103', 13, 'Dễ', 'Câu lệnh UPDATE dùng để làm gì?'),

-- Chương 14: Chuẩn hóa và Index
(66, 'CT103', 14, 'Khó', 'Chuẩn hóa dữ liệu nhằm mục đích gì?'),
(67, 'CT103', 14, 'Khó', 'Normalization là gì?'),
(68, 'CT103', 14, 'Khó', 'Index trong database có tác dụng gì?'),
(69, 'CT103', 14, 'Dễ', 'Nêu mục đích của việc sử dụng Index.'),
(70, 'CT103', 14, 'Dễ', 'Dạng chuẩn 1NF là gì?'),

-- Chương 15: Giao dịch và Bảo mật
(71, 'CT103', 15, 'Trung Bình', 'Transaction là gì?'),
(72, 'CT103', 15, 'Khó', 'ACID là viết tắt của gì?'),
(73, 'CT103', 15, 'Dễ', 'Nêu một ví dụ về giao dịch trong CSDL.'),
(74, 'CT103', 15, 'Dễ', 'Mục đích của việc sao lưu và phục hồi dữ liệu.'),
(75, 'CT103', 15, 'Trung Bình', 'Giải thích về tính nhất quán (Consistency) trong ACID.'),

-- Câu hỏi CT104 - OOP
-- Chương 16: Khái niệm cơ bản
(76, 'CT104', 16, 'Dễ', 'OOP là viết tắt của gì?'),
(77, 'CT104', 16, 'Dễ', 'Tính đóng gói trong OOP có nghĩa là gì?'),
(78, 'CT104', 16, 'Dễ', 'Class là gì?'),
(79, 'CT104', 16, 'Dễ', 'Object là gì?'),
(80, 'CT104', 16, 'Dễ', 'Nêu một ví dụ về class và object.'),

-- Chương 17: Đóng gói và Constructor
(81, 'CT104', 17, 'Trung Bình', 'Lớp và đối tượng khác nhau như thế nào?'),
(82, 'CT104', 17, 'Trung Bình', 'Constructor là gì?'),
(83, 'CT104', 17, 'Dễ', 'Getter và Setter dùng để làm gì?'),
(84, 'CT104', 17, 'Dễ', 'Mục đích của constructor là gì?'),
(85, 'CT104', 17, 'Dễ', 'Nêu cú pháp khai báo một constructor.'),

-- Chương 18: Kế thừa
(86, 'CT104', 18, 'Trung Bình', 'Kế thừa cho phép làm gì?'),
(87, 'CT104', 18, 'Trung Bình', 'Polymorphism là gì?'),
(88, 'CT104', 18, 'Trung Bình', 'Interface là gì?'),
(89, 'CT104', 18, 'Dễ', 'Nêu khái niệm về lớp cha (superclass) và lớp con (subclass).'),
(90, 'CT104', 18, 'Dễ', 'Các loại kế thừa trong OOP.'),

-- Chương 19: Đa hình và Trừu tượng
(91, 'CT104', 19, 'Khó', 'Đa hình trong OOP được thể hiện như thế nào?'),
(92, 'CT104', 19, 'Khó', 'Abstract class là gì?'),
(93, 'CT104', 19, 'Khó', 'Method overloading là gì?'),
(94, 'CT104', 19, 'Dễ', 'Nêu khái niệm về method overriding.'),
(95, 'CT104', 19, 'Dễ', 'Interface là gì?'),

-- Chương 20: Xử lý ngoại lệ
(96, 'CT104', 20, 'Trung Bình', 'Exception handling là gì?'),
(97, 'CT104', 20, 'Khó', 'Try-catch-finally dùng để làm gì?'),
(98, 'CT104', 20, 'Dễ', 'Ngoại lệ (Exception) là gì?'),
(99, 'CT104', 20, 'Dễ', 'Mục đích của việc xử lý ngoại lệ.'),
(100, 'CT104', 20, 'Trung Bình', 'Các loại ngoại lệ trong lập trình.'),

-- Câu hỏi CT105 - Mạng máy tính
-- Chương 21: Khái niệm cơ bản về mạng
(101, 'CT105', 21, 'Dễ', 'Mạng LAN là gì?'),
(102, 'CT105', 21, 'Dễ', 'Mạng WAN là gì?'),
(103, 'CT105', 21, 'Dễ', 'IP Address là gì?'),
(104, 'CT105', 21, 'Dễ', 'Nêu các loại mạng máy tính phổ biến.'),
(105, 'CT105', 21, 'Dễ', 'Mục đích của mạng máy tính.'),

-- Chương 22: Mô hình OSI và TCP/IP
(106, 'CT105', 22, 'Trung Bình', 'Mô hình OSI có bao nhiêu tầng?'),
(107, 'CT105', 22, 'Dễ', 'HTTP là viết tắt của gì?'),
(108, 'CT105', 22, 'Khó', 'HTTPS khác HTTP như thế nào?'),
(109, 'CT105', 22, 'Dễ', 'Mô hình TCP/IP có bao nhiêu tầng?'),
(110, 'CT105', 22, 'Dễ', 'Tầng vật lý (Physical Layer) trong mô hình OSI có chức năng gì?'),

-- Chương 23: Giao thức TCP/UDP và Port
(111, 'CT105', 23, 'Trung Bình', 'TCP và UDP khác nhau như thế nào?'),
(112, 'CT105', 23, 'Dễ', 'Port 80 thường dùng cho giao thức gì?'),
(113, 'CT105', 23, 'Dễ', 'Port là gì trong mạng máy tính?'),
(114, 'CT105', 23, 'Dễ', 'Nêu một ví dụ về giao thức sử dụng UDP.'),
(115, 'CT105', 23, 'Trung Bình', 'Giải thích về bắt tay ba bước (three-way handshake) của TCP.'),

-- Chương 24: DNS và Subnetting
(116, 'CT105', 24, 'Khó', 'Subnet mask có chức năng gì?'),
(117, 'CT105', 24, 'Trung Bình', 'DNS có chức năng gì?'),
(118, 'CT105', 24, 'Trung Bình', 'Subnetting là gì?'),
(119, 'CT105', 24, 'Dễ', 'Nêu mục đích của DNS.'),
(120, 'CT105', 24, 'Dễ', 'Địa chỉ IP lớp A, B, C có đặc điểm gì?'),

-- Chương 25: Thiết bị mạng và NAT/VLAN
(121, 'CT105', 25, 'Khó', 'Router hoạt động ở tầng nào của OSI?'),
(122, 'CT105', 25, 'Trung Bình', 'VLAN là gì?'),
(123, 'CT105', 25, 'Khó', 'NAT có chức năng gì?'),
(124, 'CT105', 25, 'Dễ', 'Switch hoạt động ở tầng nào của OSI?'),
(125, 'CT105', 25, 'Dễ', 'Nêu chức năng của Hub.'),

-- Câu hỏi CT106 - Hệ điều hành
-- Chương 26: Giới thiệu và chức năng
(126, 'CT106', 26, 'Dễ', 'Hệ điều hành là gì?'),
(127, 'CT106', 26, 'Dễ', 'Chức năng chính của hệ điều hành?'),
(128, 'CT106', 26, 'Dễ', 'Nêu các loại hệ điều hành phổ biến.'),
(129, 'CT106', 26, 'Dễ', 'Mục đích của hệ điều hành.'),
(130, 'CT106', 26, 'Trung Bình', 'Sự khác biệt giữa kernel và shell.'),

-- Chương 27: Quản lý tiến trình
(131, 'CT106', 27, 'Trung Bình', 'Tiến trình là gì?'),
(132, 'CT106', 27, 'Dễ', 'Nêu các trạng thái của một tiến trình.'),
(133, 'CT106', 27, 'Dễ', 'Sự khác biệt giữa tiến trình và chương trình.'),
(134, 'CT106', 27, 'Trung Bình', 'Giải thích về khối điều khiển tiến trình (PCB).'),
(135, 'CT106', 27, 'Trung Bình', 'Các phương pháp lập lịch CPU.'),

-- Chương 28: Quản lý bộ nhớ
(136, 'CT106', 28, 'Trung Bình', 'Quản lý bộ nhớ ảo có ưu điểm gì?'),
(137, 'CT106', 28, 'Dễ', 'Bộ nhớ chính (RAM) là gì?'),
(138, 'CT106', 28, 'Dễ', 'Mục đích của quản lý bộ nhớ.'),
(139, 'CT106', 28, 'Trung Bình', 'Giải thích về phân trang (paging).'),
(140, 'CT106', 28, 'Trung Bình', 'Sự khác biệt giữa bộ nhớ vật lý và bộ nhớ ảo.'),

-- Chương 29: Hệ thống File
(141, 'CT106', 29, 'Dễ', 'Hệ thống file là gì?'),
(142, 'CT106', 29, 'Dễ', 'Nêu các thao tác cơ bản trên file.'),
(143, 'CT106', 29, 'Dễ', 'Thư mục (directory) có chức năng gì?'),
(144, 'CT106', 29, 'Trung Bình', 'Sự khác biệt giữa file và thư mục.'),
(145, 'CT106', 29, 'Trung Bình', 'Các phương pháp cấp phát không gian đĩa.'),

-- Chương 30: Deadlock và Bảo mật
(146, 'CT106', 30, 'Khó', 'Deadlock xảy ra khi nào?'),
(147, 'CT106', 30, 'Dễ', 'Nêu các điều kiện cần để xảy ra deadlock.'),
(148, 'CT106', 30, 'Dễ', 'Mục đích của bảo mật hệ điều hành.'),
(149, 'CT106', 30, 'Trung Bình', 'Các phương pháp ngăn chặn deadlock.'),
(150, 'CT106', 30, 'Trung Bình', 'Giải thích về thuật toán Banker.'),

-- Câu hỏi CT107 - Phân tích hệ thống
-- Chương 31: Giới thiệu
(151, 'CT107', 31, 'Dễ', 'Phân tích hệ thống là gì?'),
(152, 'CT107', 31, 'Dễ', 'Mục đích của phân tích hệ thống?'),
(153, 'CT107', 31, 'Dễ', 'Nêu các giai đoạn chính trong phát triển hệ thống.'),
(154, 'CT107', 31, 'Dễ', 'Vai trò của nhà phân tích hệ thống.'),
(155, 'CT107', 31, 'Trung Bình', 'Sự khác biệt giữa phân tích và thiết kế hệ thống.'),

-- Chương 32: Thu thập yêu cầu
(156, 'CT107', 32, 'Trung Bình', 'Thu thập yêu cầu bao gồm những gì?'),
(157, 'CT107', 32, 'Dễ', 'Yêu cầu chức năng (Functional Requirement) là gì?'),
(158, 'CT107', 32, 'Dễ', 'Yêu cầu phi chức năng (Non-functional Requirement) là gì?'),
(159, 'CT107', 32, 'Trung Bình', 'Các phương pháp thu thập yêu cầu.'),
(160, 'CT107', 32, 'Trung Bình', 'Sự khác biệt giữa yêu cầu người dùng và yêu cầu hệ thống.'),

-- Chương 33: Phân tích và mô hình hóa
(161, 'CT107', 33, 'Trung Bình', 'UML là viết tắt của gì?'),
(162, 'CT107', 33, 'Dễ', 'Biểu đồ Use Case dùng để làm gì?'),
(163, 'CT107', 33, 'Dễ', 'Nêu một loại biểu đồ UML khác.'),
(164, 'CT107', 33, 'Trung Bình', 'Giải thích về biểu đồ lớp (Class Diagram).'),
(165, 'CT107', 33, 'Trung Bình', 'Sự khác biệt giữa biểu đồ hoạt động (Activity Diagram) và biểu đồ trình tự (Sequence Diagram).'),

-- Chương 34: Thiết kế hệ thống
(166, 'CT107', 34, 'Dễ', 'Thiết kế hệ thống là gì?'),
(167, 'CT107', 34, 'Dễ', 'Nêu các giai đoạn của thiết kế hệ thống.'),
(168, 'CT107', 34, 'Dễ', 'Mục đích của thiết kế kiến trúc.'),
(169, 'CT107', 34, 'Trung Bình', 'Sự khác biệt giữa thiết kế logic và thiết kế vật lý.'),
(170, 'CT107', 34, 'Trung Bình', 'Các nguyên tắc thiết kế phần mềm cơ bản.'),

-- Chương 35: Quản lý dự án phần mềm
(171, 'CT107', 35, 'Khó', 'Vòng đời phát triển phần mềm gồm mấy giai đoạn?'),
(172, 'CT107', 35, 'Dễ', 'Nêu một mô hình phát triển phần mềm.'),
(173, 'CT107', 35, 'Dễ', 'Mục đích của quản lý dự án phần mềm.'),
(174, 'CT107', 35, 'Trung Bình', 'Giải thích về mô hình thác nước (Waterfall Model).'),
(175, 'CT107', 35, 'Trung Bình', 'Sự khác biệt giữa mô hình Agile và Waterfall.'),

-- Câu hỏi CT108 - Trí tuệ nhân tạo
-- Chương 36: Giới thiệu AI và ML
(176, 'CT108', 36, 'Dễ', 'AI là viết tắt của gì?'),
(177, 'CT108', 36, 'Dễ', 'Machine Learning là gì?'),
(178, 'CT108', 36, 'Dễ', 'Nêu một ứng dụng của AI trong đời sống.'),
(179, 'CT108', 36, 'Dễ', 'Các loại học máy cơ bản.'),
(180, 'CT108', 36, 'Trung Bình', 'Sự khác biệt giữa AI và Machine Learning.'),

-- Chương 37: Thuật toán tìm kiếm
(181, 'CT108', 37, 'Trung Bình', 'Thuật toán tìm kiếm A* là gì?'),
(182, 'CT108', 37, 'Dễ', 'Nêu một thuật toán tìm kiếm không thông tin (uninformed search).'),
(183, 'CT108', 37, 'Dễ', 'Mục đích của thuật toán tìm kiếm trong AI.'),
(184, 'CT108', 37, 'Trung Bình', 'Giải thích về thuật toán tìm kiếm theo chiều rộng (BFS).'),
(185, 'CT108', 37, 'Trung Bình', 'Sự khác biệt giữa BFS và DFS (Depth-First Search).'),

-- Chương 38: Học không giám sát và Học tăng cường
(186, 'CT108', 38, 'Dễ', 'Học không giám sát (Unsupervised Learning) là gì?'),
(187, 'CT108', 38, 'Dễ', 'Nêu một thuật toán học không giám sát.'),
(188, 'CT108', 38, 'Dễ', 'Học tăng cường (Reinforcement Learning) là gì?'),
(189, 'CT108', 38, 'Trung Bình', 'Giải thích về thuật toán K-Means.'),
(190, 'CT108', 38, 'Trung Bình', 'Sự khác biệt giữa phân cụm (clustering) và phân loại (classification).'),

-- Chương 39: Mạng nơ-ron và Học sâu
(191, 'CT108', 39, 'Trung Bình', 'Neural Network là gì?'),
(192, 'CT108', 39, 'Dễ', 'Nêu các thành phần cơ bản của một nơ-ron nhân tạo.'),
(193, 'CT108', 39, 'Dễ', 'Học sâu (Deep Learning) là gì?'),
(194, 'CT108', 39, 'Trung Bình', 'Giải thích về hàm kích hoạt (activation function).'),
(195, 'CT108', 39, 'Trung Bình', 'Sự khác biệt giữa mạng nơ-ron truyền thẳng (feedforward) và mạng nơ-ron hồi quy (recurrent).'),

-- Chương 40: Ứng dụng AI
(196, 'CT108', 40, 'Khó', 'Deep Learning khác Machine Learning như thế nào?'),
(197, 'CT108', 40, 'Dễ', 'Nêu một ứng dụng của Xử lý ngôn ngữ tự nhiên (NLP).'),
(198, 'CT108', 40, 'Dễ', 'Thị giác máy tính (Computer Vision) là gì?'),
(199, 'CT108', 40, 'Trung Bình', 'Giải thích về hệ thống khuyến nghị (Recommender Systems).'),
(200, 'CT108', 40, 'Trung Bình', 'Các thách thức trong phát triển xe tự lái.'),

-- Câu hỏi CT109 - Lập trình web
-- Chương 41: HTML và CSS cơ bản
(201, 'CT109', 41, 'Dễ', 'HTML là viết tắt của gì?'),
(202, 'CT109', 41, 'Dễ', 'CSS dùng để làm gì?'),
(203, 'CT109', 41, 'Dễ', 'Nêu một thẻ HTML cơ bản.'),
(204, 'CT109', 41, 'Dễ', 'Các cách nhúng CSS vào trang web.'),
(205, 'CT109', 41, 'Trung Bình', 'Sự khác biệt giữa thẻ block và thẻ inline trong HTML.'),

-- Chương 42: JavaScript cơ bản
(206, 'CT109', 42, 'Trung Bình', 'JavaScript là ngôn ngữ gì?'),
(207, 'CT109', 42, 'Dễ', 'Nêu mục đích chính của JavaScript.'),
(208, 'CT109', 42, 'Dễ', 'Cách nhúng JavaScript vào trang HTML.'),
(209, 'CT109', 42, 'Trung Bình', 'Các kiểu dữ liệu cơ bản trong JavaScript.'),
(210, 'CT109', 42, 'Trung Bình', 'Sự khác biệt giữa `var`, `let`, và `const`.'),

-- Chương 43: Lập trình phía máy chủ (Server-side)
(211, 'CT109', 43, 'Trung Bình', 'PHP là ngôn ngữ lập trình gì?'),
(212, 'CT109', 43, 'Dễ', 'Nêu một ngôn ngữ lập trình phía máy chủ khác PHP.'),
(213, 'CT109', 43, 'Dễ', 'Mục đích của lập trình phía máy chủ.'),
(214, 'CT109', 43, 'Trung Bình', 'Sự khác biệt giữa lập trình phía máy khách và phía máy chủ.'),
(215, 'CT109', 43, 'Trung Bình', 'Giải thích về khái niệm API (Application Programming Interface).'),

-- Chương 44: Framework và Thư viện
(216, 'CT109', 44, 'Dễ', 'Nêu một framework JavaScript phổ biến.'),
(217, 'CT109', 44, 'Dễ', 'Thư viện (Library) là gì?'),
(218, 'CT109', 44, 'Dễ', 'Mục đích của việc sử dụng framework.'),
(219, 'CT109', 44, 'Trung Bình', 'Sự khác biệt giữa framework và thư viện.'),
(220, 'CT109', 44, 'Trung Bình', 'Giải thích về Virtual DOM trong React.'),

-- Chương 45: Bảo mật web
(221, 'CT109', 45, 'Khó', 'SQL Injection là gì?'),
(222, 'CT109', 45, 'Dễ', 'Nêu một lỗ hổng bảo mật web phổ biến khác.'),
(223, 'CT109', 45, 'Dễ', 'Mục đích của bảo mật web.'),
(224, 'CT109', 45, 'Trung Bình', 'Giải thích về Cross-Site Scripting (XSS).'),
(225, 'CT109', 45, 'Trung Bình', 'Cách ngăn chặn tấn công CSRF (Cross-Site Request Forgery).'),

-- Câu hỏi CT110 - An toàn thông tin
-- Chương 46: Khái niệm cơ bản
(226, 'CT110', 46, 'Dễ', 'An toàn thông tin là gì?'),
(227, 'CT110', 46, 'Dễ', 'Nêu các trụ cột của an toàn thông tin (CIA Triad).'),
(228, 'CT110', 46, 'Dễ', 'Mục đích của an toàn thông tin.'),
(229, 'CT110', 46, 'Trung Bình', 'Giải thích về tính bảo mật (Confidentiality).'),
(230, 'CT110', 46, 'Trung Bình', 'Sự khác biệt giữa lỗ hổng (vulnerability) và mối đe dọa (threat).'),

-- Chương 47: Mã hóa và Giải mã
(231, 'CT110', 47, 'Dễ', 'Mã hóa dữ liệu nhằm mục đích gì?'),
(232, 'CT110', 47, 'Dễ', 'Nêu một thuật toán mã hóa đối xứng.'),
(233, 'CT110', 47, 'Dễ', 'Giải mã là gì?'),
(234, 'CT110', 47, 'Trung Bình', 'Sự khác biệt giữa mã hóa đối xứng và mã hóa bất đối xứng.'),
(235, 'CT110', 47, 'Trung Bình', 'Giải thích về khóa công khai (Public Key) và khóa riêng tư (Private Key).'),

-- Chương 48: Bảo mật mạng
(236, 'CT110', 48, 'Trung Bình', 'Firewall có chức năng gì?'),
(237, 'CT110', 48, 'Dễ', 'Nêu một loại tường lửa.'),
(238, 'CT110', 48, 'Dễ', 'VPN là viết tắt của gì?'),
(239, 'CT110', 48, 'Trung Bình', 'Giải thích về hệ thống phát hiện xâm nhập (IDS).'),
(240, 'CT110', 48, 'Trung Bình', 'Sự khác biệt giữa IDS và IPS (Intrusion Prevention System).'),

-- Chương 49: Phần mềm độc hại và Tấn công xã hội
(241, 'CT110', 49, 'Trung Bình', 'Virus máy tính là gì?'),
(242, 'CT110', 49, 'Dễ', 'Nêu một loại phần mềm độc hại khác virus.'),
(243, 'CT110', 49, 'Dễ', 'Tấn công lừa đảo (Phishing) là gì?'),
(244, 'CT110', 49, 'Trung Bình', 'Sự khác biệt giữa virus và worm.'),
(245, 'CT110', 49, 'Trung Bình', 'Giải thích về Trojan Horse.'),

-- Chương 50: Quản lý rủi ro và Pháp lý
(246, 'CT110', 50, 'Dễ', 'Rủi ro an toàn thông tin là gì?'),
(247, 'CT110', 50, 'Dễ', 'Nêu một tiêu chuẩn an toàn thông tin quốc tế.'),
(248, 'CT110', 50, 'Dễ', 'Mục đích của việc đánh giá rủi ro.'),
(249, 'CT110', 50, 'Trung Bình', 'Các bước trong quy trình quản lý rủi ro.'),
(250, 'CT110', 50, 'Trung Bình', 'Giải thích về kiểm toán an toàn thông tin.');

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
(1, 1), (1, 2), (1, 3), (1, 4), (1, 5);

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
(2, 5, 18); -- Câu 5: Chọn đáp án sai (Nhiều giá trị)

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
(46, 'CT110', 'Khái niệm an toàn thông tin'),
(47, 'CT110', 'Mã hóa và bảo mật dữ liệu'),
(48, 'CT110', 'Bảo mật mạng và firewall'),
(49, 'CT110', 'Virus và phần mềm độc hại'),
(50, 'CT110', 'Mật mã học và chữ ký số');

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
-- Đáp án cho câu hỏi 1-25: CT101 - Lập trình C
(1, 1, '1972', 1), (2, 1, '1970', 0), (3, 1, '1975', 0), (4, 1, '1969', 0),
(5, 2, 'Dennis Ritchie', 1), (6, 2, 'Bjarne Stroustrup', 0), (7, 2, 'James Gosling', 0), (8, 2, 'Guido van Rossum', 0),
(9, 3, 'int x;', 1), (10, 3, 'x = int;', 0), (11, 3, 'var x;', 0), (12, 3, 'x int;', 0),
(13, 4, '4 byte', 1), (14, 4, '2 byte', 0), (15, 4, '8 byte', 0), (16, 4, '1 byte', 0),
(17, 5, 'Điểm vào của chương trình', 1), (18, 5, 'Hàm xuất dữ liệu', 0), (19, 5, 'Hàm nhập dữ liệu', 0), (20, 5, 'Hàm tính toán', 0),
(21, 6, 'for, while, do-while', 1), (22, 6, 'if, else', 0), (23, 6, 'switch, case', 0), (24, 6, 'break, continue', 0),
(25, 7, 'Cấu trúc điều kiện', 1), (26, 7, 'Cấu trúc lặp', 0), (27, 7, 'Cấu trúc nhảy', 0), (28, 7, 'Cấu trúc tuần tự', 0),
(29, 8, 'for (khởi tạo; điều kiện; tăng/giảm)', 1), (30, 8, 'for (điều kiện; khởi tạo; tăng/giảm)', 0), (31, 8, 'for (tăng/giảm; điều kiện; khởi tạo)', 0), (32, 8, 'for (khởi tạo; tăng/giảm; điều kiện)', 0),
(33, 9, 'Break thoát vòng lặp, continue bỏ qua lần lặp hiện tại', 1), (34, 9, 'Break và continue giống nhau', 0), (35, 9, 'Break bỏ qua lần lặp, continue thoát vòng lặp', 0), (36, 9, 'Cả hai đều thoát chương trình', 0),
(37, 10, 'while (điều kiện) { ... }', 1), (38, 10, 'while { ... } (điều kiện)', 0), (39, 10, 'while (điều kiện) { ... } end', 0), (40, 10, 'while { điều kiện ... }', 0),
(41, 11, 'Một giá trị', 1), (42, 11, 'Nhiều giá trị', 0), (43, 11, 'Không giới hạn', 0), (44, 11, 'Hai giá trị', 0),
(45, 12, '0', 1), (46, 12, '1', 0), (47, 12, '-1', 0), (48, 12, 'Tùy ý', 0),
(49, 13, 'Cấp phát bộ nhớ động', 1), (50, 13, 'Giải phóng bộ nhớ', 0), (51, 13, 'Sao chép chuỗi', 0), (52, 13, 'So sánh chuỗi', 0),
(53, 14, 'Tập hợp các phần tử cùng kiểu dữ liệu', 1), (54, 14, 'Tập hợp các biến khác kiểu', 0), (55, 14, 'Một biến duy nhất', 0), (56, 14, 'Một hàm', 0),
(57, 15, 'kiểu_trả_về tên_hàm(tham_số) { ... }', 1), (58, 15, 'function tên_hàm(tham_số) { ... }', 0), (59, 15, 'def tên_hàm(tham_số) { ... }', 0), (60, 15, 'tên_hàm(tham_số) { ... }', 0),
(61, 16, 'Biến lưu địa chỉ của biến khác', 1), (62, 16, 'Biến lưu giá trị số', 0), (63, 16, 'Biến lưu chuỗi', 0), (64, 16, 'Biến lưu mảng', 0),
(65, 17, '\\0', 1), (66, 17, '\\n', 0), (67, 17, '\\t', 0), (68, 17, 'EOF', 0),
(69, 18, 'kiểu_dữ_liệu *tên_con_trỏ;', 1), (70, 18, '*kiểu_dữ_liệu tên_con_trỏ;', 0), (71, 18, 'tên_con_trỏ *kiểu_dữ_liệu;', 0), (72, 18, 'pointer kiểu_dữ_liệu tên_con_trỏ;', 0),
(73, 19, 'Tính độ dài chuỗi', 1), (74, 19, 'So sánh chuỗi', 0), (75, 19, 'Nối chuỗi', 0), (76, 19, 'Sao chép chuỗi', 0),
(77, 20, '* là toán tử giải tham chiếu, & là toán tử địa chỉ', 1), (78, 20, '* và & giống nhau', 0), (79, 20, '* là địa chỉ, & là giá trị', 0), (80, 20, '* và & đều là toán tử số học', 0),
(81, 21, 'fopen()', 1), (82, 21, 'open()', 0), (83, 21, 'fileopen()', 0), (84, 21, 'readfile()', 0),
(85, 22, 'Kiểu dữ liệu do người dùng định nghĩa', 1), (86, 22, 'Kiểu dữ liệu có sẵn', 0), (87, 22, 'Một hàm', 0), (88, 22, 'Một biến', 0),
(89, 23, 'struct tên_struct { ... };', 1), (90, 23, 'struct { ... } tên_struct;', 0), (91, 23, 'tên_struct struct { ... };', 0), (92, 23, 'struct tên_struct { ... }', 0),
(93, 24, 'r, w, a, r+, w+, a+', 1), (94, 24, 'read, write, append', 0), (95, 24, 'open, close, read', 0), (96, 24, 'input, output, append', 0),
(97, 25, 'Sử dụng toán tử . hoặc ->', 1), (98, 25, 'Sử dụng toán tử []', 0), (99, 25, 'Sử dụng toán tử ()', 0), (100, 25, 'Sử dụng toán tử *', 0),

-- Đáp án cho câu hỏi 26-50: CT102 - Cấu trúc dữ liệu
(101, 26, 'LIFO (Last In First Out)', 1), (102, 26, 'FIFO (First In First Out)', 0), (103, 26, 'LILO (Last In Last Out)', 0), (104, 26, 'FILO (First In Last Out)', 0),
(105, 27, 'FIFO (First In First Out)', 1), (106, 27, 'LIFO (Last In First Out)', 0), (107, 27, 'LILO (Last In Last Out)', 0), (108, 27, 'FILO (First In Last Out)', 0),
(109, 28, 'Cấu trúc dữ liệu tuyến tính', 1), (110, 28, 'Cấu trúc dữ liệu phi tuyến', 0), (111, 28, 'Cấu trúc dữ liệu cây', 0), (112, 28, 'Cấu trúc dữ liệu đồ thị', 0),
(113, 29, 'Hàng đợi với độ ưu tiên', 1), (114, 29, 'Hàng đợi thông thường', 0), (115, 29, 'Ngăn xếp', 0), (116, 29, 'Danh sách liên kết', 0),
(117, 30, 'Truy cập nhanh theo chỉ số', 1), (118, 30, 'Chèn/xóa nhanh ở giữa', 0), (119, 30, 'Kích thước động', 0), (120, 30, 'Không cần chỉ số', 0),
(121, 31, 'Chèn/xóa nhanh', 1), (122, 31, 'Truy cập nhanh theo chỉ số', 0), (123, 31, 'Kích thước cố định', 0), (124, 31, 'Tiết kiệm bộ nhớ hơn mảng', 0),
(125, 32, 'Kích thước động, chèn/xóa nhanh', 1), (126, 32, 'Truy cập nhanh theo chỉ số', 0), (127, 32, 'Kích thước cố định', 0), (128, 32, 'Tiết kiệm bộ nhớ hơn', 0),
(129, 33, 'Danh sách có con trỏ trước và sau', 1), (130, 33, 'Danh sách chỉ có con trỏ sau', 0), (131, 33, 'Danh sách vòng tròn', 0), (132, 33, 'Danh sách có hai đầu', 0),
(133, 34, 'Phần tử cơ bản chứa dữ liệu và con trỏ', 1), (134, 34, 'Chỉ chứa dữ liệu', 0), (135, 34, 'Chỉ chứa con trỏ', 0), (136, 34, 'Chứa mảng dữ liệu', 0),
(137, 35, 'Singly, Doubly, Circular', 1), (138, 35, 'Linear, Non-linear', 0), (139, 35, 'Static, Dynamic', 0), (140, 35, 'Array, List', 0),
(141, 36, '2 con', 1), (142, 36, '1 con', 0), (143, 36, '3 con', 0), (144, 36, 'Không giới hạn', 0),
(145, 37, 'Mỗi nút có tối đa 2 con', 1), (146, 37, 'Mỗi nút có 1 con', 0), (147, 37, 'Mỗi nút có 3 con', 0), (148, 37, 'Mỗi nút có vô số con', 0),
(149, 38, 'Cây nhị phân tự cân bằng', 1), (150, 38, 'Cây nhị phân thông thường', 0), (151, 38, 'Cây đa phân', 0), (152, 38, 'Cây tìm kiếm', 0),
(153, 39, 'Root là nút gốc, leaf là nút lá không có con', 1), (154, 39, 'Root và leaf giống nhau', 0), (155, 39, 'Root là nút lá, leaf là nút gốc', 0), (156, 39, 'Root và leaf đều có con', 0),
(157, 40, 'Cây nhị phân có thứ tự', 1), (158, 40, 'Cây nhị phân không có thứ tự', 0), (159, 40, 'Cây đa phân', 0), (160, 40, 'Cây vô hướng', 0),
(161, 41, 'Merge Sort, Quick Sort, Heap Sort', 1), (162, 41, 'Bubble Sort', 0), (163, 41, 'Selection Sort', 0), (164, 41, 'Insertion Sort', 0),
(165, 42, 'Sử dụng hàm băm để ánh xạ khóa vào chỉ số', 1), (166, 42, 'Sắp xếp dữ liệu', 0), (167, 42, 'Tìm kiếm tuần tự', 0), (168, 42, 'Lưu trữ tuần tự', 0),
(169, 43, 'Cây nhị phân có thứ tự để tìm kiếm', 1), (170, 43, 'Cây nhị phân thông thường', 0), (171, 43, 'Cây đa phân', 0), (172, 43, 'Cây vô hướng', 0),
(173, 44, 'Hàm chuyển đổi khóa thành chỉ số', 1), (174, 44, 'Hàm sắp xếp', 0), (175, 44, 'Hàm tìm kiếm', 0), (176, 44, 'Hàm so sánh', 0),
(177, 45, 'Tìm kiếm và chèn nhanh', 1), (178, 45, 'Sắp xếp nhanh', 0), (179, 45, 'Truy cập tuần tự nhanh', 0), (180, 45, 'Xóa nhanh', 0),
(181, 46, 'O(n²)', 1), (182, 46, 'O(n log n)', 0), (183, 46, 'O(n)', 0), (184, 46, 'O(log n)', 0),
(185, 47, 'Chia để trị (Divide and Conquer)', 1), (186, 47, 'Tham lam (Greedy)', 0), (187, 47, 'Quy hoạch động', 0), (188, 47, 'Backtracking', 0),
(189, 48, 'Duyệt từ đầu đến cuối danh sách', 1), (190, 48, 'Chia đôi danh sách', 0), (191, 48, 'Băm khóa', 0), (192, 48, 'Sắp xếp trước', 0),
(193, 49, 'Selection Sort', 1), (194, 49, 'Quick Sort', 0), (195, 49, 'Merge Sort', 0), (196, 49, 'Heap Sort', 0),
(197, 50, 'Chia mảng thành hai nửa, sắp xếp rồi gộp lại', 1), (198, 50, 'So sánh và đổi chỗ từng cặp', 0), (199, 50, 'Chọn phần tử nhỏ nhất đưa lên đầu', 0), (200, 50, 'Chèn từng phần tử vào vị trí đúng', 0),

-- Đáp án cho câu hỏi 51-75: CT103 - Cơ sở dữ liệu
(201, 51, 'Cơ sở dữ liệu', 1), (202, 51, 'Cấu trúc dữ liệu', 0), (203, 51, 'Chuẩn hóa dữ liệu', 0), (204, 51, 'Quản lý dữ liệu', 0),
(205, 52, 'Edgar F. Codd', 1), (206, 52, 'Bill Gates', 0), (207, 52, 'Larry Ellison', 0), (208, 52, 'Tim Berners-Lee', 0),
(209, 53, 'Relational Database Management System', 1), (210, 53, 'Relational Data Management System', 0), (211, 53, 'Relational Database Model System', 0), (212, 53, 'Relational Data Model System', 0),
(213, 54, 'MySQL, PostgreSQL, Oracle', 1), (214, 54, 'HTML, CSS, JavaScript', 0), (215, 54, 'Java, Python, C++', 0), (216, 54, 'Windows, Linux, macOS', 0),
(217, 55, 'Lưu trữ và quản lý dữ liệu', 1), (218, 55, 'Xử lý văn bản', 0), (219, 55, 'Tính toán số học', 0), (220, 55, 'Hiển thị đồ họa', 0),
(221, 56, 'Không trùng lặp, không null, duy nhất', 1), (222, 56, 'Có thể trùng lặp', 0), (223, 56, 'Có thể null', 0), (224, 56, 'Không duy nhất', 0),
(225, 57, 'Khóa chính của bảng', 1), (226, 57, 'Khóa phụ', 0), (227, 57, 'Khóa ngoại', 0), (228, 57, 'Khóa hợp', 0),
(229, 58, 'Khóa tham chiếu đến khóa chính của bảng khác', 1), (230, 58, 'Khóa chính', 0), (231, 58, 'Khóa duy nhất', 0), (232, 58, 'Khóa hợp', 0),
(233, 59, 'Đối tượng trong thế giới thực', 1), (234, 59, 'Mối quan hệ', 0), (235, 59, 'Thuộc tính', 0), (236, 59, 'Khóa', 0),
(237, 60, 'Liên kết giữa các thực thể', 1), (238, 60, 'Thực thể', 0), (239, 60, 'Thuộc tính', 0), (240, 60, 'Khóa', 0),
(241, 61, 'Structured Query Language', 1), (242, 61, 'Simple Query Language', 0), (243, 61, 'Standard Query Language', 0), (244, 61, 'System Query Language', 0),
(245, 62, 'Truy vấn dữ liệu', 1), (246, 62, 'Chèn dữ liệu', 0), (247, 62, 'Cập nhật dữ liệu', 0), (248, 62, 'Xóa dữ liệu', 0),
(249, 63, 'Chèn dữ liệu vào bảng', 1), (250, 63, 'Truy vấn dữ liệu', 0), (251, 63, 'Cập nhật dữ liệu', 0), (252, 63, 'Xóa dữ liệu', 0),
(253, 64, '4 loại: INNER, LEFT, RIGHT, FULL', 1), (254, 64, '2 loại', 0), (255, 64, '3 loại', 0), (256, 64, '5 loại', 0),
(257, 65, 'Cập nhật dữ liệu trong bảng', 1), (258, 65, 'Truy vấn dữ liệu', 0), (259, 65, 'Chèn dữ liệu', 0), (260, 65, 'Xóa dữ liệu', 0),
(261, 66, 'Giảm dư thừa dữ liệu', 1), (262, 66, 'Tăng dư thừa dữ liệu', 0), (263, 66, 'Xóa dữ liệu', 0), (264, 66, 'Sao chép dữ liệu', 0),
(265, 67, 'Quá trình chuẩn hóa cấu trúc bảng', 1), (266, 67, 'Quá trình xóa dữ liệu', 0), (267, 67, 'Quá trình sao chép dữ liệu', 0), (268, 67, 'Quá trình mã hóa dữ liệu', 0),
(269, 68, 'Tăng tốc độ truy vấn', 1), (270, 68, 'Giảm tốc độ truy vấn', 0), (271, 68, 'Xóa dữ liệu', 0), (272, 68, 'Sao chép dữ liệu', 0),
(273, 69, 'Tăng tốc độ tìm kiếm', 1), (274, 69, 'Giảm tốc độ tìm kiếm', 0), (275, 69, 'Xóa dữ liệu', 0), (276, 69, 'Mã hóa dữ liệu', 0),
(277, 70, 'Mỗi cột chỉ chứa giá trị nguyên tử', 1), (278, 70, 'Có khóa chính', 0), (279, 70, 'Không có khóa ngoại', 0), (280, 70, 'Có nhiều khóa chính', 0),
(281, 71, 'Một đơn vị công việc', 1), (282, 71, 'Một bảng', 0), (283, 71, 'Một khóa', 0), (284, 71, 'Một truy vấn', 0),
(285, 72, 'Atomicity, Consistency, Isolation, Durability', 1), (286, 72, 'Access, Control, Integrity, Data', 0), (287, 72, 'Add, Create, Insert, Delete', 0), (288, 72, 'All, Count, Index, Database', 0),
(289, 73, 'Chuyển tiền từ tài khoản A sang tài khoản B', 1), (290, 73, 'Truy vấn dữ liệu', 0), (291, 73, 'Xóa dữ liệu', 0), (292, 73, 'Sao lưu dữ liệu', 0),
(293, 74, 'Bảo vệ dữ liệu khỏi mất mát', 1), (294, 74, 'Xóa dữ liệu', 0), (295, 74, 'Mã hóa dữ liệu', 0), (296, 74, 'Nén dữ liệu', 0),
(297, 75, 'Đảm bảo dữ liệu hợp lệ sau giao dịch', 1), (298, 75, 'Đảm bảo giao dịch hoàn tất', 0), (299, 75, 'Đảm bảo giao dịch cô lập', 0), (300, 75, 'Đảm bảo giao dịch bền vững', 0),

-- Đáp án cho câu hỏi 76-100: CT104 - OOP
(301, 76, 'Object-Oriented Programming', 1), (302, 76, 'Object-Optimized Programming', 0), (303, 76, 'Object-Ordered Programming', 0), (304, 76, 'Object-Organized Programming', 0),
(305, 77, 'Ẩn thông tin và chỉ cho phép truy cập qua phương thức', 1), (306, 77, 'Hiển thị tất cả thông tin', 0), (307, 77, 'Cho phép truy cập trực tiếp', 0), (308, 77, 'Không có quy tắc truy cập', 0),
(309, 78, 'Khuôn mẫu để tạo đối tượng', 1), (310, 78, 'Một đối tượng cụ thể', 0), (311, 78, 'Một hàm', 0), (312, 78, 'Một biến', 0),
(313, 79, 'Thể hiện cụ thể của class', 1), (314, 79, 'Khuôn mẫu', 0), (315, 79, 'Một hàm', 0), (316, 79, 'Một biến', 0),
(317, 80, 'Class: Xe, Object: Xe máy của tôi', 1), (318, 80, 'Class và Object giống nhau', 0), (319, 80, 'Object là khuôn mẫu', 0), (320, 80, 'Class là thể hiện', 0),
(321, 81, 'Class là khuôn mẫu, Object là thể hiện', 1), (322, 81, 'Class và Object giống nhau', 0), (323, 81, 'Object là khuôn mẫu', 0), (324, 81, 'Class là thể hiện', 0),
(325, 82, 'Phương thức khởi tạo đối tượng', 1), (326, 82, 'Phương thức hủy đối tượng', 0), (327, 82, 'Phương thức truy cập', 0), (328, 82, 'Phương thức tính toán', 0),
(329, 83, 'Getter lấy giá trị, Setter gán giá trị', 1), (330, 83, 'Getter và Setter giống nhau', 0), (331, 83, 'Getter gán giá trị, Setter lấy giá trị', 0), (332, 83, 'Cả hai đều xóa giá trị', 0),
(333, 84, 'Khởi tạo đối tượng', 1), (334, 84, 'Hủy đối tượng', 0), (335, 84, 'Truy cập đối tượng', 0), (336, 84, 'Sao chép đối tượng', 0),
(337, 85, 'public ClassName() { ... }', 1), (338, 85, 'constructor ClassName() { ... }', 0), (339, 85, 'def ClassName() { ... }', 0), (340, 85, 'function ClassName() { ... }', 0),
(341, 86, 'Lớp con kế thừa thuộc tính và phương thức từ lớp cha', 1), (342, 86, 'Lớp cha kế thừa từ lớp con', 0), (343, 86, 'Không có kế thừa', 0), (344, 86, 'Kế thừa ngược', 0),
(345, 87, 'Đa hình - nhiều hình thức', 1), (346, 87, 'Đơn hình', 0), (347, 87, 'Kế thừa', 0), (348, 87, 'Đóng gói', 0),
(349, 88, 'Hợp đồng định nghĩa phương thức', 1), (350, 88, 'Lớp cụ thể', 0), (351, 88, 'Đối tượng', 0), (352, 88, 'Biến', 0),
(353, 89, 'Superclass là lớp cha, Subclass là lớp con', 1), (354, 89, 'Superclass và Subclass giống nhau', 0), (355, 89, 'Superclass là lớp con', 0), (356, 89, 'Subclass là lớp cha', 0),
(357, 90, 'Đơn kế thừa, đa kế thừa', 1), (358, 90, 'Chỉ có đơn kế thừa', 0), (359, 90, 'Chỉ có đa kế thừa', 0), (360, 90, 'Không có kế thừa', 0),
(361, 91, 'Method overriding và method overloading', 1), (362, 91, 'Chỉ có method overriding', 0), (363, 91, 'Chỉ có method overloading', 0), (364, 91, 'Không có đa hình', 0),
(365, 92, 'Lớp không thể khởi tạo trực tiếp', 1), (366, 92, 'Lớp cụ thể', 0), (367, 92, 'Lớp cuối cùng', 0), (368, 92, 'Lớp riêng tư', 0),
(369, 93, 'Nhiều phương thức cùng tên, khác tham số', 1), (370, 93, 'Một phương thức duy nhất', 0), (371, 93, 'Nhiều phương thức khác tên', 0), (372, 93, 'Phương thức không có tên', 0),
(373, 94, 'Ghi đè phương thức của lớp cha', 1), (374, 94, 'Tạo phương thức mới', 0), (375, 94, 'Xóa phương thức', 0), (376, 94, 'Sao chép phương thức', 0),
(377, 95, 'Hợp đồng định nghĩa phương thức', 1), (378, 95, 'Lớp cụ thể', 0), (379, 95, 'Đối tượng', 0), (380, 95, 'Biến', 0),
(381, 96, 'Xử lý lỗi trong chương trình', 1), (382, 96, 'Tạo lỗi', 0), (383, 96, 'Bỏ qua lỗi', 0), (384, 96, 'Ghi log lỗi', 0),
(385, 97, 'Try thử, catch bắt lỗi, finally luôn thực thi', 1), (386, 97, 'Try, catch, finally giống nhau', 0), (387, 97, 'Try bắt lỗi, catch thử', 0), (388, 97, 'Finally không bao giờ thực thi', 0),
(389, 98, 'Sự kiện bất thường xảy ra trong chương trình', 1), (390, 98, 'Sự kiện bình thường', 0), (391, 98, 'Biến', 0), (392, 98, 'Hàm', 0),
(393, 99, 'Xử lý lỗi một cách có kiểm soát', 1), (394, 99, 'Tạo lỗi', 0), (395, 99, 'Bỏ qua lỗi', 0), (396, 99, 'Ghi log lỗi', 0),
(397, 100, 'Checked exception, Unchecked exception', 1), (398, 100, 'Chỉ có checked exception', 0), (399, 100, 'Chỉ có unchecked exception', 0), (400, 100, 'Không có loại exception', 0),

-- Đáp án cho câu hỏi 101-125: CT105 - Mạng máy tính
(401, 101, 'Mạng cục bộ', 1), (402, 101, 'Mạng diện rộng', 0), (403, 101, 'Mạng toàn cầu', 0), (404, 101, 'Mạng không dây', 0),
(405, 102, 'Mạng diện rộng', 1), (406, 102, 'Mạng cục bộ', 0), (407, 102, 'Mạng cá nhân', 0), (408, 102, 'Mạng nội bộ', 0),
(409, 103, 'Địa chỉ định danh thiết bị trong mạng', 1), (410, 103, 'Tên thiết bị', 0), (411, 103, 'Mật khẩu', 0), (412, 103, 'Giao thức', 0),
(413, 104, 'LAN, WAN, MAN, PAN', 1), (414, 104, 'TCP, UDP, HTTP', 0), (415, 104, 'HTML, CSS, JS', 0), (416, 104, 'Windows, Linux, Mac', 0),
(417, 105, 'Chia sẻ tài nguyên và thông tin', 1), (418, 105, 'Chỉ để giải trí', 0), (419, 105, 'Chỉ để lưu trữ', 0), (420, 105, 'Chỉ để tính toán', 0),
(421, 106, '7 tầng', 1), (422, 106, '5 tầng', 0), (423, 106, '4 tầng', 0), (424, 106, '8 tầng', 0),
(425, 107, 'HyperText Transfer Protocol', 1), (426, 107, 'HyperText Transport Protocol', 0), (427, 107, 'HyperText Transfer Process', 0), (428, 107, 'HyperText Transport Process', 0),
(429, 108, 'HTTPS có mã hóa SSL/TLS', 1), (430, 108, 'HTTPS và HTTP giống nhau', 0), (431, 108, 'HTTPS không có mã hóa', 0), (432, 108, 'HTTP có mã hóa', 0),
(433, 109, '4 tầng', 1), (434, 109, '7 tầng', 0), (435, 109, '5 tầng', 0), (436, 109, '6 tầng', 0),
(437, 110, 'Truyền tín hiệu vật lý', 1), (438, 110, 'Định tuyến', 0), (439, 110, 'Mã hóa', 0), (440, 110, 'Nén dữ liệu', 0),
(441, 111, 'TCP đáng tin cậy, UDP không đáng tin cậy', 1), (442, 111, 'TCP và UDP giống nhau', 0), (443, 111, 'TCP không đáng tin cậy', 0), (444, 111, 'UDP đáng tin cậy', 0),
(445, 112, 'HTTP', 1), (446, 112, 'HTTPS', 0), (447, 112, 'FTP', 0), (448, 112, 'SMTP', 0),
(449, 113, 'Cổng định danh dịch vụ', 1), (450, 113, 'Địa chỉ IP', 0), (451, 113, 'Tên miền', 0), (452, 113, 'Giao thức', 0),
(453, 114, 'DNS, DHCP', 1), (454, 114, 'HTTP, HTTPS', 0), (455, 114, 'FTP, SFTP', 0), (456, 114, 'SMTP, POP3', 0),
(457, 115, 'SYN, SYN-ACK, ACK', 1), (458, 115, 'ACK, SYN, SYN-ACK', 0), (459, 115, 'SYN, ACK, SYN-ACK', 0), (460, 115, 'ACK, ACK, ACK', 0),
(461, 116, 'Xác định phần mạng và phần host', 1), (462, 116, 'Xác định địa chỉ IP', 0), (463, 116, 'Xác định tên miền', 0), (464, 116, 'Xác định port', 0),
(465, 117, 'Chuyển đổi tên miền sang IP', 1), (466, 117, 'Chuyển đổi IP sang tên miền', 0), (467, 117, 'Mã hóa dữ liệu', 0), (468, 117, 'Nén dữ liệu', 0),
(469, 118, 'Chia mạng lớn thành mạng nhỏ', 1), (470, 118, 'Gộp mạng nhỏ thành mạng lớn', 0), (471, 118, 'Xóa mạng', 0), (472, 118, 'Sao chép mạng', 0),
(473, 119, 'Chuyển đổi tên miền sang IP', 1), (474, 119, 'Chuyển đổi IP sang tên miền', 0), (475, 119, 'Mã hóa dữ liệu', 0), (476, 119, 'Nén dữ liệu', 0),
(477, 120, 'Lớp A: 0-127, B: 128-191, C: 192-223', 1), (478, 120, 'Lớp A: 128-191, B: 192-223, C: 0-127', 0), (479, 120, 'Lớp A: 192-223, B: 0-127, C: 128-191', 0), (480, 120, 'Tất cả giống nhau', 0),
(481, 121, 'Tầng 3 (Network)', 1), (482, 121, 'Tầng 1 (Physical)', 0), (483, 121, 'Tầng 2 (Data Link)', 0), (484, 121, 'Tầng 4 (Transport)', 0),
(485, 122, 'Mạng LAN ảo', 1), (486, 122, 'Mạng WAN', 0), (487, 122, 'Mạng MAN', 0), (488, 122, 'Mạng PAN', 0),
(489, 123, 'Chuyển đổi địa chỉ IP nội bộ sang IP công cộng', 1), (490, 123, 'Chuyển đổi IP công cộng sang IP nội bộ', 0), (491, 123, 'Mã hóa dữ liệu', 0), (492, 123, 'Nén dữ liệu', 0),
(493, 124, 'Tầng 2 (Data Link)', 1), (494, 124, 'Tầng 1 (Physical)', 0), (495, 124, 'Tầng 3 (Network)', 0), (496, 124, 'Tầng 4 (Transport)', 0),
(497, 125, 'Khuếch đại và phát tín hiệu', 1), (498, 125, 'Định tuyến', 0), (499, 125, 'Lọc gói tin', 0), (500, 125, 'Mã hóa dữ liệu', 0),

-- Đáp án cho câu hỏi 126-150: CT106 - Hệ điều hành
(501, 126, 'Phần mềm quản lý tài nguyên máy tính', 1), (502, 126, 'Phần cứng máy tính', 0), (503, 126, 'Ứng dụng', 0), (504, 126, 'Trình duyệt', 0),
(505, 127, 'Quản lý tài nguyên và cung cấp giao diện', 1), (506, 127, 'Chỉ hiển thị giao diện', 0), (507, 127, 'Chỉ quản lý bộ nhớ', 0), (508, 127, 'Chỉ quản lý CPU', 0),
(509, 128, 'Windows, Linux, macOS, Unix', 1), (510, 128, 'Word, Excel, PowerPoint', 0), (511, 128, 'Chrome, Firefox, Edge', 0), (512, 128, 'Java, Python, C++', 0),
(513, 129, 'Quản lý và điều phối tài nguyên', 1), (514, 129, 'Chỉ hiển thị giao diện', 0), (515, 129, 'Chỉ chạy ứng dụng', 0), (516, 129, 'Chỉ lưu trữ dữ liệu', 0),
(517, 130, 'Kernel là lõi hệ thống, Shell là giao diện người dùng', 1), (518, 130, 'Kernel và Shell giống nhau', 0), (519, 130, 'Kernel là giao diện, Shell là lõi', 0), (520, 130, 'Không có sự khác biệt', 0),
(521, 131, 'Chương trình đang thực thi', 1), (522, 131, 'Chương trình trên đĩa', 0), (523, 131, 'Tệp tin', 0), (524, 131, 'Thư mục', 0),
(525, 132, 'Ready, Running, Waiting, Terminated', 1), (526, 132, 'Start, Stop', 0), (527, 132, 'On, Off', 0), (528, 132, 'Active, Inactive', 0),
(529, 133, 'Tiến trình là chương trình đang chạy, chương trình là tệp trên đĩa', 1), (530, 133, 'Tiến trình và chương trình giống nhau', 0), (531, 133, 'Tiến trình là tệp, chương trình đang chạy', 0), (532, 133, 'Không có sự khác biệt', 0),
(533, 134, 'Khối chứa thông tin về tiến trình', 1), (534, 134, 'Khối chứa dữ liệu', 0), (535, 134, 'Khối chứa mã nguồn', 0), (536, 134, 'Khối chứa tệp tin', 0),
(537, 135, 'FCFS, SJF, Round Robin, Priority', 1), (538, 135, 'FIFO, LIFO', 0), (539, 135, 'Stack, Queue', 0), (540, 135, 'Array, List', 0),
(541, 136, 'Cho phép chạy chương trình lớn hơn RAM', 1), (542, 136, 'Giảm dung lượng RAM', 0), (543, 136, 'Tăng tốc độ CPU', 0), (544, 136, 'Giảm dung lượng đĩa', 0),
(545, 137, 'Bộ nhớ truy cập ngẫu nhiên', 1), (546, 137, 'Bộ nhớ chỉ đọc', 0), (547, 137, 'Bộ nhớ đĩa', 0), (548, 137, 'Bộ nhớ cache', 0),
(549, 138, 'Phân bổ và quản lý bộ nhớ hiệu quả', 1), (550, 138, 'Xóa bộ nhớ', 0), (551, 138, 'Sao chép bộ nhớ', 0), (552, 138, 'Mã hóa bộ nhớ', 0),
(553, 139, 'Chia bộ nhớ thành các trang có kích thước cố định', 1), (554, 139, 'Chia bộ nhớ thành các đoạn', 0), (555, 139, 'Xóa bộ nhớ', 0), (556, 139, 'Sao chép bộ nhớ', 0),
(557, 140, 'Bộ nhớ vật lý là RAM thực, bộ nhớ ảo là không gian đĩa', 1), (558, 140, 'Bộ nhớ vật lý và ảo giống nhau', 0), (559, 140, 'Bộ nhớ vật lý là ảo, bộ nhớ ảo là thực', 0), (560, 140, 'Không có sự khác biệt', 0),
(561, 141, 'Hệ thống quản lý tệp tin và thư mục', 1), (562, 141, 'Hệ thống quản lý CPU', 0), (563, 141, 'Hệ thống quản lý mạng', 0), (564, 141, 'Hệ thống quản lý bộ nhớ', 0),
(565, 142, 'Tạo, đọc, ghi, xóa', 1), (566, 142, 'Chỉ đọc', 0), (567, 142, 'Chỉ ghi', 0), (568, 142, 'Chỉ xóa', 0),
(569, 143, 'Tổ chức và quản lý tệp tin', 1), (570, 143, 'Lưu trữ dữ liệu', 0), (571, 143, 'Xử lý dữ liệu', 0), (572, 143, 'Mã hóa dữ liệu', 0),
(573, 144, 'File chứa dữ liệu, Directory chứa file và thư mục con', 1), (574, 144, 'File và Directory giống nhau', 0), (575, 144, 'File chứa thư mục', 0), (576, 144, 'Directory chứa dữ liệu', 0),
(577, 145, 'Liên tục, liên kết, chỉ mục', 1), (578, 145, 'Chỉ liên tục', 0), (579, 145, 'Chỉ liên kết', 0), (580, 145, 'Chỉ chỉ mục', 0),
(581, 146, 'Khi các tiến trình chờ đợi lẫn nhau', 1), (582, 146, 'Khi tiến trình chạy nhanh', 0), (583, 146, 'Khi tiến trình kết thúc', 0), (584, 146, 'Khi tiến trình bắt đầu', 0),
(585, 147, 'Mutual exclusion, Hold and wait, No preemption, Circular wait', 1), (586, 147, 'Chỉ mutual exclusion', 0), (587, 147, 'Chỉ hold and wait', 0), (588, 147, 'Chỉ circular wait', 0),
(589, 148, 'Bảo vệ hệ thống khỏi truy cập trái phép', 1), (590, 148, 'Tăng tốc độ hệ thống', 0), (591, 148, 'Giảm dung lượng', 0), (592, 148, 'Tăng dung lượng', 0),
(593, 149, 'Phòng ngừa, tránh, phát hiện, phục hồi', 1), (594, 149, 'Chỉ phòng ngừa', 0), (595, 149, 'Chỉ tránh', 0), (596, 149, 'Chỉ phát hiện', 0),
(597, 150, 'Thuật toán kiểm tra trạng thái an toàn', 1), (598, 150, 'Thuật toán sắp xếp', 0), (599, 150, 'Thuật toán tìm kiếm', 0), (600, 150, 'Thuật toán mã hóa', 0),

-- Đáp án cho câu hỏi 151-175: CT107 - Phân tích hệ thống
(601, 151, 'Quá trình nghiên cứu và thiết kế hệ thống', 1), (602, 151, 'Quá trình lập trình', 0), (603, 151, 'Quá trình kiểm thử', 0), (604, 151, 'Quá trình triển khai', 0),
(605, 152, 'Hiểu và cải thiện hệ thống', 1), (606, 152, 'Chỉ lập trình', 0), (607, 152, 'Chỉ kiểm thử', 0), (608, 152, 'Chỉ triển khai', 0),
(609, 153, 'Phân tích, Thiết kế, Phát triển, Kiểm thử, Triển khai', 1), (610, 153, 'Chỉ phân tích', 0), (611, 153, 'Chỉ thiết kế', 0), (612, 153, 'Chỉ phát triển', 0),
(613, 154, 'Nghiên cứu và thiết kế hệ thống', 1), (614, 154, 'Chỉ lập trình', 0), (615, 154, 'Chỉ kiểm thử', 0), (616, 154, 'Chỉ triển khai', 0),
(617, 155, 'Phân tích xác định vấn đề, Thiết kế tạo giải pháp', 1), (618, 155, 'Phân tích và thiết kế giống nhau', 0), (619, 155, 'Phân tích tạo giải pháp', 0), (620, 155, 'Thiết kế xác định vấn đề', 0),
(621, 156, 'Yêu cầu chức năng và phi chức năng', 1), (622, 156, 'Chỉ yêu cầu chức năng', 0), (623, 156, 'Chỉ yêu cầu phi chức năng', 0), (624, 156, 'Không có yêu cầu', 0),
(625, 157, 'Yêu cầu về chức năng hệ thống phải thực hiện', 1), (626, 157, 'Yêu cầu về hiệu năng', 0), (627, 157, 'Yêu cầu về giao diện', 0), (628, 157, 'Yêu cầu về bảo mật', 0),
(629, 158, 'Yêu cầu về hiệu năng, bảo mật, giao diện', 1), (630, 158, 'Yêu cầu về chức năng', 0), (631, 158, 'Yêu cầu về dữ liệu', 0), (632, 158, 'Yêu cầu về mã nguồn', 0),
(633, 159, 'Phỏng vấn, Khảo sát, Quan sát, Prototype', 1), (634, 159, 'Chỉ phỏng vấn', 0), (635, 159, 'Chỉ khảo sát', 0), (636, 159, 'Chỉ quan sát', 0),
(637, 160, 'Yêu cầu người dùng là nhu cầu, yêu cầu hệ thống là đặc tả kỹ thuật', 1), (638, 160, 'Yêu cầu người dùng và hệ thống giống nhau', 0), (639, 160, 'Yêu cầu người dùng là kỹ thuật', 0), (640, 160, 'Yêu cầu hệ thống là nhu cầu', 0),
(641, 161, 'Unified Modeling Language', 1), (642, 161, 'Universal Modeling Language', 0), (643, 161, 'Unified Markup Language', 0), (644, 161, 'Universal Markup Language', 0),
(645, 162, 'Mô tả tương tác giữa người dùng và hệ thống', 1), (646, 162, 'Mô tả cấu trúc lớp', 0), (647, 162, 'Mô tả luồng dữ liệu', 0), (648, 162, 'Mô tả trình tự', 0),
(649, 163, 'Class Diagram, Sequence Diagram, Activity Diagram', 1), (650, 163, 'Chỉ Use Case', 0), (651, 163, 'Chỉ Class Diagram', 0), (652, 163, 'Chỉ Sequence Diagram', 0),
(653, 164, 'Mô tả cấu trúc lớp và mối quan hệ', 1), (654, 164, 'Mô tả tương tác', 0), (655, 164, 'Mô tả luồng', 0), (656, 164, 'Mô tả trình tự', 0),
(657, 165, 'Activity mô tả luồng công việc, Sequence mô tả tương tác theo thời gian', 1), (658, 165, 'Activity và Sequence giống nhau', 0), (659, 165, 'Activity mô tả tương tác', 0), (660, 165, 'Sequence mô tả luồng công việc', 0),
(661, 166, 'Tạo giải pháp kỹ thuật cho hệ thống', 1), (662, 166, 'Chỉ phân tích', 0), (663, 166, 'Chỉ phát triển', 0), (664, 166, 'Chỉ kiểm thử', 0),
(665, 167, 'Thiết kế kiến trúc, Thiết kế chi tiết, Thiết kế giao diện', 1), (666, 167, 'Chỉ thiết kế kiến trúc', 0), (667, 167, 'Chỉ thiết kế chi tiết', 0), (668, 167, 'Chỉ thiết kế giao diện', 0),
(669, 168, 'Xác định cấu trúc tổng thể hệ thống', 1), (670, 168, 'Xác định chi tiết', 0), (671, 168, 'Xác định giao diện', 0), (672, 168, 'Xác định dữ liệu', 0),
(673, 169, 'Logic là mô hình, Vật lý là triển khai thực tế', 1), (674, 169, 'Logic và Vật lý giống nhau', 0), (675, 169, 'Logic là triển khai', 0), (676, 169, 'Vật lý là mô hình', 0),
(677, 170, 'Modularity, Abstraction, Encapsulation, Reusability', 1), (678, 170, 'Chỉ Modularity', 0), (679, 170, 'Chỉ Abstraction', 0), (680, 170, 'Chỉ Encapsulation', 0),
(681, 171, '5-7 giai đoạn', 1), (682, 171, '2-3 giai đoạn', 0), (683, 171, '8-10 giai đoạn', 0), (684, 171, 'Chỉ 1 giai đoạn', 0),
(685, 172, 'Waterfall, Agile, Spiral, V-Model', 1), (686, 172, 'Chỉ Waterfall', 0), (687, 172, 'Chỉ Agile', 0), (688, 172, 'Chỉ Spiral', 0),
(689, 173, 'Đảm bảo dự án hoàn thành đúng thời gian và ngân sách', 1), (690, 173, 'Chỉ lập trình', 0), (691, 173, 'Chỉ kiểm thử', 0), (692, 173, 'Chỉ triển khai', 0),
(693, 174, 'Mô hình tuần tự từng giai đoạn', 1), (694, 174, 'Mô hình lặp', 0), (695, 174, 'Mô hình tăng trưởng', 0), (696, 174, 'Mô hình xoắn ốc', 0),
(697, 175, 'Agile linh hoạt và lặp, Waterfall tuần tự và cứng nhắc', 1), (698, 175, 'Agile và Waterfall giống nhau', 0), (699, 175, 'Agile tuần tự', 0), (700, 175, 'Waterfall linh hoạt', 0),

-- Đáp án cho câu hỏi 176-200: CT108 - Trí tuệ nhân tạo
(701, 176, 'Artificial Intelligence', 1), (702, 176, 'Automated Intelligence', 0), (703, 176, 'Advanced Intelligence', 0), (704, 176, 'Applied Intelligence', 0),
(705, 177, 'Máy học từ dữ liệu', 1), (706, 177, 'Lập trình thủ công', 0), (707, 177, 'Nhập dữ liệu thủ công', 0), (708, 177, 'Xóa dữ liệu', 0),
(709, 178, 'Nhận diện khuôn mặt, Xe tự lái, Chatbot', 1), (710, 178, 'Chỉ nhận diện khuôn mặt', 0), (711, 178, 'Chỉ xe tự lái', 0), (712, 178, 'Chỉ chatbot', 0),
(713, 179, 'Supervised, Unsupervised, Reinforcement', 1), (714, 179, 'Chỉ Supervised', 0), (715, 179, 'Chỉ Unsupervised', 0), (716, 179, 'Chỉ Reinforcement', 0),
(717, 180, 'AI là lĩnh vực rộng, ML là tập con của AI', 1), (718, 180, 'AI và ML giống nhau', 0), (719, 180, 'ML là lĩnh vực rộng', 0), (720, 180, 'AI là tập con của ML', 0),
(721, 181, 'Thuật toán tìm kiếm heuristic', 1), (722, 181, 'Thuật toán sắp xếp', 0), (723, 181, 'Thuật toán mã hóa', 0), (724, 181, 'Thuật toán nén', 0),
(725, 182, 'BFS, DFS, UCS', 1), (726, 182, 'A*, Best-First', 0), (727, 182, 'Greedy', 0), (728, 182, 'Hill Climbing', 0),
(729, 183, 'Tìm đường đi từ trạng thái ban đầu đến mục tiêu', 1), (730, 183, 'Sắp xếp dữ liệu', 0), (731, 183, 'Mã hóa dữ liệu', 0), (732, 183, 'Nén dữ liệu', 0),
(733, 184, 'Duyệt theo chiều rộng, mức độ ưu tiên', 1), (734, 184, 'Duyệt theo chiều sâu', 0), (735, 184, 'Duyệt ngẫu nhiên', 0), (736, 184, 'Duyệt ngược', 0),
(737, 185, 'BFS duyệt theo chiều rộng, DFS duyệt theo chiều sâu', 1), (738, 185, 'BFS và DFS giống nhau', 0), (739, 185, 'BFS duyệt sâu', 0), (740, 185, 'DFS duyệt rộng', 0),
(741, 186, 'Học từ dữ liệu không có nhãn', 1), (742, 186, 'Học từ dữ liệu có nhãn', 0), (743, 186, 'Học từ phần thưởng', 0), (744, 186, 'Học từ phản hồi', 0),
(745, 187, 'K-Means, Hierarchical Clustering', 1), (746, 187, 'Linear Regression', 0), (747, 187, 'Logistic Regression', 0), (748, 187, 'Neural Network', 0),
(749, 188, 'Học từ phần thưởng và phạt', 1), (750, 188, 'Học từ dữ liệu có nhãn', 0), (751, 188, 'Học từ dữ liệu không nhãn', 0), (752, 188, 'Học từ mô tả', 0),
(753, 189, 'Phân cụm dữ liệu thành k nhóm', 1), (754, 189, 'Phân loại dữ liệu', 0), (755, 189, 'Dự đoán giá trị', 0), (756, 189, 'Tìm kiếm dữ liệu', 0),
(757, 190, 'Clustering nhóm dữ liệu, Classification gán nhãn', 1), (758, 190, 'Clustering và Classification giống nhau', 0), (759, 190, 'Clustering gán nhãn', 0), (760, 190, 'Classification nhóm dữ liệu', 0),
(761, 191, 'Mạng mô phỏng nơ-ron thần kinh', 1), (762, 191, 'Mạng máy tính', 0), (763, 191, 'Mạng xã hội', 0), (764, 191, 'Mạng internet', 0),
(765, 192, 'Input, Weight, Bias, Activation function', 1), (766, 192, 'Chỉ Input', 0), (767, 192, 'Chỉ Weight', 0), (768, 192, 'Chỉ Bias', 0),
(769, 193, 'Học máy với nhiều lớp ẩn', 1), (770, 193, 'Học máy với một lớp', 0), (771, 193, 'Học máy không có lớp', 0), (772, 193, 'Học máy thủ công', 0),
(773, 194, 'Hàm phi tuyến tính để kích hoạt nơ-ron', 1), (774, 194, 'Hàm tuyến tính', 0), (775, 194, 'Hàm hằng số', 0), (776, 194, 'Hàm ngẫu nhiên', 0),
(777, 195, 'Feedforward truyền thẳng, Recurrent có vòng lặp', 1), (778, 195, 'Feedforward và Recurrent giống nhau', 0), (779, 195, 'Feedforward có vòng lặp', 0), (780, 195, 'Recurrent truyền thẳng', 0),
(781, 196, 'Deep Learning sử dụng nhiều lớp ẩn, ML có thể không', 1), (782, 196, 'Deep Learning và ML giống nhau', 0), (783, 196, 'ML luôn có nhiều lớp', 0), (784, 196, 'Deep Learning không có lớp', 0),
(785, 197, 'Dịch máy, Phân tích cảm xúc, Chatbot', 1), (786, 197, 'Chỉ dịch máy', 0), (787, 197, 'Chỉ phân tích cảm xúc', 0), (788, 197, 'Chỉ chatbot', 0),
(789, 198, 'Xử lý và hiểu hình ảnh', 1), (790, 198, 'Xử lý văn bản', 0), (791, 198, 'Xử lý âm thanh', 0), (792, 198, 'Xử lý video', 0),
(793, 199, 'Hệ thống đề xuất sản phẩm/dịch vụ', 1), (794, 199, 'Hệ thống tìm kiếm', 0), (795, 199, 'Hệ thống lưu trữ', 0), (796, 199, 'Hệ thống mã hóa', 0),
(797, 200, 'An toàn, Độ tin cậy, Xử lý tình huống phức tạp', 1), (798, 200, 'Chỉ an toàn', 0), (799, 200, 'Chỉ độ tin cậy', 0), (800, 200, 'Chỉ xử lý tình huống', 0),

-- Đáp án cho câu hỏi 201-225: CT109 - Lập trình web
(801, 201, 'HyperText Markup Language', 1), (802, 201, 'HyperText Markup Library', 0), (803, 201, 'HyperText Markup Link', 0), (804, 201, 'HyperText Markup List', 0),
(805, 202, 'Định dạng và tạo kiểu cho trang web', 1), (806, 202, 'Tạo cấu trúc trang web', 0), (807, 202, 'Xử lý logic', 0), (808, 202, 'Lưu trữ dữ liệu', 0),
(809, 203, '<div>, <p>, <h1>', 1), (810, 203, '<function>', 0), (811, 203, '<variable>', 0), (812, 203, '<class>', 0),
(813, 204, 'Inline, Internal, External', 1), (814, 204, 'Chỉ Inline', 0), (815, 204, 'Chỉ Internal', 0), (816, 204, 'Chỉ External', 0),
(817, 205, 'Block chiếm toàn bộ chiều rộng, Inline chỉ chiếm không gian cần thiết', 1), (818, 205, 'Block và Inline giống nhau', 0), (819, 205, 'Block chỉ chiếm không gian cần thiết', 0), (820, 205, 'Inline chiếm toàn bộ chiều rộng', 0),
(821, 206, 'Ngôn ngữ lập trình thông dịch', 1), (822, 206, 'Ngôn ngữ biên dịch', 0), (823, 206, 'Ngôn ngữ đánh dấu', 0), (824, 206, 'Ngôn ngữ kiểu dáng', 0),
(825, 207, 'Tạo tương tác động cho trang web', 1), (826, 207, 'Tạo cấu trúc trang', 0), (827, 207, 'Tạo kiểu dáng', 0), (828, 207, 'Lưu trữ dữ liệu', 0),
(829, 208, '<script> tag, External file, Inline', 1), (830, 208, 'Chỉ <script> tag', 0), (831, 208, 'Chỉ External file', 0), (832, 208, 'Chỉ Inline', 0),
(833, 209, 'Number, String, Boolean, Object, Array', 1), (834, 209, 'Chỉ Number', 0), (835, 209, 'Chỉ String', 0), (836, 209, 'Chỉ Boolean', 0),
(837, 210, 'var function-scoped, let/const block-scoped', 1), (838, 210, 'var, let, const giống nhau', 0), (839, 210, 'let/const function-scoped', 0), (840, 210, 'var block-scoped', 0),
(841, 211, 'Ngôn ngữ lập trình phía máy chủ', 1), (842, 211, 'Ngôn ngữ phía máy khách', 0), (843, 211, 'Ngôn ngữ đánh dấu', 0), (844, 211, 'Ngôn ngữ kiểu dáng', 0),
(845, 212, 'Node.js, Python, Java, Ruby', 1), (846, 212, 'HTML, CSS', 0), (847, 212, 'JavaScript (client-side)', 0), (848, 212, 'XML, JSON', 0),
(849, 213, 'Xử lý logic và dữ liệu phía server', 1), (850, 213, 'Hiển thị giao diện', 0), (851, 213, 'Tạo kiểu dáng', 0), (852, 213, 'Lưu trữ trên client', 0),
(853, 214, 'Client-side chạy trên trình duyệt, Server-side chạy trên server', 1), (854, 214, 'Client-side và Server-side giống nhau', 0), (855, 214, 'Client-side chạy trên server', 0), (856, 214, 'Server-side chạy trên trình duyệt', 0),
(857, 215, 'Giao diện lập trình cho phép ứng dụng giao tiếp', 1), (858, 215, 'Giao diện người dùng', 0), (859, 215, 'Giao thức mạng', 0), (860, 215, 'Cơ sở dữ liệu', 0),
(861, 216, 'React, Angular, Vue', 1), (862, 216, 'HTML, CSS', 0), (863, 216, 'PHP, Python', 0), (864, 216, 'MySQL, MongoDB', 0),
(865, 217, 'Tập hợp các hàm và lớp có sẵn', 1), (866, 217, 'Framework', 0), (867, 217, 'Ngôn ngữ lập trình', 0), (868, 217, 'Cơ sở dữ liệu', 0),
(869, 218, 'Tăng tốc độ phát triển và chuẩn hóa code', 1), (870, 218, 'Giảm tốc độ phát triển', 0), (871, 218, 'Làm phức tạp code', 0), (872, 218, 'Giảm tính linh hoạt', 0),
(873, 219, 'Framework cung cấp cấu trúc, Library cung cấp hàm', 1), (874, 219, 'Framework và Library giống nhau', 0), (875, 219, 'Framework cung cấp hàm', 0), (876, 219, 'Library cung cấp cấu trúc', 0),
(877, 220, 'Mô hình JavaScript đại diện cho DOM thực', 1), (878, 220, 'DOM thực tế', 0), (879, 220, 'HTML thực tế', 0), (880, 220, 'CSS thực tế', 0),
(881, 221, 'Tấn công chèn mã SQL độc hại', 1), (882, 221, 'Tấn công chèn HTML', 0), (883, 221, 'Tấn công chèn CSS', 0), (884, 221, 'Tấn công chèn JavaScript', 0),
(885, 222, 'XSS, CSRF, DDoS', 1), (886, 222, 'Chỉ XSS', 0), (887, 222, 'Chỉ CSRF', 0), (888, 222, 'Chỉ DDoS', 0),
(889, 223, 'Bảo vệ dữ liệu và người dùng', 1), (890, 223, 'Tăng tốc độ', 0), (891, 223, 'Giảm dung lượng', 0), (892, 223, 'Tăng dung lượng', 0),
(893, 224, 'Chèn mã JavaScript độc hại vào trang web', 1), (894, 224, 'Chèn SQL', 0), (895, 224, 'Chèn HTML', 0), (896, 224, 'Chèn CSS', 0),
(897, 225, 'Sử dụng CSRF token, Kiểm tra Referer', 1), (898, 225, 'Không có cách nào', 0), (899, 225, 'Chỉ sử dụng token', 0), (900, 225, 'Chỉ kiểm tra Referer', 0),

-- Đáp án cho câu hỏi 226-250: CT110 - An toàn thông tin
(901, 226, 'Bảo vệ thông tin khỏi truy cập trái phép', 1), (902, 226, 'Tăng tốc độ xử lý', 0), (903, 226, 'Giảm dung lượng', 0), (904, 226, 'Tăng dung lượng', 0),
(905, 227, 'Confidentiality, Integrity, Availability', 1), (906, 227, 'Chỉ Confidentiality', 0), (907, 227, 'Chỉ Integrity', 0), (908, 227, 'Chỉ Availability', 0),
(909, 228, 'Bảo vệ thông tin và hệ thống', 1), (910, 228, 'Tăng tốc độ', 0), (911, 228, 'Giảm dung lượng', 0), (912, 228, 'Tăng dung lượng', 0),
(913, 229, 'Đảm bảo thông tin chỉ người được phép mới truy cập', 1), (914, 229, 'Đảm bảo tính toàn vẹn', 0), (915, 229, 'Đảm bảo tính sẵn sàng', 0), (916, 229, 'Đảm bảo tính xác thực', 0),
(917, 230, 'Vulnerability là điểm yếu, Threat là mối đe dọa', 1), (918, 230, 'Vulnerability và Threat giống nhau', 0), (919, 230, 'Vulnerability là mối đe dọa', 0), (920, 230, 'Threat là điểm yếu', 0),
(921, 231, 'Bảo vệ dữ liệu khỏi truy cập trái phép', 1), (922, 231, 'Tăng tốc độ', 0), (923, 231, 'Giảm dung lượng', 0), (924, 231, 'Tăng dung lượng', 0),
(925, 232, 'AES, DES, 3DES', 1), (926, 232, 'RSA, ECC', 0), (927, 232, 'MD5, SHA', 0), (928, 232, 'Base64', 0),
(929, 233, 'Chuyển đổi dữ liệu mã hóa về dạng ban đầu', 1), (930, 233, 'Mã hóa dữ liệu', 0), (931, 233, 'Xóa dữ liệu', 0), (932, 233, 'Sao chép dữ liệu', 0),
(933, 234, 'Đối xứng dùng 1 khóa, Bất đối xứng dùng 2 khóa', 1), (934, 234, 'Đối xứng và bất đối xứng giống nhau', 0), (935, 234, 'Đối xứng dùng 2 khóa', 0), (936, 234, 'Bất đối xứng dùng 1 khóa', 0),
(937, 235, 'Public Key mã hóa, Private Key giải mã', 1), (938, 235, 'Public Key và Private Key giống nhau', 0), (939, 235, 'Public Key giải mã', 0), (940, 235, 'Private Key mã hóa', 0),
(941, 236, 'Bảo vệ mạng khỏi truy cập trái phép', 1), (942, 236, 'Tăng tốc độ mạng', 0), (943, 236, 'Giảm băng thông', 0), (944, 236, 'Tăng băng thông', 0),
(945, 237, 'Packet-filtering, Stateful, Application-layer', 1), (946, 237, 'Chỉ Packet-filtering', 0), (947, 237, 'Chỉ Stateful', 0), (948, 237, 'Chỉ Application-layer', 0),
(949, 238, 'Virtual Private Network', 1), (950, 238, 'Virtual Public Network', 0), (951, 238, 'Virtual Personal Network', 0), (952, 238, 'Virtual Protected Network', 0),
(953, 239, 'Hệ thống giám sát và phát hiện xâm nhập', 1), (954, 239, 'Hệ thống ngăn chặn', 0), (955, 239, 'Hệ thống mã hóa', 0), (956, 239, 'Hệ thống nén', 0),
(957, 240, 'IDS phát hiện, IPS ngăn chặn', 1), (958, 240, 'IDS và IPS giống nhau', 0), (959, 240, 'IDS ngăn chặn', 0), (960, 240, 'IPS phát hiện', 0),
(961, 241, 'Phần mềm độc hại tự nhân bản', 1), (962, 241, 'Phần mềm hợp pháp', 0), (963, 241, 'Phần mềm hệ thống', 0), (964, 241, 'Phần mềm ứng dụng', 0),
(965, 242, 'Worm, Trojan, Ransomware', 1), (966, 242, 'Chỉ Worm', 0), (967, 242, 'Chỉ Trojan', 0), (968, 242, 'Chỉ Ransomware', 0),
(969, 243, 'Lừa đảo để lấy thông tin nhạy cảm', 1), (970, 243, 'Tấn công từ chối dịch vụ', 0), (971, 243, 'Tấn công SQL injection', 0), (972, 243, 'Tấn công XSS', 0),
(973, 244, 'Virus cần file chủ, Worm tự lan truyền', 1), (974, 244, 'Virus và Worm giống nhau', 0), (975, 244, 'Virus tự lan truyền', 0), (976, 244, 'Worm cần file chủ', 0),
(977, 245, 'Phần mềm độc hại ngụy trang như phần mềm hợp pháp', 1), (978, 245, 'Phần mềm hợp pháp', 0), (979, 245, 'Phần mềm hệ thống', 0), (980, 245, 'Phần mềm ứng dụng', 0),
(981, 246, 'Khả năng xảy ra sự cố an toàn', 1), (982, 246, 'Sự cố đã xảy ra', 0), (983, 246, 'Giải pháp an toàn', 0), (984, 246, 'Công cụ an toàn', 0),
(985, 247, 'ISO 27001, NIST, PCI DSS', 1), (986, 247, 'Chỉ ISO 27001', 0), (987, 247, 'Chỉ NIST', 0), (988, 247, 'Chỉ PCI DSS', 0),
(989, 248, 'Xác định và ưu tiên rủi ro', 1), (990, 248, 'Tạo rủi ro', 0), (991, 248, 'Bỏ qua rủi ro', 0), (992, 248, 'Tăng rủi ro', 0),
(993, 249, 'Nhận diện, Đánh giá, Xử lý, Giám sát', 1), (994, 249, 'Chỉ nhận diện', 0), (995, 249, 'Chỉ đánh giá', 0), (996, 249, 'Chỉ xử lý', 0),
(997, 250, 'Đánh giá tính hiệu quả của biện pháp an toàn', 1), (998, 250, 'Tạo lỗ hổng', 0), (999, 250, 'Bỏ qua lỗ hổng', 0), (1000, 250, 'Tăng lỗ hổng', 0);

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
  `trangThai` int(11) NOT NULL DEFAULT 1 -- 0: Đề luyện tập (không lưu bài làm), 1: Đề chính thức
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `dekiemtra`
--

INSERT INTO `dekiemtra` (`maDe`, `tenDe`, `thoiGianBatDau`, `thoiGianKetThuc`, `thoiGianCanhBao`, `maMonHoc`, `soCauDe`, `soCauTrungBinh`, `soCauKho`, `trangThai`) VALUES
(1, 'Đề thi giữa kỳ - Lập trình C', '2025-10-21 08:00:00', '2025-10-21 10:00:00', '2025-10-21 09:45:00', 'CT101', 5, 10, 5, 1);

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
(1, 1);

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
('GV001', 'Thanh An', 'thanhan@university.edu.vn', 'Nam', '1980-01-01', 'giaovien.jpg', 2),
('GV002', 'Minh Tuấn', 'minhtuan@university.edu.vn', 'Nam', '1982-03-15', 'giaovien.jpg', 2),
('GV003', 'Lan Hương', 'lanhuong@university.edu.vn', 'Nữ', '1981-05-20', 'giaovien.jpg', 2),
('GV004', 'Đức Thành', 'ducthanh@university.edu.vn', 'Nam', '1979-07-10', 'giaovien.jpg', 2),
('GV005', 'Hồng Nhung', 'hongnhung@university.edu.vn', 'Nữ', '1983-09-25', 'giaovien.jpg', 2),
('GV006', 'Văn Đức', 'vanduc@university.edu.vn', 'Nam', '1980-11-30', 'giaovien.jpg', 2),
('GV007', 'Thùy Linh', 'thuylinh@university.edu.vn', 'Nữ', '1982-02-14', 'giaovien.jpg', 2),
('GV008', 'Quang Minh', 'quangminh@university.edu.vn', 'Nam', '1981-04-18', 'giaovien.jpg', 2),
('GV009', 'Thanh Hà', 'thanhha@university.edu.vn', 'Nữ', '1978-06-22', 'giaovien.jpg', 2),
('GV010', 'Bảo Anh', 'baoanh@university.edu.vn', 'Nam', '1984-08-08', 'giaovien.jpg', 2);

-- --------------------------------------------------------

--
-- Table structure for table ``
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
('CT110', 'An toàn thông tin', 3, 30, 15, 3);

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
(1, 'Nhóm 1', 'Lớp sáng thứ 2', 'CT101', 'GV001', 2025, 1, 35),
(2, 'Nhóm 2', 'Lớp chiều thứ 2', 'CT101', 'GV002', 2025, 1, 40),
(3, 'Nhóm 1', 'Phòng A201', 'CT102', 'GV003', 2025, 2, 38),
(4, 'Nhóm 2', 'Phòng A202', 'CT102', 'GV004', 2025, 2, 36),
(5, 'Nhóm 1', 'Lớp buổi sáng', 'CT103', 'GV005', 2025, 1, 42),
(6, 'Nhóm 2', 'Lớp buổi chiều', 'CT103', 'GV006', 2025, 1, 39),
(7, 'Nhóm 1', 'Phòng B101', 'CT104', 'GV002', 2025, 2, 37),
(8, 'Nhóm 2', NULL, 'CT104', 'GV007', 2025, 2, 41),
(9, 'Nhóm 1', 'Học online', 'CT105', 'GV008', 2025, 1, 34),
(10, 'Nhóm 2', 'Phòng C302', 'CT105', 'GV009', 2025, 1, 31),
(11, 'Nhóm 1', 'Phòng B203', 'CT106', 'GV003', 2025, 2, 39),
(12, 'Nhóm 2', 'Lớp chiều thứ 5', 'CT106', 'GV004', 2025, 2, 37),
(13, 'Nhóm 1', 'AI cơ bản', 'CT107', 'GV010', 2025, 1, 32),
(14, 'Nhóm 2', 'AI nâng cao', 'CT107', 'GV001', 2025, 1, 33),
(15, 'Nhóm 1', 'Thực hành UML', 'CT108', 'GV005', 2025, 2, 36),
(16, 'Nhóm 2', NULL, 'CT108', 'GV006', 2025, 2, 38),
(17, 'Nhóm 1', 'Lập trình web frontend', 'CT109', 'GV006', 2025, 1, 30),
(18, 'Nhóm 2', 'Backend PHP', 'CT109', 'GV007', 2025, 1, 28),
(19, 'Nhóm 1', 'An toàn hệ thống', 'CT110', 'GV005', 2025, 2, 29),
(20, 'Nhóm 2', 'Mã hóa dữ liệu', 'CT110', 'GV009', 2025, 2, 31);

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
(1, 'CT101', 'GV001'),
(2, 'CT101', 'GV002'),
(3, 'CT102', 'GV003'),
(4, 'CT102', 'GV004'),
(5, 'CT103', 'GV005'),
(6, 'CT103', 'GV006'),
(7, 'CT104', 'GV002'),
(8, 'CT104', 'GV007'),
(9, 'CT105', 'GV008'),
(10, 'CT105', 'GV009'),
(11, 'CT106', 'GV003'),
(12, 'CT106', 'GV004'),
(13, 'CT107', 'GV010'),
(14, 'CT107', 'GV001'),
(15, 'CT108', 'GV005'),
(16, 'CT108', 'GV006'),
(17, 'CT109', 'GV006'),
(18, 'CT109', 'GV007'),
(19, 'CT110', 'GV005'),
(20, 'CT110', 'GV009');

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
('3122410006', 'Mai Anh', 'domaianhh20@gmail.com', 'Nữ', '2000-01-01', 'default.jpg', 3),
('3122410351', 'Hoàng Quyên', 'hoangquyen@gmail.com', 'Nữ', '2004-01-01', 'default.jpg', 3);

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
('3122410006', 'maianh23', 1),
('3122410351', 'hoangquyen01', 1),
('GV001', 'gv001', 1),
('GV002', 'gv002', 1),
('GV003', 'gv003', 1),
('GV004', 'gv004', 1),
('GV005', 'gv005', 1),
('GV006', 'gv006', 1),
('GV007', 'gv007', 1),
('GV008', 'gv008', 1),
('GV009', 'gv009', 1),
('GV010', 'gv010', 1);

-- --------------------------------------------------------

--
-- Table structure for table `thongbao`
--

CREATE TABLE `thongbao` (
  `maThongBao` int(11) NOT NULL,
  `tenThongBao` varchar(255) NOT NULL,
  `noiDung` varchar(255) NOT NULL,
  `maMonHoc` varchar(11) NOT NULL,
  `thoiGian` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `thongbao`
--

INSERT INTO `thongbao` (`maThongBao`, `tenThongBao`, `noiDung`, `maMonHoc`, `thoiGian`) VALUES
(1, 'Kiểm tra', 'tiết tuần sau sẽ kiểm tra', 'CT101', '2025-11-11 23:06:40'),
(2, 'sadfd', 'fdgngsfbfsd', 'CT102', '2025-11-11 20:39:29'),
(3, 'adszcxv ', 'ưdsafgcvbm', 'CT104', '2025-11-11 20:39:20'),
(4, 'sdxcvb', 'ưefsdg', 'CT103', '2025-11-11 20:39:20'),
(5, 'sdxcvb', 'ưefsdg', 'CT103', '2025-11-11 20:39:20'),
(6, 'sdxcvb', 'ưefsdg', 'CT103', '2025-11-11 20:39:20'),
(7, 'sdxcvb', 'ưefsdg', 'CT103', '2025-11-11 20:39:20'),
(8, 'sdxcvb', 'ưefsdg', 'CT103', '2025-11-11 20:39:20');

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
  ADD PRIMARY KEY (`maThongBao`),
  ADD KEY `fk_thongbao_monhoc` (`maMonHoc`);


--
-- Indexes for table `thongbao-nhom`
--
ALTER TABLE `thongbao-nhom`
  ADD KEY `fk_thongbao-nhom_nhom` (`maNhom`),
  ADD KEY `fk_thongbao-nhom_thongbao` (`maThongBao`);

--
-- Constraints for dumped tables
--
ALTER TABLE `thongbao`
  MODIFY `maThongBao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

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
-- ALTER TABLE `taikhoan`
--   ADD CONSTRAINT `fk_sinhvien_taikhoan` FOREIGN KEY (`ma`) REFERENCES `sinhvien` (`maSinhVien`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `thongbao`
--
ALTER TABLE `thongbao`
  ADD CONSTRAINT `fk_thongbao_monhoc` FOREIGN KEY (`maMonHoc`) REFERENCES `monhoc` (`maMonHoc`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;
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


COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
