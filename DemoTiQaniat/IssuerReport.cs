﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class IssuerReport : Form
    {
        public IssuerReport()
        {
            InitializeComponent();
        }

        public string id ="";
        private void print(int id)
        {
            
            this.ISSUER_DATATableAdapter.Fill(this._Egy_TaxDataSet.ISSUER_DATA,id);
            this.reportViewer1.RefreshReport();

        }
        private void IssuerReport_Load(object sender, EventArgs e)
        {
            print(int.Parse(id));
        }
    }
}
