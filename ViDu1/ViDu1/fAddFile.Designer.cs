namespace ViDu1
{
    partial class fAddFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAddFile));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenFile = new System.Windows.Forms.TextBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKieu = new System.Windows.Forms.ComboBox();
            this.chkMacDinh = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudDiem = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLoaiKho = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudSoCau = new System.Windows.Forms.NumericUpDown();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.chkKiemTra = new System.Windows.Forms.CheckBox();
            this.lbDuongDan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn:";
            // 
            // txtTenFile
            // 
            this.txtTenFile.Location = new System.Drawing.Point(115, 6);
            this.txtTenFile.Name = "txtTenFile";
            this.txtTenFile.Size = new System.Drawing.Size(293, 26);
            this.txtTenFile.TabIndex = 0;
            // 
            // btnChon
            // 
            this.btnChon.Location = new System.Drawing.Point(414, 5);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(77, 29);
            this.btnChon.TabIndex = 1;
            this.btnChon.Text = "Chọn";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Kiểu:";
            // 
            // cbKieu
            // 
            this.cbKieu.FormattingEnabled = true;
            this.cbKieu.Items.AddRange(new object[] {
            "Tự luận",
            "Trắc nghiệm"});
            this.cbKieu.Location = new System.Drawing.Point(115, 40);
            this.cbKieu.Name = "cbKieu";
            this.cbKieu.Size = new System.Drawing.Size(376, 28);
            this.cbKieu.TabIndex = 2;
            // 
            // chkMacDinh
            // 
            this.chkMacDinh.AutoSize = true;
            this.chkMacDinh.Location = new System.Drawing.Point(26, 80);
            this.chkMacDinh.Name = "chkMacDinh";
            this.chkMacDinh.Size = new System.Drawing.Size(92, 24);
            this.chkMacDinh.TabIndex = 3;
            this.chkMacDinh.Text = "Mặc định";
            this.chkMacDinh.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Điểm:";
            // 
            // nudDiem
            // 
            this.nudDiem.DecimalPlaces = 2;
            this.nudDiem.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudDiem.Location = new System.Drawing.Point(73, 110);
            this.nudDiem.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDiem.Name = "nudDiem";
            this.nudDiem.Size = new System.Drawing.Size(56, 26);
            this.nudDiem.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loại khó:";
            // 
            // cbLoaiKho
            // 
            this.cbLoaiKho.FormattingEnabled = true;
            this.cbLoaiKho.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbLoaiKho.Location = new System.Drawing.Point(230, 110);
            this.cbLoaiKho.Name = "cbLoaiKho";
            this.cbLoaiKho.Size = new System.Drawing.Size(55, 28);
            this.cbLoaiKho.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số câu mặc định:";
            // 
            // nudSoCau
            // 
            this.nudSoCau.Location = new System.Drawing.Point(435, 112);
            this.nudSoCau.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSoCau.Name = "nudSoCau";
            this.nudSoCau.Size = new System.Drawing.Size(56, 26);
            this.nudSoCau.TabIndex = 6;
            // 
            // btnDong
            // 
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Location = new System.Drawing.Point(382, 153);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 31);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(290, 153);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(75, 31);
            this.btnGhi.TabIndex = 8;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // chkKiemTra
            // 
            this.chkKiemTra.AutoSize = true;
            this.chkKiemTra.Location = new System.Drawing.Point(26, 153);
            this.chkKiemTra.Name = "chkKiemTra";
            this.chkKiemTra.Size = new System.Drawing.Size(86, 24);
            this.chkKiemTra.TabIndex = 7;
            this.chkKiemTra.Text = "Kiểm tra";
            this.chkKiemTra.UseVisualStyleBackColor = true;
            // 
            // lbDuongDan
            // 
            this.lbDuongDan.AutoSize = true;
            this.lbDuongDan.ForeColor = System.Drawing.Color.Red;
            this.lbDuongDan.Location = new System.Drawing.Point(90, 64);
            this.lbDuongDan.Name = "lbDuongDan";
            this.lbDuongDan.Size = new System.Drawing.Size(88, 20);
            this.lbDuongDan.TabIndex = 0;
            this.lbDuongDan.Text = "Đường dẫn";
            this.lbDuongDan.Visible = false;
            // 
            // fAddFile
            // 
            this.AcceptButton = this.btnGhi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(503, 196);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.cbLoaiKho);
            this.Controls.Add(this.nudSoCau);
            this.Controls.Add(this.nudDiem);
            this.Controls.Add(this.chkKiemTra);
            this.Controls.Add(this.chkMacDinh);
            this.Controls.Add(this.cbKieu);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.txtTenFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbDuongDan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAddFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm câu hỏi";
            this.Load += new System.EventHandler(this.fAddFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudDiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoCau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenFile;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKieu;
        private System.Windows.Forms.CheckBox chkMacDinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudDiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbLoaiKho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSoCau;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.CheckBox chkKiemTra;
        private System.Windows.Forms.Label lbDuongDan;
    }
}