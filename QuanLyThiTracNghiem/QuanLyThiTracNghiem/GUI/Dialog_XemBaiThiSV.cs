using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.GUI
{
    public partial class Dialog_XemBaiThiSV : UserControl
    {
        private string currentMSSV = "";
        private string currentTenSV = "";
        private int currentMaDe = 0;
        private int currentMaBaiLam = 0;
        private int currentCauHoiIndex = 0;
        private List<CauHoi> danhSachCauHoi = new List<CauHoi>();
        private List<DapAn> danhSachDapAn = new List<DapAn>();
        private List<ChiTietBaiLam> chiTietBaiLam = new List<ChiTietBaiLam>();
        
        private CauHoiBUS cauHoiBUS = new CauHoiBUS();
        private DapAnBUS dapAnBUS = new DapAnBUS();
        private ChiTietBaiLamBUS chiTietBaiLamBUS = new ChiTietBaiLamBUS();

        public Dialog_XemBaiThiSV()
        {
            InitializeComponent();
            InitializeData();
        }

        // KHỞI TẠO DỮ LIỆU MẶC ĐỊNH
        private void InitializeData()
        {
            try
            {
                // Thiết lập các control không thể chỉnh sửa
                textBoxMSSV.ReadOnly = true;
                textBoxTenSV.ReadOnly = true;
                textBoxCauHoi.ReadOnly = true;
                
                // Vô hiệu hóa các radio button (chỉ để xem)
                radioA.Enabled = false;
                radioB.Enabled = false;
                radioC.Enabled = false;
                radioD.Enabled = false;
                
                // Thiết lập màu nền cho các textbox
                textBoxMSSV.BackColor = Color.White;
                textBoxTenSV.BackColor = Color.White;
                textBoxCauHoi.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LOAD DỮ LIỆU TỪ DATABASE
        private void LoadDataFromDatabase()
        {
            try
            {
                Console.WriteLine($"=== Bắt đầu load dữ liệu: maDe={currentMaDe}, maBaiLam={currentMaBaiLam} ===");
                
                if (currentMaDe > 0 && currentMaBaiLam > 0)
                {
                    // Load chi tiết bài làm của sinh viên trước
                    chiTietBaiLam = chiTietBaiLamBUS.GetChiTietBaiLamByMaBaiLam(currentMaBaiLam);
                    
                    Console.WriteLine($"Đã load {chiTietBaiLam?.Count ?? 0} chi tiết bài làm");
                    
                    if (chiTietBaiLam == null || chiTietBaiLam.Count == 0)
                    {
                        Console.WriteLine("LỖI: Không tìm thấy chi tiết bài làm!");
                        MessageBox.Show("Không tìm thấy chi tiết bài làm của sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // Debug: In ra tất cả chi tiết bài làm
                    Console.WriteLine("Chi tiết bài làm:");
                    foreach (var ct in chiTietBaiLam)
                    {
                        Console.WriteLine($"  - maCauHoi: {ct.maCauHoi}, maDapAnDuocChon: {ct.maDapAnDuocChon}");
                    }
                    
                    // Load danh sách câu hỏi của đề thi (KHÔNG xáo trộn để giữ thứ tự)
                    danhSachCauHoi = cauHoiBUS.GetCauHoiByDeThiKhongTron(currentMaDe);
                    
                    Console.WriteLine($"Đã load {danhSachCauHoi?.Count ?? 0} câu hỏi");
                    
                    if (danhSachCauHoi == null || danhSachCauHoi.Count == 0)
                    {
                        Console.WriteLine("LỖI: Không tìm thấy câu hỏi!");
                        MessageBox.Show("Không tìm thấy câu hỏi cho đề thi này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    // Sắp xếp câu hỏi theo thứ tự trong chi tiết bài làm (theo maCauHoi)
                    // Đảm bảo thứ tự hiển thị giống với thứ tự trong bài làm
                    var sortedCauHoi = new List<CauHoi>();
                    foreach (var chiTiet in chiTietBaiLam.OrderBy(ct => ct.maCauHoi))
                    {
                        var cauHoi = danhSachCauHoi.FirstOrDefault(ch => ch.maCauHoi == chiTiet.maCauHoi);
                        if (cauHoi != null)
                        {
                            sortedCauHoi.Add(cauHoi);
                        }
                    }
                    
                    // Thêm các câu hỏi còn lại (nếu có)
                    foreach (var cauHoi in danhSachCauHoi)
                    {
                        if (!sortedCauHoi.Any(ch => ch.maCauHoi == cauHoi.maCauHoi))
                        {
                            sortedCauHoi.Add(cauHoi);
                        }
                    }
                    
                    danhSachCauHoi = sortedCauHoi;
                    
                    // Reset về câu hỏi đầu tiên
                    currentCauHoiIndex = 0;
                    
                    // Load đáp án cho câu hỏi đầu tiên
                    LoadDapAnForCurrentQuestion();
                    
                    // Hiển thị câu hỏi đầu tiên
                    DisplayCurrentQuestion();
                    
                    // Cập nhật phân trang
                    UpdatePagination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load dữ liệu từ database: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LOAD ĐÁP ÁN CHO CÂU HỎI HIỆN TẠI
        private void LoadDapAnForCurrentQuestion()
        {
            try
            {
                if (currentCauHoiIndex < danhSachCauHoi.Count)
                {
                    int maCauHoi = danhSachCauHoi[currentCauHoiIndex].maCauHoi;
                    danhSachDapAn = dapAnBUS.GetDapAnByCauHoi(maCauHoi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load đáp án: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ CÂU HỎI HIỆN TẠI
        private void DisplayCurrentQuestion()
        {
            try
            {
                if (currentCauHoiIndex >= 0 && currentCauHoiIndex < danhSachCauHoi.Count)
                {
                    // Hiển thị câu hỏi
                    textBoxCauHoi.Text = $"Câu {currentCauHoiIndex + 1}: {danhSachCauHoi[currentCauHoiIndex].noiDungCauHoi}";
                    
                    // Load đáp án cho câu hỏi hiện tại
                    LoadDapAnForCurrentQuestion();
                    
                    // Hiển thị đáp án
                    DisplayAnswers();
                    
                    // Hiển thị đáp án sinh viên đã chọn
                    DisplayStudentAnswer();
                    
                    // Cập nhật phân trang
                    UpdatePagination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ ĐÁP ÁN
        private void DisplayAnswers()
        {
            try
            {
                // Reset tất cả radio button
                radioA.Checked = false;
                radioB.Checked = false;
                radioC.Checked = false;
                radioD.Checked = false;
                
                // Reset text và ẩn nếu không có đáp án
                radioA.Text = "A.";
                radioB.Text = "B.";
                radioC.Text = "C.";
                radioD.Text = "D.";
                
                radioA.Visible = false;
                radioB.Visible = false;
                radioC.Visible = false;
                radioD.Visible = false;
                
                // Hiển thị đáp án A, B, C, D với khoảng cách rõ ràng
                if (danhSachDapAn.Count >= 1)
                {
                    radioA.Text = $"A. {danhSachDapAn[0].tenDapAn}";
                    radioA.Visible = true;
                }
                if (danhSachDapAn.Count >= 2)
                {
                    radioB.Text = $"B. {danhSachDapAn[1].tenDapAn}";
                    radioB.Visible = true;
                }
                if (danhSachDapAn.Count >= 3)
                {
                    radioC.Text = $"C. {danhSachDapAn[2].tenDapAn}";
                    radioC.Visible = true;
                }
                if (danhSachDapAn.Count >= 4)
                {
                    radioD.Text = $"D. {danhSachDapAn[3].tenDapAn}";
                    radioD.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hiển thị đáp án: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // HIỂN THỊ ĐÁP ÁN SINH VIÊN ĐÃ CHỌN
        private void DisplayStudentAnswer()
        {
            try
            {
                // Reset màu sắc cho tất cả radio button
                radioA.ForeColor = Color.Black;
                radioB.ForeColor = Color.Black;
                radioC.ForeColor = Color.Black;
                radioD.ForeColor = Color.Black;
                
                // Reset checked
                radioA.Checked = false;
                radioB.Checked = false;
                radioC.Checked = false;
                radioD.Checked = false;
                
                if (currentCauHoiIndex >= 0 && currentCauHoiIndex < danhSachCauHoi.Count)
                {
                    int maCauHoi = danhSachCauHoi[currentCauHoiIndex].maCauHoi;
                    
                    // Debug: Kiểm tra chi tiết bài làm
                    if (chiTietBaiLam == null || chiTietBaiLam.Count == 0)
                    {
                        Console.WriteLine($"CẢNH BÁO: chiTietBaiLam rỗng cho câu hỏi {maCauHoi}");
                        return;
                    }
                    
                    // Tìm đáp án sinh viên đã chọn
                    var dapAnDaChon = chiTietBaiLam.FirstOrDefault(ct => ct.maCauHoi == maCauHoi);
                    
                    if (dapAnDaChon == null)
                    {
                        Console.WriteLine($"CẢNH BÁO: Không tìm thấy đáp án đã chọn cho câu hỏi {maCauHoi}");
                        Console.WriteLine($"Danh sách chi tiết bài làm có {chiTietBaiLam.Count} mục");
                        foreach (var ct in chiTietBaiLam)
                        {
                            Console.WriteLine($"  - maCauHoi: {ct.maCauHoi}, maDapAnDuocChon: {ct.maDapAnDuocChon}");
                        }
                        return;
                    }
                    
                    Console.WriteLine($"Tìm thấy đáp án đã chọn: maCauHoi={maCauHoi}, maDapAnDuocChon={dapAnDaChon.maDapAnDuocChon}");
                    
                    // Tìm đáp án trong danh sách bằng maDapAn (không dựa vào index)
                    var dapAnSVChon = danhSachDapAn.FirstOrDefault(da => da.maDapAn == dapAnDaChon.maDapAnDuocChon);
                    
                    // Tìm đáp án đúng
                    var dapAnDung = danhSachDapAn.FirstOrDefault(da => da.dungSai == 1);
                    
                    if (dapAnSVChon == null)
                    {
                        Console.WriteLine($"LỖI: Không tìm thấy đáp án có maDapAn={dapAnDaChon.maDapAnDuocChon} trong danh sách đáp án");
                        Console.WriteLine($"Danh sách đáp án có {danhSachDapAn.Count} mục:");
                        foreach (var da in danhSachDapAn)
                        {
                            Console.WriteLine($"  - maDapAn: {da.maDapAn}, tenDapAn: {da.tenDapAn}, dungSai: {da.dungSai}");
                        }
                    }
                    else
                    {
                        // Tìm index của đáp án sinh viên đã chọn
                        int index = danhSachDapAn.IndexOf(dapAnSVChon);
                        Console.WriteLine($"Tìm thấy đáp án sinh viên chọn ở index {index}");
                        
                        RadioButton selectedRadio = null;
                        
                        switch (index)
                        {
                            case 0: 
                                radioA.Checked = true;
                                selectedRadio = radioA;
                                break;
                            case 1: 
                                radioB.Checked = true;
                                selectedRadio = radioB;
                                break;
                            case 2: 
                                radioC.Checked = true;
                                selectedRadio = radioC;
                                break;
                            case 3: 
                                radioD.Checked = true;
                                selectedRadio = radioD;
                                break;
                            default:
                                Console.WriteLine($"CẢNH BÁO: Index {index} không hợp lệ (chỉ có {danhSachDapAn.Count} đáp án)");
                                break;
                        }
                        
                        // Đánh dấu màu sắc: xanh nếu đúng, đỏ nếu sai
                        if (selectedRadio != null)
                        {
                            if (dapAnSVChon.dungSai == 1)
                            {
                                selectedRadio.ForeColor = Color.Green;
                                Console.WriteLine($"Đáp án đúng - màu xanh");
                            }
                            else
                            {
                                selectedRadio.ForeColor = Color.Red;
                                Console.WriteLine($"Đáp án sai - màu đỏ");
                            }
                        }
                    }
                    
                    // Đánh dấu đáp án đúng bằng màu xanh (nếu sinh viên chọn sai hoặc không chọn)
                    if (dapAnDung != null && (dapAnSVChon == null || dapAnSVChon.dungSai != 1))
                    {
                        int indexDung = danhSachDapAn.IndexOf(dapAnDung);
                        RadioButton radioDung = null;
                        
                        switch (indexDung)
                        {
                            case 0: radioDung = radioA; break;
                            case 1: radioDung = radioB; break;
                            case 2: radioDung = radioC; break;
                            case 3: radioDung = radioD; break;
                        }
                        
                        if (radioDung != null && !radioDung.Checked)
                        {
                            radioDung.ForeColor = Color.Green;
                            Console.WriteLine($"Hiển thị đáp án đúng ở vị trí {indexDung}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LỖI KHI HIỂN THỊ ĐÁP ÁN SINH VIÊN: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                MessageBox.Show($"Lỗi khi hiển thị đáp án sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // LOAD DỮ LIỆU BÀI LÀM CỦA SINH VIÊN
        public void LoadBaiLam(string mssv, string tenSV, int maDe = 1, int maBaiLam = 1)
        {
            try
            {
                currentMSSV = mssv;
                currentTenSV = tenSV;
                currentMaDe = maDe;
                currentMaBaiLam = maBaiLam;
                
                // Hiển thị thông tin sinh viên
                textBoxMSSV.Text = mssv;
                textBoxTenSV.Text = tenSV;
                
                // Load dữ liệu từ database
                LoadDataFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi load bài làm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // XỬ LÝ KHI CLICK VÀO LABEL THÍ SINH
        }

        private void labelMSSV_Click(object sender, EventArgs e)
        {
            // XỬ LÝ KHI CLICK VÀO LABEL MSSV
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // XỬ LÝ KHI RADIO BUTTON THAY ĐỔI (chỉ để xem, không cho chỉnh sửa)
            // Không cần xử lý gì vì đây là chế độ xem
        }
        
        // CẬP NHẬT PHÂN TRANG
        private void UpdatePagination()
        {
            try
            {
                if (danhSachCauHoi != null && danhSachCauHoi.Count > 0)
                {
                    // Cập nhật label số câu
                    labelSoCau.Text = $"Câu {currentCauHoiIndex + 1} / {danhSachCauHoi.Count}";
                    
                    // Enable/Disable nút Previous
                    btnPrevious.Enabled = currentCauHoiIndex > 0;
                    
                    // Enable/Disable nút Next
                    btnNext.Enabled = currentCauHoiIndex < danhSachCauHoi.Count - 1;
                }
                else
                {
                    labelSoCau.Text = "Câu 0 / 0";
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phân trang: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // XỬ LÝ NÚT PREVIOUS
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCauHoiIndex > 0)
                {
                    currentCauHoiIndex--;
                    DisplayCurrentQuestion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // XỬ LÝ NÚT NEXT
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentCauHoiIndex < danhSachCauHoi.Count - 1)
                {
                    currentCauHoiIndex++;
                    DisplayCurrentQuestion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển câu hỏi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
