using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUi
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

 

        private void picThoat_Click(object sender, EventArgs e)
        {
            FormDangNhap frmdn = new FormDangNhap();
            DialogResult DR = MessageBox.Show("Bạn có muốn quay lại màn hình đăng nhập không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                this.Hide();
                frmdn.ShowDialog();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

        }

        private void txtTenNguoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtSoDienThoai.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                txtTenTaiKhoan.Focus();
                e.Handled = true;
            }
        }

        private void txtTenTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down)
            {
                cbbgioitinh.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtTenNguoiDung.Focus();
                e.Handled = true;
            }
        }

        private void cbbgioitinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtTenTaiKhoan.Focus();
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtNhapLaiMatKhau.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbbgioitinh.Focus();
                e.Handled = true;
            }
        }

        private void txtNhapLaiMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtEmail.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtSoDienThoai.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtNhapLaiMatKhau.Focus();
                e.Handled = true;
            }
        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtEmail.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
               txtTenNguoiDung.Focus();
                e.Handled = true;
            }
        }

        
    }
}
