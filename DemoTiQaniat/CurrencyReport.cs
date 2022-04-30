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
    public partial class CurrencyReport : Form
    {
        public CurrencyReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(int id)
        {
            this.CurrencyTableAdapter.Fill(this._Egy_TaxDataSet.Currency,id);

            this.reportViewer1.RefreshReport();
        
        }
        private void CurrencyReport_Load(object sender, EventArgs e)
        {
            print(int.Parse(id));
        }       
    }
}
