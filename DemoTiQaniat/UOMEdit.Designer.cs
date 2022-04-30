namespace DemoTiQaniat
{
    partial class UOMEdit
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUint = new System.Windows.Forms.TextBox();
            this.txtDescEn = new System.Windows.Forms.RichTextBox();
            this.txtDescAr = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "وحدات القياس";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "وحدة القياس الداحلية";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "وحدة قياس الضرائب";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "الوصف";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "الوصف بالعربية";
            // 
            // txtUint
            // 
            this.txtUint.Enabled = false;
            this.txtUint.Location = new System.Drawing.Point(31, 46);
            this.txtUint.Name = "txtUint";
            this.txtUint.Size = new System.Drawing.Size(176, 21);
            this.txtUint.TabIndex = 7;
            // 
            // txtDescEn
            // 
            this.txtDescEn.Location = new System.Drawing.Point(31, 121);
            this.txtDescEn.Name = "txtDescEn";
            this.txtDescEn.ReadOnly = true;
            this.txtDescEn.Size = new System.Drawing.Size(176, 62);
            this.txtDescEn.TabIndex = 9;
            this.txtDescEn.Text = "";
            // 
            // txtDescAr
            // 
            this.txtDescAr.Location = new System.Drawing.Point(31, 200);
            this.txtDescAr.Name = "txtDescAr";
            this.txtDescAr.ReadOnly = true;
            this.txtDescAr.Size = new System.Drawing.Size(176, 62);
            this.txtDescAr.TabIndex = 10;
            this.txtDescAr.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.Location = new System.Drawing.Point(188, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 38);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "تحديث";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.Location = new System.Drawing.Point(55, 279);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 38);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "2Z",
            "4K",
            "4O",
            "A87",
            "A93",
            "A94",
            "AMP",
            "ANN",
            "B22",
            "B49",
            "B75",
            "B78",
            "B84",
            "BAR",
            "BBL",
            "BG",
            "BO",
            "BOX",
            "C10",
            "C39",
            "C41",
            "C45",
            "C62",
            "CA",
            "CMK",
            "CMQ",
            "CMT",
            "CS",
            "CT",
            "CTL",
            "D10",
            "D33",
            "D41",
            "DAY",
            "DMT",
            "DRM",
            "EA",
            "FAR",
            "FOT",
            "FTK",
            "FTQ",
            "G42",
            "GL",
            "GLL",
            "GM",
            "GPT",
            "GRM",
            "H63",
            "HHP",
            "HLT",
            "HTZ",
            "HUR",
            "IE",
            "INH",
            "INK",
            "IVL",
            "JOB",
            "KGM",
            "KHZ",
            "KMH",
            "KMK",
            "KMQ",
            "KMT",
            "KSM",
            "KVT",
            "KWT",
            "LB",
            "LTR",
            "LVL",
            "M",
            "MAN",
            "MAW",
            "MGM",
            "MHZ",
            "MIN",
            "MMK",
            "MMQ",
            "MMT",
            "MON",
            "MTK",
            "MTQ",
            "OHM",
            "ONZ",
            "PAL",
            "PF",
            "PKPMP",
            "RUN",
            "SH",
            "SK",
            "SMI",
            "ST",
            "TNE",
            "TON",
            "VLT",
            "WEE",
            "WTT",
            "X03",
            "YDQ",
            "YRD"});
            this.cmbUnit.Location = new System.Drawing.Point(31, 82);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(176, 21);
            this.cmbUnit.TabIndex = 26;
            this.cmbUnit.TextChanged += new System.EventHandler(this.cmbUnit_TextChanged);
            // 
            // UOMEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 325);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescAr);
            this.Controls.Add(this.txtDescEn);
            this.Controls.Add(this.txtUint);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UOMEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.TextBox txtUint;
        public System.Windows.Forms.RichTextBox txtDescEn;
        public System.Windows.Forms.RichTextBox txtDescAr;
        public System.Windows.Forms.ComboBox cmbUnit;
    }
}