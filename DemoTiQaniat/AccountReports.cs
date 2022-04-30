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
    public partial class AccountReports : Form
    {
        public AccountReports()
        {
            InitializeComponent();
        }
        public string id = "";
        private void print(string id)
        {
            this.UserTableAdapter.Fill(this._Egy_TaxDataSet.User, id);
            this.UserRightsTableAdapter.Fill(this._Egy_TaxDataSet.UserRights, id);
            this.reportViewer1.RefreshReport();

        }

        private void AccountReports_Load(object sender, EventArgs e)
        {
            print(id);
        }
    }
}
