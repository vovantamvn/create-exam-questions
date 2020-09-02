using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace ViDu1.DataAccess
{
    public class KhoaDao
    {
        ConnectData conn;
        public KhoaDao()
        {
            conn = new ConnectData();
        }
        public DataTable LayDSKhoa()
        {
            string sql = "SELECT IDKhoa, TenKhoa "
                            + "FROM tKhoa ";
            return conn.GetDataTable(sql, false);
        }
        public OleDbDataReader LayDSKhoaReader()
        {
            string sql = "SELECT IDKhoa, TenKhoa "
                            + "FROM tKhoa ";
            OleDbDataReader reader= conn.GetDataReader(sql);
            return reader;
        }
    }
}
