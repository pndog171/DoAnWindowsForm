using BUS.Service;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUi
{
    public partial class FormThongTinKhachHang : Form
    {
        public FormThongTinKhachHang()
        {
            InitializeComponent();
        }
        private KhachHang khachHang = new KhachHang();
        private void FormThongTinKhachHang_Load(object sender, EventArgs e)
        {

            var khachhangService = new Khachhang();
            var listKhach = khachhangService.GetAll();
            BindGridKhach(listKhach);
        }

        
        
        private void BindGridKhach(List<KhachHang> kh)
        {
            dtGVKhachHang.Rows.Clear();
            foreach (KhachHang x in kh)
            {
                int index = dtGVKhachHang.Rows.Add();
                dtGVKhachHang.Rows[index].Cells[0].Value = x.MaKH;
                dtGVKhachHang.Rows[index].Cells[1].Value = x.TenKH;
                dtGVKhachHang.Rows[index].Cells[2].Value = x.SDTKH;
            }
        }
        private int getSelectedRow(string makh)
        {
            for (int i = 0; i < dtGVKhachHang.Rows.Count; i++)
            {
                if (dtGVKhachHang.Rows[i].Cells[0].Value.ToString() == makh)
                {
                    return i;
                }
            }
            return -1;
        }



    }
}
