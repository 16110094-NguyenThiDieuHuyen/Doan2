using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALL;

namespace BLL2
{
    public class BALGV
    {
        DALGV dagv = new DALGV();
       public GiaoVien getGiaoVien(string id, string Pass)
        {
            GiaoVien giaoVien = null;
            giaoVien = dagv.getgVien(id, Pass);
            return giaoVien;
        }
        public List<object> getGiaoVien(string ten)
        {
            return dagv.getgVien(ten);
        }
        public GiaoVien getGVien(string id)
        {
            return dagv.getGiaoVien(id);
        }
        public void CapNhapPass(GiaoVien giaoVien,string Passmoi)
        {
            giaoVien.Password = Passmoi;
            dagv.updategVien(giaoVien);
        }
        public List<GiaoVien> getds()
        {
            return dagv.dsGiaoVien();
        }
        public void Insert(GiaoVien giaoVien)
        {
            dagv.insertgVien(giaoVien);
        }
        public void Delte(GiaoVien giaoVien)
        {
            dagv.deletegVien(giaoVien);
        }
        public void Update(GiaoVien giaoVien)
        {
            dagv.updategVien(giaoVien);
        }
    }
}
