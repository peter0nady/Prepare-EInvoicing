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
    public partial class ReceiverReport : Form
    {
        public ReceiverReport()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(string id)
        {
            this.RecieverTableAdapter.Fill(this._Egy_TaxDataSet.Reciever,id);
            this.reportViewer1.RefreshReport();
        }
        private void ReceiverReport_Load(object sender, EventArgs e)
        {
            print(id);
        }
    }
}
