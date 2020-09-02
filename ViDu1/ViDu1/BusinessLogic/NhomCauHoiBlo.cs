using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViDu1.BusinessObject;
using ViDu1.DataAccess;
using ViDu1.BusinessObject;

namespace ViDu1.BusinessLogic
{
    class NhomCauHoiBlo
    {
        private NhomCauHoiDto _NhomCauHoiDto;
        private NhomCauHoiDao _NhomCauHoiDao;
        private string _error;

        public NhomCauHoiDto NhomCauHoi
        {
            get { return _NhomCauHoiDto; }
            set { _NhomCauHoiDto = value; }
        }
        
        public string Error
        {
            get { return _error; }
        }

        public NhomCauHoiBlo()
        {
            _NhomCauHoiDto = new NhomCauHoiDto();
            _NhomCauHoiDao = new NhomCauHoiDao();
            _error = "";
        }

        public bool ThemNhomCauHoi()
        {
            _NhomCauHoiDao.NhomCauHoi = NhomCauHoi;
            if (!_NhomCauHoiDao.ThemNhomCauHoi())
            {                
                return false;
            }
            return true;
        }

        public bool SuaNhomCauHoi()
        {
            _NhomCauHoiDao.NhomCauHoi = NhomCauHoi;
            if (!_NhomCauHoiDao.SuaNhomCauHoi())
            {
                return false;
            }
            return true;
        }

        public bool XoaNhomCauHoi()
        {
            _NhomCauHoiDao.NhomCauHoi = NhomCauHoi;
            if (_NhomCauHoiDao.XoaNhomCauHoi())
            {
                return false;
            }
            return true;
        }
    }
}
