using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class TaxNameEdit : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        DataTable mytable = new DataTable();
        CheckBox HeaderCheckBox = new CheckBox();
        DataGridViewCheckBoxColumn dgv2 = new DataGridViewCheckBoxColumn();
        SqlDataAdapter DataAdapter;
        DataTable dt = new DataTable();
        string taxId;
        public TaxNameEdit(string TaxId)
        {
            taxId = TaxId;
            InitializeComponent();
        }
        private void cmbType_TextChanged(object sender, EventArgs e)
        {
            if (cmbType.Text != "")
            {
                if (cmbType.Text == "T1")
                {

                    Clear();
                    txtDescEn.Text = "Value added tax";
                    txtDescAr.Text = "ضريبه القيمه المضافه";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("V001", "Export", "تصدير للخارج");
                    createnewrow("V002", "Export to free areas and other areas", "تصدير مناطق حرة وأخرى");
                    createnewrow("V003", "Exempted good or service", "سلعة أو خدمة معفاة");
                    createnewrow("V004", "A non-taxable good or service", "سلعة أو خدمة غير خاضعة للضريبة");
                    createnewrow("V005", "Exemptions for diplomats, consulates and embassies.", "إعفاءات دبلوماسين والقنصليات والسفاراتج");
                    createnewrow("V006", "Defence and National security Exemptions", "إعفاءات الدفاع والأمن القومى ");
                    createnewrow("V007", "Agreements exemptions", "إعفاءات اتفاقيات ");
                    createnewrow("V008", "Special Exemptios and other reasons", "إعفاءات خاصة و أخرى ");
                    createnewrow("V009", "General Item sales", "سلع عامة ");
                    createnewrow("V010", "Other Rates", "سلع عام ");

                }
                if (cmbType.Text == "T2")
                {

                    Clear();
                    txtDescEn.Text = "Table tax (percentage)";
                    txtDescAr.Text = "ضريبه الجدول (نسبيه)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("Tbl01", "Table tax (percentage)", "ضريبه الجدول (نسبيه) ");

                }
                if (cmbType.Text == "T3")
                {
                    Clear();
                    txtDescEn.Text = "Table tax (Fixed Amount)";
                    txtDescAr.Text = "ضريبه الجدول (النوعية)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("Tbl02", "Table tax (Fixed Amount)", "ضريبه الجدول (النوعية) ");

                }
                if (cmbType.Text == "T4")
                {
                    Clear();
                    txtDescEn.Text = "Withholding tax (WHT)";
                    txtDescAr.Text = "الخصم تحت حساب الضريبه";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("W001", "Contracting", "المقاولات");
                    createnewrow("W002", "Supplies", "التوريدات");
                    createnewrow("W003", "Purachases", "المشتريات");
                    createnewrow("W004", "Services", "الخدمات");
                    createnewrow("W005", "Sums paid by the cooperative societies for car transportation to their members", "المبالغ التي تدفعها الجميعات التعاونية للنقل بالسيارات لاعضائها");
                    createnewrow("W006", "Commission agency & brokerage", "الوكالة بالعمولة والسمسرة");
                    createnewrow("W007", "Discounts & grants & additional exceptional incentives granted by smoke & cement companies", "الخصومات والمنح والحوافز الاستثنائية ةالاضافية التي تمنحها شركات الدخان والاسمنت");
                    createnewrow("W008", "All discounts & grants & commissions granted by petroleum & telecommunications & other companies", "جميع الخصومات والمنح والعمولات التي تمنحها شركات البترول والاتصالات … وغيرها من الشركات المخاطبة بنظام الخصم");
                    createnewrow("W009", "Supporting export subsidies", "مساندة دعم الصادرات التي يمنحها صندوق تنمية الصادرات");
                    createnewrow("W010", "Professional fees", "اتعاب مهنية");
                    createnewrow("W011", "Commission & brokerage _A_57", "العمولة والسمسرة _م_57");
                    createnewrow("W012", "Hospitals collecting from doctors", "تحصيل المستشفيات من الاطباء");
                    createnewrow("W013", "Royalties", "الاتاوات");
                    createnewrow("W014", "Customs clearance", "تخليص جمركي");
                    createnewrow("W015", "Exemption", "أعفاء");
                    createnewrow("W016", "Advance payment", "دفعات مقدمه");

                }
                if (cmbType.Text == "T5")
                {
                    Clear();
                    txtDescEn.Text = "Stamping tax (percentage)";
                    txtDescAr.Text = "ضريبه الدمغه (نسبيه)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("ST01", "Stamping tax (percentage)", "ضريبه الدمغه (نسبيه)");

                }
                if (cmbType.Text == "T6")
                {
                    Clear();
                    txtDescEn.Text = "Stamping Tax (amount)";
                    txtDescAr.Text = "ضريبه الدمغه (قطعيه بمقدار ثابت)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("ST02", "Stamping Tax (amount)", "ضريبه الدمغه (قطعيه بمقدار ثابت)");

                }
                if (cmbType.Text == "T7")
                {
                    Clear();
                    txtDescEn.Text = "Entertainment tax";
                    txtDescAr.Text = "ضريبة الملاهى";
                    mytable.Clear();
                    mytable.Columns.Clear();

                    createnewrow("Ent01", "Entertainment tax (rate)", "ضريبة الملاهى (نسبة)");
                    createnewrow("Ent02", "Entertainment tax (amount)", "ضريبة الملاهى (قطعية)");

                }
                if (cmbType.Text == "T8")
                {
                    Clear();
                    txtDescEn.Text = "Resource development fee";
                    txtDescAr.Text = "رسم تنميه الموارد";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("RD01", "Resource development fee (rate)", "رسم تنميه الموارد (نسبة)");
                    createnewrow("RD02", "Resource development fee (amount)", "رسم تنميه الموارد (قطعية)");

                }
                if (cmbType.Text == "T9")
                {
                    Clear();
                    txtDescEn.Text = "Service charges";
                    txtDescAr.Text = "رسم خدمة";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("SC01", "Service charges (rate)", "رسم خدمة (نسبة)");
                    createnewrow("SC02", "Service charges (amount)", "رسم خدمة (قطعية)");

                }
                if (cmbType.Text == "T10")
                {
                    Clear();
                    txtDescEn.Text = "Municipality Fees";
                    txtDescAr.Text = "رسم المحليات";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("Mn01", "Municipality Fees (rate)", "رسم المحليات (نسبة)");
                    createnewrow("Mn02", "Municipality Fees (amount)", "رسم المحليات (قطعية)");

                }
                if (cmbType.Text == "T11")
                {
                    Clear();
                    txtDescEn.Text = "Medical insurance fee";
                    txtDescAr.Text = "رسم التامين الصحى";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("MI01", "Medical insurance fee (rate)", "رسم التامين الصحى (نسبة)");
                    createnewrow("MI02", "Medical insurance fee (amount)", "رسم التامين الصحى (قطعية)");

                }
                if (cmbType.Text == "T12")
                {
                    Clear();
                    txtDescEn.Text = "Other fees";
                    txtDescAr.Text = "رسوم أخرى";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("OF01", "Other fees (rate)", "رسوم أخرى (نسبة)");
                    createnewrow("OF02", "Other fees (amount)", "رسوم أخرى (قطعية)");

                }
                if (cmbType.Text == "T13")
                {
                    Clear();
                    txtDescEn.Text = "Stamping tax (percentage)";
                    txtDescAr.Text = "ضريبه الدمغه (نسبيه)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("ST03", "Stamping tax (percentage)", "ضريبه الدمغه (نسبيه)");

                }
                if (cmbType.Text == "T14")
                {
                    Clear();
                    txtDescEn.Text = "Stamping Tax (amount)";
                    txtDescAr.Text = "ضريبه الدمغه (قطعيه بمقدار ثابت)";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("ST04", "Stamping Tax (amount)", "ضريبه الدمغه (قطعيه بمقدار ثابت)");

                }
                if (cmbType.Text == "T15")
                {
                    Clear();
                    txtDescEn.Text = "Entertainment tax";
                    txtDescAr.Text = "ضريبة الملاهى";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("Ent03", "Entertainment tax (rate)", "ضريبة الملاهى (نسبة)");

                }
                if (cmbType.Text == "T16")
                {
                    Clear();
                    txtDescEn.Text = "Resource development fee";
                    txtDescAr.Text = "رسم تنميه الموارد";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("RD03", "Resource development fee (rate)", "رسم تنميه الموارد (نسبة)");
                    createnewrow("RD04", "Resource development fee (amount)", "رسم تنميه الموارد (قطعية)");

                }
                if (cmbType.Text == "T17")
                {
                    Clear();
                    txtDescEn.Text = "Service charges";
                    txtDescAr.Text = "رسم خدمة";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("SC03", "Service charges (rate)", "رسم خدمة (نسبة)");
                    createnewrow("SC04", "Service charges (amount)", "رسم خدمة (قطعية)");

                }
                if (cmbType.Text == "T18")
                {
                    Clear();
                    txtDescEn.Text = "Municipality Fees";
                    txtDescAr.Text = "رسم المحليات";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("Mn03", "Municipality Fees (rate)", "رسم المحليات (نسبة)");
                    createnewrow("Mn04", "Municipality Fees (amount)", "رسم المحليات (قطعية)");

                }
                if (cmbType.Text == "T19")
                {
                    Clear();
                    txtDescEn.Text = "Medical insurance fee";
                    txtDescAr.Text = "رسم التامين الصحى";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("MI03", "Municipality Fees (rate)", "(رسم التامين الصحى (نسبة");
                    createnewrow("MI04", "Medical insurance fee (amount)", "رسم التامين الصحى (قطعية)");

                }
                if (cmbType.Text == "T20")
                {
                    Clear();
                    txtDescEn.Text = "Other fees";
                    txtDescAr.Text = "رسوم أخرى";
                    mytable.Clear();
                    mytable.Columns.Clear();
                    dgv.Columns.Clear();
                    if (dgv.Columns.Count <= 3)
                    {
                        AddCheckBox();
                    }
                    createnewrow("OF03", "Other fees (rate)", "رسوم أخرى (نسبة)");
                    createnewrow("OF04", "Other fees (amount)", "رسوم أخرى (قطعية)");

                }


            }

        }
        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCheckBoxCell checkbox = (row.Cells["checkbox"] as DataGridViewCheckBoxCell);
                checkbox.Value = HeaderCheckBox.Checked;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("ادخل الاسم الداخلى", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
            else if (cmbType.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك حدد نوع الضريبة", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
            }
            else if (!SelectedTax())
            {
                MessageBox.Show("من فضلك حدد الضريبة الفرعية", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand cmd2 = new SqlCommand("update Tax_Name set InternalName=N'" + txtName.Text + "',TaxName='" + cmbType.Text +
                    "' ,Description='" + txtDescEn.Text + "',ArabicDescription=N'" + txtDescAr.Text + "' where ID =" + taxId + " ", cn);
                cn.Open();
                cmd2.ExecuteNonQuery();
                using (SqlCommand cmd3 = new SqlCommand("delete from Tax_SubTypes where IDTaxName =" + taxId + " ", cn))
                {
                    cmd3.ExecuteNonQuery();
                }
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    if (Convert.ToBoolean(dgv.Rows[i].Cells["checkbox"].EditedFormattedValue) == true)
                    {
                        cmd = new SqlCommand("Insert into Tax_SubTypes(SubType,Description,ArabicDescription,IDTaxName) Values ('" + dgv.Rows[i].Cells[1].Value +
                            "','" + dgv.Rows[i].Cells[2].Value + "',N'" + dgv.Rows[i].Cells[3].Value + "'," + taxId + ")", cn);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show(" تم التعديل بنجاح  ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAll();
                cn.Close();
            }

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                bool isChecked = true;
                foreach (DataGridViewRow row in dgv.Rows)
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
        private void TaxNameEdit_Load(object sender, EventArgs e)
        {
            using (SqlCommand com = new SqlCommand("select IdSub,SubType from Tax_SubTypes where IDTaxName='" + taxId + "' ", cn))
            {
                com.CommandType = CommandType.Text;
                DataAdapter = new SqlDataAdapter(com);
                DataAdapter.Fill(dt);
            }
            for (int x = 0; x <= dt.Rows.Count - 1; x++)
            {
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    if (dt.Rows[x][1].ToString() == dgv.Rows[i].Cells[1].Value.ToString())
                    {
                        dgv.Rows[i].Cells["checkbox"].Value = true;
                        break;
                    }

                }
            }
        }
        #region Helper
        public bool SelectedTax()
        {
            bool taxs = false;
            List<string> selectedItems = new List<string>();
            DataGridViewRow drow = new DataGridViewRow();
            DataGridViewRow drowSelected = new DataGridViewRow();

            for (int i = 0; i <= dgv.Rows.Count - 1; i++)
            {
                drow = dgv.Rows[i];

                if (Convert.ToBoolean(drow.Cells[0].Value) == true)
                {
                    string id = drow.Cells[1].Value.ToString();
                    selectedItems.Add(id);
                    drowSelected = dgv.Rows[i];
                }
            }
            if (selectedItems.Count > 0)
                taxs = true;
            return taxs;
        }
        private void Clear()
        {
            txtDescEn.Text = "";
            txtDescAr.Text = "";
        }
        private void ClearAll()
        {
            txtName.Text = "";
            cmbType.Text = "";
            txtDescEn.Text = "";
            txtDescAr.Text = "";
            dgv.Columns.Clear();
            dgv.Controls.Clear();
        }
        private void AddCheckBox()
        {
            HeaderCheckBox.Location = new Point(50, 4);
            HeaderCheckBox.BackColor = Color.White;
            HeaderCheckBox.Size = new Size(15, 15);
            dgv.Controls.Add(HeaderCheckBox);

            HeaderCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);

            dgv2.HeaderText = "";
            dgv2.Width = 30;
            dgv2.Name = "checkbox";
            dgv2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns.Insert(0, dgv2);

            dgv.CellContentClick += new DataGridViewCellEventHandler(dgv_CellClick);
        }
        private void createnewrow(string taxname, string EnDes, string ArDes)
        {
            if (mytable.Rows.Count > 0)
            {
                DataRow dr = null;
                dr = mytable.NewRow();
                dr["الضريبة الفرعية"] = taxname;
                dr["الوصف"] = EnDes;
                dr["الوصف بالعربى"] = ArDes;
                mytable.Rows.Add(dr);

                dgv.DataSource = mytable;

            }
            else
            {

                mytable.Columns.Add("الضريبة الفرعية", typeof(string));
                mytable.Columns.Add("الوصف", typeof(string));
                mytable.Columns.Add("الوصف بالعربى", typeof(string));

                DataRow dr1 = mytable.NewRow();
                dr1 = mytable.NewRow();
                dr1["الضريبة الفرعية"] = taxname;
                dr1["الوصف"] = EnDes;
                dr1["الوصف بالعربى"] = ArDes;
                mytable.Rows.Add(dr1);

                dgv.DataSource = mytable;
            }

        }
        #endregion
    }
}
