using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace ViDu1.DataAccess
{
    class ConnectData
    {
        private OleDbConnection conn;
        private OleDbDataAdapter dataAdapter;
        string strConn;//Dường dẫn động, thay đổi trong app.config

        public OleDbDataAdapter DataAdapter
        {
            get { return dataAdapter; }
            set { dataAdapter = value; }
        }

        private DataTable dataTable;

        public DataTable DataTable
        {
            get { return dataTable; }
            set { dataTable = value; }
        }
        private string _error;

        public string Error
        {
            get { return _error; }
        }

        //Tao contructor goi ket noi khi new lop ConnectData
        public ConnectData()
        {
            Console.WriteLine("LOL: Constructor");
            Connect();
        }

        //Ket noi
        private void Connect()
        {
            //Hiện tại, cơ sở dữ liệu nằm trong \\bin\\Debug\\Database\dbTronDe.accdb
            //string strConn = ConfigurationManager.ConnectionStrings["Tron_De_Conn_accdb"].ConnectionString;
            string path = Application.StartupPath;
            Console.WriteLine("LOL: " + path);
            /*---------------Đường dẫn này sử dụng khi lập trình.  
             * ------------------Khi cài đặt, Application.StartupPath là thư mục cài đặt ứng dụng
             * ------------------Khi lập trình, Application.StartupPath là \\bin\\Debug
            //path = path.Replace("\\bin\\Debug", "\\Database\\");
            //string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + "dbTronDe.accdb;User Id=;Password=;";
            //@"Provider=Microsoft.Jet.OLEDB.4.0;C:\Program Files (x86)\KHOA CNTT\TRON DE THI
            */
            //------------GOOG----------------
            //string strConn;
            //strConn = ConfigurationManager.ConnectionStrings["Tron_De_Conn_accdb"].ConnectionString;
            //----------------------------END-----------
            //string strConn;//Sử dụng đc, đường dẫn cứng
            ////strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + "\\dbTronDe.accdb;User Id=;Password=;";
            //strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=D:\\NGÂN HÀNG CÂU HỎI\\Database\\dbTronDe.accdb;User Id=;Password=;";
            
            strConn = ConfigurationManager.ConnectionStrings["Tron_De_Conn_accdb"].ConnectionString;
            //
            try
            {
                conn = new OleDbConnection(strConn);
                conn.Open();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: Kết nối không thành công!");
            }
        }

        //Ham lay du lieu Datatable tu cau truy van truyen vao
        public DataTable GetDataTable(string str)
        {
            //Tao dataAdapter de thuc hien cau truy van
            dataAdapter = new OleDbDataAdapter(str, conn);
            //Do du lieu vao DataTable
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return (dataTable);
        }
        public OleDbDataReader GetDataReader(string str)
        {
            conn = new OleDbConnection(strConn); 
            conn.Open(); 
            OleDbCommand cmd = new OleDbCommand(str, conn); 
            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                MessageBox.Show(reader.GetString(0) + ":2:" + reader.GetString(1));
            }
            conn.Close();
            return reader;
        }
        //Tiep theo ta tao 1 phuong thuc lay DataTable voi cau truy van truyen vao, va 1 thuoc tinh tham so
        //setDataProperties cho phep thay doi properties DataTable va DataAdapter hay khong?
        public DataTable GetDataTable(string str, bool setDataProperties)
        {
            if (setDataProperties)
            {
                //Tao dataAdapter de thuc hien cau truy van
                dataAdapter = new OleDbDataAdapter(str, conn);
                //Do du lieu vao DataTable
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return (dataTable);
            }
            //truong hop ta khong muon thay doi properties
            else
            {
                //Tao moi DataAdapter
                OleDbDataAdapter dataAdap = new OleDbDataAdapter(str, conn);
                DataTable dataTable = new DataTable();
                dataAdap.Fill(dataTable);
                return dataTable;
            }
        }

        //Ham thu hien cau lenh truy van INSERT, UPDATE, DELETE tra ve thuc hien thanh cong hay khong
        public bool ExecuteQuery(string sql)
        {
            int numRecordEffect = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                numRecordEffect = cmd.ExecuteNonQuery();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            if (numRecordEffect > 0)
                return true;
            return false;
        }
        public int ExecuteScalar(string sql)
        {
            int numRecordEffect = 0;
            int id = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                numRecordEffect = cmd.ExecuteNonQuery();
                cmd.CommandText = "Select @@Identity";                
                id = (int)cmd.ExecuteScalar();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return id;
        }
        //Lay ma cuoi cung
        public string GetLastID(string nameTable, string nameField)
        {
            string sql = "SELECT TOP 1 " + nameField + " FROM " + nameTable + " ORDER BY " + nameField + " DESC";
            //thuc hien cau truy van
            DataTable _dataTable = new DataTable();
            _dataTable = GetDataTable(sql, false);
            if (_dataTable.Rows.Count > 0)
                return _dataTable.Rows[0][nameField].ToString();
            else
                return "";
        }

        //Kiem tra co ton tai namefield rong nameTable hay khong
        public bool CheckExistValue(string nameTable, string nameField, string value)
        {
            string sql = "SELECT * FROM " + nameTable + " WHERE " + nameField + " = '" + value + "'";
            DataTable _dataTable = new DataTable();
            _dataTable = GetDataTable(sql, false);
            // Đếm số dòng trả về, nếu > 0  tức tồn tại value
            if (_dataTable.Rows.Count > 0)
                return true;
            return false;
        }

        //
        public int SaveAll()
        {
            int numRecords = 0;
            //Tao doi tuong Transaction
            OleDbTransaction sTran = null;
            try
            {
                //Mo ket noi
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //Mo Transaction
                sTran = conn.BeginTransaction();
                //Tao Transaction quan ly SelectCommand
                dataAdapter.SelectCommand.Transaction = sTran;
                //Tao doi tuong OleDbCommandBuilder quan ly qua trinh thay doi tren DataSource
                OleDbCommandBuilder sBuider = new OleDbCommandBuilder(dataAdapter);// Truyen DataAdapter vao
                //Thuc thi cap nhat DataSource xuong CSDL
                numRecords = dataAdapter.Update(dataTable);
                //Commit data
                sTran.Commit();
            }
            catch (Exception ex)
            {
                //Neu xay ra loi trong qua trinh them
                if (sTran != null)
                    sTran.Rollback();
                _error = ex.Message;
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return numRecords;
        }
    }
}
