namespace DemoTiQaniat
{
    partial class AccountAndPermissionEdit
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
            this.txtloginID = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.dtExpirey = new System.Windows.Forms.DateTimePicker();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعديل  صلاحيات المستخدم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(225, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "اسم دخول المستخدم";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(225, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "الرقم السرى";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(219, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "تاريخ انتهاء صلاحية المستخدم";
            // 
            // txtloginID
            // 
            this.txtloginID.Location = new System.Drawing.Point(23, 73);
            this.txtloginID.Name = "txtloginID";
            this.txtloginID.ReadOnly = true;
            this.txtloginID.Size = new System.Drawing.Size(170, 20);
            this.txtloginID.TabIndex = 6;
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(23, 138);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(170, 20);
            this.txtpassword.TabIndex = 7;
            // 
            // dtExpirey
            // 
            this.dtExpirey.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpirey.Location = new System.Drawing.Point(23, 174);
            this.dtExpirey.Name = "dtExpirey";
            this.dtExpirey.Size = new System.Drawing.Size(170, 20);
            this.dtExpirey.TabIndex = 8;
            this.dtExpirey.ValueChanged += new System.EventHandler(this.dtExpirey_ValueChanged);
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkActive.Location = new System.Drawing.Point(23, 211);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(50, 23);
            this.checkActive.TabIndex = 9;
            this.checkActive.Text = "نشط";
            this.checkActive.UseVisualStyleBackColor = true;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.description,
            this.Column1});
            this.dgv.Location = new System.Drawing.Point(23, 240);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(348, 211);
            this.dgv.TabIndex = 10;
            // 
            // code
            // 
            this.code.HeaderText = "code";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.code.Visible = false;
            // 
            // description
            // 
            this.description.DataPropertyName = "ArabicDescription";
            this.description.HeaderText = "الوصف";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.description.Width = 200;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "اختيار الصلاحية";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "true";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(244, 462);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(127, 43);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "تحديث";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnexit
            // 
            this.btnexit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.Location = new System.Drawing.Point(23, 462);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(90, 43);
            this.btnexit.TabIndex = 12;
            this.btnexit.Text = "خروج";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(23, 106);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(170, 20);
            this.txtname.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(225, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "اسم المستخدم";
            // 
            // AccountAndPermissionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 507);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.dtExpirey);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtloginID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountAndPermissionEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountAndPermission";
            this.Load += new System.EventHandler(this.AccountAndPermission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.DateTimePicker dtExpirey;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtname;
        public System.Windows.Forms.TextBox txtloginID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
    }
}