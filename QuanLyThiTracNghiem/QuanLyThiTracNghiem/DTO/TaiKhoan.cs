
namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO
{
    public class TaiKhoan
    {
        public string userId { get; set; }
        public string password { get; set; }
        public int trangThai {  get; set; }

        public TaiKhoan() { }
        public TaiKhoan(string userId, string password, int trangThai)
        {
            this.userId = userId;
            this.password = password;
            this.trangThai = trangThai;
        }
    }
}
