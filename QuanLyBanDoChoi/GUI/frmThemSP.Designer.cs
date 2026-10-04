namespace QuanLyBanDoChoi.GUI
{
    partial class frmThemSP
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpImage = new System.Windows.Forms.GroupBox();
            this.btnBrowseImg = new System.Windows.Forms.Button();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.radNgungKinhDoanh = new System.Windows.Forms.RadioButton();
            this.radDangKinhDoanh = new System.Windows.Forms.RadioButton();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.numTonKho = new System.Windows.Forms.NumericUpDown();
            this.lblTonKho = new System.Windows.Forms.Label();
            this.txtXuatXu = new System.Windows.Forms.TextBox();
            this.lblXuatXu = new System.Windows.Forms.Label();
            this.cboDoTuoi = new System.Windows.Forms.ComboBox();
            this.lblDoTuoi = new System.Windows.Forms.Label();
            this.txtHang = new System.Windows.Forms.TextBox();
            this.lblHang = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.lblMaSP = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.lblTenSP = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboKenhBan = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            this.grpImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonKho)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSubTitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(784, 52);
            this.pnlHeader.TabIndex = 3;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.lblSubTitle.Location = new System.Drawing.Point(17, 33);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(188, 20);
            this.lblSubTitle.TabIndex = 0;
            this.lblSubTitle.Text = "Thông tin cơ bản & Hình ảnh";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(257, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "+ Thêm Sản Phẩm Mới";
            // 
            // grpImage
            // 
            this.grpImage.Controls.Add(this.btnBrowseImg);
            this.grpImage.Controls.Add(this.picHinhAnh);
            this.grpImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpImage.Location = new System.Drawing.Point(15, 60);
            this.grpImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImage.Name = "grpImage";
            this.grpImage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImage.Size = new System.Drawing.Size(250, 288);
            this.grpImage.TabIndex = 2;
            this.grpImage.TabStop = false;
            this.grpImage.Text = "Hình ảnh sản phẩm";
            // 
            // btnBrowseImg
            // 
            this.btnBrowseImg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowseImg.Location = new System.Drawing.Point(15, 244);
            this.btnBrowseImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowseImg.Name = "btnBrowseImg";
            this.btnBrowseImg.Size = new System.Drawing.Size(220, 28);
            this.btnBrowseImg.TabIndex = 0;
            this.btnBrowseImg.Text = "+ Tải ảnh lên";
            this.btnBrowseImg.UseVisualStyleBackColor = true;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHinhAnh.Location = new System.Drawing.Point(15, 24);
            this.picHinhAnh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(220, 208);
            this.picHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHinhAnh.TabIndex = 1;
            this.picHinhAnh.TabStop = false;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.cboKenhBan);
            this.grpInfo.Controls.Add(this.label1);
            this.grpInfo.Controls.Add(this.radNgungKinhDoanh);
            this.grpInfo.Controls.Add(this.radDangKinhDoanh);
            this.grpInfo.Controls.Add(this.lblTrangThai);
            this.grpInfo.Controls.Add(this.numDonGia);
            this.grpInfo.Controls.Add(this.lblDonGia);
            this.grpInfo.Controls.Add(this.numTonKho);
            this.grpInfo.Controls.Add(this.lblTonKho);
            this.grpInfo.Controls.Add(this.txtXuatXu);
            this.grpInfo.Controls.Add(this.lblXuatXu);
            this.grpInfo.Controls.Add(this.cboDoTuoi);
            this.grpInfo.Controls.Add(this.lblDoTuoi);
            this.grpInfo.Controls.Add(this.txtHang);
            this.grpInfo.Controls.Add(this.lblHang);
            this.grpInfo.Controls.Add(this.cboDanhMuc);
            this.grpInfo.Controls.Add(this.lblDanhMuc);
            this.grpInfo.Controls.Add(this.txtMaSP);
            this.grpInfo.Controls.Add(this.lblMaSP);
            this.grpInfo.Controls.Add(this.txtTenSP);
            this.grpInfo.Controls.Add(this.lblTenSP);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpInfo.Location = new System.Drawing.Point(280, 60);
            this.grpInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpInfo.Size = new System.Drawing.Size(485, 295);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Chi tiết sản phẩm";
            // 
            // radNgungKinhDoanh
            // 
            this.radNgungKinhDoanh.AutoSize = true;
            this.radNgungKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radNgungKinhDoanh.Location = new System.Drawing.Point(168, 264);
            this.radNgungKinhDoanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radNgungKinhDoanh.Name = "radNgungKinhDoanh";
            this.radNgungKinhDoanh.Size = new System.Drawing.Size(153, 24);
            this.radNgungKinhDoanh.TabIndex = 0;
            this.radNgungKinhDoanh.Text = "Ngừng kinh doanh";
            // 
            // radDangKinhDoanh
            // 
            this.radDangKinhDoanh.AutoSize = true;
            this.radDangKinhDoanh.Checked = true;
            this.radDangKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radDangKinhDoanh.Location = new System.Drawing.Point(19, 264);
            this.radDangKinhDoanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radDangKinhDoanh.Name = "radDangKinhDoanh";
            this.radDangKinhDoanh.Size = new System.Drawing.Size(143, 24);
            this.radDangKinhDoanh.TabIndex = 1;
            this.radDangKinhDoanh.TabStop = true;
            this.radDangKinhDoanh.Text = "Đang kinh doanh";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTrangThai.Location = new System.Drawing.Point(15, 248);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(75, 20);
            this.lblTrangThai.TabIndex = 2;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // numDonGia
            // 
            this.numDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numDonGia.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDonGia.Location = new System.Drawing.Point(250, 190);
            this.numDonGia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numDonGia.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(220, 27);
            this.numDonGia.TabIndex = 3;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDonGia.Location = new System.Drawing.Point(250, 171);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(136, 20);
            this.lblDonGia.TabIndex = 4;
            this.lblDonGia.Text = "Đơn giá bán (VNĐ)";
            // 
            // numTonKho
            // 
            this.numTonKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTonKho.Location = new System.Drawing.Point(15, 190);
            this.numTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numTonKho.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTonKho.Name = "numTonKho";
            this.numTonKho.Size = new System.Drawing.Size(220, 27);
            this.numTonKho.TabIndex = 5;
            // 
            // lblTonKho
            // 
            this.lblTonKho.AutoSize = true;
            this.lblTonKho.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTonKho.Location = new System.Drawing.Point(15, 171);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(123, 20);
            this.lblTonKho.TabIndex = 6;
            this.lblTonKho.Text = "Số lượng tồn kho";
            // 
            // txtXuatXu
            // 
            this.txtXuatXu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtXuatXu.Location = new System.Drawing.Point(250, 139);
            this.txtXuatXu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtXuatXu.Name = "txtXuatXu";
            this.txtXuatXu.Size = new System.Drawing.Size(220, 27);
            this.txtXuatXu.TabIndex = 7;
            // 
            // lblXuatXu
            // 
            this.lblXuatXu.AutoSize = true;
            this.lblXuatXu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblXuatXu.Location = new System.Drawing.Point(250, 121);
            this.lblXuatXu.Name = "lblXuatXu";
            this.lblXuatXu.Size = new System.Drawing.Size(132, 20);
            this.lblXuatXu.TabIndex = 8;
            this.lblXuatXu.Text = "Xuất xứ / Vị trí kho";
            // 
            // cboDoTuoi
            // 
            this.cboDoTuoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDoTuoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDoTuoi.Location = new System.Drawing.Point(15, 139);
            this.cboDoTuoi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDoTuoi.Name = "cboDoTuoi";
            this.cboDoTuoi.Size = new System.Drawing.Size(220, 28);
            this.cboDoTuoi.TabIndex = 9;
            // 
            // lblDoTuoi
            // 
            this.lblDoTuoi.AutoSize = true;
            this.lblDoTuoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDoTuoi.Location = new System.Drawing.Point(15, 121);
            this.lblDoTuoi.Name = "lblDoTuoi";
            this.lblDoTuoi.Size = new System.Drawing.Size(59, 20);
            this.lblDoTuoi.TabIndex = 10;
            this.lblDoTuoi.Text = "Độ tuổi";
            // 
            // txtHang
            // 
            this.txtHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHang.Location = new System.Drawing.Point(250, 89);
            this.txtHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHang.Name = "txtHang";
            this.txtHang.Size = new System.Drawing.Size(220, 27);
            this.txtHang.TabIndex = 11;
            // 
            // lblHang
            // 
            this.lblHang.AutoSize = true;
            this.lblHang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHang.Location = new System.Drawing.Point(250, 70);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new System.Drawing.Size(92, 20);
            this.lblHang.TabIndex = 12;
            this.lblHang.Text = "Thương hiệu";
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDanhMuc.Location = new System.Drawing.Point(15, 89);
            this.cboDanhMuc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(220, 28);
            this.cboDanhMuc.TabIndex = 13;
            // 
            // lblDanhMuc
            // 
            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDanhMuc.Location = new System.Drawing.Point(15, 70);
            this.lblDanhMuc.Name = "lblDanhMuc";
            this.lblDanhMuc.Size = new System.Drawing.Size(118, 20);
            this.lblDanhMuc.TabIndex = 14;
            this.lblDanhMuc.Text = "Danh mục (Loại)";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaSP.Location = new System.Drawing.Point(250, 38);
            this.txtMaSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(220, 27);
            this.txtMaSP.TabIndex = 15;
            // 
            // lblMaSP
            // 
            this.lblMaSP.AutoSize = true;
            this.lblMaSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMaSP.Location = new System.Drawing.Point(250, 20);
            this.lblMaSP.Name = "lblMaSP";
            this.lblMaSP.Size = new System.Drawing.Size(149, 20);
            this.lblMaSP.TabIndex = 16;
            this.lblMaSP.Text = "Mã sản phẩm (SKU) *";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenSP.Location = new System.Drawing.Point(15, 38);
            this.txtTenSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(220, 27);
            this.txtTenSP.TabIndex = 17;
            // 
            // lblTenSP
            // 
            this.lblTenSP.AutoSize = true;
            this.lblTenSP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTenSP.Location = new System.Drawing.Point(15, 20);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(110, 20);
            this.lblTenSP.TabIndex = 18;
            this.lblTenSP.Text = "Tên sản phẩm *";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnHuy);
            this.pnlFooter.Controls.Add(this.btnLuu);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 411);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(784, 44);
            this.pnlFooter.TabIndex = 0;
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHuy.Location = new System.Drawing.Point(483, 5);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 28);
            this.btnHuy.TabIndex = 0;
            this.btnHuy.Text = "Hủy";
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(599, 5);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(166, 28);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "💾 Thêm Sản Phẩm";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnThemDongBo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(15, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Kênh bán";
            // 
            // cboKenhBan
            // 
            this.cboKenhBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKenhBan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKenhBan.Items.AddRange(new object[] {
            "Tại quầy",
            "Shopee",
            "TikTok Shop",
            "Tại quầy, TikTok Shop",
            "Tại quầy, Shopee",
            "Tất cả các kênh"});
            this.cboKenhBan.Location = new System.Drawing.Point(92, 220);
            this.cboKenhBan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboKenhBan.Name = "cboKenhBan";
            this.cboKenhBan.Size = new System.Drawing.Size(143, 28);
            this.cboKenhBan.TabIndex = 20;
            // 
            // frmThemSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 455);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.grpImage);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemSP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm Sản Phẩm Mới";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.grpImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTonKho)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.GroupBox grpImage;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnBrowseImg;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblTenSP;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label lblMaSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.TextBox txtHang;
        private System.Windows.Forms.Label lblDoTuoi;
        private System.Windows.Forms.ComboBox cboDoTuoi;
        private System.Windows.Forms.Label lblXuatXu;
        private System.Windows.Forms.TextBox txtXuatXu;
        private System.Windows.Forms.Label lblTonKho;
        private System.Windows.Forms.NumericUpDown numTonKho;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.RadioButton radDangKinhDoanh;
        private System.Windows.Forms.RadioButton radNgungKinhDoanh;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cboKenhBan;
        private System.Windows.Forms.Label label1;
    }
}