using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoTiQaniat
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            txtCode_Validation();
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
                   && txtRegion.Text != "" && txtStreet.Text != "" && txtBuild.Text != "") ||
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

                cmd = new SqlCommand("Insert Into Reciever(InternalCode,ReceiverType,ReceiverID,Name,Country,Governate,RegoinCity,Street,BuildingNumber,PostCode,Floor,Room,landMark,AdditionalInfo) Values ('" + txtCode.Text + "','" + CustomerType + "','" + txtID.Text + "',N'" + txtName.Text + "','" + txtCountry.Text + "','" + cmbGovernate.Text + "',N'" + txtRegion.Text + "',N'" + txtStreet.Text + "','" + txtBuild.Text + "','" + txtPostal.Text + "','" + txtFloor.Text + "','" + txtRoom.Text + "','" + txtland.Text + "','" + txtInfo.Text + "')", cn);
                try
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الاضافة بنجاح ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAll();
                }
                catch
                {
                    MessageBox.Show("هناك خطا ما تحقق من الكود الداخلى انه غير مكرر", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtCode.Text == "" && cmbtype.Text == "" && txtName.Text == "" && txtID.Text == "" && txtCountry.Text == "" && cmbGovernate.Text == "" && txtRegion.Text == "" && txtStreet.Text == "" && txtBuild.Text == "")
            {
                MessageBox.Show("جميع الحقول فارغه بالفعل", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ClearAll();
            }
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
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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
        private void txtCode_Validation()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("ادخل كود العميل", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCode.Focus();
            }
            else if (txtCode.Text != "")
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtCode.Text, "[^0-9]"))
                {
                    MessageBox.Show("لا يمكنك كتابه حروف هنا ", "تنبيه هام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                }
            }
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
