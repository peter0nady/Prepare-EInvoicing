using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class Login : Form
    {
       public static string id;
        public static string name;
        
        public Login()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(ConnectionString.Connection());
        private void txtPass_Leave(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("select * from [Egy-Tax].[dbo].[User] where LoginId=@UserName and Password=@Password ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@UserName", txtID.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int i = cmd.ExecuteNonQuery();


            SqlCommand cmd2 = new SqlCommand("select * from [Egy-Tax].[dbo].[UserRights] where UserLogin=@UserName ", con);
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.AddWithValue("@UserName", txtID.Text);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int ii = cmd2.ExecuteNonQuery();
            con.Close();

            Start s = new Start();

            if (dt.Rows.Count > 0)   //check for user and ps
            {
                if (dt.Rows[0][13].Equals(true))  //chech for active user
                {
                    int res = DateTime.Compare((DateTime)dt.Rows[0][7], DateTime.Now);
                    if (res > 0 || res == 0)    //expirey date 
                    {
                        if (dt.Rows[0][14].Equals(true))  //for change defulat password 
                        {
                            if (dt2.Rows[0][1].ToString() == txtID.Text)  //permission
                            {
                                if (dt2.Rows[9][2].ToString() == "00101005" && dt2.Rows[9][5].Equals(true))
                                {
                                    s.btnIssuer.Enabled = true;
                                }
                                if (dt2.Rows[10][2].ToString() == "0010106" && dt2.Rows[10][5].Equals(true))
                                {
                                    s.btnReciever.Enabled = true;
                                }
                                if (dt2.Rows[11][2].ToString() == "0010107" && dt2.Rows[11][5].Equals(true))
                                {
                                    s.btnItems.Enabled = true;
                                }
                                if (dt2.Rows[12][2].ToString() == "0010108" && dt2.Rows[12][5].Equals(true))
                                {
                                    s.button2.Enabled = true;
                                }
                                if (dt2.Rows[13][2].ToString() == "0010109" && dt2.Rows[13][5].Equals(true))
                                {
                                    s.button1.Enabled = true;
                                }
                                if (dt2.Rows[14][2].ToString() == "00101010" && dt2.Rows[14][5].Equals(true))
                                {
                                    s.btnTax.Enabled = true;
                                }
                                if (dt2.Rows[15][2].ToString() == "00101011" && dt2.Rows[15][5].Equals(true))
                                {
                                    s.btnCurrency.Enabled = true;
                                }
                                if (dt2.Rows[16][2].ToString() == "00101012" && dt2.Rows[16][5].Equals(true))
                                {
                                    s.btnUnit.Enabled = true;
                                }
                                if (dt2.Rows[17][2].ToString() == "00101013" && dt2.Rows[17][5].Equals(true))
                                {
                                    s.btnaccounts.Enabled = true;
                                }
                                id = txtID.Text;
                                name = txtPass.Text;
                                s.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            MessageBox.Show("برجاء تغيير كلمه السر الافتراضية وهى تغير اول مرة فقط ");

                            txtNewps.Visible = true;
                            txtconfirmps.Visible = true;
                            lblnew.Visible = true;
                            lblconfirm.Visible = true;

                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("عفوا, تاريخ هذا الحساب غير صالح");
                    }

                }
                else
                {
                    MessageBox.Show("عفوا, هذا الحساب غير نشط");
                }
            }
            else
            {
                MessageBox.Show("خطا فى الاسم او الرقم السرى");
            }

        }
      
        private void Login_Load(object sender, EventArgs e)
        {
            txtNewps.Visible = false;
            txtconfirmps.Visible = false;
            lblnew.Visible = false;
            lblconfirm.Visible = false;
            
            if(Login.id != null && Login.name != null)
            {
                SqlCommand cmd = new SqlCommand("select * from [Egy-Tax].[dbo].[User] where LoginId=@UserName and Password=@Password ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@UserName", Login.name);
                cmd.Parameters.AddWithValue("@Password", Login.id);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                int i = cmd.ExecuteNonQuery();


                SqlCommand cmd2 = new SqlCommand("select * from [Egy-Tax].[dbo].[UserRights] where UserLogin=@UserName ", con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@UserName", Login.name);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int ii = cmd2.ExecuteNonQuery();
                con.Close();

                Start s = new Start();

                if (dt.Rows.Count > 0)   //check for user and ps
                {
                    if (dt.Rows[0][13].Equals(true))  //chech for active user
                    {
                        int res = DateTime.Compare((DateTime)dt.Rows[0][7], DateTime.Now);
                        if (res > 0 || res == 0)    //expirey date 
                        {
                            if (dt.Rows[0][14].Equals(true))  //for change defulat password 
                            {
                                if (dt2.Rows[0][1].ToString() == Login.name)  //permission
                                {
                                    if (dt2.Rows[9][2].ToString() == "00101005" && dt2.Rows[9][5].Equals(true))
                                    {
                                        s.btnIssuer.Enabled = true;
                                    }
                                    if (dt2.Rows[10][2].ToString() == "0010106" && dt2.Rows[10][5].Equals(true))
                                    {
                                        s.btnReciever.Enabled = true;
                                    }
                                    if (dt2.Rows[11][2].ToString() == "0010107" && dt2.Rows[11][5].Equals(true))
                                    {
                                        s.btnItems.Enabled = true;
                                    }
                                    if (dt2.Rows[12][2].ToString() == "0010108" && dt2.Rows[12][5].Equals(true))
                                    {
                                        s.button2.Enabled = true;
                                    }
                                    if (dt2.Rows[13][2].ToString() == "0010109" && dt2.Rows[13][5].Equals(true))
                                    {
                                        s.button1.Enabled = true;
                                    }
                                    if (dt2.Rows[14][2].ToString() == "00101010" && dt2.Rows[14][5].Equals(true))
                                    {
                                        s.btnTax.Enabled = true;
                                    }
                                    if (dt2.Rows[15][2].ToString() == "00101011" && dt2.Rows[15][5].Equals(true))
                                    {
                                        s.btnCurrency.Enabled = true;
                                    }
                                    if (dt2.Rows[16][2].ToString() == "00101012" && dt2.Rows[16][5].Equals(true))
                                    {
                                        s.btnUnit.Enabled = true;
                                    }
                                    if (dt2.Rows[17][2].ToString() == "00101013" && dt2.Rows[17][5].Equals(true))
                                    {
                                        s.btnaccounts.Enabled = true;
                                    }
                                   
                                    s.ShowDialog();
                                    this.Hide();

                                }

                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("عفوا, تاريخ هذا الحساب غير صالح");
                        }

                    }
                    else
                    {
                        MessageBox.Show("عفوا, هذا الحساب غير نشط");
                    }
                }
                else
                {
                    MessageBox.Show("خطا فى الاسم او الرقم السرى");
                }
            }

            PictureBox pic = new PictureBox();
            pic.Location = new Point(430, 25);
            pic.Size = new Size(140, 81);
            pic.Margin = new Padding(3);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Image = Image.FromFile(@"ectra.JPEG");
            Controls.Add(pic);
        }

        private void txtconfirmps_Leave(object sender, EventArgs e)
        {
            string newpass = txtNewps.Text;
            string confirmpass = txtconfirmps.Text;

            if (!string.IsNullOrEmpty(newpass) && !string.IsNullOrEmpty(confirmpass) && newpass.Equals(confirmpass))
            {
                SqlCommand cmd3 = new SqlCommand("UpdateUserlogin", con);
                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.Parameters.Add("@Userlogin", SqlDbType.VarChar);
                cmd3.Parameters.Add("@password", SqlDbType.VarChar);
                con.Open();

                cmd3.Parameters["@Userlogin"].Value = txtID.Text;
                cmd3.Parameters["@password"].Value = txtNewps.Text;

                cmd3.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("select * from [Egy-Tax].[dbo].[UserRights] where UserLogin=@UserName ", con);
                cmd2.CommandType = CommandType.Text;
                cmd2.Parameters.AddWithValue("@UserName", txtID.Text);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                int ii = cmd2.ExecuteNonQuery();

                con.Close();

                Start s = new Start();

                if (dt2.Rows[0][1].ToString() == txtID.Text)  //permission
                {
                    if (dt2.Rows[9][2].ToString() == "00101005" && dt2.Rows[9][5].Equals(true))
                    {
                        s.btnIssuer.Enabled = true;
                    }
                    if (dt2.Rows[10][2].ToString() == "0010106" && dt2.Rows[10][5].Equals(true))
                    {
                        s.btnReciever.Enabled = true;
                    }
                    if (dt2.Rows[11][2].ToString() == "0010107" && dt2.Rows[11][5].Equals(true))
                    {
                        s.btnItems.Enabled = true;
                    }
                    if (dt2.Rows[12][2].ToString() == "0010108" && dt2.Rows[12][5].Equals(true))
                    {
                        s.button2.Enabled = true;
                    }
                    if (dt2.Rows[13][2].ToString() == "0010109" && dt2.Rows[13][5].Equals(true))
                    {
                        s.button1.Enabled = true;
                    }
                    if (dt2.Rows[14][2].ToString() == "00101010" && dt2.Rows[14][5].Equals(true))
                    {
                        s.btnTax.Enabled = true;
                    }
                    if (dt2.Rows[15][2].ToString() == "00101011" && dt2.Rows[15][5].Equals(true))
                    {
                        s.btnCurrency.Enabled = true;
                    }
                    if (dt2.Rows[16][2].ToString() == "00101012" && dt2.Rows[16][5].Equals(true))
                    {
                        s.btnUnit.Enabled = true;
                    }
                    if (dt2.Rows[17][2].ToString() == "00101013" && dt2.Rows[17][5].Equals(true))
                    {
                        s.btnaccounts.Enabled = true;
                    }
                    name = txtconfirmps.Text;
                    s.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("كلمه السر غير متطابقة");
            }

        }
    }
}
