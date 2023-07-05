using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace FMS.Working
{
    public partial class SwapProduct : Form
    {
        DataTable dt = new DataTable();
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public SwapProduct()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

            datePanel.Text = DateTime.Now.ToLongDateString();
            this.tableB.ScrollBars = ScrollBars.None;

        }
        public void MovePic(object sender)
        {
            Guna2Button b = (Guna2Button)sender;
        }

        private void employees_mangement_Load(object sender, System.EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }
        private void LoadData()
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select DISTINCT storage_name from storage", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                while (rd3.Read())
                {
                    toStorage.Items.Add(rd3[0].ToString());
                    fromStorage.Items.Add(rd3[0].ToString());

                }
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

        private void guna2Button3_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (fromStorage.SelectedIndex == -1)
            {

                MessageBox.Show("برجاء اختيار المخزن اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (product_name.SelectedIndex == -1)
            {

                MessageBox.Show("برجاء اختيار الصنف اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("displayData");
                }
            }

        }
        private void DisplayData()
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select DISTINCT storage_name as 'اسم المخزن',respon_name as 'اسم المسؤول',product_name as 'اسم الصنف', amount as 'الكمية',price as 'السعر',cost as 'الأجمالي',notes as 'ملاحظات' from storage";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
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

        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
          
        }


        private void xuiBatteryPercentageAPI_Tick(object sender, System.EventArgs e)
        {
            batteryStatus.Value = xuiBatteryPercentageAPI.Value;
            ToolTip.SetToolTip(batteryStatus, "Battery Status : " + xuiBatteryPercentageAPI.Value);
        }


        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ControlName = (string)e.Argument;
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (ControlName == "displayData")
            {
                dt.Clear();
                DisplayData();
            }
            else if (ControlName == "insertPremession")
            {
                InsertPremession();
                dt.Clear();
                DisplayData();
            }
            else if (ControlName == "getAnimals")
            {
                getFromStorage();
            }
            else if (ControlName == "getGoods")
            {
                SetGoodsState();
            }
            
            else
            {
                LoadData();
            }

        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("calc.exe");

        }


        private void DisplayByInterval()
        {


        }


        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تحذف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("deleteCols");
                }
            }
        }
        private void deleteColumns()
        {
            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();


            if (MessageBox.Show("هل تريد حذف الحركة رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from medicine_premession where prem_id = " + getIDRows + " ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void anavar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("backAnavar");
            }
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (fromStorage.SelectedIndex == -1 || toStorage.SelectedIndex == -1 || product_name.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار المخزن والصنف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تضيف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (amount.Text == "")
            {
                errorProvider.SetError(amount, "ادخل الكمية");

            }
            else if (price.Text == "")
            {
                errorProvider.SetError(price, "ادخل السعر");


            }
            else if (unit.SelectedIndex == -1)
            {
                errorProvider.SetError(unit, "اختر وحدة الوزن ");


            }
            else
            {
                if (MessageBox.Show("هل انت متأكد من تحويل البضاعة من  " + fromStorage.SelectedItem.ToString() + "   إلي مخزن " + toStorage.SelectedItem.ToString(), "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("insertPremession");
                    }
                }

            }


        }

        private void InsertPremession()
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("delete from storage where product_name = N'" + product_name.Text + "'  and storage_name = N'" + fromStorage.SelectedItem.ToString() + "'", cn);
                cmd2.ExecuteNonQuery();
                cn.Close();

                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into storage(storage_name,respon_name,product_name,amount,price,cost,notes) Values (@sn,@rn,@pn,@a,@pr,@co,@not); ", cn);
                cmd.Parameters.AddWithValue("@sn", toStorage.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rn", respon.Text);
                cmd.Parameters.AddWithValue("@pn", product_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@a", amount.Text);
                cmd.Parameters.AddWithValue("@pr", price.Text);
                cmd.Parameters.AddWithValue("@co", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                cn.Close();

              

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("insert into swap_products(date,from_storage,to_storage,product_name,product_unit,amount) Values ('" + getDate.Value.Date.ToString("yyyy-MM-dd") + "', N'" + fromStorage.SelectedItem.ToString() + "',N'" + toStorage.SelectedItem.ToString() + "',N'" + product_name.Text + "',N'" + unit.Text + "'," + amount.Text + ")", cn);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("تم تحويل البضاعة بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                cn.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void fromStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromStorage.Items.Count > 0)
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("getAnimals");
                }
            }
        }
        private void getFromStorage()
        {
            try
            {
                product_name.Items.Clear();
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select DISTINCT product_name from storage where storage_name = N'" + fromStorage.SelectedItem.ToString() + "';", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    product_name.Items.Add(rd2[0].ToString());
                }
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

        private void product_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("getGoods");
            }
        }
        private void SetGoodsState()
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select amount,price from storage where storage_name = N'" + fromStorage.SelectedItem.ToString() + "' and product_name = N'" + product_name.SelectedItem.ToString() + "'  ", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    amount.Text = rd2[0].ToString();
                    price.Text = rd2[1].ToString();

                }
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

        private void price_TextChanged(object sender, EventArgs e)
        {
            if (price.Text == "")
            {
                price.Text = "0.0";
            }




            double setTotal;
            double setPrice = Convert.ToDouble(price.Text);
            double setAmount = Convert.ToDouble(amount.Text);

            setTotal = setPrice * setAmount;
            total.Text = setTotal.ToString();
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {

            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
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

        private void SwapProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
