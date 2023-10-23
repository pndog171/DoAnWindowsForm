﻿using System;
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
    public partial class FormDangNhap : Form
    {

        public static string MaNguoiDung;

        List<Image> images = new List<Image>();
        string[] location = new string[25];

        public FormDangNhap()
        {
            InitializeComponent();
            /*location[0] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_1.jpg";
            location[1] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_2.jpg";
            location[2] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_4.jpg";
            location[3] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_5.jpg";
            location[4] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_6.jpg";
            location[5] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_7.jpg";
            location[6] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_8.jpg";
            location[7] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_9.jpg";
            location[8] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_10.jpg";
            location[9] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_11.jpg";
            location[10] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_12.jpg";
            location[11] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_13.jpg";
            location[12] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_14.jpg";
            location[13] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_15.jpg";
            location[14] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_16.jpg";
            location[15] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_17.jpg";
            location[16] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_18.jpg";
            location[17] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_19.jpg";
            location[18] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_20.jpg";
            location[19] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_21.jpg";
            location[20] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_22.jpg";
            location[21] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_23.jpg";
            location[22] = @"C:\Users\PHONG\Documents\DoAnMonCNPM-sub2\Login Avatar animation\animation\textbox_user_24.jpg";
            tounage();*/
            txtMatKhau.PasswordChar = '*';
        }

        /*private void tounage()
        {
            for (int i = 0; i < 23; i++)
            {
                Bitmap bitmap = new Bitmap(location[i]);
                images.Add(bitmap);
            }
        }*/

        /*private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Length > 0 && txtTaiKhoan.Text.Length <= 15)
            {
                pictureBox1.Image = images[txtTaiKhoan.Text.Length - 1];
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (txtTaiKhoan.Text.Length <= 0)
                pictureBox1.Image = Properties.Resources.debut;
            else
                pictureBox1.Image = images[22];
        }*/

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Bạn có muốn thoát không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
                this.Close();
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.textbox_password;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FormDangNhap frm = new FormDangNhap();
            string tendangnhap = txtTaiKhoan.Text;
            string matkhau = txtMatKhau.Text;

            int tendangnhaptoithieu = 8;
            int matkhautoithieu = 8;

            int tendangnhaptoida = 22; 
            int matkhautoida = 15; 

            if (string.IsNullOrWhiteSpace(tendangnhap) || string.IsNullOrWhiteSpace(matkhau))
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (tendangnhap.Length < tendangnhaptoithieu )
            {
                MessageBox.Show($"Tên đăng nhập có ít nhất {tendangnhaptoithieu} ký tự.\nVui lòng nhập đúng theo yêu cầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tendangnhap.Length > tendangnhaptoida)
            {
                MessageBox.Show($"Tên đăng nhập tối đa {tendangnhaptoida} ký tự.\nVui lòng nhập đúng theo yêu cầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (matkhau.Length < matkhautoithieu)
            {
                MessageBox.Show($"Mật khẩu tối thiểu {matkhautoithieu} ký tự.\nVui lòng nhập đúng theo yêu cầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (matkhau.Length > matkhautoida)
            {
                MessageBox.Show($"Mật khẩu tối đa {matkhautoida} ký tự.\nVui lòng nhập đúng theo yêu cầu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MaNguoiDung = txtTaiKhoan.Text;
                FormMenu menu = new FormMenu();
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
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
