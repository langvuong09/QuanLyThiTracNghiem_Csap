using System.Collections;
using MySql.Data.MySqlClient;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    internal class GiaoVienDAO
    {
        private readonly QuanLyThiContext db = new QuanLyThiContext();

        public List<GiaoVien> GetListGiaoVien()
        {
            return db.GiaoViens.ToList();
        }

        public bool ThemGiaoVien(GiaoVien gv)
        {
            try
            {
                db.GiaoViens.Add(gv);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool XoaGiaoVien(string maGiaoVien)
        {
            try
            {
                var gv = db.GiaoViens.Find(maGiaoVien);
                if (gv == null) return false;

                db.GiaoViens.Remove(gv);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool SuaGiaoVien(GiaoVien updated)
        {
            try
            {
                db.GiaoViens.Update(updated);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public GiaoVien GetGiaoVienByID(string id)
        {
            return db.GiaoViens.FirstOrDefault(g => g.maGiaoVien == id);
        }
    }
}
