using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;

namespace GUi
{
    public partial class FormDangNhap : Form
    {
        Model1 context = new Model1();

        public FormDangNhap()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';
        }
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Bạn có muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
                Application.Exit();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.textbox_password;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {   
            
            try
            {
                string pass = GlobalFunc.CalculateMD5Hash(txtMatKhau.Text.Trim());

                TaiKhoan acc = context.TaiKhoans.Where(r => r.TenTK == txtTaiKhoan.Text.Trim() && r.MatKhau == pass).FirstOrDefault();
                if(txtTaiKhoan.Text=="" || txtMatKhau.Text=="")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                }
                else if (acc!=null)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    FormMenu menu = new FormMenu();
                    this.Hide();
                    menu.ShowDialog();
                    this.Show();
                }
                else MessageBox.Show("Tên tài khoản không tồn tại hoặc mật khẩu chưa đúng!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /*if(Properties.Settings.Default.Username!=string.Empty)
            {
                txtTaiKhoan.Text= Properties.Settings.Default.Username;
                txtMatKhau.Text= Properties.Settings.Default.Password;
            }*/
            
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {

                this.Hide();
                FormDangKy openfrm = new FormDangKy();
                openfrm.ShowDialog();

            
        }

        private void txtTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                txtMatKhau.Focus();
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtTaiKhoan.Focus();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                txtTaiKhoan.Focus();
                e.Handled = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0'; 
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
