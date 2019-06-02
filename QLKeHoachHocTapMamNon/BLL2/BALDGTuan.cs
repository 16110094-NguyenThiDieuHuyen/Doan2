using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
   public class BALDGTuan
    {

        DALDGTuan dalhs = new DALDGTuan();

        public void Insert(DanhGiaHocSinhTuan lop)
        {
            dalhs.insertBangDG(lop);
        }
        public void Update(DanhGiaHocSinhTuan lop)
        {
            dalhs.updateBangDG(lop);
        }
        public DanhGiaHocSinhTuan getPKSK(HocSinh hocSinh)
        {
            return dalhs.bangDG(hocSinh);
        }
    }
}
