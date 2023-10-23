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

namespace GUi
{
    public partial class FormThemTaiKhoan : Form
    {
        private TaiKhoan tk = new TaiKhoan();
        private readonly TaiKhoanService tksv = new TaiKhoanService();
        private readonly GioiTinhService gtsv = new GioiTinhService();
        private readonly Model1 context = new Model1();
        public FormThemTaiKhoan()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormThemTaiKhoan_Load(object sender, EventArgs e)
        {
            
        }

        private void dtGVXemay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtGVNV.CurrentRow.Index != -1)
            {
                tk.TenTK = dtGVNV.CurrentRow.Cells[0].Value.ToString();
                using (Model1 db = new Model1())
                {
                    tk = db.TaiKhoans.Where( x => x.TenTK == tk.TenTK ).FirstOrDefault();
                    txtTenTK.Text = tk.TenTK.ToString();
                    txtMK.Text = tk.MatKhau.ToString();
                    txtFullName.Text = tk.TenNguoiDung.ToString();
                    txtSdth.Text = tk.SDT.ToString();
                    foreach(var item in cbGioiTinhs.Items)
                    {
                        if(((GioiTinh)item).GioiTinh1 == dtGVNV.Rows[dtGVNV.CurrentRow.Index].Cells[5].Value
                            .ToString())
                        {
                            cbGioiTinhs.SelectedItem = item;
                            break;
                        }
                    }
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                BindgridN(context.TaiKhoans.ToList());
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
                    dtGVNV.Rows[index].Cells[5].Value = i.GioiTinh.GioiTinh1;
                }
            }
        }
        private void FillGenderComboBox(List<GioiTinh> accountlist)
        {
            
            accountlist.Insert(0, new GioiTinh());
            this.cbGioiTinhs.DataSource = accountlist;
            this.cbGioiTinhs.DisplayMember = "GioiTinh1";
            this.cbGioiTinhs.ValueMember = "MaGioiTinh";
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
            string selectedGender = (string)cbGioiTinhs.SelectedValue;
            tk.TenTK = txtTenTK.Text;
            tk.MatKhau = txtMK.Text;
            tk.email = txtEmail.Text;
            tk.TenNguoiDung = txtFullName.Text;
            tk.SDT = txtSdth.Text;
            tk.MaGioiTinh = selectedGender;
        }
        private int GetSelectedRow( string nameaccount)
        {
            for(int i = 0; i< dtGVNV.Rows.Count; i++)
            {
                if (dtGVNV.Rows[i].Cells[0].Value.ToString() == nameaccount)
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
                var updating = context.TaiKhoans.Find(nameaccount);
                if(updating != null)
                {
                    updating.TenTK = txtTenTK.Text;
                    updating.MatKhau = txtMK.Text;
                    var selectedUpdate = (GioiTinh)cbGioiTinhs.SelectedItem;
                    string IDGioiTinh = selectedUpdate.GioiTinh1;
                    updating.MaGioiTinh = IDGioiTinh;
                    context.SaveChanges();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void delete(string nameaccount)
        {
            using (var context = new Model1())
            {
                var Deleting = context.TaiKhoans.Find(nameaccount);
                if(Deleting != null)
                {
                    context.TaiKhoans.Remove(Deleting);
                    context.SaveChanges();
                }
            }
            BindgridN(context.TaiKhoans.ToList());
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

        private void FormThemTaiKhoan_Load_1(object sender, EventArgs e)
        {
            try
            {
                var listGioiTinh = gtsv.GetAll();
                var listTaiKhoan = tksv.GetAll();
                FillGenderComboBox(listGioiTinh);
                BindgridN(listTaiKhoan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
