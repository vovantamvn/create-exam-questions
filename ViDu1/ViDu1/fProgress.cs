using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;

namespace ViDu1
{
    public partial class fProgress : Form
    {
        private bool _enableTimer;
        List<int> dsNhom1;
        //
        object readOnly = false; //default
        object isVisible = false;
        object missing = Missing.Value;
        OpenFileDialog ofdDeNhom1;
        string fileDeNhom1;
        //
        public bool EnableTimer
        {
            get { return _enableTimer; }
            set { _enableTimer = value; }
        }
        public fProgress()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.PerformStep();
            //if (progressBar1.Value == progressBar1.Maximum)
            //{
            //    timer1.Enabled = false;
            //    this.Close();
            //}
            
        }

        private void StartWork()
        {
            
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
            //MessageBox.Show("DS 10 phan tu: " + ds + "\nds cuoi cung: " + ds1);
            return lst_out;
        }

        private void fProgress_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bắt đầu");
            bgWorker1.RunWorkerAsync();
            //ofdDeNhom1 = new OpenFileDialog();
            //ofdDeNhom1.Title = "Mở nhóm câu hỏi 1";
            //ofdDeNhom1.Filter = "Word Files|*.doc; *.docx";
            //if (ofdDeNhom1.ShowDialog() == DialogResult.OK)
            //{
            //    fileDeNhom1 = ofdDeNhom1.FileName;
            //}
            //else
            //    return;
        }

        private void bgWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã hoàn thành");
            this.Close();
        }

        private void bgWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bgWorker1.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {                
                int j;
                
                List<int> lst1 = new List<int>();
                int Numrd;
                int n;//n là số câu max trong danh sách câu nhóm 1
                int _soDe;//_soDe là số đề cần tạo ra   
                int k = 0;
                for (j = 0; j <= 10; j++)
                {
                    bgWorker1.ReportProgress(j);
                }
                Word.Application w1 = new Word.Application();
                w1.Visible = false;
                Word.Document aDoc_Nhom1;
                object _fileDeNhom1 = @"E:\3. LAP TRINH\1. TRON DE THI\Nhom 1 (2Đ).docx";
                for (j = 0; j <= 50; j++)
                {
                    bgWorker1.ReportProgress(j);
                }
                //label1.Text = "Đang mở file Nhóm 1 (2Đ)...";
                aDoc_Nhom1 = w1.Documents.Open(ref _fileDeNhom1, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing);
                n = aDoc_Nhom1.Tables.Count;
                _soDe = 3;
                for (j = 51; j <= 100; j++)
                {
                    bgWorker1.ReportProgress(j);
                }
                //label1.Text = "Đang tạo danh sách đề...";
                dsNhom1 = CreateListTest(n, _soDe, k);
                aDoc_Nhom1.Close();
                w1.Quit();
                
                
            }
        }

        private void bgWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if(e.ProgressPercentage<=10)
                label2.Text = "Đang mở MS Word...";
            else if(e.ProgressPercentage<=50)
                label2.Text = "Đang mở file Nhóm 1 (2Đ)...";
            else if(e.ProgressPercentage<=100)
                label2.Text = "Đang tạo danh sách đề...";

        }
    }
}
