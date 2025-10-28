using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class CauHoi_DeKiemTraBUS
    {
        private CauHoiDAO cauHoiDao=new CauHoiDAO();
        private DapAnDAO dapAnDao=new DapAnDAO();
        /*
         Phương thức xử lí thêm itemCauHoi vào Panel

         */
        public List<Panel_ItemCauHoi> Display_ItemCauHoi_InPanel(FlowLayoutPanel flowLayoutPanel_CauHoi, int maDe, int maBaiLam)
        {
            var dsItem = new List<Panel_ItemCauHoi>();
            var danhSachCauHoi = cauHoiDao.GetListCauHoiTheoMaDe(maDe);

            int sttCauHoi = 1;
            foreach (var cauHoi in danhSachCauHoi)
            {
                var dapAnList = dapAnDao.LayDSDapAnCoDaoCauTheoMaCauHoi(cauHoi.maCauHoi);
                var item = new Panel_ItemCauHoi(maBaiLam);
                item.KhoiTaoCauHoi(sttCauHoi++, cauHoi, dapAnList);
                dsItem.Add(item);
                flowLayoutPanel_CauHoi.Controls.Add(item);
            }

            return dsItem;
        }



    }
}
