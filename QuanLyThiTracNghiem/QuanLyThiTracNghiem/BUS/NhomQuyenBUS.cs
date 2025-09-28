using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class NhomQuyenBUS
    {
        private NhomQuyenDAO nqDAO = new NhomQuyenDAO();
        private ArrayList listNhomQuyen;

        public NhomQuyenBUS()
        {
            DocListNhomQuyen();
        }

        public void DocListNhomQuyen()
        {
            this.listNhomQuyen = nqDAO.GetListNhomQuyen();
        }

        public ArrayList GetListNhomQuyen()
        {
            if(this.listNhomQuyen == null)
            {
                DocListNhomQuyen();
            }
            return listNhomQuyen;
        }
        public NhomQuyen? ThemQuyen(string tenQuyen)
        {
            NhomQuyen? kq = nqDAO.ThemQuyen(tenQuyen);
            if (kq != null)
            {
                return kq;
            }
            else return null;
        }
        public bool XoaNhomQuyen(int maNhomQuyen)
        {

            // quyền có đang được sử dụng không
            if (nqDAO.IsRoleInUse(maNhomQuyen))
            {
                MessageBox.Show("Không thể xóa quyền này vì đang được sử dụng!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Xóa chi tiết nhóm quyền trước
            bool ct = new CTNhomQuyenBUS().XoaCTNhomQuyen(maNhomQuyen);
            if (!ct)
            {
                MessageBox.Show("Có lỗi khi xóa phân quyền!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // tiến hành xóa nhóm quyền
            else
            {
                return nqDAO.XoaQuyen(maNhomQuyen);
            }
        }
        public NhomQuyen GetNhomQuyen(int maNhomQuyen)
        {
            return nqDAO.GetNhomQuyen(maNhomQuyen);
        }
        public bool CapNhatQuyen(int maNhomQuyen, string tenNhomQuyen)
        {
            return nqDAO.CapNhatQuyen(maNhomQuyen, tenNhomQuyen);
        }
        public NhomQuyen? FindByName(string tenNhomQuyen)
        {
            if (listNhomQuyen == null) DocListNhomQuyen();

            return listNhomQuyen
                .Cast<NhomQuyen>()
                .FirstOrDefault(nq => nq.tenQuyen == tenNhomQuyen);
        }

    }
}
