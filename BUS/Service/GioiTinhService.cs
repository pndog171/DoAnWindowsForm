using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class GioiTinhService
    {
        public List<GioiTinh> GetAll()
        {
            Model1 context = new Model1();
            return context.GioiTinhs.ToList();
        }
    }
}
