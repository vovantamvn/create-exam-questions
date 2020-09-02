using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
//
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;
using ViDu1.BusinessObject;
using System.Diagnostics;
namespace ViDu1
{
    public partial class fProcessTest : Form
    {
        //
        object readOnly = false; //default
        object isVisible = false;
        object missing = Missing.Value;
        Word.Paragraph oPara2;
        Word.Paragraph oPara;
        object oRng;
        Word.Range wrdRng;
        List<int> processesbeforegen;
        List<int> processesaftergen;
        object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
        object oPageBreak = Word.WdBreakType.wdPageBreak;
        fMain _fMain;
        //
        public List<string> DuongDan { get; set;}
        public List<int> SoCau { get; set; }
        public List<int> SoCauMacDinh { get; set; }
        public List<decimal> Diem { get; set; }
        public List<int> LoaiKho { get; set; }
        public List<int> IdKieu { get; set; }
        public fProcessTest()
        {
            InitializeComponent();
        }
        public fProcessTest(fMain _f)
        {
            InitializeComponent();
            _fMain = _f;
        }
        int KiemTra(int m, List<int> ds)
        {
            int i = 0, _out = 0;
            if (ds.Count == 0)
                _out = 0;
            for (i = 0; i < ds.Count; i++)
            {
                if (m == ds[i])
                {
                    _out = 1;
                    break;
                }
            }
            return _out;
        }

        private List<int> CreateListTest(int n, int _soDe, int k)
        {
            List<int> lst_out = new List<int>();
            //n là số câu max trong danh sách câu nhóm 1
            //_soDe là số đề cần tạo ra
            //k là vị trí bắt đầu lặp của mỗi danh sách (k=0,1,2...n)
            List<int> lst_tmp = new List<int>();
            int Numrd;
            //Tạo danh sách câu hỏi ngẫu nhiên theo số lượng yêu cầu
            while (lst_tmp.Count < n)
            {
                Random rd = new Random();
                Numrd = rd.Next(1, n + 1);//biến Numrd sẽ nhận có giá trị ngẫu nhiên trong khoảng 1 đến n
                //Kiểm tra xem Numrd khác với các phần tử trong lst_tmp hay không
                //Nếu khác thì thêm vào lst_tmp, ngược lại thì lại random tiếp
                if (KiemTra(Numrd, lst_tmp) == 0)
                    lst_tmp.Add(Numrd);
            }
            string ds = "";
            foreach (int m in lst_tmp)
            {
                ds = ds + m.ToString() + " ";
            }
            //MessageBox.Show("DS 10 phan tu: " + ds);

            for (int j = 0; j < _soDe; j++)
            {
                if (j < n)
                    lst_out.Add(lst_tmp[j]);
                else
                    lst_out.Add(lst_tmp[(j % n + k) % n]);
            }
            string ds1 = "";
            foreach (int m in lst_out)
            {
                ds1 = ds1 + m.ToString() + " ";
            }
            return lst_out;
        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }
        public List<int> getRunningProcesses()
        {
            List<int> ProcessIDs = new List<int>();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains("WINWORD"))
                {
                    ProcessIDs.Add(clsProcess.Id);
                }
            }
            return ProcessIDs;
        }

        private void killProcesses(List<int> processesbeforegen, List<int> processesaftergen)
        {
            foreach (int pidafter in processesaftergen)
            {
                bool processfound = false;
                if (processesbeforegen != null)
                {
                    foreach (int pidbefore in processesbeforegen)
                    {
                        if (pidafter == pidbefore)
                        {
                            processfound = true;
                        }
                    }
                }
                if (processfound == false)
                {
                    Process clsProcess = Process.GetProcessById(pidafter);
                    clsProcess.Kill();
                }
            }
        }
        private void fProcessTest_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Bắt đầu");
            lbThongTin.Text = "";
            bgWorker1.RunWorkerAsync();
        }

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            MessageBox.Show("Đã hoàn thành", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            for (int i = progressBar1.Value; i < e.ProgressPercentage; i++)
            {
                progressBar1.Value = i;
                if (i <= 5)
                    lbThongTin.Text = "Đang mở tệp tin mẫu ...";
                else
                    lbThongTin.Text = "Đang tạo đề thi " + InfoTest.iDeThiDangTao.ToString();
            }
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (bgWorker1.CancellationPending)
                {
                    e.Cancel = true;
                }
                else
                {
                    //Lấy thông tin từ class static

                    if (InfoTest.DanhSachNhomCauHoi.Count == 0)
                    {
                        //MessageBox.Show("dto moi them = " + InfoTest.DanhSachNhomCauHoi[0].DuongDan + "; điểm = " + InfoTest.DanhSachNhomCauHoi[0].Diem.ToString());
                        MessageBox.Show("Không có dữ liệu", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //
                    string sKyThi = InfoTest.sKyThi;
                    string sMonThi = InfoTest.sMonThi;
                    string sDoiTuong = InfoTest.sDoiTuong;
                    string sHinhThucThi = InfoTest.sHinhThucThi;
                    string sThoiGian = InfoTest.sThoiGian;
                    string sNgayThangNamThi = InfoTest.sNgayThi +"/"+InfoTest.sThangThi +"/"+InfoTest.sNamThi;
                    int iSoDe = InfoTest.iSoDe;//_soDe là số đề cần tạo ra  Được tính từ MaDeTu và MaDeDen
                    //
                    ArrayList dsCauHoiBoDe = new ArrayList();
                    int iSoCauMax;//n là số câu max trong danh sách câu nhóm 1 
                    int k = 0;
                    int iPhanTramCongViec =0;//j là số % công việc đang thực hiện
                    //TẠO DANH SACH CÂU HỎI CHO BỘ ĐỀ ĐẢM BẢO YÊU CẦU
                    for (int iNhom = 0; iNhom < InfoTest.DanhSachNhomCauHoi.Count; iNhom++)//Làm từng đề lần lượt
                    {
                        iSoCauMax = InfoTest.DanhSachNhomCauHoi[iNhom].SoCau;
                        List<int> tmp = CreateListTest(iSoCauMax, iSoDe, k);
                        //string ds1 = "";
                        //foreach (int m in tmp)
                        //{
                        //    ds1 = ds1 + m.ToString() + " ";
                        //}
                        //MessageBox.Show("DS câu nhóm " + iNhom.ToString() +": " + ds1);
                        dsCauHoiBoDe.Add(tmp);
                        k++;
                    }
                    //% mở đề thi mẫu
                    bgWorker1.ReportProgress(5);
                    //Mở MS Word rồi tạo file đề thi để chuẩn bị copy nội dung
                    Word.Application wordApp = new Word.Application();
                    wordApp.Visible = false;
                    object filename = InfoTest.sThuMucDeMau + "\\DeThiMau3.docx";
                 
                    List<int> processesbeforegen = getRunningProcesses();
                    Word.Document docDeThiMau = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing); ;

                    Word.Document emptyDoc = null;//Tạo tệp tin đề thi
                    emptyDoc = wordApp.Documents.Add();
                    Word.Document emptyDoc1 = null;//Tạo tệp tin đáp án đề thi
                    emptyDoc1 = wordApp.Documents.Add();
                    string sTenDe = "";     
                    for (int _iSoDe = 0; _iSoDe < iSoDe; _iSoDe++) //Xét từng đề  
                    {
                        //% Tạo đề thi thứ nhất
                        bgWorker1.ReportProgress((_iSoDe+1) * 100 / iSoDe);
                        iPhanTramCongViec = iPhanTramCongViec + 100 / iSoDe;//Cập nhật % hiện đã hoàn thành
                        InfoTest.iDeThiDangTao = _iSoDe + 1;
                        //
                        docDeThiMau.Activate();
                        //Copy nội dung file mẫu
                        docDeThiMau.Sections.First.Range.Copy();
                        //Paste vào tệp tin ĐỀ THI
                        emptyDoc.Activate();
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara2 = emptyDoc.Content.Paragraphs.Add(ref oRng);
                        oPara2.Range.PasteAndFormat(Microsoft.Office.Interop.Word.WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng   
                        //Find and replace:
                        sTenDe = InfoTest.DanhSachTenDeThi[_iSoDe];//Lấy tên đề trong danh sách tên đề
                        //
                        while (sTenDe.Length < 2)
                        {
                            sTenDe = '0' + sTenDe;
                        }
                        this.FindAndReplace(wordApp, "$KYTHI$", sKyThi);
                        this.FindAndReplace(wordApp, "$MONTHI$", sMonThi);
                        this.FindAndReplace(wordApp, "$DOITUONG$", sDoiTuong);
                        this.FindAndReplace(wordApp, "$HINHTHUCTHI$", sHinhThucThi);
                        this.FindAndReplace(wordApp, "$THOIGIAN$", sThoiGian);
                        this.FindAndReplace(wordApp, "$NGAYTHI$", sNgayThangNamThi);
                        this.FindAndReplace(wordApp, "$MADE$", sTenDe.ToString());
                        //Paste vào tệp tin ĐÁP ÁN ĐỀ THI
                        emptyDoc1.Activate();
                        oRng = emptyDoc1.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara2 = emptyDoc1.Content.Paragraphs.Add(ref oRng);
                        oPara2.Range.PasteAndFormat(Microsoft.Office.Interop.Word.WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng   
                        //Find and replace:
                        sTenDe = InfoTest.DanhSachTenDeThi[_iSoDe];//Lấy tên đề trong danh sách tên đề
                        //
                        while (sTenDe.Length < 3)
                        {
                            sTenDe = '0' + sTenDe;
                        }
                        this.FindAndReplace(wordApp, "$KYTHI$", sKyThi);
                        this.FindAndReplace(wordApp, "$MONTHI$", sMonThi);
                        this.FindAndReplace(wordApp, "$DOITUONG$", sDoiTuong);
                        this.FindAndReplace(wordApp, "$HINHTHUCTHI$", sHinhThucThi);
                        this.FindAndReplace(wordApp, "$THOIGIAN$", sThoiGian);
                        this.FindAndReplace(wordApp, "$NGAYTHI$", sNgayThangNamThi);
                        this.FindAndReplace(wordApp, "$MADE$", sTenDe.ToString());
                        //Paste nội dung chi tiết
                        for (int i = 0; i < InfoTest.DanhSachNhomCauHoi.Count; i++)//Mở từng nhóm file
                        {
                            object _fileNhom = InfoTest.DanhSachNhomCauHoi[i].DuongDan;//Lấy đường dẫn nhóm file
                            Word.Document docNhom = null;
                            docNhom = wordApp.Documents.Open(ref _fileNhom, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing);
                            docNhom.Activate();
                            //---------------Paste ĐỀ THI
                            List<int> tt = (List<int>)dsCauHoiBoDe[i];
                            docNhom.Tables[tt[_iSoDe]].Rows[1].Cells[1].Range.Copy();//Lấy cùng vị trí câu trong từng nhóm câu hỏi                            
                            // Select the last table.
                            // For this demo, the table has size of 3*4 (row * column).
                            int totalTables = emptyDoc.Tables.Count;
                            Microsoft.Office.Interop.Word.Table tab = emptyDoc.Tables[totalTables];
                            Microsoft.Office.Interop.Word.Range range = tab.Range;
                            // Moves the cursor to the first cell of target row.
                            range.Start = tab.Rows[tab.Rows.Count].Cells[1].Range.Start;
                            range.End = range.Start;
                            // Paste values to target row.
                            range.Paste();
                            // Insert a new row after the last row.
                            if(i != InfoTest.DanhSachNhomCauHoi.Count - 1)
                                tab.Rows.Add(ref missing);
                            //-------------Kết thúc Paste ĐỀ THI
                            //-------------------------------------------------
                            //---------------Paste ĐÁP ÁN ĐỀ THI
                            List<int> tt1 = (List<int>)dsCauHoiBoDe[i];
                            docNhom.Tables[tt1[_iSoDe]].Range.Copy();//Lấy cùng vị trí câu trong từng nhóm câu hỏi                            
                            // Select the last table.
                            // For this demo, the table has size of 3*4 (row * column).
                            int totalTables1 = emptyDoc1.Tables.Count;
                            Microsoft.Office.Interop.Word.Table tab1 = emptyDoc1.Tables[totalTables];
                            Microsoft.Office.Interop.Word.Range range1 = tab1.Range;
                            // Moves the cursor to the first cell of target row.
                            range1.Start = tab1.Rows[tab1.Rows.Count].Cells[1].Range.Start;
                            range1.End = range1.Start;
                            // Paste values to target row.
                            range1.Paste();
                            //-------------Kết thúc Paste ĐÁP ÁN ĐỀ THI
                           
                            //
#region "Sao chép chỉ nội dung của cell"
                            //List<int> tt = (List<int>)dsCauHoiBoDe[i];
                            //var copyFrom = docNhom.Tables[tt[_iSoDe]].Rows[1].Cells[1].Range;//Lấy cùng vị trí câu trong từng nhóm câu hỏi                            
                            //int start = emptyDoc.Content.End - 1;
                            //int end = emptyDoc.Content.End;
                            //var copyTo = emptyDoc.Range(start, end);
                            //copyFrom.MoveEnd(Microsoft.Office.Interop.Word.WdUnits.wdCharacter, -1);
                            //copyTo.FormattedText = copyFrom.FormattedText;        
#endregion
                           
                            //----------------ĐỀ THI_Thay thế chữ "Câu hỏi" bằng "Câu 1 (2 điểm)"
                            string tenCauHoi = "";
                            int tenCau;
                            tenCau = i + 1;
                            tenCauHoi = InfoTest.sTenCau + " " + tenCau.ToString() + " (" + InfoTest.DanhSachNhomCauHoi[i].Diem + " điểm)";
                            emptyDoc.Activate();
                            this.FindAndReplace(wordApp, "Câu hỏi", tenCauHoi);
                            //-------------------ĐỀ THI-kết thúc
                            //----------------ĐÁP ÁN ĐỀ THI_Thay thế chữ "Câu hỏi" bằng "Câu 1 (2 điểm)"
                            
                            emptyDoc1.Activate();
                            this.FindAndReplace(wordApp, "Câu hỏi", tenCauHoi);
                            //-------------------ĐÁP ÁN ĐỀ THI-kết thúc
                            ////Thêm 1 mark dòng
                            //copyTo.InsertParagraphAfter();
                            //copyTo.SetRange(end, end);
                            //Close Document:                
                            docNhom.Close(ref missing, ref missing, ref missing);
                            //Kết thúc đọc file nhóm
                        }
                        //-----------ĐỀ THI - Thêm giải thích
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        if (InfoTest.sGiaiThich != "") //Nếu có thêm giải thích
                        {
                            oPara = emptyDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                            //oPara.Range.Font.Name = "Arial";
                            oPara.Range.Text = InfoTest.sGiaiThich; //"Không được sử dụng tài liệu"; //add some text in paragraph
                            oPara.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            oPara.Range.Font.Bold = 1;
                            oPara.Format.SpaceAfter = 10; //define some style
                            oPara.Range.InsertParagraphAfter();
                        }
                        if (_iSoDe != iSoDe - 1)
                        {
                            ////Thêm 1 ngắt trang, chuyển sang đề tiếp theo
                            wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                            wrdRng.InsertBreak(ref oPageBreak);
                        }
                        //-------------kết thúc ĐỀ THI - Thêm giải thích
                        //-----------ĐÁP ÁN ĐỀ THI - Thêm giải thích
                        oRng = emptyDoc1.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        if (InfoTest.sGiaiThich != "") //Nếu có thêm giải thích
                        {                            
                            oPara = emptyDoc1.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                            //oPara.Range.Font.Name = "Arial";
                            oPara.Range.Text = InfoTest.sGiaiThich; //"Không được sử dụng tài liệu"; //add some text in paragraph
                            oPara.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                            oPara.Range.Font.Bold = 1;
                            oPara.Format.SpaceAfter = 10; //define some style
                            oPara.Range.InsertParagraphAfter();
                        }
                        if (_iSoDe != iSoDe - 1)
                        {
                            ////Thêm 1 ngắt trang, chuyển sang đề tiếp theo
                            wrdRng = emptyDoc1.Bookmarks.get_Item(ref oEndOfDoc).Range;
                            wrdRng.InsertBreak(ref oPageBreak);
                        }
                        //-------------kết thúc ĐÁP ÁN ĐỀ THI - Thêm giải thích
                    }
                    //Save as: filename ĐỀ THI
                    if (!System.IO.Directory.Exists(InfoTest.sViTriLuuDeThi))
                        InfoTest.sViTriLuuDeThi = InfoTest.sThuMucGoc;
                    string name = sMonThi + string.Format("{0: ddMMyyyyhhmmss}", DateTime.Now);
                    object saveAs = InfoTest.sViTriLuuDeThi + "\\" + name + ".docx";
                    emptyDoc.SaveAs2(ref saveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    emptyDoc.Close(ref missing, ref missing, ref missing);
                    //Save as: filename ĐÁP ÁN ĐỀ THI                   
                    object saveAs1 = InfoTest.sViTriLuuDeThi + "\\" + name + "_dap_an" + ".docx";
                    emptyDoc1.SaveAs2(ref saveAs1, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    emptyDoc1.Close(ref missing, ref missing, ref missing);
                    //
                    docDeThiMau.Close(); //Đóng đề thi mẫu
                    wordApp.Quit();      //Thoát MS Word
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi 1: " + ex.Message + " source:"+ ex.Source);
            }
            finally
            {
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
            
        }
    }
}
