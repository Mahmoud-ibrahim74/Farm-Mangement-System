using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.PaymentVoucher_Scripts
{
    class ChequeAdding
    {
        CloudConnection cloud = new CloudConnection();
        Guna2ComboBox Bank_Name;
        Guna2ComboBox acc_name;

        public ChequeAdding(Guna2ComboBox Bank_Name, Guna2ComboBox acc_name)
        {
            this.Bank_Name = Bank_Name;
            this.acc_name = acc_name;
        }

        public void LoadData()
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select bank_Name from bank_intial", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                while (rd3.Read())
                {
                    Bank_Name.Items.Add(rd3[0].ToString());

                }
                cn.Close();

                cn.Open();

                SqlCommand cmd4 = new SqlCommand("select account_name  from account_intiail", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                while (rd4.Read())
                {
                    acc_name.Items.Add(rd4[0].ToString());

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

        public void DisplayBalance(Guna2TextBox bank_balance)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd3 = new SqlCommand("select bank_balance from bank_intial where bank_Name= N'" + Bank_Name.SelectedItem.ToString() + "' ", cn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            if (rd3.Read())
            {
                bank_balance.Text = rd3[0].ToString();

            }
            cn.Close();
        }

        public void DisplayData(DataTable dt, DataTable dt3)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select prem_id as [رقم الإذن], date as [التاريخ],bank_name as [اسم البنك],acc_name as [اسم الحساب],amount as [المبلغ],check_No as [رقم الشيك],check_date as [تاريخ الشيك],notes as [ملاحظات] from Premession_Check where service_type = N'توريد' and bank_name = N'" + Bank_Name.SelectedItem.ToString() + "' and  date = CAST(GETDATE() AS date); ";
                cmd2.ExecuteNonQuery();


                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);


                cn.Close();


                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select bank_Name as [اسم البنك],branch_name as[اسم الفرع],account_number as [رقم الحساب],bank_balance as [رصيد الحساب] from bank_intial   where bank_Name = N'" + Bank_Name.SelectedItem.ToString() + "'";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                da3.Fill(dt3);
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

        public void InsertData(Guna2DateTimePicker getDate, Guna2TextBox amount, Guna2TextBox cheque_number, Guna2DateTimePicker cheque_date, Guna2TextBox notes)
        {

            try

            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();                                                  // create Transactions for Bank Balance
                SqlCommand cmd = new SqlCommand("begin tran t1\n" +
                    "insert into Premession_Check(date, bank_name, acc_name, amount, check_No, check_date, notes, service_type)  Values(@dat, @bn, @an, @am, @cn, @cd, @not, N'توريد')\n" +
                    "commit tran t1;", cn);
                cmd.Parameters.AddWithValue("@dat", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@bn", Bank_Name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@an", acc_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@am", amount.Text);
                cmd.Parameters.AddWithValue("@cn", cheque_number.Text);
                cmd.Parameters.AddWithValue("@cd", cheque_date.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                 "update bank_intial set bank_balance = bank_balance+" + amount.Text + " where bank_Name = N'" + Bank_Name.SelectedItem.ToString() + "';\n" +
                 "commit  tran t2;", cn);
                cmd2.ExecuteNonQuery();
                cn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("رقم الشيك موجود مسبقا", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (ex.Message.Contains("A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: TCP Provider, error: 0 - No such host is known.)"))
                {

                    MessageBox.Show("خطأ في الأتصال بالخادم برجاء التحقق من اتصالك بالأنترنت", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        public void RolledBack_Transaction(DataGridView tableB)
        {

            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();

            string getAmount = tableB.SelectedCells[4].Value.ToString(); 
            if (MessageBox.Show("هل تريد استرجاع المبلغ الإذن رقم '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();

                    SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    "update bank_intial set bank_balance = bank_balance-"+getAmount+ " where bank_Name = N'" + Bank_Name.SelectedItem.ToString() + "';\n" +
                    "commit  tran t2;", cn);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("delete from Premession_Check where prem_id = " + getIDRows + " ", cn);
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

    }
}
