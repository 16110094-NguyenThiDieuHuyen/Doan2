using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL
{
   public class DALDGTuan
    {
        QLKHHTMNEntities db = new QLKHHTMNEntities();
        // hien bamg danh gia cua hoc sinh
        public DanhGiaHocSinhTuan bangDG(HocSinh hocSinh)
        {
            DanhGiaHocSinhTuan danhGiaHocSinhTuan = (from b in db.DanhGiaHocSinhTuans
                                                   where b.MaHS == hocSinh.MaHS
                                                   select b).Single();
            return danhGiaHocSinhTuan;
        }
        public void insertBangDG(DanhGiaHocSinhTuan danhGiaHocSinhTuan)
        {
            db.DanhGiaHocSinhTuans.Add(danhGiaHocSinhTuan);
            db.SaveChanges();
        }
        public void updateBangDG(DanhGiaHocSinhTuan danhGiaHocSinhTuan)
        {
            DanhGiaHocSinhTuan danhGia = (from b in db.DanhGiaHocSinhTuans
                                                     where b.MaHS == danhGiaHocSinhTuan.MaHS &&
                                                     b.NgayBatDau == danhGiaHocSinhTuan.NgayBatDau
                                                     select b).Single();
            if(danhGia!=null)
            {
                danhGia.DanhGiaChung = danhGiaHocSinhTuan.DanhGiaChung;
                danhGia.HoatDong = danhGiaHocSinhTuan.HoatDong;
                danhGia.HocTap = danhGiaHocSinhTuan.HocTap;
                danhGia.MaGV = danhGiaHocSinhTuan.MaGV;
                danhGia.MucDoc = danhGiaHocSinhTuan.MucDoc;
                danhGia.SucKhoe = danhGiaHocSinhTuan.SucKhoe;
                db.SaveChanges();
            }
        }
    }
}
