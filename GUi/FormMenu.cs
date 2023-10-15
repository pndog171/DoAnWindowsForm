using BUS.Service;
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
    public partial class FormMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
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

        private void accordionControlElement5_Click(object sender, EventArgs e)
        {

        }

    }

       
}
