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
    public partial class formThongTinTaiKhoan : Form
    {
        private string mand = FormDangNhap.MaNguoiDung;            
        private readonly TaiKhoanService tksv = new TaiKhoanService();
        //TaiKhoan tk = tksv.GetById("mand");
        public formThongTinTaiKhoan()
        {
            InitializeComponent();
        }


        OpenFileDialog openFile = new OpenFileDialog();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                this.Hide();
        }

        private void formThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            
        }
    }
}
