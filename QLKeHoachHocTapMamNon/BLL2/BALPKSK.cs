using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
   public class BALPKSK
    {
        DALPhieuKSK dalhs = new DALPhieuKSK();
     
        public void Insert(PhieuKhamSucKhoe lop)
        {
            dalhs.insertPhieu(lop);
        }
        public void Update(PhieuKhamSucKhoe lop)
        {
            dalhs.updatePhieu(lop);
        }
        public PhieuKhamSucKhoe getPKSK(HocSinh hocSinh, DateTime Ngaykham)
        {
            return dalhs.dspksk(hocSinh, Ngaykham);
        }
    }
}
