using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ViDu1.DataAccess;
using ViDu1.BusinessObject;
using ViDu1.BusinessLogic;
using System.Data.OleDb;
//using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Reflection;
//using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Configuration;
using Microsoft.Office.Interop.Word;

namespace ViDu1
{
    public partial class fMain : Form
    {
        string myRoot = "";
        KhoaDao _khoa;
        MonHocDao _monHoc; 
        NhomCauHoiDao dao;
        System.Data.DataTable dt;
        public fMain()
        {
            InitializeComponent();
            InfoTest.sThuMucGoc = ConfigurationManager.ConnectionStrings["ThuMucGoc"].ConnectionString;
            InfoTest.sThuMucDeMau = ConfigurationManager.ConnectionStrings["ThuMucDeMau"].ConnectionString;
            myRoot = InfoTest.sThuMucGoc;
            //InfoTest.sViTriLuuDeThi = ConfigurationManager.ConnectionStrings["ThuMucGoc"].ConnectionString;
        }
        private void tvMonHoc_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode tn = e.Node.Nodes[0];
            if (tn.Text == "...")
            {
                e.Node.Nodes.AddRange(getFolderNodes(((DirectoryInfo)e.Node.Tag)
                      .FullName, true).ToArray());
                if (tn.Text == "...") tn.Parent.Nodes.Remove(tn);
            }
        }

        List<TreeNode> getFolderNodes(string dir, bool expanded)
        {
            var dirs = Directory.GetDirectories(dir).ToArray();
            var nodes = new List<TreeNode>();
            foreach (string d in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                TreeNode tn = new TreeNode(di.Name);
                tn.Tag = di;
                int subCount = 0;
                try 
                { 
                    subCount = Directory.GetDirectories(d).Count();  
                } 
                catch { /* ignore accessdenied */  }
                if (subCount > 0) tn.Nodes.Add("...");
                if (expanded) tn.Expand();   //  **
                nodes.Add(tn);
            }
            return nodes;
        }
        List<TreeNode> getAllFolderNodes(string dir)
        {
            var dirs = Directory.GetDirectories(dir).ToArray();
            var nodes = new List<TreeNode>();
            foreach (string d in dirs)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                TreeNode tn = new TreeNode(di.Name);
                tn.Tag = di;
                int subCount = 0;
                try { subCount = Directory.GetDirectories(d).Count(); } 
                catch { /* ignore accessdenied */  }
                if (subCount > 0)
                {
                    var subNodes = getAllFolderNodes(di.FullName);
                    tn.Nodes.AddRange(subNodes.ToArray());
                }
                nodes.Add(tn);
            }
            return nodes;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            try
            {
                BuildTreeView();
                toolStrip1.ImageList = imageList1;
                //Load dữ liệu Khoa, Môn học
                _khoa = new KhoaDao();
                cbKhoa.DataSource = _khoa.LayDSKhoa();
                cbKhoa.ValueMember = "IDKhoa";
                cbKhoa.DisplayMember = "TenKhoa";
                _monHoc = new MonHocDao();
                cbHocPhan.DataSource = _monHoc.LayDSMonHoc();
                cbHocPhan.ValueMember = "MaMonHoc";
                cbHocPhan.DisplayMember = "TenMonHoc";
                lbDiem.Text = "";//điểm
                lbDoKho.Text = "";//Độ khó
                lbKieu.Text = "";//Kiểu
                lbTongSoCauHoi.Text = "";//Tổng số câu hỏi
                lbSoCau.Text = "";//Số câu mặc định
                lbNgayTao.Text = "";//Ngày tạo, ngày sửa
                lbNgaySua.Text = "";
                lbDuongDan.Text = "";
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Kiểm tra kết nối cơ sở dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void PopulateTree(string dir, TreeNode node)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                TreeNode t = new TreeNode(d.Name,0,0);
                t.Name = myRoot + d.Name + "\\";
                PopulateTree(d.FullName, t);
                node.Nodes.Add(t);
            }
            //foreach (FileInfo f in directory.GetFiles())
            //{
            //    TreeNode t = new TreeNode(f.Name);
            //    node.Nodes.Add(t);
            //}
        }

        public void PopulateTree1(string dir, TreeNode node)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                TreeNode t = new TreeNode(d.Name,0,0);
                t.Name = node.Name + d.Name + "\\";
                if(node.Level <=1)
                {
                    if (node != null) node.Nodes.Add(t);
                    else tvMonHoc.Nodes.Add(t);
                    PopulateTree1(d.FullName, t);

                }
            }
            //foreach (FileInfo f in directory.GetFiles())
            //{
            //    TreeNode t = new TreeNode(f.Name);
            //    if (node != null) node.Nodes.Add(t);
            //    else tvMonHoc.Nodes.Add(t);
            //}
        }
        //public void PopulateTree1(string dir, TreeNode node)
        //{
        //    DirectoryInfo directory = new DirectoryInfo(dir);
        //    foreach (DirectoryInfo d in directory.GetDirectories())
        //    {
        //        TreeNode t = new TreeNode(d.Name);
        //        if (node != null) node.Nodes.Add(t);
        //        else tvMonHoc.Nodes.Add(t);
        //        PopulateTree1(d.FullName, t);
        //    }
        //    foreach (FileInfo f in directory.GetFiles())
        //    {
        //        TreeNode t = new TreeNode(f.Name);
        //        if (node != null) node.Nodes.Add(t);
        //        else tvMonHoc.Nodes.Add(t);
        //    }
        //}

        public void PopulateTree2(string dir, TreeNodeCollection nodes)
        {
            DirectoryInfo directory = new DirectoryInfo(dir);
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                TreeNode t = new TreeNode(d.Name);
                nodes.Add(t);
                PopulateTree2(d.FullName, t.Nodes);
            }
            foreach (FileInfo f in directory.GetFiles())
            {
                TreeNode t = new TreeNode(f.Name);
                nodes.Add(t);
            }
        }

        private void tvMonHoc_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string strPath = "";
            dt = new System.Data.DataTable();
            dao = new NhomCauHoiDao();
            if (tvMonHoc.SelectedNode.Level == 0)
            {
                txtTenMonThi.Text = "";
                cbKhoa.Text = "";
                txtMaHocPhan.Text = "";
                cbHocPhan.Text = "";
                //
                lbDiem.Text = "";//điểm
                lbDoKho.Text = "";//Độ khó
                lbKieu.Text = "";//Kiểu
                lbTongSoCauHoi.Text = "";//Tổng số câu hỏi
                lbSoCau.Text = "";//Số câu mặc định
                lbNgayTao.Text = "";//Ngày tạo, ngày sửa
                lbNgaySua.Text = "";
                lbDuongDan.Text = "";
                lbIDKieu.Text = "";
                //
                TreeNode node = tvMonHoc.SelectedNode;
                strPath = myRoot;//sThuMucGoc
            }
            else if(tvMonHoc.SelectedNode.Level==1)//Chọn node Khoa
            {
                txtTenMonThi.Text = "";
                cbKhoa.Text = tvMonHoc.SelectedNode.Text;
                txtMaHocPhan.Text = "";
                cbHocPhan.Text = "";
                //
                lbDiem.Text = "";//điểm
                lbDoKho.Text = "";//Độ khó
                lbKieu.Text = "";//Kiểu
                lbTongSoCauHoi.Text = "";//Tổng số câu hỏi
                lbSoCau.Text = "";//Số câu mặc định
                lbNgayTao.Text = "";//Ngày tạo, ngày sửa
                lbNgaySua.Text = "";
                lbDuongDan.Text = "";
                lbIDKieu.Text = "";
                //  
                TreeNode node = tvMonHoc.SelectedNode;
                strPath = myRoot + "\\" + node.Text;
            }
            else if(tvMonHoc.SelectedNode.Level == 2) //Nếu treenode là <tên môn học>
            {
                string maMonHoc = "";
                maMonHoc = tvMonHoc.SelectedNode.Name;
                dt = dao.LayDSNhomCauHoiTheoMH(maMonHoc);
                if (dt.Rows.Count != 0)
                {
                    txtTenMonThi.Text = dt.Rows[0]["TenMonHoc"].ToString();
                    cbKhoa.SelectedValue = dt.Rows[0]["IDKhoa"];
                    txtMaHocPhan.Text = dt.Rows[0]["MaMonHoc"].ToString();
                    cbHocPhan.SelectedValue = dt.Rows[0]["MaMonHoc"].ToString();
                    //
                    lbDiem.Text = "";//điểm
                    lbDoKho.Text = "";//Độ khó
                    lbKieu.Text = "";//Kiểu
                    lbTongSoCauHoi.Text = "";//Tổng số câu hỏi
                    lbSoCau.Text = "";//Số câu mặc định
                    lbNgayTao.Text = "";//Ngày tạo, ngày sửa
                    lbNgaySua.Text = "";
                    lbDuongDan.Text = "";
                    lbIDKieu.Text = "";
                    //
                }
                else
                {
                    TreeNode nodeKhoa = tvMonHoc.SelectedNode.Parent;//

                    txtTenMonThi.Text = tvMonHoc.SelectedNode.Text;
                    cbKhoa.Text = nodeKhoa.Text;
                    txtMaHocPhan.Text = tvMonHoc.SelectedNode.Name;
                    cbHocPhan.Text = tvMonHoc.SelectedNode.Text;
                    //
                    lbDiem.Text = "";//điểm
                    lbDoKho.Text = "";//Độ khó
                    lbKieu.Text = "";//Kiểu
                    lbTongSoCauHoi.Text = "";//Tổng số câu hỏi
                    lbSoCau.Text = "";//Số câu mặc định
                    lbNgayTao.Text = "";//Ngày tạo, ngày sửa
                    lbNgaySua.Text = "";
                    lbDuongDan.Text = "";
                    lbIDKieu.Text = "";
                }
                TreeNode node = tvMonHoc.SelectedNode;
                strPath = myRoot + "\\" + node.Parent.Text;
            }
            else if (tvMonHoc.SelectedNode.Level == 3)//Nếu treenode là <tên nhóm>
            {
                dt = dao.LayDSNhomCauHoiTheoID(Convert.ToInt32(tvMonHoc.SelectedNode.Name));
                if (dt.Rows.Count != 0)
                {
                    lbDiem.Text = Convert.ToString(dt.Rows[0]["Diem"]);//điểm
                    lbDoKho.Text = dt.Rows[0]["LoaiKho"].ToString();//Độ khó
                    lbKieu.Text = dt.Rows[0]["TenKieu"].ToString();//Kiểu
                    lbTongSoCauHoi.Text = dt.Rows[0]["SoCau"].ToString();//Tổng số câu hỏi
                    lbSoCau.Text = dt.Rows[0]["SoCauMacDinh"].ToString();//Số câu mặc định
                    lbNgayTao.Text = string.Format("{0: dd/MM/yyyy}", dt.Rows[0]["NgayTao"]);//Ngày tạo, ngày sửa
                    lbNgaySua.Text = string.Format("{0: dd/MM/yyyy}", dt.Rows[0]["NgaySua"]);
                    lbDuongDan.Text = dt.Rows[0]["DuongDan"].ToString();
                    lbIDKieu.Text = dt.Rows[0]["IDKieu"].ToString();
                    //
                    TreeNode nodeMH = tvMonHoc.SelectedNode.Parent;
                    txtTenMonThi.Text = dt.Rows[0]["TenMonHoc"].ToString();
                    cbKhoa.SelectedValue = dt.Rows[0]["IDKhoa"];
                    txtMaHocPhan.Text = dt.Rows[0]["MaMonHoc"].ToString();
                    cbHocPhan.SelectedValue = dt.Rows[0]["MaMonHoc"].ToString();
                }
                //
                TreeNode node = tvMonHoc.SelectedNode;
                strPath = myRoot + "\\" + node.Parent.Parent.Text;
                
                //node.Parent.Text  : Tên môn học
                //node.Parent.Parent.Text   : Tên khoa
                //node.Parent.Parent.Parent.Text    : "NGÂN HÀNG CÂU HỎI"
            }
            InfoTest.sViTriLuuDeThi = strPath + "\\Đề đã trộn";
        }
        //private void BuildTreeView()
        //{
        //    this.tvMonHoc.Nodes.Clear();            
        //    TreeNode nodeParent = new TreeNode();
        //    nodeParent.Text = "NGÂN HÀNG CÂU HỎI";
        //    nodeParent.Name = myRoot;
        //    OleDbConnection conn = new OleDbConnection(Session.strConn);
        //    conn.Open();
        //    string sql1 = "SELECT IDKhoa, TenKhoa FROM tKhoa ";
        //    OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
        //    OleDbDataReader dr1 = cmd1.ExecuteReader();
        //    while(dr1.Read())
        //    {
        //        TreeNode nodeKhoa = new TreeNode();
        //        nodeKhoa.Text = dr1["TenKhoa"].ToString();
        //        nodeKhoa.Name = dr1["IDKhoa"].ToString();
        //        //AddChildNode(nodeKhoa, nodeKhoa.Name);
        //        #region-------------Thêm môn học theo khoa------------
        //        string idKhoa = dr1["IDKhoa"].ToString();
        //        string sql2 = "SELECT m.IDMonHoc, m.IDKhoa, m.MaMonHoc, m.TenMonHoc "
        //                    + "FROM tMonHoc m "
        //                    + "WHERE m.IDKhoa='" + idKhoa + "'";
        //        OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
        //        OleDbDataReader dr2 = cmd2.ExecuteReader();
        //        while(dr2.Read())
        //        {
        //            TreeNode nodeMonHoc = new TreeNode();
        //            nodeMonHoc.Name = dr2["MaMonHoc"].ToString();
        //            nodeMonHoc.Text = dr2["TenMonHoc"].ToString();
        //            nodeMonHoc.Tag = dr2["IDMonHoc"];
        //            nodeMonHoc.ImageIndex = 0;
        //            nodeMonHoc.SelectedImageIndex = 1;
        //            //AddChildNodeNhom(nodeMonHoc, nodeMonHoc.Name);
        //            #region-------------Thêm nhóm câu hỏi theo môn học------------
        //            string idMonHoc = dr2["IDMonHoc"].ToString();
        //            //string sql3 = "SELECT m.ID, m.TenFile, m.IDMonHoc, "
        //            //       + " n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa "
        //            //       + " FROM (tNhom m "
        //            //       + " INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc) "
        //            //       + " INNER JOIN tKhoa k ON n.IDKhoa = k.IDKhoa "
        //            //       + " WHERE n.MaMonHoc='" + maMonHoc + "' "
        //            //       + " GROUP BY m.ID, m.TenFile, m.IDMonHoc, n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa";
        //            string sql3 = "SELECT m.ID, m.TenFile, m.IDMonHoc FROM tNhom m WHERE m.IDMonHoc ="+idMonHoc;
        //            OleDbCommand cmd3 = new OleDbCommand(sql3, conn);
        //            OleDbDataReader dr3 = cmd3.ExecuteReader();
        //            while(dr3.Read())
        //            {
        //                TreeNode nodeNhom = new TreeNode();
        //                nodeNhom.Name = dr3["ID"].ToString();
        //                nodeNhom.Text = dr3["TenFile"].ToString();
        //                nodeNhom.ImageIndex = 2;
        //                nodeNhom.SelectedImageIndex = 2;
        //                nodeMonHoc.Nodes.Add(nodeNhom);
        //            }
        //            #endregion//-------------KẾT THÚC Thêm nhóm câu hỏi theo môn học------------
        //            nodeKhoa.Nodes.Add(nodeMonHoc);
        //        }
        //        #endregion-------------KẾT THÚC Thêm môn học theo khoa------------
        //        nodeKhoa.ImageIndex = 0;
        //        nodeKhoa.SelectedImageIndex = 1;
        //        nodeParent.Nodes.Add(nodeKhoa);
        //    }
        //    tvMonHoc.Nodes.Add(nodeParent);
        //    nodeParent.ExpandAll();
        //    conn.Close();
        //}
        private void BuildTreeView()
        {
            this.tvMonHoc.Nodes.Clear();
            TreeNode nodeParent = new TreeNode();
            nodeParent.Text = "NGÂN HÀNG CÂU HỎI";
            nodeParent.Name = myRoot;

            Console.WriteLine(Session.strConn);

            OleDbConnection conn = new OleDbConnection(Session.strConn);

            Console.WriteLine(conn.ToString());

            //conn.Open();
            //
            #region "Nhap có thể xóa"
            string sql1 = "SELECT IDKhoa, TenKhoa FROM tKhoa ";
            OleDbCommand cmd1 = new OleDbCommand(sql1, conn);
            OleDbDataAdapter dataAdapter1 = new OleDbDataAdapter(sql1, conn);
            System.Data.DataTable dtKhoa = new System.Data.DataTable();
            dataAdapter1.Fill(dtKhoa);
            //
            string sql2 = "SELECT m.IDMonHoc, m.IDKhoa, m.MaMonHoc, m.TenMonHoc "
                            + "FROM tMonHoc m ";
            OleDbCommand cmd2 = new OleDbCommand(sql2, conn);
            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sql2, conn);
            System.Data.DataTable dtMonHoc = new System.Data.DataTable();
            dataAdapter2.Fill(dtMonHoc);
            //
            string sql3 = "SELECT m.ID, m.TenFile, m.IDMonHoc, "
                           + " n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa "
                           + " FROM (tNhom m "
                           + " INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc) "
                           + " INNER JOIN tKhoa k ON n.IDKhoa = k.IDKhoa "
                           + " GROUP BY m.ID, m.TenFile, m.IDMonHoc, n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa";
            OleDbCommand cmd3 = new OleDbCommand(sql3, conn);
            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(sql3, conn);
            System.Data.DataTable dtNhomCauHoi = new System.Data.DataTable();
            dataAdapter3.Fill(dtNhomCauHoi);
            //
            foreach (DataRow r1 in dtKhoa.Rows)
            {
                TreeNode nodeKhoa = new TreeNode();
                nodeKhoa.Text = r1["TenKhoa"].ToString();
                nodeKhoa.Name = r1["IDKhoa"].ToString();
                //Thêm môn học theo khoa
                #region-------------Thêm môn học theo khoa------------
                string idKhoa = r1["IDKhoa"].ToString();
                DataView dview2 = new DataView(dtMonHoc);
                dview2.RowFilter = "IDKhoa ='" + idKhoa + "'";
                System.Data.DataTable dtMonHoc2 = dview2.ToTable();
                foreach (DataRow r2 in dtMonHoc2.Rows)
                {
                    TreeNode nodeMonHoc = new TreeNode();
                    nodeMonHoc.Name = r2["MaMonHoc"].ToString();
                    nodeMonHoc.Text = r2["TenMonHoc"].ToString();
                    nodeMonHoc.Tag = r2["IDMonHoc"];
                    nodeMonHoc.ImageIndex = 0;
                    nodeMonHoc.SelectedImageIndex = 1;
                    //Thêm nhóm câu hỏi theo môn học
                    #region-------------Thêm nhóm câu hỏi theo môn học------------
                    string idMonHoc = r2["IDMonHoc"].ToString();
                    DataView dview3 = new DataView(dtNhomCauHoi);
                    dview3.RowFilter = "IDMonHoc=" + idMonHoc;
                    System.Data.DataTable dtNhomCauHoi2 = dview3.ToTable();
                    foreach (DataRow r3 in dtNhomCauHoi2.Rows)
                    {
                        TreeNode nodeNhom = new TreeNode();
                        nodeNhom.Name = r3["ID"].ToString();
                        nodeNhom.Text = r3["TenFile"].ToString();
                        nodeNhom.ImageIndex = 2;
                        nodeNhom.SelectedImageIndex = 2;
                        nodeMonHoc.Nodes.Add(nodeNhom);
                    }
                    #endregion//-------------KẾT THÚC Thêm nhóm câu hỏi theo môn học------------
                    nodeKhoa.Nodes.Add(nodeMonHoc);
                }
                #endregion
                //
                nodeKhoa.ImageIndex = 0;
                nodeKhoa.SelectedImageIndex = 1;
                nodeParent.Nodes.Add(nodeKhoa);
            }
            tvMonHoc.Nodes.Add(nodeParent);
            nodeParent.ExpandAll();
            #endregion "Nhap có thể xóa"
            #region "Nhap"
            //KhoaDao _khoa = new KhoaDao();
            //System.Data.DataTable dtKhoa = new System.Data.DataTable();
            //dtKhoa = _khoa.LayDSKhoa();
            //MonHocDao _monHoc = new MonHocDao();
            //DataTable dtMonHoc = new DataTable();
            //dtMonHoc = _monHoc.LayDSMonHoc();
            //NhomCauHoiDao _nhomCauHoi = new NhomCauHoiDao();
            //DataTable dtNhomCauHoi = new DataTable();
            //dtNhomCauHoi = _nhomCauHoi.LayDSNhomCauHoi();
            ////
            //foreach(DataRow r1 in dtKhoa.Rows)
            //{
            //    TreeNode nodeKhoa = new TreeNode();
            //    nodeKhoa.Text = r1["TenKhoa"].ToString();
            //    nodeKhoa.Name = r1["IDKhoa"].ToString();
            //    //Thêm môn học theo khoa
            //    #region-------------Thêm môn học theo khoa------------
            //    string idKhoa = r1["IDKhoa"].ToString();
            //    DataView dview2 = new DataView(dtMonHoc);
            //    dview2.RowFilter = "IDKhoa ='" + idKhoa +"'";
            //    DataTable dtMonHoc2 = dview2.ToTable();
            //    foreach(DataRow r2 in dtMonHoc2.Rows)
            //    {
            //        TreeNode nodeMonHoc = new TreeNode();
            //        nodeMonHoc.Name = r2["MaMonHoc"].ToString();
            //        nodeMonHoc.Text = r2["TenMonHoc"].ToString();
            //        nodeMonHoc.Tag = r2["IDMonHoc"];
            //        nodeMonHoc.ImageIndex = 0;
            //        nodeMonHoc.SelectedImageIndex = 1;
            //        //Thêm nhóm câu hỏi theo môn học
            //        #region-------------Thêm nhóm câu hỏi theo môn học------------
            //        string idMonHoc = r2["IDMonHoc"].ToString();
            //        DataView dview3 = new DataView(dtNhomCauHoi);
            //        dview3.RowFilter = "IDMonHoc=" + idMonHoc;
            //        DataTable dtNhomMonHoc2 = dview3.ToTable();
            //        foreach(DataRow r3 in dtNhomMonHoc2.Rows)
            //        {
            //            TreeNode nodeNhom = new TreeNode();
            //            nodeNhom.Name = r3["ID"].ToString();
            //            nodeNhom.Text = r3["TenFile"].ToString();
            //            nodeNhom.ImageIndex = 2;
            //            nodeNhom.SelectedImageIndex = 2;
            //            nodeMonHoc.Nodes.Add(nodeNhom);
            //        }
            //        #endregion//-------------KẾT THÚC Thêm nhóm câu hỏi theo môn học------------
            //        nodeKhoa.Nodes.Add(nodeMonHoc);
            //    }
            //    #endregion
            //    //
            //    nodeKhoa.ImageIndex = 0;
            //    nodeKhoa.SelectedImageIndex = 1;
            //    nodeParent.Nodes.Add(nodeKhoa);
            //}            
            //tvMonHoc.Nodes.Add(nodeParent);
            //nodeParent.ExpandAll();
            #endregion "Nhap"
            //conn.Close();
        }
        private void AddChildNode(TreeNode nodeParent, string maNodeParent)
        {
            MonHocDao _dao = new MonHocDao();
            OleDbDataReader _reader = _dao.LayDSMonHocReader(maNodeParent);
            if (_reader != null)
            {
                while (_reader.Read())
                {
                    TreeNode nodeMonHoc = new TreeNode();
                    nodeMonHoc.Name = _reader["MaMonHoc"].ToString();
                    nodeMonHoc.Text = _reader["TenMonHoc"].ToString();
                    nodeMonHoc.Tag = _reader["IDMonHoc"];
                    nodeMonHoc.ImageIndex = 0;
                    nodeMonHoc.SelectedImageIndex = 1;
                    AddChildNodeNhom(nodeMonHoc, nodeMonHoc.Name);
                    nodeParent.Nodes.Add(nodeMonHoc);
                }
            }
        }
        private void AddChildNodeNhom(TreeNode nodeParent, string maNodeParent)
        {
            NhomCauHoiDao _dao = new NhomCauHoiDao();
            OleDbDataReader _reader = _dao.LayDSNhomCauHoiTheoMHReader(maNodeParent);//Lấy DS nhóm câu hỏi theo IDMonHoc            
            while(_reader.Read())
            {
                TreeNode nodeNhom = new TreeNode();
                nodeNhom.Name = _reader["ID"].ToString();
                nodeNhom.Text = _reader["TenFile"].ToString();
                nodeNhom.ImageIndex = 2;
                nodeNhom.SelectedImageIndex = 2;
                nodeParent.Nodes.Add(nodeNhom);
            }            
        }
        public void ThemFileNhom(string tenFile, string idMonHoc, string duongDan, int idKieu, decimal diem, int loaiKho, int soCauMacDinh)
        {
            TreeNode nodeSelected = tvMonHoc.SelectedNode;
            if (nodeSelected == null || nodeSelected.Level !=2)
            {
                MessageBox.Show("Không thao tác được tại đây!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                
                //
                NhomCauHoiDto _dto = new NhomCauHoiDto();
                NhomCauHoiDao _dao = new NhomCauHoiDao();
                string id_File;
                _dto.ID = _dao.NextID();
                id_File = _dto.ID.ToString();
                _dto.TenFile = tenFile;
                _dto.IdMonHoc = Convert.ToInt32(nodeSelected.Tag);//ID Môn học
                _dto.DuongDan = duongDan;
                _dto.IdKieu = idKieu;
                _dto.Diem = diem;
                _dto.LoaiKho = loaiKho;
                _dto.SoCauMacDinh = soCauMacDinh;
                _dto.NgayTao = DateTime.Now;
                _dto.NgaySua = DateTime.Now;
                //cập nhật SoCau
                object path = duongDan;//Lấy đường dẫn
                //
                object missing = Missing.Value;
                object readOnly = true;
                Microsoft.Office.Interop.Word.Application w1 = new Microsoft.Office.Interop.Word.Application();
                w1.Visible = false;
                Microsoft.Office.Interop.Word.Document aDoc_Nhom1 = w1.Documents.Open(ref path, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing);
                _dto.SoCau = aDoc_Nhom1.Tables.Count;
                aDoc_Nhom1.Close();
                w1.Quit();
                //
                NhomCauHoiBlo _blo = new NhomCauHoiBlo();
                _blo.NhomCauHoi = _dto;
                _blo.ThemNhomCauHoi();

                //
                TreeNode nodeChild = new TreeNode();
                nodeChild.Text = tenFile;
                nodeChild.Name = id_File;
                nodeChild.ImageIndex = 2;
                nodeChild.SelectedImageIndex = 2;
                nodeSelected.Nodes.Add(nodeChild);
                nodeSelected.Expand();
            }
        }
        public void SuaFileNhom(string tenFile, string idMonHoc, string duongDan, int idKieu, decimal diem, int loaiKho, int soCauMacDinh)
        {
            TreeNode nodeSelected = tvMonHoc.SelectedNode;
            if (nodeSelected == null || nodeSelected.Level != 3)
            {
                MessageBox.Show("Không thao tác được tại đây!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //
                NhomCauHoiDto _dto = new NhomCauHoiDto();
                NhomCauHoiDao _dao = new NhomCauHoiDao();
                _dto.ID = Convert.ToInt32(nodeSelected.Name);//Lấy ID của file nhóm câu hỏi 
                _dto.TenFile = tenFile;
                _dto.IdMonHoc = Convert.ToInt32(nodeSelected.Parent.Tag);//Lấy IDMonHoc là Name của nút cha
                _dto.DuongDan = duongDan;
                _dto.IdKieu = idKieu;
                _dto.Diem = diem;
                _dto.LoaiKho = loaiKho;
                _dto.SoCauMacDinh = soCauMacDinh;
                _dto.NgaySua = DateTime.Now;
                //
                //cập nhật SoCau
                object path = duongDan;//Lấy đường dẫn
                //
                object missing = Missing.Value;
                object readOnly = true;
                Microsoft.Office.Interop.Word.Application w1 = new Microsoft.Office.Interop.Word.Application();
                w1.Visible = false;
                Microsoft.Office.Interop.Word.Document aDoc_Nhom1 = w1.Documents.Open(ref path, ref missing, ref readOnly,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing,
                                                        ref missing, ref missing, ref missing, ref missing);
                _dto.SoCau = aDoc_Nhom1.Tables.Count;
                aDoc_Nhom1.Close();
                //
                NhomCauHoiBlo _blo = new NhomCauHoiBlo();
                _blo.NhomCauHoi = _dto;
                _blo.SuaNhomCauHoi();

                //
                nodeSelected.Text = tenFile;
            }
        }
        public void ThemMonHoc(string maMonHoc, string tenMonHoc)
        {
            if(tvMonHoc.SelectedNode.Level == 1)
            {
                //Thêm môn học vào database
                string idKhoa = tvMonHoc.SelectedNode.Name;
                MonHocDto dtoMH = new MonHocDto();
                dtoMH.MaMonHoc = maMonHoc;
                dtoMH.TenMonHoc = tenMonHoc;
                dtoMH.IDKhoa = idKhoa;
                MonHocDao daoMH = new MonHocDao();
                daoMH.MonHoc = dtoMH;
                int id = daoMH.ThemMonHoc();
                if (id > 0)
                {
                    //Thêm môn học vào TreeView
                    TreeNode node = new TreeNode();
                    node.Text = tenMonHoc;
                    node.Name = maMonHoc;
                    node.Tag = id;
                    tvMonHoc.SelectedNode.Nodes.Add(node);
                    tvMonHoc.SelectedNode.Expand();
                }
                else
                    MessageBox.Show("Không thêm được!!!", "Thông báo");

            }
            else
            {
                MessageBox.Show("Hãy chọn khoa!", "Thông báo");
            }
        }
        public void SuaMonHoc(int idMonHoc, string maMonHoc, string tenMonHoc, string idKhoa)
        {
            if (tvMonHoc.SelectedNode.Level == 2)
            {
                //Thêm môn học vào database
                MonHocDto dtoMH = new MonHocDto();
                dtoMH.MaMonHoc = maMonHoc;
                dtoMH.TenMonHoc = tenMonHoc;
                dtoMH.IDMonHoc = idMonHoc;
                dtoMH.IDKhoa = idKhoa;
                MonHocDao daoMH = new MonHocDao();
                daoMH.MonHoc = dtoMH;                
                if (daoMH.SuaMonHoc())
                {
                    //Sửa môn học vào TreeView
                    tvMonHoc.SelectedNode.Text = tenMonHoc;
                    tvMonHoc.SelectedNode.Name = maMonHoc;
                    tvMonHoc.SelectedNode.Tag = idMonHoc;                    
                }
            }
            else
            {
                MessageBox.Show("Hãy chọn khoa!", "Thông báo");
            }
        }
        public void SuaFileNhomListView(string tenFile, string duongDan, string tenKieu, decimal diem, int loaiKho, int soCauMacDinh)
        {
            lstvNoiDung.SelectedItems[0].Text = tenFile;
            lstvNoiDung.SelectedItems[0].SubItems[2].Text = soCauMacDinh.ToString();//Số câu đc chọn
            lstvNoiDung.SelectedItems[0].SubItems[3].Text = diem.ToString();//Điểm
            lstvNoiDung.SelectedItems[0].SubItems[4].Text = loaiKho.ToString();//Loại khó
            lstvNoiDung.SelectedItems[0].SubItems[6].Text = duongDan;//Đường dẫn
            lstvNoiDung.SelectedItems[0].SubItems[5].Text = tenKieu;//TenKieu          
            //            
        }
        public MonHocDto LayMonHoc()
        {
            MonHocDto dtoMH = new MonHocDto();
            TreeNode selectedNode = tvMonHoc.SelectedNode;
            if(selectedNode.Level == 2)
            {
                dtoMH.MaMonHoc = selectedNode.Name;
                dtoMH.TenMonHoc = selectedNode.Text;
                dtoMH.IDMonHoc = (int) selectedNode.Tag;
                dtoMH.IDKhoa = selectedNode.Parent.Name;
            }
            else
            {
                MessageBox.Show("Không thao tác được. /nHãy chọn đúng môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);              
            }
            return dtoMH;
        }
        public int LayMaNhomCauHoi()
        {
            TreeNode selectedNode = tvMonHoc.SelectedNode;
            if (selectedNode == null && selectedNode.Level != 3)
            {
                MessageBox.Show("Chưa chọn tệp tin nhóm câu hỏi!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            else
                return Convert.ToInt32(selectedNode.Name);
        }
        public NhomCauHoiDto LayNhomCauHoiTuListView()
        {
            NhomCauHoiDto dto = new NhomCauHoiDto();
            dto.TenFile = lstvNoiDung.SelectedItems[0].Text;//Tên file
            dto.SoCau = Convert.ToInt16(lstvNoiDung.SelectedItems[0].SubItems[1].Text);//Tổng số câu hỏi
            dto.SoCauMacDinh = Convert.ToInt16(lstvNoiDung.SelectedItems[0].SubItems[2].Text);//Số câu đc chọn
            dto.Diem = Convert.ToDecimal(lstvNoiDung.SelectedItems[0].SubItems[3].Text);//Điểm
            dto.LoaiKho = Convert.ToInt16(lstvNoiDung.SelectedItems[0].SubItems[4].Text);//Loại khó
            dto.DuongDan = lstvNoiDung.SelectedItems[0].SubItems[6].Text;//Đường dẫn
            dto.IdKieu = Convert.ToInt16(lstvNoiDung.SelectedItems[0].SubItems[7].Text);//IdKieu
            return dto;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvMonHoc.SelectedNode;//node nhóm câu hỏi
            if (selectedNode.Level == 3)
            {
                ListViewItem item = new ListViewItem();
                item.Text = selectedNode.Text;
                item.SubItems.Add(lbTongSoCauHoi.Text);
                item.SubItems.Add(lbSoCau.Text);
                item.SubItems.Add(lbDiem.Text);
                item.SubItems.Add(lbDoKho.Text);
                item.SubItems.Add(lbKieu.Text);
                item.SubItems.Add(lbDuongDan.Text);
                item.SubItems.Add(lbIDKieu.Text);
                lstvNoiDung.Items.Add(item);
            }
            else
                MessageBox.Show("Đây không phải nhóm câu hỏi!", "Thông báo");
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            #region "Nháp"
            //string path = System.Windows.Forms.Application.StartupPath;
            //path = path.Replace("\\bin\\Debug", "\\Database\\");
            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + "dbTronDe.accdb;User Id=;Password=;";
            
            //int id = -1;

            //string Query = "INSERT INTO Test (Ten) VALUES ('TestName')";
            //string Query2 = "SELECT @@Identity";

            //OleDbConnection con = new OleDbConnection(strConn);

            //OleDbCommand cmd = new OleDbCommand(Query, con);
            //OleDbCommand cmd2 = new OleDbCommand(Query2, con);
            //try
            //{
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    id = (int)cmd2.ExecuteScalar();
            //}
            //catch (Exception ex)
            //{
            //    //log the ex
            //}
            //finally
            //{
            //    con.Dispose();
            //    con.Close();
            //}
            //---------------------------------------------------------------
            //string strChuoi = "3,2, 1, 4,  , ";
            //string[] space = new string[]{","};
            //string[] arr = strChuoi.Split(space, StringSplitOptions.None);
            //string result = "";
            //foreach(string ob in arr)
            //{
            //    result = ob + "-" + result;  
            //}
            //MessageBox.Show("kq: " + result);
            //---------------------------------------------------------------
            //object missObj = Missing.Value;
            //object path = @"E:\3. LAP TRINH\1. TRON DE THI\nhap.docx";
            //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(ref path, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj, ref missObj);
            //app.Visible = true;
            //// Select the last table.
            //// For this demo, the table has size of 3*4 (row * column).
            //int totalTables = doc.Tables.Count;
            //Microsoft.Office.Interop.Word.Table tab = doc.Tables[totalTables];
            //Microsoft.Office.Interop.Word.Range range = tab.Range;

            //// Select the last row as source row.
            //int selectedRow = tab.Rows.Count;

            //// Select and copy content of the source row.
            //range.Start = tab.Rows[selectedRow].Cells[1].Range.Start;
            //range.End = tab.Rows[selectedRow].Cells[tab.Rows[selectedRow].Cells.Count].Range.End;
            //range.Copy();

            //// Insert a new row after the last row.
            //tab.Rows.Add(ref missObj);

            //// Moves the cursor to the first cell of target row.
            //range.Start = tab.Rows[tab.Rows.Count].Cells[1].Range.Start;
            //range.End = range.Start;

            //// Paste values to target row.
            //range.Paste();

            //// Write new vaules to each cell.
            //tab.Rows[tab.Rows.Count].Cells[1].Range.Text = "new row";
            //tab.Rows[tab.Rows.Count].Cells[2].Range.Text = "cell 2";
            //tab.Rows[tab.Rows.Count].Cells[3].Range.Text = "cell 3";
            #endregion
            txtKyThi.Text = "";
            txtMaHocPhan.Text = "";
            txtTenMonThi.Text = "";
            txtLanRaDe.Text = "";
            txtChonThuMuc.Text = "";
            cbDeGoc.Text = "";
            lstvNoiDung.Items.Clear();
        }

        private void tsbAddFile_Click(object sender, EventArgs e)
        {
            TreeNode nodeSelected = new TreeNode();
            nodeSelected = tvMonHoc.SelectedNode;
            if (nodeSelected == null || nodeSelected.Level != 2)
            {
                MessageBox.Show("Hãy CHỌN MÔN HỌC!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                fAddFile frm = new fAddFile(this);
                frm.Text = "Thêm nhóm câu hỏi";
                frm.Them = true;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdViTriLuuDeThi = new FolderBrowserDialog();
            fbdViTriLuuDeThi.SelectedPath = InfoTest.sThuMucGoc;
            if (fbdViTriLuuDeThi.ShowDialog() == DialogResult.OK)
            {                
                InfoTest.sViTriLuuDeThi = fbdViTriLuuDeThi.SelectedPath;//Thư mục lưu đề thi và đáp án
            }
        }

        private void tsbEditFile_Click(object sender, EventArgs e)
        {
            TreeNode nodeSelected = new TreeNode();
            nodeSelected = tvMonHoc.SelectedNode;
            if (nodeSelected == null || nodeSelected.Level != 3)
            {
                MessageBox.Show("Không sửa được tại đây./nPhải CHỌN NHÓM CÂU HỎI!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                fAddFile frm = new fAddFile(this);
                frm.Text = "Sửa nhóm câu hỏi";
                frm.Them = false;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void tsbDeleteFile_Click(object sender, EventArgs e)
        {
            TreeNode nodeSelected = new TreeNode();
            nodeSelected = tvMonHoc.SelectedNode;
            if (nodeSelected == null || nodeSelected.Level != 3)
            {
                MessageBox.Show("Không xóa được tại đây./nPhải CHỌN NHÓM CÂU HỎI!", "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                NhomCauHoiDto _dto = new NhomCauHoiDto();
                NhomCauHoiDao _dao = new NhomCauHoiDao();
                _dto.ID = Convert.ToInt32(nodeSelected.Name);//Lấy ID của file nhóm câu hỏi 
                NhomCauHoiBlo _blo = new NhomCauHoiBlo();
                _blo.NhomCauHoi = _dto;
                _blo.XoaNhomCauHoi();
                tvMonHoc.Nodes.Remove(nodeSelected);
            }
        }
        private bool Resizing = false;
        private void lstvNoiDung_SizeChanged(object sender, EventArgs e)
        {
            //lstvNoiDung.Columns[0].Width = -2;
            //lstvNoiDung.Columns[6].Width = 0;
            // Don't allow overlapping of SizeChanged calls
            if (!Resizing)
            {
                // Set the resizing flag
                Resizing = true;

                ListView listView = sender as ListView;
                if (listView != null)
                {
                    float totalColumnWidth = 0;

                    // Get the sum of all column tags
                    for (int i = 0; i < listView.Columns.Count; i++)
                        totalColumnWidth += Convert.ToInt32(listView.Columns[i].Tag);

                    // Calculate the percentage of space each column should 
                    // occupy in reference to the other columns and then set the 
                    // width of the column to that percentage of the visible space.
                    for (int i = 0; i < listView.Columns.Count; i++)
                    {
                        float colPercentage = (Convert.ToInt32(listView.Columns[i].Tag) / totalColumnWidth);
                        listView.Columns[i].Width = (int)(colPercentage * listView.ClientRectangle.Width);
                    }
                }
            }

            // Clear the resizing flag
            Resizing = false;
        }

        private void lstvNoiDung_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;
                e.DrawBackground();

                using (System.Drawing.Font headerFont =
                    new System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Bold)) //Font size!!!!
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
        }


        //public List<NhomCauHoiDto> LayDanhSachTaoDe()
        //{
        //    var DS = new List<NhomCauHoiDto>();
        //    int _soNhom = lstvNoiDung.Items.Count;
        //    if (_soNhom == 0)
        //    {
        //        MessageBox.Show("Không có nhóm câu hỏi nào", "Thông báo");
        //        return null;
        //    }
        //    foreach (ListViewItem item in lstvNoiDung.Items)
        //    {
        //        NhomCauHoiDto dto = new NhomCauHoiDto();
        //        //dto.DuongDan = item.SubItems["colDuongDan"].Text;
        //        //dto.SoCau = Convert.ToInt32(item.SubItems["colTongSoCauHoi"].Text);
        //        //dto.SoCauMacDinh = Convert.ToInt32(item.SubItems["colSoCauDuocChon"].Text);
        //        //dto.Diem = Convert.ToDecimal(item.SubItems["colDiem"].Text);
        //        //dto.LoaiKho = Convert.ToInt32(item.SubItems["colLoaiKho"].Text);
        //        //dto.IdKieu = Convert.ToInt32(item.SubItems["colKieu"].Text);
        //        dto.DuongDan = item.SubItems[6].Text;
        //        dto.SoCau = Convert.ToInt32(item.SubItems[1].Text);
        //        dto.SoCauMacDinh = Convert.ToInt32(item.SubItems[2].Text);
        //        dto.Diem = Convert.ToDecimal(item.SubItems[3].Text);
        //        dto.LoaiKho = Convert.ToInt32(item.SubItems[4].Text);
        //        dto.IdKieu = Convert.ToInt32(item.SubItems[7].Text);//colIDKieu
        //        DS.Add(dto);
        //    }
        //    //in ra 
        //    string str = "";
        //    for (int i = 0; i < DS.Count; i++)
        //    {
        //        str += "Nhóm " + (i + 1).ToString() + ": " + DS[i].DuongDan + " " + DS[i].Diem + " " + DS[i].SoCau + "\r\n";
        //    }
        //    MessageBox.Show(str);
        //    return DS;
        //}
        private void btnTaoDe_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtKyThi.Text == "" || txtMaHocPhan.Text == "" || txtTenMonThi.Text == "")
                {
                    MessageBox.Show("Nhập THIẾU THÔNG TIN", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    //Khởi tạo lại các thông số trong InfoTest để tạo đề thi tiếp theo
                    InfoTest.iDeThiDangTao = 0;
                    //
                    InfoTest.sKyThi = txtKyThi.Text.ToUpper();
                    InfoTest.sMonThi = txtTenMonThi.Text;
                    InfoTest.sMaHocPhan = txtMaHocPhan.Text;
                    //
                    List<NhomCauHoiDto> DS = new List<NhomCauHoiDto>();
                    int _soNhom = lstvNoiDung.Items.Count;
                    if (_soNhom == 0)
                    {
                        MessageBox.Show("Bổ sung NHÓM CÂU HỎI", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    InfoTest.DanhSachNhomCauHoi.Clear();
                    foreach (ListViewItem item in lstvNoiDung.Items)
                    {
                        NhomCauHoiDto dto1 = new NhomCauHoiDto();
                        dto1.DuongDan = item.SubItems[6].Text;
                        dto1.SoCau = Convert.ToInt32(item.SubItems[1].Text);
                        dto1.SoCauMacDinh = Convert.ToInt32(item.SubItems[2].Text);
                        dto1.Diem = Convert.ToDecimal(item.SubItems[3].Text);
                        dto1.LoaiKho = Convert.ToInt32(item.SubItems[4].Text);
                        dto1.IdKieu = Convert.ToInt32(item.SubItems[7].Text);//colIDKieu
                        //
                        InfoTest.DanhSachNhomCauHoi.Add(dto1);
                    }
                    fInfoTest frm = new fInfoTest();
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                return;
            }            
        }

        private void tvMonHoc_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvMonHoc.SelectedNode;
            if(selectedNode.Level == 3)
            {
                btnThem_Click(null, null);
            }
        }

        private void btnXoaNhom_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstvNoiDung.Items.Count > 0)
                {
                    lstvNoiDung.Items.Remove(lstvNoiDung.SelectedItems[0]);
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            try
            {
                fEditItemListViewFile frm = new fEditItemListViewFile(this);
                frm.ShowDialog();
            }
            catch(Exception ex)
            {

            }

        }

        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            if(tvMonHoc.SelectedNode.Level == 1)//Thêm môn học
            {
                fThemMonHoc frm = new fThemMonHoc(this);
                frm.Them = true;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Không thêm được tại đây./nHãy CHỌN KHOA!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsiSuaThuMuc_Click(object sender, EventArgs e)
        {
            tsbEditFolder_Click(null, null);
        }

        private void tsiThemThuMuc_Click(object sender, EventArgs e)
        {
            tsbAddFolder_Click(null, null);
        }

        private void tsiXoaThuMuc_Click(object sender, EventArgs e)
        {
            tsbDeleteFolder_Click(null, null);
        }

        private void tsiThemTepTin_Click(object sender, EventArgs e)
        {
            tsbAddFile_Click(null, null);
        }

        private void tsiSuaTepTin_Click(object sender, EventArgs e)
        {
            tsbEditFile_Click(null, null);
        }

        private void tsiXoaTepTin_Click(object sender, EventArgs e)
        {
            tsbDeleteFile_Click(null, null);
        }

        private void tsbEditFolder_Click(object sender, EventArgs e)
        {
            if (tvMonHoc.SelectedNode.Level == 2)//Sửa môn học
            {
                fThemMonHoc frm = new fThemMonHoc(this);
                frm.Them = false;
                frm.Text = "Sửa môn học";
                frm.Show();
            }
            else
            {
                MessageBox.Show("Không được sửa tại đây./nHãy CHỌN MÔN HỌC!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tsbDeleteFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if(tvMonHoc.SelectedNode.Level == 2)
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa hay không Y/N?", "Câu hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        MonHocDto dto = new MonHocDto();
                        dto.IDMonHoc = Convert.ToInt32(tvMonHoc.SelectedNode.Tag);
                        MonHocDao dao = new MonHocDao();
                        dao.MonHoc = dto;
                        dao.XoaMonHoc();
                        tvMonHoc.Nodes.Remove(tvMonHoc.SelectedNode);
                    }
                }
                else
                    MessageBox.Show("Hãy CHỌN MÔN HỌC cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hãy CHỌN MÔN HỌC cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
