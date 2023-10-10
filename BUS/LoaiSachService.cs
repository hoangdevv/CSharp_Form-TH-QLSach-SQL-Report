using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class LoaiSachService
    {
        public static List<LoaiSach> getAllLoaiSach()
        {
            return LoaiSachRepo.getAll();
        }
    }
}
