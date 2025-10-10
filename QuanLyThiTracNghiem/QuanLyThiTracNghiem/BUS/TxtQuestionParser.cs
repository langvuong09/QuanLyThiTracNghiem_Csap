using Newtonsoft.Json;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class TxtQuestionParser
    {
        // Phương thức phân tích cú pháp nội dung câu hỏi từ file .txt
        private CauHoiDAO cauHoiDAO = new CauHoiDAO();
        private DapAnDAO dapAnDAO = new DapAnDAO();
        // Regex nhận diện A. hoặc A)
        private Regex optionRegex = new(@"^\s*([A-Ea-e])[\.\)]\s*(.*)$", RegexOptions.Compiled);
        private Regex answerRegex = new(@"^\s*(ANSWER|ĐÁP\s*ÁN)\s*[:\-]?\s*([A-Ea-e])", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        // Hàm chuyển ký tự A/B/C/D → số 1/2/3/4
        private int ConvertOptionToIndex(string option)
        {
            switch (option.Trim().ToUpper())
            {
                case "A": return 1;
                case "B": return 2;
                case "C": return 3;
                case "D": return 4;
                default: return 0;
            }
        }

        public  List<CauHoiJSON> ParseFile(string path)
        {
            var lines = File.ReadAllLines(path, Encoding.UTF8);
            var result = new List<CauHoiJSON>();

            int i = 0;
            while (i < lines.Length)
            {
                // Bỏ qua dòng trống
                while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;
                if (i >= lines.Length) break;

                // Lấy nội dung câu hỏi
                string question = "";
                while (i < lines.Length && !optionRegex.IsMatch(lines[i]))
                {
                    if (!string.IsNullOrWhiteSpace(lines[i]))
                        question += " " + lines[i].Trim();
                    i++;
                }

                var cauHoi = new CauHoiJSON { NoiDung = question.Trim() };

                // Đọc danh sách đáp án
                while (i < lines.Length && optionRegex.IsMatch(lines[i]))
                {
                    var m = optionRegex.Match(lines[i]);
                    string key = m.Groups[1].Value.ToUpper();
                    string val = m.Groups[2].Value.Trim();

                    int index = ConvertOptionToIndex(key);
                    if (index > 0)
                        cauHoi.DapAn[index] = val;

                    i++;
                }

                // Đọc dòng chứa đáp án đúng
                while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;
                if (i < lines.Length && answerRegex.IsMatch(lines[i]))
                {
                    var ma = answerRegex.Match(lines[i]);
                    string correct = ma.Groups[2].Value.ToUpper();
                    cauHoi.DapAnDung = ConvertOptionToIndex(correct);
                    i++;
                }

                if (!string.IsNullOrEmpty(cauHoi.NoiDung))
                    result.Add(cauHoi);
            }

            return result;
        }

        public void ExportToJson(string inputPath, string outputPath)
        {
            var questions = ParseFile(inputPath);

            var jsonObjects = new List<object>();
            foreach (var q in questions)
                jsonObjects.Add(q.ToJsonObject());

            string json = JsonConvert.SerializeObject(jsonObjects, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(outputPath, json, Encoding.UTF8);

            Console.WriteLine($"Đã xuất {questions.Count} câu hỏi sang file JSON: {outputPath}");
        }

        /*Phương thức đọc CauHoiJSON  và biến nó thành các đối tượng CauHoi và DapAn*/
        public (CauHoi cauHoi, List<DapAn> dsDapAn) BienDoiCauHoiJSON_sang_CauHoiVaListDapAn(CauHoiJSON input,string maMonHoc, int maChuong, string doKho, int maCauHoi)
        {
            //1. Tạo câu hỏi 
            var cauHoi = new CauHoi(maCauHoi, maMonHoc, maChuong, doKho, input.NoiDung);

            // 2. Tạo danh sách đáp án
            var dsDapAn = new List<DapAn>();
            int maDapAn = 1;
            int dungSai;
            foreach (var item in input.DapAn)
            {
                // int maDapAn, int maCauHoi, string tenDapAn, int dungSai
                if (input.DapAnDung == maDapAn)
                {
                    dungSai = 1;
                }
                else
                {
                    dungSai = 0;
                }
                var dapAn = new DapAn(maDapAn,maCauHoi,item.Value,dungSai);
                maDapAn = maDapAn + 1;
                dsDapAn.Add(dapAn);

            }
            return (cauHoi, dsDapAn);
        }

        // Phương thức đọc List<CauHoiJSON> sang List <CauHoi,List<DapAn>>
        public List<(CauHoi cauHoi, List<DapAn> dsDapAn)> DocListCauHoiJSON_sang_ListCauHoiVaListDapAn(
            List<CauHoiJSON> listCauHoiJSON,
            string maMonHoc,
            int maChuong,
            string doKho)
        {
            // Tạo mã câu hỏi để bắt đầu
            int maCauHoiBatDau = cauHoiDAO.maxMaCauHoi()+1;
            // Tạo danh sách kết quả
            var listKetQua = new List<(CauHoi, List<DapAn>)>();

            foreach (var item in listCauHoiJSON)
            {

                (CauHoi, List<DapAn>) obj = BienDoiCauHoiJSON_sang_CauHoiVaListDapAn(item, maMonHoc, maChuong, doKho, maCauHoiBatDau);
                listKetQua.Add(obj);
                maCauHoiBatDau = maCauHoiBatDau + 1;

            }

            return listKetQua;
        }
        /* Phương thức tạo ra file mẫu
           Phương thức này dùng trong : Panel_ThemCauHoiTuFile
         */

        public void TaoVaMoFileMau()
        {
            try
            {
                // Mở hộp thoại cho người dùng chọn nơi lưu
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Chọn nơi lưu file mẫu";
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveFileDialog.FileName = "file_mau.txt"; // tên gợi ý

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Nội dung file mẫu
                        string noiDung =
                            @"OOP là viết tắt của:
                            A. Object Open Programming
                            B. Open Object Programming
                            C. Object Oriented Programming
                            D. Object Oriented Proccessing
                            ANSWER: C

                            HTML là viết tắt của:
                            A. Hyper Trainer Marking Language
                            B. Hyper Text Marketing Language
                            C. Hyper Text Markup Language
                            D. Hyper Tool Multi Language
                            ANSWER: C";

                        // Ghi nội dung vào file
                        File.WriteAllText(filePath, noiDung, Encoding.UTF8);

                        // Hỏi người dùng có muốn mở file ngay không
                        var dialogResult = MessageBox.Show(
                            "Đã tạo file mẫu thành công!\nBạn có muốn mở file ngay bây giờ không?",
                            "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes)
                        {
                            // Mở file bằng Notepad hoặc ứng dụng mặc định
                            Process.Start(new ProcessStartInfo()
                            {
                                FileName = filePath,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo hoặc mở file mẫu.\nChi tiết: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /* Phương thức lưu vào cơ sở dữ liệu 
            Sử dụng phương thức của class CauHoiDAO => bool ThemCauHoi(int maCauHoi, string maMonHoc, int maChuong, string doKho, string noiDungCauHoi)
            Sử dụng phương thức của claas DapAnDAP => bool ThemDSDapAn(List<DapAn> danhSachDapAn)
           Phương thức này dùng trong : Panel_ThemCauHoiTuFile
         */
        public void LuuDanhSachCauHoiTuFileVaoCSDL(ComboBox comboBox_MonHoc, ComboBox comboBox_Chuong, ComboBox comboBox_DoKho)
        {
            string maMonHoc = ((MonHoc)comboBox_MonHoc.SelectedItem).maMonHoc;
            int maChuong = ((Chuong)comboBox_Chuong.SelectedItem).maChuong;
            var selectedPair = (KeyValuePair<int, string>)comboBox_DoKho.SelectedItem;
            string doKho = selectedPair.Value;

            //Không được chọn "Chọn Môn Học"
            if (comboBox_MonHoc.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Môn Học.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Không được chọn "Chọn Chương"
            if (comboBox_Chuong.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Chương.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }
            //Không được chọn "Chọn Độ Khó"
            if (comboBox_DoKho.SelectedIndex <= 0)
            {
                MyDialog dialog = new MyDialog("Vui lòng chọn Độ Khó.", MyDialog.WARNING_DIALOG);
                dialog.ShowDialog();
                return;
            }

            // Đọc List<CauHoiJSON> từ file
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn file câu hỏi (.txt)";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Đọc danh sách câu hỏi JSON
                    var listCauHoiJSON = ParseFile(filePath);
                    if (listCauHoiJSON.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy câu hỏi hợp lệ trong file!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Chuyển đổi sang đối tượng thật
                    var listKetQua = DocListCauHoiJSON_sang_ListCauHoiVaListDapAn(listCauHoiJSON, maMonHoc, maChuong, doKho);

                    int countThanhCong = 0;
                    int countLoi = 0;

                    // B3: Duyệt từng phần tử để thêm vào CSDL
                    foreach (var (cauHoi, dsDapAn) in listKetQua)
                    {
                        bool themCauHoiThanhCong = cauHoiDAO.ThemCauHoi(
                            cauHoi.maCauHoi, cauHoi.maMonHoc, cauHoi.maChuong, cauHoi.doKho, cauHoi.noiDungCauHoi
                        );

                        if (themCauHoiThanhCong==true)
                        {
                            Console.WriteLine("Thêm câu hỏi có mã là ", cauHoi.maCauHoi, " thành công");
                            bool themDapAnThanhCong = dapAnDAO.ThemDSDapAn(dsDapAn);

                            if (themDapAnThanhCong==true)
                            {
                                Console.WriteLine("Thêm danh sách đáp án của mã câu hỏi ", cauHoi.maCauHoi," thành công");
                                countThanhCong++;
                            }
                            else
                            {
                                countLoi++;
                                Console.WriteLine("Thêm danh sách đáp án của mã câu hỏi ", cauHoi.maCauHoi, " không thành công");
                                bool xoaDapAn = dapAnDAO.XoaDapAnTheoCauHoi(cauHoi.maCauHoi);
                                bool xoaCauHoi = cauHoiDAO.XoaCauHoi(cauHoi.maCauHoi) ;
                                if (xoaDapAn==true && xoaCauHoi == true)
                                {
                                    Console.WriteLine("Đã xóa câu hỏi bị thêm lỗi có mã là", cauHoi.maCauHoi) ;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Thêm câu hỏi  có mã", cauHoi.maCauHoi, " bị lỗi");
                            countLoi++;

                        }
                    }

                    MyDialog dialog = new MyDialog($"Thêm thành công {countThanhCong} câu hỏi, thất bại {countLoi} câu!", MyDialog.SUCCESS_DIALOG);
                    dialog.ShowDialog();

                }

            }


        }

        



    }

}
