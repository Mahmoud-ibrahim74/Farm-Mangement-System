using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.Basic_Data
{
    class AccountIntial
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
                cmd2.CommandText = "select account_name as [اسم الحساب],main_acc_name as [اسم الحساب الرئيسي],respon_person as[الشخص المسؤول],address as [العنوان],phone as[رقم الهاتف], notes as[ملاحظات]  from account_intiail";
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


        public void InsertAccount(Guna2TextBox account_name, Guna2ComboBox main_account, Guna2TextBox person, Guna2TextBox address, Guna2TextBox phone, Guna2TextBox an_phone)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into account_intiail(account_name,main_acc_name,respon_person,address,phone,notes) values (@an,@mn,@rp,@add,@ph,@anPh)", cn);
                cmd.Parameters.AddWithValue("@an", account_name.Text);
                cmd.Parameters.AddWithValue("@mn", main_account.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@rp", person.Text);
                cmd.Parameters.AddWithValue("@add", address.Text);
                cmd.Parameters.AddWithValue("@ph", phone.Text);
                cmd.Parameters.AddWithValue("@anPh", an_phone.Text);
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

        public void UpdateAccount(string main, string res, string address, string phone, string note,string getRowData0)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update account_intiail set main_acc_name  = @main,respon_person=@res,address = @add,phone = @ph,notes=@nt where account_name = @acc_name ", cn);
                cmd.Parameters.AddWithValue("@main", main);
                cmd.Parameters.AddWithValue("@res", res);
                cmd.Parameters.AddWithValue("@add", address);
                cmd.Parameters.AddWithValue("@ph", phone);
                cmd.Parameters.AddWithValue("@nt", note);
                cmd.Parameters.AddWithValue("@acc_name", getRowData0);
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

        public void DeleteAccount(string getRowData0)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("delete from account_intiail where account_name = N'"+getRowData0+"' ", cn);
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



    }
}
