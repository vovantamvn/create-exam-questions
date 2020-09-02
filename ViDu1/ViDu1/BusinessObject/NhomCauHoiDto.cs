using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViDu1.BusinessObject
{
    public class NhomCauHoiDto
    {
                 #region "Variables"
        private int _ID_Nhom;
        private string _tenFile;
        private int _idMonHoc;
        private string _duongDan;
        private int _idKieu;
        private decimal _diem;
        private int _loaiKho;
        private int _soCauMacDinh;
        private int _soCau;
        private DateTime _ngayTao;
        private DateTime _NgaySua;        
        #endregion

        #region "Properties"
        public int ID
        {
            get { return _ID_Nhom; }
            set { _ID_Nhom = value; }
        }
        public int SoCauMacDinh
        {
          get { return _soCauMacDinh; }
          set { _soCauMacDinh = value; }
        }
        public int LoaiKho
        {
          get { return _loaiKho; }
          set { _loaiKho = value; }
        }public decimal Diem
        {
          get { return _diem; }
          set { _diem = value; }
        }
        public int IdKieu
        {
          get { return _idKieu; }
          set { _idKieu = value; }
        }
        public string DuongDan
        {
          get { return _duongDan; }
          set { _duongDan = value; }
        }
        public int IdMonHoc
        {
          get { return _idMonHoc; }
          set { _idMonHoc = value; }
        }

        public string TenFile
        {
          get { return _tenFile; }
          set { _tenFile = value; }
        }
        public int SoCau
        {
            get { return _soCau; }
            set { _soCau = value; }
        }
        public DateTime NgaySua
        {
            get { return _NgaySua; }
            set { _NgaySua = value; }
        }
        public DateTime NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
        } 
        #endregion
        #region "Constructors"
        public NhomCauHoiDto()
        {
            ID = 0;
            TenFile = "";
            IdMonHoc = 0;
            DuongDan = "";
            IdKieu = 1;
            Diem = 0;
            LoaiKho = 1;
            SoCauMacDinh = 1;
            SoCau = 0;
            NgayTao = DateTime.Now;
            NgaySua = DateTime.Now;
        }
        public NhomCauHoiDto(int _id, string _tenFile, int _idMonHoc, string _duongDan, 
            int _idKieu, decimal _diem, int _loaiKho, int _soCauMacDinh, int _soCau, DateTime _ngayTao, DateTime _ngaySua)
        {
            ID = _id;
            TenFile = _tenFile;
            IdMonHoc = _idMonHoc;
            DuongDan = _duongDan;
            IdKieu = _idKieu;
            Diem = _diem;
            LoaiKho = _loaiKho;
            SoCauMacDinh = _soCauMacDinh;
            SoCau = _soCau;
            NgayTao = _ngayTao;
            NgaySua = _NgaySua;
        }
        #endregion
    }
}
