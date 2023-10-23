using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using BUS.Service;
using DAL.Entities;
using DevExpress.XtraEditors.Filtering.Templates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUi
{
    public partial class FormHoaDon : Form
    {
        private readonly Khachhang khService = new Khachhang();
        private readonly Phuongtien ptService = new Phuongtien();
        private readonly HoaDonService hdService = new HoaDonService();
        private readonly TaiKhoanService tkService = new TaiKhoanService();
        private readonly Model1 context = new Model1();
        private HoaDon model = new HoaDon();

        public FormHoaDon()
        {
            InitializeComponent();
        }
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                var listKhachhang = khService.GetAll();
                var listPhuongtien = ptService.GetAll();
                var listTaikhoan = tkService.GetAll();
                FillKhachHangCombobox(listKhachhang);
                FillNhanVienCombobox(listTaikhoan);
                FillXeCombobox(listPhuongtien);
                // txtSoNgayThue.Text = defaultValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //combobox Ten nhan vien
        private void FillNhanVienCombobox(List<TaiKhoan> listNhanViens)
        {
            listNhanViens.Insert(0, new TaiKhoan());
            this.cbbNhanVien.DataSource = listNhanViens;
            this.cbbNhanVien.DisplayMember = "TenNguoiDung";
            this.cbbNhanVien.ValueMember = "TenTK";
        }
        //combobox Ten khach hang
        private void FillKhachHangCombobox(List<KhachHang> listKhachHangs)
        {
            listKhachHangs.Insert(0, new KhachHang());
            this.cbbKhachHang.DataSource = listKhachHangs;
            this.cbbKhachHang.DisplayMember = "TenKH";
            this.cbbKhachHang.ValueMember = "MaKH";
        }
        //combobox Ten xe
        private void FillXeCombobox(List<Xe> listXes)
        {
            listXes.Insert(0, new Xe());
            this.cbbTenXe.DataSource = listXes;
            this.cbbTenXe.DisplayMember = "TenXe";
            this.cbbTenXe.ValueMember = "MaXe";
        }

        private void txtHoaDon_EditValueChanged(object sender, EventArgs e)
        {

        }



        private void getValue()
        {
            string selectedNhanVien = (string)cbbNhanVien.SelectedValue;
            string selectedKhachHangID = (string)cbbKhachHang.SelectedValue;
            string selectedXeID =(string)cbbTenXe.SelectedValue;
            model.NgayThanhToan = dateXuatDon.Value.Date;
            model.NgayThue = dateNhanXe.Value.Date;
            model.NgayTra = dateTraXe.Value.Date;
            model.MaHD = txtHoaDon.Text;
            model.MaKH = selectedKhachHangID;
            model.TenTK = selectedNhanVien;
            model.MaXe = selectedXeID;
            model.TongTien = decimal.Parse(txtTongTien.Text);
        }

        private void cbbTenXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTenXe.SelectedIndex > 0)
            {
                Xe selectedXe = (Xe)cbbTenXe.SelectedItem;
                txtGia.Text = selectedXe.DonGia.ToString();
                if (selectedXe.MaLoai == "1")
                    txtVAT.Text = ("5");
                else txtVAT.Text = ("10");

                //nhanVienService.FindById(selectedNhanVien.MaNhanVien);
                //txtKhachHang.Text = ...
            }
        }
        /*private void SoNT(string snt)
        {
            if (string.IsNullOrEmpty(snt) || snt==" ")
            {
                txtSoNgayThue.Text = null;
            }
            else
            {
                decimal Gia = decimal.Parse(txtGia.Text);
                decimal SNthue = decimal.Parse(txtSoNgayThue.Text);
                decimal Tax = decimal.Parse(txtVAT.Text);
                decimal result = Gia * SNthue * ((Tax + 100) / 100);
                txtTongTien.Text = result.ToString();
            }
        }*/

        

        private bool checkValue()
        {
            if (txtHoaDon.Text == "" || cbbKhachHang.Text == "" || cbbNhanVien.Text == "" || cbbTenXe.Text == "" || txtTongTien.Text == "")
            {
                return false;
            }
            return true;
        }

        private void clearValue()
        {
            txtHoaDon.Text = cbbKhachHang.Text = cbbNhanVien.Text = cbbTenXe.Text = txtGia.Text = txtSoNgayThue.Text = txtVAT.Text = txtTongTien.Text = "" ;
        }

        //private string defaultValue = "1";
        private void txtSoNgayThue_TextChanged(object sender, EventArgs e)
        {
            //SoNT(txtSoNgayThue.Text);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValue() == true)
                {
                    TinhTien();
                    getValue();
                    hdService.InsertUpdate(model);
                    MessageBox.Show("Da update thanh cong!");
                    clearValue();
                }
                else throw new Exception("vui long nhap day du thong tin!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateNhanXe_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateNhanXe.Text);
            DateTime outTime = Convert.ToDateTime(dateTraXe.Text);
            if (outTime >= inTime)
            {
                txtSoNgayThue.Text = outTime.Subtract(inTime).Days.ToString();
            }
        }

        private void dateTraXe_ValueChanged(object sender, EventArgs e)
        {
            DateTime inTime = Convert.ToDateTime(dateNhanXe.Text);
            DateTime outTime = Convert.ToDateTime(dateTraXe.Text);
            if (outTime >= inTime)
            {
                txtSoNgayThue.Text = outTime.Subtract(inTime).Days.ToString();
            }
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            TinhTien();
        }

        private void TinhTien()
        {
            decimal Gia = decimal.Parse(txtGia.Text);
            decimal SNthue = decimal.Parse(txtSoNgayThue.Text);
            decimal Tax = decimal.Parse(txtVAT.Text);
            decimal result = Gia * SNthue * ((Tax + 100) / 100);
            txtTongTien.Text = result.ToString();
        }
    }
}
