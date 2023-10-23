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
    public partial class FormThongTinKhachHang : Form
    {
        public FormThongTinKhachHang()
        {
            InitializeComponent();
        }
        private readonly Khachhang khachhang = new Khachhang();
        private KhachHang khachHang = new KhachHang();
        private void FormThongTinKhachHang_Load(object sender, EventArgs e)
        {

            try
            {
                var khachhangService = new Khachhang();
                var listKhach = khachhangService.GetAll();
                BindGridKhach(listKhach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        
        private void BindGridKhach(List<KhachHang> kh)
        {
            dtGVKhachHang.Rows.Clear();
            foreach (KhachHang x in kh)
            {
                int index = dtGVKhachHang.Rows.Add();
                dtGVKhachHang.Rows[index].Cells[0].Value = x.MaKH;
                dtGVKhachHang.Rows[index].Cells[1].Value = x.TenKH;
                dtGVKhachHang.Rows[index].Cells[2].Value = x.SDTKH;
                if (x.NgaySinh != null && x.NgaySinh is DateTime ngaySinh)
                {
                    dtGVKhachHang.Rows[index].Cells[3].Value = ngaySinh.ToString("dd-MM-yyyy");
                }
                else
                {
                    dtGVKhachHang.Rows[index].Cells[3].Value = string.Empty;
                }
                dtGVKhachHang.Rows[index].Cells[4].Value = x.CCCD;
            }
        }
        private int getSelectedRow(string makh)
        {
            for (int i = 0; i < dtGVKhachHang.Rows.Count; i++)
            {
                if (dtGVKhachHang.Rows[i].Cells[0].Value.ToString() == makh)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string maKhachHang = txtMaKH.Text;

                if (KiemTraMaKHTonTai(maKhachHang))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại.\nXin nhập mã khác.");
                }
                else
                {
                    KhachHang khachMoi = new KhachHang
                    {
                        MaKH = maKhachHang,
                        TenKH = txtTenKH.Text,
                        SDTKH = txtSdt.Text,
                        NgaySinh = dtpNgaysinh.Value,
                        CCCD = txtCCCD.Text
                    };

                    var khachhangService = new Khachhang();
                    khachhangService.Insert(khachMoi);

                    AddRow(khachMoi);
                    ClearValue();
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin bên dưới !");
            }
        }

        private bool KiemTraMaKHTonTai(string maKH)
        {
            using (var context = new Model1())
            {
                return context.KhachHangs.Any(kh => kh.MaKH == maKH);
            }
        }

        private void ClearValue()
        {
            txtMaKH.Text = txtTenKH.Text = txtSdt.Text = txtCCCD.Text = "";
            dtpNgaysinh.Value = DateTime.Now;
        }

        private void AddRow(KhachHang newKhach)
        {
            int index = dtGVKhachHang.Rows.Add();
            dtGVKhachHang.Rows[index].Cells[0].Value = newKhach.MaKH;
            dtGVKhachHang.Rows[index].Cells[1].Value = newKhach.TenKH;
            dtGVKhachHang.Rows[index].Cells[2].Value = newKhach.SDTKH;
            if (newKhach.NgaySinh != null && newKhach.NgaySinh is DateTime ngaySinh)
            {
                dtGVKhachHang.Rows[index].Cells[3].Value = ngaySinh.ToString("dd-MM-yyyy");
            }
            else
            {
                dtGVKhachHang.Rows[index].Cells[3].Value = string.Empty;
            }
            dtGVKhachHang.Rows[index].Cells[4].Value = newKhach.CCCD;
        }

        private bool Check()
        {

            if (string.IsNullOrWhiteSpace(txtTenKH.Text) ||
            string.IsNullOrWhiteSpace(txtSdt.Text) ||
            string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                return false;
            }

            return true;

        }

        private void dtGVKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtGVKhachHang.Rows[e.RowIndex];
                string maKH = selectedRow.Cells[0].Value.ToString();
                string tenKH = selectedRow.Cells[1].Value.ToString();
                string sdt = selectedRow.Cells[2].Value.ToString();
                string ngaySinhText = selectedRow.Cells[3].Value.ToString();
                string cccd = selectedRow.Cells[4].Value.ToString();

                txtMaKH.Text = maKH;
                txtTenKH.Text = tenKH;
                txtSdt.Text = sdt;
                txtCCCD.Text = cccd;
                dtpNgaysinh.Value = DateTime.Now;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKH.Text))
            {
                string maKH = txtMaKH.Text;

                if (KiemTraMaKHTonTai(maKH))
                {
                    ShowDialogDelete(maKH);
                }
                else
                {
                    MessageBox.Show("Mã khách hàng không tồn tại trong cơ sở dữ liệu.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách trước khi xóa.");
            }
        }

        private void ShowDialogDelete(string maKH)
        {
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có mã: {maKH} không?", "Xác nhận xóa", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DeleteKhachHang(maKH);
                MessageBox.Show("Xóa thành công!");
                BindGridKhach(khachhang.GetAll());
                ClearValue();
            }
        }

        private void DeleteKhachHang(string maKH)
        {
            using (var context = new Model1())
            {
                var khachToDelete = context.KhachHangs.FirstOrDefault(kh => kh.MaKH == maKH);
                if (khachToDelete != null)
                {
                    context.KhachHangs.Remove(khachToDelete);
                    context.SaveChanges();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách trước khi sửa.");
                return;
            }

            if (Check())
            {
                string maKhachHang = txtMaKH.Text;
                KhachHang updatedKhach = new KhachHang
                {
                    MaKH = maKhachHang,
                    TenKH = txtTenKH.Text,
                    SDTKH = txtSdt.Text,
                    NgaySinh = dtpNgaysinh.Value,
                    CCCD = txtCCCD.Text
                };

                var khachhangService = new Khachhang();
                khachhangService.Update(updatedKhach);

                int rowIndex = getSelectedRow(maKhachHang);
                if (rowIndex != -1)
                {
                    UpdateRow(rowIndex, updatedKhach);
                    MessageBox.Show("Sửa thành công!");
                    ClearValue();
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ thông tin bên dưới !");
            }
        }

        private void UpdateRow(int rowIndex, KhachHang suakhachhang)
        {
            dtGVKhachHang.Rows[rowIndex].Cells[1].Value = suakhachhang.TenKH;
            dtGVKhachHang.Rows[rowIndex].Cells[2].Value = suakhachhang.SDTKH;
            if (suakhachhang.NgaySinh != null)
            {
                dtGVKhachHang.Rows[rowIndex].Cells[3].Value = ((DateTime)suakhachhang.NgaySinh).ToString("dd-MM-yyyy");
            }
            else
            {
                dtGVKhachHang.Rows[rowIndex].Cells[3].Value = string.Empty;
            }
            dtGVKhachHang.Rows[rowIndex].Cells[4].Value = suakhachhang.CCCD;

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            var khachhangService = new Khachhang();
            List<KhachHang> searchResults = khachhangService.GetAll()
                .Where(kh =>
                    kh.MaKH.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    kh.TenKH.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    kh.SDTKH.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    kh.CCCD.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            BindGridKhach(searchResults);
        }
    }
}
