using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
    public class BALHS
    {
        DALHocSinh dalhs = new DALHocSinh();
        public HocSinh getHocSih(string id)
        {

            return dalhs.gethSinh(id);
        }
        public List<HocSinh> getHocSinh()
        {
            return dalhs.dshSinh();
        }
        public List<HocSinh> getHocSinh(string ten)
        {
            return dalhs.GetHocSinhs(ten);
        }
        public void Insert(HocSinh hocSinh)
        {
            dalhs.inserthSinh(hocSinh);
        }
        public void Delte(HocSinh hocSinh)
        {
            dalhs.deletehSinh(hocSinh);
        }
        public void Update(HocSinh hocSinh)
        {
            dalhs.updatehSinh(hocSinh);
        }
        public List<HocSinh> getHStheoDSLop(string malop)
        {
            return dalhs.getHStheoDSLop(malop);
        }
    }
}
