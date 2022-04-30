using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class AccountAndPermissionEdit : Form
    {
        SqlConnection con = new SqlConnection(ConnectionString.Connection());
        DataTable RigthAccessdt = new DataTable();
        bool isvalid = true;
        public AccountAndPermissionEdit()
        {
            InitializeComponent();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AccountAndPermission_Load(object sender, EventArgs e)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from [dbo].[User] where LoginId =@LoginId", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@LoginId", txtloginID.Text);
                con.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtpassword.Text = dt.Rows[0][2].ToString();
                txtname.Text = dt.Rows[0][4].ToString();
                dtExpirey.Text = dt.Rows[0][7].ToString();
                checkActive.Checked = Boolean.Parse(dt.Rows[0][13].ToString());

            }
            using (SqlDataAdapter da = new SqlDataAdapter("select Code,[ArabicDescription],[Right_Access] from [dbo].[UserRights] inner join [dbo].[URights] on  [dbo].[UserRights].[RightCode]=[dbo].[URights].[Code] where  UserLogin=@LoginId ", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@LoginId", txtloginID.Text);

                da.Fill(RigthAccessdt);
                con.Close();
            }

            for (int i = 0; i <= RigthAccessdt.Rows.Count - 1; i++)
            {
                dgv.Rows.Add();
                dgv.Rows[i].Cells["code"].Value = RigthAccessdt.Rows[i]["Code"].ToString();
                dgv.Rows[i].Cells["description"].Value = RigthAccessdt.Rows[i]["ArabicDescription"].ToString();
                dgv.Rows[i].Cells["Column1"].Value = RigthAccessdt.Rows[i]["Right_Access"];
            }

        }
        private void dtExpirey_ValueChanged(object sender, EventArgs e)
        {
            if (dtExpirey.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("برجاء ادخال تاريخ صالح");
                isvalid = false;
            }
            else
                isvalid = true;
        }      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtpassword_Validation();
            txtname_Validation();
            if (txtpassword.Text != "" && txtname.Text != "")
            {
                if (isvalid == true)
                {
                    using (SqlCommand command = new SqlCommand("UpdateUser", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@loginID", SqlDbType.VarChar);
                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters.Add("@passwordHint", SqlDbType.VarChar);
                        command.Parameters.Add("@name", SqlDbType.NVarChar);
                        command.Parameters.Add("@memberof", SqlDbType.Int);
                        command.Parameters.Add("@status", SqlDbType.TinyInt);
                        command.Parameters.Add("@Expireydate", SqlDbType.Date);
                        command.Parameters.Add("@lastLogin", SqlDbType.DateTime);
                        command.Parameters.Add("@lastLoginout", SqlDbType.DateTime);
                        command.Parameters.Add("@currentDate", SqlDbType.DateTime);
                        command.Parameters.Add("@employeecode", SqlDbType.Char);
                        command.Parameters.Add("@defulatissue", SqlDbType.VarChar);
                        command.Parameters.Add("@active", SqlDbType.Bit);
                        command.Parameters.Add("@allowinter", SqlDbType.Bit);
                        command.Parameters.Add("@searchdefualt", SqlDbType.VarChar);
                        command.Parameters.Add("@defualtlang", SqlDbType.TinyInt);
                        command.Parameters.Add("@defualtissure", SqlDbType.Bit);
                        command.Parameters.Add("@employeecodenew", SqlDbType.Char);

                        con.Open();

                        command.Parameters["@loginID"].Value = txtloginID.Text;
                        command.Parameters["@password"].Value = txtpassword.Text;
                        command.Parameters["@passwordHint"].Value = null;
                        command.Parameters["@name"].Value = txtname.Text;
                        command.Parameters["@memberof"].Value = 0;
                        command.Parameters["@status"].Value = 1;
                        command.Parameters["@Expireydate"].Value = dtExpirey.Text;
                        command.Parameters["@lastLogin"].Value = null;
                        command.Parameters["@lastLoginout"].Value = null;
                        command.Parameters["@currentDate"].Value = DateTime.Now;
                        command.Parameters["@employeecode"].Value = null;
                        command.Parameters["@defulatissue"].Value = null;
                        command.Parameters["@active"].Value = checkActive.CheckState;
                        command.Parameters["@allowinter"].Value = false;
                        command.Parameters["@searchdefualt"].Value = 0;
                        command.Parameters["@defualtlang"].Value = 0;
                        command.Parameters["@defualtissure"].Value = true;
                        command.Parameters["@employeecodenew"].Value = "";

                        command.ExecuteNonQuery();

                    }

                    using (SqlCommand command2 = new SqlCommand("UpdateUserRights", con))
                    {
                        command2.CommandType = CommandType.StoredProcedure;

                        command2.Parameters.Add("@Userlogin", SqlDbType.VarChar);
                        command2.Parameters.Add("@Rightcode", SqlDbType.VarChar);
                        command2.Parameters.Add("@Issuerid", SqlDbType.NVarChar);
                        command2.Parameters.Add("@categoryid", SqlDbType.Int);
                        command2.Parameters.Add("@Rightaccess", SqlDbType.Bit);
                        command2.Parameters.Add("@sort", SqlDbType.VarChar);


                        for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                        {
                            command2.Parameters["@Userlogin"].Value = txtloginID.Text;
                            command2.Parameters["@Rightcode"].Value = dgv.Rows[i].Cells["code"].Value.ToString();
                            command2.Parameters["@Issuerid"].Value = "";
                            command2.Parameters["@categoryid"].Value = 0;
                            command2.Parameters["@Rightaccess"].Value = Boolean.Parse(dgv.Rows[i].Cells["Column1"].Value.ToString());
                            command2.Parameters["@sort"].Value = "";
                            command2.ExecuteNonQuery();

                        }
                    }
                    con.Close();
                    MessageBox.Show("تمت تحديث المستخدم بنجاح");
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("برجاء التاكد من صحة البيانات المدخله ");
                }
            }
        }

        #region Helper
        private void ClearAll()
        {
            txtloginID.Text = "";
            txtname.Text = "";
            txtpassword.Text = "";
            dtExpirey.Value = DateTime.Now;
            checkActive.Checked = false;
            for (int i = 0; i <= dgv.Rows.Count - 1; i++)
            {
                dgv.Rows[i].Cells["Column1"].Value = false;
            }
        }
        private void txtpassword_Validation()
        {
            if (txtpassword.Text == "")
            {
                MessageBox.Show("برجاء ادخال الرقم السرى");
                txtpassword.Focus();
            }
        }
        private void txtname_Validation()
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("برجاء ادخال اسم المستخدم");
                txtname.Focus();
            }
        }
        #endregion
    }
}
