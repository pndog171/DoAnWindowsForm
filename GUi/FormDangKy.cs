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
using BUS;
using BUS.Service;
using DAL.Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Text.RegularExpressions;

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
            //if (e.KeyCode == Keys.Up)
            //{
            //    txtSoDienThoai.Focus();
            //    e.Handled = true;
            //}
            //if (e.KeyCode == Keys.Down)
            //{
            //    txtTenTaiKhoan.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtTenTaiKhoan_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Down)
            //{
            //    cbbgioitinh.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    txtTenNguoiDung.Focus();
            //    e.Handled = true;
            //}
        }

        private void cbbgioitinh_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    txtMatKhau.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    txtTenTaiKhoan.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    txtNhapLaiMatKhau.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    cbbgioitinh.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtNhapLaiMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    txtEmail.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    txtMatKhau.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    txtSoDienThoai.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    txtNhapLaiMatKhau.Focus();
            //    e.Handled = true;
            //}
        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    txtEmail.Focus();
            //    e.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Down)
            //{
            //   txtTenNguoiDung.Focus();
            //    e.Handled = true;
            //}
        }

        private readonly Dangky dangky = new Dangky();
        private TaiKhoan taiKhoan = new TaiKhoan();

        private void FormDangKy_Load(object sender, EventArgs e)
        {



        }

        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            if (Check())
            {
                string tentk = txtTenTaiKhoan.Text;

                if (KiemTraTaiKhoanTonTai(tentk))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Xin nhập tên tài khoản khác.");
                }
                else
                {
                    TaiKhoan dangky = new TaiKhoan
                    {
                        TenTK = tentk,
                        MatKhau = txtMatKhau.Text,
                        email = txtEmail.Text,
                        TenNguoiDung = txtTenNguoiDung.Text,
                        SDT = txtSoDienThoai.Text,
                    };

                    var DangkyService = new Dangky();
                    DangkyService.Insert(dangky);

                    ClearValue(); 

                    MessageBox.Show("Đăng ký tài khoản thành công!"); 
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ các thông tin còn thiếu !");
            }
        }

        private void ClearValue()
        {
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtNhapLaiMatKhau.Text = "";
            txtEmail.Text = "";
            txtTenNguoiDung.Text = "";
            txtSoDienThoai.Text = "";
        }

        private bool KiemTraTaiKhoanTonTai(string tentk)
        {
            using (var context = new Model1())
            {
                return context.TaiKhoans.Any(p => p.TenTK == tentk);
            }
        }

        private bool Check()
        {

            if (string.IsNullOrEmpty(txtTenTaiKhoan.Text) || txtTenTaiKhoan.Text.Length < 8)
            {
                MessageBox.Show("Tên tài khoản phải chứa ít nhất 8 ký tự.");
                return false;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text) || txtMatKhau.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 8 ký tự.");
                return false;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email.");
                return false;
            }
            if (!KiemTraEmail(txtEmail.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ. Địa chỉ email phải có đuôi '.com'.");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenNguoiDung.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng.");
                return false;
            }
            if (string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                return false;
            }

            return true;
        }

        private bool KiemTraEmail(string email)
        {
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }
    }

       
    }

