using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALPhieuKSK
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        // hiển thị toàn bộ danh sách học sinh
        public PhieuKhamSucKhoe dspksk(HocSinh hocSinh, DateTime ngayKham)
        {
            PhieuKhamSucKhoe phieuKhamSucKhoe = (from p in db.PhieuKhamSucKhoes
                                                 where p.MaHS == hocSinh.MaHS && p.NgayKham == ngayKham
                                                 select p).Single();
            return phieuKhamSucKhoe;
        }
        public void insertPhieu(PhieuKhamSucKhoe phieuKhamSucKhoe)
        {
            db.PhieuKhamSucKhoes.Add(phieuKhamSucKhoe);
            db.SaveChanges();
        }
        public void updatePhieu(PhieuKhamSucKhoe phieuKhamSucKhoe)
        {
            PhieuKhamSucKhoe phieu = (from p in db.PhieuKhamSucKhoes
                                                 where p.MaHS ==phieuKhamSucKhoe.MaHS && 
                                                 p.NgayKham == phieuKhamSucKhoe.NgayKham
                                                 select p).Single();
            if(phieu!=null)
            {
                phieu.CanNang = phieuKhamSucKhoe.CanNang;
                phieu.ChieuCao = phieuKhamSucKhoe.ChieuCao;
                phieu.KL = phieuKhamSucKhoe.KL;
                phieu.Mat = phieuKhamSucKhoe.Mat;
                phieu.TaiMuiHong = phieuKhamSucKhoe.TaiMuiHong;
                db.SaveChanges();
            }
        }

    }
}
