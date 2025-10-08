using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class ChuongBUS
    {
        private ChuongDAO chuongDAO = new ChuongDAO();
        public ChuongBUS()
        {
        }

        /*
         Phương thức lấy danh sách chương theo môn học để hiển thị lên Combobox
            Input: ComboBox comboBox, String MaMonHoc 
            Output: none
            Chức năng: Lấy danh sách chương từ CSDL và hiển thị lên Combobox
            Created by: Đỗ Mai Anh
            Dùng trong trang : Component_CauHoi, Dialog_ThemCauHoi, Dialog_SuaCauHoi
         */
        public void LayListChuong(ComboBox combo, string MaMonHoc = "0",int maChuong=0)
        {
            //Dọn sạch dữ liệu cũ 
            combo.DataSource = null;
            combo.Items.Clear();

            ArrayList dsChuong =chuongDAO.GetListChuongOfMaMonHoc(MaMonHoc);
            //Thêm Mục giả "Chọn Chương" vào đầu danh sách
            dsChuong.Insert(0, new Chuong(0, MaMonHoc, "Chọn Chương"));
            //Gán lại dữ liệu mới vào Combobox
            combo.DataSource = dsChuong;
            combo.DisplayMember = "tenChuong";
            combo.ValueMember = "maChuong";
            combo.SelectedIndex = 0;

            //Nếu là trang Sửa câu hỏi thì chọn Chương tương ứng với câu hỏi
            if (maChuong != 0)
            {
                for (int i = 0; i < dsChuong.Count; i++)
                {
                    Chuong c = (Chuong)dsChuong[i];
                    if (c.maChuong == maChuong)
                    {
                        combo.SelectedIndex = i;
                        break;
                    }
                }
            }

        }
    }
}
