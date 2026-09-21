namespace QuanLyBanDoChoi.GUI
{
    partial class frmThemKH
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiemTL = new System.Windows.Forms.TextBox();
            this.cboHang = new System.Windows.Forms.ComboBox();
            this.btnLuuKH = new System.Windows.Forms.Button();
            this.btnHuyKH = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(52, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM KHÁCH HÀNG MỚI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã KH: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên KH:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Số điện thoại:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(12, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Điểm tích lũy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(11, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Hạng:";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(90, 41);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.ReadOnly = true;
            this.txtMaKH.Size = new System.Drawing.Size(100, 22);
            this.txtMaKH.TabIndex = 2;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(90, 80);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(172, 22);
            this.txtHoTen.TabIndex = 2;
            this.txtHoTen.Text = "Nhập họ tên...";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(129, 129);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(173, 22);
            this.txtSDT.TabIndex = 2;
            this.txtSDT.Text = "Nhập số điện thoại...";
            // 
            // txtDiemTL
            // 
            this.txtDiemTL.Location = new System.Drawing.Point(129, 178);
            this.txtDiemTL.Name = "txtDiemTL";
            this.txtDiemTL.ReadOnly = true;
            this.txtDiemTL.Size = new System.Drawing.Size(173, 22);
            this.txtDiemTL.TabIndex = 3;
            this.txtDiemTL.Text = "0";
            // 
            // cboHang
            // 
            this.cboHang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHang.Enabled = false;
            this.cboHang.FormattingEnabled = true;
            this.cboHang.Items.AddRange(new object[] {
            "Đồng",
            "Bạc",
            "Vàng",
            "Kim Cương"});
            this.cboHang.Location = new System.Drawing.Point(71, 226);
            this.cboHang.Name = "cboHang";
            this.cboHang.Size = new System.Drawing.Size(121, 24);
            this.cboHang.TabIndex = 4;
            // 
            // btnLuuKH
            // 
            this.btnLuuKH.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnLuuKH.Location = new System.Drawing.Point(33, 271);
            this.btnLuuKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuKH.Name = "btnLuuKH";
            this.btnLuuKH.Size = new System.Drawing.Size(75, 39);
            this.btnLuuKH.TabIndex = 8;
            this.btnLuuKH.Text = "💾 Lưu";
            this.btnLuuKH.UseVisualStyleBackColor = true;
            // 
            // btnHuyKH
            // 
            this.btnHuyKH.ForeColor = System.Drawing.Color.Red;
            this.btnHuyKH.Location = new System.Drawing.Point(203, 271);
            this.btnHuyKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyKH.Name = "btnHuyKH";
            this.btnHuyKH.Size = new System.Drawing.Size(75, 39);
            this.btnHuyKH.TabIndex = 9;
            this.btnHuyKH.Text = "❌ Hủy";
            this.btnHuyKH.UseVisualStyleBackColor = true;
            // 
            // frmThemKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 333);
            this.Controls.Add(this.btnHuyKH);
            this.Controls.Add(this.btnLuuKH);
            this.Controls.Add(this.cboHang);
            this.Controls.Add(this.txtDiemTL);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThemKH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khách hàng mới";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiemTL;
        private System.Windows.Forms.ComboBox cboHang;
        private System.Windows.Forms.Button btnLuuKH;
        private System.Windows.Forms.Button btnHuyKH;
    }
}