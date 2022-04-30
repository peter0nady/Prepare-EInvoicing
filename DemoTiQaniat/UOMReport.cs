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
    public partial class UOMReport : Form
    {
        public UOMReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(int id)
        {
            this.UOMTableAdapter.Fill(this._Egy_TaxDataSet.UOM,id);

            this.reportViewer1.RefreshReport();
        }
        private void UOMReport_Load(object sender, EventArgs e)
        {
            print(int.Parse(id));  
        }
    }
}
