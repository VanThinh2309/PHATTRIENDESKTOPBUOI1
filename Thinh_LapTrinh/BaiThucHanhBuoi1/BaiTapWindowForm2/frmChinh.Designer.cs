namespace BaiTapWindowForm2
{
    partial class frmChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChinh));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bàiTập2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.câu1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.câu2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.câu3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bàiTập2ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bàiTập2ToolStripMenuItem
            // 
            this.bàiTập2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.câu1ToolStripMenuItem,
            this.câu2ToolStripMenuItem,
            this.câu3ToolStripMenuItem});
            this.bàiTập2ToolStripMenuItem.Name = "bàiTập2ToolStripMenuItem";
            this.bàiTập2ToolStripMenuItem.Size = new System.Drawing.Size(102, 26);
            this.bàiTập2ToolStripMenuItem.Text = "Bài kiểm tra";
            // 
            // câu1ToolStripMenuItem
            // 
            this.câu1ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("câu1ToolStripMenuItem.Image")));
            this.câu1ToolStripMenuItem.Name = "câu1ToolStripMenuItem";
            this.câu1ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.câu1ToolStripMenuItem.Text = "Câu 1";
            this.câu1ToolStripMenuItem.Click += new System.EventHandler(this.câu1ToolStripMenuItem_Click);
            // 
            // câu2ToolStripMenuItem
            // 
            this.câu2ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("câu2ToolStripMenuItem.Image")));
            this.câu2ToolStripMenuItem.Name = "câu2ToolStripMenuItem";
            this.câu2ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.câu2ToolStripMenuItem.Text = "Câu 2";
            this.câu2ToolStripMenuItem.Click += new System.EventHandler(this.câu2ToolStripMenuItem_Click);
            // 
            // câu3ToolStripMenuItem
            // 
            this.câu3ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("câu3ToolStripMenuItem.Image")));
            this.câu3ToolStripMenuItem.Name = "câu3ToolStripMenuItem";
            this.câu3ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.câu3ToolStripMenuItem.Text = "Câu 3";
            this.câu3ToolStripMenuItem.Click += new System.EventHandler(this.câu3ToolStripMenuItem_Click);
            // 
            // frmChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmChinh";
            this.Text = "Chương trình chính";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bàiTập2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem câu1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem câu2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem câu3ToolStripMenuItem;
    }
}

