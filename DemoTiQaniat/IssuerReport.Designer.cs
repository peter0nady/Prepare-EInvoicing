namespace DemoTiQaniat
{
    partial class IssuerReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Egy_TaxDataSet1 = new DemoTiQaniat._Egy_TaxDataSet();
            this._Egy_TaxDataSet = new DemoTiQaniat._Egy_TaxDataSet();
            this.ISSUER_DATABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ISSUER_DATATableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.ISSUER_DATATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISSUER_DATABindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ISSUER_DATABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1045, 499);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Egy_TaxDataSet1
            // 
            this._Egy_TaxDataSet1.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ISSUER_DATABindingSource
            // 
            this.ISSUER_DATABindingSource.DataMember = "ISSUER_DATA";
            this.ISSUER_DATABindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // ISSUER_DATATableAdapter
            // 
            this.ISSUER_DATATableAdapter.ClearBeforeFill = true;
            // 
            // IssuerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 499);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IssuerReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IssuerReport";
            this.Load += new System.EventHandler(this.IssuerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ISSUER_DATABindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        //public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public _Egy_TaxDataSet _Egy_TaxDataSet1;
        private System.Windows.Forms.BindingSource ISSUER_DATABindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private _Egy_TaxDataSetTableAdapters.ISSUER_DATATableAdapter ISSUER_DATATableAdapter;
    }
}