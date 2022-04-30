using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class AccountsPermissionsDataFrom : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();

        public AccountsPermissionsDataFrom()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
        } 
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtLoginID.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
            }
            else
            {
                txtName.Text = "";
                txtLoginID.Text = "";
                txtName.Focus();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            AccountAndPermission acc = new AccountAndPermission();
            acc.ShowDialog();
            if (dataGridView1.Rows.Count > 0 )
            {
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 6)
                {
                    AddCheckBox();
                }
                DataAdapter = new SqlDataAdapter(" select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]", cn);
                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                setUpDataGrid();
            }
        }    
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 6)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter(" select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]", cn);
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
            if (dataGridView1.Columns.Count <= 6)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter(" select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 6)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter(" select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]  where Name like '%" + txtName.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void txtLoginID_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 6)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter(" select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]  where LoginId like '%" + txtLoginID.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        #region Helper
        public void EnabelEditAndClear()
        {
            btnEdit.Enabled = true;
            btnClearGrid.Enabled = true;
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
        public void setUpDataGrid()
        {
            for (int i = 1; i <= 6; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                dataGridView1.Columns[i].HeaderCell.Style.ForeColor = Color.Black;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
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
                DialogResult dr = MessageBox.Show("هل تريد حذف هذا المستخدم", "تاكيد", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    foreach (string s in selectedItems)
                    {
                        var query = "  delete from [dbo].[User] where LoginId = '" + s + "'delete from [dbo].[UserRights] where UserLogin = '" + s + "'";
                        cmd = new SqlCommand(query, cn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            dataTabel.Clear();
            DataAdapter = new SqlDataAdapter("select LoginId as 'اسم دخول المستخدم',[Name] as 'اسم المستخدم',[Status] as 'الحالة',[ExpiryDate] as 'تاريخ انتهاء صلاحية المستخدم',[CreationDate] as 'تاريخ انشاء الحساب',[Active] as 'نشط' from[dbo].[User]", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            cn.Close();
        }
        public void Print()
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
                MessageBox.Show("من فضلك حدد النتائج التى تريد طباعتها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (string s in selectedItems)
                {
                    AccountReports rep = new AccountReports();
                    rep.id = s;
                    rep.ShowDialog();
                }
            }

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
                AccountAndPermissionEdit acc = new AccountAndPermissionEdit();
                acc.txtloginID.Text = drowSelected.Cells[1].Value.ToString();

                acc.StartPosition = FormStartPosition.CenterScreen;
                acc.ShowDialog();

            }

        }
        #endregion
    }

}
