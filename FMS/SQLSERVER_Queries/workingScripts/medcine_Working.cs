using Guna.UI2.WinForms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FMS.SQLSERVER_Queries.workingScripts
{
    class medcine_Working
    {
        CloudConnection cloud = new CloudConnection();

        public void DisplayData(Guna2ComboBox medicine, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [سحب رصيد المخزن],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي] from medicine_premession where type_working  = N'صرف' and date = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine = N'" + medicine.SelectedItem.ToString() + "'";
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

        public void getMedecineLoad(Guna2ComboBox medicine, Guna2TextBox numbers, Guna2TextBox unit, Guna2TextBox price, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select numbers,medicine_unit,price,total from immunization where medicine = N'" + medicine.SelectedItem.ToString() + "' ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    numbers.Text = rd[0].ToString();
                    unit.Text = rd[1].ToString();

                    price.Text = rd[2].ToString();
                    total.Text = rd[3].ToString();


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

        public void getAnavarAnimals(Guna2ComboBox animals_type, Guna2ComboBox anavar)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select  animal_name from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "'   ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                animals_type.Items.Clear();
                while (rd.Read())
                {
                    animals_type.Items.Add(rd[0].ToString());
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

        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox medicine, Guna2ComboBox storage, Guna2ComboBox anavar, Guna2TextBox desease, Guna2ComboBox animals_type, Guna2TextBox numbers, Guna2TextBox unit, Guna2TextBox cost, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into medicine_premession(date,medicine,storage,anavar,desease,animal_type,storage_balance,unit,cost,total,type_working) values (@d,@med,@st,@an,@des,@an_t,@bal,@un,@cost,@tot,N'صرف')", cn);
                cmd.Parameters.AddWithValue("@d", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@med", medicine.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@st", storage.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@an", anavar.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@des", desease.Text);
                cmd.Parameters.AddWithValue("an_t", animals_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@bal", numbers.Text);
                cmd.Parameters.AddWithValue("@un", unit.Text);
                cmd.Parameters.AddWithValue("@cost", cost.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم إدخال الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                //"update immunization set numbers  = numbers - "+numbers.Text+" where medicine = N'"+medicine.SelectedItem.ToString()+"';\n" +
                //"commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void deleteColumns(DataGridView tableB,Guna2ComboBox medicine)
        {
            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            string getCount;
            getCount = tableB.SelectedCells[6].Value.ToString();

            if (MessageBox.Show("هل تريد حذف العملية رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from medicine_premession where prem_id = " + getIDRows + " ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    //"update immunization set numbers  = numbers + " +getCount+ " where medicine = N'" + medicine.SelectedItem.ToString() + "';\n" +
                    //"commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveBill(Guna2ComboBox medicine, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into medicineBill (medicine_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'صرف')", cn);
                cmd.Parameters.AddWithValue("@pn", medicine.SelectedItem.ToString());
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


        public void LoadData(Guna2ComboBox medicine, Guna2ComboBox anavar)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select medicine from immunization", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                medicine.Items.Clear();
                while (rd.Read())
                {
                    medicine.Items.Add(rd[0].ToString());

                }
                cn.Close();

                cn.Open();
                SqlCommand cmd4 = new SqlCommand("select anavar_name from anavar", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                anavar.Items.Clear();
                while (rd4.Read())
                {
                    anavar.Items.Add(rd4[0].ToString());
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


    class medicine_Purshase
    {
        CloudConnection cloud = new CloudConnection();
        public void DisplayData(Guna2ComboBox medicine, DataTable dt, DataTable dt3)
        {
            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd2 = cn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select prem_id as [رقم الحركة], date as [التاريخ],medicine as [المصل/الدواء],storage as [المخزن],desease as[المرض],animal_type as [نوع الحيوان],storage_balance as [سحب رصيد المخزن],unit as [الوحدة],cost as [التكلفة],total as [الإجمالي],notes as [ملاحظات] from medicine_premession where type_working  = N'شراء' and date = CAST(GETDATE() AS DATE)";
                cmd2.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                cn.Close();

                cn.Open();
                SqlCommand cmd3 = cn.CreateCommand();
                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select medicine as [الدواء],medicine_unit as [وحدة الدواء],price as [السعر],total as [الاجمالي] ,notes as[ملاحظات] from immunization  where medicine = N'" + medicine.SelectedItem.ToString() + "'";
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

        public void getMedecineLoad(Guna2ComboBox medicine, Guna2TextBox numbers, Guna2TextBox unit, Guna2TextBox price, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select numbers,medicine_unit,price,total from immunization where medicine = N'" + medicine.SelectedItem.ToString() + "' ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    numbers.Text = rd[0].ToString();
                    unit.Text = rd[1].ToString();

                    price.Text = rd[2].ToString();
                    total.Text = rd[3].ToString();


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

        public void getAnavarAnimals(Guna2ComboBox animals_type, Guna2ComboBox anavar)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select  animal_name from animal_storage where anavar_name = N'" + anavar.SelectedItem.ToString() + "'   ", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                animals_type.Items.Clear();
                while (rd.Read())
                {
                    animals_type.Items.Add(rd[0].ToString());
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


        public void InsertPremession(Guna2DateTimePicker getDate, Guna2ComboBox medicine, Guna2ComboBox storage, Guna2ComboBox anavar, Guna2TextBox desease, Guna2ComboBox animals_type, Guna2TextBox numbers, Guna2TextBox unit, Guna2TextBox cost, Guna2TextBox total)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into medicine_premession(date,medicine,storage,anavar,desease,animal_type,storage_balance,unit,cost,total,type_working) values (@d,@med,@st,@an,@des,@an_t,@bal,@un,@cost,@tot,N'شراء')", cn);
                cmd.Parameters.AddWithValue("@d", getDate.Value.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@med", medicine.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@st", storage.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@an", anavar.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@des", desease.Text);
                cmd.Parameters.AddWithValue("an_t", animals_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@bal", numbers.Text);
                cmd.Parameters.AddWithValue("@un", unit.Text);
                cmd.Parameters.AddWithValue("@cost", cost.Text);
                cmd.Parameters.AddWithValue("@tot", total.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم إدخال الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                //"update immunization set numbers  = numbers + " + numbers.Text + " where medicine = N'" + medicine.SelectedItem.ToString() + "';\n" +
                //"commit  tran t2;", cn);
                //cmd2.ExecuteNonQuery();

                cn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void deleteColumns(DataGridView tableB, Guna2ComboBox medicine)
        {
            string getIDRows;
            getIDRows = tableB.SelectedCells[0].Value.ToString();
            string getCount;
            getCount = tableB.SelectedCells[6].Value.ToString();

            if (MessageBox.Show("هل تريد حذف العملية رقم  '" + getIDRows + "' ؟؟", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("delete from medicine_premession where prem_id = " + getIDRows + " ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الإذن بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //SqlCommand cmd2 = new SqlCommand("begin tran t2\n" +
                    //"update immunization set numbers  = numbers - " + getCount + " where medicine = N'" + medicine.SelectedItem.ToString() + "';\n" +
                    //"commit  tran t2;", cn);
                    //cmd2.ExecuteNonQuery();
                    cn.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaveBill(Guna2ComboBox medicine, Guna2TextBox product_value, Guna2TextBox transmit_value, Guna2TextBox added_tax, Guna2TextBox bill_value)
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into medicineBill (medicine_name,product_value,transmit_value,value_added_tax,total,type_working)  values (@pn,@pv,@tv,@add,@tot,N'شراء')", cn);
                cmd.Parameters.AddWithValue("@pn", medicine.SelectedItem.ToString());
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


        public void LoadData(Guna2ComboBox medicine, Guna2ComboBox anavar)
        {

            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select medicine from immunization", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                medicine.Items.Clear();
                while (rd.Read())
                {
                    medicine.Items.Add(rd[0].ToString());

                }
                cn.Close();

                cn.Open();
                SqlCommand cmd4 = new SqlCommand("select anavar_name from anavar", cn);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                anavar.Items.Clear();

                while (rd4.Read())
                {
                    anavar.Items.Add(rd4[0].ToString());
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
