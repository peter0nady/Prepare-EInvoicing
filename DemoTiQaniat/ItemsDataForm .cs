using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class ItemsDataForm : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();
        public ItemsDataForm()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtItemCode.Text == "" && txtInternalCode.Text == "" && txtDesc.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtItemCode.Focus();
            }
            else
            {
                txtItemCode.Text = "";
                txtInternalCode.Text = "";
                txtDesc.Text = "";
                txtItemCode.Focus();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Items i = new Items();
            i.ShowDialog();
            if (dataGridView1.Rows.Count > 0)
            {
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 11)
                {
                    AddCheckBox();
                }
                DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup ", cn);
                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                setUpDataGrid();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 11)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            Print();

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 11)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 11)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup  where Description like N'%" + txtDesc.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void txtItemCode_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 11)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup  where ItemCode like '%" + txtItemCode.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();

        }
        private void txtInternalCode_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 11)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup  where InternalCode like '%" + txtInternalCode.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();

        }
        #region Helper
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
                ItemsEdit c = new ItemsEdit(drowSelected.Cells[1].Value.ToString());

                c.StartPosition = FormStartPosition.CenterScreen;
                c.ShowDialog();
            }

        }
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
            cn.Open();
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("من فضلك حدد النتائج التى تريد حذفها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dr = MessageBox.Show("هل تريد حذف هذه البيانات", "تاكيد", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (string s in selectedItems)
                    {
                        cmd = new SqlCommand("delete from ItemSetup where ID ='" + s + "' ", cn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            dataTabel.Clear();
            DataAdapter = new SqlDataAdapter("Select ID as 'مسلسل',InternalCode as 'الكود الداخلى',Description as 'الوصف',ItemType as 'فئة الصنف',ItemCode as 'الكود',UnitType as 'وحدة القياس',AmountEGP as 'السعر بالجنية المصرى' ,CurrencySold as 'العملة',AmountSold as 'السعر بالعملة الاجنبية' ,CurrencyExchangeRate as 'معدل تحويل العملة',DiscountAmount as 'قيمة الخصم' From ItemSetup ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            cn.Close();
        }
        private void Print()
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
            cn.Open();
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("من فضلك حدد النتائج التى تريد طباعتها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ItemsReport rep = new ItemsReport();

                foreach (string s in selectedItems)
                {
                    rep.id = s;
                    rep.ShowDialog();
                }
            }
            cn.Close();
        }
        public void setUpDataGrid()
        {
            for (int i = 1; i <= 11; i++)
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
        #endregion

        
    }

}
