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
    internal class NhomBUS
    {
        private NhomDAO NhomDAO = new NhomDAO();
        public NhomBUS() { }
        /*Lấy danh sách nhóm theo mã số sinh viên bỏ nó vô comboBox*/
        public void GetListNhomTheoMaSV(string maSV, ComboBox combo)
        {
            //Dọn sạch dữ liệu cũ 
            combo.DataSource = null;
            combo.Items.Clear();

            ArrayList dsn = NhomDAO.getListNhomTheoMaSinhVien(maSV);

            dsn.Insert(0, new Nhom(0,"Chọn nhóm học phần"));

            //Gán lại dữ liệu mới vào Combobox
            combo.DataSource = dsn;
            combo.DisplayMember = "tenNhom";
            combo.ValueMember = "maNhom";
            combo.SelectedIndex = 0;

        }
    }
}
