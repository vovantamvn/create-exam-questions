using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/////Add the references (new)
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
////

namespace ViDu1
{
    public partial class Form1 : Form
    {
        string fileDeThiMau, fileDeNhom1, fileDeNhom2, fileDeNhom3;
        List<int> dsNhom1, dsNhom2, dsNhom3, dsNhom4, dsNhom5;
        Word.Application wordApp;
        Word.Document aDoc_mau = null;
        Word.Document emptyDoc = null;
        object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
        object oPageBreak = Word.WdBreakType.wdPageBreak;
        object readOnly = true; //default
        object readOnly_T = true;
        object isVisible = false;
        object missing = Missing.Value;

        Word.Document aDoc_Nhom1 = null;
        Word.Document aDoc_Nhom2 = null;
        Word.Document aDoc_Nhom3 = null;
        Word.Paragraph oPara2;
        Word.Paragraph oPara;
        object oRng;
        Word.Range wrdRng;

        List<int> processesbeforegen;
        List<int> processesaftergen;
        public Form1()
        {
            InitializeComponent();
        }

        private void tEnabled(bool state)
        {
            btnTaoDeThi.Enabled = state;
            grpThongSo.Enabled = state;

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
                foreach (int pidbefore in processesbeforegen)
                {
                    if (pidafter == pidbefore)
                    {
                        processfound = true;
                    }
                }

                if (processfound == false)
                {
                    Process clsProcess = Process.GetProcessById(pidafter);
                    clsProcess.Kill();
                }
            }
        }

        private void btnMoDeMau_Click(object sender, EventArgs e)
        {
            processesbeforegen = getRunningProcesses();
            OpenFileDialog ofdDeThiMau = new OpenFileDialog();
            ofdDeThiMau.Title = "Mở đề thi mẫu";
            ofdDeThiMau.Filter = "Word Files|*.doc; *.docx";
            if (ofdDeThiMau.ShowDialog() == DialogResult.OK)
            {
                fileDeThiMau = ofdDeThiMau.FileName;
                txtDeThiMau.Text = fileDeThiMau;
                tEnabled(true);
                //
            }
            else
                return;
        }        

        private void btnChonNhom1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofdDeNhom1 = new OpenFileDialog();
                ofdDeNhom1.Title = "Mở nhóm câu hỏi 1";
                ofdDeNhom1.Filter = "Word Files|*.doc; *.docx";


                if (ofdDeNhom1.ShowDialog() == DialogResult.OK)
                {
                    fileDeNhom1 = ofdDeNhom1.FileName;
                    txtDeNhom1.Text = fileDeNhom1;
                }
                else
                    return;
                List<int> lst1 = new List<int>();
                int Numrd;
                int n;//n là số câu max trong danh sách câu nhóm 1
                int _soDe;//_soDe là số đề cần tạo ra   
                int k = 0;
                //fProgress frm = new fProgress();
                //frm.EnableTimer = true;
                //frm.Show();
                Word.Application w1 = new Word.Application();
                w1.Visible = false;
                object _fileDeNhom1 = fileDeNhom1;
                aDoc_Nhom1 = w1.Documents.Open(ref _fileDeNhom1, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing);
                n = aDoc_Nhom1.Tables.Count;
                _soDe = Convert.ToInt32(txtSoDe.Text);
                dsNhom1 = CreateListTest(n, _soDe, k);
                aDoc_Nhom1.Close();
                w1.Quit();
                //frm.Close();
            }
            catch(Exception ex)
            {

            }            
            finally
            {
                // Release all Interop objects.
                if (aDoc_Nhom1 != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(aDoc_Nhom1);
                if (wordApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                aDoc_Nhom1 = null;
                wordApp = null;
                GC.Collect();
            }

        }
        int KiemTra(int m, List<int> ds)
        {
            int i=0, _out = 0;
            if (ds.Count == 0)
                _out = 0;
            for(i=0;i<ds.Count; i++)
            {
                if (m == ds[i])
                {
                    _out = 1;
                    break;
                }
            }
            return _out;
        }
        private void btnChonNhom2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDeNhom2 = new OpenFileDialog();
            ofdDeNhom2.Title = "Mở nhóm câu hỏi 2";
            ofdDeNhom2.Filter = "Word Files|*.doc; *.docx";
            if (ofdDeNhom2.ShowDialog() == DialogResult.OK)
            {
                fileDeNhom2 = ofdDeNhom2.FileName;
                txtDeNhom2.Text = fileDeNhom2;
            }
            else
                return;
            dsNhom2 = new List<int>();
            int i = 0;
            dsNhom2.Add(2);
            dsNhom2.Add(5);
            dsNhom2.Add(1);
            dsNhom2.Add(3);
        }

        private void btnChonNhom3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdDeNhom3 = new OpenFileDialog();
            ofdDeNhom3.Title = "Mở nhóm câu hỏi 3";
            ofdDeNhom3.Filter = "Word Files|*.doc; *.docx";
            if (ofdDeNhom3.ShowDialog() == DialogResult.OK)
            {
                fileDeNhom3 = ofdDeNhom3.FileName;
                txtDeNhom3.Text = fileDeNhom3;
            }
            else
                return;
            dsNhom3 = new List<int>();
            int i = 0;
            dsNhom3.Add(3);
            dsNhom3.Add(1);
            dsNhom3.Add(2);
            dsNhom3.Add(9);
        }

        //Methode Find and Replace:
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

        private void btnTaoDeThi_Click(object sender, EventArgs e)
        {
           
        }

        SaveFileDialog sfdTaoDeThi;

        private void btnTest_Click(object sender, EventArgs e)
        {            
            try
            {        
                sfdTaoDeThi = new SaveFileDialog();
                if (sfdTaoDeThi.ShowDialog() == DialogResult.OK)
                {
                    bgWorker1.RunWorkerAsync();
                    //CreateWordDocument1(txtDeThiMau.Text, sfdTaoDeThi.FileName);
                    //tEnabled(false);

                }
                else
                    return;   
            }
            catch (Exception ex)
            {
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
                     
            
        }

        //private void CreateWordDocument1(object filename, object savaAs)
        //{
        //    List<int> processesbeforegen = getRunningProcesses();            
        //    string tempPath = null;
        //    Word.Application wordApp = new Word.Application();
        //    Word.Document aDoc_mau = null;
        //    object readOnly = false; //default
        //    object readOnly_T = true;
        //    object isVisible = false;
        //    object missing = Missing.Value;
        //    int iTenDe = 0;
        //    Word.Document aDoc_Nhom1 = null;
        //    Word.Document aDoc_Nhom2 = null;
        //    Word.Document aDoc_Nhom3 = null;
        //    Word.Document emptyDoc = null;
        //    Word.Paragraph oPara2;
        //    Word.Paragraph oPara;
        //    object oRng;
        //    Word.Range wrdRng;
        //    object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */
        //    object oPageBreak = Word.WdBreakType.wdPageBreak;
            
        //    if (File.Exists((string)filename))
        //    {
        //        wordApp.Visible = false;
        //        //Mở file mẫu
        //        aDoc_mau = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing,
        //                                    ref missing, ref missing, ref missing, ref missing);

        //        //aDoc_mau.Activate();
        //        ////Copy nội dung file mẫu
        //        //aDoc_mau.Sections.First.Range.Copy();
        //        emptyDoc = wordApp.Documents.Add();
        //        object _fileDeNhom1 = fileDeNhom1;

                
        //        for (int i = 0; i < dsNhom1.Count; i++)
        //        {
        //            aDoc_mau.Activate();
        //            //Copy nội dung file mẫu
        //            aDoc_mau.Sections.First.Range.Copy();                    
        //            //
        //            emptyDoc.Activate();
        //            oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            oPara2 = emptyDoc.Content.Paragraphs.Add(ref oRng);
        //            //oPara2.Range.Text = "Heading 1";
        //            //oPara2.Range.Paste(); //paste tiêu đề đề thi
        //            oPara2.Range.PasteAndFormat(WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng
        //            //oPara2.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        //            //oPara2.Format.SpaceAfter = 6;
        //            //oPara2.Range.InsertParagraphAfter();
        //            //
        //            //wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            //wrdRng.InsertBreak(ref oPageBreak);
        //            //
        //            //Find and replace:
        //            iTenDe++;
        //            this.FindAndReplace(wordApp, "<HOCKY>", txtHocKy.Text);
        //            this.FindAndReplace(wordApp, "<HocPhan>", txtHocPhan.Text);
        //            this.FindAndReplace(wordApp, "<DoiTuong>", txtDoiTuong.Text);
        //            this.FindAndReplace(wordApp, "<HinhThucThi>", txtHinhThucThi.Text);
        //            this.FindAndReplace(wordApp, "<ThoiGian>", txtThoiGian.Text);
        //            this.FindAndReplace(wordApp, "<NgayThi>", dtpNgayThi.Value.ToShortDateString());
        //            this.FindAndReplace(wordApp, "<STTDeThi>", iTenDe.ToString());

        //            //Mở file nhóm đề 1 để copy vào file mẫu
        //            #region "Mở file nhóm đề 1 để copy vào file mẫu"
        //            aDoc_Nhom1 = wordApp.Documents.Open(ref _fileDeNhom1, ref missing, ref readOnly,
        //                                        ref missing, ref missing, ref missing,
        //                                        ref missing, ref missing, ref missing,
        //                                        ref missing, ref missing, ref missing,
        //                                        ref missing, ref missing, ref missing, ref missing);
        //            aDoc_Nhom1.Activate();
        //            //
        //            var copyFrom = aDoc_Nhom1.Tables[dsNhom1[i]].Rows[1].Cells[1].Range;
        //            int start = emptyDoc.Content.End - 1;
        //            int end = emptyDoc.Content.End;
        //            var copyTo = emptyDoc.Range(start, end);
        //            copyFrom.MoveEnd(WdUnits.wdCharacter, -1);
        //            copyTo.FormattedText = copyFrom.FormattedText;
        //            //Thêm 1 ngắt trang nữa
        //            //wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            //wrdRng.InsertBreak(ref oPageBreak);
        //            copyTo.InsertParagraphAfter();
        //            copyTo.InsertParagraphAfter();
        //            copyTo.SetRange(end, end);
        //            //oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            //oPara = emptyDoc.Content.Paragraphs.Add(ref oRng);
        //            //aDoc_Nhom1.Tables[dsNhom1[i]].Cell(1, 1).Range.Copy();
        //            //oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
        //            //oPara2 = emptyDoc.Content.Paragraphs.Add(ref oRng);
        //            //oPara2.Range.PasteAndFormat(WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng
        //            //Close Document:                
        //            aDoc_Nhom1.Close(ref missing, ref missing, ref missing);
                    
        //        }
                
        //        //Save as: filename
        //        emptyDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing,
        //                ref missing, ref missing, ref missing);
        //        emptyDoc.Close(ref missing, ref missing, ref missing);
        //        #endregion

        //    }
        //    else
        //    {
        //        MessageBox.Show("file dose not exist.");
        //        return;
        //    }

        //    //Close Document:
        //    aDoc_mau.Close(ref missing, ref missing, ref missing);           
        //    MessageBox.Show("File created.");
        //    List<int> processesaftergen = getRunningProcesses();
        //    killProcesses(processesbeforegen, processesaftergen);
            
        //}
        
        private void CreateWordDocument1(object filename, object savaAs)
        {
            try
            {
                //List<int> processesbeforegen = getRunningProcesses();
                int iTenDe = 0;
                wordApp = new Word.Application();
                aDoc_mau = null;
                wordApp.Visible = false;               
                if (File.Exists((string)filename))
                {
                    aDoc_mau = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                    object _fileDeNhom1 = fileDeNhom1;
                    object _fileDeNhom2 = fileDeNhom2;
                    object _fileDeNhom3 = fileDeNhom3;
                    emptyDoc = wordApp.Documents.Add();
                    int _numDe = Convert.ToInt32(txtSoDe.Text);
                    for (int i = 0; i < _numDe; i++)
                    {

                        aDoc_mau.Activate();
                        //aDoc_mau = wordApp.ActiveDocument;                    
                        //Copy nội dung file mẫu
                        aDoc_mau.Sections.First.Range.Copy();
                        emptyDoc.Activate();
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara2 = emptyDoc.Content.Paragraphs.Add(ref oRng);
                        oPara2.Range.PasteAndFormat(WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng   
                        //Find and replace:
                        iTenDe++;
                        this.FindAndReplace(wordApp, "<HOCKY>", txtHocKy.Text);
                        this.FindAndReplace(wordApp, "<HocPhan>", txtHocPhan.Text);
                        this.FindAndReplace(wordApp, "<DoiTuong>", txtDoiTuong.Text);
                        this.FindAndReplace(wordApp, "<HinhThucThi>", txtHinhThucThi.Text);
                        this.FindAndReplace(wordApp, "<ThoiGian>", txtThoiGian.Text);
                        this.FindAndReplace(wordApp, "<NgayThi>", dtpNgayThi.Value.ToShortDateString());
                        this.FindAndReplace(wordApp, "<STTDeThi>", iTenDe.ToString());

                        //Mở file nhóm đề 1 để copy vào file mẫu
                      
                        aDoc_Nhom1 = wordApp.Documents.Open(ref _fileDeNhom1, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom1.Activate();
                        //
                        var copyFrom = aDoc_Nhom1.Tables[dsNhom1[i]].Rows[1].Cells[1].Range;
                        int start = emptyDoc.Content.End - 1;
                        int end = emptyDoc.Content.End;
                        var copyTo = emptyDoc.Range(start, end);
                        copyFrom.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo.FormattedText = copyFrom.FormattedText;
                        //Thay thế chữ "Câu hỏi" bằng "Câu 1 (2 điểm)"
                        //copyTo.SetRange(start + 7, start + 7);
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 1 (2 điểm)");

                        //Thêm 1 ngắt trang nữa
                        //wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        //wrdRng.InsertBreak(ref oPageBreak);
                        //Thêm 2 mark dòng
                        copyTo.InsertParagraphAfter();
                        //copyTo.InsertParagraphAfter();
                        copyTo.SetRange(end, end);
                        //Close Document:                
                        aDoc_Nhom1.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 1

                        //Mở file nhóm đề 2 để copy vào file mẫu
    
                        aDoc_Nhom2 = wordApp.Documents.Open(ref _fileDeNhom2, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom2.Activate();
                        //
                        var copyFrom2 = aDoc_Nhom2.Tables[dsNhom2[i]].Rows[1].Cells[1].Range;
                        var start2 = emptyDoc.Content.End - 1;
                        var end2 = emptyDoc.Content.End;
                        var copyTo2 = emptyDoc.Range(start2, end2);
                        copyFrom2.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo2.FormattedText = copyFrom2.FormattedText;
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 2 (4 điểm)");
                        //Thêm 1 ngắt trang nữa
                        //wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        //wrdRng.InsertBreak(ref oPageBreak);
                        //Thêm 2 mark dòng
                        copyTo2.InsertParagraphAfter();
                        //copyTo2.InsertParagraphAfter();
                        copyTo2.SetRange(end2, end2);
                        //Close Document:                
                        aDoc_Nhom2.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 2

                        aDoc_Nhom3 = wordApp.Documents.Open(ref _fileDeNhom3, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom3.Activate();
                        //
                        var copyFrom3 = aDoc_Nhom3.Tables[dsNhom3[i]].Rows[1].Cells[1].Range;
                        var start3 = emptyDoc.Content.End - 1;
                        var end3 = emptyDoc.Content.End;
                        var copyTo3 = emptyDoc.Range(start3, end3);
                        copyFrom3.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo3.FormattedText = copyFrom3.FormattedText;
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 3 (4 điểm)");
                        //Thêm 1 ngắt trang nữa
                        //wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        //wrdRng.InsertBreak(ref oPageBreak);
                        //Thêm 2 mark dòng
                        copyTo3.InsertParagraphAfter();
                        //copyTo3.InsertParagraphAfter();
                        copyTo3.SetRange(end3, end3);
                        //Close Document:                
                        aDoc_Nhom3.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 3
                        //Thêm text  ghi chú sử dụng tài liệu
                        //var start4 = emptyDoc.Content.End - 1;
                        //var end4 = emptyDoc.Content.End;
                        //var copyTo4 = emptyDoc.Range(start4, end4);
                        //copyTo4.SetRange(end4, end4);
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara = emptyDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                        oPara.Range.Text = "Không được sử dụng tài liệu"; //add some text in paragraph
                        oPara.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        oPara.Range.Font.Bold = 1;
                        oPara.Format.SpaceAfter = 10; //define some style
                        oPara.Range.InsertParagraphAfter(); 

                    }

                    //Save as: filename
                    emptyDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    emptyDoc.Close(ref missing, ref missing, ref missing);


                }
                else
                {
                    MessageBox.Show("file dose not exist.");
                    return;
                }

                //Close Document:
                aDoc_mau.Close(ref missing, ref missing, ref missing);
                //MessageBox.Show("File created.");
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
                emptyDoc.Close(ref missing, ref missing, ref missing);
                aDoc_mau.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom1.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom2.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom3.Close(ref missing, ref missing, ref missing);
                wordApp.Quit();
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
            finally
            {
                // Release all Interop objects.
                if (aDoc_Nhom1 != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(aDoc_Nhom1);
                if (wordApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                aDoc_Nhom1 = null;
                wordApp = null;
                GC.Collect();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //processesaftergen = getRunningProcesses();
            //killProcesses(processesbeforegen, processesaftergen);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsNhom1 = CreateListTest(10, 12, 0);            
            dsNhom2 = CreateListTest(9, 12, 1);
            dsNhom3 = CreateListTest(7, 12, 2);
            dsNhom4 = CreateListTest(11, 12, 3);
            dsNhom5 = CreateListTest(10, 12, 4);
            string _out = "";
            for (int j = 0; j < dsNhom1.Count; j++)
            {
                _out = _out + "(" + dsNhom1[j] + ", " + dsNhom2[j] + ", " + dsNhom3[j] + ", " + dsNhom4[j] + ", " + dsNhom5[j] + ")\r\n";
            }
            MessageBox.Show(_out);          
        }

        private List<int> CreateListTest(int n, int _soDe, int k)
        {
            List<int> lst_out = new List<int>();
            //n là số câu max trong danh sách câu nhóm 1
            //_soDe là số đề cần tạo ra
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
            //MessageBox.Show("DS 10 phan tu: " + ds + "\nds cuoi cung: " + ds1);
            return lst_out;
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    if (bgWorker1.CancellationPending)
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {
            //        async();                    
            //        bgWorker1.ReportProgress(i);
            //    }

            //}     
            //CreateWordDocument1(txtDeThiMau.Text, sfdTaoDeThi.FileName);
            //tEnabled(false);
            try
            {
                //List<int> processesbeforegen = getRunningProcesses();
                object filename = txtDeThiMau.Text;
                object saveAs = sfdTaoDeThi.FileName;
                //
                int iTenDe = 0;
                wordApp = new Word.Application();
                aDoc_mau = null;
                wordApp.Visible = false;
                if (File.Exists((string)filename))
                {
                    aDoc_mau = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing,
                                                ref missing, ref missing, ref missing, ref missing);
                    object _fileDeNhom1 = fileDeNhom1;
                    object _fileDeNhom2 = fileDeNhom2;
                    object _fileDeNhom3 = fileDeNhom3;
                    emptyDoc = wordApp.Documents.Add();
                    int _numDe = Convert.ToInt32(txtSoDe.Text);
                    int _soLuot = 0;//lưu lại % của tiến trình trước
                    for (int i = 0; i < _numDe; i++)
                    {

                        aDoc_mau.Activate();
                        //aDoc_mau = wordApp.ActiveDocument;                    
                        //Copy nội dung file mẫu
                        aDoc_mau.Sections.First.Range.Copy();
                        emptyDoc.Activate();
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara2 = emptyDoc.Content.Paragraphs.Add(ref oRng);
                        oPara2.Range.PasteAndFormat(WdRecoveryType.wdFormatOriginalFormatting);//paste tiêu đề và giữa nguyên định dạng   
                        //Find and replace:
                        iTenDe++;
                        this.FindAndReplace(wordApp, "$KYTHI$", txtHocKy.Text);
                        this.FindAndReplace(wordApp, "$MONTHI$", txtHocPhan.Text);
                        this.FindAndReplace(wordApp, "$DOITUONG$", txtDoiTuong.Text);
                        this.FindAndReplace(wordApp, "$HINHTHUCTHI$", txtHinhThucThi.Text);
                        this.FindAndReplace(wordApp, "$THOIGIAN$", txtThoiGian.Text);
                        this.FindAndReplace(wordApp, "$NGAYTHI$", dtpNgayThi.Value.ToShortDateString());
                        this.FindAndReplace(wordApp, "$NGAYTHI$", iTenDe.ToString());

                        //Mở file nhóm đề 1 để copy vào file mẫu                     
                        aDoc_Nhom1 = wordApp.Documents.Open(ref _fileDeNhom1, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom1.Activate();
                        //
                        var copyFrom = aDoc_Nhom1.Tables[dsNhom1[i]].Rows[1].Cells[1].Range;
                        int start = emptyDoc.Content.End - 1;
                        int end = emptyDoc.Content.End;
                        var copyTo = emptyDoc.Range(start, end);
                        copyFrom.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo.FormattedText = copyFrom.FormattedText;
                        //Thay thế chữ "Câu hỏi" bằng "Câu 1 (2 điểm)"
                        //copyTo.SetRange(start + 7, start + 7);
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 1 (2 điểm)");
                        //Thêm 1 mark dòng
                        copyTo.InsertParagraphAfter();
                        copyTo.SetRange(end, end);
                        //Close Document:                
                        aDoc_Nhom1.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 1

                        //Mở file nhóm đề 2 để copy vào file mẫu

                        aDoc_Nhom2 = wordApp.Documents.Open(ref _fileDeNhom2, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom2.Activate();
                        //
                        var copyFrom2 = aDoc_Nhom2.Tables[dsNhom2[i]].Rows[1].Cells[1].Range;
                        var start2 = emptyDoc.Content.End - 1;
                        var end2 = emptyDoc.Content.End;
                        var copyTo2 = emptyDoc.Range(start2, end2);
                        copyFrom2.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo2.FormattedText = copyFrom2.FormattedText;
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 2 (4 điểm)");
                        //Thêm 1 mark dòng
                        copyTo2.InsertParagraphAfter();
                        //copyTo2.InsertParagraphAfter();
                        copyTo2.SetRange(end2, end2);
                        //Close Document:                
                        aDoc_Nhom2.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 2

                        aDoc_Nhom3 = wordApp.Documents.Open(ref _fileDeNhom3, ref missing, ref readOnly,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing,
                                                    ref missing, ref missing, ref missing, ref missing);
                        aDoc_Nhom3.Activate();
                        //
                        var copyFrom3 = aDoc_Nhom3.Tables[dsNhom3[i]].Rows[1].Cells[1].Range;
                        var start3 = emptyDoc.Content.End - 1;
                        var end3 = emptyDoc.Content.End;
                        var copyTo3 = emptyDoc.Range(start3, end3);
                        copyFrom3.MoveEnd(WdUnits.wdCharacter, -1);
                        copyTo3.FormattedText = copyFrom3.FormattedText;
                        this.FindAndReplace(wordApp, "Câu hỏi", "Câu 3 (4 điểm)");
                        //Thêm 1 mark dòng
                        copyTo3.InsertParagraphAfter();
                        copyTo3.SetRange(end3, end3);
                        //Close Document:                
                        aDoc_Nhom3.Close(ref missing, ref missing, ref missing);
                        //Kết thúc đọc file nhóm 3
                        //Thêm text  ghi chú sử dụng tài liệu
                        //var start4 = emptyDoc.Content.End - 1;
                        //var end4 = emptyDoc.Content.End;
                        //var copyTo4 = emptyDoc.Range(start4, end4);
                        //copyTo4.SetRange(end4, end4);
                        oRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        oPara = emptyDoc.Content.Paragraphs.Add(ref oRng); //add paragraph at end of document
                        oPara.Range.Text = "Không được sử dụng tài liệu"; //add some text in paragraph
                        oPara.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                        oPara.Range.Font.Bold = 1;
                        oPara.Format.SpaceAfter = 10; //define some style
                        oPara.Range.InsertParagraphAfter();
                        wrdRng = emptyDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                        wrdRng.InsertBreak(ref oPageBreak);
                        //
                        
                        if (bgWorker1.CancellationPending)
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            async();
                            int j;
                            for (j = _soLuot; j < (i + 1) * 100 / _numDe; j++)
                                bgWorker1.ReportProgress(j);
                            _soLuot = j+1;
                                //bgWorker1.ReportProgress((i + 1) * 100 / _numDe);
                        }

                    }

                    //Save as: filename
                    emptyDoc.SaveAs2(ref saveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);
                    emptyDoc.Close(ref missing, ref missing, ref missing);


                }
                else
                {
                    MessageBox.Show("file dose not exist.");
                    return;
                }

                //Close Document:
                aDoc_mau.Close(ref missing, ref missing, ref missing);
                //MessageBox.Show("File created.");
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");
                emptyDoc.Close(ref missing, ref missing, ref missing);
                aDoc_mau.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom1.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom2.Close(ref missing, ref missing, ref missing);
                aDoc_Nhom3.Close(ref missing, ref missing, ref missing);
                wordApp.Quit();
                processesaftergen = getRunningProcesses();
                killProcesses(processesbeforegen, processesaftergen);
            }
        }
        public void async()
        {
            Thread.Sleep(100);
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lbl1.Text = e.ProgressPercentage.ToString() + " % completed";
        }

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The program is stopped");
            }
            else
            {
                //CreateWordDocument1(txtDeThiMau.Text, sfdTaoDeThi.FileName);
                //tEnabled(false);
                MessageBox.Show("Đã hoàn thành");
            }
        }

    }
}
