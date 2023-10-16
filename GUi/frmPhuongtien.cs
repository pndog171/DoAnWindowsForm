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
    public partial class frmPhuongtien : Form
    {
        private readonly Phuongtien pt = new Phuongtien();
        private readonly Loaiphuongtien lpt = new Loaiphuongtien();
        private readonly Model1 context = new Model1();
        private Xe xe = new Xe();
        public frmPhuongtien()
        {
            InitializeComponent();
        }

        private void btnXeMay_Click(object sender, EventArgs e)
        {
            
        }

        private void frmPhuongtien_Load(object sender, EventArgs e)
        {
            try
            {
                var listTheloai = lpt.GetAll(ToString());
                var listXe = pt.GetAll();
                FillTypeofXeCombobox(listTheloai);
                BindGridXeMay(listXe);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int getSelectedRow(string maxe) //GETSELECTEDROW
        {
            for (int i = 0; i < dtGVXemay.Rows.Count; i++)
            {
                if (dtGVXemay.Rows[i].Cells[0].Value.ToString() == maxe)
                {
                    return i;
                }
            }
            return -1;
        }
        private void getValue() //GETVALUE
        {
            string selectedTheloaixe = (string)cbLoaiXe.SelectedValue;
            xe.MaXe = txtMaXe.Text;
            xe.TenXe = txtTenXe.Text;
            xe.Mau = txtMau.Text;
            xe.DonGia = decimal.Parse(txtDonGia.Text);
            xe.MaLoai = selectedTheloaixe;
        }
        private void BindGridXeMay(List<Xe> xe) //BINDGRID
        {
            dtGVXemay.Rows.Clear();
            foreach (Xe x in xe)
            {
                int index = dtGVXemay.Rows.Add(x);
                dtGVXemay.Rows[index].Cells[0].Value = x.MaXe;
                dtGVXemay.Rows[index].Cells[1].Value = x.TenXe;
                if (x.LoaiXe != null)
                {
                    dtGVXemay.Rows[index].Cells[2].Value = x.LoaiXe.TenLoai;
                }
                dtGVXemay.Rows[index].Cells[3].Value = x.Mau;
                dtGVXemay.Rows[index].Cells[4].Value = x.DonGia;
            }
        }
        private void FillTypeofXeCombobox(List<LoaiXe> loaiXes) //FILL
        {
            loaiXes.Insert(0, new LoaiXe());
            this.cbLoaiXe.DataSource = loaiXes;
            this.cbLoaiXe.DisplayMember = "TenLoai";
            this.cbLoaiXe.ValueMember = "TenLoai";
        }

        private void dtGVXemay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}

