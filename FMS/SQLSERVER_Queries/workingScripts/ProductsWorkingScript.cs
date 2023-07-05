using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.SQLSERVER_Queries.workingScripts
{
    class ProductsWorkingScript
    {
        CloudConnection cloud = new CloudConnection();

        public void DisplayData(Guna2ComboBox storage, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي' from goods_premession where type_working  = N'صرف' and المخزن=N'" + storage.SelectedItem.ToString() + "' and التاريخ = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + storage.SelectedItem.ToString() + "' ";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                da2.Fill(dt3);
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
        public void StorageRetreive(Guna2ComboBox product_name, Guna2ComboBox storage)
        {
            try
            {
                product_name.Items.Clear();
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select DISTINCT product_name from storage where storage_name = N'" + storage.SelectedItem.ToString() + "';", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    product_name.Items.Add(rd2[0].ToString());


                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getAmountGoods(Guna2TextBox amount, Guna2TextBox price, Guna2ComboBox storage, Guna2ComboBox product_name)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select amount,price from storage where storage_name = N'" + storage.SelectedItem.ToString() + "' and product_name = N'" + product_name.SelectedItem.ToString() + "'  ", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    amount.Text = rd2[0].ToString();
                    price.Text = rd2[1].ToString();

                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox anavar_name, Guna2ComboBox storage, Guna2ComboBox payment, Guna2ComboBox treasuary, Guna2ComboBox product_name, Guna2ComboBox unit, Guna2TextBox amount, Guna2TextBox price, Guna2TextBox total, Guna2TextBox notes)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into goods_premession(التاريخ,anavar_name,المخزن,payment,treasury,product_name,weight_unit,amount,price,total,notes,type_working) Values (@d,@sn,@st,@pay,@tre,@pn,@wu,@am,@p,@tot,@not,N'صرف') ", cn);
                cmd.Parameters.AddWithValue("@d", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sn", anavar_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@st", storage.Text);

                cmd.Parameters.AddWithValue("@pay", payment.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tre", treasuary.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pn", product_name.SelectedItem.ToString());

                cmd.Parameters.AddWithValue("@wu", unit.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@am", amount.Text);
                cmd.Parameters.AddWithValue("@p", price.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال الاذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                // "update storage set amount = amount - " + amount.Text + " where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                // "update storage set cost = amount * price  where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                // "commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void SaveBill(Guna2ComboBox product_name, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into bill_goods (goods_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'صرف')", cn);
                cmd.Parameters.AddWithValue("@pn", product_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pv", product_value.Text);
                cmd.Parameters.AddWithValue("@tv", transmit_value.Text);
                cmd.Parameters.AddWithValue("@add", added_tax.Text);
                cmd.Parameters.AddWithValue("@tot", bill_value.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ الفاتورة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deleteColumns(DataGridView tableB, Guna2ComboBox product_name)
        {
            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            string getAmount = tableB.SelectedCells[8].Value.ToString();

            if (MessageBox.Show("هل تريد استرجاع كمية الإذن رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from goods_premession where premession_id = " + getIDRows + " ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    // "update storage set amount = amount + " + getAmount + " where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                    // "update storage set cost = amount * price  where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                    // "commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    //cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LoadData(Guna2ComboBox treasuary, Guna2ComboBox storage, Guna2ComboBox anavar_name)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                treasuary.Items.Clear();
                while (rd.Read())
                {
                    treasuary.Items.Add(rd[0].ToString());
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select DISTINCT storage_name from storage", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                storage.Items.Clear();
                while (rd3.Read())
                {
                    storage.Items.Add(rd3[0].ToString());
                }
                cn.Close();



                cn.Open();
                SqlCommand cmd6 = new SqlCommand("select DISTINCT anavar_name from anavar", cn);
                SqlDataReader rd6 = cmd6.ExecuteReader();
                anavar_name.Items.Clear();
                while (rd6.Read())
                {
                    anavar_name.Items.Add(rd6[0].ToString());
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


    class ProductPurshaseScript
    {
        CloudConnection cloud = new CloudConnection();
        public void DisplayData(Guna2ComboBox storage, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select premession_id as 'رقم الاذن',التاريخ,anavar_name as [اسم العنبر],المخزن,payment as 'طريقة الدفع', treasury as 'الخزينة',product_name as 'اسم الصنف',weight_unit as [وحدة الوزن],amount as 'الكمية',price as 'السعر',total as 'الأجمالي' from goods_premession where type_working  = N'شراء' and المخزن=N'" + storage.SelectedItem.ToString() + "' and التاريخ = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select storage_name as [اسم المخزن],product_name as [اسم الصنف],unit as [وحدة الوزن],amount as [الكمية],price as [السعر],cost as [التكلفة] from storage  where storage_name = N'" + storage.SelectedItem.ToString() + "' ";
                cmd3.ExecuteNonQuery();
                SqlDataAdapter da2 = new SqlDataAdapter(cmd3);
                da2.Fill(dt3);
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
        public void StorageRetreive(Guna2ComboBox product_name, Guna2ComboBox storage)
        {
            try
            {
                product_name.Items.Clear();
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select DISTINCT product_name from storage where storage_name = N'" + storage.SelectedItem.ToString() + "';", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    product_name.Items.Add(rd2[0].ToString());


                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getAmountGoods(Guna2TextBox amount, Guna2TextBox price, Guna2ComboBox storage, Guna2ComboBox product_name)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select amount,price from storage where storage_name = N'" + storage.SelectedItem.ToString() + "' and product_name = N'" + product_name.SelectedItem.ToString() + "'  ", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    amount.Text = rd2[0].ToString();
                    price.Text = rd2[1].ToString();

                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox acc_type, Guna2ComboBox anavar_name, Guna2ComboBox storage, Guna2ComboBox payment, Guna2ComboBox treasuary, Guna2ComboBox product_name, Guna2ComboBox unit, Guna2TextBox amount, Guna2TextBox price, Guna2TextBox total, Guna2TextBox notes)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into goods_premession(التاريخ,anavar_name,المخزن,payment,treasury,product_name,weight_unit,amount,price,total,acc_type,notes,type_working) Values (@d,@sn,@st,@pay,@tre,@pn,@wu,@am,@p,@tot,@ac_type,@not,N'شراء') ", cn);
                cmd.Parameters.AddWithValue("@d", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sn", anavar_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@st", storage.Text);

                cmd.Parameters.AddWithValue("@pay", payment.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tre", treasuary.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pn", product_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ac_type", acc_type.SelectedItem.ToString());

                cmd.Parameters.AddWithValue("@wu", unit.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@am", amount.Text);
                cmd.Parameters.AddWithValue("@p", price.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text.ToString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال الاذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                // "update storage set amount = amount + " + amount.Text + " where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                // "update storage set cost = amount * price  where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                // "commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void SaveBill(Guna2ComboBox product_name, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into bill_goods (goods_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'شراء')", cn);
                cmd.Parameters.AddWithValue("@pn", product_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pv", product_value.Text);
                cmd.Parameters.AddWithValue("@tv", transmit_value.Text);
                cmd.Parameters.AddWithValue("@add", added_tax.Text);
                cmd.Parameters.AddWithValue("@tot", bill_value.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ الفاتورة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deleteColumns(DataGridView tableB, Guna2ComboBox product_name)
        {
            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            string getAmount = tableB.SelectedCells[8].Value.ToString();

            if (MessageBox.Show("هل تريد استرجاع كمية الإذن رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from goods_premession where premession_id = " + getIDRows + " ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    // "update storage set amount = amount - " +getAmount+ " where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                    // "update storage set cost = amount * price  where product_name = N'" + product_name.SelectedItem.ToString() + "'\n" +
                    // "commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    //cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void LoadData(Guna2ComboBox treasuary, Guna2ComboBox storage, Guna2ComboBox anavar_name, Guna2ComboBox acc_type)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select DISTINCT Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                treasuary.Items.Clear();
                while (rd.Read())
                {
                    treasuary.Items.Add(rd[0].ToString());
                }
                cn.Close();


                cn.Open();
                SqlCommand cmd4 = new SqlCommand("select DISTINCT account_name from account_intiail", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                acc_type.Items.Clear();

                while (rd4.Read())
                {
                    acc_type.Items.Add(rd4[0].ToString());
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand("select DISTINCT storage_name from storage", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();
                storage.Items.Clear();
                while (rd3.Read())
                {
                    storage.Items.Add(rd3[0].ToString());
                }
                cn.Close();



                cn.Open();
                SqlCommand cmd6 = new SqlCommand("select DISTINCT anavar_name from anavar", cn);
                SqlDataReader rd6 = cmd6.ExecuteReader();
                anavar_name.Items.Clear();
                while (rd6.Read())
                {
                    anavar_name.Items.Add(rd6[0].ToString());
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
