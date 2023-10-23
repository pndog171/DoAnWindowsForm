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
    public partial class FormInHoaDon : Form
    {
        public string DateLap, DateNhan, DateTra, TenKH, TenXe, TenLoai, TenNV, SoNgayThue, Gia, VAT, TongTien;
        public FormInHoaDon()
        {
            InitializeComponent();
        }

        private void FormInHoaDon_Load(object sender, EventArgs e)
        {
            lbNgayLap.Text = DateLap;
            lbTenKH.Text = TenKH;
            lbTenNV.Text = TenNV;
            lbTenXe.Text = TenXe;
            lbLoai.Text = TenLoai;
            lbDateNhan.Text = DateNhan;
            lbDateTra.Text = DateTra;
            lbSoNgayThue.Text = SoNgayThue;
            lbGia.Text = Gia;
            lbVAT.Text = VAT;
            lbTongTien.Text = TongTien;
        }
    }
}
