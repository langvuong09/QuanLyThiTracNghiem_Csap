using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using ExcelFont = DocumentFormat.OpenXml.Spreadsheet.Font;
using ExcelColor = DocumentFormat.OpenXml.Spreadsheet.Color;

/*
 * File: XemChiTietDeThi.cs
 * Mô tả: UserControl để xem chi tiết đề thi và danh sách bài làm
 * Chức năng:
 *   - Hiển thị danh sách bài làm của đề thi
 *   - Tìm kiếm và lọc bài làm theo từ khóa
 *   - Xem chi tiết bài làm của từng sinh viên
 *   - Xuất danh sách bài làm ra file Excel
 * Dùng trong: Component_DeKiemTra
 */

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class XemChiTietDeThi : UserControl
    {
        private BaiLamBUS baiLamBUS = new BaiLamBUS();
        private ChiTietBaiLamBUS chiTietBaiLamBUS = new ChiTietBaiLamBUS();
        private int currentMaDe = 0;
        private List<Dictionary<string, object>> danhSachBaiLam = new List<Dictionary<string, object>>();
        private List<Dictionary<string, object>> danhSachBaiLamHienTai = new List<Dictionary<string, object>>();

        public XemChiTietDeThi()
        {
            InitializeComponent();
            SetupDataGridView();
            InitializeData();
        }

        /// <summary>
        /// Load dữ liệu bài làm theo mã đề thi
        /// </summary>
        /// <param name="maDe">Mã đề thi</param>
        public void LoadDataByMaDe(int maDe)
        {
            currentMaDe = maDe;
            LoadBaiLamData();
        }

        /// <summary>
        /// Thiết lập màu sắc, font và kích thước cho DataGridView
        /// </summary>
        private void SetupDataGridView()
        {
            try
            {
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(126, 164, 241);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
                
                ColMSSV.Width = 150;
                ColTen.Width = 200;
                ColDiem.Width = 100;
                ColTimeVaoThi.Width = 200;
                ColTimeNopBai.Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thiết lập DataGridView: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Khởi tạo dữ liệu cho DataGridView
        /// </summary>
        private void InitializeData()
        {
            try
            {
                if (currentMaDe > 0)
                {
                    LoadBaiLamData();
                }
                else
                {
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load danh sách bài làm từ database theo mã đề thi
        /// </summary>
        private void LoadBaiLamData()
        {
            try
            {
                if (currentMaDe == 0)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }

                danhSachBaiLam = baiLamBUS.GetBaiLamByMaDeWithSinhVien(currentMaDe);
                
                if (danhSachBaiLam == null || danhSachBaiLam.Count == 0)
                {
                    dataGridView1.Rows.Clear();
                    danhSachBaiLamHienTai = new List<Dictionary<string, object>>();
                    return;
                }

                danhSachBaiLamHienTai = danhSachBaiLam;
                DisplayBaiLamData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu bài làm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Rows.Clear();
            }
        }

        /// <summary>
        /// Hiển thị danh sách bài làm lên DataGridView
        /// </summary>
        private void DisplayBaiLamData()
        {
            try
            {
                dataGridView1.Rows.Clear();
                
                foreach (var baiLam in danhSachBaiLamHienTai)
                {
                    string mssv = baiLam["maSinhVien"].ToString();
                    string tenSV = baiLam["hoVaTen"].ToString();
                    string diem = baiLam["tongDiem"].ToString();
                    int maBaiLam = Convert.ToInt32(baiLam["maBaiLam"]);
                    
                    string timeVaoThi = "N/A";
                    string timeNopBai = "N/A";
                    
                    if (baiLam.ContainsKey("thoiGianBatDau") && baiLam["thoiGianBatDau"] != null)
                    {
                        DateTime thoiGianBatDau = (DateTime)baiLam["thoiGianBatDau"];
                        timeVaoThi = thoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    
                    if (baiLam.ContainsKey("thoiGianNopBai") && baiLam["thoiGianNopBai"] != null)
                    {
                        DateTime thoiGianNopBai = (DateTime)baiLam["thoiGianNopBai"];
                        timeNopBai = thoiGianNopBai.ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    
                    int rowIndex = dataGridView1.Rows.Add(mssv, tenSV, diem, timeVaoThi, timeNopBai, "Xem");
                    dataGridView1.Rows[rowIndex].Tag = maBaiLam;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn tất cả trong comboBox
        /// Áp dụng bộ lọc theo từ khóa tìm kiếm
        /// </summary>
        private void comboBoxTatCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi chọn trạng thái nộp bài trong comboBox
        /// Áp dụng bộ lọc theo từ khóa tìm kiếm
        /// </summary>
        private void comboBoxTrangThaiNop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhập từ khóa tìm kiếm trong textBox
        /// Áp dụng bộ lọc theo từ khóa tìm kiếm
        /// </summary>
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Áp dụng bộ lọc và tìm kiếm cho danh sách bài làm
        /// </summary>
        private void ApplyFilters()
        {
            try
            {
                if (danhSachBaiLam == null || danhSachBaiLam.Count == 0)
                {
                    dataGridView1.Rows.Clear();
                    return;
                }

                string searchKeyword = textBoxTimKiem.Text.Trim().ToLower();
                var filteredList = danhSachBaiLam.Where(b => 
                    string.IsNullOrEmpty(searchKeyword) ||
                    b["maSinhVien"].ToString().ToLower().Contains(searchKeyword) ||
                    b["hoVaTen"].ToString().ToLower().Contains(searchKeyword)
                ).ToList();

                danhSachBaiLamHienTai = filteredList;
                DisplayBaiLamData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi áp dụng bộ lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện click nút xuất Excel
        /// Hiển thị dialog chọn nơi lưu file và xuất danh sách bài làm ra file Excel
        /// </summary>
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (danhSachBaiLamHienTai == null || danhSachBaiLamHienTai.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                saveFileDialog.FileName = $"DanhSachBaiLam_DeThi_{currentMaDe}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    ExportToExcel(filePath);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất danh sách bài làm ra file Excel
        /// </summary>
        /// <param name="filePath">Đường dẫn file Excel</param>
        private void ExportToExcel(string filePath)
        {
            try
            {
                if (!filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    filePath += ".xlsx";
                }

                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Danh sách bài làm" };
                    sheets.Append(sheet);

                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    stylesPart.Stylesheet = CreateStylesheet();
                    stylesPart.Stylesheet.Save();

                    Row headerRow = new Row();
                    headerRow.Append(CreateCell("MSSV", CellValues.String, 1));
                    headerRow.Append(CreateCell("Tên Sinh Viên", CellValues.String, 1));
                    headerRow.Append(CreateCell("Điểm", CellValues.String, 1));
                    headerRow.Append(CreateCell("Thời Gian Vào Thi", CellValues.String, 1));
                    headerRow.Append(CreateCell("Thời Gian Nộp Bài", CellValues.String, 1));
                    sheetData.AppendChild(headerRow);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        Row dataRow = new Row();
                        dataRow.Append(CreateCell(row.Cells["ColMSSV"].Value?.ToString() ?? "", CellValues.String));
                        dataRow.Append(CreateCell(row.Cells["ColTen"].Value?.ToString() ?? "", CellValues.String));
                        dataRow.Append(CreateCell(row.Cells["ColDiem"].Value?.ToString() ?? "", CellValues.String));
                        dataRow.Append(CreateCell(row.Cells["ColTimeVaoThi"].Value?.ToString() ?? "", CellValues.String));
                        dataRow.Append(CreateCell(row.Cells["ColTimeNopBai"].Value?.ToString() ?? "", CellValues.String));
                        sheetData.AppendChild(dataRow);
                    }

                    workbookPart.Workbook.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi ghi file Excel: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo cell mới cho file Excel
        /// </summary>
        /// <param name="text">Nội dung cell</param>
        /// <param name="dataType">Kiểu dữ liệu cell</param>
        /// <param name="styleIndex">Index style cho cell</param>
        private Cell CreateCell(string text, CellValues dataType, uint styleIndex = 0)
        {
            Cell cell = new Cell()
            {
                DataType = dataType,
                CellValue = new CellValue(text),
                StyleIndex = styleIndex
            };
            return cell;
        }

        private Stylesheet CreateStylesheet()
        {
            Stylesheet stylesheet = new Stylesheet();

            // Fonts
            Fonts fonts = new Fonts();
            fonts.Append(new ExcelFont()); // Default font
            fonts.Append(new ExcelFont(new Bold())); // Bold font for header
            fonts.Count = (uint)fonts.ChildElements.Count;

            // Fills
            Fills fills = new Fills();
            fills.Append(new Fill(new PatternFill() { PatternType = PatternValues.None }));
            fills.Append(new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }));
            fills.Count = (uint)fills.ChildElements.Count;

            // Borders
            Borders borders = new Borders();
            borders.Append(new Border());
            borders.Count = (uint)borders.ChildElements.Count;

            // CellFormats
            CellFormats cellFormats = new CellFormats();
            cellFormats.Append(new CellFormat()); // Default
            cellFormats.Append(new CellFormat { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true }); // Bold header
            cellFormats.Count = (uint)cellFormats.ChildElements.Count;

            stylesheet.Append(fonts);
            stylesheet.Append(fills);
            stylesheet.Append(borders);
            stylesheet.Append(cellFormats);

            return stylesheet;
        }

        /// <summary>
        /// Xử lý sự kiện click vào cell trong DataGridView
        /// Mở dialog xem chi tiết bài làm khi click vào nút "Xem"
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "ColHanhDong")
                    {
                        string mssv = dataGridView1.Rows[e.RowIndex].Cells["ColMSSV"].Value?.ToString();
                        string tenSV = dataGridView1.Rows[e.RowIndex].Cells["ColTen"].Value?.ToString();
                        int maBaiLam = 0;
                        
                        if (dataGridView1.Rows[e.RowIndex].Tag != null)
                        {
                            maBaiLam = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
                        }
                        else if (danhSachBaiLamHienTai != null && e.RowIndex < danhSachBaiLamHienTai.Count)
                        {
                            maBaiLam = Convert.ToInt32(danhSachBaiLamHienTai[e.RowIndex]["maBaiLam"]);
                        }
                        
                        if (!string.IsNullOrEmpty(mssv) && maBaiLam > 0)
                        {
                            OpenBaiLamDialog(mssv, tenSV, currentMaDe, maBaiLam);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin bài làm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý click: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mở dialog xem chi tiết bài làm của sinh viên
        /// </summary>
        /// <param name="mssv">Mã số sinh viên</param>
        /// <param name="tenSV">Tên sinh viên</param>
        /// <param name="maDe">Mã đề thi</param>
        /// <param name="maBaiLam">Mã bài làm</param>
        private void OpenBaiLamDialog(string mssv, string tenSV, int maDe, int maBaiLam)
        {
            try
            {
                Form dialogForm = new Form();
                dialogForm.Text = $"Xem bài làm - {tenSV} ({mssv})";
                dialogForm.FormBorderStyle = FormBorderStyle.Sizable;
                dialogForm.MaximizeBox = true;
                dialogForm.MinimizeBox = true;
                dialogForm.StartPosition = FormStartPosition.CenterParent;
                dialogForm.Size = new Size(1000, 700);
                dialogForm.MinimumSize = new Size(800, 600);
                
                Dialog_XemBaiThiSV dialogXemBaiThi = new Dialog_XemBaiThiSV();
                dialogXemBaiThi.Dock = DockStyle.Fill;
                dialogXemBaiThi.LoadBaiLam(mssv, tenSV, maDe, maBaiLam);
                
                dialogForm.Controls.Add(dialogXemBaiThi);
                dialogForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở dialog xem bài làm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi form được thay đổi kích thước
        /// Điều chỉnh chiều rộng của textBoxTimKiem để phù hợp với kích thước của button và textBox
        /// </summary>
        private void XemChiTietDeThi_Resize(object sender, EventArgs e)
        {
            if (btnXuatExcel != null && textBoxTimKiem != null && this.Width > 0)
            {
                int textBoxRight = btnXuatExcel.Left - 20; 
                int textBoxWidth = textBoxRight - textBoxTimKiem.Left;
                
                if (textBoxWidth > 0)
                {
                    textBoxTimKiem.Width = textBoxWidth;
                }
            }
        }
    }
}

