using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViDu1.DataAccess;

namespace ViDu1
{
    public partial class fInfoTest : Form
    {
        public fInfoTest()
        {
            InitializeComponent();
        }

        private void btnTaoThongTinDeThi_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudThoiGianThi.Value > 0)
                    InfoTest.sThoiGian = nudThoiGianThi.Value.ToString();
                else
                {
                    MessageBox.Show("Hãy nhập THỜI GIAN THI!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!string.IsNullOrEmpty(txtDoiTuongThi.Text))
                    InfoTest.sDoiTuong = txtDoiTuongThi.Text.ToUpper();
                else
                {
                    
                }
                InfoTest.sHinhThucThi = cbHinhThucThi.Text;
                InfoTest.sThoiGian = nudThoiGianThi.Value.ToString();
                InfoTest.sTenCau = cbTenCau.Text;                
                InfoTest.bThemGiaiThich = chkThemGiaiThich.Checked;
                if (chkThemGiaiThich.Checked)
                    InfoTest.sGiaiThich = cbGiaiThich.Text;
                else
                    InfoTest.sGiaiThich = "";
                if (chkHienThiTieuDeNhom.Checked)
                    InfoTest.bTieuDeNhom = chkHienThiTieuDeNhom.Checked;
                
                if(nudNgayThi.Value < 10)
                    InfoTest.sNgayThi="0"+nudNgayThi.Value.ToString();
                else
                    InfoTest.sNgayThi = nudNgayThi.Value.ToString();
                if(nudThangThi.Value < 10)
                    InfoTest.sThangThi="0"+nudThangThi.Value.ToString();
                else
                    InfoTest.sThangThi = nudThangThi.Value.ToString();
                InfoTest.sNamThi = nudNamThi.Value.ToString();
                if(string.IsNullOrEmpty(txtMaDeTuDen.Text))
                {
                    InfoTest.iSoDe = (int)(nudMaDeDen.Value - nudMaDeTu.Value + 1);
                    InfoTest.iCauBatDau = (int) nudCauBatDau.Value;
                    InfoTest.DanhSachTenDeThi.Clear();
                    for(int ii = 0; ii<InfoTest.iSoDe;ii++)
                    {
                        int _iDe;
                        _iDe = ii + InfoTest.iCauBatDau;
                        InfoTest.DanhSachTenDeThi.Add(_iDe.ToString());
                    }
                }
                else
                {
                    string[] lstTenDeThi = txtMaDeTuDen.Text.Split(new string[]{",", ";", " "}, StringSplitOptions.RemoveEmptyEntries);
                    InfoTest.DanhSachTenDeThi.Clear();
                    foreach (string _ten in lstTenDeThi)
                    {
                        InfoTest.DanhSachTenDeThi.Add(_ten.Trim());
                        int _result;
                        if(!int.TryParse(_ten, out _result))
                        {
                            throw new ArgumentException("ĐỊNH DẠNG TÊN ĐỀ THI sai!\n Tên đề thi chỉ được là số\nĐược ngăn cách bởi dấu phẩy, chấm phẩy, khoảng trắng");
                        }
                    }
                    InfoTest.iSoDe = InfoTest.DanhSachTenDeThi.Count;
                }
                this.Close();
                fProcessTest frm = new fProcessTest();
                frm.ShowDialog();

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin đề thi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fInfoTest_Load(object sender, EventArgs e)
        {
            ConnectData conn = new ConnectData();
            DataTable dt = conn.GetDataTable("select * from tKieu");
            cbHinhThucThi.DataSource = dt;
            cbHinhThucThi.ValueMember = "ID";
            cbHinhThucThi.DisplayMember = "TenKieu";  
            //
            cbGiaiThich.SelectedIndex = 0;
            cbHinhThucThi.SelectedIndex = 0;
            cbKieuDeThi.SelectedIndex = 0;
            cbTenCau.SelectedIndex = 0;
            cbTepMau.SelectedIndex = 0;
            cbTieuDeNhom.SelectedIndex = 0;
        }

        private void chkHienThiTieuDeNhom_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiTieuDeNhom.Checked)
            {
                cbTieuDeNhom.Enabled = true;
                InfoTest.bTieuDeNhom = true;
            }
            else
            {
                cbTieuDeNhom.Enabled = false;
                InfoTest.bTieuDeNhom = false;
            }
        }

        private void chkThemGiaiThich_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThemGiaiThich.Checked)
            {
                cbGiaiThich.Enabled = true;
                InfoTest.bThemGiaiThich = true;
                InfoTest.sGiaiThich = cbGiaiThich.Text;
            }
            else
            {
                cbGiaiThich.Enabled = false;
                InfoTest.bThemGiaiThich = false;
                InfoTest.sGiaiThich = "";
            }
        }
    }
}
