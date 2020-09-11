namespace ViDu1
{
    partial class QuestionForm
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
            this.lbDetail = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSubject = new System.Windows.Forms.ComboBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumberOfExam = new System.Windows.Forms.NumericUpDown();
            this.txtNumberOfQuestion = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDetail
            // 
            this.lbDetail.AutoSize = true;
            this.lbDetail.Location = new System.Drawing.Point(12, 102);
            this.lbDetail.Name = "lbDetail";
            this.lbDetail.Size = new System.Drawing.Size(70, 13);
            this.lbDetail.TabIndex = 14;
            this.lbDetail.Text = "Số câu hỏi: 0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Môn học";
            // 
            // cbSubject
            // 
            this.cbSubject.FormattingEnabled = true;
            this.cbSubject.Location = new System.Drawing.Point(147, 6);
            this.cbSubject.Name = "cbSubject";
            this.cbSubject.Size = new System.Drawing.Size(307, 21);
            this.cbSubject.TabIndex = 16;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(713, 144);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 17;
            this.btnFinish.Text = "Tạo đề";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Số đề:";
            // 
            // txtNumberOfExam
            // 
            this.txtNumberOfExam.Location = new System.Drawing.Point(147, 121);
            this.txtNumberOfExam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfExam.Name = "txtNumberOfExam";
            this.txtNumberOfExam.Size = new System.Drawing.Size(120, 20);
            this.txtNumberOfExam.TabIndex = 19;
            this.txtNumberOfExam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNumberOfQuestion
            // 
            this.txtNumberOfQuestion.Location = new System.Drawing.Point(147, 152);
            this.txtNumberOfQuestion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumberOfQuestion.Name = "txtNumberOfQuestion";
            this.txtNumberOfQuestion.Size = new System.Drawing.Size(120, 20);
            this.txtNumberOfQuestion.TabIndex = 21;
            this.txtNumberOfQuestion.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Số câu của đề:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Đọc file trắc nghiệm";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(147, 33);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 23;
            this.btnChooseFile.Text = "Chọn file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumberOfQuestion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNumberOfExam);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.cbSubject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbDetail);
            this.Name = "QuestionForm";
            this.Text = "QuestionForm";
            this.Load += new System.EventHandler(this.QuestionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSubject;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtNumberOfExam;
        private System.Windows.Forms.NumericUpDown txtNumberOfQuestion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChooseFile;
    }
}