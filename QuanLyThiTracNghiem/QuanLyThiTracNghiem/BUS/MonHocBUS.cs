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
    internal class MonHocBUS
    {
        //Môn Học Dao
        private MonHocDAO monHocDAO = new MonHocDAO();

        public MonHocBUS() { }

        /*
         Phương thúc lấy danh sách môn học để hiển thị lên Combobox
            Input: ComboBox comboBox, int MaMonHoc (mặc định = 0)=> 
                   Nếu là trang Sửa câu hỏi thf truyền vào dối số MaMonHoc
            Output: none
            Chức năng: Lấy danh sách Môn Học từ CSDL và hiển thị lên Combobox
            Created by: Đỗ Mai Anh
            Dùng trong trang : Component_CauHoi, Dialog_ThemCauHoi, Dialog_SuaCauHoi
         */
        public void LayListMonHoc(ComboBox combo, string MaMonHoc="0")
        {
            //Dọn sạch dữ liệu cũ 
            combo.DataSource = null;
            combo.Items.Clear();

            //Lấy Danh sách Môn Học từ CSDL
            ArrayList dsMonHoc = monHocDAO.GetListMonHoc();

            //Thêm Mục giả "Chọn Môn Học" vào đầu danh sách
            dsMonHoc.Insert(0, new MonHoc("0", "Chọn Môn Học", 3, 30, 15, 2));

            //Gán lại dữ liệu mới vào Combobox
            combo.DataSource = dsMonHoc;
            combo.DisplayMember = "tenMonHoc";
            combo.ValueMember = "maMonHoc";

            
            //Nếu là trang Sửa câu hỏi thì chọn Môn Học tương ứng với câu hỏi
            if (MaMonHoc != "0")
            {
                for (int i = 0; i < dsMonHoc.Count; i++)
                {
                    MonHoc mh = (MonHoc)dsMonHoc[i];
                    if (mh.maMonHoc == MaMonHoc.ToString())
                    {
                        combo.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                combo.SelectedIndex = 0;
            }

        }




    }
}
