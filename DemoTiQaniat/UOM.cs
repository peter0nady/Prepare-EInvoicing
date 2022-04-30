using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class UOM : Form
    {
        SqlConnection cn = new SqlConnection(ConnectionString.Connection());
        SqlCommand cmd;
        SqlDataReader sqlDataReader;
        public UOM()
        {
            InitializeComponent();
        }
        
        private void cmbUnit_TextChanged(object sender, EventArgs e)
        {
            if (cmbUnit.Text != "")
            {
                if (cmbUnit.Text == "2Z")
                {
                    Clear();
                    txtDescEn.Text = "Millivolt ( mV )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "4K")
                {
                    Clear();
                    txtDescEn.Text = "Milliampere ( mA )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "4O")
                {
                    Clear();
                    txtDescEn.Text = "Microfarad ( microF )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "A87")
                {
                    Clear();
                    txtDescEn.Text = "Gigaohm ( GOhm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "A93")
                {
                    Clear();
                    txtDescEn.Text = "Gram/Cubic meter ( g/m3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "A94")
                {
                    Clear();
                    txtDescEn.Text = "Gram/cubic centimeter ( g/cm3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "AMP")
                {
                    Clear();
                    txtDescEn.Text = "Ampere ( A )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "ANN")
                {
                    Clear();
                    txtDescEn.Text = "Years ( yr )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "B22")
                {
                    Clear();
                    txtDescEn.Text = "Kiloampere ( kA )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "B49")
                {
                    Clear();
                    txtDescEn.Text = "Kiloohm ( kOhm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "B75")
                {
                    Clear();
                    txtDescEn.Text = "Megohm ( MOhm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "B78")
                {
                    Clear();
                    txtDescEn.Text = "Megavolt ( MV )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "B84")
                {
                    Clear();
                    txtDescEn.Text = "Microampere ( microA )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "BAR")
                {
                    Clear();
                    txtDescEn.Text = "bar ( bar )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "BBL")
                {
                    Clear();
                    txtDescEn.Text = "Barrel (oil 42 gal.)";
                    txtDescAr.Text = "برميل";
                }
                if (cmbUnit.Text == "BG")
                {
                    Clear();
                    txtDescEn.Text = "Bag ( Bag )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "BO")
                {
                    Clear();
                    txtDescEn.Text = "Bottle ( Bt. )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "BOX")
                {
                    Clear();
                    txtDescEn.Text = "Box";
                    txtDescAr.Text = "صندوق";
                }
                if (cmbUnit.Text == "C10")
                {
                    Clear();
                    txtDescEn.Text = "Millifarad ( mF )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "C39")
                {
                    Clear();
                    txtDescEn.Text = "Nanoampere ( nA )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "C41")
                {
                    Clear();
                    txtDescEn.Text = "Nanofarad ( nF )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "C45")
                {
                    Clear();
                    txtDescEn.Text = "Nanometer ( nm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "C62")
                {
                    Clear();
                    txtDescEn.Text = "Activity unit ( AU )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CA")
                {
                    Clear();
                    txtDescEn.Text = "Canister ( Can )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CMK")
                {
                    Clear();
                    txtDescEn.Text = "Square centimeter ( cm2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CMQ")
                {
                    Clear();
                    txtDescEn.Text = "SCubic centimeter ( cm3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CMT")
                {
                    Clear();
                    txtDescEn.Text = "Centimeter ( cm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CS")
                {
                    Clear();
                    txtDescEn.Text = "Case ( Case )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CT")
                {
                    Clear();
                    txtDescEn.Text = "Carton ( Car )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "CTL")
                {
                    Clear();
                    txtDescEn.Text = "Centiliter ( Cl )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "D10")
                {
                    Clear();
                    txtDescEn.Text = "Siemens per meter ( S/m )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "D33")
                {
                    Clear();
                    txtDescEn.Text = "STesla ( D )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "D41")
                {
                    Clear();
                    txtDescEn.Text = "Ton/Cubic meter ( t/m3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "DAY")
                {
                    Clear();
                    txtDescEn.Text = "Days ( d )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "DMT")
                {
                    Clear();
                    txtDescEn.Text = "Decimeter ( dm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "DRM")
                {
                    Clear();
                    txtDescEn.Text = "DRUM";
                    txtDescAr.Text = "أسطوانة";
                }
                if (cmbUnit.Text == "EA")
                {
                    Clear();
                    txtDescEn.Text = "each (ST) ( ST )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "FAR")
                {
                    Clear();
                    txtDescEn.Text = "Farad ( F )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "FOT")
                {
                    Clear();
                    txtDescEn.Text = "Foot ( Foot )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "FTK")
                {
                    Clear();
                    txtDescEn.Text = "Square foot ( ft2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "FTQ")
                {
                    Clear();
                    txtDescEn.Text = "Cubic foot ( ft3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "G42")
                {
                    Clear();
                    txtDescEn.Text = "Microsiemens per centimeter ( microS/cm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "GL")
                {
                    Clear();
                    txtDescEn.Text = "Gram/liter ( g/l )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "GLL")
                {
                    Clear();
                    txtDescEn.Text = "gallon ( gal )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "GM")
                {
                    Clear();
                    txtDescEn.Text = "Gram/square meter ( g/m2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "GPT")
                {
                    Clear();
                    txtDescEn.Text = "Gallon per thousand";
                    txtDescAr.Text = "جالون/الف";
                }
                if (cmbUnit.Text == "GRM")
                {
                    Clear();
                    txtDescEn.Text = "Gram ( g )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "H63")
                {
                    Clear();
                    txtDescEn.Text = "Milligram/Square centimeter ( mg/cm2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "HHP")
                {
                    Clear();
                    txtDescEn.Text = "Hydraulic Horse Power";
                    txtDescAr.Text = "قوة حصان هيدروليكي";
                }
                if (cmbUnit.Text == "HLT")
                {
                    Clear();
                    txtDescEn.Text = "Hectoliter ( hl )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "HTZ")
                {
                    Clear();
                    txtDescEn.Text = "Hertz (1/second) ( Hz )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "HUR")
                {
                    Clear();
                    txtDescEn.Text = "Hours ( hrs )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "IE")
                {
                    Clear();
                    txtDescEn.Text = "Number of Persons ( PRS )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "INH")
                {
                    Clear();
                    txtDescEn.Text = "Inch ( “ )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "INK")
                {
                    Clear();
                    txtDescEn.Text = "Square inch ( Inch2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "IVL")
                {
                    Clear();
                    txtDescEn.Text = "Interval";
                    txtDescAr.Text = "فترة";
                }
                if (cmbUnit.Text == "JOB")
                {
                    Clear();
                    txtDescEn.Text = "JOB";
                    txtDescAr.Text = "وظيفة";
                }
                if (cmbUnit.Text == "KGM")
                {
                    Clear();
                    txtDescEn.Text = "Kilogram ( KG )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KHZ")
                {
                    Clear();
                    txtDescEn.Text = "Kilohertz ( kHz )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KMH")
                {
                    Clear();
                    txtDescEn.Text = "Kilometer/hour ( km/h )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KMK")
                {
                    Clear();
                    txtDescEn.Text = "Square kilometer ( km2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KMQ")
                {
                    Clear();
                    txtDescEn.Text = "SKilogram/cubic meter ( kg/m3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KMT")
                {
                    Clear();
                    txtDescEn.Text = "Kilometer ( km )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KSM")
                {
                    Clear();
                    txtDescEn.Text = "Kilogram/Square meter ( kg/m2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KVT")
                {
                    Clear();
                    txtDescEn.Text = "Kilovolt ( kV )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "KWT")
                {
                    Clear();
                    txtDescEn.Text = "Kilowatt ( KW )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "LB")
                {
                    Clear();
                    txtDescEn.Text = "pounds";
                    txtDescAr.Text = "رطل";
                }
                if (cmbUnit.Text == "LTR")
                {
                    Clear();
                    txtDescEn.Text = "Liter ( l )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "LVL")
                {
                    Clear();
                    txtDescEn.Text = "Level";
                    txtDescAr.Text = "مستوى";
                }
                if (cmbUnit.Text == "M")
                {
                    Clear();
                    txtDescEn.Text = "Meter ( m )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MAN")
                {
                    Clear();
                    txtDescEn.Text = "Man";
                    txtDescAr.Text = "رجل";
                }
                if (cmbUnit.Text == "MAW")
                {
                    Clear();
                    txtDescEn.Text = "Megawatt ( VA )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MGM")
                {
                    Clear();
                    txtDescEn.Text = "Milligram ( mg )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MHZ")
                {
                    Clear();
                    txtDescEn.Text = "Megahertz ( MHz )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MIN")
                {
                    Clear();
                    txtDescEn.Text = "Minute ( min )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MMK")
                {
                    Clear();
                    txtDescEn.Text = "Square millimeter ( mm2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MMQ")
                {
                    Clear();
                    txtDescEn.Text = "Cubic millimeter ( mm3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MMT")
                {
                    Clear();
                    txtDescEn.Text = "Millimeter ( mm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MON")
                {
                    Clear();
                    txtDescEn.Text = "Months ( Months )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MTK")
                {
                    Clear();
                    txtDescEn.Text = "Square meter ( m2 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "MTQ")
                {
                    Clear();
                    txtDescEn.Text = "Cubic meter ( m3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "OHM")
                {
                    Clear();
                    txtDescEn.Text = "Ohm ( Ohm )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "ONZ")
                {
                    Clear();
                    txtDescEn.Text = "Ounce ( oz )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "PAL")
                {
                    Clear();
                    txtDescEn.Text = "Pascal ( Pa )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "PF")
                {
                    Clear();
                    txtDescEn.Text = "Pallet ( PAL )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "PK")
                {
                    Clear();
                    txtDescEn.Text = "Pack ( PAK )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "PMP")
                {
                    Clear();
                    txtDescEn.Text = "pump";
                    txtDescAr.Text = "مضخة";
                }
                if (cmbUnit.Text == "RUN")
                {
                    Clear();
                    txtDescEn.Text = "run";
                    txtDescAr.Text = "ركض";
                }
                if (cmbUnit.Text == "SH")
                {
                    Clear();
                    txtDescEn.Text = "Shrink ( Shrink )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "SK")
                {
                    Clear();
                    txtDescEn.Text = "Sack";
                    txtDescAr.Text = "كيس";
                }
                if (cmbUnit.Text == "SMI")
                {
                    Clear();
                    txtDescEn.Text = "Mile ( mile )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "ST")
                {
                    Clear();
                    txtDescEn.Text = "Ton (short,2000 lb)";
                    txtDescAr.Text = "طن (قصير,2000)";
                }
                if (cmbUnit.Text == "TNE")
                {
                    Clear();
                    txtDescEn.Text = "Tonne ( t )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "TON")
                {
                    Clear();
                    txtDescEn.Text = "Ton (metric)";
                    txtDescAr.Text = "طن (متري)";
                }
                if (cmbUnit.Text == "VLT")
                {
                    Clear();
                    txtDescEn.Text = "Volt ( V )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "WEE")
                {
                    Clear();
                    txtDescEn.Text = "Weeks ( Weeks )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "WTT")
                {
                    Clear();
                    txtDescEn.Text = "Watt ( W )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "X03")
                {
                    Clear();
                    txtDescEn.Text = "Meter/Hour ( m/h )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "YDQ")
                {
                    Clear();
                    txtDescEn.Text = "Cubic yard ( yd3 )";
                    txtDescAr.Text = "";
                }
                if (cmbUnit.Text == "YRD")
                {
                    Clear();
                    txtDescEn.Text = "Yards ( yd )";
                    txtDescAr.Text = "";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand command2 = new SqlCommand("select ID,TaxUOM from UOM where TaxUOM='" + cmbUnit.Text + "'", cn);
            sqlDataReader = command2.ExecuteReader();
            if (!sqlDataReader.Read())
            {
                cn.Close();
                if (cmbUnit.Text == "")
                {
                    MessageBox.Show(" من فضلك حدد وحده قياس الضرائب", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbUnit.Focus();
                }
                else if (txtUint.Text == "")
                {
                    MessageBox.Show("ادخل وحدة القياس الداخليه ", "حقول فارغة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUint.Focus();
                }
                else
                {
                    cmd = new SqlCommand("Insert Into UOM (InternalUOM,TaxUOM,Description,ArabicDescription) Values (N'" + txtUint.Text + "' ,'" + cmbUnit.Text + "','" + txtDescEn.Text + "',N'" + txtDescAr.Text + "')", cn);
                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم الاضافة بنجاح ", "اضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAll();
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
            else
            {
                cn.Close();
                MessageBox.Show("وحدة القياص موجوده بالفعل ");
            }

        }
        #region Helper
        private void Clear()
        {
            txtDescAr.Text = "";
            txtDescEn.Text = "";
        }
        private void clearAll()
        {
            txtUint.Text = "";
            cmbUnit.Text = "";
            txtDescEn.Text = "";
            txtDescAr.Text = "";
        }

        #endregion
    }
}
