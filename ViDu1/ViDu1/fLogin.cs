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
using System.Data;

namespace ViDu1
{
    public partial class fLogin : Form
    {
        public bool IsSuccessfull { get; set; }
        public fLogin()
        {
            InitializeComponent();
            IsSuccessfull = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUserName.Text == "admin" && txtPassWord.Text == "111")
                {
                    Session.UserName = txtUserName.Text;
                    IsSuccessfull = true;
                    this.Close();
                }
                else
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                }
                //ConnectData conn = new ConnectData();
                //DataTable dt = new System.Data.DataTable();
                //string sql = "SELECT ID, TenDangNhap, MatKhau FROM tNguoiDung WHERE TenDangNhap='"+txtUserName.Text +"'";
                //dt = conn.GetDataTable(sql, false);                
                //if (dt.Rows.Count > 0)
                //{
                //    string tenNguoiDung = Convert.ToString(dt.Rows[0]["TenDangNhap"]);
                //    string matKhau = Convert.ToString(dt.Rows[0]["MatKhau"]);
                //    if(txtUserName.Text == tenNguoiDung && txtPassWord.Text == matKhau)
                //    {
                //        Session.UserName = txtUserName.Text;
                //        IsSuccessfull = true;
                //        this.Close();
                //    }
                //    else
                //    {
                //        throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                //    }
                    
                //}
                //else
                //{
                //    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
