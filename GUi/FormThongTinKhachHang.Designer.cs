namespace GUi
{
    partial class FormThongTinKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSdt = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.dtGVKhachHang = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpNgaysinh = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKhachHang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 20);
            this.txtSearch.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Tìm kiếm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(-3, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Thông tin khách hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 88);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Số điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Tên khách hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Mã khách hàng";
            // 
            // txtSdt
            // 
            this.txtSdt.Location = new System.Drawing.Point(112, 85);
            this.txtSdt.Margin = new System.Windows.Forms.Padding(2);
            this.txtSdt.Name = "txtSdt";
            this.txtSdt.Size = new System.Drawing.Size(76, 20);
            this.txtSdt.TabIndex = 52;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(459, 42);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(76, 20);
            this.txtTenKH.TabIndex = 54;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(193, 42);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(76, 20);
            this.txtMaKH.TabIndex = 55;
            // 
            // dtGVKhachHang
            // 
            this.dtGVKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dtGVKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column3});
            this.dtGVKhachHang.Location = new System.Drawing.Point(0, 141);
            this.dtGVKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.dtGVKhachHang.Name = "dtGVKhachHang";
            this.dtGVKhachHang.RowHeadersWidth = 51;
            this.dtGVKhachHang.RowTemplate.Height = 24;
            this.dtGVKhachHang.Size = new System.Drawing.Size(507, 263);
            this.dtGVKhachHang.TabIndex = 50;
            this.dtGVKhachHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVKhachHang_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã khách hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tên khách hàng";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Số điện thoại";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ngày sinh";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CCCD";
            this.Column3.Name = "Column3";
            // 
            // dtpNgaysinh
            // 
            this.dtpNgaysinh.Location = new System.Drawing.Point(295, 85);
            this.dtpNgaysinh.Name = "dtpNgaysinh";
            this.dtpNgaysinh.Size = new System.Drawing.Size(119, 20);
            this.dtpNgaysinh.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Ngày sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "CCCD";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(506, 85);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(100, 20);
            this.txtCCCD.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(506, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 263);
            this.panel1.TabIndex = 72;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Image = global::GUi.Properties.Resources.add_file;
            this.btnThem.Location = new System.Drawing.Point(51, 72);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(56, 32);
            this.btnThem.TabIndex = 63;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Image = global::GUi.Properties.Resources.delete;
            this.btnXoa.Location = new System.Drawing.Point(51, 131);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(56, 32);
            this.btnXoa.TabIndex = 64;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSua.Image = global::GUi.Properties.Resources.maintenance;
            this.btnSua.Location = new System.Drawing.Point(51, 198);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(56, 32);
            this.btnSua.TabIndex = 65;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTim
            // 
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTim.Image = global::GUi.Properties.Resources.search;
            this.btnTim.Location = new System.Drawing.Point(113, 28);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(31, 23);
            this.btnTim.TabIndex = 69;
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(505, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Chức năng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUi.Properties.Resources.back1;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FormThongTinKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(661, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.dtpNgaysinh);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSdt);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.dtGVKhachHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormThongTinKhachHang";
            this.Text = "FormThongTinKhachHang";
            this.Load += new System.EventHandler(this.FormThongTinKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVKhachHang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.DataGridView dtGVKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DateTimePicker dtpNgaysinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}