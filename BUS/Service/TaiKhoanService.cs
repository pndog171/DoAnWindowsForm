﻿using DAL.Entities;
using System;
using System.Collections.Generic;
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
        public void DangKy(TaiKhoan taiKhoan)
        {
            using (var context = new Model1())
            {
                context.TaiKhoans.Add(taiKhoan);
                context.SaveChanges();
            }
        }
    }
}
