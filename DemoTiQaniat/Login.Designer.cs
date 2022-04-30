namespace DemoTiQaniat
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNewps = new System.Windows.Forms.TextBox();
            this.lblnew = new System.Windows.Forms.Label();
            this.txtconfirmps = new System.Windows.Forms.TextBox();
            this.lblconfirm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(345, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المستخدم ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "كلمة السر";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(176, 127);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(150, 20);
            this.txtID.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(176, 170);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(150, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(19, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = " \"Tab\"  اضغط";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtNewps
            // 
            this.txtNewps.Location = new System.Drawing.Point(176, 221);
            this.txtNewps.Name = "txtNewps";
            this.txtNewps.PasswordChar = '*';
            this.txtNewps.Size = new System.Drawing.Size(150, 20);
            this.txtNewps.TabIndex = 8;
            // 
            // lblnew
            // 
            this.lblnew.AutoSize = true;
            this.lblnew.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnew.Location = new System.Drawing.Point(345, 223);
            this.lblnew.Name = "lblnew";
            this.lblnew.Size = new System.Drawing.Size(80, 15);
            this.lblnew.TabIndex = 7;
            this.lblnew.Text = "كلمة السر الجديدة";
            // 
            // txtconfirmps
            // 
            this.txtconfirmps.Location = new System.Drawing.Point(176, 256);
            this.txtconfirmps.Name = "txtconfirmps";
            this.txtconfirmps.PasswordChar = '*';
            this.txtconfirmps.Size = new System.Drawing.Size(150, 20);
            this.txtconfirmps.TabIndex = 10;
            this.txtconfirmps.Leave += new System.EventHandler(this.txtconfirmps_Leave);
            // 
            // lblconfirm
            // 
            this.lblconfirm.AutoSize = true;
            this.lblconfirm.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfirm.Location = new System.Drawing.Point(345, 258);
            this.lblconfirm.Name = "lblconfirm";
            this.lblconfirm.Size = new System.Drawing.Size(71, 15);
            this.lblconfirm.TabIndex = 9;
            this.lblconfirm.Text = "تاكيد كلمة السر";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(562, 287);
            this.Controls.Add(this.txtconfirmps);
            this.Controls.Add(this.lblconfirm);
            this.Controls.Add(this.txtNewps);
            this.Controls.Add(this.lblnew);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNewps;
        private System.Windows.Forms.Label lblnew;
        private System.Windows.Forms.Label lblconfirm;
        private System.Windows.Forms.TextBox txtconfirmps;
        private System.Windows.Forms.TextBox txtPass;
    }
}