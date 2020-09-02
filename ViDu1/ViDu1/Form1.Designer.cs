namespace ViDu1
{
    partial class Form1
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
            this.txtDeThiMau = new System.Windows.Forms.TextBox();
            this.btnMoDeMau = new System.Windows.Forms.Button();
            this.btnTaoDeThi = new System.Windows.Forms.Button();
            this.grpThongSo = new System.Windows.Forms.GroupBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dtpNgayThi = new System.Windows.Forms.DateTimePicker();
            this.btnChonNhom3 = new System.Windows.Forms.Button();
            this.btnChonNhom2 = new System.Windows.Forms.Button();
            this.btnChonNhom1 = new System.Windows.Forms.Button();
            this.txtSoDe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtThoiGian = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHinhThucThi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDoiTuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHocPhan = new System.Windows.Forms.TextBox();
            this.txtDeNhom3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeNhom2 = new System.Windows.Forms.TextBox();
            this.txtHocKy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeNhom1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.grpThongSo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mẫu đề thi:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeThiMau
            // 
            this.txtDeThiMau.Location = new System.Drawing.Point(167, 15);
            this.txtDeThiMau.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeThiMau.Name = "txtDeThiMau";
            this.txtDeThiMau.ReadOnly = true;
            this.txtDeThiMau.Size = new System.Drawing.Size(367, 29);
            this.txtDeThiMau.TabIndex = 0;
            // 
            // btnMoDeMau
            // 
            this.btnMoDeMau.Location = new System.Drawing.Point(541, 14);
            this.btnMoDeMau.Margin = new System.Windows.Forms.Padding(6);
            this.btnMoDeMau.Name = "btnMoDeMau";
            this.btnMoDeMau.Size = new System.Drawing.Size(142, 30);
            this.btnMoDeMau.TabIndex = 1;
            this.btnMoDeMau.Text = "Mở";
            this.btnMoDeMau.UseVisualStyleBackColor = true;
            this.btnMoDeMau.Click += new System.EventHandler(this.btnMoDeMau_Click);
            // 
            // btnTaoDeThi
            // 
            this.btnTaoDeThi.Location = new System.Drawing.Point(283, 449);
            this.btnTaoDeThi.Margin = new System.Windows.Forms.Padding(6);
            this.btnTaoDeThi.Name = "btnTaoDeThi";
            this.btnTaoDeThi.Size = new System.Drawing.Size(127, 41);
            this.btnTaoDeThi.TabIndex = 15;
            this.btnTaoDeThi.Text = "Tạo Đề Thi";
            this.btnTaoDeThi.UseVisualStyleBackColor = true;
            this.btnTaoDeThi.Click += new System.EventHandler(this.btnTaoDeThi_Click);
            // 
            // grpThongSo
            // 
            this.grpThongSo.Controls.Add(this.lbl1);
            this.grpThongSo.Controls.Add(this.progressBar1);
            this.grpThongSo.Controls.Add(this.dtpNgayThi);
            this.grpThongSo.Controls.Add(this.btnChonNhom3);
            this.grpThongSo.Controls.Add(this.btnChonNhom2);
            this.grpThongSo.Controls.Add(this.btnChonNhom1);
            this.grpThongSo.Controls.Add(this.txtSoDe);
            this.grpThongSo.Controls.Add(this.label11);
            this.grpThongSo.Controls.Add(this.label7);
            this.grpThongSo.Controls.Add(this.txtThoiGian);
            this.grpThongSo.Controls.Add(this.label6);
            this.grpThongSo.Controls.Add(this.txtHinhThucThi);
            this.grpThongSo.Controls.Add(this.label5);
            this.grpThongSo.Controls.Add(this.txtDoiTuong);
            this.grpThongSo.Controls.Add(this.label4);
            this.grpThongSo.Controls.Add(this.txtHocPhan);
            this.grpThongSo.Controls.Add(this.txtDeNhom3);
            this.grpThongSo.Controls.Add(this.label3);
            this.grpThongSo.Controls.Add(this.txtDeNhom2);
            this.grpThongSo.Controls.Add(this.txtHocKy);
            this.grpThongSo.Controls.Add(this.label10);
            this.grpThongSo.Controls.Add(this.txtDeNhom1);
            this.grpThongSo.Controls.Add(this.label9);
            this.grpThongSo.Controls.Add(this.label2);
            this.grpThongSo.Controls.Add(this.label8);
            this.grpThongSo.Location = new System.Drawing.Point(12, 53);
            this.grpThongSo.Name = "grpThongSo";
            this.grpThongSo.Size = new System.Drawing.Size(682, 385);
            this.grpThongSo.TabIndex = 16;
            this.grpThongSo.TabStop = false;
            this.grpThongSo.Text = "Thông số tạo đề thi";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(467, 219);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(70, 24);
            this.lbl1.TabIndex = 39;
            this.lbl1.Text = "label12";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(350, 193);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(313, 23);
            this.progressBar1.TabIndex = 18;
            // 
            // dtpNgayThi
            // 
            this.dtpNgayThi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThi.Location = new System.Drawing.Point(185, 192);
            this.dtpNgayThi.Name = "dtpNgayThi";
            this.dtpNgayThi.Size = new System.Drawing.Size(141, 29);
            this.dtpNgayThi.TabIndex = 38;
            // 
            // btnChonNhom3
            // 
            this.btnChonNhom3.Location = new System.Drawing.Point(526, 353);
            this.btnChonNhom3.Margin = new System.Windows.Forms.Padding(6);
            this.btnChonNhom3.Name = "btnChonNhom3";
            this.btnChonNhom3.Size = new System.Drawing.Size(137, 30);
            this.btnChonNhom3.TabIndex = 37;
            this.btnChonNhom3.Text = "Chọn nhóm 3";
            this.btnChonNhom3.UseVisualStyleBackColor = true;
            this.btnChonNhom3.Click += new System.EventHandler(this.btnChonNhom3_Click);
            // 
            // btnChonNhom2
            // 
            this.btnChonNhom2.Location = new System.Drawing.Point(526, 310);
            this.btnChonNhom2.Margin = new System.Windows.Forms.Padding(6);
            this.btnChonNhom2.Name = "btnChonNhom2";
            this.btnChonNhom2.Size = new System.Drawing.Size(137, 30);
            this.btnChonNhom2.TabIndex = 35;
            this.btnChonNhom2.Text = "Chọn nhóm 2";
            this.btnChonNhom2.UseVisualStyleBackColor = true;
            this.btnChonNhom2.Click += new System.EventHandler(this.btnChonNhom2_Click);
            // 
            // btnChonNhom1
            // 
            this.btnChonNhom1.Location = new System.Drawing.Point(526, 271);
            this.btnChonNhom1.Margin = new System.Windows.Forms.Padding(6);
            this.btnChonNhom1.Name = "btnChonNhom1";
            this.btnChonNhom1.Size = new System.Drawing.Size(137, 30);
            this.btnChonNhom1.TabIndex = 33;
            this.btnChonNhom1.Text = "Chọn nhóm 1";
            this.btnChonNhom1.UseVisualStyleBackColor = true;
            this.btnChonNhom1.Click += new System.EventHandler(this.btnChonNhom1_Click);
            // 
            // txtSoDe
            // 
            this.txtSoDe.Location = new System.Drawing.Point(185, 228);
            this.txtSoDe.Margin = new System.Windows.Forms.Padding(6);
            this.txtSoDe.Name = "txtSoDe";
            this.txtSoDe.Size = new System.Drawing.Size(141, 29);
            this.txtSoDe.TabIndex = 31;
            this.txtSoDe.Text = "3";
            // 
            // label11
            // 
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(-6, 233);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 24);
            this.label11.TabIndex = 18;
            this.label11.Text = "Số đề thi muốn tạo:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Location = new System.Drawing.Point(-6, 192);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 24);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ngày thi:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThoiGian
            // 
            this.txtThoiGian.Location = new System.Drawing.Point(516, 148);
            this.txtThoiGian.Margin = new System.Windows.Forms.Padding(6);
            this.txtThoiGian.Name = "txtThoiGian";
            this.txtThoiGian.Size = new System.Drawing.Size(137, 29);
            this.txtThoiGian.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(335, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Thời gian làm bài:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHinhThucThi
            // 
            this.txtHinhThucThi.Location = new System.Drawing.Point(185, 146);
            this.txtHinhThucThi.Margin = new System.Windows.Forms.Padding(6);
            this.txtHinhThucThi.Name = "txtHinhThucThi";
            this.txtHinhThucThi.Size = new System.Drawing.Size(141, 29);
            this.txtHinhThucThi.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(-6, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 24);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hình thức thi:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDoiTuong
            // 
            this.txtDoiTuong.Location = new System.Drawing.Point(185, 105);
            this.txtDoiTuong.Margin = new System.Windows.Forms.Padding(6);
            this.txtDoiTuong.Name = "txtDoiTuong";
            this.txtDoiTuong.Size = new System.Drawing.Size(329, 29);
            this.txtDoiTuong.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(-6, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 24);
            this.label4.TabIndex = 22;
            this.label4.Text = "Đối tượng:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHocPhan
            // 
            this.txtHocPhan.Location = new System.Drawing.Point(185, 64);
            this.txtHocPhan.Margin = new System.Windows.Forms.Padding(6);
            this.txtHocPhan.Name = "txtHocPhan";
            this.txtHocPhan.Size = new System.Drawing.Size(329, 29);
            this.txtHocPhan.TabIndex = 26;
            // 
            // txtDeNhom3
            // 
            this.txtDeNhom3.Location = new System.Drawing.Point(185, 351);
            this.txtDeNhom3.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeNhom3.Name = "txtDeNhom3";
            this.txtDeNhom3.ReadOnly = true;
            this.txtDeNhom3.Size = new System.Drawing.Size(329, 29);
            this.txtDeNhom3.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(-6, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Học phần:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeNhom2
            // 
            this.txtDeNhom2.Location = new System.Drawing.Point(185, 310);
            this.txtDeNhom2.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeNhom2.Name = "txtDeNhom2";
            this.txtDeNhom2.ReadOnly = true;
            this.txtDeNhom2.Size = new System.Drawing.Size(329, 29);
            this.txtDeNhom2.TabIndex = 34;
            // 
            // txtHocKy
            // 
            this.txtHocKy.Location = new System.Drawing.Point(185, 23);
            this.txtHocKy.Margin = new System.Windows.Forms.Padding(6);
            this.txtHocKy.Name = "txtHocKy";
            this.txtHocKy.Size = new System.Drawing.Size(329, 29);
            this.txtHocKy.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(-6, 356);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 24);
            this.label10.TabIndex = 17;
            this.label10.Text = "Câu hỏi nhóm 3:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeNhom1
            // 
            this.txtDeNhom1.Location = new System.Drawing.Point(185, 269);
            this.txtDeNhom1.Margin = new System.Windows.Forms.Padding(6);
            this.txtDeNhom1.Name = "txtDeNhom1";
            this.txtDeNhom1.ReadOnly = true;
            this.txtDeNhom1.Size = new System.Drawing.Size(329, 29);
            this.txtDeNhom1.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(-6, 315);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 24);
            this.label9.TabIndex = 16;
            this.label9.Text = "Câu hỏi nhóm 2:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(-6, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Học kỳ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(-6, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Câu hỏi nhóm 1:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(422, 449);
            this.btnTest.Margin = new System.Windows.Forms.Padding(6);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(127, 41);
            this.btnTest.TabIndex = 15;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 33);
            this.button1.TabIndex = 17;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 514);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grpThongSo);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTaoDeThi);
            this.Controls.Add(this.btnMoDeMau);
            this.Controls.Add(this.txtDeThiMau);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.grpThongSo.ResumeLayout(false);
            this.grpThongSo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeThiMau;
        private System.Windows.Forms.Button btnMoDeMau;
        private System.Windows.Forms.Button btnTaoDeThi;
        private System.Windows.Forms.GroupBox grpThongSo;
        private System.Windows.Forms.Button btnChonNhom3;
        private System.Windows.Forms.Button btnChonNhom2;
        private System.Windows.Forms.Button btnChonNhom1;
        private System.Windows.Forms.TextBox txtSoDe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtThoiGian;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHinhThucThi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDoiTuong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHocPhan;
        private System.Windows.Forms.TextBox txtDeNhom3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeNhom2;
        private System.Windows.Forms.TextBox txtHocKy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDeNhom1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DateTimePicker dtpNgayThi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Label lbl1;
    }
}

