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
        public formThongTinTaiKhoan()
        {
            InitializeComponent();
        }


        OpenFileDialog openFile = new OpenFileDialog();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                string filePath = openFile.FileName;


                pictureBox1.Image = Image.FromFile(filePath);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormMenu frmdn = new FormMenu();
            DialogResult DR = MessageBox.Show("Bạn có muốn quay lại màn hình đăng nhập không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                this.Hide();
                frmdn.ShowDialog();
            }
        }

  
    }
}
