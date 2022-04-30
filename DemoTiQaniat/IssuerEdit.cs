using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class IssuerEdit : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        public IssuerEdit()
        {
            InitializeComponent();
            this.ActiveControl = cmbEnvironment;
        }
        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            if (txtCountry.Text != "EG")
            {
                cmbGovernate.Items.Clear();
                cmbGovernate.Items.Add("Other");
            }
            else
            {
                cmbGovernate.Items.Clear();

                cmbGovernate.Items.Add("Cairo");
                cmbGovernate.Items.Add("Alex");
                cmbGovernate.Items.Add("Ismalia");
                cmbGovernate.Items.Add("Aswan");
                cmbGovernate.Items.Add("Asuit");
                cmbGovernate.Items.Add("Luxer");
                cmbGovernate.Items.Add("Red Sea");
                cmbGovernate.Items.Add("Behera");
                cmbGovernate.Items.Add("Bani Suef");
                cmbGovernate.Items.Add("Bor Saied");
                cmbGovernate.Items.Add("South Sina");
                cmbGovernate.Items.Add("North Sina");
                cmbGovernate.Items.Add("Giza");
                cmbGovernate.Items.Add("Daqhlea");
                cmbGovernate.Items.Add("Demeat");
                cmbGovernate.Items.Add("Sohag");
                cmbGovernate.Items.Add("Suez");
                cmbGovernate.Items.Add("Sharqia");
                cmbGovernate.Items.Add("Gharbia");
                cmbGovernate.Items.Add("Feyom");
                cmbGovernate.Items.Add("Qaliubia");
                cmbGovernate.Items.Add("Qena");
                cmbGovernate.Items.Add("Kfr ElShekh");
                cmbGovernate.Items.Add("Matroh");
                cmbGovernate.Items.Add("Monfea");
                cmbGovernate.Items.Add("Minia");
                cmbGovernate.Items.Add("Waldy ElGeded");

            }
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {       
            cmbEnvironment_Validation();
            txtName_Validation();
            txtActivity_Validation();
            txtClientID_Validation();
            txtPass1_Validation();
            txtPass2_Validation();
            txtBranch_Validation();
            txtCountry_Validation();
            cmbGovernate_Validation();
            txtRegion_Validation();
            txtStreet_Validation();
            txtBuild_Validation();

            if (cmbEnvironment.Text != "" && txtName.Text != "" && txtActivity.Text != "" && txtClientID.Text != "" && txtPass1.Text != "" &&
                txtPass2.Text != "" && txtBranch.Text != "" && txtCountry.Text != "" && cmbGovernate.Text != "" && txtRegion.Text != "" &&
                txtStreet.Text != "" && txtBuild.Text != "")
            {
                string WalletPath = "", WalletPass = "", CustomerType = "B";
                cmd = new SqlCommand("Update ISSUER_DATA set ENVIROMENT='" + cmbEnvironment.Text + "',BRANCHID =" + txtBranch.Text + ", ISSUER_NAME=N'" + txtName.Text + "',TAXACTIVITYCODE='" + txtActivity.Text + "',CLIENT_ID='" + txtClientID.Text + "',CLIENT_SECRET_1='" + txtPass1.Text + "',CLIENT_SECRET_2='" + txtPass2.Text + "',WALLET_PATH='" + WalletPath + "',WALLET_PASSWORD='" + WalletPass + "' , TYPE = '" + CustomerType + "' ,COUNTRY ='" + txtCountry.Text + "',GOVERNATE ='" + cmbGovernate.Text + "',REGIONCITY=N'" + txtRegion.Text + "',STREET=N'" + txtStreet.Text + "',BUILDINGNUMBER ='" + txtBuild.Text + "',POSTALCODE='" + txtPostal.Text + "',FLOOR='" + txtFloor.Text + "',ROOM ='" + txtRoom.Text + "',LANDMARK='" + txtland.Text + "',ADDITIONALINFO='" + txtInfo.Text + "',IssuerServerIP='" + txtIPServer.Text + "'  Where ISSUER_ID =" + txtID.Text + " ", cn);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {

                    MessageBox.Show("هناك خطا ما تحقق من الرقم الضريبى انه غير مكرر ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region Helper
        private void cmbEnvironment_Validation()
        {
            if (cmbEnvironment.SelectedIndex == -1)
            {
                MessageBox.Show(" من فضلك حدد بيئه العمل ", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEnvironment.Focus();
            }
        }
        private void txtName_Validation()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("ادخل الاسم", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
            }
        }
        private void txtActivity_Validation()
        {
            if (txtActivity.Text == "")
            {
                MessageBox.Show("ادخل كود النشاط", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtActivity.Focus();
            }
            else if (txtActivity.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtActivity.Text, "[^0-9]"))
                {
                    MessageBox.Show("لا يمكنك كتابه حروف فى كود النشاط ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtActivity.Focus();
                }
            }
        }
        private void txtClientID_Validation()
        {
            if (txtClientID.Text == "")
            {
                MessageBox.Show("ادخل كود الممول", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClientID.Focus();
            }
        }
        private void txtPass1_Validation()
        {
            if (txtPass1.Text == "")
            {
                MessageBox.Show("ادخل الرقم السرى 1", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass1.Focus();
            }
        }
        private void txtPass2_Validation()
        {
            if (txtPass2.Text == "")
            {
                MessageBox.Show("ادخل الرقم السرى 2", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPass2.Focus();
            }
        }
        private void txtBranch_Validation()
        {
            if (txtBranch.Text == "")
            {
                MessageBox.Show("من فضلك  حدد رقم الفرع", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBranch.Text = "0";
            }
        }
        private void txtCountry_Validation()
        {
            string country = txtCountry.Text;
            if (country.Length != 2 || country == null)
            {
                MessageBox.Show("من فضلك ضع كود الدولة والمكون من حرفين", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCountry.Focus();
            }
        }
        private void cmbGovernate_Validation()
        {
            if (cmbGovernate.Text == "")
            {
                MessageBox.Show("برجاء اختيار اسم المحافظة", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGovernate.Focus();
            }
        }
        private void txtRegion_Validation()
        {
            if (txtRegion.Text == "")
            {
                MessageBox.Show("برجاء كتابة اسم المنطقة", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRegion.Focus();
            }
        }
        private void txtStreet_Validation()
        {
            if (txtStreet.Text == "")
            {
                MessageBox.Show("برجاء كتابة اسم الشارع", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStreet.Focus();
            }
        }
        private void txtBuild_Validation()
        {
             if (txtBuild.Text == "")
            {
                MessageBox.Show("برجاء كتابة رقم المبنى", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuild.Focus();
            }
        }
        #endregion
    }
}
