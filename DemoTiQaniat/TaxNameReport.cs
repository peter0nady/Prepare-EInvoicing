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
    public partial class TaxNameReport : Form
    {
        public TaxNameReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print (int id )
        {
            this.Tax_NameTableAdapter.Fill(this._Egy_TaxDataSet.Tax_Name,id);

            this.reportViewer1.RefreshReport();
        }
        private void TaxNameReport_Load(object sender, EventArgs e)
        {
            print(int.Parse(id));
        }
    }
}
