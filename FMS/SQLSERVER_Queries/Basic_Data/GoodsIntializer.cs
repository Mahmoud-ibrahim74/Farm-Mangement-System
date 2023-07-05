using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class GoodsIntializer
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
                cmd2.CommandText = "select product_name as [اسم الصنف],storage_name as [اسم المخزن],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage";
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


        public void InsertGoods(Guna2TextBox storage_name, Guna2TextBox person, Guna2TextBox product,Guna2ComboBox unit, Guna2TextBox amount,Guna2TextBox price, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into storage(storage_name,product_name,unit,amount,price,cost)  Values (@sn,@pro,@u,@am,@pr,@cost)", cn);
                cmd.Parameters.AddWithValue("@sn", storage_name.Text);
                cmd.Parameters.AddWithValue("@pro", product.Text);
                cmd.Parameters.AddWithValue("@u", unit.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@am", amount.Text);
                cmd.Parameters.AddWithValue("@pr", price.Text);
                cmd.Parameters.AddWithValue("@cost", total.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627) //  Exception error of primary key
                {
                    MessageBox.Show(" اسم البضاعة  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        public void UpdateGoods(string storage_name, string unit, string amount, string price, string total ,string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update storage set storage_name =@sn,unit=@u,amount=@am,price=@pr,cost=@cost where product_name  = N'" + getRowData0 + "' ", cn);
                cmd.Parameters.AddWithValue("@sn", storage_name);
                cmd.Parameters.AddWithValue("@u", unit);
                cmd.Parameters.AddWithValue("@am", amount);
                cmd.Parameters.AddWithValue("@pr", price);
                cmd.Parameters.AddWithValue("@cost", total);
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

        public void DeleteGoods(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from storage where product_name = N'" + getRowData0 + "' ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم حذف الصنف بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }








    }
}
