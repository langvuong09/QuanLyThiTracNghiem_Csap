# ĐỒ ÁN C# WINFORM

ID máy chủ: 10.153.117.21

# 📝 Hệ thống Quản lý Thi Trắc Nghiệm

## 📘 Giới thiệu

Dự án xây dựng **hệ thống quản lý thi trắc nghiệm** hỗ trợ:

- Quản lý học sinh, giáo viên, môn thi, đề thi và kết quả.
- Tổ chức thi, giám sát, chấm điểm tự động.
- Quản lý thông tin và phân quyền người dùng.

## 🎯 Mục tiêu

- Tự động hóa quản lý thi cử: tạo đề, tổ chức thi, chấm điểm và báo cáo.
- Đảm bảo phân quyền rõ ràng giữa **Admin – Giáo viên – Học sinh**.
- Tạo môi trường thi trực tuyến tiện lợi, chính xác và minh bạch.

## 👥 Đối tượng sử dụng

- **Học sinh**: đăng nhập làm bài thi, xem kết quả, ôn luyện.
- **Giáo viên**: tạo đề thi, thêm câu hỏi, tổ chức và chấm điểm.
- **Admin**: quản lý tài khoản, phân quyền, giám sát toàn hệ thống.

## ⚙️ Chức năng chính

### 1. Quản lý tài khoản & phân quyền

- Đăng nhập hệ thống (Admin/Giáo viên/Học sinh).
- Quản lý thông tin tài khoản, trạng thái hoạt động.

### 2. Quản lý học sinh & giáo viên

- Lưu thông tin cá nhân, lớp học, email, ảnh đại diện.
- Gán môn học và đề thi cho giáo viên.

### 3. Quản lý môn thi & ngân hàng câu hỏi

- Tạo/sửa/xóa môn thi.
- Ngân hàng câu hỏi trắc nghiệm (nhiều lựa chọn).
- Gán câu hỏi vào đề thi.

### 4. Quản lý đề thi

- Tạo đề thi theo môn học, cấu hình số câu, thời gian làm bài.
- Tự động xáo trộn câu hỏi và đáp án.

### 5. Quản lý bài làm & chấm điểm

- Học sinh làm bài trực tuyến.
- Lưu chi tiết từng câu trả lời.
- Hệ thống tự động tính điểm và lưu kết quả.

### 6. Quản lý kết quả thi

- Xem kết quả thi theo học sinh, theo lớp, theo môn học.
- Xuất báo cáo kết quả để phân tích.

## 🗂️ Mối quan hệ dữ liệu

- 1 **Học sinh** → nhiều **Bài làm**.
- 1 **Giáo viên** → nhiều **Đề thi**.
- 1 **Môn thi** → nhiều **Câu hỏi** và **Đề thi**.
- 1 **Đề thi** → nhiều **Câu hỏi**.
- 1 **Bài làm** → nhiều **Câu trả lời**.

## 📊 Mô hình CSDL

## 👨‍👩‍👧‍👦 Thành viên nhóm

<div align="center">

| Họ và tên                 | Vai trò     |
| ------------------------- | ----------- |
| <b>Đỗ Mai Anh</b>         | Nhóm trưởng |
| <b>Cao Tiến Cường</b>     | Thành viên  |
| <b>Nguyễn Hoàng Quyên</b> | Thành viên  |
| <b>Trần Yến Phượng</b>    | Thành viên  |
| <b>Nguyễn Phương Anh</b>  | Thành viên  |
| <b>Trần Tấn Đạt</b>       | Thành viên  |

</div>

# 💻 Công nghệ sử dụng

- **Ngôn ngữ lập trình**: C# (.NET WinForms)
- **Cơ sở dữ liệu**: MySQL (chạy qua XAMPP)
- **IDE**: Visual Studio 2022
- **Kiến trúc**: WinForms + ADO.NET (MySQL Connector)

---

# 🚀 Cách cài đặt & chạy dự án

1. **Clone repo**

```bash
git clone https://github.com/langvuong09/QuanLyThiTracNghiem_Csap.git
```

2. **Cài đặt XAMPP**

Tải và cài đặt XAMPP.
Khởi động Apache và MySQL trong XAMPP Control Panel.

3. **Cấu hình database**

- Import file .sql từ thư mục dự án.
