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
    internal class CTNhomQuyenBUS
    {
        private CTNhomQuyenDAO ctnqDAO = new CTNhomQuyenDAO();
        private ArrayList listCTNhomQuyen;

        public CTNhomQuyenBUS()
        {
            DocListCTNhomQuyen();
        }

        public void DocListCTNhomQuyen()
        {
            this.listCTNhomQuyen = ctnqDAO.GetListCTNhomQuyen();
        }

        public void DocListCTNhomQuyen(string quyen)
        {
            this.listCTNhomQuyen = ctnqDAO.GetListCTNhomQuyen(quyen);
        }

        public ArrayList GetListCTNhomQuyen()
        {
            DocListCTNhomQuyen();
            return listCTNhomQuyen;
        }

        public ArrayList GetListCTNhomQuyen(string quyen)
        {
            DocListCTNhomQuyen(quyen);
            return listCTNhomQuyen;
        }

        public bool ThemCTNhomQuyen(string quyen, int xem, int them, int capNhat, int xoa)
        {
            string[] arr = {"Người dùng","Học phần","Câu hỏi","Môn học","Chương","Phân công","Đề thi","Nhóm quyền","Thông báo"};
            int flag = 0;
            for (int i=0; i < arr.Length; i++)
            {
                if (!ctnqDAO.ThemCTNhomQuyen(quyen, arr[i], xem, them, capNhat, xoa))
                {                    
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                MyDialog dlg = new MyDialog("Thêm nhóm quyền thất bại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return false;
            }
            else
            {
                MyDialog dlg = new MyDialog("Thêm nhóm quyền thành công!", MyDialog.SUCCESS_DIALOG);
                dlg.ShowDialog();
                return true;
            }            
        }
    }
}
