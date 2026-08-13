namespace Bai2
{
    partial class MainForm
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
            this.grGT = new System.Windows.Forms.GroupBox();
            this.rdNam = new System.Windows.Forms.RadioButton();
            this.rdNu = new System.Windows.Forms.RadioButton();
            this.grMau = new System.Windows.Forms.GroupBox();
            this.rdXanh = new System.Windows.Forms.RadioButton();
            this.rdDo = new System.Windows.Forms.RadioButton();
            this.btToMau = new System.Windows.Forms.Button();
            this.txtOMau = new System.Windows.Forms.TextBox();
            this.grGT.SuspendLayout();
            this.grMau.SuspendLayout();
            this.SuspendLayout();
            // 
            // grGT
            // 
            this.grGT.Controls.Add(this.rdNu);
            this.grGT.Controls.Add(this.rdNam);
            this.grGT.Location = new System.Drawing.Point(37, 43);
            this.grGT.Name = "grGT";
            this.grGT.Size = new System.Drawing.Size(200, 100);
            this.grGT.TabIndex = 0;
            this.grGT.TabStop = false;
            this.grGT.Text = "Giới tính";
            // 
            // rdNam
            // 
            this.rdNam.AutoSize = true;
            this.rdNam.Checked = true;
            this.rdNam.Location = new System.Drawing.Point(6, 19);
            this.rdNam.Name = "rdNam";
            this.rdNam.Size = new System.Drawing.Size(47, 17);
            this.rdNam.TabIndex = 1;
            this.rdNam.TabStop = true;
            this.rdNam.Text = "Nam";
            this.rdNam.UseVisualStyleBackColor = true;
            this.rdNam.CheckedChanged += new System.EventHandler(this.rdNam_CheckedChanged_1);
            // 
            // rdNu
            // 
            this.rdNu.AutoSize = true;
            this.rdNu.Location = new System.Drawing.Point(6, 54);
            this.rdNu.Name = "rdNu";
            this.rdNu.Size = new System.Drawing.Size(39, 17);
            this.rdNu.TabIndex = 1;
            this.rdNu.Text = "Nữ";
            this.rdNu.UseVisualStyleBackColor = true;
            this.rdNu.CheckedChanged += new System.EventHandler(this.rdNu_CheckedChanged);
            // 
            // grMau
            // 
            this.grMau.Controls.Add(this.btToMau);
            this.grMau.Controls.Add(this.rdXanh);
            this.grMau.Controls.Add(this.rdDo);
            this.grMau.Location = new System.Drawing.Point(37, 211);
            this.grMau.Name = "grMau";
            this.grMau.Size = new System.Drawing.Size(286, 100);
            this.grMau.TabIndex = 2;
            this.grMau.TabStop = false;
            this.grMau.Text = "Màu sắc";
            // 
            // rdXanh
            // 
            this.rdXanh.AutoSize = true;
            this.rdXanh.Location = new System.Drawing.Point(6, 54);
            this.rdXanh.Name = "rdXanh";
            this.rdXanh.Size = new System.Drawing.Size(72, 17);
            this.rdXanh.TabIndex = 1;
            this.rdXanh.Text = "Màu xanh";
            this.rdXanh.UseVisualStyleBackColor = true;
            // 
            // rdDo
            // 
            this.rdDo.AutoSize = true;
            this.rdDo.Checked = true;
            this.rdDo.Location = new System.Drawing.Point(6, 19);
            this.rdDo.Name = "rdDo";
            this.rdDo.Size = new System.Drawing.Size(62, 17);
            this.rdDo.TabIndex = 1;
            this.rdDo.TabStop = true;
            this.rdDo.Text = "Màu đỏ";
            this.rdDo.UseVisualStyleBackColor = true;
            // 
            // btToMau
            // 
            this.btToMau.Location = new System.Drawing.Point(143, 39);
            this.btToMau.Name = "btToMau";
            this.btToMau.Size = new System.Drawing.Size(75, 23);
            this.btToMau.TabIndex = 3;
            this.btToMau.Text = "Tô màu";
            this.btToMau.UseVisualStyleBackColor = true;
            this.btToMau.Click += new System.EventHandler(this.btToMau_Click);
            // 
            // txtOMau
            // 
            this.txtOMau.Location = new System.Drawing.Point(413, 211);
            this.txtOMau.Multiline = true;
            this.txtOMau.Name = "txtOMau";
            this.txtOMau.Size = new System.Drawing.Size(100, 100);
            this.txtOMau.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtOMau);
            this.Controls.Add(this.grMau);
            this.Controls.Add(this.grGT);
            this.Name = "MainForm";
            this.Text = "Bài tập 2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grGT.ResumeLayout(false);
            this.grGT.PerformLayout();
            this.grMau.ResumeLayout(false);
            this.grMau.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grGT;
        private System.Windows.Forms.RadioButton rdNu;
        private System.Windows.Forms.RadioButton rdNam;
        private System.Windows.Forms.GroupBox grMau;
        private System.Windows.Forms.RadioButton rdXanh;
        private System.Windows.Forms.RadioButton rdDo;
        private System.Windows.Forms.Button btToMau;
        private System.Windows.Forms.TextBox txtOMau;
    }
}

