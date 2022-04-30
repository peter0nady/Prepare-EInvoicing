namespace DemoTiQaniat
{
    partial class InvoiceReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.EINVOICES_HEADERS_TEMP_SETUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Egy_TaxDataSet = new DemoTiQaniat._Egy_TaxDataSet();
            this.EINVOICES_LINES_TEMP_SETUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TAX_HEADERS_TEMP_SETUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TAX_LINES_TEMP_SETUPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EINVOICES_HEADERS_TEMP_SETUPTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.EINVOICES_HEADERS_TEMP_SETUPTableAdapter();
            this.EINVOICES_LINES_TEMP_SETUPTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.EINVOICES_LINES_TEMP_SETUPTableAdapter();
            this.TAX_HEADERS_TEMP_SETUPTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.TAX_HEADERS_TEMP_SETUPTableAdapter();
            this.TAX_LINES_TEMP_SETUPTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.TAX_LINES_TEMP_SETUPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EINVOICES_HEADERS_TEMP_SETUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EINVOICES_LINES_TEMP_SETUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAX_HEADERS_TEMP_SETUPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAX_LINES_TEMP_SETUPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.EINVOICES_HEADERS_TEMP_SETUPBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.EINVOICES_LINES_TEMP_SETUPBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.TAX_HEADERS_TEMP_SETUPBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.TAX_LINES_TEMP_SETUPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report7.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-3, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1245, 446);
            this.reportViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1181, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "الوصف";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1070, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "عرض التقرير";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // EINVOICES_HEADERS_TEMP_SETUPBindingSource
            // 
            this.EINVOICES_HEADERS_TEMP_SETUPBindingSource.DataMember = "EINVOICES_HEADERS_TEMP_SETUP";
            this.EINVOICES_HEADERS_TEMP_SETUPBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EINVOICES_LINES_TEMP_SETUPBindingSource
            // 
            this.EINVOICES_LINES_TEMP_SETUPBindingSource.DataMember = "EINVOICES_LINES_TEMP_SETUP";
            this.EINVOICES_LINES_TEMP_SETUPBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // TAX_HEADERS_TEMP_SETUPBindingSource
            // 
            this.TAX_HEADERS_TEMP_SETUPBindingSource.DataMember = "TAX_HEADERS_TEMP_SETUP";
            this.TAX_HEADERS_TEMP_SETUPBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // TAX_LINES_TEMP_SETUPBindingSource
            // 
            this.TAX_LINES_TEMP_SETUPBindingSource.DataMember = "TAX_LINES_TEMP_SETUP";
            this.TAX_LINES_TEMP_SETUPBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // EINVOICES_HEADERS_TEMP_SETUPTableAdapter
            // 
            this.EINVOICES_HEADERS_TEMP_SETUPTableAdapter.ClearBeforeFill = true;
            // 
            // EINVOICES_LINES_TEMP_SETUPTableAdapter
            // 
            this.EINVOICES_LINES_TEMP_SETUPTableAdapter.ClearBeforeFill = true;
            // 
            // TAX_HEADERS_TEMP_SETUPTableAdapter
            // 
            this.TAX_HEADERS_TEMP_SETUPTableAdapter.ClearBeforeFill = true;
            // 
            // TAX_LINES_TEMP_SETUPTableAdapter
            // 
            this.TAX_LINES_TEMP_SETUPTableAdapter.ClearBeforeFill = true;
            // 
            // InvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 493);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvoiceReport";
            ((System.ComponentModel.ISupportInitialize)(this.EINVOICES_HEADERS_TEMP_SETUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EINVOICES_LINES_TEMP_SETUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAX_HEADERS_TEMP_SETUPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TAX_LINES_TEMP_SETUPBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        private System.Windows.Forms.BindingSource EINVOICES_HEADERS_TEMP_SETUPBindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private System.Windows.Forms.BindingSource EINVOICES_LINES_TEMP_SETUPBindingSource;
        private System.Windows.Forms.BindingSource TAX_HEADERS_TEMP_SETUPBindingSource;
        private System.Windows.Forms.BindingSource TAX_LINES_TEMP_SETUPBindingSource;
        private _Egy_TaxDataSetTableAdapters.EINVOICES_HEADERS_TEMP_SETUPTableAdapter EINVOICES_HEADERS_TEMP_SETUPTableAdapter;
        private _Egy_TaxDataSetTableAdapters.EINVOICES_LINES_TEMP_SETUPTableAdapter EINVOICES_LINES_TEMP_SETUPTableAdapter;
        private _Egy_TaxDataSetTableAdapters.TAX_HEADERS_TEMP_SETUPTableAdapter TAX_HEADERS_TEMP_SETUPTableAdapter;
        private _Egy_TaxDataSetTableAdapters.TAX_LINES_TEMP_SETUPTableAdapter TAX_LINES_TEMP_SETUPTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}