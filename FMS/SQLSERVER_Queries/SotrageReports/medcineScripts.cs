using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.SotrageReports
{
    class medcineScripts
    {
        CloudConnection cloud = new CloudConnection();
        public void DisplayData(Guna2ComboBox getAnavar, Guna2ComboBox service_type, Guna2ComboBox  med_type,DataTable dt,DataTable dt3)
        {
            try
            {
                if (getAnavar.SelectedIndex == -1 || service_type.SelectedIndex == -1)
                {
                    MessageBox.Show("برجاء اختيار العنبر ونوع الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (service_type.SelectedIndex == 0)   // شراء
                    {

                        if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working  as [نوع الحركة] from medicine_premession where type_working  = N'شراء' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "'";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();


                        }
                        else
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'شراء' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();
                        }
                    }

                    else if (service_type.SelectedIndex == 1)   // صرف
                    {

                        if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'صرف' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "'";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();


                        }
                        else
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'صرف' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();
                        }




                    }
                    else
                    {

                        if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where  anavar  = N'" + getAnavar.SelectedItem.ToString() + "'";
                            cmd.ExecuteNonQuery();
                            SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                            da2.Fill(dt);
                            cn.Close();


                        }
                        else
                        {
                            SqlConnection cn = new SqlConnection(cloud.StartConnection);
                            cn.Open();
                            SqlCommand cmd2 = cn.CreateCommand();
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                            cmd2.ExecuteNonQuery();
                            SqlDataAdapter da = new SqlDataAdapter(cmd2);
                            da.Fill(dt3);
                            cn.Close();


                            cn.Open();
                            SqlCommand cmd = cn.CreateCommand();
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where  anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
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


        public void InterlView(Guna2ComboBox getAnavar, Guna2ComboBox service_type,Guna2DateTimePicker fromDate, Guna2DateTimePicker toDate, Guna2ComboBox med_type, DataTable dt, DataTable dt3)
        {

            if (service_type.SelectedIndex == 0)   // شراء
            {

                if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'شراء' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and   date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'   ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();


                }
                else
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'شراء' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' and  date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'   ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();
                }
            }

            else if (service_type.SelectedIndex == 1)   // صرف
            {

                if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'صرف' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "'  and  date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'  ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();


                }
                else
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where type_working  = N'صرف' and anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' and  date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'   ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();
                }


            }
            else
            {

                if (med_type.SelectedIndex == -1)  // في حالة عدم اختيار نوع الدواء
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where  anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and  date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'  ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();


                }
                else
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd2 = cn.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],numbers as [العدد],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine  = N'" + med_type.SelectedItem.ToString() + "' ";
                    cmd2.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(dt3);
                    cn.Close();


                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],anavar as [العنبر],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [العدد],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],type_working as [نوع الحركة] from medicine_premession where  anavar  = N'" + getAnavar.SelectedItem.ToString() + "' and medicine  = N'" + med_type.SelectedItem.ToString() + "' and  date between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'   ";
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    da2.Fill(dt);
                    cn.Close();
                }

            }




        }

        public void LoadData(Guna2ComboBox getAnavar, Guna2ComboBox med_type)
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
                cn.Close();


                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select DISTINCT medicine from immunization", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    med_type.Items.Add(rd2[0].ToString());
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
