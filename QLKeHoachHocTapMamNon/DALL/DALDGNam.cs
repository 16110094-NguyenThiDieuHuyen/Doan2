using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALDGNam
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        // hien bamg danh gia cua hoc sinh
        public DanhGiaHocSinhNam bangDG(HocSinh hocSinh)
        {
            DanhGiaHocSinhNam danhGiaHocSinhNam = (from b in db.DanhGiaHocSinhNams
                                                   where b.HocSinh == hocSinh
                                                   select b).Single();
            return danhGiaHocSinhNam;
        }
        public void insertBangDG (DanhGiaHocSinhNam danhGiaHocSinhNam)
        {
            db.DanhGiaHocSinhNams.Add(danhGiaHocSinhNam);
            db.SaveChanges();
        }
        public void updateBangDG(DanhGiaHocSinhNam danhGiaHocSinhNam)
        {
            DanhGiaHocSinhNam bang = (from b in db.DanhGiaHocSinhNams
                                                   where b.HocSinh == danhGiaHocSinhNam.HocSinh && 
                                                   b.NamHoc == danhGiaHocSinhNam.NamHoc
                                                   select b).Single();
            if(bang!=null)
            {
                bang.TheLuc = danhGiaHocSinhNam.TheLuc;
                bang.Ngonngu = danhGiaHocSinhNam.Ngonngu;
                bang.DanhGiaChung = danhGiaHocSinhNam.DanhGiaChung;
                bang.DanhHieu = danhGiaHocSinhNam.DanhHieu;
                bang.MaGV = danhGiaHocSinhNam.MaGV;
                bang.NhanThuc = danhGiaHocSinhNam.NhanThuc;
                bang.ThamMy = danhGiaHocSinhNam.ThamMy;
                bang.TinhCamQHXH = danhGiaHocSinhNam.TinhCamQHXH;
                db.SaveChanges();
            }
        }
    }
}
