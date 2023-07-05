using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class AnimalIntilaizer
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
                cmd2.CommandText = "select animal_id as[رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [اسم العنبر],numbers as [العدد],price_per_numbers as [السعر لكل رأس],total as [الإجمالي],notes as [ملاحظات] from animal_storage";
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


        public void InsertAnimal(Guna2TextBox animal_name, Guna2ComboBox getSotrage, Guna2TextBox notes, Guna2TextBox numbers, Guna2TextBox price, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into animal_storage(animal_name,anavar_name,notes,numbers,price_per_numbers,total) Values(@an,@ana,@not,@no,@pri,@tot)", cn);
                cmd.Parameters.AddWithValue("@an", animal_name.Text);
                cmd.Parameters.AddWithValue("@ana", getSotrage.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.Parameters.AddWithValue("@no", numbers.Text);
                cmd.Parameters.AddWithValue("@pri", price.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال البيانات", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();


            }
            catch (SqlException ex)
            {

                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(" اسم الحيوان  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key
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

        public void UpdateAnimal(string animal_name, string getSotrage,string numbers, string price, string total, string notes, string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update animal_storage set animal_name  = @an,anavar_name=@anv,numbers = @no,price_per_numbers = @price,total=@tot,notes=@not where animal_id = @an_id ", cn);
                cmd.Parameters.AddWithValue("@an", animal_name);
                cmd.Parameters.AddWithValue("@anv", getSotrage);
                cmd.Parameters.AddWithValue("@no", numbers);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@tot", total);
                cmd.Parameters.AddWithValue("@not", notes);
                cmd.Parameters.AddWithValue("@an_id", getRowData0);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();

            }
            catch (SqlException ex)
            {

                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show(" اسم الحساب  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error); //  Exception error of primary key
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

        public void DeleteAnimal(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from animal_storage where animal_id = "+getRowData0+"  ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("تم حذف الحساب بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cn.Close();
        }

        public void reset(Guna2TextBox account_name, Guna2ComboBox main_account, Guna2TextBox person, Guna2TextBox address, Guna2TextBox phone, Guna2TextBox an_phone)
        {
            account_name.Text = "";
            main_account.SelectedIndex = -1;
            person.Text = "";
            address.Text = "";
            phone.Text = "";
            an_phone.Text = "";


        }

        public void LoadData(Guna2ComboBox getSotrage)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select DISTINCT anavar_name from anavar", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    getSotrage.Items.Add(rd2["anavar_name"].ToString().Trim());
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


    }
}
