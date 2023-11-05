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
        private readonly HoaDonService hd = new HoaDonService(); 
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
                var listTheloai = lpt.GetAllType();
                var listXe = pt.GetAll();
                var listHD= hd.GetAll();
                FillTypeofXeCombobox(listTheloai);
                BindGridXeMay(listXe);
                List<HoaDon> searchResults = hd.GetAll()
                    .Where(xe =>
                        xe.Xe.Status == true)
                    .ToList();
                BindTrangThai(searchResults);
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
        private int getSelectedRowTT(string maxe) //GETSELECTEDROW
        {
            for (int i = 0; i < DtGVTrangThaiXe.Rows.Count; i++)
            {
                if (DtGVTrangThaiXe.Rows[i].Cells[0].Value.ToString() == maxe)
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
                int index = dtGVXemay.Rows.Add();
                dtGVXemay.Rows[index].Cells[0].Value = x.MaXe;
                dtGVXemay.Rows[index].Cells[1].Value = x.TenXe;
                
                dtGVXemay.Rows[index].Cells[2].Value = x.Mau;
                if (x.LoaiXe != null)
                {
                    dtGVXemay.Rows[index].Cells[3].Value = x.LoaiXe.TenLoai;
                }
                dtGVXemay.Rows[index].Cells[4].Value = x.DonGia.ToString();
            }
        }
        private void BindTrangThai(List<HoaDon> xe) //BINDGRID Trang thai xe
        {
            DtGVTrangThaiXe.Rows.Clear();
            foreach (HoaDon x in xe)
            {
                int index = DtGVTrangThaiXe.Rows.Add();
                DtGVTrangThaiXe.Rows[index].Cells[0].Value = x.MaXe;
                DtGVTrangThaiXe.Rows[index].Cells[1].Value = x.Xe.TenXe;

                DtGVTrangThaiXe.Rows[index].Cells[2].Value = x.Xe.Mau;
                DtGVTrangThaiXe.Rows[index].Cells[3].Value = x.Xe.LoaiXe.TenLoai;
                DtGVTrangThaiXe.Rows[index].Cells[4].Value = x.KhachHang.TenKH;
                DtGVTrangThaiXe.Rows[index].Cells[5].Value = x.Xe.Status;
            }
        }
        private void FillTypeofXeCombobox(List<LoaiXe> loaiXes) //FILL
        {
            loaiXes.Insert(0, new LoaiXe());
            this.cbLoaiXe.DataSource = loaiXes;
            this.cbLoaiXe.DisplayMember = "TenLoai";
            this.cbLoaiXe.ValueMember = "MaLoai";
        }

        private void dtGVXemay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVXemay.CurrentRow.Index != -1)
            {
                xe.MaXe = dtGVXemay.CurrentRow.Cells[0].Value.ToString();
                using (Model1 db = new Model1())
                {
                    xe = db.Xes.Where(x => x.MaXe == xe.MaXe).FirstOrDefault();
                    txtMaXe.Text = xe.MaXe.ToString();
                    txtTenXe.Text = xe.TenXe.ToString();
                    txtMau.Text = xe.Mau.ToString();
                    foreach (var item in cbLoaiXe.Items)
                    {
                        if (((LoaiXe)item).TenLoai == dtGVXemay.Rows[dtGVXemay.CurrentRow.Index].Cells[3].Value.ToString())
                        {
                            cbLoaiXe.SelectedItem = item;
                            break;
                        }
                    }
                    txtDonGia.Text = xe.DonGia.ToString();
                }
            }
        }
        private void clearValue()//CLEAR
        {
            txtMaXe.Text = txtTenXe.Text = txtMau.Text = txtDonGia.Text = "";
        }
        private bool checkValue()//CHECK
        {
            if (txtTenXe.Text == "" || txtMaXe.Text == "" || txtMau.Text == "" ||txtDonGia.Text == "")
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int n = getSelectedRow(txtMaXe.Text.ToString());
                if (!checkValue())
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                if (n == -1)
                {
                    getValue();
                    pt.InsertUpdate(xe);
                }
                MessageBox.Show("Thêm xe thành công");
                clearValue();
                BindGridXeMay(pt.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void delete(string maxe) //DELETE
        {
            using (var context = new Model1())
            {
                var xoaXe = context.Xes.Find(maxe);
                if (xoaXe != null)
                {
                    context.Xes.Remove(xoaXe);
                    context.SaveChanges();
                }
            }
            BindGridXeMay(context.Xes.ToList());
            clearValue();
        }
        private void showDialogDelete() //BANGTHONGBAO XOA 
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Yes/No", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                delete(txtMaXe.Text);
                MessageBox.Show("Xóa thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int n = getSelectedRow(txtMaXe.Text.ToString());
                if (n == -1)
                {
                    throw new Exception("Không tìm thấy thông tin xe!");
                }
                showDialogDelete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BindGridXeMay(context.Xes.ToList());
        }
        private void updateRowTT(string maxe) //UPDATEROW 
        {
            try
            {
                var xeUpdate = context.Xes.Find(maxe);
                if (xeUpdate != null)
                {
                    xeUpdate.Status = false;
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void updateRow(string maxe) //UPDATEROW 
        {
            try
            {
                var xeUpdate = context.Xes.Find(maxe);
                if (xeUpdate != null)
                {
                    xeUpdate.MaLoai = txtMaXe.Text;
                    xeUpdate.TenXe = txtTenXe.Text;
                    xeUpdate.Mau = txtMau.Text;
                    var selectloaiXe = (LoaiXe)cbLoaiXe.SelectedItem;
                    string maTheloai = selectloaiXe.MaLoai;
                    xeUpdate.MaLoai = maTheloai;
                    xeUpdate.DonGia = decimal.Parse(txtDonGia.Text);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                Xe xe = pt.GetAll().FirstOrDefault(p => p.MaXe == txtMaXe.Text);
                if (xe == null)
                {
                    throw new Exception("Mã xe đã có vui lòng nhập mã xe khác");               
                }
                updateRow(txtMaXe.Text);
                MessageBox.Show("Sua thong tin thanh cong");
                clearValue();
                BindGridXeMay(pt.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLoaiXe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (txtTim.Text == "")
                BindGridXeMay(pt.GetAll());
            else
            {
                BindGridXeMay(pt.FindByName(txtTim.Text));
            }
        }

        private void txtMaXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtTenXe.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtDonGia.Focus();
                e.Handled = true;
            }
        }

        private void txtTenXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMau.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtTenXe.Focus();
                e.Handled = true;
            }
        }

        private void txtMau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                cbLoaiXe.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtTenXe.Focus();
                e.Handled = true;
            }
        }

        private void cbLoaiXe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMau.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtDonGia.Focus();
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtMaXe.Focus();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                cbLoaiXe.Focus();
                e.Handled = true;
            }
        }

        private void DtGVTrangThaiXe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow r in DtGVTrangThaiXe.Rows)
            {
                bool is_True = Convert.ToBoolean(r.Cells[5].Value);
                if (is_True==false)
                {
                    r.DefaultCellStyle.BackColor = Color.Red;
                    r.DefaultCellStyle.ForeColor = Color.White;
                }
                else if(is_True == true)
                {
                    r.DefaultCellStyle.BackColor = Color.Green;
                    r.DefaultCellStyle.ForeColor = Color.Yellow;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Xe abc = pt.GetAll().FirstOrDefault(p => p.MaXe == txtMaXe.Text);
                if (abc == null)
                {
                    throw new Exception("Chưa chọn xe!");

                }
                else
                {
                    updateRowTT(txtMaXe.Text);
                    MessageBox.Show("Trả xe thành công");
                    List<HoaDon> searchResults = hd.GetAll()
                        .Where(xe =>
                            xe.Xe.Status == true)
                        .ToList();
                    BindTrangThai(searchResults);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DtGVTrangThaiXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGVXemay.CurrentRow.Index != -1)
            {
                xe.MaXe = DtGVTrangThaiXe.CurrentRow.Cells[0].Value.ToString();
                using (Model1 db = new Model1())
                {
                    xe = db.Xes.Where(x => x.MaXe == xe.MaXe).FirstOrDefault();
                    txtMaXe.Text = xe.MaXe.ToString();
                    txtTenXe.Text = xe.TenXe.ToString();
                    txtMau.Text = xe.Mau.ToString();
                    foreach (var item in cbLoaiXe.Items)
                    {
                        if (((LoaiXe)item).TenLoai == DtGVTrangThaiXe.Rows[DtGVTrangThaiXe.CurrentRow.Index].Cells[3].Value.ToString())
                        {
                            cbLoaiXe.SelectedItem = item;
                            break;
                        }
                    }
                    txtDonGia.Text = xe.DonGia.ToString();
                }
            }
        }
    }
   
}

