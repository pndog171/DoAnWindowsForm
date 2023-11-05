using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BUS.Service
{
    public class Phuongtien
    {
        public List<Xe> GetAll()
        {
            Model1 context = new Model1();
            return context.Xes.ToList();
        }
        public Xe FindByID(string id)
        {
            Model1 context = new Model1();
            return context.Xes.FirstOrDefault( p => p.MaXe == id);
        }
        public List<Xe> FindByName(string name)
        {
            Model1 context = new Model1();
            return context.Xes.Where(p => p.MaXe.ToLower().Contains(name.ToLower())).ToList(); ;
        }
        public void InsertUpdate(Xe xe)
        {
            Model1 context = new Model1();
            context.Xes.Add(xe);
            context.SaveChanges();
        }
        public Xe CheckStatus(bool name)
        {
            Model1 context = new Model1();
            return context.Xes.FirstOrDefault(p => p.Status == name);
        }
    }
}
