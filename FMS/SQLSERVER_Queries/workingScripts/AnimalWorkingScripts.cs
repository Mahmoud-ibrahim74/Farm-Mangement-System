using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.workingScripts
{
    class AnimalWorkingScripts
    {

        CloudConnection cloud = new CloudConnection();

        public void DisplayData(Guna2ComboBox anavar, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select premession_id as [رقم الحركة] , date as [التاريخ] ,supplier_name as [اسم المورد],anavar_name as [اسم العنبر],payment_method as [طريقة الدفع],treasury as [الخزينة],animal_name as [اسم الحيوان], numbers as [العدد],price as [السعر],total as [الإجمالي],notes as [ملاحظات]   from animals_premession where service_type = N'بيع' and anavar_name = N'" + anavar.SelectedItem.ToString() + "' and date = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [اسم العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي],notes as [ملاحظات] from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "'";
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

        public void backgroundAnavar(Guna2ComboBox anavar, Guna2ComboBox animal_type)
        {
            if (anavar.Items.Count > 0)
            {
                animal_type.Items.Clear();
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select animal_name from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "';", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    animal_type.Items.Add(rd2[0].ToString());
                }
                cn.Close();
            }
        }


        public void animalSelectBackground(Guna2TextBox numbers, Guna2TextBox price, Guna2ComboBox animal_type)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd2 = new SqlCommand("select numbers,price_per_numbers,total from animal_storage  where animal_name  = N'" + animal_type.SelectedItem.ToString() + "' ", cn);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                numbers.Text = rd2[0].ToString();
                price.Text = rd2[1].ToString();

            }
            cn.Close();
        }


        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox acc_name, Guna2ComboBox anavar, Guna2ComboBox payment, Guna2ComboBox treasuary, Guna2ComboBox animal_type, Guna2TextBox numbers, Guna2TextBox price, Guna2TextBox total, Guna2TextBox notes)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into animals_premession(date,supplier_name,anavar_name,payment_method,treasury,animal_name,numbers,price,total,notes,service_type) Values(@dt,@sn,@anav,@pm,@tre,@ani_name,@no,@pri,@tot,@not,N'بيع');", cn);

                cmd.Parameters.AddWithValue("@dt", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sn", acc_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@anav", anavar.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pm", payment.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tre", treasuary.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ani_name", animal_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@no", numbers.Text);
                cmd.Parameters.AddWithValue("@pri", price.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                //"update animal_storage set numbers = numbers -" + numbers.Text + " where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                //"update animal_storage set total = numbers*price_per_numbers where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                //"commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void deleteColumns(DataGridView tableB, Guna2ComboBox animal_type)
        {
            string getIDRows, getNumbers;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            getNumbers = tableB.SelectedCells[7].Value.ToString();

            if (MessageBox.Show("هل تريد استرجاع عدد الحركة رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    //"update animal_storage set numbers = numbers +" + getNumbers + " where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                    //"update animal_storage set total = numbers*price_per_numbers where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                    //"commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("delete from animals_premession  where premession_id = " + getIDRows + "  ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الحركة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveBill(Guna2ComboBox animal_type, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into bill_for_animals (animal_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'بيع')", cn);
                cmd.Parameters.AddWithValue("@pn", animal_type.SelectedItem.ToString());
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

        public void LoadData(Guna2ComboBox treasuary, Guna2ComboBox anavar, Guna2ComboBox acc_name)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    treasuary.Items.Add(rd[0].ToString());
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand(" select DISTINCT anavar_name from anavar", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();


                while (rd3.Read())
                {
                    anavar.Items.Add(rd3[0].ToString());
                }
                cn.Close();


                cn.Open();
                SqlCommand cmd4 = new SqlCommand("select DISTINCT account_name from account_intiail", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                while (rd4.Read())
                {
                    acc_name.Items.Add(rd4[0].ToString());
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



    class AnimalPurshaseScript
    {
        CloudConnection cloud = new CloudConnection();
        public void DisplayData(Guna2ComboBox anavar, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select premession_id as [رقم الحركة] , date as [التاريخ] ,supplier_name as [اسم المورد],anavar_name as [اسم العنبر],payment_method as [طريقة الدفع],treasury as [الخزينة],animal_name as [اسم الحيوان], numbers as [العدد],price as [السعر],total as [الإجمالي],notes as [ملاحظات]   from animals_premession where service_type = N'شراء' and anavar_name = N'" + anavar.SelectedItem.ToString() + "' and date = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select animal_id as [رقم الحيوان],animal_name as [نوع الحيوان],anavar_name as [اسم العنبر],numbers as [العدد],price_per_numbers as [السعر لكل حيوان],total as [الإجمالي],notes as [ملاحظات] from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "'";
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

        public void backgroundAnavar(Guna2ComboBox anavar, Guna2ComboBox animal_type)
        {
            if (anavar.Items.Count > 0)
            {
                animal_type.Items.Clear();
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select animal_name from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "';", cn);
                SqlDataReader rd2 = cmd2.ExecuteReader();
                while (rd2.Read())
                {
                    animal_type.Items.Add(rd2[0].ToString());
                }
                cn.Close();
            }
        }


        public void animalSelectBackground(Guna2TextBox numbers, Guna2TextBox price, Guna2ComboBox animal_type)
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd2 = new SqlCommand("select numbers,price_per_numbers,total from animal_storage  where animal_name  = N'" + animal_type.SelectedItem.ToString() + "' ", cn);
            SqlDataReader rd2 = cmd2.ExecuteReader();
            while (rd2.Read())
            {
                numbers.Text = rd2[0].ToString();
                price.Text = rd2[1].ToString();

            }
            cn.Close();
        }


        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox acc_name, Guna2ComboBox anavar, Guna2ComboBox payment, Guna2ComboBox treasuary, Guna2ComboBox animal_type, Guna2TextBox numbers, Guna2TextBox price, Guna2TextBox total, Guna2TextBox notes)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into animals_premession(date,supplier_name,anavar_name,payment_method,treasury,animal_name,numbers,price,total,notes,service_type) Values(@dt,@sn,@anav,@pm,@tre,@ani_name,@no,@pri,@tot,@not,N'شراء');", cn);

                cmd.Parameters.AddWithValue("@dt", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@sn", acc_name.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@anav", anavar.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@pm", payment.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@tre", treasuary.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@ani_name", animal_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@no", numbers.Text);
                cmd.Parameters.AddWithValue("@pri", price.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.Parameters.AddWithValue("@not", notes.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ادخال الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                //"update animal_storage set numbers = numbers +"+numbers.Text+" where animal_name = N'"+animal_type.SelectedItem.ToString()+"';\n" +
                //"update animal_storage set total = numbers*price_per_numbers where animal_name = N'"+animal_type.SelectedItem.ToString()+"';\n"+
                //"commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void deleteColumns(DataGridView tableB,Guna2ComboBox animal_type)
        {
            string getIDRows,getNumbers;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            getNumbers = tableB.SelectedCells[7].Value.ToString();

            if (MessageBox.Show("هل تريد استرجاع عدد الحركة رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    //"update animal_storage set numbers = numbers -" +getNumbers+ " where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                    //"update animal_storage set total = numbers*price_per_numbers where animal_name = N'" + animal_type.SelectedItem.ToString() + "';\n" +
                    //"commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    SqlCommand cmd = new SqlCommand("delete from animals_premession  where premession_id = " + getIDRows + "  ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الحركة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveBill(Guna2ComboBox animal_type, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into bill_for_animals (animal_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'شراء')", cn);
                cmd.Parameters.AddWithValue("@pn", animal_type.SelectedItem.ToString());
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

        public void LoadData(Guna2ComboBox treasuary, Guna2ComboBox anavar, Guna2ComboBox acc_name)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select Treasury_Name from Cash_Treasury", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    treasuary.Items.Add(rd[0].ToString());
                }
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = new SqlCommand(" select DISTINCT anavar_name from anavar", cn);
                SqlDataReader rd3 = cmd3.ExecuteReader();


                while (rd3.Read())
                {
                    anavar.Items.Add(rd3[0].ToString());
                }
                cn.Close();


                cn.Open();
                SqlCommand cmd4 = new SqlCommand("select DISTINCT account_name from account_intiail", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                while (rd4.Read())
                {
                    acc_name.Items.Add(rd4[0].ToString());
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
