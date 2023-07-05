using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FMS.Basic_Data
{
    public partial class storage_animal : Form
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public storage_animal()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(guna2Panel3, guna2Panel1, connection, backgroundWorker);
            this.tableB.ScrollBars = ScrollBars.None;

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(anavar_name.Text) || string.IsNullOrEmpty(person.Text))
            {
                MessageBox.Show("برجاء ملئ جميع البيانات", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand(" insert into anavar(anavar_name) Values (@sn)", cn);
                cmd.Parameters.AddWithValue("@sn", anavar_name.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حفظ التعديل ", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                reset();


            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) //  Exception error of primary key
                {
                    MessageBox.Show(" اسم العنبر  موجود مسبقا برجاء ادخال اسم اخر", "Done", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }

        }

        private void account_intiail_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("loadData");
            }
        }

        private void LoadData()
        {
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select anavar_name from anavar", cn);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    account_modify.Items.Add(rd[0].ToString());
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

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (account_modify.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر خزينة", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("update Cash_Treasury  set Person_Name = @pn where Treasury_Name = N'" + account_modify.SelectedItem.ToString() + "' ", cn);
                cmd.Parameters.AddWithValue("@pn", person.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تعديل الحساب", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                reset();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (account_modify.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر عنبر", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection cn = new SqlConnection(cloud.StartConnection);

                cn.Open();
                SqlCommand cmd = new SqlCommand("delete from anavar where anavar_name= N'" + account_modify.SelectedItem.ToString() + "' ", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم حذف العنبر بنجاح", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                cn.Close();
            }


        }
        public void reset()
        {
            anavar_name.Text = "";
            person.Text = "";
            notes.Text = "";



        }

        private void storage_animal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string getProcessName = (string)e.Argument;
            if (getProcessName == "loadData")
            {
                LoadData();
            }
        }

        private void storage_animal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
