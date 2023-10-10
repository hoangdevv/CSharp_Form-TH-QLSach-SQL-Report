using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSachRepo
    {
        public static List<LoaiSach> getAll()
        {
            ModelSach modelSach = new ModelSach();
            return modelSach.LoaiSaches.ToList();
        }
    }
}
