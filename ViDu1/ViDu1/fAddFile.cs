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
using System.Windows.Forms;

namespace ViDu1
{
    public partial class fAddFile : Form
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
        public fAddFile()
        {
            InitializeComponent();
        }
        public fAddFile(fMain _f)
        {
            InitializeComponent();
            _fMain = _f; 
        }
        private void fAddFile_Load(object sender, EventArgs e)
        {
            DataTable dt = conn.GetDataTable("select * from tKieu");
            cbKieu.DataSource = dt;
            cbKieu.ValueMember = "ID";
            cbKieu.DisplayMember = "TenKieu";            
            if(!Them)//Sửa nhóm câu hỏi
            {
                NhomCauHoiDao _dao = new NhomCauHoiDao();
                int idNhomCauHoi = 0;                
                idNhomCauHoi = _fMain.LayMaNhomCauHoi();

                DataTable _dTable = _dao.LayDSNhomCauHoiTheoID(idNhomCauHoi);
                foreach (DataRow row in _dTable.Rows)
                {                    
                    txtTenFile.Text = row["TenFile"].ToString();
                    //tenFile = row["TenFile"].ToString();
                    cbKieu.SelectedValue = row["IDKieu"];
                    lbDuongDan.Text = row["DuongDan"].ToString();
                    txtTenFile.Text = lbDuongDan.Text.Substring(lbDuongDan.Text.LastIndexOf("\\") + 1);
                    nudDiem.Value = Convert.ToDecimal(row["Diem"]);
                    cbLoaiKho.SelectedText = Convert.ToString(row["LoaiKho"]);
                    nudSoCau.Value = Convert.ToInt32(row["SoCauMacDinh"]);
                }
            }
            else//Thêm nhóm câu hỏi
            {
                cbKieu.SelectedIndex = 0;
                cbLoaiKho.SelectedIndex = 0;
                nudSoCau.Value = 1;
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (txtTenFile.Text != "")
            {
                if(Them)
                    _fMain.ThemFileNhom(txtTenFile.Text, "", lbDuongDan.Text, Convert.ToInt32(cbKieu.SelectedValue), nudDiem.Value, Convert.ToInt32(cbLoaiKho.Text), Convert.ToInt32(nudSoCau.Value));
                else
                    _fMain.SuaFileNhom(txtTenFile.Text, "", lbDuongDan.Text, Convert.ToInt32(cbKieu.SelectedValue), nudDiem.Value, Convert.ToInt32(cbLoaiKho.Text), Convert.ToInt32(nudSoCau.Value));
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
