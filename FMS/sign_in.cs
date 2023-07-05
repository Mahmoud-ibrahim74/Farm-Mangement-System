using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FMS
{

    public partial class sign_in : Form
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        public sign_in()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(panelRight, panelRight, connection, backgroundWorker);
            InitData();

        }
        private void InitData()
        {
            if (Properties.Settings.Default.UsernameDefault != string.Empty)
            {
                username.Text = Properties.Settings.Default.UsernameDefault;
                password.Text = Properties.Settings.Default.PasswordDefault;
                remeberMe.Checked = true;

            }
            else
            {
                username.Text = "";

            }
        }
        private void SaveData()
        {
            if (remeberMe.Checked)
            {
                Properties.Settings.Default.UsernameDefault = username.Text;
                Properties.Settings.Default.PasswordDefault = password.Text;
                Properties.Settings.Default.Save();

            }
            else
            {
                Properties.Settings.Default.UsernameDefault = "";
                Properties.Settings.Default.PasswordDefault = "";
                remeberMe.Checked = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Freeze()
        {
            username.Enabled = false;
            password.Enabled = false;
            userType.Enabled = false;
            guna2ToggleSwitch1.Enabled = false;
            remeberMe.Enabled = false;
            loader.Visible = true;
            gotoLogin.Enabled = false;
        }
        private void UnFreeze()
        {
            username.Enabled = true;
            password.Enabled = true;
            userType.Enabled = true;
            guna2ToggleSwitch1.Enabled = true;
            remeberMe.Enabled = true;
            gotoLogin.Enabled = true;

            loader.Visible = false;
        }
        private void Login(string type)
        {
            SqlConnection connection = new SqlConnection(cloud.StartConnection);
            try
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand("select emp_username,emp_password,user_type from user_management" +
                    " where emp_username  = @user and emp_password = @pass" +
                    " and user_type= N'"+type+"' ", connection);
                cmd.Parameters.AddWithValue("@user", username.Text);
                cmd.Parameters.AddWithValue("@pass", new PasswordSecure().Encrypt(password.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    UserNameApplication.UserName = username.Text;
                    UserNameApplication.Password = password.Text;
                    SaveData();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show(String.Format("Username : '{0}' or Password Incorrect ", username.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UnFreeze();
                }


            }
            catch (SqlException ex)
            {
                UnFreeze();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }
        }

        private void gotoLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                errorProvider.SetError(username, "!! اسم المستخدم فارغ");

            }
            else if (string.IsNullOrEmpty(password.Text))
            {
                errorProvider.SetError(password, "!!  كلمة المرور فارغة");

            }
            else if (userType.SelectedIndex == 0)
            {
                errorProvider.SetError(userType, "!!  بجاء اختيار نوع المستخدم (مسؤول / مستخدم) ");
            }
            else
            {
                if (userType.SelectedIndex == 1)
                {
                    Freeze();
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("AdminLogin");
                    }


                }
                else if(userType.SelectedIndex == 2)
                {
                    Freeze();
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("EmployeeLogin");
                    }
                }
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                password.PasswordChar = '\0';

            }
            else
            {
                password.PasswordChar = '●';
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if ((string)e.Argument == "AdminLogin")
            {
                ThreadSafe(()=>Login("مسؤول"));
            }
            else
            {
                ThreadSafe(() => Login("موظف"));
            }

        }

        public static void ThreadSafe(Action action)
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal,
                new MethodInvoker(action));
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            username.Text = string.Concat(username.Text.Where(char.IsLetterOrDigit));
        }

        private void sign_in_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void CloseFrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
