using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class First : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataAdapter DataAdapter;
        DataTable dataTabel = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv = new DataGridViewCheckBoxColumn();

        public First()
        {
            InitializeComponent();
            btnEdit.Enabled = false;
            btnClearGrid.Enabled = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "" && txtName.Text == "" && txtID.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
            }
            else
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtID.Text = "";
                txtCode.Focus();
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.ShowDialog();
            if(dataGridView1.Rows.Count > 0)
            {
                dataTabel.Clear();
                if (dataGridView1.Columns.Count <= 14)
                {
                    AddCheckBox();
                }
                DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل',ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever", cn);
                DataAdapter.Fill(dataTabel);
                dataGridView1.DataSource = dataTabel;
                setUpDataGrid();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 14)
            {
                AddCheckBox();
            }

            DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل',ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever Where InternalCode like '%" + txtCode.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 14)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل',ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever", cn);
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
            if (dataGridView1.Columns.Count <= 14)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل' ,ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever Where Name like N'%" + txtName.Text + "%' ", cn);
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
            DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل' ,ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever Where ReceiverID like '%" + txtID.Text + "%' ", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            print();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
            EnabelEditAndClear();
            dataTabel.Clear();
            if (dataGridView1.Columns.Count <= 14)
            {
                AddCheckBox();
            }
            DataAdapter = new SqlDataAdapter("Select InternalCode as 'كود العميل',case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end 'نوع العميل',ReceiverID as 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever", cn);
            DataAdapter.Fill(dataTabel);
            dataGridView1.DataSource = dataTabel;
            setUpDataGrid();
        }
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            Delete();
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
                        cmd = new SqlCommand("delete from Reciever where InternalCode ='" + s + "' ", cn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            dataTabel.Clear();
            DataAdapter = new SqlDataAdapter("Select InternalCode As 'كود العميل',ReceiverType As 'نوع العميل',ReceiverID As 'الرقم الضريبى',Name as 'اسم العميل' , Country as 'كود الدولة' ,Governate as 'المحافظة',RegoinCity as 'المدينة',Street as 'الشارع',BuildingNumber as 'رقم المبنى',PostCode as 'الرقم البريدى',Floor as 'الدور',Room as 'الغرفة' ,LandMark as 'علامة مميزة',AdditionalInfo as 'معلومات اضافية'  From Reciever", cn);
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
                Edit edit = new Edit();

                edit.txtCode.Text = drowSelected.Cells[1].Value.ToString();
                edit.cmbtype.Text = drowSelected.Cells[2].Value.ToString();
                edit.txtID.Text = drowSelected.Cells[3].Value.ToString();
                edit.txtName.Text = drowSelected.Cells[4].Value.ToString();
                edit.txtCountry.Text = drowSelected.Cells[5].Value.ToString();
                edit.cmbGovernate.Text = drowSelected.Cells[6].Value.ToString();
                edit.txtRegion.Text = drowSelected.Cells[7].Value.ToString();
                edit.txtStreet.Text = drowSelected.Cells[8].Value.ToString();
                edit.txtBuild.Text = drowSelected.Cells[9].Value.ToString();
                edit.txtPostal.Text = drowSelected.Cells[10].Value.ToString();
                edit.txtFloor.Text = drowSelected.Cells[11].Value.ToString();
                edit.txtRoom.Text = drowSelected.Cells[12].Value.ToString();
                edit.txtland.Text = drowSelected.Cells[13].Value.ToString();
                edit.txtInfo.Text = drowSelected.Cells[14].Value.ToString();

                edit.StartPosition = FormStartPosition.CenterScreen;
                edit.ShowDialog();
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
                MessageBox.Show("من فضلك حدد النتائج التى تريد طباعاتها", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ReceiverReport rep = new ReceiverReport();
                foreach (string s in selectedItems)
                {
                    //rep.reportViewer1.Clear();
                    //DataAdapter = new SqlDataAdapter("Select InternalCode,case when ReceiverType = 'B' then 'Business' when ReceiverType = 'P' then 'Person' when  ReceiverType = 'F' then 'Foreign' end ReceiverType ,ReceiverID ,Name  , Country ,Governate ,RegoinCity ,Street ,BuildingNumber,PostCode ,Floor ,Room ,LandMark ,AdditionalInfo  From Reciever Where InternalCode ='" + s + "' ", cn);
                    //DataAdapter.Fill(rep._Egy_TaxDataSet.Reciever);
                    //rep.reportViewer2.RefreshReport();
                    rep.id = s;
                    rep.ShowDialog();
                }
            }
        }
        public void setUpDataGrid()
        {
            for (int i = 1; i <= 14; i++)
            {
                dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
                dataGridView1.Columns[i].HeaderCell.Style.ForeColor = Color.Black;
                dataGridView1.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
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
        #endregion
    }

}
