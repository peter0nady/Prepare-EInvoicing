using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;

namespace DemoTiQaniat
{
    public partial class InvoiceDataForm : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();

        public InvoiceDataForm()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
           
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
        private void btnCreate_Click(object sender, EventArgs e)
        {
            InvoiceDataFormat i = new InvoiceDataFormat();
            i.ShowDialog();
            if (dataGridView1.Rows.Count > 0)
            {
                EnabelEditAndClear();
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 48)
                {
                    AddCheckBox();
                }
                DataAdapter = new SqlDataAdapter("Select TRX_HEADER_ID as 'رقم الفاتورة',ISSUER_ID as 'الرقم الضريبى للممول',case when RECEIVER_TYPE = 'B' then 'Business' when RECEIVER_TYPE = 'P' then 'Person' when  RECEIVER_TYPE = 'F' then 'Foreign' end 'نوع العميل',RECEIVER_ID as 'كود العميل' ,RECEIVER_NAME as 'اسم العميل', RECEIVER_COUNTRY as 'كود الدولة', RECEIVER_GOVERNATE as 'المحافظة', RECEIVER_REGIONCITY as 'المدينة' ,RECEIVER_STREET  as 'الشارع' ,RECEIVER_BUILDINGNUMBER as 'رقم المبنى',RECEIVER_POSTALCODE as 'الرقم البريدى',RECEIVER_FLOOR as 'الدور',RECEIVER_ROOM as 'الغرفة' ,RECEIVER_LANDMARK as 'علامة مميزة',RECEIVER_ADDITIONALINFO as 'معلومات اضافية' ,DOCUMENTTYPE as 'نوع الوثيقة',DOCUMENTTYPEVERSION as 'نسخة الوثيقة',DATETIMEISSUED as 'التاريخ',TAXPAYERACTIVITYCODE as 'كود النشاط',INTERNALID as 'الرقم الداخلى للفاتورة',PURCHASEORDERREFERENCE as 'بيان طلب الشراء',PURCHASEORDERDESCRIPTION as 'وصف امر الشراء',SALESORDERREFERENCE as 'بيان طلب المبيعات',SALESORDERDESCRIPTION as 'وصف طلب المبيعات',PROFORMAINVOICENUMBER as 'رقم الفاتورة الاولية',PAYMENT_BANKNAME as 'اسم بنك الدفع',PAYMENT_BANKADDRESS as 'عنوان بنك الدفع',PAYMENT_BANKACCOUNTNO as 'رقم حساب بنك الدفع',PAYMENT_BANKACCOUNTIBAN as ' IBAN رقم',PAYMENT_SWIFTCODE as 'رقم السويفت كود',PAYMENT_TERMS as 'شروط الدفع',DELIVERY_APPROACH as 'نهج التسليم',DELIVERY_PACKAGING as 'التسليم- التعبئة',DELIVERY_DATEVALIDITY as 'صلاحية تاريخ التسليم',DELIVERY_EXPORTPORT as 'ميناء التسليم',DELIVERY_COUNTRYOFORIGIN as 'بلد التسليم الاصلى',DELIVERY_GROSSWEIGHT as 'الوزن الاجمالى المسلم',DELIVERY_NETWEIGHT as 'الوزن الصافى المسلم',DELIVERY_TERMS as 'شروط التوصيل',TOTALDISCOUNTAMOUNT as 'مجموع الخصومات',TOTALSALESAMOUNT as 'اجمالى المبيعات',NETAMOUNT as 'الاجمالى بعد الخصم' ,TOTALAMOUNT as 'الاجمالى بعد الضريبة',EXTRADISCOUNTAMOUNT as 'خصم اضافى' ,TOTALITEMSDISCOUNTAMOUNT as 'اجمالى الخصم بعد ض' ,REFERENCE_UUID as 'الرقم الفريد المرجعى',REFERENCE_INVOICE_NUM as 'رقم الفاتورة المرجعي',ACTIONTYPE as 'الغاء فاتورة' From EINVOICES_HEADERS_TEMP_SETUP ", cn);
                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                dataGridView1.Sort(this.dataGridView1.Columns["التاريخ"], ListSortDirection.Descending);
                setUpDataGrid();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnClearGrid.Enabled = true;
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
        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            dtp.Format = DateTimePickerFormat.Short;
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.Format = DateTimePickerFormat.Short;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                DataGridViewRow drow = new DataGridViewRow();
                drow = dataGridView1.Rows[i];
                if (Convert.ToBoolean(drow.Cells[0].Value) == true)
                {
                    InvoiceReport inrep = new InvoiceReport();
                    inrep.id = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    inrep.ShowDialog();
                }

            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 48)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select TRX_HEADER_ID as 'رقم الفاتورة',ISSUER_ID as 'الرقم الضريبى للممول',case when RECEIVER_TYPE = 'B' then 'Business' when RECEIVER_TYPE = 'P' then 'Person' when  RECEIVER_TYPE = 'F' then 'Foreign' end 'نوع العميل',RECEIVER_ID as 'كود العميل' ,RECEIVER_NAME as 'اسم العميل', RECEIVER_COUNTRY as 'كود الدولة', RECEIVER_GOVERNATE as 'المحافظة', RECEIVER_REGIONCITY as 'المدينة' ,RECEIVER_STREET  as 'الشارع' ,RECEIVER_BUILDINGNUMBER as 'رقم المبنى',RECEIVER_POSTALCODE as 'الرقم البريدى',RECEIVER_FLOOR as 'الدور',RECEIVER_ROOM as 'الغرفة' ,RECEIVER_LANDMARK as 'علامة مميزة',RECEIVER_ADDITIONALINFO as 'معلومات اضافية' ,DOCUMENTTYPE as 'نوع الوثيقة',DOCUMENTTYPEVERSION as 'نسخة الوثيقة',DATETIMEISSUED as 'التاريخ',TAXPAYERACTIVITYCODE as 'كود النشاط',INTERNALID as 'الرقم الداخلى للفاتورة',PURCHASEORDERREFERENCE as 'بيان طلب الشراء',PURCHASEORDERDESCRIPTION as 'وصف امر الشراء',SALESORDERREFERENCE as 'بيان طلب المبيعات',SALESORDERDESCRIPTION as 'وصف طلب المبيعات',PROFORMAINVOICENUMBER as 'رقم الفاتورة الاولية',PAYMENT_BANKNAME as 'اسم بنك الدفع',PAYMENT_BANKADDRESS as 'عنوان بنك الدفع',PAYMENT_BANKACCOUNTNO as 'رقم حساب بنك الدفع',PAYMENT_BANKACCOUNTIBAN as ' IBAN رقم',PAYMENT_SWIFTCODE as 'رقم السويفت كود',PAYMENT_TERMS as 'شروط الدفع',DELIVERY_APPROACH as 'نهج التسليم',DELIVERY_PACKAGING as 'التسليم- التعبئة',DELIVERY_DATEVALIDITY as 'صلاحية تاريخ التسليم',DELIVERY_EXPORTPORT as 'ميناء التسليم',DELIVERY_COUNTRYOFORIGIN as 'بلد التسليم الاصلى',DELIVERY_GROSSWEIGHT as 'الوزن الاجمالى المسلم',DELIVERY_NETWEIGHT as 'الوزن الصافى المسلم',DELIVERY_TERMS as 'شروط التوصيل',TOTALDISCOUNTAMOUNT as 'مجموع الخصومات',TOTALSALESAMOUNT as 'اجمالى المبيعات',NETAMOUNT as 'الاجمالى بعد الخصم' ,TOTALAMOUNT as 'الاجمالى بعد الضريبة',EXTRADISCOUNTAMOUNT as 'خصم اضافى' ,TOTALITEMSDISCOUNTAMOUNT as 'اجمالى الخصم بعد ض' ,REFERENCE_UUID as 'الرقم الفريد المرجعى',REFERENCE_INVOICE_NUM as 'رقم الفاتورة المرجعي',ACTIONTYPE as 'الغاء فاتورة' From EINVOICES_HEADERS_TEMP_SETUP ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            dataGridView1.Sort(this.dataGridView1.Columns["التاريخ"], ListSortDirection.Descending);
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void InvoiceDataForm_Load(object sender, EventArgs e)
        {
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = " ";
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " ";
        }

        #region Helper
        public void Delete()
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
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("من فضلك حدد النتائج التى تريد حذفها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("هل تريد حذف هذه الفواتير", "تاكيد", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //delete row from database and datagridview...
                    foreach (string s in selectedItems)
                    {
                        var query = "DELETE FROM EINVOICES_HEADERS_TEMP_SETUP WHERE TRX_HEADER_ID = '" + s + "' " + "DELETE FROM EINVOICES_LINES_TEMP_SETUP WHERE TRX_HEADER_ID = '" + s + "' " + " DELETE FROM TAX_HEADERS_TEMP_SETUP WHERE TRX_HEADER_ID = '" + s + "' " + "DELETE FROM TAX_LINES_TEMP_SETUP WHERE TRX_HEADER_ID = '" + s + "' ";
                        cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            dataTabel.Clear();
            DataAdapter = new SqlDataAdapter("Select TRX_HEADER_ID as 'رقم الفاتورة',ISSUER_ID as 'الرقم الضريبى للممول',RECEIVER_TYPE as 'نوع العميل',RECEIVER_ID as 'كود العميل' ,RECEIVER_NAME as 'اسم العميل', RECEIVER_COUNTRY as 'كود الدولة', RECEIVER_GOVERNATE as 'المحافظة', RECEIVER_REGIONCITY as 'المدينة' ,RECEIVER_STREET  as 'الشارع' ,RECEIVER_BUILDINGNUMBER as 'رقم المبنى',RECEIVER_POSTALCODE as 'الرقم البريدى',RECEIVER_FLOOR as 'الدور',RECEIVER_ROOM as 'الغرفة' ,RECEIVER_LANDMARK as 'علامة مميزة',RECEIVER_ADDITIONALINFO as 'معلومات اضافية' ,DOCUMENTTYPE as 'نوع الوثيقة',DOCUMENTTYPEVERSION as 'نسخة الوثيقة',DATETIMEISSUED as 'التاريخ',TAXPAYERACTIVITYCODE as 'كود النشاط',INTERNALID as 'الرقم الداخلى للفاتورة',PURCHASEORDERREFERENCE,PURCHASEORDERDESCRIPTION,SALESORDERREFERENCE,SALESORDERDESCRIPTION,PROFORMAINVOICENUMBER,PAYMENT_BANKNAME,PAYMENT_BANKADDRESS,PAYMENT_BANKACCOUNTNO,PAYMENT_BANKACCOUNTIBAN,PAYMENT_SWIFTCODE,PAYMENT_TERMS,DELIVERY_APPROACH,DELIVERY_PACKAGING,DELIVERY_DATEVALIDITY,DELIVERY_EXPORTPORT,DELIVERY_COUNTRYOFORIGIN,DELIVERY_GROSSWEIGHT,DELIVERY_NETWEIGHT,DELIVERY_TERMS,TOTALDISCOUNTAMOUNT,TOTALSALESAMOUNT,NETAMOUNT as 'الاجمالى بعد الخصم' ,TOTALAMOUNT as 'الاجمالى بعد الضريبة',EXTRADISCOUNTAMOUNT as 'خصم اضافى' ,TOTALITEMSDISCOUNTAMOUNT as 'اجمالى الخصم بعد ض' ,REFERENCE_UUID,REFERENCE_INVOICE_NUM,ACTIONTYPE,MAINSTATUS,ReadyToMain,DateTimeIssuedTemp From EINVOICES_HEADERS_TEMP_SETUP", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            dataGridView1.Sort(this.dataGridView1.Columns["التاريخ"], ListSortDirection.Descending);
            cn.Close();
        }
        public void Edit()
        {
            List<string> selectedItems = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            DataGridViewRow drowSelected = new DataGridViewRow();

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                drow = dataGridView1.Rows[i];

                if (Convert.ToBoolean(drow.Cells[0].Value) == true)
                {
                    string id = drow.Cells[1].Value.ToString();
                    selectedItems.Add(id);
                    drowSelected = dataGridView1.Rows[i];
                }

            }

            if (selectedItems.Count != 1)
            {
                MessageBox.Show("من فضلك حدد صفا واحدا", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedItems.Count == 1)
            {
                InvoiceEdit edit = new InvoiceEdit();

                edit.txtHeaderID.Text = drowSelected.Cells[1].Value.ToString();

                edit.StartPosition = FormStartPosition.CenterScreen;
                edit.ShowDialog();
            }

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
        private void AddCheckBox()
        {
            HeaderCheckBox.Location = new Point(50, 15);
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
        public void EnabelEditAndClear()
        {
            btnEdit.Enabled = true;
            btnClearGrid.Enabled = true;
        }
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
            string RecieverName = txtName.Text == "" ? "RECEIVER_NAME" : "N'%" + txtName.Text + "%'";
            string id = txtID.Text == "" ? "RECEIVER_ID" : "'%" + txtID.Text + "%'";
            string cmb = type == "" ? "DOCUMENTTYPE" : "'%" + type + "%'";
            string startDate = dtp.Format == DateTimePickerFormat.Custom ? "DATETIMEISSUED" : "'" + dtp.Value.ToString("yyyy-MM-dd") + "' + 'T08:11:12Z'";
            string endDate = dtpTo.Format == DateTimePickerFormat.Custom ? "DATETIMEISSUED" : "'" + dtpTo.Value.ToString("yyyy-MM-dd") + "'+'T08:11:12Z'";
            
            DataAdapter = new SqlDataAdapter("Select TRX_HEADER_ID as 'رقم الفاتورة',ISSUER_ID as 'الرقم الضريبى للممول',case when RECEIVER_TYPE = 'B' then 'Business' when RECEIVER_TYPE = 'P' then 'Person' when  RECEIVER_TYPE = 'F' then 'Foreign' end 'نوع العميل',RECEIVER_ID as 'كود العميل' ,RECEIVER_NAME as 'اسم العميل', RECEIVER_COUNTRY as 'كود الدولة', RECEIVER_GOVERNATE as 'المحافظة', RECEIVER_REGIONCITY as 'المدينة' ,RECEIVER_STREET  as 'الشارع' ,RECEIVER_BUILDINGNUMBER as 'رقم المبنى',RECEIVER_POSTALCODE as 'الرقم البريدى',RECEIVER_FLOOR as 'الدور',RECEIVER_ROOM as 'الغرفة' ,RECEIVER_LANDMARK as 'علامة مميزة',RECEIVER_ADDITIONALINFO as 'معلومات اضافية' ,DOCUMENTTYPE as 'نوع الوثيقة',DOCUMENTTYPEVERSION as 'نسخة الوثيقة',DATETIMEISSUED as 'التاريخ',TAXPAYERACTIVITYCODE as 'كود النشاط',INTERNALID as 'الرقم الداخلى للفاتورة',PURCHASEORDERREFERENCE as 'بيان طلب الشراء',PURCHASEORDERDESCRIPTION as 'وصف امر الشراء',SALESORDERREFERENCE as 'بيان طلب المبيعات',SALESORDERDESCRIPTION as 'وصف طلب المبيعات',PROFORMAINVOICENUMBER as 'رقم الفاتورة الاولية',PAYMENT_BANKNAME as 'اسم بنك الدفع',PAYMENT_BANKADDRESS as 'عنوان بنك الدفع',PAYMENT_BANKACCOUNTNO as 'رقم حساب بنك الدفع',PAYMENT_BANKACCOUNTIBAN as ' IBAN رقم',PAYMENT_SWIFTCODE as 'رقم السويفت كود',PAYMENT_TERMS as 'شروط الدفع',DELIVERY_APPROACH as 'نهج التسليم',DELIVERY_PACKAGING as 'التسليم- التعبئة',DELIVERY_DATEVALIDITY as 'صلاحية تاريخ التسليم',DELIVERY_EXPORTPORT as 'ميناء التسليم',DELIVERY_COUNTRYOFORIGIN as 'بلد التسليم الاصلى',DELIVERY_GROSSWEIGHT as 'الوزن الاجمالى المسلم',DELIVERY_NETWEIGHT as 'الوزن الصافى المسلم',DELIVERY_TERMS as 'شروط التوصيل',TOTALDISCOUNTAMOUNT as 'مجموع الخصومات',TOTALSALESAMOUNT as 'اجمالى المبيعات',NETAMOUNT as 'الاجمالى بعد الخصم' ,TOTALAMOUNT as 'الاجمالى بعد الضريبة',EXTRADISCOUNTAMOUNT as 'خصم اضافى' ,TOTALITEMSDISCOUNTAMOUNT as 'اجمالى الخصم بعد ض' ,REFERENCE_UUID as 'الرقم الفريد المرجعى',REFERENCE_INVOICE_NUM as 'رقم الفاتورة المرجعي',ACTIONTYPE as 'الغاء فاتورة' From EINVOICES_HEADERS_TEMP_SETUP where TRX_HEADER_ID like  " + invoceNumber + " and RECEIVER_NAME like " + RecieverName + " and RECEIVER_ID like " + id + " and DOCUMENTTYPE like " + cmb + " and DATETIMEISSUED between " + startDate  + " and " + endDate + " ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        #endregion

    }

}
