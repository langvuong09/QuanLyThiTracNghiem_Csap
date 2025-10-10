using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CauHoiBUS
    {
        private CauHoiDAO CauHoiDAO = new CauHoiDAO();
        public CauHoiBUS()
        {
        }

        /*
         Phương thưc Lấy Danh sách Câu hỏi để hiển thị lên DataGridView <Phân trang>
            Input: dataGridView ,curentPage, pageSize, maMonHoc, maChuong, doKho 
                   <3 cái đầu là bắt buộc phải có , 
                   3 biến sau có thể đề mặc định>
            Output: none
            Created by: Đỗ Mai Anh
            Dùng trong : Component_CauHoi
         
         */

        public int LayDSCauHoi_PhanTrang(
             DataGridView dataGridView,
             int currentPage,
             int pageSize,
             string maMonHoc = "0",
             int maChuong = 0,
             string doKho = "0")
        {
            try
            {
                var result = CauHoiDAO.GetListCauHoiPhanTrang(currentPage, pageSize, maMonHoc, maChuong, doKho);

                // Đảm bảo DataGridView có cột
                if (dataGridView.Columns.Count == 0)
                {
                    Console.WriteLine("⚠ DataGridView chưa có cột — kiểm tra lại quá trình khởi tạo.");
                    return 0;
                }

                // Xóa dữ liệu cũ
                dataGridView.Rows.Clear();

                // Thêm dữ liệu mới
                foreach (var item in result.Data)
                {
                    dataGridView.Rows.Add(
                        item.maCauHoi,
                        item.noiDungCauHoi,
                        item.maMonHoc,
                        item.maChuong,
                        item.doKho,
                        item.noiDungCauHoi
                    );
                }

                return result.TotalPages;
            }
            catch (Exception ex)
            {
                Console.WriteLine("CauHoiBUS => Lỗi khi lấy danh sách câu hỏi: " + ex.Message);
                return 0;
            }
        }

        /*
             Phương thức tìm kiếm theo Mã Câu Hỏi hoặc Nội Dung Câu Hỏi
                Input: dataGridView
                Output: none
                Created by: Đỗ Mai Anh
                Dùng trong : Component_CauHoi
         */
        public void TimKiemCauHoi(DataGridView dataGridView, string noiDungTimKiem)
        {
            if (noiDungTimKiem == "")
            {
                MyDialog dialog = new MyDialog("Vui lòng nhập từ khóa để tìm kiếm.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Nếu là số thì tìm theo mã câu hỏi
            if (int.TryParse(noiDungTimKiem, out int maCauHoi))
            {
                var cauHoi = CauHoiDAO.GetListCauHoiById(maCauHoi);
                if (cauHoi != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Rows.Add(
                        cauHoi.maCauHoi,
                        cauHoi.noiDungCauHoi,
                        cauHoi.maMonHoc,
                        cauHoi.maChuong,
                        cauHoi.doKho,
                        cauHoi.noiDungCauHoi
                    );
                }
                else
                {
                    MyDialog dialog = new MyDialog("Không tìm thấy câu hỏi.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                }
            }
            else 
            {
                var cauHoi = CauHoiDAO.TimKiemCauHoiTheoNoiDung(noiDungTimKiem);
                if (cauHoi != null)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Rows.Add(
                        cauHoi.maCauHoi,
                        cauHoi.noiDungCauHoi,
                        cauHoi.maMonHoc,
                        cauHoi.maChuong,
                        cauHoi.doKho,
                        cauHoi.noiDungCauHoi
                    );
                }
                else
                {
                    MyDialog dialog = new MyDialog("Không tìm thấy câu hỏi.", MyDialog.WARNING_DIALOG);
                    dialog.ShowDialog();
                }

            }
        }

        /*
         Phương thức lấy câu hỏi theo mã câu hỏi và điền nó vào các component tương ứng
            Input:textBox_MaCauHoi,textBox_NDCauHoi
            Output: CauHoi
            Created by: Đỗ Mai Anh
            Dùng trong : Dialog_SuaCauHoi

         */
        public CauHoi LayCauHoiTheoMa(int maCauHoi, TextBox textBox_MaCauHoi, TextBox textBox_NDCauHoi)
        {
            CauHoi cauHoi = null;
            try
            {
                cauHoi = CauHoiDAO.GetListCauHoiById(maCauHoi);
                textBox_MaCauHoi.Text=cauHoi.maCauHoi.ToString();
                textBox_NDCauHoi.Text = cauHoi.noiDungCauHoi;
            }
            catch (Exception ex)
            {
                Console.WriteLine("BUS = >Lối khi tải câu hỏi cho Dialog_SuaCauHoi",ex.Message);
            }
            return cauHoi;
        }

        /*
         Phương thức sửa câu hỏi theo mã câu hỏi 
            Input:textBox_MaCauHoi,textBox_NDCauHoi, comboBox_MonHoc, comboBox_Chuong, comboBox_DoKho
            Output: none
            Created by: Đỗ Mai Anh
            Dùng trong : Dialog_SuaCauHoi
         */
        public void SuaCauHoi(
            TextBox textBox_MaCauHoi,
            TextBox textBox_NDCauHoi,
            ComboBox comboBox_MonHoc,
            ComboBox comboBox_Chuong,
            ComboBox comboBox_DoKho)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            int maCauHoi = int.Parse(textBox_MaCauHoi.Text);
            string noiDungCauHoi = textBox_NDCauHoi.Text;
            string maMonHoc = ((MonHoc)comboBox_MonHoc.SelectedItem).maMonHoc;
            int maChuong = ((Chuong)comboBox_Chuong.SelectedItem).maChuong;
            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            string doKho = selectedPair.Value;



            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(noiDungCauHoi))
            {
                MyDialog dialog = new MyDialog("Nội dung câu hỏi không được để trống.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Không được chọn "Chọn Môn Học"
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Môn Học.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Không được chọn "Chọn Chương"
            if (comboBox_Chuong.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Chương.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Không được chọn "Chọn Độ Khó"
            if (comboBox_DoKho.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Độ Khó.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            // Gọi phương thức trong DAO để cập nhật câu hỏi
            bool result = CauHoiDAO.SuaCauHoi(maCauHoi,maMonHoc,maChuong,doKho,noiDungCauHoi);
            if (result)
            {
                MyDialog dialog = new MyDialog("Sửa câu hỏi thành công.", MyDialog.SUCCESS_DIALOG);
                dialog.ShowDialog();
            }
            else
            {
                MyDialog dialog = new MyDialog("Sửa câu hỏi thất bại.", MyDialog.ERROR_DIALOG);
                dialog.ShowDialog();
            }
        }

        /*
         Phương thức tạo ra mac câu hỏi mới và gán nó vào textBox_MaCauHoi
            Input:textBox_MaCauHoi
            Output: none
            Created by: Đỗ Mai Anh
            Dùng trong : Dialog_SuaCauHoi
         */
        public void TaoMaCauHoiMoi(TextBox textBox_MaCauHoi)
        {
            int maCauHoiMoi = CauHoiDAO.maxMaCauHoi() + 1;
            textBox_MaCauHoi.Text = maCauHoiMoi.ToString();
        }

        /*
             Phương thức thêm câu hỏi mới vào database
                Input:  comboBox_DoKho, comboBox_Chuong, comboBox_MonHoc, textBox_NDCauHoi, textBox_MaCauHoi
                Output: bool
                Created by: Đỗ Mai Anh
                Dùng trong : Panel_ThemCauHoiThuCong
         */
        public bool ThemCauHoiMoi(
            ComboBox comboBox_DoKho,
            ComboBox comboBox_Chuong,
            ComboBox comboBox_MonHoc,
            TextBox textBox_NDCauHoi,
            TextBox textBox_MaCauHoi)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string noiDungCauHoi = textBox_NDCauHoi.Text;
            string maMonHoc = ((MonHoc)comboBox_MonHoc.SelectedItem).maMonHoc;
            int maChuong = ((Chuong)comboBox_Chuong.SelectedItem).maChuong;
            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            string doKho = selectedPair.Value;
            int maCauHoi = int.Parse(textBox_MaCauHoi.Text);

            Console.WriteLine($"DEBUG: ThemCauHoiMoi - maCauHoi={maCauHoi}, maMonHoc={maMonHoc}, maChuong={maChuong}, doKho={doKho}, noiDungCauHoi={noiDungCauHoi} \n");
            // Kiểm tra dữ liệu hợp lệ
            if (string.IsNullOrWhiteSpace(noiDungCauHoi))
            {
                MyDialog dialog = new MyDialog("Nội dung câu hỏi không được để trống.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            //Không được chọn "Chọn Môn Học"
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Môn Học.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            //Không được chọn "Chọn Chương"
            if (comboBox_Chuong.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Chương.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            //Không được chọn "Chọn Độ Khó"
            if (comboBox_DoKho.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Độ Khó.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            // Gọi phương thức trong DAO để thêm câu hỏi
            bool result = CauHoiDAO.ThemCauHoi(maCauHoi, maMonHoc, maChuong, doKho, noiDungCauHoi);
            if (result)
            {
                MyDialog dialog = new MyDialog("Thêm câu hỏi thành công.", MyDialog.SUCCESS_DIALOG);
                dialog.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dialog = new MyDialog("Thêm câu hỏi thất bại.", MyDialog.ERROR_DIALOG);
                dialog.ShowDialog();
                return false;
            }
            return false;
        }

        /*
             Phương thức xóa câu hỏi theo mã câu hỏi
                Input: maCauHoi
                Output: void
                Created by: Đỗ Mai Anh
                Dùng trong : Panel_ThemCauHoiThuCong
         */
        public void XoaCauHoi(int maCauHoi)
        {
            bool soLuongCauHoiBiXoa = CauHoiDAO.XoaCauHoi(maCauHoi);
            if (soLuongCauHoiBiXoa ==true)
            {
                Console.WriteLine("Xóa câu hỏi thành công");
            }
            else
            {
                Console.WriteLine("Xóa câu hỏi thất bại");
            }
        }



    }
}
