using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.SotrageReports
{
    class AnavarScripts
    {
        CloudConnection cloud = new CloudConnection();
        public void DisplayData(Guna2ComboBox service_type, Guna2ComboBox animal_type, Guna2ComboBox getAnavar, DataTable dt, DataTable dt3)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                if (service_type.SelectedIndex == 0)   // شراء
                {

                    if (animal_type.SelectedIndex == -1)
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' and service_type = N'شراء'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();


                    }
                    else
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' and animal_name = N'" + animal_type.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();



                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "' and service_type = N'شراء'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();
                    }
                }

                else if (service_type.SelectedIndex == 1)   // بيع
                {

                    if (animal_type.SelectedIndex == -1)  // عرض الجداول بدون حيوان مخصص
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' and service_type = N'بيع'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();


                    }
                    else
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'  and animal_name = N'" + animal_type.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();



                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "'  and service_type = N'بيع'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();
                    }
                }
                else
                {
                    if (animal_type.SelectedIndex == -1)  // عرض الجداول بدون حيوان مخصص
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();


                    }
                    else
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'  and animal_name = N'" + animal_type.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();



                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "'";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();
                    }
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

        public void getAnaverSetting(Guna2ComboBox animal_type, Guna2ComboBox  getAnavar)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("select animal_name from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'  ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                animal_type.Items.Clear();
                while (rd.Read())
                {
                    animal_type.Items.Add(rd[0].ToString());
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

        public void DisplayByInterval(Guna2ComboBox service_type, Guna2ComboBox animal_type, Guna2DateTimePicker fromDate, Guna2DateTimePicker toDate, Guna2ComboBox getAnavar, DataTable dt, DataTable dt3)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                string getfromDatInterval = fromDate.Value.Date.ToString("yyy-MM-dd");
                string getToDatInterval = toDate.Value.Date.ToString("yyy-MM-dd");

                if (service_type.SelectedIndex == 0)   // شراء
                {

                    if (animal_type.SelectedIndex == -1)
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' and service_type = N'شراء'  and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();


                    }
                    else
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();



                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "' and service_type = N'شراء'  and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();
                    }
                }

                else if (service_type.SelectedIndex == 1)   // بيع
                {

                    if (animal_type.SelectedIndex == -1)  // عرض الجداول بدون حيوان مخصص
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' and service_type = N'بيع'  and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();


                    }
                    else
                    {
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt3);
                        cn.Close();



                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "'  and service_type = N'بيع'  and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt);
                        cn.Close();
                    }
                }
                else

                {
                    // بيع
                    {

                        if (animal_type.SelectedIndex == -1)  // عرض الجداول بدون حيوان مخصص
                        {
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();


                        }
                        else
                        {
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي] from animal_storage where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "' ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();



                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select date as [التاريخ],supplier_name as [نوع الحساب],anavar_name as [اسم العنبر],payment_method as [طريقةالدفع],treasury as [الخزينة], animal_name as [نوع الحيوان],numbers as [العدد],price as [السعر],total as [الإجمالي],service_type as [نوع الخدمة] from animals_premession where anavar_name = N'" + getAnavar.SelectedItem.ToString() + "'   and animal_name = N'" + animal_type.SelectedItem.ToString() + "'   and  date between '" + getfromDatInterval + "' and '" + getToDatInterval + "'  ";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();
                        }
                    }
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

        public void LoadData(Guna2ComboBox getAnavar)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT anavar_name from animal_storage", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    getAnavar.Items.Add(rd[0].ToString());
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
