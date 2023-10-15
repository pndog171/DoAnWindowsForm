using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS.Service
{
    public class Loaiphuongtien
    {
        public List<LoaiXe> GetAll(string idLoai)
        {
            Model1 context = new Model1();
            return context.LoaiXes.Where( p => p.MaLoai == idLoai ).ToList();
        }
        public List<LoaiXe> GetAllType()
        {
            Model1 context = new Model1();
            return context.LoaiXes.ToList();
        }
    }
}
