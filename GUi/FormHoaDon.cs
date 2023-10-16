using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL.Entities;

namespace GUi
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        //combobox Ten nhan vien
        private void FillNhanVienCombobox(List<TaiKhoan> listNhanViens)
        {
            listNhanViens.Insert(0, new TaiKhoan());
            this.cbbNhanVien.DataSource = listNhanViens;
            this.cbbNhanVien.DisplayMember = "TenNguoiDung";
            this.cbbNhanVien.ValueMember = "TenTK";
        }
        //combobox Ten khach hang
        private void FillKhachHangCombobox(List<KhachHang> listKhachHangs)
        {
            listKhachHangs.Insert(0, new KhachHang());
            this.cbbKhachHang.DataSource = listKhachHangs;
            this.cbbKhachHang.DisplayMember = "TenKH";
            this.cbbKhachHang.ValueMember = "MaKH";
        }
        //combobox Ten xe
        private void FillXeCombobox(List<Xe> listXes)
        {
            listXes.Insert(0, new Xe());
            this.cbbTenXe.DataSource = listXes;
            this.cbbTenXe.DisplayMember = "TenXe";
            this.cbbTenXe.ValueMember = "MaXe";
        }
    }
}
