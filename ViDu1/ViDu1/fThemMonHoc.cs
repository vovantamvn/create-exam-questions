using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViDu1.BusinessObject;
using ViDu1.DataAccess;

namespace ViDu1
{
    public partial class fThemMonHoc : Form
    {
        public bool Them;
        fMain _fMain;
        MonHocDto dto;
        string idKhoa;
        public fThemMonHoc()
        {
            InitializeComponent();
        }
        public fThemMonHoc(fMain _f)
        {
            InitializeComponent();
            _fMain = _f;
            dto = new MonHocDto();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            if(Them)
            {
                _fMain.ThemMonHoc(txtMaMonHoc.Text, txtTenMonHoc.Text);
            }
            else
            {
                int idMonHoc = Convert.ToInt32(lbIDMonHoc.Text);
                _fMain.SuaMonHoc(idMonHoc, txtMaMonHoc.Text, txtTenMonHoc.Text, idKhoa);
            }
            this.Close();
        }

        private void fThemMonHoc_Load(object sender, EventArgs e)
        {
            if(Them)//Thêm môn học mới
            {
                txtMaMonHoc.Text = "";
                txtTenMonHoc.Text = "";
            }
            else//Sửa môn học
            {
                dto = _fMain.LayMonHoc();
                txtMaMonHoc.Text = dto.MaMonHoc;
                txtTenMonHoc.Text = dto.TenMonHoc;
                lbIDMonHoc.Text = dto.IDMonHoc.ToString();
                idKhoa = dto.IDKhoa;
            }
        }
    }
}
