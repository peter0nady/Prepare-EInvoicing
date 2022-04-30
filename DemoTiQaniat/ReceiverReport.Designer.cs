namespace DemoTiQaniat
{
    partial class ReceiverReport
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
            this.RecieverBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecieverTableAdapter = new DemoTiQaniat._Egy_TaxDataSetTableAdapters.RecieverTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecieverBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.RecieverBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "DemoTiQaniat.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1251, 495);
            this.reportViewer1.TabIndex = 0;
            // 
            // _Egy_TaxDataSet
            // 
            this._Egy_TaxDataSet.DataSetName = "_Egy_TaxDataSet";
            this._Egy_TaxDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RecieverBindingSource
            // 
            this.RecieverBindingSource.DataMember = "Reciever";
            this.RecieverBindingSource.DataSource = this._Egy_TaxDataSet;
            // 
            // RecieverTableAdapter
            // 
            this.RecieverTableAdapter.ClearBeforeFill = true;
            // 
            // ReceiverReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 495);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiverReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReceiverReport";
            this.Load += new System.EventHandler(this.ReceiverReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this._Egy_TaxDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecieverBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;

        private System.Windows.Forms.BindingSource RecieverBindingSource;
        private _Egy_TaxDataSet _Egy_TaxDataSet;
        private _Egy_TaxDataSetTableAdapters.RecieverTableAdapter RecieverTableAdapter;
    }
}