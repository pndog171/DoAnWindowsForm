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
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

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

   
    }
}
