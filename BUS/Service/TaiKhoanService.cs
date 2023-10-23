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
        public void InsertUpdate(TaiKhoan item)
        {
            Model1 context = new Model1();
            context.TaiKhoans.AddOrUpdate(item);
            context.SaveChanges();
        }
    }
}
