using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class HoaDonService
    {
        public List<HoaDon> GetAll()
        {
            Model1 context = new Model1();
            return context.HoaDons.ToList();
        }
        public void InsertUpdate(HoaDon HD)
        {
            Model1 context = new Model1();
            context.HoaDons.Add(HD);
            context.SaveChanges();
        }
    }
}
