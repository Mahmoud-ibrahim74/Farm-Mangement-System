using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class medicineIntializer
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
                cmd2.CommandText = "select medicine as [اسم الدواء/المصل],medicine_unit as [وحدة المصل],numbers as [العدد],price as [السعر],total as [الاجمالي],notes as [ملاحظات] from immunization";
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


        public void InsertMedicine(Guna2TextBox med_name, Guna2TextBox unit, Guna2TextBox numbers, Guna2TextBox price, Guna2TextBox total, Guna2TextBox notes)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into immunization (medicine,medicine_unit,numbers,price,total,notes)  Values(@ana,@unit,@no,@dos,@age,@not)", cn);
                cmd.Parameters.AddWithValue("@ana", med_name.Text);
                cmd.Parameters.AddWithValue("@unit", unit.Text);
                cmd.Parameters.AddWithValue("@no", numbers.Text);
                cmd.Parameters.AddWithValue("@dos", price.Text);
                cmd.Parameters.AddWithValue("@age", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال البيانات", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }

            catch (SqlException ex)
            {

                if (ex.Number == 2627) //  Exception error of primary key
                {
                    MessageBox.Show(" اسم الدواء  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        public void UpdateMedicine(string unit, string numbers, string price, string total, string notes, string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update immunization set medicine_unit=@unit,numbers=@no,price=@pri,total=@tot,notes=@not where medicine = N'" + getRowData0+"' ", cn);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@no", numbers);
                cmd.Parameters.AddWithValue("@pri", price);
                cmd.Parameters.AddWithValue("@tot", total);
                cmd.Parameters.AddWithValue("@not", notes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
            catch (SqlException ex)
            {

                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(" اسم الدواء  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key
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

        public void DeleteMedicine(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from immunization where medicine = N'" + getRowData0 + "' ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم حذف الدواء بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }








    }
}
