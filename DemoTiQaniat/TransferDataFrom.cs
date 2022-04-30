using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DemoTiQaniat
{
    public partial class TransferDataFrom : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();
        SqlCommand cmd1, cmd2, cmd3, cmd4;
        public TransferDataFrom()
        {
            InitializeComponent();

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNumber.Text == "" && txtID.Text == "" && cmbType.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInvoiceNumber.Focus();
            }
            else
            {
                cmbType.Text = "";
                txtInvoiceNumber.Text = "";
                txtID.Text = "";
                txtInvoiceNumber.Focus();
            }
        } 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            getData();
        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (row.Cells["checkbox"] as DataGridViewCheckBoxCell);
                checkbox.Value = HeaderCheckBox.Checked;
            }
        }
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = true;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkbox"].EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                HeaderCheckBox.Checked = isChecked;
            }
        }
        private void btnExe_Click(object sender, EventArgs e)
        {
            Process.Start(@"EInvoicing.exe", Login.id+" "+Login.name);
        }
        private void TransferDataFrom_Load(object sender, EventArgs e)
        {
            dtTo.Format = DateTimePickerFormat.Custom;
            dtTo.CustomFormat = " ";
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = " ";
        }
        private void btnTansfer_Click(object sender, EventArgs e)
        {
            List<string> selectedItems = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                drow = dataGridView1.Rows[i];
                if (Convert.ToBoolean(drow.Cells[0].Value) == true)
                {
                    string id = drow.Cells[1].Value.ToString();
                    selectedItems.Add(id);
                }
            }

            if (selectedItems.Count == 0)
            {
                MessageBox.Show("من فضلك حدد الفواتير التى تريد ترحيلها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("هل تريد ترحيل هذه الفواتير", "تاكيد", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    foreach (string s in selectedItems)
                    {
                        using (SqlConnection source = new SqlConnection(ConnectionString.Connection()))
                        using (SqlConnection destination = new SqlConnection(ConnectionString.Connection()))
                        {
                            try
                            {
                                source.Open();
                                destination.Open();

                                cmd1 = new SqlCommand("SELECT * FROM EINVOICES_HEADERS_TEMP_SETUP where TRX_HEADER_ID = '" + s + "' ", source);
                                cmd1.CommandType = CommandType.Text;
                                cmd1.ExecuteNonQuery();

                                DataTable dt = new DataTable();
                                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                                adapter.Fill(dt);

                                SqlBulkCopy BDInvoiceHeader = new SqlBulkCopy(destination);
                                BDInvoiceHeader.DestinationTableName = "EINVOICES_HEADERS_TEMP";
                                BDInvoiceHeader.WriteToServer(dt);
                                BDInvoiceHeader.Close();

                                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                                {
                                    //invoice line
                                    cmd2 = new SqlCommand("SELECT * FROM EINVOICES_LINES_TEMP_SETUP where TRX_HEADER_ID = '" + s + "' ", source);
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.ExecuteNonQuery();

                                    DataTable dtInvoiceLine = new DataTable();
                                    SqlDataAdapter daInvoiceLine = new SqlDataAdapter(cmd2);
                                    daInvoiceLine.Fill(dtInvoiceLine);

                                    SqlBulkCopy BDInvoiceLines = new SqlBulkCopy(destination);
                                    BDInvoiceLines.DestinationTableName = "EINVOICES_LINES_TEMP";
                                    BDInvoiceLines.WriteToServer(dtInvoiceLine);
                                    BDInvoiceLines.Close();

                                    //taxheader
                                    cmd3 = new SqlCommand("SELECT * FROM TAX_HEADERS_TEMP_SETUP where TRX_HEADER_ID = '" + s + "' ", source);
                                    cmd3.CommandType = CommandType.Text;
                                    cmd3.ExecuteNonQuery();
                                    DataTable dtTaxHeader = new DataTable();
                                    SqlDataAdapter daTaxHeader = new SqlDataAdapter(cmd3);
                                    daTaxHeader.Fill(dtTaxHeader);

                                    SqlBulkCopy BDtaxHeader = new SqlBulkCopy(destination);
                                    BDtaxHeader.DestinationTableName = "TAX_HEADERS_TEMP";
                                    BDtaxHeader.WriteToServer(dtTaxHeader);
                                    BDtaxHeader.Close();


                                    //tax line
                                    cmd4 = new SqlCommand("SELECT * FROM TAX_LINES_TEMP_SETUP where TRX_HEADER_ID = '" + s + "' ", source);
                                    cmd4.CommandType = CommandType.Text;
                                    cmd4.ExecuteNonQuery();
                                    DataTable dtTaxLine = new DataTable();
                                    SqlDataAdapter daTaxLine = new SqlDataAdapter(cmd4);
                                    daTaxLine.Fill(dtTaxLine);

                                    SqlBulkCopy BDTaxLines = new SqlBulkCopy(destination);
                                    BDTaxLines.DestinationTableName = "TAX_LINES_TEMP";
                                    BDTaxLines.WriteToServer(dtTaxLine);
                                    BDTaxLines.Close();

                                }
                                MessageBox.Show("تمت عملية ترحيل الفواتير بنجاح ");

                            }
                            catch
                            {
                                MessageBox.Show("لم تتم عمليه الترحيل تاكد من جميع بياناتك ");
                            }
                            finally
                            {
                                destination.Close();
                                source.Close();
                            }
                        }
                    }
                }

            }

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpFrom.Format = DateTimePickerFormat.Short;
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            dtTo.Format = DateTimePickerFormat.Short;
        }
        #region Helper
        private void getData()
        {
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 48)
            {
                AddCheckBox();
            }
            string type = "";
            if (cmbType.Text == "فاتورة")
            {
                type = "I";
            }
            else if (cmbType.Text == "اشعار بالاضافة")
            {
                type = "C";
            }
            else if (cmbType.Text == "اشعار بالخصم")
            {
                type = "D";
            }
            string invoceNumber = txtInvoiceNumber.Text == "" ? "TRX_HEADER_ID" : "'%" + txtInvoiceNumber.Text + "%'";
            string id = txtID.Text == "" ? "RECEIVER_ID" : "'%" + txtID.Text + "%'";
            string cmb = type == "" ? "DOCUMENTTYPE" : "'%" + type + "%'";
            string startDate = dtpFrom.Format == DateTimePickerFormat.Custom ? "DATETIMEISSUED" : "'" + dtpFrom.Value.ToString("yyyy-MM-dd") + "' + 'T08:11:12Z'";
            string endDate = dtTo.Format == DateTimePickerFormat.Custom ? "DATETIMEISSUED" : "'" + dtTo.Value.ToString("yyyy-MM-dd") + "' + 'T08:11:12Z'";

            DataAdapter = new SqlDataAdapter("Select TRX_HEADER_ID as 'رقم الفاتورة',ISSUER_ID as 'الرقم الضريبى للممول',case when RECEIVER_TYPE = 'B' then 'Business' when RECEIVER_TYPE = 'P' then 'Person' when  RECEIVER_TYPE = 'F' then 'Foreign' end 'نوع العميل',RECEIVER_ID as 'كود العميل' ,RECEIVER_NAME as 'اسم العميل', RECEIVER_COUNTRY as 'كود الدولة', RECEIVER_GOVERNATE as 'المحافظة', RECEIVER_REGIONCITY as 'المدينة' ,RECEIVER_STREET  as 'الشارع' ,RECEIVER_BUILDINGNUMBER as 'رقم المبنى',RECEIVER_POSTALCODE as 'الرقم البريدى',RECEIVER_FLOOR as 'الدور',RECEIVER_ROOM as 'الغرفة' ,RECEIVER_LANDMARK as 'علامة مميزة',RECEIVER_ADDITIONALINFO as 'معلومات اضافية' ,DOCUMENTTYPE as 'نوع الوثيقة',DOCUMENTTYPEVERSION as 'نسخة الوثيقة',DATETIMEISSUED as 'التاريخ',TAXPAYERACTIVITYCODE as 'كود النشاط',INTERNALID as 'الرقم الداخلى للفاتورة',PURCHASEORDERREFERENCE as 'بيان طلب الشراء',PURCHASEORDERDESCRIPTION as 'وصف امر الشراء',SALESORDERREFERENCE as 'بيان طلب المبيعات',SALESORDERDESCRIPTION as 'وصف طلب المبيعات',PROFORMAINVOICENUMBER as 'رقم الفاتورة الاولية',PAYMENT_BANKNAME as 'اسم بنك الدفع',PAYMENT_BANKADDRESS as 'عنوان بنك الدفع',PAYMENT_BANKACCOUNTNO as 'رقم حساب بنك الدفع',PAYMENT_BANKACCOUNTIBAN as ' IBAN رقم',PAYMENT_SWIFTCODE as 'رقم السويفت كود',PAYMENT_TERMS as 'شروط الدفع',DELIVERY_APPROACH as 'نهج التسليم',DELIVERY_PACKAGING as 'التسليم- التعبئة',DELIVERY_DATEVALIDITY as 'صلاحية تاريخ التسليم',DELIVERY_EXPORTPORT as 'ميناء التسليم',DELIVERY_COUNTRYOFORIGIN as 'بلد التسليم الاصلى',DELIVERY_GROSSWEIGHT as 'الوزن الاجمالى المسلم',DELIVERY_NETWEIGHT as 'الوزن الصافى المسلم',DELIVERY_TERMS as 'شروط التوصيل',TOTALDISCOUNTAMOUNT as 'مجموع الخصومات',TOTALSALESAMOUNT as 'اجمالى المبيعات',NETAMOUNT as 'الاجمالى بعد الخصم' ,TOTALAMOUNT as 'الاجمالى بعد الضريبة',EXTRADISCOUNTAMOUNT as 'خصم اضافى' ,TOTALITEMSDISCOUNTAMOUNT as 'اجمالى الخصم بعد ض' ,REFERENCE_UUID as 'الرقم الفريد المرجعى',REFERENCE_INVOICE_NUM as 'رقم الفاتورة المرجعي',ACTIONTYPE as 'الغاء فاتورة' From EINVOICES_HEADERS_TEMP_SETUP where TRX_HEADER_ID like  " + invoceNumber + " and RECEIVER_ID like " + id + " and DOCUMENTTYPE like " + cmb+ " and DATETIMEISSUED between " + startDate + " and " + endDate + " ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void AddCheckBox()
        {
            HeaderCheckBox.Location = new Point(50, 8);
            HeaderCheckBox.BackColor = Color.White;
            HeaderCheckBox.Size = new Size(15, 15);
            dataGridView1.Controls.Add(HeaderCheckBox);

            HeaderCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);

            dgv.HeaderText = "";
            dgv.Width = 30;
            dgv.Name = "checkbox";
            dgv.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns.Insert(0, dgv);

            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }
        public void setUpDataGrid()
        {
            for (int i = 1; i <= 48; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                dataGridView1.Columns[i].HeaderCell.Style.ForeColor = Color.Black;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        #endregion
    }

}
