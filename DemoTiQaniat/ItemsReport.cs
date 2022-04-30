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
    public partial class ItemsReport : Form
    {
        public ItemsReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(int id)
        {
            this.ItemSetupTableAdapter.Fill(this._Egy_TaxDataSet.ItemSetup,id);

            this.reportViewer1.RefreshReport();
        }
        private void ItemsReport_Load(object sender, EventArgs e)
        {
            print(int.Parse(id));            
        }
    }
}
