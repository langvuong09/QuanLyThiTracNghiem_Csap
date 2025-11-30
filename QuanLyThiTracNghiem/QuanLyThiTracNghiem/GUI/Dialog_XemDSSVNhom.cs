using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_XemDSSVNhom : UserControl
    {
        private SinhVienBUS sinhVienBUS = new SinhVienBUS();
        private NhomThamGiaBUS nhomThamGiaBUS = new NhomThamGiaBUS();
        private string maNhomDuocChon { get; set; }
        public Dialog_XemDSSVNhom(string maNhom)
        {
            InitializeComponent();
            maNhomDuocChon = maNhom;
            AddEvents();
        }

        private void AddEvents()
        {
            LoadDataLenTableSinhVien();
            btnTimKiem.Click += btnTimKiem_Click;
            btnThem.Click += btnThemSV_Click;
            btnXuat.Click += btnXuat_Click;
        }

        private void LoadDataLenTableSinhVien()
        {
            dgvSinhVien.Rows.Clear();
            int maNhom = Convert.ToInt32(maNhomDuocChon);
            ArrayList dsThamGia = nhomThamGiaBUS.GetListNhomThamGiaOfMaNhom(maNhom);
            ArrayList dssv = sinhVienBUS.GetListSinhVien();
            int count = 1;
            foreach (SinhVien sv in dssv)
            {
                foreach (NhomThamGia ntg in dsThamGia)
                {
                    if (sv.maSinhVien == ntg.maSinhVien)
                    {
                        dgvSinhVien.Rows.Add(
                            count++,
                            sv.maSinhVien,
                            sv.hoVaTen,
                            sv.email,
                            sv.gioiTinh,
                            sv.ngaySinh.ToString("dd/MM/yyyy")
                            );
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKIem.Text.Trim().ToLower();
            if (tuKhoa == "")
            {
                LoadDataLenTableSinhVien();
                return;
            }

            dgvSinhVien.Rows.Clear();
            int maNhom = Convert.ToInt32(maNhomDuocChon);
            ArrayList dsThamGia = nhomThamGiaBUS.GetListNhomThamGiaOfMaNhom(maNhom);
            ArrayList dssv = sinhVienBUS.GetListSinhVien();
            int count = 1;
            foreach (SinhVien sv in dssv)
            {
                foreach (NhomThamGia ntg in dsThamGia)
                {
                    if (sv.maSinhVien == ntg.maSinhVien && sv.hoVaTen.ToLower().Contains(tuKhoa))
                    {
                        dgvSinhVien.Rows.Add(
                            count++,
                            sv.maSinhVien,
                            sv.hoVaTen,
                            sv.email,
                            sv.gioiTinh,
                            sv.ngaySinh.ToString("dd/MM/yyyy")
                            );
                    }
                }
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            if (maSV == "")
            {
                MyDialog dlg = new MyDialog("Chưa điền mã sinh viên!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }

            int maNhom = Convert.ToInt32(maNhomDuocChon);
            ArrayList dsThamGia = nhomThamGiaBUS.GetListNhomThamGiaOfMaNhom(maNhom);
            foreach(NhomThamGia ntg in dsThamGia)
            {
                if(ntg.maSinhVien == maSV)
                {
                    MyDialog dlg = new MyDialog("Sinh viên đã có trong nhóm!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
            }           

            ArrayList dssv = sinhVienBUS.GetListSinhVien();
            int flag = 0;
            foreach (SinhVien sv in dssv)
            {
                if (sv.maSinhVien == maSV)
                {
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
            {
                MyDialog dlg = new MyDialog("Mã sinh viên không tồn tại!", MyDialog.ERROR_DIALOG);
                dlg.ShowDialog();
                return;
            }

            foreach (SinhVien sv in dssv)
            {
                if(sv.maSinhVien == maSV)
                {
                    if(nhomThamGiaBUS.ThemNhomThamGia(maNhomDuocChon, maSV))
                    {
                        MyDialog dlg = new MyDialog("Thêm sinh viên vào nhóm thành công!", MyDialog.SUCCESS_DIALOG);
                        dlg.ShowDialog();
                        return;
                    }
                    else
                    {
                        MyDialog dlg = new MyDialog("Thêm sinh viên vào nhóm thất bại!", MyDialog.ERROR_DIALOG);
                        dlg.ShowDialog();
                        return;
                    }
                }
            }
            LoadDataLenTableSinhVien();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            // Hộp thoại lưu file
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Excel File|*.xlsx";
            saveDlg.Title = "Lưu danh sách sinh viên";
            saveDlg.FileName = "DanhSachSinhVien.xlsx";

            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new ClosedXML.Excel.XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("SinhVien");

                        // ======= GHI TIÊU ĐỀ CỘT =======
                        for (int i = 0; i < dgvSinhVien.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dgvSinhVien.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // ======= GHI DỮ LIỆU =======
                        for (int i = 0; i < dgvSinhVien.Rows.Count; i++)
                        {
                            for (int j = 0; j < dgvSinhVien.Columns.Count; j++)
                            {
                                object value = dgvSinhVien.Rows[i].Cells[j].Value;

                                // Nếu là ngày sinh → format dd/MM/yyyy để không xuất giờ
                                if (dgvSinhVien.Columns[j].Name == "colNgaySinh" && value != null)
                                {
                                    DateTime date;
                                    if (DateTime.TryParse(value.ToString(), out date))
                                        worksheet.Cell(i + 2, j + 1).Value = date.ToString("dd/MM/yyyy");
                                    else
                                        worksheet.Cell(i + 2, j + 1).Value = value?.ToString();
                                }
                                else
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = value?.ToString();
                                }
                            }
                        }

                        worksheet.Columns().AdjustToContents(); // Auto-size column

                        workbook.SaveAs(saveDlg.FileName);
                    }

                    MyDialog dlg = new MyDialog("Xuất file excel sinh viên thành công!", MyDialog.SUCCESS_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
                catch (Exception ex)
                {
                    MyDialog dlg = new MyDialog("Xuất file excel sinh viên thất bại!", MyDialog.ERROR_DIALOG);
                    dlg.ShowDialog();
                    return;
                }
            }
        }

    }
}
