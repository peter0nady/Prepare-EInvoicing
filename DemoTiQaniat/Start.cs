using System;
using System.Windows.Forms;
using System.Drawing;
namespace DemoTiQaniat
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void btnReciever_Click(object sender, EventArgs e)
        {
            First f = new First();
            f.Show();
        }

        private void btnIssuer_Click(object sender, EventArgs e)
        {
            IssuerDataFrom i = new IssuerDataFrom();
            i.Show();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            CurrencyDataFrom c = new CurrencyDataFrom();
            c.Show();
        }

        private void btnUnit_Click(object sender, EventArgs e)
        {
            UOMDataForm u = new UOMDataForm();
            u.Show();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            ItemsDataForm d = new ItemsDataForm();
            d.Show();
        }

        private void btnTax_Click(object sender, EventArgs e)
        {
            TaxNameDataForm t = new TaxNameDataForm();
            t.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransferDataFrom trInvoice = new TransferDataFrom();
            trInvoice.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InvoiceDataForm i = new InvoiceDataForm();
            i.Show();
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnaccounts_Click(object sender, EventArgs e)
        {
            AccountsPermissionsDataFrom acc = new AccountsPermissionsDataFrom();
            acc.Show();
        }

        private void Start_Load(object sender, EventArgs e)
        {

            PictureBox pic = new PictureBox();
            pic.Location = new Point(345, 10);
            pic.Size = new Size(130, 71);
            pic.Margin = new Padding(3);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = Image.FromFile(@"ectra.JPEG");
            Controls.Add(pic);
        }
    }
}
