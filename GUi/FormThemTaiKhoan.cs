using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;
using BUS.Service;
using DevExpress.XtraEditors.Popup;
using System.Drawing.Text;
using System.Data.Entity.Validation;

namespace GUi
{
    public partial class FormThemTaiKhoan : Form
    {
        private TaiKhoan tk = new TaiKhoan();
        private readonly TaiKhoanService tksv = new TaiKhoanService();
        private readonly Model1 ct = new Model1();
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }
        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                var listTaiKhoan = tksv.GetAll();
                BindgridN(listTaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtGVNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVNV.CurrentRow.Index != -1)
            {
                tk.TenTK = dtGVNV.CurrentRow.Cells[0].Value.ToString();
                using (Model1 db = new Model1())
                {
                    tk = db.TaiKhoans.Where(x => x.TenTK == tk.TenTK).FirstOrDefault();
                    txtTenTK.Text = tk.TenTK.ToString();
                    txtMK.Text = tk.MatKhau.ToString();
                    txtFullName.Text = tk.TenNguoiDung.ToString();
                    txtSdth.Text = tk.SDT.ToString();
                    cbGioiTinh.Text=tk.GioiTinh.ToString();
                    txtEmail.Text=tk.email.ToString();
                }
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int n = GetSelectedRow(txtTenTK.Text.ToString());
                if (!checkValue())
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");

                }if(n == -1)
                {
                    getValue();
                    tksv.InsertUpdate(tk);
                }
                MessageBox.Show("Thêm dữ liệu thành công");
                clearValue();
                BindgridN(tksv.GetAll());
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int n = GetSelectedRow(txtTenTK.Text.ToString());
                if (!checkValue())
                {
                    throw new Exception("Vui lòng nhập đủ thông tin!");
                }
                if( n != -1)
                {
                    UpdateRow(txtTenTK.Text);
                }
                MessageBox.Show("Chỉnh sửa thông tin dữ liệu thành công");
                clearValue();
                BindgridN(tksv.GetAll());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int n = GetSelectedRow(txtTenTK.Text.ToString());
                if(n == -1)
                {
                    throw new Exception("Không tìm thấy thông tin dữ liệu!");
                    
                }
                ShowDialogDelete();
                BindgridN(ct.TaiKhoans.ToList());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //PRIVATE FUNCTION DO NOT TOUCH ANY THINGS IN HERE

        private void BindgridN(List<TaiKhoan> account)
        {
            dtGVNV.Rows.Clear();
            foreach (TaiKhoan i in account)
            {
                int index = dtGVNV.Rows.Add();
                dtGVNV.Rows[index].Cells[0].Value = i.TenTK;
                dtGVNV.Rows[index].Cells[1].Value = i.MatKhau;
                dtGVNV.Rows[index].Cells[2].Value = i.email;
                dtGVNV.Rows[index].Cells[3].Value = i.TenNguoiDung;
                dtGVNV.Rows[index].Cells[4].Value = i.SDT;
                if (i.GioiTinh != null)
                {
                    dtGVNV.Rows[index].Cells[5].Value = i.GioiTinh;
                }
            }
        }
        private bool checkValue()
        {
            if (txtTenTK.Text == "" || txtMK.Text == "" || txtEmail.Text == "" || txtFullName.Text == "" || txtSdth.Text == "")
            {
                return false;
            }
            return true;
        }
        private void clearValue()
        {
            txtTenTK.Text = txtMK.Text = txtEmail.Text = txtFullName.Text = txtSdth.Text = "";
        }
        private void getValue()
        {
            tk.TenTK = txtTenTK.Text;
            tk.MatKhau = GlobalFunc.CalculateMD5Hash(txtMK.Text.Trim());
            tk.email = txtEmail.Text;
            tk.TenNguoiDung = txtFullName.Text;
            tk.SDT = txtSdth.Text;
            tk.GioiTinh = cbGioiTinh.Text;
        }
        private int GetSelectedRow(string taikhoan) //GETSELECTEDROW
        {
            for (int i = 0; i < dtGVNV.Rows.Count; i++)
            {
                if (dtGVNV.Rows[i].Cells[0].Value.ToString() == taikhoan)
                {
                    return i;
                }
            }
            return -1;
        }
        private void UpdateRow(string nameaccount)
        {
            try
            {
                var updating = ct.TaiKhoans.Find(nameaccount);
                if(updating != null)
                {
                    updating.TenTK = txtTenTK.Text;
                    updating.TenNguoiDung=txtFullName.Text;
                    updating.MatKhau = GlobalFunc.CalculateMD5Hash(txtMK.Text.Trim());
                    updating.SDT = txtSdth.Text;
                    updating.email = txtEmail.Text;
                    updating.GioiTinh = cbGioiTinh.Text;
                    ct.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void delete(string nameaccount)
        {
            using (var context = new Model1())
            {
                var Deleting = ct.TaiKhoans.Find(nameaccount);
                if(Deleting != null)
                {
                    ct.TaiKhoans.Remove(Deleting);
                    ct.SaveChanges();
                }
            }
            BindgridN(ct.TaiKhoans.ToList());
            clearValue();
        }
        private void ShowDialogDelete()
        {
            DialogResult res = MessageBox.Show("Bạn có chắc muốn xóa dữ liệu", "Thông báo", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                delete(txtTenTK.Text);
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
                BindgridN(tksv.GetAll());
            else
            {
                BindgridN(tksv.FindByName(txtTim.Text));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
