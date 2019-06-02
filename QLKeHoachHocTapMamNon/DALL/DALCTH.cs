using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALCTH
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        public List<ChuongTrinhHoc> dsCTH(DateTime NgayBD, DateTime NgayKT, Lop lop)
        {
            // so sanh hai gia tri thoi gian
            List<ChuongTrinhHoc> dsCT = (from ct in db.ChuongTrinhHocs
                                              // <=0 có nghĩa ngày bắt đầu phải trc ngay tham gia
                                          where DateTime.Compare(NgayBD, ct.NgayThamGia) <= 0 &&
                                          DateTime.Compare(ct.NgayThamGia, NgayKT) <= 0 && ct.MaLop == lop.MaLop
                                          select ct
                                          ).ToList(); 

            return dsCT;
        }
        public void insertCTH(ChuongTrinhHoc chuongTrinhHoc)
        {
            db.ChuongTrinhHocs.Add(chuongTrinhHoc);
            db.SaveChanges();
        }
        public void deleteCT(ChuongTrinhHoc chuongTrinhHoc)
        {
            db.ChuongTrinhHocs.Remove(chuongTrinhHoc);
            db.SaveChanges();
        }
        public void updateCT(ChuongTrinhHoc chuongTrinhHoc)
        {
            ChuongTrinhHoc ct = (from p in db.ChuongTrinhHocs
                                 where p.NgayThamGia == chuongTrinhHoc.NgayThamGia
                                 && p.MaLop == chuongTrinhHoc.MaLop
                                 && p.TGBD == chuongTrinhHoc.TGBD
                                 select p).Single();
            if(ct!=null)
            {
                ct.TGKT = chuongTrinhHoc.TGKT;
                ct.MaGV = chuongTrinhHoc.MaGV;
                ct.PhongHoc = chuongTrinhHoc.PhongHoc;
                ct.NoiDung = chuongTrinhHoc.NoiDung;
                ct.GhiChu = chuongTrinhHoc.GhiChu;
                db.SaveChanges();
            }
        }
    }
}
