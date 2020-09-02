using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViDu1.BusinessObject
{
    public class MonHocDto
    {
        #region "Variables"
        private int _idMonHoc;
        private string _idKhoa;
        private string _maMonHoc;
        private string _tenMonHoc;      
        #endregion

        #region "Properties"
        public int IDMonHoc
        {
            get { return _idMonHoc; }
            set { _idMonHoc = value; }
        }
        public string TenMonHoc
        {
          get { return _tenMonHoc; }
          set { _tenMonHoc = value; }
        }
        public string MaMonHoc
        {
          get { return _maMonHoc; }
          set { _maMonHoc = value; }
        }
        public string IDKhoa
        {
          get { return _idKhoa; }
          set { _idKhoa = value; }
        }
        #endregion
        #region "Constructors"
        public MonHocDto()
        {
            IDMonHoc = 0;
            IDKhoa = "";           
            MaMonHoc = "";
            TenMonHoc = "";
        }        
        #endregion
        
    }
}
