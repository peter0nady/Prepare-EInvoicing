using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class InvoiceReport : Form
    {
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(string id)
        {
            this.EINVOICES_HEADERS_TEMP_SETUPTableAdapter.Fill(this._Egy_TaxDataSet.EINVOICES_HEADERS_TEMP_SETUP,id);
            this.EINVOICES_LINES_TEMP_SETUPTableAdapter.Fill(this._Egy_TaxDataSet.EINVOICES_LINES_TEMP_SETUP, id, textBox1.Text);
            this.TAX_HEADERS_TEMP_SETUPTableAdapter.Fill(this._Egy_TaxDataSet.TAX_HEADERS_TEMP_SETUP,id);
            this.TAX_LINES_TEMP_SETUPTableAdapter.Fill(this._Egy_TaxDataSet.TAX_LINES_TEMP_SETUP,id);

            this.reportViewer1.RefreshReport();
        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            print(id);
        }
    }
}
