namespace DemoTiQaniat
{
    partial class UOMReport
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
            this.UOMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UOMTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.UOMTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.UOMBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1241, 487);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UOMBindingSource
            // 
            this.UOMBindingSource.DataMember = "UOM";
            this.UOMBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // UOMTableAdapter
            // 
            this.UOMTableAdapter.ClearBeforeFill = true;
            // 
            // UOMReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 487);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UOMReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UOMReport";
            this.Load += new System.EventHandler(this.UOMReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOMBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       // private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        private System.Windows.Forms.BindingSource UOMBindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private _Egy_TaxDataSetTableAdapters.UOMTableAdapter UOMTableAdapter;
    }
}