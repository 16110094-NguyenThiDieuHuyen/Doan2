using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALHocSinh
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        // hiển thị toàn bộ danh sách học sinh
        public List<HocSinh> dshSinh()
        {
            return db.HocSinhs.ToList();
        }
        public void inserthSinh(HocSinh hocSinh)
        {
            db.HocSinhs.Add(hocSinh);
            db.SaveChanges();
        }
        public void updatehSinh(HocSinh hocSinh)
        {
            HocSinh hSinh = (from hs in db.HocSinhs
                             where hs.MaHS == hocSinh.MaHS
                             select hs).Single();
            if (hSinh != null)
            {
                hSinh.MaLop = hocSinh.MaLop;
                hSinh.NgaySinh = hocSinh.NgaySinh;
                hSinh.HoTen = hocSinh.HoTen;
                hSinh.GioiTinh = hocSinh.GioiTinh;
                hSinh.HoTenNT1 = hocSinh.HoTenNT1;
                hSinh.EmailNT1 = hocSinh.EmailNT1;
                hSinh.DTNT1 = hocSinh.DTNT1;
                hSinh.HoTenNT2 = hocSinh.HoTenNT2;
                hSinh.EmailNT2 = hocSinh.EmailNT2;
                hSinh.DTNT2 = hocSinh.DTNT2;
                hSinh.ĐiaChi = hocSinh.ĐiaChi;
                hSinh.Hinh = hocSinh.Hinh;

                db.SaveChanges();
            }
        }
        public void deletehSinh(HocSinh hocSinh)
        {
            db.HocSinhs.Remove(hocSinh);
            db.SaveChanges();
        }
        public HocSinh gethSinh(String maHS)
        {
            HocSinh hocSinh = (from hs in db.HocSinhs
                               where hs.MaHS == maHS
                               select hs).Single();
            return hocSinh;
        }
        public List<HocSinh> GetHocSinhs(string ten)
        {
            List<HocSinh> hocSinhs =(from hs in db.HocSinhs
                                     where hs.HoTen == ten
                                     select hs).ToList();
            return hocSinhs;
        }
        // hiển thị học sin h theo danh sách lớp 
        public List<HocSinh> getHStheoDSLop(string maLop)
        {
            List<HocSinh> ls = db.HocSinhs.SqlQuery("select * from HocSinh where MaLop = '" + maLop + "'")
                .ToList();
            return ls;
        }

    }
}
