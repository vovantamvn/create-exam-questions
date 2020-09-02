namespace ViDu1
{
    partial class fThread
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
            this.s1 = new System.Windows.Forms.Button();
            this.t1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // s1
            // 
            this.s1.Location = new System.Drawing.Point(240, 146);
            this.s1.Name = "s1";
            this.s1.Size = new System.Drawing.Size(116, 35);
            this.s1.TabIndex = 0;
            this.s1.Text = "button1";
            this.s1.UseVisualStyleBackColor = true;
            this.s1.Click += new System.EventHandler(this.s1_Click);
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(187, 61);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(293, 20);
            this.t1.TabIndex = 1;
            // 
            // fThread
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 238);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.s1);
            this.Name = "fThread";
            this.Text = "fThread";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button s1;
        private System.Windows.Forms.TextBox t1;
    }
}