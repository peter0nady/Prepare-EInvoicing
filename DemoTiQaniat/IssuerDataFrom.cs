using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class IssuerDataFrom : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();

        public IssuerDataFrom()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
        }     
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtID.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            { 
                txtName.Text = "";
                txtID.Text = "";
                txtName.Focus();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Issuer i = new Issuer();
            i.ShowDialog();
            if(dataGridView1.Rows.Count > 0)
            {
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 22)
                {
                    AddCheckBox();
                }
                DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA ", cn);
                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                setUpDataGrid();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 22)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA ", cn);
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
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 22)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA where ISSUER_NAME like N'%" + txtName.Text + "%'", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 14)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA where ISSUER_ID like '%" + txtID.Text + "%'", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            Print();
        }   
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 22)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
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
                IssuerEdit edit = new IssuerEdit();

                edit.txtID.Text = drowSelected.Cells[1].Value.ToString();
                edit.cmbEnvironment.Text = drowSelected.Cells[2].Value.ToString();
                edit.txtBranch.Text = drowSelected.Cells[3].Value.ToString();
                edit.txtName.Text = drowSelected.Cells[4].Value.ToString();
                edit.txtActivity.Text = drowSelected.Cells[5].Value.ToString();
                edit.txtClientID.Text = drowSelected.Cells[6].Value.ToString();
                edit.txtPass1.Text = drowSelected.Cells[7].Value.ToString();
                edit.txtPass2.Text = drowSelected.Cells[8].Value.ToString();
                edit.txtType.Text = "Business";
                edit.txtCountry.Text = drowSelected.Cells[12].Value.ToString();
                edit.cmbGovernate.Text = drowSelected.Cells[13].Value.ToString();
                edit.txtRegion.Text = drowSelected.Cells[14].Value.ToString();
                edit.txtStreet.Text = drowSelected.Cells[15].Value.ToString();
                edit.txtBuild.Text = drowSelected.Cells[16].Value.ToString();
                edit.txtPostal.Text = drowSelected.Cells[17].Value.ToString();
                edit.txtFloor.Text = drowSelected.Cells[18].Value.ToString();
                edit.txtRoom.Text = drowSelected.Cells[19].Value.ToString();
                edit.txtland.Text = drowSelected.Cells[20].Value.ToString();
                edit.txtInfo.Text = drowSelected.Cells[21].Value.ToString();
                edit.txtIPServer.Text = drowSelected.Cells[22].Value.ToString();

                edit.StartPosition = FormStartPosition.CenterScreen;
                edit.ShowDialog();
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
                        cmd = new SqlCommand("delete from ISSUER_DATA where ISSUER_ID ='" + s + "' ", cn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            dataTabel.Clear();
            DataAdapter = new SqlDataAdapter("Select ISSUER_ID as 'الرقم الضريبى',ENVIROMENT as 'بيئة العمل',BRANCHID as 'رقم الفرع',ISSUER_NAME as 'اسم العميل' ,TAXACTIVITYCODE as 'كود النشاط',CLIENT_ID as ' كود الممول',CLIENT_SECRET_1 as 'الرقم السرى1',CLIENT_SECRET_2 as 'الرقم السرى2' ,WALLET_PATH,WALLET_PASSWORD, case when TYPE= 'B'  then 'Business' when TYPE = 'P' then 'Person' when  TYPE = 'F' then 'Foreign' end 'النوع', COUNTRY as 'كود الدولة' ,GOVERNATE as 'المحافظة',REGIONCITY as 'المدينة',STREET as 'الشارع',BUILDINGNUMBER as 'رقم المبنى',POSTALCODE as 'الرقم البريدى',FLOOR as 'الدور',ROOM as 'الغرفة' ,LANDMARK as 'علامة مميزة',ADDITIONALINFO as 'معلومات اضافية' ,IssuerServerIP as 'رقم السيرفر' From ISSUER_DATA", cn);
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
                IssuerReport rep = new IssuerReport();
                foreach (string s in selectedItems)
                {
                    rep.reportViewer1.Clear();
                    rep.id = s;
                    rep.ShowDialog();
                }
            }
            cn.Close();
        }
        public void setUpDataGrid()
        {
            for (int i = 1; i <= 22; i++)
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
