using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SachRepo
    {

        public static List<Sach> getAll()
        {
            ModelSach modelSach = new ModelSach();
            var sachList = modelSach.Saches.ToList();

            foreach (var s in sachList)
            {
                var loaiSach = modelSach.LoaiSaches.FirstOrDefault(l => l.MaLoai == s.MaLoai);
                if (loaiSach != null)
                {
                    s.TenLoaiSach = loaiSach.TenLoai;
                }
            }
            return sachList;
        }
        public static List<Sach> SortByDescending()
        {
            ModelSach modelSach = new ModelSach();
            var sachList = modelSach.Saches.OrderByDescending(p => p.NamXB).ToList();
            foreach (var s in sachList)
            {
                var loaiSach = modelSach.LoaiSaches.FirstOrDefault(l => l.MaLoai == s.MaLoai);
                if (loaiSach != null)
                {
                    s.TenLoaiSach = loaiSach.TenLoai;
                }
            }
            return sachList;
        }
        public static void add(Sach sach)
        {
            ModelSach modelSach = new ModelSach();
            modelSach.Saches.Add(sach);
            modelSach.SaveChanges();
        }

        public static void fix(Sach sach)
        {
            ModelSach modelSach = new ModelSach();
            var existingSach = modelSach.Saches.FirstOrDefault(s => s.MaSach == sach.MaSach);

            if (existingSach != null)
            {
                existingSach.TenSach = sach.TenSach;
                existingSach.NamXB = sach.NamXB;
                existingSach.MaLoai = sach.MaLoai;
                modelSach.SaveChanges();
            }
        }

        public static void delete(string id)
        {
            ModelSach modelSach = new ModelSach();
            var existingSach = modelSach.Saches.FirstOrDefault(s=> s.MaSach == id);
            if (existingSach != null)
            {
                modelSach.Saches.Remove(existingSach);
            }
            modelSach.SaveChanges();
        }

        public static List<Sach> SearchListSach(string key)
        {
            ModelSach modelSach = new ModelSach();
            var result = modelSach.Saches.Where(p=> p.MaSach.Contains(key.ToLower()) || p.TenSach.Contains(key.ToLower()) || p.NamXB.ToString().Contains(key.ToLower())).ToList();
            return result;
        }
    }
}
