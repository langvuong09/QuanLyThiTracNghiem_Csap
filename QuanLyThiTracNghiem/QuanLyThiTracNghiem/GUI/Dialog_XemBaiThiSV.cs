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
                if (currentMaDe > 0)
                {
                    // Load danh sách câu hỏi của đề thi
                    danhSachCauHoi = cauHoiBUS.GetCauHoiByDeThi(currentMaDe);
                    
                    if (danhSachCauHoi.Count > 0)
                    {
                        // Load đáp án cho câu hỏi đầu tiên
                        LoadDapAnForCurrentQuestion();
                        
                        // Load chi tiết bài làm của sinh viên
                        chiTietBaiLam = chiTietBaiLamBUS.GetChiTietBaiLamByMaBaiLam(currentMaBaiLam);
                        
                        // Hiển thị câu hỏi đầu tiên
                        DisplayCurrentQuestion();
                    }
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
                if (currentCauHoiIndex < danhSachCauHoi.Count)
                {
                    // Hiển thị câu hỏi
                    textBoxCauHoi.Text = $"Câu {currentCauHoiIndex + 1}: {danhSachCauHoi[currentCauHoiIndex].noiDungCauHoi}";
                    
                    // Hiển thị đáp án
                    DisplayAnswers();
                    
                    // Hiển thị đáp án sinh viên đã chọn
                    DisplayStudentAnswer();
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
                
                // Hiển thị đáp án A, B, C, D
                if (danhSachDapAn.Count >= 1)
                {
                    radioA.Text = $"A. {danhSachDapAn[0].tenDapAn}";
                }
                if (danhSachDapAn.Count >= 2)
                {
                    radioB.Text = $"B. {danhSachDapAn[1].tenDapAn}";
                }
                if (danhSachDapAn.Count >= 3)
                {
                    radioC.Text = $"C. {danhSachDapAn[2].tenDapAn}";
                }
                if (danhSachDapAn.Count >= 4)
                {
                    radioD.Text = $"D. {danhSachDapAn[3].tenDapAn}";
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
                if (currentCauHoiIndex < danhSachCauHoi.Count)
                {
                    int maCauHoi = danhSachCauHoi[currentCauHoiIndex].maCauHoi;
                    
                    // Tìm đáp án sinh viên đã chọn
                    var dapAnDaChon = chiTietBaiLam.FirstOrDefault(ct => ct.maCauHoi == maCauHoi);
                    
                    if (dapAnDaChon != null)
                    {
                        // Tìm đáp án trong danh sách
                        var dapAn = danhSachDapAn.FirstOrDefault(da => da.maDapAn == dapAnDaChon.maDapAnDuocChon);
                        
                        if (dapAn != null)
                        {
                            int index = danhSachDapAn.IndexOf(dapAn);
                            switch (index)
                            {
                                case 0: radioA.Checked = true; break;
                                case 1: radioB.Checked = true; break;
                                case 2: radioC.Checked = true; break;
                                case 3: radioD.Checked = true; break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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
            // XỬ LÝ KHI RADIO BUTTON THAY ĐỔI
            try
            {
                RadioButton selectedRadio = sender as RadioButton;
                if (selectedRadio != null && selectedRadio.Checked)
                {
                    string selectedAnswer = selectedRadio.Text;
                    // Sinh viên đã chọn đáp án: selectedAnswer
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý đáp án: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
