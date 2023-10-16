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
        public void InsertUpdate(KhachHang khach)
        {
            Model1 context = new Model1();
            context.KhachHangs.Add(khach);
            context.SaveChanges();
        }
    }
}
