using QuanLyThiTracNghiem.MyCustom;
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
        private ArrayList listMonHoc;

        /*
         Phương thúc lấy danh sách môn học để hiển thị lên Combobox
            Input: ComboBox comboBox, int MaMonHoc (mặc định = 0)=> 
                   Nếu là trang Sửa câu hỏi thf truyền vào dối số MaMonHoc
            Output: none
            Chức năng: Lấy danh sách Môn Học từ CSDL và hiển thị lên Combobox
            Created by: Đỗ Mai Anh
            Dùng trong trang : Component_CauHoi, Dialog_ThemCauHoi, Dialog_SuaCauHoi
         */
        public void LayListMonHoc(ComboBox combo, string MaMonHoc = "0")
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
        public void getListByAssignment(string maGV, ComboBox combo,string MaMonHoc = "0")
        {
            //Dọn sạch dữ liệu cũ 
            combo.DataSource = null;
            combo.Items.Clear();

            //Lấy Danh sách Môn Học từ CSDL
            ArrayList dsMonHoc = monHocDAO.GetListMonHocByMaGiaoVien(maGV);
            if (dsMonHoc == null) {
                //MyDialog dlg = new MyDialog("Không tìm thây môn được phân công!", MyDialog.WARNING_DIALOG);
                //dlg.ShowDialog();
                return;
            }

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
        // ==========================================
        // LẤY TẤT CẢ MÔN HỌC ĐỂ HIỂN THỊ TRONG COMBOBOX
        // ==========================================
        public List<MonHoc> GetAllMonHoc()
        {
            try
            {
                ArrayList dsMonHoc = monHocDAO.GetListMonHoc();
                List<MonHoc> result = new List<MonHoc>();

                foreach (MonHoc monHoc in dsMonHoc)
                {
                    result.Add(monHoc);
                }

                return result;
            }
            catch (Exception ex)
            {
                return new List<MonHoc>();
            }
        }

        public MonHocBUS()
        {
            DocListMonHoc();
        }
        public void DocListMonHoc()
        {
            this.listMonHoc = monHocDAO.GetListMonHoc();
        }

        public ArrayList GetListMonHoc()
        {
            if(listMonHoc == null)
            {
                DocListMonHoc();
            }
            return listMonHoc;
        }

        public bool ThemMonHoc(string tenMonHoc, string tinChi, string soTietLT, string soTietTH, string heSo)
        {
            try
            {
                if (tenMonHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên môn học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (tinChi == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tín chỉ!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (soTietLT == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống số tiết lý thuyết!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (soTietTH == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống số tiết thực hành!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (heSo == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống hệ số!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                int tc = Convert.ToInt32(tinChi);
                int stlt = Convert.ToInt32(soTietLT);
                int stth = Convert.ToInt32(soTietTH);
                int hs = Convert.ToInt32(heSo);
                int soThuTu = int.Parse(monHocDAO.GetMaxMaMonHoc().Substring(0));
                int ma = soThuTu + 1;
                string maMonHoc = "CT" + ma;
                if (monHocDAO.ThemMonHoc(maMonHoc, tenMonHoc, tc, stlt, stth, hs))
                {
                    MyDialog dlg = new MyDialog("Thêm môn thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Thêm môn thất bại!", MyDialog.ERROR_DIALOG);
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

        public bool XoaMonHoc(string maMonHoc)
        {
            if(maMonHoc == "")
            {
                MyDialog dlg = new MyDialog("Chưa chọn môn học để xóa!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
            if (monHocDAO.XoaMonHoc(maMonHoc))
            {
                MyDialog dlg = new MyDialog("Xóa môn học thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Xóa môn học thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool SuaMonHoc(string maMonHoc, string tenMonHoc, string tinChi, string soTietLT, string soTietTH, string heSo)
        {
            try
            {
                if (maMonHoc == "")
                {
                    MyDialog dlg = new MyDialog("Chưa chọn môn học để sửa!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (tenMonHoc == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên môn học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (tinChi == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tín chỉ!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (soTietLT == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống số tiết lý thuyết!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (soTietTH == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống số tiết thực hành!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (heSo == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống hệ số!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                int tc = Convert.ToInt32(tinChi);
                int stlt = Convert.ToInt32(soTietLT);
                int stth = Convert.ToInt32(soTietTH);
                int hs = Convert.ToInt32(heSo);
                if (monHocDAO.SuaMonHoc(maMonHoc, tenMonHoc, tc, stlt, stth, hs))
                {
                    MyDialog dlg = new MyDialog("Sửa môn thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Sửa môn thất bại!", MyDialog.ERROR_DIALOG);
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

        public MonHoc GetMonHocTheoTen(string tenMonHoc)
        {
            var dsMonHoc = monHocDAO.GetListMonHoc().Cast<MonHoc>();
            MonHoc monHoc = dsMonHoc
                .FirstOrDefault(mh => mh.tenMonHoc.Equals(tenMonHoc, StringComparison.OrdinalIgnoreCase));
            return monHoc;
        }

        //LinQ phương thức
        public ArrayList GetListDSMonHoc(string tenMonHoc)
        {
            var dsTimKiem = new ArrayList(
                monHocDAO.GetListMonHoc()
                .Cast<MonHoc>()
                .Where(mh => mh.tenMonHoc.IndexOf(tenMonHoc, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList()
            );

            return dsTimKiem;
        }
        public string GetMonHoc(string maMonHoc)
        {
            MonHoc mh = monHocDAO.GetMonHocByID(maMonHoc);
            return mh.tenMonHoc;
        }
    }
}
