namespace DemoTiQaniat
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPostal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtland = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.cmbGovernate = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(147, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "بيانات العميل";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(306, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "كود العميل";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(44, 90);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(192, 23);
            this.txtCode.TabIndex = 2;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(45, 160);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(191, 23);
            this.txtID.TabIndex = 4;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "نوع العميل";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "اسم العميل";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 192);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(191, 23);
            this.txtName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "الرقم (الضريبى/ القومى)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "كود الدولة";
            // 
            // txtCountry
            // 
            this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCountry.Location = new System.Drawing.Point(45, 225);
            this.txtCountry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(191, 23);
            this.txtCountry.TabIndex = 12;
            this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(305, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "المحافظة";
            // 
            // txtRegion
            // 
            this.txtRegion.Location = new System.Drawing.Point(45, 295);
            this.txtRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(191, 23);
            this.txtRegion.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(305, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "المدينة";
            // 
            // txtStreet
            // 
            this.txtStreet.Location = new System.Drawing.Point(45, 330);
            this.txtStreet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(191, 23);
            this.txtStreet.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "الشارع";
            // 
            // txtBuild
            // 
            this.txtBuild.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtBuild.Location = new System.Drawing.Point(45, 361);
            this.txtBuild.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Size = new System.Drawing.Size(191, 23);
            this.txtBuild.TabIndex = 18;
            this.txtBuild.WordWrap = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 364);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "رقم المبنى";
            // 
            // txtPostal
            // 
            this.txtPostal.Location = new System.Drawing.Point(10, 24);
            this.txtPostal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPostal.Name = "txtPostal";
            this.txtPostal.Size = new System.Drawing.Size(191, 23);
            this.txtPostal.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(271, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "الرقم البريدي";
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(10, 59);
            this.txtFloor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.Size = new System.Drawing.Size(191, 23);
            this.txtFloor.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(271, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "الدور";
            // 
            // txtRoom
            // 
            this.txtRoom.Location = new System.Drawing.Point(10, 94);
            this.txtRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(191, 23);
            this.txtRoom.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "الغرفة";
            // 
            // txtland
            // 
            this.txtland.Location = new System.Drawing.Point(10, 126);
            this.txtland.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtland.Name = "txtland";
            this.txtland.Size = new System.Drawing.Size(191, 23);
            this.txtland.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(270, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "علامة مميزة";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(10, 158);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(191, 23);
            this.txtInfo.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(271, 161);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 27;
            this.label15.Text = "معلومات اضافية";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(302, 598);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(121, 52);
            this.btnSubmit.TabIndex = 29;
            this.btnSubmit.Text = "حفظ";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRoom);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPostal);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtFloor);
            this.groupBox1.Controls.Add(this.txtland);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox1.Location = new System.Drawing.Point(35, 390);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(402, 200);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات اختيارية";
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Business",
            "Person",
            "Foreign"});
            this.cmbtype.Location = new System.Drawing.Point(45, 123);
            this.cmbtype.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(191, 24);
            this.cmbtype.TabIndex = 33;
            // 
            // cmbGovernate
            // 
            this.cmbGovernate.FormattingEnabled = true;
            this.cmbGovernate.Location = new System.Drawing.Point(45, 257);
            this.cmbGovernate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbGovernate.Name = "cmbGovernate";
            this.cmbGovernate.Size = new System.Drawing.Size(191, 24);
            this.cmbGovernate.TabIndex = 34;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnClear.Location = new System.Drawing.Point(166, 598);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(121, 52);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "مسح الكل";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnExit.Location = new System.Drawing.Point(26, 598);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 52);
            this.btnExit.TabIndex = 36;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 661);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbGovernate);
            this.Controls.Add(this.cmbtype);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtBuild);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRegion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCountry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tiQaniat Solutions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBuild;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPostal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtland;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.ComboBox cmbGovernate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
    }
}

