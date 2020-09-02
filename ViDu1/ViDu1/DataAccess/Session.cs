using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ViDu1.DataAccess
{
    class Session
    {
        public static string UserName = "minh";
        public static fMain MAIN;
        public static fLogin LOGIN;
        public static string strConn = ConfigurationManager.ConnectionStrings["Tron_De_Conn_accdb"].ConnectionString;
    }
}
