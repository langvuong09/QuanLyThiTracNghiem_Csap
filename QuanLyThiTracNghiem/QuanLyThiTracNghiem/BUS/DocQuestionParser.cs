using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using QuanLyThiTracNghiem.MyCustom;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DAO;
using QuanLyThiTracNghiem.QuanLyThiTracNghiem.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThiTracNghiem.QuanLyThiTracNghiem.BUS
{
    internal class DocQuestionParser
    {
        private CauHoiDAO cauHoiDAO = new CauHoiDAO();
        private DapAnDAO dapAnDAO = new DapAnDAO();

        // Regex: A. / A) / a. / a)
        private Regex optionRegex = new(@"^\s*([A-Da-d])[\.\)]\s*(.*)$", RegexOptions.Compiled);
        private Regex answerRegex = new(@"^\s*(ANSWER|ĐÁP\s*ÁN)\s*[:\-]?\s*([A-Da-d])\s*$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private int ConvertOptionToIndex(string option)
        {
            return option.Trim().ToUpper() switch
            {
                "A" => 1,
                "B" => 2,
                "C" => 3,
                "D" => 4,
                _ => 0
            };
        }

        /// <summary>
        /// Đọc nội dung file .docx → mảng dòng
        /// </summary>
        private string[] ReadDocxFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("File không tồn tại: " + path);
            if (Path.GetExtension(path).ToLower() != ".docx")
                throw new NotSupportedException("Chỉ hỗ trợ file .docx");

            var lines = new List<string>();
            using (WordprocessingDocument doc = WordprocessingDocument.Open(path, false))
            {
                var paragraphs = doc.MainDocumentPart.Document.Body.Elements<Paragraph>();
                foreach (var p in paragraphs)
                {
                    string text = p.InnerText.Trim();
                    if (!string.IsNullOrWhiteSpace(text))
                        lines.Add(text);
                }
            }
            return lines.ToArray();
        }

        /// <summary>
        /// Parse file .docx → List<CauHoiJSON> (có kiểm tra hợp lệ)
        /// </summary>
        public List<CauHoiJSON> ParseFile(string path)
        {
            var lines = ReadDocxFile(path);
            var result = new List<CauHoiJSON>();
            int i = 0;
            int questionNumber = 1;

            while (i < lines.Length)
            {
                // Bỏ dòng trống
                while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;
                if (i >= lines.Length) break;

                // --- Đọc nội dung câu hỏi ---
                string question = "";
                int startQuestionLine = i;
                while (i < lines.Length && !optionRegex.IsMatch(lines[i]))
                {
                    question += " " + lines[i].Trim();
                    i++;
                }
                question = question.Trim();
                if (string.IsNullOrEmpty(question)) continue;

                var cauHoi = new CauHoiJSON { NoiDung = question };
                var dapAnDict = new Dictionary<int, string>();

                // --- Đọc 4 đáp án ---
                int optionCount = 0;
                while (i < lines.Length && optionRegex.IsMatch(lines[i]) && optionCount < 4)
                {
                    var match = optionRegex.Match(lines[i]);
                    string key = match.Groups[1].Value.ToUpper();
                    string val = match.Groups[2].Value.Trim();
                    int index = ConvertOptionToIndex(key);

                    if (index >= 1 && index <= 4 && !string.IsNullOrEmpty(val))
                    {
                        dapAnDict[index] = val;
                        optionCount++;
                    }
                    i++;
                }

                // Kiểm tra: Phải đủ 4 đáp án A B C D
                if (optionCount != 4 || dapAnDict.Count != 4)
                {
                    Console.WriteLine($"[LỖI CÂU {questionNumber}] Thiếu đáp án (chỉ có {optionCount}/4)");
                    questionNumber++;
                    continue;
                }

                cauHoi.DapAn = dapAnDict;

                // --- Đọc đáp án đúng ---
                while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;
                if (i >= lines.Length || !answerRegex.IsMatch(lines[i]))
                {
                    Console.WriteLine($"[LỖI CÂU {questionNumber}] Thiếu dòng ANSWER:");
                    questionNumber++;
                    continue;
                }

                var answerMatch = answerRegex.Match(lines[i]);
                string correctKey = answerMatch.Groups[2].Value.ToUpper();
                int correctIndex = ConvertOptionToIndex(correctKey);

                if (correctIndex < 1 || correctIndex > 4)
                {
                    Console.WriteLine($"[LỖI CÂU {questionNumber}] Đáp án đúng không hợp lệ: {correctKey}");
                    questionNumber++;
                    i++;
                    continue;
                }

                cauHoi.DapAnDung = correctIndex;
                i++; // Bỏ qua dòng ANSWER

                // Thành công → thêm vào kết quả
                result.Add(cauHoi);
                Console.WriteLine($"[THÀNH CÔNG] Đã parse câu hỏi {questionNumber}");
                questionNumber++;
            }

            return result;
        }

        // === Xuất JSON ===
        public void ExportToJson(string inputPath, string outputPath)
        {
            var questions = ParseFile(inputPath);
            var json = JsonConvert.SerializeObject(questions.Select(q => q.ToJsonObject()), Formatting.Indented);
            File.WriteAllText(outputPath, json, Encoding.UTF8);
            MessageBox.Show($"Xuất thành công {questions.Count} câu hỏi hợp lệ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // === Các hàm chuyển đổi & lưu DB (giữ nguyên logic cũ) ===
        /// <summary>
        /// Chuyển 1 CauHoiJSON → (CauHoi, List<DapAn>, maDapAnTiepTheo)
        /// </summary>
        public (CauHoi cauHoi, List<DapAn> dsDapAn, int maDapAnTiepTheo)
            BienDoiCauHoiJSON_sang_CauHoiVaListDapAn(
                CauHoiJSON input,
                string maMonHoc,
                int maChuong,
                string doKho,
                int maCauHoi,
                int maDapAnBatDau)
        {
            var cauHoi = new CauHoi(maCauHoi, maMonHoc, maChuong, doKho, input.NoiDung);
            var dsDapAn = new List<DapAn>();

            int maDapAnHienTai = maDapAnBatDau;

            for (int i = 1; i <= 4; i++)
            {
                int dungSai = (input.DapAnDung == i) ? 1 : 0;
                dsDapAn.Add(new DapAn(maDapAnHienTai, maCauHoi, input.DapAn[i], dungSai));
                maDapAnHienTai++; // Tăng dần cho đáp án tiếp
            }

            return (cauHoi, dsDapAn, maDapAnHienTai); // Trả về mã đáp án tiếp theo
        }

        /// <summary>
        /// Chuyển toàn bộ List<CauHoiJSON> → List<(CauHoi, List<DapAn>)>
        /// Tự động sinh maCauHoi và maDapAn liên tục
        /// </summary>
        public List<(CauHoi cauHoi, List<DapAn> dsDapAn)>
            DocListCauHoiJSON_sang_ListCauHoiVaListDapAn(
                List<CauHoiJSON> listCauHoiJSON,
                string maMonHoc,
                int maChuong,
                string doKho)
        {
            int maCauHoi = cauHoiDAO.maxMaCauHoi() + 1;
            int maDapAn = dapAnDAO.maxMaDapAn() + 1;

            var result = new List<(CauHoi, List<DapAn>)>();

            foreach (var item in listCauHoiJSON)
            {
                var (cauHoi, dsDapAn, maDapAnMoi) =
                    BienDoiCauHoiJSON_sang_CauHoiVaListDapAn(
                        item, maMonHoc, maChuong, doKho, maCauHoi, maDapAn);

                result.Add((cauHoi, dsDapAn));

                // Cập nhật mã cho câu hỏi & đáp án tiếp theo
                maCauHoi++;
                maDapAn = maDapAnMoi;
            }

            return result;
        }
        // === Tạo file mẫu .docx ===
        public void TaoVaMoFileMau()
        {
            using (var saveDlg = new SaveFileDialog())
            {
                saveDlg.Filter = "Word Document|*.docx";
                saveDlg.FileName = "mau_cau_hoi.docx";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    using (var doc = WordprocessingDocument.Create(saveDlg.FileName, WordprocessingDocumentType.Document))
                    {
                        var mainPart = doc.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        var body = mainPart.Document.AppendChild(new Body());

                        string[] sample = {
                            "Câu 1: OOP là viết tắt của:",
                            "A. Object Open Programming",
                            "B. Open Object Programming",
                            "C. Object Oriented Programming",
                            "D. Object Oriented Proccessing",
                            "ANSWER: C",
                            "",
                            "Câu 2: HTML là viết tắt của:",
                            "A. Hyper Trainer Marking Language",
                            "B. Hyper Text Marketing Language",
                            "C. Hyper Text Markup Language",
                            "D. Hyper Tool Multi Language",
                            "ANSWER: C"
                        };

                        foreach (var line in sample)
                        {
                            body.AppendChild(new Paragraph(new Run(new Text(line))));
                        }
                        mainPart.Document.Save();
                    }

                    if (MessageBox.Show("Tạo file mẫu thành công!\nMở file ngay?", "Thành công", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Process.Start(new ProcessStartInfo(saveDlg.FileName) { UseShellExecute = true });
                    }
                }
            }
        }

        // === Lưu vào CSDL ===
        public void LuuDanhSachCauHoiTuFileVaoCSDL(ComboBox cbMonHoc, ComboBox cbChuong, ComboBox cbDoKho)
        {
            // Kiểm tra chọn
            if (cbMonHoc.SelectedIndex <= 0 || cbChuong.SelectedIndex <= 0 || cbDoKho.SelectedIndex <= 0)
            {
                new MyDialog("Vui lòng chọn đầy đủ Môn học, Chương, Độ khó!", MyDialog.WARNING_DIALOG).ShowDialog();
                return;
            }

            string maMonHoc = ((MonHoc)cbMonHoc.SelectedItem).maMonHoc;
            int maChuong = ((Chuong)cbChuong.SelectedItem).maChuong;
            string doKho = ((KeyValuePair<int, string>)cbDoKho.SelectedItem).Value;

            using (var openDlg = new OpenFileDialog())
            {
                openDlg.Filter = "Word Document|*.docx";
                if (openDlg.ShowDialog() == DialogResult.OK)
                {
                    var questions = ParseFile(openDlg.FileName);
                    if (questions.Count == 0)
                    {
                        MessageBox.Show("Không có câu hỏi hợp lệ nào!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var data = DocListCauHoiJSON_sang_ListCauHoiVaListDapAn(questions, maMonHoc, maChuong, doKho);
                    int success = 0, fail = 0;

                    foreach (var (cauHoi, dsDapAn) in data)
                    {
                        if (cauHoiDAO.ThemCauHoi(cauHoi.maCauHoi, cauHoi.maMonHoc, cauHoi.maChuong, cauHoi.doKho, cauHoi.noiDungCauHoi))
                        {
                            if (dapAnDAO.ThemDSDapAn(dsDapAn))
                                success++;
                            else
                            {
                                fail++;
                                dapAnDAO.XoaDapAnTheoCauHoi(cauHoi.maCauHoi);
                                cauHoiDAO.XoaCauHoi(cauHoi.maCauHoi);
                            }
                        }
                        else fail++;
                    }

                    new MyDialog($"Thêm thành công: {success}\nThất bại: {fail}", MyDialog.SUCCESS_DIALOG).ShowDialog();
                }
            }
        }
    }
}