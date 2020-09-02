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
    class MonHocDao
    {
        ConnectData conn;
        private MonHocDto _monHoc;
        public MonHocDto MonHoc
        {
            get { return _monHoc; }
            set { _monHoc = value; }
        }
        public MonHocDao()
        {
            conn = new ConnectData();
            _monHoc = new MonHocDto();
        }
        public DataTable LayDSMonHoc()
        {
            string sql = "SELECT m.IDMonHoc, m.IDKhoa, m.MaMonHoc, m.TenMonHoc, n.TenKhoa "
                            + "FROM tMonHoc m "
                            + "INNER JOIN tKhoa n ON m.IDKhoa = n.IDKhoa ";
            return conn.GetDataTable(sql, false);
        }
        public DataTable LayDSMonHoc(string idKhoa)
        {
            string sql = "SELECT m.IDMonHoc, m.IDKhoa, m.MaMonHoc, m.TenMonHoc, n.TenKhoa "
                            + "FROM tMonHoc m "
                            + "INNER JOIN tKhoa n ON m.IDKhoa = n.IDKhoa "
                            + "WHERE m.IDKhoa='"+idKhoa+"'";
            return conn.GetDataTable(sql, false);
        }
        public OleDbDataReader LayDSMonHocReader(string idKhoa)
        {
            string sql = "SELECT m.IDMonHoc, m.IDKhoa, m.MaMonHoc, m.TenMonHoc, n.TenKhoa "
                            + "FROM tMonHoc m "
                            + "INNER JOIN tKhoa n ON m.IDKhoa = n.IDKhoa "
                            + "WHERE m.IDKhoa='" + idKhoa + "'";
            return conn.GetDataReader(sql);
        }
        public int ThemMonHoc()
        {
            int id = 0;
            string sql = string.Format("INSERT INTO tMonHoc (IDKhoa, MaMonHoc, TenMonHoc) "
                                    + " VALUES ('{0}', '{1}', '{2}')",
                                    MonHoc.IDKhoa, MonHoc.MaMonHoc, MonHoc.TenMonHoc);
            id = conn.ExecuteScalar(sql);
            return id;
        }
        public bool SuaMonHoc()
        {
            string sql = string.Format("UPDATE tMonHoc SET IDKhoa='{0}', MaMonHoc='{1}', TenMonHoc='{2}' WHERE IDMonHoc={3}",
                                    MonHoc.IDKhoa, MonHoc.MaMonHoc, MonHoc.TenMonHoc, MonHoc.IDMonHoc);
            if (conn.ExecuteQuery(sql))
            {
                return true;
            }
            return false;
        }
        public bool XoaMonHoc()
        {
            string sql1 = "DELETE FROM tNhom WHERE IDMonHoc =" + MonHoc.IDMonHoc.ToString();
            string sql2 = "DELETE FROM tMonHoc WHERE IDMonHoc =" + MonHoc.IDMonHoc.ToString();
            conn.ExecuteQuery(sql1);//Xóa các nhóm câu hỏi nếu có
            if (conn.ExecuteQuery(sql2))
            {
                return true;
            }
            return false;
        }
    }
}
