using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class TaiKhoanService
    {
        public List<TaiKhoan> GetAll()
        {
            Model1 context = new Model1();
            return context.TaiKhoans.ToList();
        }
<<<<<<< Updated upstream
        public List<TaiKhoan> FindByName(string name)
        {
         
                Model1 context = new Model1();
                return context.TaiKhoans.Where(p => p.TenNguoiDung.ToLower().Contains(name.ToLower())).ToList();
            
        }
        public void InsertUpdate(TaiKhoan item)
        {
            Model1 context = new Model1();
            context.TaiKhoans.AddOrUpdate(item);
            context.SaveChanges();
=======
        public void Insert(TaiKhoan nhanvienmoi)
        {
            using (var context = new Model1())
            {
                context.TaiKhoans.Add(nhanvienmoi);
                context.SaveChanges();
            }

        }

        public void Update(TaiKhoan suanhanvien)
        {
            using (var context = new Model1())
            {
                var existingNhanVien = context.TaiKhoans.Find(suanhanvien.TenTK);
                if (existingNhanVien != null)
                {
                    context.Entry(existingNhanVien).CurrentValues.SetValues(suanhanvien);
                }
                else
                {
                    context.TaiKhoans.Add(suanhanvien);
                }
                context.SaveChanges();
            }
        }
        public void Delete(string tenTaiKhoan)
        {
            using (var context = new Model1())
            {
                var nhanVienToDelete = context.TaiKhoans.Find(tenTaiKhoan);
                if (nhanVienToDelete != null)
                {
                    context.TaiKhoans.Remove(nhanVienToDelete);
                    context.SaveChanges();
                }
            }
>>>>>>> Stashed changes
        }
    }
}
