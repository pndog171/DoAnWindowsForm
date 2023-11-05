using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Service;
using DAL.Entities;

namespace GUi
{
    public partial class FormXemHoaDon : Form
    {
        public FormXemHoaDon()
        {
            InitializeComponent();
        }
        private void Bindgrid(List<HoaDon> hoadon)
        {
            dgvXemHD.Rows.Clear();
            foreach (HoaDon i in hoadon)
            {
                int index = dgvXemHD.Rows.Add();
                dgvXemHD.Rows[index].Cells[0].Value = i.MaHD;
                dgvXemHD.Rows[index].Cells[1].Value = i.KhachHang.TenKH;
                dgvXemHD.Rows[index].Cells[2].Value = i.NgayThue;
                dgvXemHD.Rows[index].Cells[3].Value = i.NgayTra;
                dgvXemHD.Rows[index].Cells[4].Value = i.NgayThanhToan;
                dgvXemHD.Rows[index].Cells[5].Value = i.TaiKhoan.TenNguoiDung;
                dgvXemHD.Rows[index].Cells[6].Value = i.Xe.TenXe;
                dgvXemHD.Rows[index].Cells[7].Value = i.TongTien;
            }
        }
        private void FormXemHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                var hoadonService = new HoaDonService();
                var listhoadon = hoadonService.GetAll();
                Bindgrid(listhoadon);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
