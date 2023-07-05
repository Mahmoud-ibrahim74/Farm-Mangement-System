using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class BankIntializer
    {
        CloudConnection cloud = new CloudConnection();

        public void DisplayData(DataTable dt)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select bank_Name as [اسم البنك],branch_name as [اسم الفرع],account_number as [رقم الحساب],bank_balance as [رصيد البنك] from bank_intial";
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


        public void InsertBank(Guna2TextBox bank_name, Guna2TextBox branch_name, Guna2TextBox account_number, Guna2TextBox bank_balance)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into bank_intial (bank_Name,branch_name,account_number,bank_balance) Values (@bN,@br,@an,@bb)", cn);
                cmd.Parameters.AddWithValue("@bN", bank_name.Text);
                cmd.Parameters.AddWithValue("@br", branch_name.Text);
                cmd.Parameters.AddWithValue("@an", account_number.Text);
                cmd.Parameters.AddWithValue("@bb", bank_balance.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }

            catch (SqlException ex)
            {

                if (ex.Number == 2627) //  Exception error of primary key
                {
                    MessageBox.Show(" اسم البنك  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        public void UpdateBank(string branch_name, string account_number, string bank_balance, string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update bank_intial set branch_name  =@br_name ,account_number  =@acc_no ,bank_balance =@bb  where bank_Name = N'"+getRowData0+"' ", cn);
                cmd.Parameters.AddWithValue("@br_name", branch_name);
                cmd.Parameters.AddWithValue("@acc_no", account_number);
                cmd.Parameters.AddWithValue("@bb", bank_balance);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
            catch (SqlException ex)
            {

                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(" اسم البنك  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key
                        break;

                    case 109:
                        MessageBox.Show("خطأ في أدخال البيانات برجاء المحاولة مرة اخري", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key
                        break;
                    case 20669:
                        MessageBox.Show("خطأ في أدخال البيانات برجاء المحاولة مرة اخري", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key

                        break;
                    default:
                        MessageBox.Show(ex.Message, "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

            }

        }

        public void DeleteBank(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from bank_intial where bank_Name = N'" + getRowData0 + "' ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم حذف الحساب بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }

        public void reset(Guna2TextBox bank_name, Guna2TextBox branch_name, Guna2TextBox account_number, Guna2TextBox bank_balance)
        {
            bank_name.Text = "";
            branch_name.Text = "";
            account_number.Text = "";
            bank_balance.Text = "";
        }



    }
}
