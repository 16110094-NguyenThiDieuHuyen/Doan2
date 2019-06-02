using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
    public class BALCTH
    {
        DALCTH dalhs = new DALCTH();
        public List<ChuongTrinhHoc> GetChuongTrinhHocs(DateTime NgayBD, DateTime NgayKT, Lop lop)
        {
            return dalhs.dsCTH(NgayBD, NgayKT,lop);
        }
       
        public void Insert(ChuongTrinhHoc chuongTrinhHoc)
        {
            dalhs.insertCTH(chuongTrinhHoc);
        }
        public void Delte(ChuongTrinhHoc chuongTrinhHoc)
        {
            dalhs.deleteCT(chuongTrinhHoc);
        }
        public void Update(ChuongTrinhHoc chuongTrinhHoc)
        {
            dalhs.updateCT(chuongTrinhHoc);
        }
    }
}
