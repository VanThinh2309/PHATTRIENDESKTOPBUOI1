namespace QuanLyBanDoChoi.GUI
{
    partial class frmLoc
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbTonKho = new System.Windows.Forms.GroupBox();
            this.rdoTonKhoTatCa = new System.Windows.Forms.RadioButton();
            this.rdoConHang = new System.Windows.Forms.RadioButton();
            this.rdoSapHet = new System.Windows.Forms.RadioButton();
            this.rdoHetHang = new System.Windows.Forms.RadioButton();
            this.lblKhoangGia = new System.Windows.Forms.Label();
            this.txtGiaTu = new System.Windows.Forms.TextBox();
            this.lblGiaPhanCach = new System.Windows.Forms.Label();
            this.txtGiaDen = new System.Windows.Forms.TextBox();
            this.lblSoLuongTon = new System.Windows.Forms.Label();
            this.txtTonKhoTu = new System.Windows.Forms.TextBox();
            this.lblTonPhanCach = new System.Windows.Forms.Label();
            this.txtTonKhoDen = new System.Windows.Forms.TextBox();
            this.lblThuongHieu = new System.Windows.Forms.Label();
            this.cboThuongHieu = new System.Windows.Forms.ComboBox();
            this.lblDoTuoi = new System.Windows.Forms.Label();
            this.cboDoTuoi = new System.Windows.Forms.ComboBox();
            this.gbKenhBan = new System.Windows.Forms.GroupBox();
            this.chkShopee = new System.Windows.Forms.CheckBox();
            this.chkTikTok = new System.Windows.Forms.CheckBox();
            this.gbDongBo = new System.Windows.Forms.GroupBox();
            this.rdoDongBoTatCa = new System.Windows.Forms.RadioButton();
            this.rdoDongBoOK = new System.Windows.Forms.RadioButton();
            this.rdoLoiDongBo = new System.Windows.Forms.RadioButton();
            this.lblSapXep = new System.Windows.Forms.Label();
            this.cboSapXep = new System.Windows.Forms.ComboBox();
            this.btnXoaBoLoc = new System.Windows.Forms.Button();
            this.btnApDung = new System.Windows.Forms.Button();
            this.gbTonKho.SuspendLayout();
            this.gbKenhBan.SuspendLayout();
            this.gbDongBo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 15);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(230, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 BỘ LỌC NÂNG CAO";
            // 
            // gbTonKho
            // 
            this.gbTonKho.Controls.Add(this.rdoTonKhoTatCa);
            this.gbTonKho.Controls.Add(this.rdoConHang);
            this.gbTonKho.Controls.Add(this.rdoSapHet);
            this.gbTonKho.Controls.Add(this.rdoHetHang);
            this.gbTonKho.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbTonKho.Location = new System.Drawing.Point(16, 52);
            this.gbTonKho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTonKho.Name = "gbTonKho";
            this.gbTonKho.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbTonKho.Size = new System.Drawing.Size(453, 64);
            this.gbTonKho.TabIndex = 1;
            this.gbTonKho.TabStop = false;
            this.gbTonKho.Text = "TRẠNG THÁI TỒN KHO";
            // 
            // rdoTonKhoTatCa
            // 
            this.rdoTonKhoTatCa.AutoSize = true;
            this.rdoTonKhoTatCa.Checked = true;
            this.rdoTonKhoTatCa.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoTonKhoTatCa.Location = new System.Drawing.Point(13, 27);
            this.rdoTonKhoTatCa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoTonKhoTatCa.Name = "rdoTonKhoTatCa";
            this.rdoTonKhoTatCa.Size = new System.Drawing.Size(66, 23);
            this.rdoTonKhoTatCa.TabIndex = 0;
            this.rdoTonKhoTatCa.TabStop = true;
            this.rdoTonKhoTatCa.Text = "Tất cả";
            // 
            // rdoConHang
            // 
            this.rdoConHang.AutoSize = true;
            this.rdoConHang.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoConHang.Location = new System.Drawing.Point(100, 27);
            this.rdoConHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoConHang.Name = "rdoConHang";
            this.rdoConHang.Size = new System.Drawing.Size(90, 23);
            this.rdoConHang.TabIndex = 1;
            this.rdoConHang.Text = "Còn hàng";
            // 
            // rdoSapHet
            // 
            this.rdoSapHet.AutoSize = true;
            this.rdoSapHet.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoSapHet.Location = new System.Drawing.Point(207, 27);
            this.rdoSapHet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoSapHet.Name = "rdoSapHet";
            this.rdoSapHet.Size = new System.Drawing.Size(76, 23);
            this.rdoSapHet.TabIndex = 2;
            this.rdoSapHet.Text = "Sắp hết";
            // 
            // rdoHetHang
            // 
            this.rdoHetHang.AutoSize = true;
            this.rdoHetHang.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoHetHang.Location = new System.Drawing.Point(307, 27);
            this.rdoHetHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoHetHang.Name = "rdoHetHang";
            this.rdoHetHang.Size = new System.Drawing.Size(87, 23);
            this.rdoHetHang.TabIndex = 3;
            this.rdoHetHang.Text = "Hết hàng";
            // 
            // lblKhoangGia
            // 
            this.lblKhoangGia.AutoSize = true;
            this.lblKhoangGia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKhoangGia.Location = new System.Drawing.Point(16, 126);
            this.lblKhoangGia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKhoangGia.Name = "lblKhoangGia";
            this.lblKhoangGia.Size = new System.Drawing.Size(155, 20);
            this.lblKhoangGia.TabIndex = 2;
            this.lblKhoangGia.Text = "KHOẢNG GIÁ (VNĐ)";
            // 
            // txtGiaTu
            // 
            this.txtGiaTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaTu.Location = new System.Drawing.Point(16, 148);
            this.txtGiaTu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaTu.Name = "txtGiaTu";
            this.txtGiaTu.Size = new System.Drawing.Size(199, 27);
            this.txtGiaTu.TabIndex = 3;
            // 
            // lblGiaPhanCach
            // 
            this.lblGiaPhanCach.AutoSize = true;
            this.lblGiaPhanCach.Location = new System.Drawing.Point(224, 153);
            this.lblGiaPhanCach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaPhanCach.Name = "lblGiaPhanCach";
            this.lblGiaPhanCach.Size = new System.Drawing.Size(25, 16);
            this.lblGiaPhanCach.TabIndex = 4;
            this.lblGiaPhanCach.Text = "──";
            // 
            // txtGiaDen
            // 
            this.txtGiaDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGiaDen.Location = new System.Drawing.Point(261, 148);
            this.txtGiaDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGiaDen.Name = "txtGiaDen";
            this.txtGiaDen.Size = new System.Drawing.Size(207, 27);
            this.txtGiaDen.TabIndex = 5;
            // 
            // lblSoLuongTon
            // 
            this.lblSoLuongTon.AutoSize = true;
            this.lblSoLuongTon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSoLuongTon.Location = new System.Drawing.Point(16, 187);
            this.lblSoLuongTon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoLuongTon.Name = "lblSoLuongTon";
            this.lblSoLuongTon.Size = new System.Drawing.Size(159, 20);
            this.lblSoLuongTon.TabIndex = 6;
            this.lblSoLuongTon.Text = "SỐ LƯỢNG TỒN KHO";
            // 
            // txtTonKhoTu
            // 
            this.txtTonKhoTu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTonKhoTu.Location = new System.Drawing.Point(16, 209);
            this.txtTonKhoTu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTonKhoTu.Name = "txtTonKhoTu";
            this.txtTonKhoTu.Size = new System.Drawing.Size(199, 27);
            this.txtTonKhoTu.TabIndex = 7;
            // 
            // lblTonPhanCach
            // 
            this.lblTonPhanCach.AutoSize = true;
            this.lblTonPhanCach.Location = new System.Drawing.Point(224, 214);
            this.lblTonPhanCach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTonPhanCach.Name = "lblTonPhanCach";
            this.lblTonPhanCach.Size = new System.Drawing.Size(25, 16);
            this.lblTonPhanCach.TabIndex = 8;
            this.lblTonPhanCach.Text = "──";
            // 
            // txtTonKhoDen
            // 
            this.txtTonKhoDen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTonKhoDen.Location = new System.Drawing.Point(261, 209);
            this.txtTonKhoDen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTonKhoDen.Name = "txtTonKhoDen";
            this.txtTonKhoDen.Size = new System.Drawing.Size(207, 27);
            this.txtTonKhoDen.TabIndex = 9;
            // 
            // lblThuongHieu
            // 
            this.lblThuongHieu.AutoSize = true;
            this.lblThuongHieu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuongHieu.Location = new System.Drawing.Point(16, 249);
            this.lblThuongHieu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Size = new System.Drawing.Size(115, 20);
            this.lblThuongHieu.TabIndex = 10;
            this.lblThuongHieu.Text = "THƯƠNG HIỆU";
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuongHieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboThuongHieu.FormattingEnabled = true;
            this.cboThuongHieu.Location = new System.Drawing.Point(16, 271);
            this.cboThuongHieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Size = new System.Drawing.Size(452, 28);
            this.cboThuongHieu.TabIndex = 11;
            // 
            // lblDoTuoi
            // 
            this.lblDoTuoi.AutoSize = true;
            this.lblDoTuoi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDoTuoi.Location = new System.Drawing.Point(16, 310);
            this.lblDoTuoi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDoTuoi.Name = "lblDoTuoi";
            this.lblDoTuoi.Size = new System.Drawing.Size(71, 20);
            this.lblDoTuoi.TabIndex = 12;
            this.lblDoTuoi.Text = "ĐỘ TUỔI";
            // 
            // cboDoTuoi
            // 
            this.cboDoTuoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoTuoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDoTuoi.FormattingEnabled = true;
            this.cboDoTuoi.Location = new System.Drawing.Point(16, 332);
            this.cboDoTuoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDoTuoi.Name = "cboDoTuoi";
            this.cboDoTuoi.Size = new System.Drawing.Size(452, 28);
            this.cboDoTuoi.TabIndex = 13;
            // 
            // gbKenhBan
            // 
            this.gbKenhBan.Controls.Add(this.chkShopee);
            this.gbKenhBan.Controls.Add(this.chkTikTok);
            this.gbKenhBan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbKenhBan.Location = new System.Drawing.Point(16, 372);
            this.gbKenhBan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbKenhBan.Name = "gbKenhBan";
            this.gbKenhBan.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbKenhBan.Size = new System.Drawing.Size(453, 62);
            this.gbKenhBan.TabIndex = 14;
            this.gbKenhBan.TabStop = false;
            this.gbKenhBan.Text = "KÊNH BÁN HÀNG";
            // 
            // chkShopee
            // 
            this.chkShopee.AutoSize = true;
            this.chkShopee.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkShopee.Location = new System.Drawing.Point(13, 27);
            this.chkShopee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkShopee.Name = "chkShopee";
            this.chkShopee.Size = new System.Drawing.Size(76, 23);
            this.chkShopee.TabIndex = 0;
            this.chkShopee.Text = "Shopee";
            // 
            // chkTikTok
            // 
            this.chkTikTok.AutoSize = true;
            this.chkTikTok.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkTikTok.Location = new System.Drawing.Point(133, 27);
            this.chkTikTok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTikTok.Name = "chkTikTok";
            this.chkTikTok.Size = new System.Drawing.Size(104, 23);
            this.chkTikTok.TabIndex = 1;
            this.chkTikTok.Text = "TikTok Shop";
            // 
            // gbDongBo
            // 
            this.gbDongBo.Controls.Add(this.rdoDongBoTatCa);
            this.gbDongBo.Controls.Add(this.rdoDongBoOK);
            this.gbDongBo.Controls.Add(this.rdoLoiDongBo);
            this.gbDongBo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbDongBo.Location = new System.Drawing.Point(16, 441);
            this.gbDongBo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDongBo.Name = "gbDongBo";
            this.gbDongBo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbDongBo.Size = new System.Drawing.Size(453, 62);
            this.gbDongBo.TabIndex = 15;
            this.gbDongBo.TabStop = false;
            this.gbDongBo.Text = "TRẠNG THÁI ĐỒNG BỘ";
            // 
            // rdoDongBoTatCa
            // 
            this.rdoDongBoTatCa.AutoSize = true;
            this.rdoDongBoTatCa.Checked = true;
            this.rdoDongBoTatCa.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoDongBoTatCa.Location = new System.Drawing.Point(13, 27);
            this.rdoDongBoTatCa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoDongBoTatCa.Name = "rdoDongBoTatCa";
            this.rdoDongBoTatCa.Size = new System.Drawing.Size(66, 23);
            this.rdoDongBoTatCa.TabIndex = 0;
            this.rdoDongBoTatCa.TabStop = true;
            this.rdoDongBoTatCa.Text = "Tất cả";
            // 
            // rdoDongBoOK
            // 
            this.rdoDongBoOK.AutoSize = true;
            this.rdoDongBoOK.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoDongBoOK.Location = new System.Drawing.Point(133, 27);
            this.rdoDongBoOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoDongBoOK.Name = "rdoDongBoOK";
            this.rdoDongBoOK.Size = new System.Drawing.Size(107, 23);
            this.rdoDongBoOK.TabIndex = 1;
            this.rdoDongBoOK.Text = "Đồng bộ OK";
            // 
            // rdoLoiDongBo
            // 
            this.rdoLoiDongBo.AutoSize = true;
            this.rdoLoiDongBo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rdoLoiDongBo.Location = new System.Drawing.Point(280, 27);
            this.rdoLoiDongBo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoLoiDongBo.Name = "rdoLoiDongBo";
            this.rdoLoiDongBo.Size = new System.Drawing.Size(104, 23);
            this.rdoLoiDongBo.TabIndex = 2;
            this.rdoLoiDongBo.Text = "Lỗi đồng bộ";
            // 
            // lblSapXep
            // 
            this.lblSapXep.AutoSize = true;
            this.lblSapXep.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSapXep.Location = new System.Drawing.Point(16, 510);
            this.lblSapXep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSapXep.Name = "lblSapXep";
            this.lblSapXep.Size = new System.Drawing.Size(111, 20);
            this.lblSapXep.TabIndex = 16;
            this.lblSapXep.Text = "SẮP XẾP THEO";
            // 
            // cboSapXep
            // 
            this.cboSapXep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSapXep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboSapXep.FormattingEnabled = true;
            this.cboSapXep.Location = new System.Drawing.Point(16, 532);
            this.cboSapXep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboSapXep.Name = "cboSapXep";
            this.cboSapXep.Size = new System.Drawing.Size(452, 28);
            this.cboSapXep.TabIndex = 17;
            // 
            // btnXoaBoLoc
            // 
            this.btnXoaBoLoc.BackColor = System.Drawing.Color.White;
            this.btnXoaBoLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaBoLoc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnXoaBoLoc.ForeColor = System.Drawing.Color.DimGray;
            this.btnXoaBoLoc.Location = new System.Drawing.Point(16, 585);
            this.btnXoaBoLoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXoaBoLoc.Name = "btnXoaBoLoc";
            this.btnXoaBoLoc.Size = new System.Drawing.Size(200, 44);
            this.btnXoaBoLoc.TabIndex = 18;
            this.btnXoaBoLoc.Text = "Xóa bộ lọc";
            this.btnXoaBoLoc.UseVisualStyleBackColor = false;
            this.btnXoaBoLoc.Click += new System.EventHandler(this.btnXoaBoLoc_Click);
            // 
            // btnApDung
            // 
            this.btnApDung.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnApDung.FlatAppearance.BorderSize = 0;
            this.btnApDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnApDung.ForeColor = System.Drawing.Color.White;
            this.btnApDung.Location = new System.Drawing.Point(261, 585);
            this.btnApDung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApDung.Name = "btnApDung";
            this.btnApDung.Size = new System.Drawing.Size(208, 44);
            this.btnApDung.TabIndex = 19;
            this.btnApDung.Text = "Áp dụng";
            this.btnApDung.UseVisualStyleBackColor = false;
            this.btnApDung.Click += new System.EventHandler(this.btnApDung_Click);
            // 
            // frmLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 646);
            this.Controls.Add(this.btnApDung);
            this.Controls.Add(this.btnXoaBoLoc);
            this.Controls.Add(this.cboSapXep);
            this.Controls.Add(this.lblSapXep);
            this.Controls.Add(this.gbDongBo);
            this.Controls.Add(this.gbKenhBan);
            this.Controls.Add(this.cboDoTuoi);
            this.Controls.Add(this.lblDoTuoi);
            this.Controls.Add(this.cboThuongHieu);
            this.Controls.Add(this.lblThuongHieu);
            this.Controls.Add(this.txtTonKhoDen);
            this.Controls.Add(this.lblTonPhanCach);
            this.Controls.Add(this.txtTonKhoTu);
            this.Controls.Add(this.lblSoLuongTon);
            this.Controls.Add(this.txtGiaDen);
            this.Controls.Add(this.lblGiaPhanCach);
            this.Controls.Add(this.txtGiaTu);
            this.Controls.Add(this.lblKhoangGia);
            this.Controls.Add(this.gbTonKho);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thiết lập lọc nâng cao";
            this.gbTonKho.ResumeLayout(false);
            this.gbTonKho.PerformLayout();
            this.gbKenhBan.ResumeLayout(false);
            this.gbKenhBan.PerformLayout();
            this.gbDongBo.ResumeLayout(false);
            this.gbDongBo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox gbTonKho;
        private System.Windows.Forms.RadioButton rdoTonKhoTatCa;
        private System.Windows.Forms.RadioButton rdoConHang;
        private System.Windows.Forms.RadioButton rdoSapHet;
        private System.Windows.Forms.RadioButton rdoHetHang;
        private System.Windows.Forms.Label lblKhoangGia;
        private System.Windows.Forms.TextBox txtGiaTu;
        private System.Windows.Forms.Label lblGiaPhanCach;
        private System.Windows.Forms.TextBox txtGiaDen;
        private System.Windows.Forms.Label lblSoLuongTon;
        private System.Windows.Forms.TextBox txtTonKhoTu;
        private System.Windows.Forms.Label lblTonPhanCach;
        private System.Windows.Forms.TextBox txtTonKhoDen;
        private System.Windows.Forms.Label lblThuongHieu;
        private System.Windows.Forms.ComboBox cboThuongHieu;
        private System.Windows.Forms.Label lblDoTuoi;
        private System.Windows.Forms.ComboBox cboDoTuoi;
        private System.Windows.Forms.GroupBox gbKenhBan;
        private System.Windows.Forms.CheckBox chkShopee;
        private System.Windows.Forms.CheckBox chkTikTok;
        private System.Windows.Forms.GroupBox gbDongBo;
        private System.Windows.Forms.RadioButton rdoDongBoTatCa;
        private System.Windows.Forms.RadioButton rdoDongBoOK;
        private System.Windows.Forms.RadioButton rdoLoiDongBo;
        private System.Windows.Forms.Label lblSapXep;
        private System.Windows.Forms.ComboBox cboSapXep;
        private System.Windows.Forms.Button btnXoaBoLoc;
        private System.Windows.Forms.Button btnApDung;
    }
}