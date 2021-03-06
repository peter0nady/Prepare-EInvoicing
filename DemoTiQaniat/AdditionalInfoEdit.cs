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
    public partial class AdditionalInfoEdit : Form
    {
        public AdditionalInfoEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OptionalInfoData.PURCHASEORDERREFERENCE = textBox1.Text;
            OptionalInfoData.PURCHASEORDERDESCRIPTION = textBox2.Text;
            OptionalInfoData.SALESORDERREFERENCE = textBox3.Text;
            OptionalInfoData.SALESORDERDESCRIPTION = textBox4.Text;
            OptionalInfoData.PROFORMAINVOICENUMBER = textBox5.Text;
            OptionalInfoData.PAYMENT_BANKNAME = textBox6.Text;
            OptionalInfoData.PAYMENT_BANKADDRESS = textBox7.Text;
            OptionalInfoData.PAYMENT_BANKACCOUNTNO = textBox8.Text;
            OptionalInfoData.PAYMENT_BANKACCOUNTIBAN = textBox9.Text;
            OptionalInfoData.PAYMENT_SWIFTCODE = textBox10.Text;
            OptionalInfoData.PAYMENT_TERMS = textBox11.Text;
            OptionalInfoData.DELIVERY_APPROACH = textBox12.Text;
            OptionalInfoData.DELIVERY_PACKAGING = textBox15.Text;
            OptionalInfoData.DELIVERY_DATEVALIDITY = textBox14.Text;
            OptionalInfoData.DELIVERY_EXPORTPORT = textBox13.Text;
            OptionalInfoData.DELIVERY_COUNTRYOFORIGIN = textBox18.Text;
            OptionalInfoData.DELIVERY_GROSSWEIGHT = textBox17.Text;
            OptionalInfoData.DELIVERY_NETWEIGHT = textBox16.Text;
            OptionalInfoData.DELIVERY_TERMS = textBox19.Text;
            OptionalInfoData.REFERENCE_INVOICE_NUM = textBox20.Text;
            OptionalInfoData.ACTIONTYPE = textBox21.Text;

            MessageBox.Show("تم الحفظ");

        }

        private void AdditionalInfoEdit_Load(object sender, EventArgs e)
        {
            textBox1.Text= OptionalInfoData.PURCHASEORDERREFERENCE ;
            textBox2.Text= OptionalInfoData.PURCHASEORDERDESCRIPTION ;
            textBox3.Text= OptionalInfoData.SALESORDERREFERENCE ;
            textBox4.Text= OptionalInfoData.SALESORDERDESCRIPTION ;
            textBox5.Text= OptionalInfoData.PROFORMAINVOICENUMBER;
            textBox6.Text= OptionalInfoData.PAYMENT_BANKNAME;
            textBox7.Text= OptionalInfoData.PAYMENT_BANKADDRESS ;
            textBox8.Text= OptionalInfoData.PAYMENT_BANKACCOUNTNO ;
            textBox9.Text= OptionalInfoData.PAYMENT_BANKACCOUNTIBAN ;
            textBox10.Text= OptionalInfoData.PAYMENT_SWIFTCODE ;
            textBox11.Text= OptionalInfoData.PAYMENT_TERMS ;
            textBox12.Text= OptionalInfoData.DELIVERY_APPROACH ;
            textBox15.Text= OptionalInfoData.DELIVERY_PACKAGING ;
            textBox14.Text= OptionalInfoData.DELIVERY_DATEVALIDITY ;
            textBox13.Text= OptionalInfoData.DELIVERY_EXPORTPORT ;
            textBox18.Text=OptionalInfoData.DELIVERY_COUNTRYOFORIGIN ;
            textBox17.Text= OptionalInfoData.DELIVERY_GROSSWEIGHT ;
            textBox16.Text= OptionalInfoData.DELIVERY_NETWEIGHT;
            textBox19.Text=OptionalInfoData.DELIVERY_TERMS ;
            textBox20.Text=OptionalInfoData.REFERENCE_INVOICE_NUM ;
            textBox21.Text= OptionalInfoData.ACTIONTYPE ;

        }
    }
}
