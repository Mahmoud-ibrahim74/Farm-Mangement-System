using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Farm_Management
{
    public partial class employees_mangement : Form
    {
        string getUsername = "";
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public employees_mangement()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3,this.guna2GradientPanel4, this.panel1, this.connection, backgroundWorker);

            datePanel.Text = DateTime.Now.ToLongDateString();
        }

        public employees_mangement(string username)
        {
            InitializeComponent();
            datePanel.Text = DateTime.Now.ToLongDateString();
            getUsername = username; 
        }
        private void id_TextChanged(object sender, System.EventArgs e)
        {
            id.Text = string.Concat(id.Text.Where(char.IsDigit));

        }



        private void phone_TextChanged(object sender, System.EventArgs e)
        {
            phone.Text = string.Concat(phone.Text.Where(char.IsNumber));

        }

        private void show_CheckedChanged_1(object sender, System.EventArgs e)
        {
            if (show.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '●';
            }
        }

        private void confirm_show_CheckedChanged_1(object sender, System.EventArgs e)
        {
            if (confirm_show.Checked)
            {
                confirm_pass.PasswordChar = '\0';
            }
            else
            {
                confirm_pass.PasswordChar = '●';
            }
        }

        private void username_TextChanged(object sender, System.EventArgs e)
        {
            username.Text = string.Concat(username.Text.Where(char.IsLetterOrDigit));
        }

        
        public void reset()
        {
            emp_fname.Text = "";
            id.Text = "";
            userPic.Image = userPic.InitialImage;
            emp_lname.Text = "";
            phone.Text = "";
            user_type.SelectedIndex = -1;
            emp_address.Text = "";
            password.Text = "";
            confirm_pass.Text = "";
        }
  
        private void confirm_pass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (password.Text != confirm_pass.Text)
            {
                errorProvider.SetError(confirm_pass, "كلمات المرور غير متاطبقة");
            }
            else
            {
                errorProvider.Clear();
            }
        }

        private void guna2Button3_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(id.Text) && string.IsNullOrEmpty(username.Text))
            {
                errorProvider.SetError(username, "من فضلك أدخل   اسم المستخدم حتي تعرض البيانات");

            }

            else
            {

                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    xuiObjectAnimator.StandardAnimate(panelLoader, XanderUI.XUIObjectAnimator.StandardAnimation.SlideDown,5);
                    backgroundWorker.RunWorkerAsync("emp_display");
                }
            }

        }
        private void DisplayData()
        {

            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from user_management where  emp_username=@user;", cn);
                cmd.Parameters.AddWithValue("@user", username.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id.Text = rd["emp_id"].ToString();
                    emp_fname.Text = rd["emp_fname"].ToString();
                    emp_lname.Text = rd["emp_lname"].ToString();

                    phone.Text = rd["emp_phone"].ToString();
                    emp_address.Text = rd["emp_address"].ToString();

                    username.Text = rd["emp_username"].ToString();
                    user_type.Text = rd["user_type"].ToString();
                    password.Text = new PasswordSecure().Decrypt(rd["emp_password"].ToString());
                    confirm_pass.Text = new PasswordSecure().Decrypt(rd["emp_password"].ToString());

                }
                else
                {
                    MessageBox.Show("لا يوجد موظف بهذه البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                cn.Close();

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select user_pic from user_management where emp_username = N'" +username.Text+ "' ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["user_pic"]);
                    userPic.Image = new Bitmap(ms);

                 
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
                    Clipboard.SetText(ex.Message);

                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DisplayData(string setUsername)
        {

            try
            {

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("select * from user_management where  emp_username=@user;", cn);
                cmd.Parameters.AddWithValue("@user", setUsername);
                cmd.Parameters.AddWithValue("@id", id.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    id.Text = rd["emp_id"].ToString();
                    emp_fname.Text = rd["emp_fname"].ToString();
                    emp_lname.Text = rd["emp_lname"].ToString();

                    phone.Text = rd["emp_phone"].ToString();
                    emp_address.Text = rd["emp_address"].ToString();

                    username.Text = rd["emp_username"].ToString();
                    user_type.Text = rd["user_type"].ToString();
                    password.Text = new PasswordSecure().Decrypt(rd["emp_password"].ToString());
                    confirm_pass.Text = new PasswordSecure().Decrypt(rd["emp_password"].ToString());

                }
                else
                {
                    MessageBox.Show("لا يوجد موظف بهذه البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                cn.Close();

                cn.Open();
                SqlCommand cmd2 = new SqlCommand("select user_pic from user_management where emp_username = N'" + username.Text + "' ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["user_pic"]);
                    userPic.Image = new Bitmap(ms);


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
                    Clipboard.SetText(ex.Message);

                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button4_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(emp_fname.Text))
            {
                errorProvider.SetError(emp_fname, "ادخل الاسم الأول");
            }
            else if (string.IsNullOrEmpty(emp_lname.Text))
            {
                errorProvider.SetError(emp_lname, "ادخل الاسم الأخير");
            }
            else if (string.IsNullOrEmpty(id.Text))
            {
                errorProvider.SetError(id, "ادخل الرقم القومي");
            }
            else if (string.IsNullOrEmpty(emp_address.Text))
            {
                errorProvider.SetError(emp_address, "ادخل العنوان");
            }
            else if (string.IsNullOrEmpty(phone.Text))
            {
                errorProvider.SetError(phone, "ادخل رقم الهاتف");
            }
            else if (string.IsNullOrEmpty(username.Text))
            {
                errorProvider.SetError(username, "ادخل اسم المستخدم");
            }
            else if (user_type.SelectedIndex == -1)
            {
                errorProvider.SetError(user_type, "ادخل نوع المستخدم");
            }

            else if (password.Text != confirm_pass.Text)
            {
                MessageBox.Show("تأكد من كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    xuiObjectAnimator.StandardAnimate(panelLoader, XanderUI.XUIObjectAnimator.StandardAnimation.SlideDown, 5);
                    backgroundWorker.RunWorkerAsync("emp_add");
                }
            }

        }
        private void InsertData()
        {
            
            try
            {
                MemoryStream ms = new MemoryStream();
                userPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] img = ms.GetBuffer();



                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("insert into [dbo].[user_management] values (@id,@fname,@lname,@date,@phone,@user_type,@address,@user,@password,@img)", cn);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@fname", emp_fname.Text);
                cmd.Parameters.AddWithValue("@lname", emp_lname.Text);
                cmd.Parameters.AddWithValue("@date", emp_date.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@user_type", user_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@address", emp_address.Text);
                cmd.Parameters.AddWithValue("@user", username.Text);
                cmd.Parameters.AddWithValue("@password", new PasswordSecure().Encrypt(password.Text));
                cmd.Parameters.AddWithValue("@img", img);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم إدخال المستخدم بنجاح" + "\n '" + username.Text + "': اسم المستخدم ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("الرقم القومي موجود بالفعل ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
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
        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(emp_fname.Text))
            {
                errorProvider.SetError(emp_fname, "ادخل الاسم الأول");
            }
            else if (string.IsNullOrEmpty(emp_lname.Text))
            {
                errorProvider.SetError(emp_lname, "ادخل الاسم الأخير");
            }
            else if (string.IsNullOrEmpty(id.Text))
            {
                errorProvider.SetError(id, "ادخل الرقم القومي");
            }
            else if (string.IsNullOrEmpty(emp_address.Text))
            {
                errorProvider.SetError(emp_address, "ادخل العنوان");
            }
            else if (string.IsNullOrEmpty(phone.Text))
            {
                errorProvider.SetError(phone, "ادخل رقم الهاتف");
            }
            else if (string.IsNullOrEmpty(username.Text))
            {
                errorProvider.SetError(username, "ادخل اسم المستخدم");
            }
            else if (user_type.SelectedIndex == -1)
            {
                errorProvider.SetError(user_type, "ادخل نوع المستخدم");
            }

            else if (password.Text != confirm_pass.Text)
            {
                MessageBox.Show("تأكد من كلمة المرور", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {

                    panelLoader.Visible = true;
                    xuiObjectAnimator.StandardAnimate(panelLoader, XanderUI.XUIObjectAnimator.StandardAnimation.SlideDown, 5);
                    backgroundWorker.RunWorkerAsync("emp_update");
                }
            }

        }
        private void UpdateData()
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                userPic.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] img = ms.GetBuffer();

                SqlConnection cn = new SqlConnection(cloud.StartConnection);
                cn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE user_management SET emp_fname = @fname,emp_lname = @lname, emp_date = @date, emp_phone = @phone, user_type = @user_type, emp_address = @address, emp_username = @user, emp_password = @password,user_pic= @img WHERE emp_id =  " + id.Text + "  ; ", cn);
                cmd.Parameters.AddWithValue("@fname", emp_fname.Text);
                cmd.Parameters.AddWithValue("@lname", emp_lname.Text);
                cmd.Parameters.AddWithValue("@date", emp_date.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@user_type", user_type.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@address", emp_address.Text);
                cmd.Parameters.AddWithValue("@user", username.Text);
                cmd.Parameters.AddWithValue("@password", new PasswordSecure().Encrypt(password.Text));
                cmd.Parameters.AddWithValue("@img", img);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تعديل المستخدم بنجاح" + "\n '" + username.Text + "': اسم المستخدم ", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("الرقم القومي موجود بالفعل ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
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
        private void guna2Button6_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(id.Text) || string.IsNullOrEmpty(username.Text))
            {
                errorProvider.SetError(id, "برجاء إدخال الرقم القومي او اسم المستخدم حتي تحذف المستخدم");
                errorProvider.SetError(username, "برجاء إدخال الرقم القومي او اسم المستخدم حتي تحذف المستخدم");
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("emp_delete");
                }
            }
        }
        private void deleteData()
        {

            if (MessageBox.Show("هل تريد حذف المستخدم ؟؟" + "\n '" + id.Text + "'", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    SqlConnection cn = new SqlConnection(cloud.StartConnection);
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM user_management WHERE emp_id= " + id.Text + " or emp_username = N'" + username.Text + "' ;", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم حذف المستخدم بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cn.Close();
                    reset();
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
   
        private void xuiBatteryPercentageAPI_Tick(object sender, System.EventArgs e)
        {
            batteryStatus.Value = xuiBatteryPercentageAPI.Value;
            ToolTip.SetToolTip(batteryStatus, "Battery Status : " + xuiBatteryPercentageAPI.Value);
        }

        private void userPic_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                userPic.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string buttonName = (string)e.Argument;
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            switch (buttonName)
            {
                case "emp_display":
                    DisplayData();
                    break;
                case "emp_add":
                    InsertData();
                    break;

                case "emp_update":
                    UpdateData();
                    break;

                case "emp_delete":
                    deleteData();

                    break;
                default:
                    if(!string.IsNullOrEmpty(getUsername))
                    {
                        DisplayData(getUsername);
                    }
                    break;
            }



        }

        private void clearFields_CheckedChanged(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (clearFields.Checked)
            {
                if(MessageBox.Show("هل تريد حذف جميع المدخلات ؟؟","تحذير",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    reset();
                    clearFields.Checked = false;
                }
                else
                {
                    clearFields.Checked = false;

                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }

        private void employees_mangement_Load(object sender, EventArgs e)
        {
            if(!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void employees_mangement_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
