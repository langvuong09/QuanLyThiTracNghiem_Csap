using System;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class DeKTra_Mon_Nhom
    {
        public DeKiemTra? DeKiemTra { get; set; }  
        public string? MaMonHoc { get; set; }     
        public string? TenMonHoc { get; set; }
        public string? TenNhom { get; set; }
        public int MaNhom { get; set; }           

        public DeKTra_Mon_Nhom() { }

        public DeKTra_Mon_Nhom(DeKiemTra? deKiemTra, string? maMonHoc, string? tenMonHoc, string? tenNhom, int maNhom)
        {
            DeKiemTra = deKiemTra;
            MaMonHoc = maMonHoc;
            TenMonHoc = tenMonHoc;
            TenNhom = tenNhom;
            MaNhom = maNhom;
        }
    }
}
