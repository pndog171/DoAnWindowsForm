using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class Khachhang
    {
        public List<KhachHang> GetAll()
        {
            using (var context = new Model1())
            {
                return context.KhachHangs.ToList();
            }
        }

        public void Insert(KhachHang khach)
        {
            using (var context = new Model1())
            {
                context.KhachHangs.Add(khach);
                context.SaveChanges();
            }
        }

        public void Update(KhachHang khach)
        {
            using (var context = new Model1())
            {
                var existingKhachHang = context.KhachHangs.Find(khach.MaKH);
                if (existingKhachHang != null)
                {
                    context.Entry(existingKhachHang).CurrentValues.SetValues(khach);
                }
                else
                {
                    context.KhachHangs.Add(khach);
                }
                context.SaveChanges();
            }
        }
    }
}
