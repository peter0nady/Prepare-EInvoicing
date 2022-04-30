using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoTiQaniat
{
    public partial class InvoiceDataFormat : Form
    {
        SqlConnection connection = new SqlConnection(ConnectionString.Connection());
        DataSet Taxesds = new DataSet();
        List<int> listOfDeletedTaxLine = new List<int>();
        bool IsLoaded = false;
        decimal totalamount = 0;
        decimal itemdisc = 0;
        bool IsValidtax = true;
        bool IsValid = true;
        bool btnAddClicked = false;
        bool LineExist = false;
        bool IsRepeat = false;
        bool repeat = false;
        bool messageRepeated = false;
        DataTable InvLIneDT = new DataTable();
        SqlDataReader sqlDataReader;
        public InvoiceDataFormat()
        {
            InitializeComponent();
        }
        private void InvoiceDataFormat_Load(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                string query = "select InternalCode from Reciever";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "Reciever");
                cmbInternal.DisplayMember = "InternalCode";
                cmbInternal.ValueMember = "InternalCode";
                cmbInternal.DataSource = ds.Tables["Reciever"];

                cmbInternal.SelectedItem = null;
                ClearCustomerData();
                cmbInternal.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbInternal.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }

            try
            {
                string query = "select Name from Reciever";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "Reciever");
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Name";
                cmbName.DataSource = ds.Tables["Reciever"];

                cmbName.SelectedItem = null;
                ClearCustomerData();
                cmbName.AutoCompleteMode = AutoCompleteMode.Suggest;
                cmbName.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }

            try
            {
                string query = " select ID,TaxName,ArabicDescription from Tax_Name";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.Fill(Taxesds, "Tax_Name");
                TAXTYPE.DisplayMember = "ArabicDescription";
                TAXTYPE.ValueMember = "ID";
                TAXTYPE.DataSource = Taxesds.Tables["Tax_Name"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }

            try
            {
                string queryIssuer = "select ISSUER_ID from ISSUER_DATA";
                SqlDataAdapter da = new SqlDataAdapter(queryIssuer, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "ISSUER_DATA");
                cmbIID.DisplayMember = "ISSUER_ID";
                cmbIID.ValueMember = "ISSUER_ID";
                cmbIID.DataSource = ds.Tables["ISSUER_DATA"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }

            try
            {
                string query = " select InternalCode from ItemSetup";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "ItemSetup");
                INTERNALCODE.DisplayMember = "InternalCode";
                INTERNALCODE.ValueMember = "InternalCode";
                INTERNALCODE.DataSource = ds.Tables["ItemSetup"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured!" + ex);
            }

            try
            {
                string queryIssuer = "select Code from Currency";
                SqlDataAdapter da = new SqlDataAdapter(queryIssuer, connection);
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
            IsLoaded = true;
            this.ActiveControl = txtHeaderID;
            cmbType.SelectedItem = "فاتورة";
            InvLIneDT.Columns.Add("TRX_LINE_ID");
        }
        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (IsValid == true && IsRepeat == false)
            {
                if (txttotalDiscount.Text != "" && txttotalSales.Text != "" && txtnetTotal.Text != "" && txttotalAmount.Text != "" && txttotalitemDiscount.Text != "")
                {
                    if (e.ColumnIndex == 1 && e.RowIndex > -1)
                    {

                        if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() != "")
                        {
                            using (SqlCommand cmd = new SqlCommand("select Description,ItemCode,ItemType,UnitType,AmountEGP,AmountSold,DiscountAmount from ItemSetup where InternalCode = '" + dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue + "' "))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = connection;
                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    sdr.Read();
                                    dgv.Rows[e.RowIndex].Cells["DESCRIPTION"].Value = sdr["Description"].ToString();
                                    dgv.Rows[e.RowIndex].Cells["ITEMTYPE"].Value = sdr["ItemType"].ToString();
                                    dgv.Rows[e.RowIndex].Cells["ITEMCODE"].Value = sdr["ItemCode"].ToString();
                                    dgv.Rows[e.RowIndex].Cells["UNITTYPE"].Value = sdr["UnitType"].ToString();
                                    dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value = sdr["AmountEGP"].ToString();
                                    dgv.Rows[e.RowIndex].Cells["ITEMSDISCOUNT"].Value = "0";
                                    dgv.Rows[e.RowIndex].Cells["VALUEDIFFERENCE"].Value = "0";
                                    dgv.Rows[e.RowIndex].Cells["TOTALTAXABLEFEES"].Value = "0";
                                    dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value = sdr["DiscountAmount"].ToString();

                                    itemdisc += decimal.Parse(dgv.Rows[e.RowIndex].Cells["ITEMSDISCOUNT"].Value?.ToString());
                                }
                            }
                            dgv.Rows[e.RowIndex].Cells["CURRENCYSOLD"].Value = cmbCurrency.Text;
                        }
                        if (cmbCurrency.Text == "EGP")
                        {
                            dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].ReadOnly = true;
                            dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].ReadOnly = true;
                            dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].ReadOnly = false;

                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].ReadOnly = true;
                            dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].ReadOnly = false;
                            dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].ReadOnly = false;
                        }

                    }
                    else if (e.ColumnIndex == 8 && e.RowIndex > -1)
                    {
                        if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() != "")
                        {
                            if (dgv.Rows[e.RowIndex].Cells["CURRENCYSOLD"].EditedFormattedValue.ToString() == "EGP")
                            {
                                dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value = "0";
                                dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value = "0";

                            }
                            else
                            {

                                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].EditedFormattedValue.ToString() != "" && dgv.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].EditedFormattedValue.ToString() != "")
                                {
                                    dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex + 2].EditedFormattedValue.ToString();
                                    dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].EditedFormattedValue.ToString();

                                }
                            }
                        }
                    }
                    else if ((e.ColumnIndex == 10 && e.RowIndex > -1 && dgv.Rows[e.RowIndex].Cells[10].IsInEditMode == true) ||
                        (e.ColumnIndex == 11 && e.RowIndex > -1 && dgv.Rows[e.RowIndex].Cells[11].IsInEditMode == true))
                    {
                        if (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null)
                        {
                            MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل  كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                dgv.Rows.RemoveAt(e.RowIndex);
                                InvLIneDT.Rows.RemoveAt(e.RowIndex);

                                InvoiceLinesCount.DataSource = InvLIneDT;

                            }));
                            messageRepeated = true;
                        }
                        else
                        {
                            if (dgv.Rows[e.RowIndex].Cells["CURRENCYSOLD"].EditedFormattedValue.ToString() != "EGP")
                            {
                                dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value?.ToString() == null ?
                                    0.ToString() : dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value?.ToString()) *
                                    decimal.Parse(dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value?.ToString() == null ?
                                    0.ToString() : dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value?.ToString());

                                dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString() == null ?
                                    0.ToString() : dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString()) * decimal.Parse(dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value?.ToString());

                                dgv.Rows[e.RowIndex].Cells["NetTota"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value?.ToString()) - decimal.Parse(dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value?.ToString());

                                decimal tot = 0;
                                for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
                                {
                                    if (dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString())
                                    {
                                        dgvTaxLine.Rows[i].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[i].Cells["RATE"].Value?.ToString()) / 100) *
                                            decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());

                                        tot += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                                        CalcTaxByTypeAndLine(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()), dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString());
                                    }
                                   
                                }
                                dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = tot + decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());
                            }
                        }
                    }
                    else if (e.ColumnIndex == 6 && e.RowIndex > -1 )
                    {
                        if (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null)
                        {
                            MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                dgv.Rows.RemoveAt(e.RowIndex);
                                InvLIneDT.Rows.RemoveAt(e.RowIndex);

                                InvoiceLinesCount.DataSource = InvLIneDT;

                            }));
                            messageRepeated = true;
                        }
                        else
                        {
                            messageRepeated = false;
                            dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString() == null ?
                                0.ToString() : dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString()) * decimal.Parse(dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value?.ToString());

                            dgv.Rows[e.RowIndex].Cells["NetTota"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value?.ToString()) - decimal.Parse(dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value?.ToString());

                            decimal tot = 0;
                            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
                            {
                            
                                if (dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString())
                                {
                                    dgvTaxLine.Rows[i].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[i].Cells["RATE"].Value?.ToString()) / 100) *
                                        decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());

                                    tot += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                                    CalcTaxByTypeAndLine(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()), dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString());
                                }
                            }
                            dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = tot + decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());
                        }
                    }
                    else if (e.ColumnIndex == 7 && e.RowIndex > -1 && dgv.Rows[e.RowIndex].Cells[7].IsInEditMode == true && dgv.Rows[e.RowIndex].Cells[6].Value != null && dgv.Rows[e.RowIndex].Cells[7].Value != null)
                    {
                        if (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null)
                        {
                            MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل  كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                dgv.Rows.RemoveAt(e.RowIndex);
                                InvLIneDT.Rows.RemoveAt(e.RowIndex);

                                InvoiceLinesCount.DataSource = InvLIneDT;

                            }));
                            messageRepeated = true;
                        }
                        else
                        {
                            messageRepeated = false;
                            dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString() == null ?
                                0.ToString() : dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString()) * decimal.Parse(dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value?.ToString());

                            dgv.Rows[e.RowIndex].Cells["NetTota"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value?.ToString()) - decimal.Parse(dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value?.ToString());

                            decimal tot = 0;
                            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
                            {
                                if (dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString())
                                {
                                    dgvTaxLine.Rows[i].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[i].Cells["RATE"].Value?.ToString()) / 100) *
                                        decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());

                                    tot += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                                    CalcTaxByTypeAndLine(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()), dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString());
                                }
                            }
                            dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = tot + decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());
                        }
                    }
                    else if (e.ColumnIndex == 17 && e.RowIndex > -1 && dgv.Rows[e.RowIndex].Cells[17].IsInEditMode == true && dgv.Rows[e.RowIndex].Cells[17].Value != null)
                    {
                        if (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null)
                        {
                            MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل  كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                dgv.Rows.RemoveAt(e.RowIndex);
                                InvLIneDT.Rows.RemoveAt(e.RowIndex);

                                InvoiceLinesCount.DataSource = InvLIneDT;

                            }));
                            messageRepeated = true;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].Cells["NetTota"].Value = decimal.Parse(dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value?.ToString()) - decimal.Parse(dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value?.ToString());
                            decimal tot = 0;
                            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
                            {
                                if (dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString())
                                {
                                    dgvTaxLine.Rows[i].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[i].Cells["RATE"].Value?.ToString()) / 100) *
                                        decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());

                                    tot += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                                    CalcTaxByTypeAndLine(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()), dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString());
                                }
                            }
                            dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = tot + decimal.Parse(dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString());
                        }
                    }
                    else if (e.ColumnIndex == 2 && e.RowIndex > -1)
                    {
                        if (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null)
                        {
                            MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل  كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                            BeginInvoke(new MethodInvoker(delegate
                            {
                                dgv.Rows.RemoveAt(e.RowIndex);
                                InvLIneDT.Rows.RemoveAt(e.RowIndex);

                                InvoiceLinesCount.DataSource = InvLIneDT;

                            }));
                            messageRepeated = true;
                        }
                    }

                    CalcTotals();

                }
                else
                {
                    txttotalDiscount.Text = "0";
                    txttotalSales.Text = "0";
                    txtnetTotal.Text = "0";
                    txttotalAmount.Text = "0";
                    txttotalitemDiscount.Text = "0";

                }
            }
            else
            {
                return;
            }
        }
        private void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgv.IsCurrentCellDirty)
            {
                if (e.ColumnIndex == 6)
                {

                    if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكميه");
                        IsValid = false;
                    }
                    else
                        IsValid = true;

                }
                else if (e.ColumnIndex == 7)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل السعر بالجنية المصرى ");
                        IsValid = false;
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), @"^[.1-9]\d*(\.\d+)?$"))
                    {
                        MessageBox.Show("من فضلك ادخل السعر بالجنية المصرى وتكون قيمة عدديه");
                        IsValid = false;
                        dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value = "0.00000";
                        dgv.Rows[e.RowIndex].Cells["NetTota"].Value = "0.00000";
                        dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = "0.00000";
                        CalcTotals();

                    }
                    else
                        IsValid = true;
                }

                else if (e.ColumnIndex == 9)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل السعر  بالعمله الاجنبيه ");
                        IsValid = false;
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), @"^[+]?([.]\d+|\d+[.]?\d*)$"))
                    {
                        MessageBox.Show("من فضلك ادخل السعر  بالعمله الاجنبيه وتكون قيمة عدديه");
                        IsValid = false;
                    }
                    else
                        IsValid = true;
                }
                else if (e.ColumnIndex == 10)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل معدل تحويل العملة");
                        IsValid = false;
                    }

                    else if (!System.Text.RegularExpressions.Regex.IsMatch(dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), @"^[+]?([.]\d+|\d+[.]?\d*)$"))
                    {
                        MessageBox.Show("من فضلك ادخل معدل تحويل العملة وتكون قيمة عدديه");
                        IsValid = false;
                    }
                    else
                        IsValid = true;
                }
                else if (e.ColumnIndex == 17)
                {
                    if (dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل قيمة الخصم ");
                        IsValid = false;
                    }
                    else if (!System.Text.RegularExpressions.Regex.IsMatch(dgv[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString(), @"^[+]?([.]\d+|\d+[.]?\d*)$"))
                    {
                        MessageBox.Show("من فضلك ادخل قيمة الخصم وتكون قيمة عدديه");
                        IsValid = false;

                    }
                    else
                        IsValid = true;
                }

            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgv.Columns.Count - 1 && dgv.Rows[e.RowIndex].IsNewRow == false)
            {

                for (int r = 0; r <= dgvTaxLine.Rows.Count - 2; r++)
                {
                    if (int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()) == int.Parse(dgvTaxLine.Rows[r].Cells["InvoiceLinesCount"].Value?.ToString()))
                    {
                        LineExist = true;
                        break;
                    }
                    else
                    {
                        LineExist = false;
                    }
                }
                if (dgvTaxLine.Rows.Count > 1)
                {
                    if (dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString() == null)
                    {
                        LineExist = false;
                    }
                }
                if (LineExist == false)
                {
                    if (dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value?.ToString() == null)
                    {
                        dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value = 0;
                    }
                    else if (dgv.Rows[e.RowIndex].Cells["TOTAL"].Value?.ToString() == null)
                    {
                        dgv.Rows[e.RowIndex].Cells["TOTAL"].Value = 0;
                    }
                    else if (dgv.Rows[e.RowIndex].Cells["NetTota"].Value?.ToString() == null)
                    {
                        dgv.Rows[e.RowIndex].Cells["NetTota"].Value = 0;
                    }
                    else if (dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value?.ToString() == null)
                    {
                        dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value = 0;
                    }
                    else if (dgv.Rows[e.RowIndex].Cells["ITEMSDISCOUNT"].Value?.ToString() == null)
                    {
                        dgv.Rows[e.RowIndex].Cells["ITEMSDISCOUNT"].Value = 0;
                    }
                    else
                    {
                        var exist = listOfDeletedTaxLine.Exists(x => x.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString());
                        if (!exist)
                        {
                            listOfDeletedTaxLine.Add(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()));
                        }

                        dgv.Rows.RemoveAt(e.RowIndex);                       
                        InvLIneDT.Rows.RemoveAt(e.RowIndex);
                        InvoiceLinesCount.DataSource = InvLIneDT;                  
                        CalcTotals();
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString() +
                        " : يرجى العلم انه سيتم حذف سطور الضريبه الخاصه بسطر الفاتورة", "تحذير", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        int taxLineCount = dgvTaxLine.Rows.Count - 2;
                        for (int i = taxLineCount; i >= 0; i--)
                        {
                            if (dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString() == dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString())
                            {
                                int taxHeaderCount = dTaxHeader.Rows.Count - 1;
                                for (int tx = taxHeaderCount; tx >= 0; tx--)
                                {
                                    if (dTaxHeader.Rows[tx].Cells["TaxTypeHeader"].EditedFormattedValue.ToString() == dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString())
                                    {
                                        dTaxHeader.Rows[tx].Cells["AmountHeader"].Value = decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) -
                                            decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());

                                        if (decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) == 0)
                                        {
                                            dTaxHeader.Rows.RemoveAt(tx);
                                        }
                                        break;
                                    }
                                }
                                dgvTaxLine.Rows.RemoveAt(i);
                            }
                        }
                        var exist = listOfDeletedTaxLine.Exists(x => x.ToString() == dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString());
                        if (!exist)
                        {
                            listOfDeletedTaxLine.Add(int.Parse(dgv.Rows[e.RowIndex].Cells["InvoiceLine"].Value?.ToString()));
                        }
                        dgv.Rows.RemoveAt(e.RowIndex);
                        InvLIneDT.Rows.RemoveAt(e.RowIndex);
                        InvoiceLinesCount.DataSource = InvLIneDT;
                        
                        CalcTotals();
                        CalcTaxAmount();
                    }
                }

            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgv_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == 6 || dgv.CurrentCell.ColumnIndex == 7 || dgv.CurrentCell.ColumnIndex == 9
                || dgv.CurrentCell.ColumnIndex == 10 || dgv.CurrentCell.ColumnIndex == 11 || dgv.CurrentCell.ColumnIndex == 12
                || dgv.CurrentCell.ColumnIndex == 13 || dgv.CurrentCell.ColumnIndex == 14 || dgv.CurrentCell.ColumnIndex == 15
                || dgv.CurrentCell.ColumnIndex == 16 || dgv.CurrentCell.ColumnIndex == 17) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgv_KeyPress);
                }
            }
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = AutoCompleteMode.Suggest;
            }


        }
        private void dgv_Click(object sender, EventArgs e)
        {
            if (txtHeaderID.Text == "" || cmbInternal.Text == "" || cmbName.Text == "")
            {
                MessageBox.Show("براجاء ادخال البيانات المطلوبه للفاتوره", "حقول فارغة", MessageBoxButtons.OK);
            }
            else
            {
                return;
            }
        }
        private void dgv_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!messageRepeated)
            {
                if ((dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null &&
                    dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value?.ToString() != null) ||
                    (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null &&
                    dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value?.ToString() != null) ||
                    (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null &&
                    dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value?.ToString() != null) ||
                    (dgv.Rows[e.RowIndex].Cells["INTERNALCODE"].Value?.ToString() == null &&
                    dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value?.ToString() != null))
                {
                    MessageBox.Show("برجاء اختيار كود الصنف الداخلى قبل كتابة البيانات لتكوين فاتورة صحيحة ", "تحذير");
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        dgv.Rows.RemoveAt(e.RowIndex);
                        InvLIneDT.Rows.RemoveAt(e.RowIndex);

                        InvoiceLinesCount.DataSource = InvLIneDT;

                    }));
                }
                else
                {
                    bool taxLineExist = false;
                    if (e.RowIndex > 0)
                    {
                        for (int i = 0; i < dgvTaxLine.Rows.Count - 1; i++)
                        {
                            if (dgv.Rows[e.RowIndex - 1].Cells["InvoiceLine"].Value?.ToString() == dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString())
                            {
                                taxLineExist = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        taxLineExist = true;
                    }
                    if (!taxLineExist)
                    {
                        MessageBox.Show("برجاء ادخال الضريبه الخاصه بهذا السطر قبل اضافة سطر جديد ", "تحذير");
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            dgv.Rows.RemoveAt(e.RowIndex);
                            InvLIneDT.Rows.RemoveAt(e.RowIndex);
                            InvoiceLinesCount.DataSource = InvLIneDT;
                            
                        }));
                    }
                }
            }
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            if (btnAddClicked == false)
            {
                if (listOfDeletedTaxLine.Count != 0)
                {
                    listOfDeletedTaxLine.Sort();
                    foreach (var item in listOfDeletedTaxLine)
                    {
                        dgv.Rows[e.RowIndex - 1].Cells["InvoiceLine"].Value = item;
                        listOfDeletedTaxLine.Remove(item);

                        break;
                    }
                }
                else
                {
                    dgv.Rows[e.RowIndex - 1].Cells["InvoiceLine"].Value = e.RowIndex;
                }
                InvLIneDT.Rows.Clear();
                for (int h = 0; h < dgv.Rows.Count - 1; h++)
                {
                    InvLIneDT.Rows.Add(dgv.Rows[h].Cells["InvoiceLine"].Value?.ToString());
                    InvoiceLinesCount.DataSource = InvLIneDT;
                    InvoiceLinesCount.DisplayMember = "TRX_LINE_ID";
                    InvoiceLinesCount.ValueMember = "TRX_LINE_ID";
                }
            }
            else
            {
                return;
            }
        }
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["QUANTITY"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString() == null ? 0.ToString() : e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 7 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["AMOUNTEGP"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 9 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["AMOUNTSOLD"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 10 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["CURRENCYEXCHANGERATE"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 11 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["SALESTOTAL"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 12 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["NetTota"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 13 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["TOTAL"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 14 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["ITEMSDISCOUNT"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 15 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["VALUEDIFFERENCE"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 16 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["TOTALTAXABLEFEES"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
            else if (e.ColumnIndex == 17 && e.RowIndex != this.dgv.NewRowIndex)
            {
                if (dgv.Rows[e.RowIndex].Cells["DISCOUNT_AMOUNT"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }

        }
        private void dgv_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 1 && dgv.CurrentCell.Value != null)
            {
                foreach (DataGridViewRow row in this.dgv.Rows)
                {
                    if (row.Index == this.dgv.CurrentCell.RowIndex)
                    { continue; }

                    if (this.dgv.CurrentCell.Value == null)
                    { continue; }


                    if (row.Cells[1].Value != null && row.Cells[1].Value?.ToString() == dgv.CurrentCell.Value?.ToString())
                    {

                        IsRepeat = true;
                        MessageBox.Show("الكود الداخلى الذى تريد اضافته موجود بالفعل");
                        dgv.CurrentCell.Value = null;
                    }
                    else
                    {
                        IsRepeat = false;
                        dgv_CellValueChanged(sender, e);
                    }


                }
            }
        }
        private void dgvTaxLine_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvTaxLine_KeyPress);
            if (dgvTaxLine.CurrentCell.ColumnIndex == 3) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvTaxLine_KeyPress);
                }
            }
        }
        private void dgvTaxLine_KeyPress(object sender, KeyPressEventArgs e)
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
        private void dgvTaxLine_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (IsValidtax == true && repeat == false)
            {
                if (e.RowIndex > -1)
                {
                    if (dgvTaxLine.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        if (e.ColumnIndex == 1 && e.RowIndex > -1)
                        {
                            if (dgvTaxLine[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() != "")
                            {
                                using (SqlCommand cmd = new SqlCommand("select SubType,ArabicDescription from Tax_SubTypes where IDTaxName = " + int.Parse(dgvTaxLine[e.ColumnIndex, e.RowIndex].Value?.ToString()) + " "))
                                {
                                    cmd.CommandType = CommandType.Text;
                                    cmd.Connection = connection;
                                    SqlDataAdapter da = new SqlDataAdapter(cmd.CommandText, connection);
                                    DataSet ds = new DataSet();
                                    ds.Clear();
                                    da.Fill(ds, "Tax_SubTypes");
                                    ((DataGridViewComboBoxCell)dgvTaxLine.Rows[e.RowIndex].Cells[2]).DisplayMember = "ArabicDescription";
                                    ((DataGridViewComboBoxCell)dgvTaxLine.Rows[e.RowIndex].Cells[2]).ValueMember = "SubType";
                                    ((DataGridViewComboBoxCell)dgvTaxLine.Rows[e.RowIndex].Cells[2]).DataSource = ds.Tables["Tax_SubTypes"];
                                }
                            }
                        }

                        CalcTaxAmount();
                    }
                    else
                    {
                        dgvTaxLine.Rows[e.RowIndex].Cells[1].Value = null;
                    }

                }
            }
            else
            {
                return;
            }
        }
        private void dgvTaxLine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == dgvTaxLine.Columns.Count - 1 && dgvTaxLine.Rows[e.RowIndex].IsNewRow == false)
            {

                if (dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString() == null)
                {
                    dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value = 0;
                }
                else
                {
                    for (int w = 0; w < dgv.Rows.Count - 1; w++)
                    {
                        if (dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[w].Cells["InvoiceLine"].Value?.ToString())
                        {
                            dgv.Rows[w].Cells["TOTAL"].Value = decimal.Parse(dgv.Rows[w].Cells["TOTAL"].Value?.ToString()) - decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString());
                            break;
                        }
                    }

                    totalamount -= decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString());

                    txttotalAmount.Text = totalamount.ToString();

                    for (int tx = 0; tx <= dTaxHeader.Rows.Count - 1; tx++)
                    {
                        if (dTaxHeader.Rows[tx].Cells["TaxTypeHeader"].EditedFormattedValue.ToString() == dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue.ToString())
                        {
                            dTaxHeader.Rows[tx].Cells["AmountHeader"].Value = decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) - decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString());

                            if (decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) == 0)
                            {
                                dTaxHeader.Rows.RemoveAt(tx);
                            }
                            break;
                        }
                    }
                    dgvTaxLine.Rows.RemoveAt(e.RowIndex);
                }
            }
            CalcTaxAmount();
            CalcTotals();
        }
        private void dgvTaxLine_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvTaxLine.IsCurrentCellDirty)
            {
                if (e.ColumnIndex == 3)
                {

                    if (dgvTaxLine[e.ColumnIndex, e.RowIndex].EditedFormattedValue.ToString() == "")
                    {
                        MessageBox.Show("من فضلك ادخل النسبه المئويه ");
                        IsValidtax = false;
                    }
                    else
                        IsValidtax = true;
                }
            }
        }
        private void dgvTaxLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString() == null && dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value?.ToString() != null)
            {
                MessageBox.Show("برجاء اختيار رقم سطرالفاتورة");
                BeginInvoke(new MethodInvoker(delegate
                {
                    dgvTaxLine.Rows.RemoveAt(e.RowIndex);
                }));
            }
            else
            {
                string messageError = "";
                if (IsValidtax == true)
                {
                    int invoiceLine = int.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString() == null ? 0.ToString() :
                        dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString());
                    for (int i = 0; i < dgv.Rows.Count - 1; i++)
                    {
                        if (int.Parse(dgv.Rows[i].Cells["InvoiceLine"].Value?.ToString()) == invoiceLine)
                        {
                            if (dgv.Rows[i].Cells["QUANTITY"].Value?.ToString() == null || dgv.Rows[i].Cells["QUANTITY"].Value?.ToString() == "0.00000")
                            {
                                messageError = "برجاء ادخال الكمية اولا";
                            }
                            else if (dgv.Rows[i].Cells["AMOUNTEGP"].Value?.ToString() == "0.00000" && dgv.Rows[i].Cells["CURRENCYSOLD"].Value?.ToString() == "EGP")
                            {
                                messageError = "برجاء ادخال السعر بالجنيه المصرى اولا";
                            }
                            else if ((dgv.Rows[i].Cells["AMOUNTSOLD"].Value?.ToString() == null || dgv.Rows[i].Cells["AMOUNTSOLD"].Value?.ToString() == "0.00000") &&
                                dgv.Rows[i].Cells["CURRENCYSOLD"].Value?.ToString() != "EGP")
                            {
                                messageError = "برجاء ادخال السعر بالعملة الجنبية اولا";
                            }
                            else if ((dgv.Rows[i].Cells["CURRENCYEXCHANGERATE"].Value?.ToString() == null || dgv.Rows[i].Cells["CURRENCYEXCHANGERATE"].Value?.ToString() == "0.00000")
                                && dgv.Rows[i].Cells["CURRENCYSOLD"].Value?.ToString() != "EGP")
                            {
                                messageError = "برجاء ادخال معدل تحويل العملة اولا";
                            }
                            break;
                        }
                    }
                    if (messageError == "")
                    {
                        if (e.ColumnIndex == 3 && e.RowIndex > -1 && dgvTaxLine.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode == false)
                        {
                            if (dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].Value?.ToString() == null && dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value?.ToString() != null)
                            {
                                MessageBox.Show("برجاء اختيار نوع الضريبة");
                                dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value = null;
                            }
                            else if (dgvTaxLine.Rows[e.RowIndex].Cells["SUBTYPE"].Value?.ToString() == null && dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value?.ToString() != null)
                            {
                                MessageBox.Show("برجاء اختيار الضريبة الفرعية");
                                dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value = null;
                            }
                            else
                            {
                                for (int n = 0; n < dgv.Rows.Count - 1; n++)
                                {
                                    if (dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString() == dgv.Rows[n].Cells["InvoiceLine"].Value?.ToString())
                                    {
                                        dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value?.ToString()) / 100) * decimal.Parse(dgv.Rows[n].Cells["NetTota"].Value?.ToString());
                                        break;
                                    }
                                }
                                dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value = decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString());


                                if (dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue.ToString() == "الخصم تحت حساب الضريبه")
                                {
                                    dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value = (decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString()) * -1);

                                }
                                decimal tottaxval = decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString());
                                txttotalAmount.Text = (decimal.Parse(txttotalAmount.Text) + tottaxval).ToString();

                                decimal tot = 0;
                                int InvoceLineCountValue = int.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString());
                                
                                for (int i = 0; i < dgvTaxLine.Rows.Count - 1; i++)
                                {
                                    if (int.Parse(dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString()) == InvoceLineCountValue)
                                    {
                                        tot += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                                    }
                                }
                                for (int z = 0; z < dgv.Rows.Count - 1; z++)
                                {
                                    if (int.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["InvoiceLinesCount"].Value?.ToString()) == int.Parse(dgv.Rows[z].Cells["InvoiceLine"].Value?.ToString()))
                                    {
                                        dgv.Rows[z].Cells["TOTAL"].Value = tot + decimal.Parse(dgv.Rows[z].Cells["NetTota"].Value?.ToString());
                                        break;
                                    }
                                }
                                bool IsExits = false;
                                bool IsUpdated = false;
                                decimal AmountTaxLine = 0;

                                if (dTaxHeader.Rows.Count == 0)
                                {
                                    dTaxHeader.Rows.Add(dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue, dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value);
                                    IsExits = true;
                                    return;
                                }
                                else
                                {

                                    if (e.RowIndex >= 0)
                                    {
                                        AmountTaxLine = decimal.Parse(dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value?.ToString());
                                    }
                                    else
                                    {
                                        AmountTaxLine = 0;
                                    }
                                    for (int ii = 0; ii <= dTaxHeader.Rows.Count - 1; ii++)
                                    {
                                        if (dTaxHeader.Rows[ii].Cells["TaxTypeHeader"].EditedFormattedValue.ToString() == dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue.ToString())
                                        {
                                            IsExits = true;
                                            break;
                                        }
                                    }

                                    if (IsExits == false && IsUpdated == false)
                                    {
                                        AmountTaxLine = 0;
                                        dTaxHeader.Rows.Add(dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue, dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value);
                                    }
                                    CalcTaxByType(dgvTaxLine.Rows[e.RowIndex].Cells["TAXTYPE"].EditedFormattedValue.ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(messageError, "تحذير");
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            dgvTaxLine.Rows.RemoveAt(e.RowIndex);
                        }));
                    }
                }
                else
                {
                    return;
                }
            }
        }
        private void dgvTaxLine_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && dgvTaxLine.CurrentCell.Value != null)
            {
                foreach (DataGridViewRow row in this.dgvTaxLine.Rows)
                {

                    if (row.Index == this.dgvTaxLine.CurrentCell.RowIndex)

                    { continue; }

                    if (this.dgvTaxLine.CurrentCell.Value == null)

                    { continue; }

                    if (row.Cells[1].Value != null && row.Cells[1].Value?.ToString() == dgvTaxLine.CurrentCell.Value?.ToString() && row.Cells[0].Value?.ToString() == dgvTaxLine.Rows[e.RowIndex].Cells[0].Value?.ToString())
                    {
                        MessageBox.Show("نوع الضريبة الذى تريد اضافته موجود بالفعل");
                        repeat = true;
                        dgvTaxLine.CurrentCell.Value = null;

                    }
                    else
                    {
                        repeat = false;
                        dgvTaxLine_CellValueChanged(sender, e);
                    }

                }

            }

        }
        private void dgvTaxLine_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != this.dgvTaxLine.NewRowIndex)
            {
                if (dgvTaxLine.Rows[e.RowIndex].Cells["RATE"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N2");
                }
            }
            else if (e.ColumnIndex == 4 && e.RowIndex != this.dgvTaxLine.NewRowIndex)
            {
                if (dgvTaxLine.Rows[e.RowIndex].Cells["AMOUNT"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
        }
        private void dTaxHeader_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != this.dTaxHeader.NewRowIndex)
            {
                if (dTaxHeader.Rows[e.RowIndex].Cells["AmountHeader"].Value != null)
                {
                    double val = double.Parse(e.Value?.ToString());
                    e.Value = val.ToString("N5");
                }
            }
        }
        private void cmbInternal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                if (txtHeaderID.Text == "")
                {
                    MessageBox.Show("برجاء ادخل رقم الوثيقة ");
                    txtHeaderID.Focus();

                }
                if (cmbInternal.SelectedItem != null)
                {
                    using (SqlCommand cmd = new SqlCommand("select ReceiverID,ReceiverType,Name,Country,Governate,RegoinCity,Street,BuildingNumber," +
                        "AdditionalInfo,PostCode,Floor,Room,LandMark from Reciever where InternalCode = '" + cmbInternal.Text + "' ", connection))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            txttype.Text = sdr["ReceiverType"].ToString();
                            txtID.Text = sdr["ReceiverID"].ToString();
                            txtname.Text = sdr["Name"].ToString();
                            txtcountry.Text = sdr["Country"].ToString();
                            txtregion.Text = sdr["RegoinCity"].ToString();
                            txtgover.Text = sdr["Governate"].ToString();
                            txtstreet.Text = sdr["Street"].ToString();
                            txtbuild.Text = sdr["BuildingNumber"].ToString();
                            txtaddinfo.Text = sdr["AdditionalInfo"].ToString();
                            txtpostal.Text = sdr["PostCode"].ToString();
                            txtfloor.Text = sdr["Floor"].ToString();
                            txtroom.Text = sdr["Room"].ToString();
                            txtland.Text = sdr["LandMark"].ToString();
                            cmbName.Text = txtname.Text;
                        }
                    }
                }

            }

        }
        private void cmbName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (IsLoaded)
            {
                string query = "";
                if (cmbName.Text == "")
                {
                    query = txtname.Text;
                }
                else if (cmbName.Text != "")
                {
                    query = cmbName.Text;
                }
                using (SqlCommand cmd = new SqlCommand("select InternalCode from Reciever where Name = N'" + query + "' COLLATE SQL_Latin1_General_CP1_CS_AS", connection))
                {
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        cmbInternal.Text = sdr["InternalCode"].ToString();
                    }
                }
                if (txtHeaderID.Text == "")
                {
                    txtHeaderID.Focus();
                }
            }
        }
        private void cmbCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 1)
            {
                var comboBox = dgv.Rows[0].Cells["CURRENCYSOLD"].Value?.ToString();
                if (cmbCurrency.Text != comboBox)
                {
                    DialogResult dialogResult = MessageBox.Show("لقد اخترت اكثر من عملة فى سطور الفاتوره \n اذا كنت تريد الاضافه بتلك العمله فسيتم حذف سطور الفاتوره المضافه. ",
                      "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.OK)
                    {
                        int dgvRowsCount = dgv.Rows.Count - 2;
                        for (int d = dgvRowsCount; d >= 0; d--)
                        {
                            int taxLineCount = dgvTaxLine.Rows.Count - 2;
                            for (int i = taxLineCount; i >= 0; i--)
                            {
                                if (dgv.Rows[d].Cells["InvoiceLine"].Value?.ToString() == dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].Value?.ToString())
                                {
                                    int taxHeaderCount = dTaxHeader.Rows.Count - 1;
                                    for (int tx = taxHeaderCount; tx >= 0; tx--)
                                    {
                                        if (dTaxHeader.Rows[tx].Cells["TaxTypeHeader"].EditedFormattedValue.ToString() == dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString())
                                        {
                                            dTaxHeader.Rows[tx].Cells["AmountHeader"].Value = decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) -
                                                decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());

                                            if (decimal.Parse(dTaxHeader.Rows[tx].Cells["AmountHeader"].Value?.ToString()) == 0)
                                            {
                                                dTaxHeader.Rows.RemoveAt(tx);
                                            }
                                            break;
                                        }
                                    }
                                    dgvTaxLine.Rows.RemoveAt(i);
                                }
                            }
                            var exist = listOfDeletedTaxLine.Exists(x => x.ToString() == dgv.Rows[d].Cells["InvoiceLine"].Value?.ToString());
                            if (!exist)
                            {
                                listOfDeletedTaxLine.Add(int.Parse(dgv.Rows[d].Cells["InvoiceLine"].Value?.ToString()));
                            }
                            dgv.Rows.RemoveAt(d);
                            InvLIneDT.Rows.RemoveAt(d);
                            InvoiceLinesCount.DataSource = InvLIneDT;
                        }

                    }
                    else
                    {
                        cmbCurrency.Text = comboBox;
                    }
                }
            }
        }
        private void btnoptionalinfo_Click(object sender, EventArgs e)
        {
            AdditionalInfo i = new AdditionalInfo();
            i.Show();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            bool currencyChanged = false;
            for (int d = 0; d <= dgv.Rows.Count - 2; d++)
            {
                if (dgv.Rows[0].Cells["CURRENCYSOLD"].Value?.ToString() != dgv.Rows[d].Cells["CURRENCYSOLD"].Value?.ToString())
                {
                    currencyChanged = true;
                    break;
                }
            }
            if (currencyChanged == false)
            {

                if (IsValid == true && IsValidtax == true)
                {
                    bool IsFound = true;
                    for (int inindx = 0; inindx < dgv.Rows.Count - 1; inindx++)
                    {
                        if (IsFound == true)
                        {
                            for (int txIndx = 0; txIndx < dgvTaxLine.Rows.Count - 1; txIndx++)
                            {
                                if (int.Parse(dgv.Rows[inindx].Cells["InvoiceLine"].Value?.ToString()) == int.Parse(dgvTaxLine.Rows[txIndx].Cells["InvoiceLinesCount"].Value?.ToString()))
                                {
                                    IsFound = true;
                                    break;
                                }
                                else
                                {
                                    IsFound = false;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }

                    }
                    if (IsFound == false)
                    {
                        MessageBox.Show("يجب ادخال ضريبة لكل عنصر فى الفاتورة");
                        return;
                    }
                    bool ValidateTaxData = validateTaxLineDate();
                    bool ValidInvData = validateInvLineDate();
                    bool ValidateHeader = ValidatInvoiceHeader();

                    if (ValidInvData == true && ValidateTaxData == true && ValidateHeader == true)
                    {
                        using (SqlCommand command = new SqlCommand("InsertInvoiceHeader", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add("@HeaderID", SqlDbType.VarChar);
                            command.Parameters.Add("@UssuerID", SqlDbType.VarChar);
                            command.Parameters.Add("@Type", SqlDbType.NVarChar);
                            command.Parameters.Add("@ID", SqlDbType.NVarChar);
                            command.Parameters.Add("@Name", SqlDbType.NVarChar);
                            command.Parameters.Add("@Country", SqlDbType.NVarChar);
                            command.Parameters.Add("@Governate", SqlDbType.NVarChar);
                            command.Parameters.Add("@Region", SqlDbType.NVarChar);
                            command.Parameters.Add("@Street", SqlDbType.NVarChar);
                            command.Parameters.Add("@BuildinNO", SqlDbType.NVarChar);
                            command.Parameters.Add("@Postal", SqlDbType.NVarChar);
                            command.Parameters.Add("@floor", SqlDbType.NVarChar);
                            command.Parameters.Add("@Room", SqlDbType.NVarChar);
                            command.Parameters.Add("@LandMark", SqlDbType.NVarChar);
                            command.Parameters.Add("@AdditionalInfo", SqlDbType.NVarChar);
                            command.Parameters.Add("@DocumentTyp", SqlDbType.NVarChar);
                            command.Parameters.Add("@DocumentTypVer", SqlDbType.NVarChar);
                            command.Parameters.Add("@DateTime", SqlDbType.VarChar);
                            command.Parameters.Add("@Taxable", SqlDbType.NVarChar);
                            command.Parameters.Add("@InternalID", SqlDbType.NVarChar);
                            command.Parameters.Add("@Reverence", SqlDbType.NVarChar);
                            command.Parameters.Add("@Descrip", SqlDbType.NVarChar);
                            command.Parameters.Add("@SalesRefer", SqlDbType.NVarChar);
                            command.Parameters.Add("@SalesDesc", SqlDbType.NVarChar);
                            command.Parameters.Add("@ProInvoice", SqlDbType.NVarChar);
                            command.Parameters.Add("@BankNa", SqlDbType.NVarChar);
                            command.Parameters.Add("@BankADD", SqlDbType.NVarChar);
                            command.Parameters.Add("@BankACC", SqlDbType.NVarChar);
                            command.Parameters.Add("@BankIBAN", SqlDbType.NVarChar);
                            command.Parameters.Add("@SWIFTCODE", SqlDbType.NVarChar);
                            command.Parameters.Add("@TERMS", SqlDbType.NVarChar);
                            command.Parameters.Add("@APPROACH", SqlDbType.NVarChar);
                            command.Parameters.Add("@PACKAGING", SqlDbType.NVarChar);
                            command.Parameters.Add("@DATEVALIDITY", SqlDbType.NVarChar);
                            command.Parameters.Add("@EXPORTPORT", SqlDbType.NVarChar);
                            command.Parameters.Add("@COUNTRYOFORIGIN", SqlDbType.NVarChar);
                            command.Parameters.Add("@GROSSWEIGHT", SqlDbType.NVarChar);
                            command.Parameters.Add("@NETWEIGHT", SqlDbType.NVarChar);
                            command.Parameters.Add("@DELIVERY_TERMS", SqlDbType.NVarChar);
                            command.Parameters.Add("@TOTALDISCOUNTAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@TOTALSALESAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@NETAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@TOTALAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@EXTRADISCOUNTAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@TOTALITEMSDISCOUNTAMOUNT", SqlDbType.Decimal);
                            command.Parameters.Add("@REFERENCE_UUID", SqlDbType.NVarChar);
                            command.Parameters.Add("@REFERENCE_INVOICE_NUM", SqlDbType.NVarChar);
                            command.Parameters.Add("@ACTIONTYPE", SqlDbType.VarChar);
                            command.Parameters.Add("@MAINSTATUS", SqlDbType.VarChar);
                            command.Parameters.Add("@ReadyToMain", SqlDbType.Bit);
                            command.Parameters.Add("@DateTimeIssuedTemp", SqlDbType.DateTime);
                            SqlCommand command2 = new SqlCommand("SELECT [HeaderId],[TRX_HEADER_ID]  FROM [EINVOICES_HEADERS_TEMP_SETUP] where [TRX_HEADER_ID]='" + txtHeaderID.Text + "'", connection);

                            sqlDataReader = command2.ExecuteReader();
                            if (!sqlDataReader.Read())
                            {
                                try
                                {
                                    command.Parameters["@HeaderID"].Value = txtHeaderID.Text;
                                    command.Parameters["@UssuerID"].Value = cmbIID.Text;
                                    command.Parameters["@Type"].Value = txttype.Text;
                                    command.Parameters["@ID"].Value = txtID.Text;
                                    command.Parameters["@Name"].Value = txtname.Text;
                                    command.Parameters["@Country"].Value = txtcountry.Text;
                                    command.Parameters["@Governate"].Value = txtgover.Text;
                                    command.Parameters["@Region"].Value = txtregion.Text;
                                    command.Parameters["@Street"].Value = txtstreet.Text;
                                    command.Parameters["@BuildinNO"].Value = txtbuild.Text;
                                    command.Parameters["@Postal"].Value = txtpostal.Text;
                                    command.Parameters["@floor"].Value = txtfloor.Text;
                                    command.Parameters["@Room"].Value = txtroom.Text;
                                    command.Parameters["@LandMark"].Value = txtland.Text;
                                    command.Parameters["@AdditionalInfo"].Value = txtaddinfo.Text;

                                    if (cmbType.Text == "فاتورة")
                                    {
                                        command.Parameters["@DocumentTyp"].Value = "I";
                                    }
                                    else if (cmbType.Text == "اشعار بالاضافة")
                                    {
                                        command.Parameters["@DocumentTyp"].Value = "C";
                                    }
                                    else if (cmbType.Text == "اشعار بالخصم")
                                    {
                                        command.Parameters["@DocumentTyp"].Value = "D";
                                    }
                                    command.Parameters["@DocumentTypVer"].Value = "1.0";
                                    command.Parameters["@DateTime"].Value = (DateTime.Parse(paDate.Text).ToString("yyyy-MM-dd" + "T08:11:12Z")).ToString();
                                    command.Parameters["@Taxable"].Value = txtactitvity.Text;
                                    command.Parameters["@InternalID"].Value = txtHeaderID.Text;
                                    command.Parameters["@Reverence"].Value = OptionalInfoData.PURCHASEORDERREFERENCE;
                                    command.Parameters["@Descrip"].Value = OptionalInfoData.PURCHASEORDERDESCRIPTION;
                                    command.Parameters["@SalesRefer"].Value = OptionalInfoData.SALESORDERREFERENCE;
                                    command.Parameters["@SalesDesc"].Value = OptionalInfoData.SALESORDERDESCRIPTION;
                                    command.Parameters["@ProInvoice"].Value = OptionalInfoData.PROFORMAINVOICENUMBER;
                                    command.Parameters["@BankNa"].Value = OptionalInfoData.PAYMENT_BANKNAME;
                                    command.Parameters["@BankADD"].Value = OptionalInfoData.PAYMENT_BANKADDRESS;
                                    command.Parameters["@BankACC"].Value = OptionalInfoData.PAYMENT_BANKACCOUNTNO;
                                    command.Parameters["@BankIBAN"].Value = OptionalInfoData.PAYMENT_BANKACCOUNTIBAN;
                                    command.Parameters["@SWIFTCODE"].Value = OptionalInfoData.PAYMENT_SWIFTCODE;
                                    command.Parameters["@TERMS"].Value = OptionalInfoData.PAYMENT_TERMS;
                                    command.Parameters["@APPROACH"].Value = OptionalInfoData.DELIVERY_APPROACH;
                                    command.Parameters["@PACKAGING"].Value = OptionalInfoData.DELIVERY_PACKAGING;
                                    command.Parameters["@DATEVALIDITY"].Value = OptionalInfoData.DELIVERY_DATEVALIDITY;
                                    command.Parameters["@EXPORTPORT"].Value = OptionalInfoData.DELIVERY_EXPORTPORT;
                                    command.Parameters["@COUNTRYOFORIGIN"].Value = OptionalInfoData.DELIVERY_COUNTRYOFORIGIN;
                                    command.Parameters["@GROSSWEIGHT"].Value = OptionalInfoData.DELIVERY_GROSSWEIGHT;
                                    command.Parameters["@NETWEIGHT"].Value = OptionalInfoData.DELIVERY_NETWEIGHT;
                                    command.Parameters["@DELIVERY_TERMS"].Value = OptionalInfoData.DELIVERY_TERMS;
                                    command.Parameters["@REFERENCE_INVOICE_NUM"].Value = OptionalInfoData.REFERENCE_INVOICE_NUM;
                                    command.Parameters["@ACTIONTYPE"].Value = OptionalInfoData.ACTIONTYPE;

                                    command.Parameters["@TOTALDISCOUNTAMOUNT"].Value = decimal.Parse(txttotalDiscount.Text);
                                    command.Parameters["@TOTALSALESAMOUNT"].Value = decimal.Parse(txttotalSales.Text);
                                    command.Parameters["@NETAMOUNT"].Value = decimal.Parse(txtnetTotal.Text);
                                    command.Parameters["@TOTALAMOUNT"].Value = decimal.Parse(txttotalAmount.Text);
                                    command.Parameters["@EXTRADISCOUNTAMOUNT"].Value = 0;
                                    command.Parameters["@TOTALITEMSDISCOUNTAMOUNT"].Value = decimal.Parse(txttotalitemDiscount.Text);

                                    command.Parameters["@REFERENCE_UUID"].Value = 0;
                                    command.Parameters["@MAINSTATUS"].Value = "";
                                    command.Parameters["@ReadyToMain"].Value = false;
                                    command.Parameters["@DateTimeIssuedTemp"].Value = DateTime.UtcNow;
                                    command.ExecuteNonQuery();
                                    using (SqlCommand command3 = new SqlCommand("InsertInvoiceLines", connection))
                                    {
                                        command3.CommandType = CommandType.StoredProcedure;

                                        command3.Parameters.Add("@headerid", SqlDbType.VarChar);
                                        command3.Parameters.Add("@lineid", SqlDbType.Int);
                                        command3.Parameters.Add("@descr", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@itemType", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@itemCode", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@unitType", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@qantity", SqlDbType.Decimal);
                                        command3.Parameters.Add("@internalCode", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@salesTotal", SqlDbType.Decimal);
                                        command3.Parameters.Add("@total", SqlDbType.Decimal);
                                        command3.Parameters.Add("@valueDifer", SqlDbType.Decimal);
                                        command3.Parameters.Add("@totalTax", SqlDbType.Decimal);
                                        command3.Parameters.Add("@netTotal", SqlDbType.Decimal);
                                        command3.Parameters.Add("@itemDis", SqlDbType.Decimal);
                                        command3.Parameters.Add("@currSold", SqlDbType.NVarChar);
                                        command3.Parameters.Add("@amountEGP", SqlDbType.Decimal);
                                        command3.Parameters.Add("@amountSold", SqlDbType.Decimal);
                                        command3.Parameters.Add("@currExchange", SqlDbType.Decimal);
                                        command3.Parameters.Add("@disRate", SqlDbType.Decimal);
                                        command3.Parameters.Add("@disAmount", SqlDbType.Decimal);
                                        command3.Parameters.Add("@Ready", SqlDbType.Bit);

                                        command3.Parameters["@headerid"].Value = txtHeaderID.Text;

                                        for (int i = 0; i < dgv.RowCount - 1; i++)
                                        {
                                            command3.Parameters["@lineid"].Value = int.Parse(dgv.Rows[i].Cells["InvoiceLine"].Value?.ToString());
                                            command3.Parameters["@descr"].Value = dgv.Rows[i].Cells["DESCRIPTION"].Value?.ToString();
                                            command3.Parameters["@itemType"].Value = dgv.Rows[i].Cells["ITEMTYPE"].Value?.ToString();
                                            command3.Parameters["@itemCode"].Value = dgv.Rows[i].Cells["ITEMCODE"].Value?.ToString();
                                            command3.Parameters["@unitType"].Value = dgv.Rows[i].Cells["UNITTYPE"].Value?.ToString();
                                            command3.Parameters["@qantity"].Value = decimal.Parse(dgv.Rows[i].Cells["QUANTITY"].Value?.ToString());
                                            command3.Parameters["@internalCode"].Value = dgv.Rows[i].Cells["INTERNALCODE"].Value?.ToString();
                                            command3.Parameters["@salesTotal"].Value = decimal.Parse(dgv.Rows[i].Cells["SALESTOTAL"].Value?.ToString());
                                            command3.Parameters["@total"].Value = decimal.Parse(dgv.Rows[i].Cells["TOTAL"].Value?.ToString());
                                            command3.Parameters["@valueDifer"].Value = decimal.Parse(dgv.Rows[i].Cells["VALUEDIFFERENCE"].Value?.ToString());
                                            command3.Parameters["@totalTax"].Value = decimal.Parse(dgv.Rows[i].Cells["TOTALTAXABLEFEES"].Value?.ToString());
                                            command3.Parameters["@netTotal"].Value = decimal.Parse(dgv.Rows[i].Cells["NetTota"].Value?.ToString());
                                            command3.Parameters["@itemDis"].Value = decimal.Parse(dgv.Rows[i].Cells["ITEMSDISCOUNT"].Value?.ToString());
                                            command3.Parameters["@currSold"].Value = dgv.Rows[i].Cells["CURRENCYSOLD"].EditedFormattedValue.ToString();
                                            command3.Parameters["@amountEGP"].Value = decimal.Parse(dgv.Rows[i].Cells["AMOUNTEGP"].Value?.ToString());
                                            command3.Parameters["@amountSold"].Value = decimal.Parse(dgv.Rows[i].Cells["AMOUNTSOLD"].Value?.ToString());
                                            command3.Parameters["@currExchange"].Value = decimal.Parse(dgv.Rows[i].Cells["CURRENCYEXCHANGERATE"].Value?.ToString());
                                            command3.Parameters["@disRate"].Value = 0;
                                            command3.Parameters["@disAmount"].Value = decimal.Parse(dgv.Rows[i].Cells["DISCOUNT_AMOUNT"].Value?.ToString());
                                            command3.Parameters["@Ready"].Value = false;

                                            command3.ExecuteNonQuery();
                                        }
                                        using (SqlCommand command5 = new SqlCommand("InsertTaxLines", connection))
                                        {
                                            command5.CommandType = CommandType.StoredProcedure;

                                            command5.Parameters.Add("@headerid", SqlDbType.VarChar);
                                            command5.Parameters.Add("@lineID", SqlDbType.Int);
                                            command5.Parameters.Add("@TaxType", SqlDbType.VarChar);
                                            command5.Parameters.Add("@Amount", SqlDbType.Decimal);
                                            command5.Parameters.Add("@SubType", SqlDbType.VarChar);
                                            command5.Parameters.Add("@rate", SqlDbType.Decimal);
                                            command5.Parameters.Add("@ready", SqlDbType.Bit);

                                            command5.Parameters["@headerid"].Value = txtHeaderID.Text;

                                            for (int x = 0; x <= dgvTaxLine.Rows.Count - 2; x++)
                                            {
                                                command5.Parameters["@lineID"].Value = dgvTaxLine.Rows[x].Cells["InvoiceLinesCount"].Value?.ToString();
                                                int indx = -1;
                                                for (int i = 0; i <= Taxesds.Tables[0].Rows.Count - 1; i++)
                                                {
                                                    if (dgvTaxLine.Rows[x].Cells["TAXTYPE"].Value?.ToString() == Taxesds.Tables[0].Rows[i][0].ToString())
                                                    {
                                                        indx = i;
                                                        break;
                                                    }
                                                }

                                                command5.Parameters["@TaxType"].Value = Taxesds.Tables[0].Rows[indx][1].ToString();
                                                command5.Parameters["@SubType"].Value = dgvTaxLine.Rows[x].Cells["SUBTYPE"].Value?.ToString();
                                                command5.Parameters["@rate"].Value = decimal.Parse(dgvTaxLine.Rows[x].Cells["RATE"].Value?.ToString());
                                                command5.Parameters["@Amount"].Value = Math.Abs(decimal.Parse(dgvTaxLine.Rows[x].Cells["AMOUNT"].Value?.ToString()));
                                                command5.Parameters["@ready"].Value = false;

                                                command5.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                    IsLoaded = false;
                                    MessageBox.Show("تمت اضافه الفاتورة بنجاح");
                                    btnAddClicked = true;
                                    ClearAllFields();
                                    btnAddClicked = false;

                                    this.Hide();
                                    this.Close();
                                    InvoiceDataFormat inv = new InvoiceDataFormat();
                                    inv.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("" + ex);
                                }

                            }
                            else
                            {
                                MessageBox.Show("هذه الفاتورة موجوده بالفعل ");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("من فضلك ادخل جميع البيانات المطلوبه للفاتورة  ");

                    }
                }
                else
                {
                    MessageBox.Show("من فضلك تاكد ان جميع بيانات الفاتورة صحيحة  ");
                    return;
                }
            }
            else
            {
                MessageBox.Show("تم استخدام اكثر من عملة فى سطور الفاتورة ", "تغيير العملة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        #region Helper
        private bool ValidatInvoiceHeader()
        {
            bool x = false;
            if (cmbInternal.Text != "" && cmbIID.Text != "" && cmbType.Text != "" && txtHeaderID.Text != "")
            {
                x = true;
            }
            return x;
        }
        private bool validateTaxLineDate()
        {
            bool x = true;
            if (dgvTaxLine.Rows.Count - 1 == 0)
            {
                x = false;
            }
            else
            {
                for (int ii = 0; ii < dgvTaxLine.Rows.Count - 1; ii++)
                {

                    if (dgvTaxLine.Rows[ii].Cells[0].Value != null && dgvTaxLine.Rows[ii].Cells[1].Value != null && dgvTaxLine.Rows[ii].Cells[2].Value != null && dgvTaxLine.Rows[ii].Cells[3].Value != null && dgvTaxLine.Rows[ii].Cells[4].Value != null)
                    {
                        x = true;
                    }
                    else
                    {
                        x = false;
                        break;
                    }
                }
            }
            return x;
        }
        private bool validateInvLineDate()
        {
            bool x = true;
            for (int ii = 0; ii < dgv.Rows.Count - 1; ii++)
            {

                if (dgv.Rows[ii].Cells[0].Value != null && dgv.Rows[ii].Cells[1].Value != null && dgv.Rows[ii].Cells[2].Value != null
                    && dgv.Rows[ii].Cells[3].Value != null && dgv.Rows[ii].Cells[4].Value != null && dgv.Rows[ii].Cells[5].Value != null
                   && dgv.Rows[ii].Cells[6].Value != null && dgv.Rows[ii].Cells[7].Value?.ToString() != "0.00000" && dgv.Rows[ii].Cells[8].Value != null
                   && dgv.Rows[ii].Cells[9].Value != null && dgv.Rows[ii].Cells[10].Value != null && dgv.Rows[ii].Cells[11].Value != null
                   && dgv.Rows[ii].Cells[12].Value != null && dgv.Rows[ii].Cells[13].Value != null && dgv.Rows[ii].Cells[14].Value != null
                   && dgv.Rows[ii].Cells[15].Value != null && dgv.Rows[ii].Cells[16].Value != null)
                {
                    x = true;
                }
                else
                {
                    x = false;
                    break;
                }

            }
            return x;
        }
        private void CalcTaxByType(string TaxT)
        {
            decimal taxTypeTotal = 0;
            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
            {
                if (dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString() == TaxT)
                {
                    taxTypeTotal += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                }
            }

            for (int i = 0; i <= dTaxHeader.Rows.Count - 1; i++)
            {
                if (dTaxHeader.Rows[i].Cells["TaxTypeHeader"].Value?.ToString() == TaxT)
                {
                    dTaxHeader.Rows[i].Cells["AmountHeader"].Value = taxTypeTotal.ToString();
                    break;
                }
            }
        }
        private void CalcTaxByTypeAndLine(int InLineNum, string TaxT)
        {
            decimal taxTypeTotal = 0;
            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
            {
                if (dgvTaxLine.Rows[i].Cells["TAXTYPE"].EditedFormattedValue.ToString() == TaxT && int.Parse(dgvTaxLine.Rows[i].Cells["InvoiceLinesCount"].EditedFormattedValue.ToString()) == InLineNum)
                {
                    taxTypeTotal += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
                }
            }

            for (int i = 0; i <= dTaxHeader.Rows.Count - 1; i++)
            {
                if (dTaxHeader.Rows[i].Cells["TaxTypeHeader"].Value?.ToString() == TaxT)
                {
                    dTaxHeader.Rows[i].Cells["AmountHeader"].Value = taxTypeTotal.ToString();
                    break;
                }
            }
        }
        private void ClearAllFields()
        {
            txtHeaderID.Text = "";
            cmbType.SelectedItem = null;
            cmbInternal.SelectedItem = null;
            cmbIID.SelectedItem = null;
            cmbName.SelectedItem = null;

            txttype.Text = "";
            txtID.Text = "";
            txtname.Text = "";
            txtcountry.Text = "";
            txtregion.Text = "";
            txtgover.Text = "";
            txtstreet.Text = "";
            txtbuild.Text = "";
            txtaddinfo.Text = "";
            txtpostal.Text = "";
            txtfloor.Text = "";
            txtroom.Text = "";
            txtland.Text = "";

            txttotalSales.Text = "";
            txttotalDiscount.Text = "";
            txttotalAmount.Text = "";
            txttotalitemDiscount.Text = "";
            txtTotalTaxLineAmount.Text = "";
            txtnetTotal.Text = "";

            dgv.Rows.Clear();
            dgvTaxLine.Rows.Clear();
            dTaxHeader.Rows.Clear();

        }
        private void CalcTaxAmount()
        {
            decimal taxAmount = 0;
            for (int i = 0; i <= dgvTaxLine.Rows.Count - 2; i++)
            {
                if (dgvTaxLine.Rows[i].Cells["AMOUNT"].Value == null)
                {
                    dgvTaxLine.Rows[i].Cells["AMOUNT"].Value = 0;
                }

                taxAmount += decimal.Parse(dgvTaxLine.Rows[i].Cells["AMOUNT"].Value?.ToString());
            }
            txtTotalTaxLineAmount.Text = Strings.FormatNumber(taxAmount, 5, TriState.False).ToString();

        }
        private void ClearCustomerData()
        {

            txttype.Text = "";
            txtID.Text = "";
            txtname.Text = "";
            txtcountry.Text = "";
            txtregion.Text = "";
            txtgover.Text = "";
            txtstreet.Text = "";
            txtbuild.Text = "";
            txtaddinfo.Text = "";
            txtpostal.Text = "";
            txtfloor.Text = "";
            txtroom.Text = "";
            txtland.Text = "";
        }
        private void CalcTotals()
        {
            decimal TotalSales = 0;
            decimal TotDiscount = 0;
            decimal nettotal = 0;
            decimal totalamount = 0;
            decimal itemdisc = 0;

            for (int i = 0; i <= dgv.Rows.Count - 2; i++)
            {
                if (dgv.Rows[i].Cells["SALESTOTAL"].Value == null)
                {
                    dgv.Rows[i].Cells["SALESTOTAL"].Value = 0;
                }
                else if (dgv.Rows[i].Cells["DISCOUNT_AMOUNT"].Value == null)
                {
                    dgv.Rows[i].Cells["DISCOUNT_AMOUNT"].Value = 0;
                }
                else if (dgv.Rows[i].Cells["TOTAL"].Value == null)
                {
                    dgv.Rows[i].Cells["TOTAL"].Value = 0;
                }
                else if (dgv.Rows[i].Cells["NetTota"].Value == null)
                {
                    dgv.Rows[i].Cells["NetTota"].Value = 0;
                }
                else if (dgv.Rows[i].Cells["ITEMSDISCOUNT"].Value == null)
                {
                    dgv.Rows[i].Cells["ITEMSDISCOUNT"].Value = 0;
                }

                TotalSales += decimal.Parse(dgv.Rows[i].Cells["SALESTOTAL"].Value?.ToString());
                TotDiscount += decimal.Parse(dgv.Rows[i].Cells["DISCOUNT_AMOUNT"].Value?.ToString());
                totalamount += decimal.Parse(dgv.Rows[i].Cells["TOTAL"].Value?.ToString());
                nettotal += decimal.Parse(dgv.Rows[i].Cells["NetTota"].Value?.ToString());
                itemdisc += decimal.Parse(dgv.Rows[i].Cells["ITEMSDISCOUNT"].Value?.ToString());


            }
            txttotalSales.Text = Strings.FormatNumber(TotalSales, 5, TriState.False).ToString();
            txttotalDiscount.Text = Strings.FormatNumber(TotDiscount, 5, TriState.False).ToString();
            txttotalAmount.Text = Strings.FormatNumber(totalamount, 5, TriState.False).ToString();
            txtnetTotal.Text = Strings.FormatNumber(nettotal, 5, TriState.False).ToString();
            txttotalitemDiscount.Text = Strings.FormatNumber(itemdisc, 5, TriState.False).ToString();


        }
        #endregion
    }
}
