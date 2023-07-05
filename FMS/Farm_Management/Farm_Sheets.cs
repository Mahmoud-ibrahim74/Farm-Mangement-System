using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using FMS.Hardware.Printing;

namespace FMS.Farm_Management
{
    public partial class Farm_Sheets : Form
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        string TblName = null;
        string ColsName = null;

        public Farm_Sheets()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(bottomPanelTables, this.panel1, this.connection, backgroundWorker);
            datePanel.Text = DateTime.Now.ToLongDateString();
            helpProvider.SetHelpString(this, " *- Press (CTRL+D)  to delete any row for all tables. \n\n" +
" *- Press (Excel Export)  Then Wait (4s) to Export Sheet. \n\n" +
" *- Press (Log Selection ComboBox)  to View Log of Farm Management System .\n\n" +
" *- Press (Print Button) to print log table .");
        }


        private void employees_mangement_Load(object sender, System.EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                new PrinterSender().SendPRinter("بيان بالتقارير", tableB);

            }

        }

        private void xuiBatteryPercentageAPI_Tick(object sender, System.EventArgs e)
        {
            batteryStatus.Value = xuiBatteryPercentageAPI.Value;
            ToolTip.SetToolTip(batteryStatus, "Battery Status : " + xuiBatteryPercentageAPI.Value);
        }


        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ControlName = (string)e.Argument;

            if (ControlName == "animal_reports")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select animal_id as [رقم الحيوان],animal_name as [اسم الحيوان],anavar_name as [اسم العنبر],numbers as [العدد],price_per_numbers as [سعر لكل عدد],total as [الإجمالي],notes as [ملاحظات] from animal_storage", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "animal_storage");
                    tableB.DataSource = ds.Tables["animal_storage"].DefaultView;
                    cn.Close();
                    TblName = ds.Tables[0].TableName;
                    ColsName = "animal_id";
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "animal_purshase")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select premession_id as [رقم الحركة], date as [التاريخ], supplier_name as [اسم المورد], anavar_name as [اسم العنبر], payment_method as [طريقة الدفع], treasury as [الخزينة], animal_name as [اسم الحيوان], numbers as [العدد], price as [السعر], total as [الإجمالي], notes as [ملاحظات]   from animals_premession where service_type = N'شراء'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "animals_premession");
                    tableB.DataSource = ds.Tables["animals_premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "premession_id";
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "animal_selling")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select premession_id as [رقم الحركة], date as [التاريخ], supplier_name as [اسم المورد], anavar_name as [اسم العنبر], payment_method as [طريقة الدفع], treasury as [الخزينة], animal_name as [اسم الحيوان], numbers as [العدد], price as [السعر], total as [الإجمالي], notes as [ملاحظات]   from animals_premession where service_type = N'بيع'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "animals_premession");
                    tableB.DataSource = ds.Tables["animals_premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "premession_id";
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "medicine_purshase")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الحركة], date as [التاريخ], medicine as [المصل / الدواء], storage as [المخزن], desease as[المرض], animal_type as [نوع الحيوان], storage_balance as [سحب رصيد المخزن], unit as [الوحدة], cost as [التكلفة], total as [الإجمالي] from medicine_premession where type_working = N'شراء'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "medicine_premession");
                    tableB.DataSource = ds.Tables["medicine_premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "medicine_selling")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الحركة], date as [التاريخ], medicine as [المصل / الدواء], storage as [المخزن], desease as[المرض], animal_type as [نوع الحيوان], storage_balance as [سحب رصيد المخزن], unit as [الوحدة], cost as [التكلفة], total as [الإجمالي] from medicine_premession where type_working = N'صرف'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "medicine_premession");
                    tableB.DataSource = ds.Tables["medicine_premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";

                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "goods_purshase")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select premession_id as 'رقم الاذن',التاريخ,acc_type as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي' from goods_premession where type_working  = N'شراء'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "goods_Purshase_Premession");
                    tableB.DataSource = ds.Tables["goods_Purshase_Premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "premession_id";

                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else if (ControlName == "goods_selling")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select premession_id as 'رقم الاذن',التاريخ,acc_type as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي' from goods_premession where type_working  = N'صرف'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "goods_Purshase_Premession");
                    tableB.DataSource = ds.Tables["goods_Purshase_Premession"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "premession_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (ControlName == "SafePurshase")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الإذن], date as[التاريخ],Treasury as [الخزينة],acc_name as[اسم الحساب],amount as [المبلغ],acc_type [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where service_type = N'توريد' ", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Premession_Cash");
                    tableB.DataSource = ds.Tables["Premession_Cash"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (ControlName == "SafeSelling")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الإذن], date as[التاريخ],Treasury as [الخزينة],acc_name as[اسم الحساب],amount as [المبلغ],acc_type [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where service_type = N'صرف' ", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Premession_Cash");
                    tableB.DataSource = ds.Tables["Premession_Cash"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (ControlName == "ChequePurshase")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الإذن], date as [التاريخ],bank_name as [اسم البنك],acc_name as [اسم الحساب],amount as [المبلغ],check_No as [رقم الشيك],check_date as [تاريخ الشيك],service_type as [رقم الخدمة],notes as [ملاحظات] from Premession_Check where service_type = N'توريد'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Premession_Check");
                    tableB.DataSource = ds.Tables["Premession_Check"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (ControlName == "ChequeSelling")
            {
                tableB.DataSource = null;
                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("select prem_id as [رقم الإذن], date as [التاريخ],bank_name as [اسم البنك],acc_name as [اسم الحساب],amount as [المبلغ],check_No as [رقم الشيك],check_date as [تاريخ الشيك],service_type as [رقم الخدمة],notes as [ملاحظات] from Premession_Check where service_type = N'صرف'", cn);
                    cmd.ExecuteNonQuery();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "Premession_Check");
                    tableB.DataSource = ds.Tables["Premession_Check"].DefaultView;
                    TblName = ds.Tables[0].TableName;
                    ColsName = "prem_id";
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (ControlName == "clearData")
            {
                List<string> temp = new List<string>();
                TablesName(temp);
                try
                {
                    confirm.Enabled = false;
                    panelSlider.Enabled = false;
                    lblConfirm.Text = "......  جاري محو جميع البيانات";
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    for (int i = 0; i < temp.Count; i++)
                    {
                        if (i != 18) // this index for table user_management
                        {
                            SqlCommand cmd = new SqlCommand(string.Format("TRUNCATE TABLE {0};", temp[i]), cn);
                            cmd.ExecuteNonQuery();
                            Thread.Sleep(1000);
                            Console.WriteLine("Table : '" + temp[i] + "'     is Deleted");
                        }
                    }
                    cn.Close();
                    temp.Clear();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                    {

                        MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        confirm.Enabled = true;
                        panelSlider.Enabled = true;


                    }
                }
                finally
                {
                    panelSlider.Enabled = true;
                    confirm.Enabled = true;
                    confirmPanel.Dispose();
                    MessageBox.Show("تم حذف جميع البيانات بنجاح", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }


        private void guna2Button3_Click_2(object sender, EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تطبع", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ExportExcel excel = new ExportExcel();
            Thread thread = new Thread(() => excel.ExeclReportOne(tableB, saveExcel));
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تطبع", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                };
                worker.RunWorkerAsync();
            }
        }



        private void tableB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                tableB.Refresh();
            }
            else
            {
                tableB.Refresh();
            }
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (tableB.DataSource != null)
            {

                BindingSource bs = new BindingSource();
                bs.DataSource = tableB.DataSource;
                bs.Filter = "CONVERT([" + tableB.Columns[0].Name + "], System.String)" + " like '%" + search.Text + "%'";
                tableB.DataSource = bs;

                if (search.Text == "")
                    bs.Filter = null;
            }

        }

        private void Farm_Sheets_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                if (tableB.Rows.Count != 0)
                {
                    string val = tableB.SelectedCells[0].Value.ToString();
                    if (MessageBox.Show(string.Format(" '{0}'  هل تريد حذف الصف رقم", val), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        try
                        {
                            SqlConnection conn = new SqlConnection(cloud.StartConnection);
                            conn.Open();
                            SqlCommand command = new SqlCommand("delete from " + TblName + " where " + ColsName + " = " + val + ";", conn);
                            command.ExecuteNonQuery();
                            MessageBox.Show("تم حذف الصف بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            conn.Close();
                            Console.Clear();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
            }
        }

        private void Farm_Sheets_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void Report_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Report_List.SelectedIndex == 1)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("animal_reports");
                }
            }
            else if (Report_List.SelectedIndex == 2)
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("animal_purshase");
                }
            }
            else if (Report_List.SelectedIndex == 3)
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("animal_selling");
                }
            }
            else if (Report_List.SelectedIndex == 4)
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("medicine_purshase");
                }
            }
            else if (Report_List.SelectedIndex == 5)
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("medicine_selling");
                }
            }
            else if (Report_List.SelectedIndex == 6)
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("goods_purshase");
                }
            }
            else if (Report_List.SelectedIndex == 7)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("goods_selling");
                }
            }
            else if (Report_List.SelectedIndex == 8)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("SafePurshase");
                }
            }
            else if (Report_List.SelectedIndex == 9)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("SafeSelling");
                }
            }
            else if (Report_List.SelectedIndex == 10)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("ChequePurshase");
                }
            }
            else if (Report_List.SelectedIndex == 11)
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("ChequeSelling");
                }
            }




        }

        private void resetData_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("سوف يتم حذف جميع البيانات الخاصة بالنظام ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                confirmPanel.Visible = true;
            }

        }
        private List<string> TablesName(List<string> tblsList)
        {
            SqlConnection connection = new SqlConnection(cloud.StartConnection);
            try
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT name FROM sys.Tables", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tblsList.Add(reader[0].ToString());
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            return tblsList;
        }
        private void confirm_Click(object sender, EventArgs e)
        {
            if (UserNameApplication.Password != null)
            {
                if (UserNameApplication.Password == confirmPassword.Text)
                {

                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("clearData");
                    }

                }
                else
                {
                    MessageBox.Show("كلمة المرور غير صحيحة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("برجاء المحاولة لاحقا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(confirmPassword.Text))
            {
                confirm.Enabled = true;
            }
            else
            {
                confirm.Enabled = false;

            }
        }

        private void closeConPanel_Click(object sender, EventArgs e)
        {
            confirmPanel.Visible = false;
        }
    }
}
