using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class TaxNameDataForm : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();

        public TaxNameDataForm()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
        }  
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txInternalName.Text == "" && txtTaxName.Text == "" && txtDesc.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txInternalName.Focus();
            }
            else
            {
                txInternalName.Text = "";
                txtTaxName.Text = "";
                txtDesc.Text = "";
                txInternalName.Focus();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            TaxName i = new TaxName();
            i.ShowDialog();
            if (dataGridView1.Rows.Count > 0)
            {
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 5)
                {
                    AddCheckBox();
                }
                cmd = new SqlCommand("SearchAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataAdapter = new SqlDataAdapter(cmd);

                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                setUpDataGrid();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 5)
            {
                AddCheckBox();
            }
            cmd = new SqlCommand("SearchAll", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataAdapter = new SqlDataAdapter(cmd);

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
            print();

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 5)
            {
                AddCheckBox();
            }
            cmd = new SqlCommand("SearchAll", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataAdapter = new SqlDataAdapter(cmd);

            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void txInternalName_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 5)
            {
                AddCheckBox();
            }
            cmd = new SqlCommand("SearchByInternalName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = txInternalName.Text;
            DataAdapter = new SqlDataAdapter(cmd);

            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void txtTaxName_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 5)
            {
                AddCheckBox();
            }
            cmd = new SqlCommand("SearchByTaxName", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TaxName", SqlDbType.NVarChar).Value = txtTaxName.Text;
            DataAdapter = new SqlDataAdapter(cmd);

            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();

        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 5)
            {
                AddCheckBox();
            }
            cmd = new SqlCommand("SearchByDesc", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Desc", SqlDbType.NVarChar).Value = txtDesc.Text;
            DataAdapter = new SqlDataAdapter(cmd);

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
            for (int i = 1; i <= 5; i++)
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
                DialogResult dr = MessageBox.Show("هل تريد حذف هذه البيانات", "تاكيد", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (string s in selectedItems)
                    {
                        cmd = new SqlCommand("delete from Tax_Name where ID ='" + s + "' ", cn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            dataTabel.Clear();

            cmd = new SqlCommand("SearchAll", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataAdapter = new SqlDataAdapter(cmd);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
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
                TaxNameEdit c = new TaxNameEdit(drowSelected.Cells[1].Value.ToString());

                c.txtName.Text = drowSelected.Cells[2].Value.ToString();
                c.cmbType.Text = drowSelected.Cells[3].Value.ToString();
                c.txtDescEn.Text = drowSelected.Cells[4].Value.ToString();
                c.txtDescAr.Text = drowSelected.Cells[5].Value.ToString();

                c.StartPosition = FormStartPosition.CenterScreen;
                c.ShowDialog();
            }

        }
        private void print()
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
                MessageBox.Show("من فضلك حدد النتائج التى تريد طباعتها ", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TaxNameReport rep = new TaxNameReport();
                foreach (string s in selectedItems)
                {
                    rep.id = s;
                    rep.ShowDialog();
                }
            }
        }
        #endregion
    }

}
