using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ViDu1.BusinessObject;
using System.Data.OleDb;

namespace ViDu1.DataAccess
{
    class NhomCauHoiDao
    {
        private ConnectData conn;
        private NhomCauHoiDto _nhomCauHoi;
        public NhomCauHoiDto NhomCauHoi
        {
            get { return _nhomCauHoi; }
            set { _nhomCauHoi = value; }
        }
        public NhomCauHoiDao()
        {
            conn = new ConnectData();
            _nhomCauHoi = new NhomCauHoiDto();
        }
        public DataTable LayDSNhomCauHoi()
        {
            string sql = "SELECT m.ID, m.TenFile, m.IDMonHoc, m.DuongDan, m.IDKieu, m.Diem, m.LoaiKho, m.SoCauMacDinh "
                            + ", n.MaMonHoc, n.TenMonHoc "
                            + "FROM tNhom m "
                            + "INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc ";
            return conn.GetDataTable(sql, false);
        }
        public DataTable LayDSNhomCauHoiTheoID(int ID)
        {
            string sql = "SELECT m.ID, m.TenFile, m.IDMonHoc, m.DuongDan, m.IDKieu, m.Diem, m.LoaiKho, m.SoCauMacDinh, m.SoCau, m.NgayTao, m.NgaySua "
                           + ", n.MaMonHoc, n.TenMonHoc, n.IDKhoa "
                           + ", k.TenKieu "
                           + " FROM ((tNhom m "
                           + " INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc) "
                           + " INNER JOIN tKieu k ON m.IDKieu = k.ID) "
                           + " WHERE m.ID =" + ID.ToString()
                           + " GROUP BY m.ID, m.TenFile, m.IDMonHoc, m.DuongDan, m.IDKieu, m.Diem, m.LoaiKho, m.SoCauMacDinh, m.SoCau, n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKieu, m.NgayTao, m.NgaySua";
            return conn.GetDataTable(sql, false);
        }
        public DataTable LayDSNhomCauHoiTheoMH(string maMonHoc)
        {
            string sql = "SELECT m.ID, m.TenFile, m.IDMonHoc, "
                           + " n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa "
                           + " FROM (tNhom m "
                           + " INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc) "
                           + " INNER JOIN tKhoa k ON n.IDKhoa = k.IDKhoa "
                           + " WHERE n.MaMonHoc='" + maMonHoc + "' "
                           + " GROUP BY m.ID, m.TenFile, m.IDMonHoc, n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa";
            return conn.GetDataTable(sql, false);
        }
        public OleDbDataReader LayDSNhomCauHoiTheoMHReader(string maMonHoc)
        {
            string sql = "SELECT m.ID, m.TenFile, m.IDMonHoc, "
                           + " n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa "
                           + " FROM (tNhom m "
                           + " INNER JOIN tMonHoc n ON m.IDMonHoc = n.IDMonHoc) "
                           + " INNER JOIN tKhoa k ON n.IDKhoa = k.IDKhoa "
                           + " WHERE n.MaMonHoc='" + maMonHoc + "' "
                           + " GROUP BY m.ID, m.TenFile, m.IDMonHoc, n.MaMonHoc, n.TenMonHoc, n.IDKhoa, k.TenKhoa";
            return conn.GetDataReader(sql);
        }   
        public bool ThemNhomCauHoi()
        {
            //string sql = string.Format("INSERT INTO tNhom (TenFile, IDMonHoc, DuongDan, IDKieu, Diem, LoaiKho, SoCauMacDinh) "
            //                        + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", 
            //                        NhomCauHoi.TenFile,NhomCauHoi.IdMonHoc, NhomCauHoi.DuongDan,NhomCauHoi.IdKieu,NhomCauHoi.Diem,NhomCauHoi.LoaiKho,NhomCauHoi.SoCauMacDinh);
            string sql = string.Format("INSERT INTO tNhom (ID, TenFile, IDMonHoc, DuongDan, IDKieu, Diem, LoaiKho, SoCauMacDinh, NgayTao, NgaySua, SoCau) "
                                    + " VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', {10})",
                                    NhomCauHoi.ID, NhomCauHoi.TenFile, NhomCauHoi.IdMonHoc, NhomCauHoi.DuongDan, NhomCauHoi.IdKieu, NhomCauHoi.Diem, NhomCauHoi.LoaiKho, NhomCauHoi.SoCauMacDinh, NhomCauHoi.NgayTao, NhomCauHoi.NgaySua, NhomCauHoi.SoCau);
            if (conn.ExecuteQuery(sql))
            {
                return true;
            }
            return false;
        }
        public bool SuaNhomCauHoi()
        {
            string sql = string.Format("UPDATE tNhom SET TenFile='{0}', IDMonHoc='{1}', DuongDan='{2}', IDKieu={3}, Diem={4}, LoaiKho={5}, SoCauMacDinh={6}, NgaySua='{7}', SoCau={8} WHERE ID={9} ",
                                    NhomCauHoi.TenFile, NhomCauHoi.IdMonHoc, NhomCauHoi.DuongDan, NhomCauHoi.IdKieu, NhomCauHoi.Diem, NhomCauHoi.LoaiKho, NhomCauHoi.SoCauMacDinh, NhomCauHoi.NgaySua, NhomCauHoi.SoCau, NhomCauHoi.ID);
            if (conn.ExecuteQuery(sql))
            {
                return true;
            }
            return false;
        }
        public bool XoaNhomCauHoi()
        {
            string sql = "DELETE FROM tNhom WHERE ID ="+ NhomCauHoi.ID.ToString();
            if (conn.ExecuteQuery(sql))
            {
                return true;
            }
            return false;
        }
        public string GetLastID()
        {
            string lastID = conn.GetLastID("tNhom", "ID");
            if (lastID == "")
                lastID = "0";
            return lastID;
        }
        public int NextID()
        {
            return Convert.ToInt32(Utilities.NextID(GetLastID(), ""));
        }
    }
}
