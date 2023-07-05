using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.SotrageReports
{

    class StorageScript
    {
        CloudConnection ConnURL = new CloudConnection();

            
        public void LoadData(Guna2ComboBox getStorage)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConnURL.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT  storage_name from  storage", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    getStorage.Items.Add(rd[0].ToString());
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
        public void DisplayData(Guna2ComboBox service_type, Guna2ComboBox product_type, Guna2ComboBox getStorage,DataTable dt,DataTable dt3)
        {
            try
            {
                if (service_type.SelectedIndex == 0)   // شراء
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,acc_type as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'شراء' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();


                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,acc_type  as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'شراء' and product_name =  N'" + product_type.SelectedItem.ToString() + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "'  ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();
                    }
                }

                else if (service_type.SelectedIndex == 1)   // بيع
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'صرف' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();


                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'صرف' and product_name =  N'" + product_type.SelectedItem.ToString() + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "'  ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();
                    }




                }
                else
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع',acc_type as [اسم الحساب], treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();


                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع',acc_type as [اسم الحساب], treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where   product_name =  N'" + product_type.SelectedItem.ToString() + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
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

        public void getGoodsStorage(Guna2ComboBox product_type, Guna2ComboBox getStorage)
        {

            try
            {
                SqlConnection cn = new SqlConnection(ConnURL.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT product_name from  storage where storage_name = N'" + getStorage.SelectedItem.ToString() + "'  ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                product_type.Items.Clear();
                while (rd.Read())
                {
                    product_type.Items.Add(rd[0].ToString());
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

        public void DisplayByInterval(Guna2ComboBox service_type, Guna2ComboBox product_type, Guna2ComboBox getStorage,Guna2DateTimePicker fromDate, Guna2DateTimePicker toDate, DataTable dt, DataTable dt3)
        {
            try
            {
                if (service_type.SelectedIndex == 0)   // شراء
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,acc_type  as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'شراء'  and  التاريخ between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "'and المخزن = N'" + getStorage.SelectedItem.ToString() + "'  ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();

                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,acc_type as [اسم الحساب],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'شراء' and product_name =  N'" + product_type.SelectedItem.ToString() + "' and  التاريخ between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "'  ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();
                    }
                }

                else if (service_type.SelectedIndex == 1)   // بيع
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'صرف' and  التاريخ between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();


                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where type_working = N'صرف' and product_name =  N'" + product_type.SelectedItem.ToString() + "' and  التاريخ between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "'  ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();
                    }




                }
                else
                {

                    if (product_type.SelectedIndex == -1)
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع',acc_type as [اسم الحساب], treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where التاريخ  between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
                        cn.Close();


                    }
                    else
                    {
                        SqlConnection cn = new SqlConnection(ConnURL.StartConnection);
                        cn.Open();
                        SqlCommand cmd2 = cn.CreateCommand();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع',acc_type as [اسم الحساب], treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي',type_working as [نوع الحركة] from goods_premession where   product_name =  N'" + product_type.SelectedItem.ToString() + "' and  التاريخ  between '" + fromDate.Value.Date.ToString("yyyy-MM-dd") + "' and '" + toDate.Value.Date.ToString("yyyy-MM-dd") + "' and المخزن = N'" + getStorage.SelectedItem.ToString() + "' ";
                        cmd2.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd2);
                        da.Fill(dt);
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd = cn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + getStorage.SelectedItem.ToString() + "' and  product_name = N'" + product_type.SelectedItem.ToString() + "' ";
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                        da2.Fill(dt3);
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












    }
}
