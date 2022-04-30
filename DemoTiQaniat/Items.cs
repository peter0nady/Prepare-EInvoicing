using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class Items : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataReader sqlDataReader;
        public Items()
        {
            InitializeComponent();
            this.ActiveControl = txtInternalCode;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand command2 = new SqlCommand("SELECT *  FROM ItemSetup where InternalCode='" + txtInternalCode.Text + "'", cn);
            sqlDataReader = command2.ExecuteReader();
            if (!sqlDataReader.Read())
            {
                cn.Close();
                txtInternalCode_Validation();
                txtDesc_Validation();
                cmbItem_Validation();
                txtCode_Validation();
                txtPriceEgp_Validation();
                txtPriceFor_Validation();
                txtExchangeCurr_Validation();
                txtDiscountAmount_Validation();
                cmbUnit_Validation();

                if (txtInternalCode.Text != "" && txtDesc.Text != "" && cmbItem.Text != "" && txtCode.Text != "" && txtPriceEgp.Text != "" && txtPriceFor.Text != ""
                    && cmbCurrency.Text != "" && txtExchangeCurr.Text != "" && txtDiscountAmount.Text != "" && cmbUnit.Text != "")
                {
                    decimal discount = 0;
                    cmd = new SqlCommand("Insert Into ItemSetup (InternalCode,Description,ItemType,ItemCode,UnitType,AmountEGP,CurrencySold,AmountSold,CurrencyExchangeRate,DiscountRate,DiscountAmount) Values ('" + txtInternalCode.Text + "',N'" + txtDesc.Text + "','" + cmbItem.Text + "','" + txtCode.Text + "','" + cmbUnit.Text + "'," + txtPriceEgp.Text + ",'" + cmbCurrency.Text + "'," + txtPriceFor.Text + "," + txtExchangeCurr.Text + "," + discount + "," + txtDiscountAmount.Text + ")", cn);
                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم الاضافة بنجاح ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAll();
                    }
                    catch
                    {
                        MessageBox.Show("هناك خطا ما ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }

            }
            else
            {
                cn.Close();
                MessageBox.Show("هذا الصنف موجود بالفعل ");
            }
        }

        private void txtPriceEgp_KeyPress(object sender, KeyPressEventArgs e)
        {
            DicimalValidation(sender, e);
        }
        private void txtPriceFor_KeyPress(object sender, KeyPressEventArgs e)
        {
            DicimalValidation(sender, e);
        }
        private void txtExchangeCurr_KeyPress(object sender, KeyPressEventArgs e)
        {
            DicimalValidation(sender, e);
        }
        private void txtDiscountAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            DicimalValidation(sender, e);
        }
        private void Items_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select Code from Currency";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                cn.Open();
                DataSet Currencyds = new DataSet();
                da.Fill(Currencyds, "Currency");
                cmbCurrency.DisplayMember = "Code";
                cmbCurrency.ValueMember = "Code";
                cmbCurrency.DataSource = Currencyds.Tables["Currency"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }
            finally
            {
                cn.Close();
            }

            try
            {
                string query = "select TaxUOM from UOM";
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                cn.Open();
                DataSet UOMds = new DataSet();
                da.Fill(UOMds, "UOM");
                cmbUnit.DisplayMember = "TaxUOM";
                cmbUnit.ValueMember = "TaxUOM";
                cmbUnit.DataSource = UOMds.Tables["UOM"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }
            finally
            {
                cn.Close();
            }

        }
        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCurrency.Text == "EGP")
            {
                txtPriceFor.Enabled = false;
                txtExchangeCurr.Enabled = false;
                txtPriceFor.Text = "0.00000";
                txtExchangeCurr.Text = "0.00000";
            }
            else
            {
                txtPriceFor.Text = "";
                txtExchangeCurr.Text = "";
                txtPriceFor.Enabled = true;
                txtExchangeCurr.Enabled = true;
            }
        }
        #region Helper
        private void DicimalValidation(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }
        private void clearAll()
        {
            txtInternalCode.Text = "";
            txtDesc.Text = "";
            cmbItem.Text = "";
            txtCode.Text = "";
            cmbUnit.Text = "";
            txtPriceEgp.Text = "";
            cmbCurrency.Text = "";
            txtPriceFor.Text = "";
            txtExchangeCurr.Text = "";
            txtDiscountAmount.Text = "";
            txtPriceFor.Enabled = true;
            txtExchangeCurr.Enabled = true;
        }
        private void txtInternalCode_Validation()
        {
            if (txtInternalCode.Text == "")
            {
                MessageBox.Show("ادخل  الكود الداخلى", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInternalCode.Focus();
            }
        }
        private void txtDesc_Validation()
        {
            if (txtDesc.Text == "")
            {
                MessageBox.Show("برجاء كتابة وصف المنتج ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
            }
        }
        private void cmbItem_Validation()
        {
            if (cmbItem.Text == "")
            {
                MessageBox.Show("برجاء اختيار نوع الكود ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbItem.Focus();
            }
        }
        private void txtCode_Validation()
        {
            if (cmbItem.Text != "")
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("برجاء كتابة الكود ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                }
            }
            else if (cmbItem.Text == "")
            {
                MessageBox.Show("برجاء اختيار كود الصنف", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbItem.Focus();
            }
        }
        private void txtPriceEgp_Validation()
        {
            if (txtPriceEgp.Text == "")
            {
                MessageBox.Show("برجاء كتابه السعر بالجنية المصرى", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPriceEgp.Focus();
            }
        }
        private void txtPriceFor_Validation()
        {
            if (txtPriceFor.Text == "")
            {
                MessageBox.Show("برجاء كتابة السعر بالعملة الاجنبية ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPriceFor.Focus();
            }
        }
        private void txtExchangeCurr_Validation()
        {
            if (txtExchangeCurr.Text == "")
            {
                MessageBox.Show("برجاء كتابة معدل تحويل العملة ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtExchangeCurr.Focus();
            }
        }
        private void txtDiscountAmount_Validation()
        {
            if (txtDiscountAmount.Text == "")
            {
                MessageBox.Show("يمكنك كتابه قيمة الخصم ان وجدت ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiscountAmount.Text = "0.00000";
            }
        }
        private void cmbUnit_Validation()
        {
            if (cmbUnit.Text == "")
            {
                MessageBox.Show("برجاء اختيار كود الصنف  ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUnit.Focus();
            }
        }
        #endregion

    }
}
