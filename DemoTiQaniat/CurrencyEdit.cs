using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class CurrencyEdit : Form
    {
        SqlConnection connection2 = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        string currancyId;
        SqlDataReader sqlDataReader;
        public CurrencyEdit(string Currancy)
        {
            currancyId = Currancy;
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            connection2.Open();
            SqlCommand command2 = new SqlCommand("SELECT ID,Code  FROM Currency where Code='" + txtCode.Text + "'", connection2);
            sqlDataReader = command2.ExecuteReader();
            if (!sqlDataReader.Read())
            {
                connection2.Close();
                string currency = txtCode.Text;
                if (currency.Length != 3 || currency == null)
                {
                    MessageBox.Show("من فضلك ضع كود الدولة والمكون من 3 احرف", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();

                }
                else if (txtDesc.Text == "")
                {
                    MessageBox.Show("ادخل الوصف", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDesc.Focus();
                }
                else
                {
                    try
                    {
                        cmd = new SqlCommand("Update Currency set Code='" + txtCode.Text + "',Description=N'" + txtDesc.Text + "' Where ID=" + currancyId + " ", connection2);
                        connection2.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم التعديل بنجاح ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("هناك خطا ما ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection2.Close();
                    }
                }
            }
            else
            {
                connection2.Close();
                MessageBox.Show("هذه العملة موجوده بالفعل ");
            }
           
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
