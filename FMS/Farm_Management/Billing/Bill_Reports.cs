using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms; 

namespace FMS.Billing
{
    class Bill_Reports
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();  
        public void DisplayTables(Guna.UI2.WinForms.Guna2ComboBox billType,DataTable dt0, DataTable dt1, DataTable dt2)
        {
            switch (billType.SelectedIndex)
            {
                case 0:
                    try
                    {
                        SqlConnection cn = new SqlConnection(cloud.StartConnection);
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select bill_id as [رقم الفاتورة],goods_name as [اسم الصنف],product_value as [قيمة البضاعة],transmit_value as [قيمة النقل],value_added_tax as [الضريبة المضافة],total as [إجمالي الفاتورة],type_working as [نوع الحركة] from bill_goods", cn);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt0);
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
                    break;

                case 1:
                    try
                    {
                        SqlConnection cn = new SqlConnection(cloud.StartConnection);
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select bill_id as [رقم الفاتورة],animal_name as [اسم الحيوان],product_value as [قيمة البضاعة],transmit_value as [قيمة النقل],value_added_tax as [الضريبة المضافة],total as [إجمالي الفاتورة],type_working as [نوع الحركة] from bill_for_animals", cn);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt1);
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
                    break;

                case 2:
                    try
                    {
                        SqlConnection cn = new SqlConnection(cloud.StartConnection);
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("select bill_id as [رقم الفاتورة],medicine_name as [اسم الدواء /المصل],product_value as [قيمة الدواء],transmit_value as [قيمة النقل],value_added_tax as [الضريبة المضافة],total as [الإجمالي],type_working as [نوع الحركة] from medicineBill  ", cn);
                        cmd.ExecuteNonQuery();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt2);
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
                    break;


                default:
                    break;
            }
        }

        public void getSelectedRows(DataGridView tableB)
        {

            for (int i = 0; i < tableB.RowCount; i++)
            {
                if (!tableB.Rows[i].Cells[0].Selected)
                {
                    tableB.Rows.RemoveAt(i);
                }

            }


        }
        public void TotalAlogrithm(DataGridView tableB,Guna.UI2.WinForms.Guna2TextBox totalBills)
        {
            double get_Sum = 0;
            for (int i = 0; i < tableB.Rows.Count; i++)
            {
                if (tableB[5, i].Value.ToString() != null)
                {
                    get_Sum = get_Sum + Convert.ToDouble(tableB[5, i].Value.ToString());
                }
            }
            totalBills.Text = get_Sum.ToString();
        }
    }
}
