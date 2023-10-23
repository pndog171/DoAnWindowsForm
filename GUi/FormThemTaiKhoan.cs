using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;
using BUS.Service;

namespace GUi
{
    public partial class FormThemTaiKhoan : Form
    {
        private TaiKhoan tk = new TaiKhoan();
        private readonly TaiKhoanService tksv = new TaiKhoanService();
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {

        }

        private void dtGVXemay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }


        //PRIVATE FUNCTION DO NOT TOUCH ANY THINGS IN HERE

        private void BindgridN(List<TaiKhoan> account)
        {
            dtGVNV.Rows.Clear();
            foreach (TaiKhoan i in account)
            {
                int index = dtGVNV.Rows.Add();
                dtGVNV.Rows[index].Cells[0].Value = i.TenTK;
                dtGVNV.Rows[index].Cells[1].Value = i.MatKhau;
                dtGVNV.Rows[index].Cells[2].Value = i.email;
                dtGVNV.Rows[index].Cells[3].Value = i.TenNguoiDung;
                dtGVNV.Rows[index].Cells[4].Value = i.SDT;
                if (i.GioiTinh != null)
                {
                    dtGVNV.Rows[index].Cells[5].Value = i.GioiTinh.GioiTinh1;
                }
            }
        }
        private void FillGenderComboBox(List<TaiKhoan> accountlist)
        {
            accountlist.Insert(0, new TaiKhoan());
            this.cbbGioiTinh.DataSource = accountlist;
            this.cbbGioiTinh.DisplayMember = "GioiTinh1";
            this.cbbGioiTinh.ValueMember = "MaGioiTinh";
        }
        private bool checkValue()
        {
            if (txtTenTK.Text == "" || txtMK.Text == "" || txtEmail.Text == "" || txtFullName.Text == "" || txtSdth.Text == "")
            {
                return false;
            }
            return true;
        }
        private void clearValue()
        {
            txtTenTK.Text = txtMK.Text = txtEmail.Text = txtFullName.Text = txtSdth.Text = "";
        }
        private void getValue()
        {
            string selectedGender = (string)cbbGioiTinh.SelectedValue;
            tk.TenTK = txtTenTK.Text;
            tk.MatKhau = txtMK.Text;
            tk.email = txtEmail.Text;
            tk.TenNguoiDung = txtTenTK.Text;
            tk.SDT = txtSdth.Text;
        }
        /*private int GetSelectedRow( string nameaccount)
        {
            for(int n)
        }*/
    }
}
