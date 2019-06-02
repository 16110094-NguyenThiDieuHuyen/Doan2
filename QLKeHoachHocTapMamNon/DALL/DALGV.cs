using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALGV
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        // hiển thị toàn bộ danh sách
        public List<GiaoVien> dsGiaoVien()
        {
            return db.GiaoViens.ToList();
        }
        public void insertgVien(GiaoVien giaoVien)
        {
            db.GiaoViens.Add(giaoVien);
            db.SaveChanges();
        }
        public void deletegVien(GiaoVien giaoVien)
        {
            db.GiaoViens.Remove(giaoVien);
            db.SaveChanges();
        }
        public List<object> getgVien(String tenGV)
        {
            var giaoVien = (from gv in db.GiaoViens
                               where gv.TenGV == tenGV
                               select new { gv.MaGV, gv.TenGV, gv.BoMon, gv.Hinh });
            return giaoVien.ToList<object>() ;
        }
        public GiaoVien getGiaoVien(string ma)
        {
            GiaoVien giaoVien = db.GiaoViens.Find(ma);
            return giaoVien;
        }
        public GiaoVien getgVien(String MaGV, String Pass)
        {
            GiaoVien giaoVien = null;
            giaoVien = (from gv in db.GiaoViens
                                 where gv.MaGV == MaGV && gv.Password == Pass
                                 select gv).SingleOrDefault();
            return giaoVien;
        }
        public void updategVien(GiaoVien gv)
        {
            GiaoVien giaoVien = db.GiaoViens.Find(gv.MaGV);
            if(giaoVien !=null)
            {
                giaoVien.TenGV = gv.TenGV;
                giaoVien.BoMon = gv.BoMon;
                giaoVien.Password = gv.Password;
                giaoVien.Hinh = gv.Hinh;
                giaoVien.Quyen = gv.Quyen;
                db.SaveChanges();
            }
        }
    }
}
