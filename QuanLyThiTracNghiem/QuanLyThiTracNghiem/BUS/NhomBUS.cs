using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class NhomBUS
    {
        private NhomDAO nhomDAO = new NhomDAO();
        public NhomBUS() { }
        /*Lấy danh sách nhóm theo mã số sinh viên bỏ nó vô comboBox*/
        public void GetListNhomTheoMaSV(string maSV, ComboBox combo)
        {
            //Dọn sạch dữ liệu cũ 
            combo.DataSource = null;
            combo.Items.Clear();

            ArrayList dsn = nhomDAO.getListNhomTheoMaSinhVien(maSV);

            dsn.Insert(0, new Nhom(0,"Chọn nhóm học phần"));

            //Gán lại dữ liệu mới vào Combobox
            combo.DataSource = dsn;
            combo.DisplayMember = "tenNhom";
            combo.ValueMember = "maNhom";
            combo.SelectedIndex = 0;

            DocListNhom();

        }
        private ArrayList listNhom;
        private ArrayList listNhomTheoMonHoc;
        public void DocListNhom()
        {
            this.listNhom = nhomDAO.GetListNhom();
        }
        public ArrayList GetListNhom()
        {
            if(listNhom == null)
            {
                DocListNhom();
            }
            return listNhom;
        }

        public void DocListNhomTheoMonHoc(string maMonHoc)
        {
            this.listNhomTheoMonHoc = nhomDAO.GetListNhom(maMonHoc);
        }
        public ArrayList GetListNhom(string maMonHoc)
        {
            if (listNhomTheoMonHoc == null)
            {
                DocListNhomTheoMonHoc(maMonHoc);
            }
            return listNhomTheoMonHoc;
        }

        public ArrayList GetListNhom(string maNhom, string maMonHoc)
        {
            listNhomTheoMonHoc = null;
            if (listNhomTheoMonHoc == null)
            {
                DocListNhomTheoMonHoc(maMonHoc);
            }
            return listNhomTheoMonHoc;
        }

        public Nhom GetNhom(string tenNhom)
        {
            foreach (Nhom nhom in listNhom)
            {
                if(nhom.tenNhom == tenNhom)
                {
                    return nhom;
                }
            }
            return null;
        }

        public Nhom GetNhom(int maNhom)
        {
            DocListNhom();
            foreach (Nhom nhom in listNhom)
            {
                if (nhom.maNhom == maNhom)
                {
                    return nhom;
                }
            }
            return null;
        }

        /*
         * Phương thức lấy danh sách nhóm học phần theo mã môn học
         * Input: string maMonHoc - Mã môn học cần lấy danh sách nhóm
         * Output: List<Nhom> - Danh sách các nhóm học phần của môn học đó
         * Dùng trong: Dialog_TaoDeThi (để hiển thị danh sách nhóm khi chọn môn học)
         * Created by: Hoàng Quyên
         */
        public List<Nhom> GetListNhomByMonHoc(string maMonHoc)
        {
            try
            {
                ArrayList arrayList = nhomDAO.GetListNhom(maMonHoc);
                List<Nhom> result = new List<Nhom>();

                if (arrayList != null)
                {
                    foreach (Nhom item in arrayList)
                    {
                        result.Add(item);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy danh sách nhóm theo môn học: {ex.Message}");
                return new List<Nhom>();
            }
        }
    }
}
