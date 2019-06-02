using DALL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL2
{
   public class BALLop
    {
        DALLop dalhs = new DALLop();
        public List<Lop> GetLops()
        {
            return dalhs.dsLop();
        }

        public void Insert(Lop lop)
        {
            dalhs.insertLop(lop);
        }
        public void Delte(Lop lop)
        {
            dalhs.deleteLop(lop);
        }
        public void Update(Lop lop)
        {
            dalhs.updateLop(lop);
        }
        public Lop GetLop(string malop)
        {
            return dalhs.getLop(malop);
        }
    }
}
