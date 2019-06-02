using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
   public class BALDGNam
    {

        DALDGNam dALDGNam = new DALDGNam(); 

        public void Insert(DanhGiaHocSinhNam lop)
        {
            dALDGNam.insertBangDG(lop);
        }
        public void Update(DanhGiaHocSinhNam lop)
        {
            dALDGNam.updateBangDG(lop);
        }
        public DanhGiaHocSinhNam getPKSK(HocSinh hocSinh)
        {
            return dALDGNam.bangDG(hocSinh);
        }

    }
}
