namespace DemoTiQaniat
{
    partial class AccountReports
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._Egy_TaxDataSet = new DemoTiQaniat._Egy_TaxDataSet();
            this.UserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.UserTableAdapter();
            this.UserRightsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserRightsTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.UserRightsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRightsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.UserBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.UserRightsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report8.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1237, 491);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UserBindingSource
            // 
            this.UserBindingSource.DataMember = "User";
            this.UserBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // UserTableAdapter
            // 
            this.UserTableAdapter.ClearBeforeFill = true;
            // 
            // UserRightsBindingSource
            // 
            this.UserRightsBindingSource.DataMember = "UserRights";
            this.UserRightsBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // UserRightsTableAdapter
            // 
            this.UserRightsTableAdapter.ClearBeforeFill = true;
            // 
            // AccountReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 491);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountReports";
            this.Load += new System.EventHandler(this.AccountReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserRightsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        private System.Windows.Forms.BindingSource UserBindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private System.Windows.Forms.BindingSource UserRightsBindingSource;
        private _Egy_TaxDataSetTableAdapters.UserTableAdapter UserTableAdapter;
        private _Egy_TaxDataSetTableAdapters.UserRightsTableAdapter UserRightsTableAdapter;
    }
}