using Google.Protobuf.WellKnownTypes;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Component_TTCaNhan : UserControl
    {
        private bool isEditing = false; // Cờ trạng thái xem có đang sửa hay không

        private string tenHinh = ""; // Biến lưu tên hình ảnh đại diện

        public Component_TTCaNhan()
        {
            InitializeComponent();
        }

        private void Component_TTCaNhan_Load(object sender, EventArgs e)
        {
            // Khi load thì khóa các ô nhập

            LoadThongTinSinhVien();
            KhoaThongTin();
        }

        TaiKhoanBUS tkBUS = new TaiKhoanBUS();

        private void LoadThongTinSinhVien()
        {
            SinhVienBUS svBUS = new SinhVienBUS();
            SinhVien sv = svBUS.GetSinhVienByID(UserSession.userId);
            

            if (sv != null)
            {
                textBoxMaTK.Text = sv.maSinhVien;
                textBoxHoTen.Text = sv.hoVaTen;
                textBoxEmail.Text = sv.email;
                textBoxNgaySinh.Text = sv.ngaySinh.ToShortDateString();
                comboBoxGioiTinh.Text = sv.gioiTinh;
                tenHinh = sv.anhDaiDien;
                textBoxMK.Text = UserSession.password; // Lấy mật khẩu từ session

                // ----- Load ảnh -----
                if (!string.IsNullOrEmpty(tenHinh))
                {
                    string duongDanAnh = Path.Combine(Application.StartupPath, "Image", tenHinh);
                    if (File.Exists(duongDanAnh))
                    {
                        // Giải phóng ảnh cũ trước khi load
                        if (pictureBoxChanDung.Image != null)
                        {
                            pictureBoxChanDung.Image.Dispose();
                            pictureBoxChanDung.Image = null;
                        }

                        using (FileStream fs = new FileStream(duongDanAnh, FileMode.Open, FileAccess.Read))
                        {
                            pictureBoxChanDung.Image = Image.FromStream(fs);
                        }
                    }
                    else
                    {
                        pictureBoxChanDung.Image = null;
                    }
                }
                else
                {
                    pictureBoxChanDung.Image = null;
                }
            }
        }


        // ----------------- KHÓA & MỞ KHÓA -----------------
        private void KhoaThongTin()
        {
            textBoxMaTK.Enabled = false;
            textBoxHoTen.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxNgaySinh.Enabled = false;
            textBoxMK.Enabled = false;
            comboBoxGioiTinh.Enabled = false;
            textBoxMK.PasswordChar = '*'; // Ẩn lại mật khẩu

            labelMChonAnh.Visible = false; // Ẩn nút chọn ảnh

        }

        private void MoKhoaThongTin()
        {
            textBoxHoTen.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxNgaySinh.Enabled = true;
            textBoxMK.Enabled = true;
            textBoxMK.PasswordChar = '\0'; // Hiện lại mật khẩu (bỏ ẩn)
            labelMChonAnh.Visible = true; // Hiện nút chọn ảnh
            comboBoxGioiTinh.Enabled = true;
        }



        // ----------------- NÚT THAY ĐỔI THÔNG TIN -----------------
        private void buttonThaydoithongtin_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // === Bật chế độ chỉnh sửa ===
                MoKhoaThongTin();
                buttonThaydoithongtin.Text = "Lưu thông tin";
                isEditing = true;
            }
            else
            {
                // === Khi nhấn "Lưu thông tin" ===
                SinhVienBUS svBUS = new SinhVienBUS();

                string maSinhVien = textBoxMaTK.Text.Trim();
                string hoVaTen = textBoxHoTen.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string gioiTinh = comboBoxGioiTinh.Text;
                //string gioiTinh = "Nam"; // Nếu bạn có combobox giới tính thì thay bằng comboBoxGioiTinh.Text
                DateTime ngaySinh;

                // Kiểm tra ngày sinh hợp lệ
                if (!DateTime.TryParse(textBoxNgaySinh.Text, out ngaySinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lưu ảnh đại diện
                string anhDaiDien = tenHinh;

                // Kiểm tra dữ liệu bắt buộc
                if (string.IsNullOrWhiteSpace(maSinhVien) || string.IsNullOrWhiteSpace(hoVaTen) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện lưu xuống DB
                bool kq = svBUS.SuaSinhVien(maSinhVien, hoVaTen, email, gioiTinh, ngaySinh, anhDaiDien);

                if (kq)
                {
                    if(tkBUS.SuaMKTaiKhoan(textBoxMaTK.Text, textBoxMK.Text))
                        {
                        // Cập nhật lại mật khẩu trong session
                        UserSession.password = textBoxMK.Text;
                        MessageBox.Show("Thông tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Cập nhật lại form
                        KhoaThongTin();
                        buttonThaydoithongtin.Text = "Thay đổi thông tin";
                        isEditing = false;
                    }

                    
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại. Vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ----------------- NÚT CHỌN ẢNH -----------------
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh đại diện";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNguon = openFileDialog.FileName;
                    string tenFileAnh = Path.GetFileName(fileNguon);

                    string thuMucDich = Path.Combine(Application.StartupPath, "Image");
                    if (!Directory.Exists(thuMucDich))
                        Directory.CreateDirectory(thuMucDich);

                    string duongDanDich = Path.Combine(thuMucDich, tenFileAnh);
                    File.Copy(fileNguon, duongDanDich, true); // cho phép ghi đè

                    // Giải phóng ảnh cũ
                    if (pictureBoxChanDung.Image != null)
                    {
                        pictureBoxChanDung.Image.Dispose();
                        pictureBoxChanDung.Image = null;
                    }

                    // Load ảnh mới
                    using (FileStream fs = new FileStream(duongDanDich, FileMode.Open, FileAccess.Read))
                    {
                        pictureBoxChanDung.Image = Image.FromStream(fs);
                    }

                    tenHinh = tenFileAnh;
                }
            }
        }


    }
}