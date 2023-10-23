using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class Nhanvien
    {
        public List<TaiKhoan> GetAll()
        {
            using (var context = new Model1())
            {
                return context.TaiKhoans.ToList();
            }
        }

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
        }
    }
}
