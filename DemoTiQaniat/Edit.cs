using System;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DemoTiQaniat
{
    public partial class Edit : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        
        public Edit()
        {
            InitializeComponent();   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cmbtype_Validation();
            txtID_Validation();
            txtName_Validation();
            txtCountry_Validation();
            cmbGovernate_Validation();
            txtRegion_Validation();
            txtStreet_Validation();
            txtBuild_Validation();
            if ((txtCode.Text != "" && cmbtype.Text == "Business" && txtID.Text.Length == 9 && txtName.Text != "" && txtCountry.Text != "" && cmbGovernate.Text != ""
                   && txtRegion.Text != "" && txtStreet.Text != "" && txtBuild.Text != "") ||
                   (txtCode.Text != "" && cmbtype.Text == "Person" && txtID.Text == "" && txtName.Text != "" && txtCountry.Text != "" && cmbGovernate.Text != ""
                   && txtRegion.Text != "" && txtStreet.Text != "" && txtBuild.Text != "") ||
                   (txtCode.Text != "" && cmbtype.Text == "Person" && txtID.Text.Length == 14 && txtName.Text != "" && txtCountry.Text != "" && cmbGovernate.Text != ""
                   && txtRegion.Text != "" && txtStreet.Text != "" && txtBuild.Text != "")||
                   (txtCode.Text != "" && cmbtype.Text == "Foreign" && txtID.Text != "" && txtName.Text != "" && txtCountry.Text != "" && cmbGovernate.Text != ""
                   && txtRegion.Text != "" && txtStreet.Text != "" && txtBuild.Text != ""))
            {
                string CustomerType = "";
                if (cmbtype.Text == "Business")
                    CustomerType = "B";
                else if (cmbtype.Text == "Person")
                    CustomerType = "P";
                else if (cmbtype.Text == "Foreign")
                    CustomerType = "F";

                cmd = new SqlCommand("Update Reciever set ReceiverType = '" + CustomerType + "' , ReceiverID ='" + txtID.Text + "',Name =N'" + txtName.Text + "',Country ='" + txtCountry.Text + "',Governate =N'" + cmbGovernate.Text + "',RegoinCity=N'" + txtRegion.Text + "',Street=N'" + txtStreet.Text + "',BuildingNumber ='" + txtBuild.Text + "',PostCode='" + txtPostal.Text + "',Floor='" + txtFloor.Text + "',Room ='" + txtRoom.Text + "',LandMark='" + txtland.Text + "',AdditionalInfo='" + txtInfo.Text + "' where InternalCode='" + txtCode.Text + "' ", cn);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("هناك خطا ما", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnClear_Click(object sender, EventArgs e)
        {
           
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
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        #region Helper
        public void ClearAll()
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtID.Text = "";
            cmbtype.Text = "";
            txtCountry.Text = "";
            cmbGovernate.Text = "";
            txtRegion.Text = "";
            txtStreet.Text = "";
            txtBuild.Text = "";
            txtPostal.Text = "";
            txtFloor.Text = "";
            txtRoom.Text = "";
            txtland.Text = "";
            txtInfo.Text = "";
        }
       
        private void cmbtype_Validation()
        {
            if (cmbtype.Text == "")
            {
                MessageBox.Show("من فضلك حدد نوع العميل", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbtype.Focus();
            }
        }
        private void txtID_Validation()
        {
            string id = txtID.Text;

            if (cmbtype.Text == "Business")
            {
                if (id.Length != 9 || System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
                {
                    MessageBox.Show(" برجاء كتابة الرقم الضريبي المكون من 9 ارقام", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                }
            }
            else if (cmbtype.Text == "Foreign")
            {
                if (id.Length == 0 || System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
                {
                    MessageBox.Show("برجاء كتابة رقم البوليصة او جواز السفر", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                }
            }
            else if (cmbtype.Text == "Person")
            {
                if (txtID.Text != "")
                {
                    if (id.Length != 14 || System.Text.RegularExpressions.Regex.IsMatch(txtID.Text, "[^0-9]"))
                    {
                        MessageBox.Show("يجب وضع الرقم القومى المكون من 14 رقم", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtID.Focus();
                    }
                }
                else if (txtID.Text == "")
                {
                    MessageBox.Show("يجب وضع الرقم القومى اذا تجاوزت قيمه الفاتوره 50 الف", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (cmbtype.Text == "")
            {
                MessageBox.Show("برجاء اختيار نوع العميل", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbtype.Focus();
            }
        }
        private void txtName_Validation()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("برجاء كتابة اسم العميل", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
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
                MessageBox.Show("برجاء كتابة رقم المبنى ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBuild.Focus();
            }
        }

        #endregion

        
    }
}
