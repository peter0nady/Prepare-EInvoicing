using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class Currency : Form
    {
        SqlConnection connection2 = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataReader sqlDataReader;
        public Currency()
        {
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
                    cmd = new SqlCommand("Insert Into Currency(Code,Description) Values ('" + txtCode.Text + "',N'" + txtDesc.Text + "')", connection2);
                    try
                    {
                        connection2.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم الاضافة بنجاح ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();

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
        #region Helper
        private void Clear()
        {
            txtCode.Text = "";
            txtDesc.Text = "";
        }
        #endregion
    }
}
