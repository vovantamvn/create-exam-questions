using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ViDu1.DataAccess;
using ViDu1.BusinessObject;

namespace ViDu1
{
    public partial class fEditItemListViewFile : Form
    {
        ConnectData conn = new ConnectData();
        fMain _fMain;
        string tenFile="";
        private bool _them;
        public bool Them
        {
            get { return _them; }
            set { _them = value; }
        }
        public fEditItemListViewFile()
        {
            InitializeComponent();
        }
        public fEditItemListViewFile(fMain _f)
        {
            InitializeComponent();
            _fMain = _f; 
        }
        private void fEditItemListViewFile_Load(object sender, EventArgs e)
        {
            DataTable dt = conn.GetDataTable("select * from tKieu");
            cbKieu.DataSource = dt;
            cbKieu.ValueMember = "ID";
            cbKieu.DisplayMember = "TenKieu";
            cbKieu.SelectedIndex = 0;
            if(!Them)
            {
                NhomCauHoiDto dto = new NhomCauHoiDto();
                dto = _fMain.LayNhomCauHoiTuListView();
                txtTenFile.Text = dto.TenFile;//Tên file
                nudSoCau.Value = Convert.ToDecimal(dto.SoCauMacDinh);//Số câu đc chọn
                nudDiem.Value = dto.Diem;//Điểm
                cbLoaiKho.Text = dto.LoaiKho.ToString();//Loại khó
                lbDuongDan.Text = dto.DuongDan;
                cbKieu.SelectedValue = dto.IdKieu;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtTenFile.Text != "")
            {
                
                _fMain.SuaFileNhomListView(txtTenFile.Text, lbDuongDan.Text, cbKieu.Text, nudDiem.Value, Convert.ToInt32(cbLoaiKho.Text), Convert.ToInt32(nudSoCau.Value));
                this.Close();
            }
            else
                MessageBox.Show("Chưa chọn file câu hỏi", "Thông báo");
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = InfoTest.sThuMucGoc;
            if(ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                if (ofd.FileName != "")
                {
                    tenFile = ofd.FileName.Substring(ofd.FileName.LastIndexOf("\\")+1);
                    txtTenFile.Text = tenFile;
                    lbDuongDan.Text = ofd.FileName;                    
                }
            }
        }
    }
}
