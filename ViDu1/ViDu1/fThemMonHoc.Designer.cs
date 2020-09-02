namespace ViDu1
{
    partial class fThemMonHoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fThemMonHoc));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaMonHoc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenMonHoc = new System.Windows.Forms.TextBox();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lbIDMonHoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã môn học:";
            // 
            // txtMaMonHoc
            // 
            this.txtMaMonHoc.Location = new System.Drawing.Point(128, 14);
            this.txtMaMonHoc.Name = "txtMaMonHoc";
            this.txtMaMonHoc.Size = new System.Drawing.Size(327, 26);
            this.txtMaMonHoc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên môn học:";
            // 
            // txtTenMonHoc
            // 
            this.txtTenMonHoc.Location = new System.Drawing.Point(128, 54);
            this.txtTenMonHoc.Name = "txtTenMonHoc";
            this.txtTenMonHoc.Size = new System.Drawing.Size(327, 26);
            this.txtTenMonHoc.TabIndex = 1;
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(261, 91);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 31);
            this.btnGhi.TabIndex = 2;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(353, 91);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 31);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lbIDMonHoc
            // 
            this.lbIDMonHoc.AutoSize = true;
            this.lbIDMonHoc.ForeColor = System.Drawing.Color.Red;
            this.lbIDMonHoc.Location = new System.Drawing.Point(47, 91);
            this.lbIDMonHoc.Name = "lbIDMonHoc";
            this.lbIDMonHoc.Size = new System.Drawing.Size(208, 20);
            this.lbIDMonHoc.TabIndex = 12;
            this.lbIDMonHoc.Text = "lbIDMonHoc=TreeNode.Tag";
            this.lbIDMonHoc.Visible = false;
            // 
            // fThemMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(483, 139);
            this.Controls.Add(this.lbIDMonHoc);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTenMonHoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaMonHoc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fThemMonHoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm môn học";
            this.Load += new System.EventHandler(this.fThemMonHoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaMonHoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenMonHoc;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lbIDMonHoc;
    }
}