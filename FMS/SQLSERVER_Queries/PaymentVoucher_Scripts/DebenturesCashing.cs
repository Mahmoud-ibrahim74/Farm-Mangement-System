using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.PaymentVoucher_Scripts
{
    class DebenturesCashing
    {
        CloudConnection cloud = new CloudConnection();

        public void LoadData(Guna2ComboBox Treasury_Name, Guna2ComboBox acc_name)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select DISTINCT Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                while (rd3.Read())
                {
                    Treasury_Name.Items.Add(rd3[0].ToString());

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

        public void DisplayBalance(Guna2TextBox tre_balance, Guna2ComboBox Treasury_Name)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd3 = new SqlCommand("select Treasury_Balance from Cash_Treasury  where Treasury_Name = N'" + Treasury_Name.SelectedItem.ToString() + "' ", cn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            if (rd3.Read())
            {
                tre_balance.Text = rd3[0].ToString();

            }
            cn.Close();
        }
        public void getAccountType(Guna2TextBox getAccount_Type, Guna2ComboBox acc_name)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd3 = new SqlCommand("select main_acc_name from account_intiail where account_name= N'" + acc_name.SelectedItem.ToString() + "' ", cn);
            SqlDataReader rd3 = cmd3.ExecuteReader();
            if (rd3.Read())
            {
                getAccount_Type.Text = rd3[0].ToString();

            }
            cn.Close();
        }


        public void DisplayData(DataTable dt, DataTable dt3, Guna2ComboBox Treasury_Name)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select prem_id as [رقم الإذن], date as[التاريخ],Treasury as [الخزينة],acc_name as[اسم الحساب],amount as [المبلغ],acc_type [نوع الحساب],notes as [ملاحظات] from Premession_Cash where service_type = N'صرف' and  date = CAST(GETDATE() AS date);";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select Treasury_Name as [اسم الخزينة],Person_Name as [اسم المسؤول],Treasury_Balance as [رصيد الخزينة] from Cash_Treasury where Treasury_Name = N'" + Treasury_Name.SelectedItem.ToString() + "'";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                da2.Fill(dt3);
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


        public void InsertData(Guna2DateTimePicker getDate, Guna2ComboBox Treasury_Name, Guna2ComboBox acc_name, Guna2TextBox amount, Guna2TextBox getAccount_Type, Guna2TextBox notes)
        {
            try

            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into Premession_Cash(date,Treasury,acc_name,amount,acc_type,notes,service_type)  Values (@dat,@t,@an,@am,@at,@not,N'صرف')", cn);
                cmd.Parameters.AddWithValue("@dat", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@t", Treasury_Name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@an", acc_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@am", amount.Text);
                cmd.Parameters.AddWithValue("@at", getAccount_Type.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال السند بنجاح ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                "update Cash_Treasury set Treasury_Balance = Treasury_Balance - " + amount.Text + " where Treasury_Name = N'" + Treasury_Name.SelectedItem.ToString() + "';\n" +
                "commit  tran t2;", cn);
                cmd2.ExecuteNonQuery();
                cn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }



        public void RolledBack_Transaction(DataGridView tableB, Guna2TextBox amount, Guna2ComboBox Treasury_Name)
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

                    SqlCommand cmd2 = new SqlCommand("begin tran t2;\n" +
                        "update Cash_Treasury set Treasury_Balance = Treasury_Balance + "+getAmount+" where Treasury_Name = N'"+Treasury_Name.SelectedItem.ToString()+"';\n" +
                        "commit  tran t2; ", cn);
                    cmd2.ExecuteNonQuery();

                    SqlCommand cmd = new SqlCommand("delete from Premession_Cash where prem_id = " + getIDRows + " ", cn);
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
