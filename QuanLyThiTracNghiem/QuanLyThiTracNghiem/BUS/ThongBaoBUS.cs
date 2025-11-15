using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mysqlx;

using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class ThongBaoBUS
    {
        private ThongBaoDAO thongBaoDAO = new ThongBaoDAO();
        private MonHocBUS monHocBUS = new MonHocBUS();
        private ArrayList listThongBao;

        public ThongBaoBUS()
        {
            DocListThongBao();
        }
        public void DocListThongBao()
        {
            this.listThongBao = thongBaoDAO.GetListThongBao();
        }
        public ArrayList GetListThongBao()
        {
            if (listThongBao == null)
            {
                DocListThongBao();
            }
            return listThongBao;
        }

        public bool ThemThongBao(string maThongBao, string tenThongBao, string noiDung, string maMonHoc)
        {
            try
            {
                if (tenThongBao == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên thông báo!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (noiDung == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống nội dung!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (maMonHoc == "")
                {
                    MyDialog dlg = new MyDialog("Chưa chọn môn học!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                DateTime thoiGian = DateTime.Now;

                if (thongBaoDAO.ThemThongBao(maThongBao, tenThongBao, noiDung, maMonHoc, thoiGian))
                {
                    MyDialog dlg = new MyDialog("Thêm thông báo thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Thêm thông báo thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            } catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Lỗi hệ thống!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool SuaThongBao(string maThongBao, string tenThongBao, string noiDung)
        {
            try
            {
                if (tenThongBao == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống tên thông báo!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                if (noiDung == "")
                {
                    MyDialog dlg = new MyDialog("Không được để trống nội dung!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
                DateTime thoiGian = DateTime.Now;
                int maTB = Convert.ToInt32(maThongBao);
                if (thongBaoDAO.SuaThongBao(maTB, tenThongBao, noiDung))
                {
                    MyDialog dlg = new MyDialog("Sửa thông báo thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return true;
                }
                else
                {
                    MyDialog dlg = new MyDialog("Sửa thông báo thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Lỗi hệ thống!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        }

        public bool XoaThongBao(string maThongBao)
        {
            if (maThongBao == "")
            {
                MyDialog dlg = new MyDialog("Chưa chọn thông báo để xóa!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
            int maTB = Convert.ToInt32(maThongBao);
            if (thongBaoDAO.XoaThongBao(maTB))
            {
                MyDialog dlg = new MyDialog("Xóa thông báo thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }
            else
            {
                MyDialog dlg = new MyDialog("Xóa thông báo thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
        } 

        public ArrayList GetListDSThongBao(string tenMonHoc)
        {
            ArrayList dstb = thongBaoDAO.GetListThongBao();
            ArrayList dsmh = monHocBUS.GetListDSMonHoc(tenMonHoc);           
            ArrayList dsTimKiem = new ArrayList();

            foreach (ThongBao tb in dstb)
            {
                foreach (MonHoc mh in dsmh)
                if (tb.maMonHoc == mh.maMonHoc)
                {
                    dsTimKiem.Add(tb);
                }
            }
            return dsTimKiem;
        }

        public int GetMaxMaThongBao()
        {
            return thongBaoDAO.GetMaxMaThongBao();
        }

        //LinQ Phương thức
        public ThongBao GetThongBaoTheoMa(string maThongBao)
        {
            try
            {
                DocListThongBao();
                int maTB = Convert.ToInt32(maThongBao);
                ArrayList dstb = thongBaoDAO.GetListThongBao();
                foreach (ThongBao tb in dstb)
                {
                    if (maTB == tb.maThongBao)
                    {
                        return tb;
                    }
                }
                MyDialog dlg = new MyDialog("Lỗi thông báo!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return null;
            } catch (Exception ex)
            {
                MyDialog dlg = new MyDialog("Lỗi định dạng!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return null;
            }
        }

        public ArrayList TimThongBaoTheoTuKhoa(string tuKhoa)
        {
            var ketQua = thongBaoDAO.GetListThongBao()
                         .Cast<ThongBao>()
                         .Where(tb => tb.tenThongBao.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)
                                   || tb.noiDung.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                         .ToList();

            return new ArrayList(ketQua);
        }
    }   
}
