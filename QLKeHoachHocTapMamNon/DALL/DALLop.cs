using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALLop
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        public List<Lop> dsLop()
        {
            return db.Lops.ToList();
        }
        public void insertLop(Lop lop)
        {
            db.Lops.Add(lop);
            db.SaveChanges();
        }
        public void deleteLop(Lop lop)
        {
            db.Lops.Remove(lop);
            db.SaveChanges();
        }
        public Lop getLop(String maLop)
        {
            Lop lop = (from l in db.Lops
                                 where l.MaLop == maLop
                                 select l).Single();
            return lop;
        }
        // phân quyền
        public void updateLop(Lop lop)
        {
            Lop clss = (from l in db.Lops
                                 where l.MaLop == lop.MaLop
                                 select l).Single();
            if (clss != null)
            {
                clss.GVCN = lop.GVCN;
                clss.GVTG = lop.GVTG;
                db.SaveChanges();
            }
        }
        // hiển thị danh sách học sinh của lớp
    }
}
