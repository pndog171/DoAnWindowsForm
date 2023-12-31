﻿using BUS.Service;
using DAL.Entities;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUi
{
    public partial class FormMenu : DevExpress.XtraEditors.XtraForm
    {
        private readonly Phuongtien pt = new Phuongtien();
        private readonly Loaiphuongtien lpt = new Loaiphuongtien();
        private readonly Model1 context = new Model1();
        private Xe xe = new Xe();
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnXeHoi_Click(object sender, EventArgs e)
        {
            frmPhuongtien openfrm = new frmPhuongtien();
            openfrm.ShowDialog();

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Bạn có muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
                this.Close();
        }

        private void btnXeMay_Click(object sender, EventArgs e)
        {
            frmPhuongtien openxe = new frmPhuongtien();
            openxe.ShowDialog();
        }

        private void accordionControlElement8_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Bạn có muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
               Application.Exit();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap frmdn = new FormDangNhap();
            DialogResult DR = MessageBox.Show("Bạn có muốn đăng xuất không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                this.Hide();
                frmdn.ShowDialog();
            }
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            FormHoaDon formHoaDon = new FormHoaDon();
            formHoaDon.ShowDialog();
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            FormThemTaiKhoan formThemTaiKhoan = new FormThemTaiKhoan();
            formThemTaiKhoan.ShowDialog();

        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            FormThongTinKhachHang formThongTinKhachHang = new FormThongTinKhachHang();
            formThongTinKhachHang.ShowDialog();
        }
    }     
}
