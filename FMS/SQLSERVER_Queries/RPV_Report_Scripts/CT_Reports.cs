using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.RPV_Report_Scripts
{
    class CT_Reports
    {
        CloudConnection cloud = new CloudConnection();

        public void DisplayData(Guna2ComboBox service_type,DataTable dt, DataTable dt3,Guna2ComboBox getTreasure)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                if (service_type.SelectedIndex == 0)
                {
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where service_type = N'توريد' and Treasury = N'" + getTreasure.SelectedItem.ToString() + "'  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }
                else if (service_type.SelectedIndex == 1)
                {
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where service_type = N'صرف' and Treasury = N'" + getTreasure.SelectedItem.ToString() + "'  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }
                else
                {
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where  Treasury = N'" + getTreasure.SelectedItem.ToString() + "'  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }


                cn.Open();
                SqlCommand cmd4 = cn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select Treasury_Name as [اسم الخزينة],Person_Name as [اسم المسؤول],Treasury_Balance as [المبلغ] from Cash_Treasury where Treasury_Name = N'" + getTreasure.SelectedItem.ToString() + "' ";
                cmd4.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
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

        
        public void DisplayByInterval(Guna2ComboBox service_type, Guna2DateTimePicker fromDate, Guna2DateTimePicker toDate, Guna2ComboBox getTreasure, DataTable dt, DataTable dt3)
        {

            try //copied
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                if (service_type.SelectedIndex == 0) // توريد
                {
                    string getfromDatInterval = fromDate.Value.Date.ToString("yyy-MM-dd");
                    string getToDatInterval = toDate.Value.Date.ToString("yyy-MM-dd");
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;

                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where  date between '"+getfromDatInterval+"' and '"+getToDatInterval+"' and service_type  = N'توريد' and Treasury = N'"+getTreasure.SelectedItem.ToString()+"'  ";
                    cmd2.ExecuteNonQuery();
                    dt.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }
                else if (service_type.SelectedIndex == 1)
                {
                    string getfromDatInterval = fromDate.Value.Date.ToString("yyy-MM-dd");
                    string getToDatInterval = toDate.Value.Date.ToString("yyy-MM-dd");
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "' and service_type  = N'صرف' and Treasury = N'" + getTreasure.SelectedItem.ToString() + "'  ";
                    cmd2.ExecuteNonQuery();
                    dt.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }
                else
                {
                    string getfromDatInterval = fromDate.Value.Date.ToString("yyy-MM-dd");
                    string getToDatInterval = toDate.Value.Date.ToString("yyy-MM-dd");


                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select  date as[التاريخ],Treasury as [اسم الخزينة],acc_name as [اسم الحساب],amount as [المبلغ],acc_type as [نوع الحساب],service_type as [نوع الخدمة],notes as [ملاحظات] from Premession_Cash where  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "' and Treasury = N'" + getTreasure.SelectedItem.ToString() + "'  ";
                    cmd2.ExecuteNonQuery();
                    dt.Clear();

                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt);
                    cn.Close();
                }


                cn.Open();
                SqlCommand cmd4 = cn.CreateCommand();
                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select Treasury_Name as [اسم الخزينة],Person_Name as [اسم المسؤول],Treasury_Balance as [المبلغ] from Cash_Treasury where Treasury_Name = N'" + getTreasure.SelectedItem.ToString() + "' ";
                cmd4.ExecuteNonQuery();
                SqlDataAdapter da3 = new SqlDataAdapter(cmd4);
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

        public void LoadData(Guna2ComboBox getTreasure)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("select Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    getTreasure.Items.Add(rd[0].ToString());
                }

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
