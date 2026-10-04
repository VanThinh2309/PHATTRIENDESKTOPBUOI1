namespace QuanLyBanDoChoi.GUI
{
    partial class ucKhachHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.cboHang = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblHang = new System.Windows.Forms.Label();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnLichSu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtHang = new System.Windows.Forms.TextBox();
            this.txtDiemTL = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.colMaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cboHang);
            this.panelTop.Controls.Add(this.txtTimKiem);
            this.panelTop.Controls.Add(this.lblHang);
            this.panelTop.Controls.Add(this.lblTimKiem);
            this.panelTop.Controls.Add(this.btnLamMoi);
            this.panelTop.Controls.Add(this.btnThem);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1344, 60);
            this.panelTop.TabIndex = 0;
            // 
            // cboHang
            // 
            this.cboHang.FormattingEnabled = true;
            this.cboHang.Items.AddRange(new object[] {
            "Tất cả",
            "Kim cương",
            "Vàng",
            "Bạc",
            "Đồng"});
            this.cboHang.Location = new System.Drawing.Point(965, 18);
            this.cboHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new System.Drawing.Size(121, 24);
            this.cboHang.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTimKiem.Location = new System.Drawing.Point(408, 11);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(433, 38);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.Text = "Nhập tên hoặc số điện thoại khách hàng...";
            // 
            // lblHang
            // 
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHang.Location = new System.Drawing.Point(875, 18);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new System.Drawing.Size(67, 23);
            this.lblHang.TabIndex = 2;
            this.lblHang.Text = "Hạng :";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTimKiem.Location = new System.Drawing.Point(300, 18);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(102, 23);
            this.lblTimKiem.TabIndex = 2;
            this.lblTimKiem.Text = "Tìm kiếm :";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLamMoi.Location = new System.Drawing.Point(1149, 11);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(171, 39);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "↻ Làm Mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(3, 11);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(289, 39);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "+ Thêm Khách Hàng";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.grbThongTin);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(979, 60);
            this.panelRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panelRight.Size = new System.Drawing.Size(365, 661);
            this.panelRight.TabIndex = 1;
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.button4);
            this.grbThongTin.Controls.Add(this.btnLichSu);
            this.grbThongTin.Controls.Add(this.btnHuy);
            this.grbThongTin.Controls.Add(this.btnLuu);
            this.grbThongTin.Controls.Add(this.txtTrangThai);
            this.grbThongTin.Controls.Add(this.txtHang);
            this.grbThongTin.Controls.Add(this.txtDiemTL);
            this.grbThongTin.Controls.Add(this.txtSDT);
            this.grbThongTin.Controls.Add(this.txtHoTen);
            this.grbThongTin.Controls.Add(this.txtMaKH);
            this.grbThongTin.Controls.Add(this.label6);
            this.grbThongTin.Controls.Add(this.label5);
            this.grbThongTin.Controls.Add(this.label4);
            this.grbThongTin.Controls.Add(this.label3);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbThongTin.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grbThongTin.Location = new System.Drawing.Point(11, 10);
            this.grbThongTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grbThongTin.Size = new System.Drawing.Size(343, 641);
            this.grbThongTin.TabIndex = 0;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông Tin Khách Hàng";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(72, 423);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(203, 39);
            this.button4.TabIndex = 10;
            this.button4.Text = "🗑️ Xóa khách hàng";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnLichSu
            // 
            this.btnLichSu.Location = new System.Drawing.Point(72, 377);
            this.btnLichSu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(203, 41);
            this.btnLichSu.TabIndex = 9;
            this.btnLichSu.Text = "📜 Xem lịch sử mua hàng";
            this.btnLichSu.UseVisualStyleBackColor = true;
            this.btnLichSu.Click += new System.EventHandler(this.btnLichSu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.ForeColor = System.Drawing.Color.Red;
            this.btnHuy.Location = new System.Drawing.Point(195, 330);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 39);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnLuu.Location = new System.Drawing.Point(72, 330);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 39);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(185, 279);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTrangThai.Multiline = true;
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(145, 35);
            this.txtTrangThai.TabIndex = 6;
            // 
            // txtHang
            // 
            this.txtHang.Location = new System.Drawing.Point(5, 279);
            this.txtHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHang.Multiline = true;
            this.txtHang.Name = "txtHang";
            this.txtHang.Size = new System.Drawing.Size(145, 35);
            this.txtHang.TabIndex = 6;
            // 
            // txtDiemTL
            // 
            this.txtDiemTL.Location = new System.Drawing.Point(127, 181);
            this.txtDiemTL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiemTL.Multiline = true;
            this.txtDiemTL.Name = "txtDiemTL";
            this.txtDiemTL.Size = new System.Drawing.Size(211, 32);
            this.txtDiemTL.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(125, 123);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSDT.Multiline = true;
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(212, 32);
            this.txtSDT.TabIndex = 6;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(72, 68);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoTen.Multiline = true;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(265, 32);
            this.txtHoTen.TabIndex = 6;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(76, 21);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaKH.Multiline = true;
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(261, 32);
            this.txtMaKH.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(213, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(51, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hạng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(5, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Điểm tích lũy:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(5, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(5, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH:";
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.dgvKhachHang);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 60);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.panelCenter.Size = new System.Drawing.Size(979, 661);
            this.panelCenter.TabIndex = 2;
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Aquamarine;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaKH,
            this.colTenKH,
            this.colSDT,
            this.colDiem,
            this.colHang,
            this.colTrangThai});
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhachHang.EnableHeadersVisualStyles = false;
            this.dgvKhachHang.Location = new System.Drawing.Point(11, 10);
            this.dgvKhachHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvKhachHang.MultiSelect = false;
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.ReadOnly = true;
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.RowHeadersWidth = 51;
            this.dgvKhachHang.RowTemplate.Height = 24;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(957, 641);
            this.dgvKhachHang.TabIndex = 0;
            // 
            // colMaKH
            // 
            this.colMaKH.DataPropertyName = "MaKH";
            this.colMaKH.HeaderText = "Mã KH";
            this.colMaKH.MinimumWidth = 6;
            this.colMaKH.Name = "colMaKH";
            this.colMaKH.ReadOnly = true;
            // 
            // colTenKH
            // 
            this.colTenKH.DataPropertyName = "HoTen";
            this.colTenKH.HeaderText = "Họ tên";
            this.colTenKH.MinimumWidth = 6;
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.ReadOnly = true;
            // 
            // colSDT
            // 
            this.colSDT.DataPropertyName = "SDT";
            this.colSDT.HeaderText = "Số điện thoại";
            this.colSDT.MinimumWidth = 6;
            this.colSDT.Name = "colSDT";
            this.colSDT.ReadOnly = true;
            // 
            // colDiem
            // 
            this.colDiem.DataPropertyName = "DiemTL";
            this.colDiem.HeaderText = "Điểm tích lũy";
            this.colDiem.MinimumWidth = 6;
            this.colDiem.Name = "colDiem";
            this.colDiem.ReadOnly = true;
            // 
            // colHang
            // 
            this.colHang.DataPropertyName = "HangKH";
            this.colHang.HeaderText = "Hạng";
            this.colHang.MinimumWidth = 6;
            this.colHang.Name = "colHang";
            this.colHang.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.MinimumWidth = 6;
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // ucKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenter);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucKhachHang";
            this.Size = new System.Drawing.Size(1344, 721);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.ComboBox cboHang;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnLichSu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtHang;
        private System.Windows.Forms.TextBox txtDiemTL;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}
