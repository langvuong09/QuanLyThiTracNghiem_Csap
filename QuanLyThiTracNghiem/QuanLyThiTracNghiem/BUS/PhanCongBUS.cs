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
    internal class PhanCongBUS
    {
        private PhanCongDAO pcDAO = new PhanCongDAO();
        private ArrayList listPhanCong;


        public PhanCongBUS()
        {
            DocListPhanCong();
        }

        public void DocListPhanCong()
        {
            this.listPhanCong = pcDAO.GetListPhanCong();
        }

        public ArrayList GetListPhanCong()
        {
            return pcDAO.GetListPhanCong();
        }

        public bool ThemPhanCong(int maPhanCong, string maMonHoc, string maGiaoVien)
        {
            if(pcDAO.Existed(maMonHoc, maGiaoVien)){
                MyDialog dlg = new MyDialog("Phân công đã tồn tại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
            if (pcDAO.ThemPhanCong(maPhanCong, maMonHoc, maGiaoVien))
            {
                MyDialog dlg = new MyDialog("Thêm phân công thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Thêm phân công thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool XoaPhanCong(int maPhanCong)
        {
            if (pcDAO.XoaPhanCong(maPhanCong))
            {
                MyDialog dlg = new MyDialog("Xóa phân công thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Xóa phân công thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }



        public ArrayList GetListPhanCongOfGiaoVien(string maGiaoVien)
        {
            if (string.IsNullOrEmpty(maGiaoVien))
                return null;

            return pcDAO.GetListPhanCongOfGiaoVien(maGiaoVien);
        }

        public List<PhanCong> GetAllPhanCong()
        {
            ArrayList arr = pcDAO.GetListPhanCong();
            List<PhanCong> list = arr.OfType<PhanCong>().ToList();

            return list;
        }

        public int LayMaPhanCongTiepTheo()
        {
            int maxId = pcDAO.GetMaxMaPhanCong();
            return maxId + 1;
        }

        public bool SuaPhanCong(int maPhanCong, string maMonHoc, string maGiaoVien)
        {
            if (pcDAO.SuaPhanCong(maPhanCong, maMonHoc, maGiaoVien))
            {
                MyDialog dlg = new MyDialog("Cập nhật thông tin thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Cập nhật thông tin thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }
    }
}
