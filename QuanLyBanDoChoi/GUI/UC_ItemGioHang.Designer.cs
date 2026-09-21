namespace QuanLyBanDoChoi.GUI
{
    partial class UC_ItemGioHang
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
            this.components = new System.ComponentModel.Container();
            this.lblTenDoChoi = new System.Windows.Forms.Label();
            this.btXoa = new System.Windows.Forms.Button();
            this.lblHang = new System.Windows.Forms.Label();
            this.btGiam = new System.Windows.Forms.Button();
            this.btTang = new System.Windows.Forms.Button();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTenDoChoi
            // 
            this.lblTenDoChoi.AutoSize = true;
            this.lblTenDoChoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDoChoi.Location = new System.Drawing.Point(5, 5);
            this.lblTenDoChoi.Name = "lblTenDoChoi";
            this.lblTenDoChoi.Size = new System.Drawing.Size(71, 15);
            this.lblTenDoChoi.TabIndex = 0;
            this.lblTenDoChoi.Text = "Tên đồ chơi";
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.Transparent;
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.ForeColor = System.Drawing.Color.Red;
            this.btXoa.Location = new System.Drawing.Point(235, 5);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(20, 20);
            this.btXoa.TabIndex = 1;
            this.btXoa.Text = "X";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // lblHang
            // 
            this.lblHang.AutoSize = true;
            this.lblHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblHang.Location = new System.Drawing.Point(5, 25);
            this.lblHang.Name = "lblHang";
            this.lblHang.Size = new System.Drawing.Size(31, 13);
            this.lblHang.TabIndex = 2;
            this.lblHang.Text = "hãng";
            // 
            // btGiam
            // 
            this.btGiam.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btGiam.Location = new System.Drawing.Point(5, 42);
            this.btGiam.Name = "btGiam";
            this.btGiam.Size = new System.Drawing.Size(22, 22);
            this.btGiam.TabIndex = 3;
            this.btGiam.Text = "-";
            this.btGiam.UseVisualStyleBackColor = false;
            this.btGiam.Click += new System.EventHandler(this.btGiam_Click);
            // 
            // btTang
            // 
            this.btTang.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btTang.Location = new System.Drawing.Point(54, 42);
            this.btTang.Name = "btTang";
            this.btTang.Size = new System.Drawing.Size(22, 22);
            this.btTang.TabIndex = 5;
            this.btTang.Text = "+";
            this.btTang.UseVisualStyleBackColor = false;
            this.btTang.Click += new System.EventHandler(this.btTang_Click);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThanhTien.ForeColor = System.Drawing.Color.DarkRed;
            this.lblThanhTien.Location = new System.Drawing.Point(175, 45);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Size = new System.Drawing.Size(63, 15);
            this.lblThanhTien.TabIndex = 6;
            this.lblThanhTien.Text = "65.000 đ";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(31, 43);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(20, 20);
            this.txtSoLuong.TabIndex = 7;
            this.txtSoLuong.Text = "1";
            // 
            // UC_ItemGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lblThanhTien);
            this.Controls.Add(this.btTang);
            this.Controls.Add(this.btGiam);
            this.Controls.Add(this.lblHang);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.lblTenDoChoi);
            this.Location = new System.Drawing.Point(200, 5);
            this.Name = "UC_ItemGioHang";
            this.Size = new System.Drawing.Size(262, 70);
            this.Load += new System.EventHandler(this.UC_ItemGioHang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenDoChoi;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label lblHang;
        private System.Windows.Forms.Button btGiam;
        private System.Windows.Forms.Button btTang;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtSoLuong;
    }
}
