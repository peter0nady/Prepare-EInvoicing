namespace DemoTiQaniat
{
    partial class TaxNameReport
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
            this._Egy_TaxDataSet = new DemoTiQaniat._Egy_TaxDataSet();
            this.Tax_NameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Tax_NameTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.Tax_NameTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax_NameBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Tax_NameBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report6.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1239, 494);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Tax_NameBindingSource
            // 
            this.Tax_NameBindingSource.DataMember = "Tax_Name";
            this.Tax_NameBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // Tax_NameTableAdapter
            // 
            this.Tax_NameTableAdapter.ClearBeforeFill = true;
            // 
            // TaxNameReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 494);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaxNameReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaxNameReport";
            this.Load += new System.EventHandler(this.TaxNameReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tax_NameBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       // private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        private System.Windows.Forms.BindingSource Tax_NameBindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private _Egy_TaxDataSetTableAdapters.Tax_NameTableAdapter Tax_NameTableAdapter;
    }
}