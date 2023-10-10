using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class SachService
    {
        public static List<Sach> getAllSach()
        {
            return SachRepo.getAll();
        }
        public static bool addSach(Sach sach)
        {
            var context = new ModelSach();
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    SachRepo.add(sach);
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }

            }
        }

        public static bool fixSach(Sach sach) 
        {
            var context = new ModelSach();
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingSach = context.Saches.FirstOrDefault(s => s.MaSach == sach.MaSach);

                    if (existingSach != null)
                    {
                        // Cập nhật thông tin sách
                        existingSach.TenSach = sach.TenSach;
                        existingSach.NamXB = sach.NamXB;
                        existingSach.MaLoai = sach.MaLoai;
                        SachRepo.fix(sach);
                        transaction.Commit();
                        return true;
                    }
                    return false;
                   
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }

            }
        }

        public static bool deleteSach(string id)
        {
            var context = new ModelSach();
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingSach = context.Saches.FirstOrDefault(s => s.MaSach == id);

                    if (existingSach != null)
                    {
                        
                        context.Saches.Remove(existingSach);
                        SachRepo.delete(id);
                        transaction.Commit();
                        return true;
                    }
                    return false;

                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }

            }
        }

        public static List<Sach> sortByYear()
        {
            return SachRepo.SortByDescending();
        }

    }
}
