using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class CashTreasury
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
                cmd2.CommandText = "select Treasury_Name as [اسم الخزينة],Person_Name as [الشخص المسؤول],Treasury_Balance as [رصيد الخزينة] from Cash_Treasury";
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


        public void InsertTreasuary(Guna2TextBox tre_name, Guna2TextBox person, Guna2TextBox balance)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into Cash_Treasury (Treasury_Name,Person_Name,Treasury_Balance) Values (@tn,@pn,@tb)", cn);
                cmd.Parameters.AddWithValue("@tn", tre_name.Text);
                cmd.Parameters.AddWithValue("@pn", person.Text);
                cmd.Parameters.AddWithValue("@tb", balance.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("تم إدخال  الخزينة ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }

            catch (SqlException ex)
            {

                if (ex.Number == 2627) //  Exception error of primary key
                {
                    MessageBox.Show(" اسم الخزينة  موجودة مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        public void UpdateTreasuary(string person, string balance ,string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update Cash_Treasury set Person_Name = @pn,Treasury_Balance =@tb where Treasury_Name = N'"+getRowData0+"' ", cn);
                cmd.Parameters.AddWithValue("@pn", person);
                cmd.Parameters.AddWithValue("@tb", balance);
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

        public void DeleteTreasuary(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from Cash_Treasury where Treasury_Name = N'" + getRowData0 + "' ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم حذف الخزينة بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }






    }
}
