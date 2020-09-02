namespace ViDu1
{
    partial class fProcessTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fProcessTest));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.bgWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbThongTin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(0, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(545, 25);
            this.progressBar1.TabIndex = 1;
            // 
            // bgWorker1
            // 
            this.bgWorker1.WorkerReportsProgress = true;
            this.bgWorker1.WorkerSupportsCancellation = true;
            this.bgWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker1_DoWork);
            this.bgWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker1_ProgressChanged);
            this.bgWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker1_RunWorkerCompleted);
            // 
            // lbThongTin
            // 
            this.lbThongTin.AutoSize = true;
            this.lbThongTin.Location = new System.Drawing.Point(48, -1);
            this.lbThongTin.Name = "lbThongTin";
            this.lbThongTin.Size = new System.Drawing.Size(87, 20);
            this.lbThongTin.TabIndex = 2;
            this.lbThongTin.Text = "lbThongTin";
            // 
            // fProcessTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(545, 47);
            this.Controls.Add(this.lbThongTin);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fProcessTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đang chờ...";
            this.Load += new System.EventHandler(this.fProcessTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bgWorker1;
        private System.Windows.Forms.Label lbThongTin;
    }
}