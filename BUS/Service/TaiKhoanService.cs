using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
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
        public List<TaiKhoan> FindByName(string name)
        {       
            Model1 context = new Model1();
            return context.TaiKhoans.Where(p => p.TenNguoiDung.ToLower().Contains(name.ToLower())).ToList();        
        }
        public TaiKhoan GetById(string id) 
        {
            Model1 context = new Model1();
            return context.TaiKhoans.FirstOrDefault(b => b.TenTK == id);
        }
        public void InsertUpdate(TaiKhoan itembruh)
        {
            Model1 ct = new Model1();
            ct.TaiKhoans.Add(itembruh);
            ct.SaveChanges();
        }

        public void Insert(TaiKhoan nhanvienmoi)
        {
            using (var context = new Model1())
            {
                context.TaiKhoans.Add(nhanvienmoi);
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
        }
    }
}
