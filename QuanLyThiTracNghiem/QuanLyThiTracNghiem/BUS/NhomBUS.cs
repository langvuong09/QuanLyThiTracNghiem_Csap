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
        private GiaoVienBUS giaoVienBUS = new GiaoVienBUS();
        private MonHocBUS monHocBUS = new MonHocBUS();
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

        public Nhom GetNhomTheoMa(int maNhom)
        {            
            ArrayList listN = nhomDAO.GetListNhom();
            foreach (Nhom nhom in listN)
            {
                if (nhom.maNhom == maNhom)
                {
                    return nhom;
                }
            }
            return null;
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

        public bool ThemNhom(string tenNhom, string ghiChu, string monHoc, string maGiangVien, string namHoc, string hocKy)
        {
            try
            {
                if (tenNhom == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên nhóm!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (ghiChu == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống ghi chú!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (monHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống môn học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (maGiangVien == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống giảng viên!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (namHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống năm học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (hocKy == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống học kỳ!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }

                string maMonHoc = monHocBUS.GetMaMonHoc(monHoc).maMonHoc;
                int namH = Convert.ToInt32(namHoc);
                int hocK = Convert.ToInt32(hocKy);

                if(nhomDAO.ThemNhom(tenNhom,ghiChu,maMonHoc,maGiangVien, namH, hocK))
                {
                    MyDialog dlg = new MyDialog("Thêm nhóm thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Thêm nhóm thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            }catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Sai định dạng!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool SuaNhom(string maNhom, string tenNhom, string ghiChu, string monHoc, string maGiangVien, string namHoc, string hocKy)
        {
            try
            {
                if (tenNhom == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên nhóm!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (ghiChu == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống ghi chú!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (monHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống môn học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (namHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống năm học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (hocKy == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống học kỳ!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }

                int maN = Convert.ToInt32(maNhom);
                string maMonHoc = monHocBUS.GetMaMonHoc(monHoc).maMonHoc;
                int namH = Convert.ToInt32(namHoc);
                int hocK = Convert.ToInt32(hocKy);

                if (nhomDAO.SuaNhom(maN, tenNhom, ghiChu, maMonHoc, maGiangVien, namH, hocK))
                {
                    MyDialog dlg = new MyDialog("Sửa nhóm thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Sửa nhóm thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Sai định dạng!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool XoaNhom(string maNhom)
        {
            try
            {
                if (maNhom == "")
                {
                    MyDialog dlg = new MyDialog("Chưa chọn nhóm để xóa!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                int maN = Convert.ToInt32(maNhom);
                if (nhomDAO.XoaNhom(maN))
                {
                    MyDialog dlg = new MyDialog("Xóa nhóm thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Xóa nhóm thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            } catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Sai định dạng!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
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
