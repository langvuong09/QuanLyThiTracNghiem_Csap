using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO
{
    public class QuanLyThiContext : DbContext
    {
        public DbSet<GiaoVien> GiaoViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "Server=localhost;Database=quanlythitracnghiem;User=qluser;Password=;",
                new MySqlServerVersion(new Version(8, 0, 23))
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiaoVien>().ToTable("giaovien");
            modelBuilder.Entity<GiaoVien>().HasKey(g => g.maGiaoVien);
        }
    }
}
