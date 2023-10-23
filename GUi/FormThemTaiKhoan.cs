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
using BUS;
using BUS.Service;
using System.Text.RegularExpressions;

namespace GUi
{
    public partial class FormThemTaiKhoan : Form
    {
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private readonly Nhanvien nhanvien = new Nhanvien();
        private TaiKhoan tk = new TaiKhoan();
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                string tentk = txtTenTKNV.Text;

                if (KiemTraTaiKhoanTonTai(tentk))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại.\nXin nhập mã khác.");
                }
                else
                {
                    TaiKhoan nhanvienmoi = new TaiKhoan
                    {
                        TenTK = tentk,
                        MatKhau = txtMatkhauNV.Text,
                        email = txtEmailNV.Text,
                        TenNguoiDung = txtHoTenNV.Text,
                        SDT = txtSdt.Text,
                    };

                    var nhanvienService = new Nhanvien();
                    nhanvienService.Insert(nhanvienmoi);
                    AddRow(nhanvienmoi);
                    ClearValue();
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đầy đủ các thông tin còn thiếu !");
            }
        }
        private int getSelectedRow(string tenTaiKhoan)
        {
            for (int i = 0; i < dtGVNhanVien.Rows.Count; i++)
            {
                if (dtGVNhanVien.Rows[i].Cells[0].Value.ToString() == tenTaiKhoan)
                {
                    return i;
                }
            }
            return -1;
        }

        private bool KiemTraTaiKhoanTonTai(string tentk)
        {
            using (var context = new Model1())
            {
                return context.TaiKhoans.Any(p => p.TenTK == tentk);
            }
        }

        private bool ClearValue()
        {
            if (string.IsNullOrEmpty(txtTenTKNV.Text) && string.IsNullOrEmpty(txtMatkhauNV.Text) &&
                string.IsNullOrEmpty(txtEmailNV.Text) && string.IsNullOrEmpty(txtHoTenNV.Text) &&
                   string.IsNullOrEmpty(txtSdt.Text))
            {
                return true;
            }

            return false;
        }

        private void AddRow(TaiKhoan nhanvienmoi)
        {
            int index = dtGVNhanVien.Rows.Add();
            dtGVNhanVien.Rows[index].Cells[0].Value = nhanvienmoi.TenTK;
            dtGVNhanVien.Rows[index].Cells[1].Value = nhanvienmoi.MatKhau;
            dtGVNhanVien.Rows[index].Cells[2].Value = nhanvienmoi.email;
            dtGVNhanVien.Rows[index].Cells[3].Value = nhanvienmoi.TenNguoiDung;
            dtGVNhanVien.Rows[index].Cells[4].Value = nhanvienmoi.SDT;
        }

        private bool Check()
        {
            if (string.IsNullOrEmpty(txtTenTKNV.Text) || txtTenTKNV.Text.Length < 8)
            {
                MessageBox.Show("Tên tài khoản phải chứa ít nhất 8 ký tự.");
                return false;
            }
            if (string.IsNullOrEmpty(txtMatkhauNV.Text) || txtMatkhauNV.Text.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải chứa ít nhất 8 ký tự.");
                return false;
            }
            if (string.IsNullOrEmpty(txtEmailNV.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email.");
                return false;
            }
            if (!KiemTraEmail(txtEmailNV.Text))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ. Địa chỉ email phải có đuôi '.com'.");
                return false;
            }
            if (string.IsNullOrEmpty(txtHoTenNV.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng.");
                return false;
            }
            if (string.IsNullOrEmpty(txtSdt.Text))
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

        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                var listnhanvien = nhanvien.GetAll();
                BindGridNhanvien(listnhanvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindGridNhanvien(List<TaiKhoan> taiKhoans)
        {
            dtGVNhanVien.Rows.Clear();
            foreach (TaiKhoan x in taiKhoans)
            {
                int index = dtGVNhanVien.Rows.Add();
                dtGVNhanVien.Rows[index].Cells[0].Value = x.TenTK;
                dtGVNhanVien.Rows[index].Cells[1].Value = x.MatKhau;
                dtGVNhanVien.Rows[index].Cells[2].Value = x.email;
                dtGVNhanVien.Rows[index].Cells[3].Value = x.TenNguoiDung;
                dtGVNhanVien.Rows[index].Cells[4].Value = x.SDT;
            }
        }

        private void dtGVNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtGVNhanVien.Rows[e.RowIndex];
                string tenTK = selectedRow.Cells[0].Value.ToString();
                string matkhau = selectedRow.Cells[1].Value.ToString();
                string email = selectedRow.Cells[2].Value.ToString();
                string tennguoidung = selectedRow.Cells[3].Value.ToString();
                string sdt = selectedRow.Cells[4].Value.ToString();

                
                txtTenTKNV.Text = tenTK;
                txtMatkhauNV.Text = matkhau;
                txtEmailNV.Text = email;
                txtHoTenNV.Text = tennguoidung;
                txtSdt.Text = sdt;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenTKNV.Text))
            {
                MessageBox.Show("Vui lòng chọn một khách hàng từ danh sách để sửa.");
                return;
            }

            if (Check())
            {
                string tentk = txtTenTKNV.Text;
                TaiKhoan suanhanvien = new TaiKhoan
                {
                    TenTK = tentk,
                    MatKhau = txtMatkhauNV.Text,
                    email = txtEmailNV.Text,
                    TenNguoiDung = txtHoTenNV.Text,
                    SDT = txtSdt.Text,
                };

                var nhanvienService = new Nhanvien();
                nhanvienService.Update(suanhanvien);

                int rowIndex = getSelectedRow(tentk);
                if (rowIndex != -1)
                {
                    UpdateRow(rowIndex, suanhanvien);
                    MessageBox.Show("Sửa thành công!");
                    ClearValue();
                }
            }
            else
            {
                MessageBox.Show("Xin vui lòng nhập đây đủ và phù hợp với yêu cầu về thông tin");
            }
        }

        private void UpdateRow(int rowIndex, TaiKhoan suanhanvien)
        {
            dtGVNhanVien.Rows[rowIndex].Cells[0].Value = suanhanvien.TenTK;
            dtGVNhanVien.Rows[rowIndex].Cells[1].Value = suanhanvien.MatKhau;
            dtGVNhanVien.Rows[rowIndex].Cells[2].Value = suanhanvien.email;
            dtGVNhanVien.Rows[rowIndex].Cells[3].Value = suanhanvien.TenNguoiDung;
            dtGVNhanVien.Rows[rowIndex].Cells[4].Value = suanhanvien.SDT;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVNhanVien.SelectedRows.Count > 0)
            {
              
                string tenTK = dtGVNhanVien.SelectedRows[0].Cells[0].Value.ToString();

              
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    var nhanvienService = new Nhanvien();
                    nhanvienService.Delete(tenTK);
                    dtGVNhanVien.Rows.Remove(dtGVNhanVien.SelectedRows[0]);
                    ClearValue();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một tài khoản từ danh sách bạn muốn xóaa.");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTim.Text;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                var listnhanvien = nhanvien.GetAll();
                BindGridNhanvien(listnhanvien);
                return;
            }

            for (int i = 0; i < dtGVNhanVien.Rows.Count; i++)
            {
                if (dtGVNhanVien.Rows[i].Cells[0].Value != null)
                {
                    string tenTK = dtGVNhanVien.Rows[i].Cells[0].Value.ToString();

                    if (tenTK.Contains(keyword))
                    {
                        dtGVNhanVien.Rows[i].Visible = true;
                    }
                    else
                    {
                        dtGVNhanVien.Rows[i].Visible = false;
                    }
                }
            }

        }

        }
    }

