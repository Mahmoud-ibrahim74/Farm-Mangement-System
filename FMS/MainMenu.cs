using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms; 
namespace FMS
{
    public partial class MainMenu : Form
    {
        private string getUserName;
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        DataSet ds = new DataSet();
        SqlConnection conn;
        public MainMenu()
        {
            InitializeComponent();
            ConnectionTimeOut.MainMenuConnection(panel1, profile_user, menuStrip1, backgroundWorker, connection);
            //double Total = Math.Abs((Properties.Settings.Default.EndDate - Properties.Settings.Default.StartDate).TotalDays);
            //int DaysLeft = (int)Total;
            //Trail_Ibl.Text = DaysLeft + " Days Left";
            //if (DaysLeft <= 0)
            //{
            //    Freeze();
            //    profile_icon.Enabled = false;
            //    expire_lbl.Visible = true;
            //    Separator1.Visible = false;
            //    Separator2.Visible = false;
            //    title.Visible = false;
            //    logoAnimator.Visible = false;

            //}

        }
        public void UnFreeze()
        {
            openMusic.Enabled = true;
            userControl.Enabled = true;
            send.Enabled = true;
            gallery.Enabled = true;
            linkLabel.Enabled = true;
            البياناتالأساسيةToolStripMenuItem.Enabled = true;
            حركةالعملToolStripMenuItem.Enabled = true;
            حركةالعملToolStripMenuItem1.Enabled = true;
            تقاريرحركةالمزرعةToolStripMenuItem.Enabled = true;
            تقاريرسنداتالقبضوالدفعToolStripMenuItem.Enabled = true;
            toolStripMenuItem1.Enabled = true;
            menuStrip1.Enabled = true;
            logout.Text = "تسجيل الخروج";
            tooltip.SetToolTip(logout, "الخروج نسجيل");
        }
        public void Freeze()
        {
            openMusic.Enabled = false;
            userControl.Enabled = false;
            send.Enabled = false;
            gallery.Enabled = false;
            linkLabel.Enabled = false;
            البياناتالأساسيةToolStripMenuItem.Enabled = false;
            حركةالعملToolStripMenuItem.Enabled = false;
            حركةالعملToolStripMenuItem1.Enabled = false;
            تقاريرحركةالمزرعةToolStripMenuItem.Enabled = false;
            تقاريرسنداتالقبضوالدفعToolStripMenuItem.Enabled = false;
            toolStripMenuItem1.Enabled = false;
            menuStrip1.Enabled = false;
            logout.Text = "تسجيل الخروج";
            tooltip.SetToolTip(logout, "الخروج نسجيل");
        }


        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            var processBackGround = Process.GetProcessesByName("FMS");

            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("هل تريد إغلاق التطبيق  ؟؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    foreach (var KillProcess in processBackGround)
                    {
                        KillProcess.Kill();
                    }
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void facebook_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Process.Start("https://www.instagram.com/bnjraman/");

        }

        private void twitter_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Process.Start("https://twitter.com/bnjraman?lang=ar");

        }

        private void whatsapp_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Process.Start("https://api.whatsapp.com/send?phone=966544411127");
        }

        private void guna2GradientButton15_Click(object sender, EventArgs e)
        {
            if (gallery.Checked)
            {
                GalleryTypes.Visible = true;
            }
            else
            {
                GalleryTypes.Visible = false;
            }
        }

        private void guna2GradientButton16_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Farm_Management.support();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }


        private void logout_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new sign_in();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                form.Focus();
            }
        }

        private void guna2GradientButton20_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Farm_Management.employees_mangement();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }



        private void openMusic_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Hardware.MusicPlayer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }

        }


        private void تقاريرالعنابرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new RPV_Report.Cheueque_Reports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.Accountinializer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.GoodsIntializer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالعنابرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.storage_animal();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالبنوكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.Bankintializer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالخزينةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.CashTreasuray();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبالحيواناتالبريةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.AnimalsIntializer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تعريفبمخزنالأدويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Basic_Data.medicineIntializer();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنصرفنقديةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Receipt_Payment_Vouchers.DebenturesWithdraw();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنصرفشيكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Receipt_Payment_Vouchers.ChequeWithdraw();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنتوريدنقديةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Receipt_Payment_Vouchers.DebenturesAdding();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنتوريدشيكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Receipt_Payment_Vouchers.ChequeAdding();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنمشترياتبضاعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.animalPurshasePremession();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنشراءالحيواناتالبريةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.animalSellPremession();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنصرفبضاعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.goodsSelling();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنصرفبضاعةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.goodsPurshase();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void إذنشراءأدويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.medicine_Purshase();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }

        }

        private void إذنصرفأدويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.medicine_Premessions();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالعنابرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new storage_reports.animalReports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new storage_reports.productReports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالأدويةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new storage_reports.medicineReports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرتحويلاتالبضاعةبينالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new storage_reports.ProductSwapping();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالمخازنToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new RPV_Report.CashTreasurayReports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالمزرعةToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تحويلبضاعةبينالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Working.SwapProduct();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new About();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string getProcess = (string)e.Argument;
            if (getProcess == "LoadName")
            {
                try
                {
                    conn = new SqlConnection(cloud.StartConnection);
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("select emp_fname,emp_lname,user_type,user_pic from user_management where emp_username  = N'" + this.getUserName + "' ", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd2);
                    da.Fill(ds);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void profile_icon_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (profile_user.Width == 300)
            {
                panelAnimator.AnimationType = Guna.UI2.AnimatorNS.AnimationType.VertSlide;
                panelAnimator.ShowSync(profile_user);
                profile_user.Width = 295;
            }
            else
            {
                profile_user.Visible = false;
                profile_user.Width = 300;
            }
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {

            while (true)
            {
                await Task.Delay(2000);
                if (!string.IsNullOrEmpty(UserNameApplication.UserName))
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        this.getUserName = UserNameApplication.UserName;
                        backgroundWorker.RunWorkerAsync("LoadName");
                    }
                }
            }

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbl_name.Visible = true;
                    lbl_userType.Visible = true;
                    lbl_username.Visible = true;
                    MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["user_pic"]);
                    profile_icon.Image = new Bitmap(ms);
                    lbl_name.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString() + " " + ds.Tables[0].Rows[0]["emp_lname"].ToString();
                    lbl_userType.Text = ds.Tables[0].Rows[0]["user_type"].ToString();
                    lbl_username.Text = this.getUserName;
                    UnFreeze();
                    logout.Visible = false;
                    if (ds.Tables[0].Rows[0]["user_type"].ToString() == "موظف")  // priviliges of users
                    {
                        userControl.Enabled = false;
                        linkLabel.Enabled = false;
                    }
                    backgroundWorker.Dispose();
                }

                conn.Close();

            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (!string.IsNullOrEmpty(this.getUserName))
            {
                var form = new Farm_Management.employees_mangement(this.getUserName);
                if (Application.OpenForms[form.Name] == null)
                {
                    form.ShowDialog();
                }
                else
                {
                    Application.OpenForms[form.Name].Focus();
                }
            }

        }

        private void تقاريرالمزرعةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Farm_Management.Farm_Sheets();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void تقاريرالفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Farm_Management.Billing.BillReports();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }

        private void snakeGameBtn_Click(object sender, EventArgs e)
        {
            var form = new Game.SnakeGame();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }


        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;

            }
            else if (e.KeyData == Keys.Escape)
            {
                this.FormBorderStyle = FormBorderStyle.Fixed3D;
                this.WindowState = FormWindowState.Normal;
            }


        }

        private void البياناتالأساسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GalleryTypes.Visible == true)
            {
                GalleryTypes.Visible = false;
                gallery.Checked = false;

            }
        }

        private void GalleryTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GalleryTypes.SelectedIndex == 0)
            {
                ClickSound sound = new ClickSound();
                sound.RunClickSound();
                var form = new Gallery.ImageView();
                if (Application.OpenForms[form.Name] == null)
                {
                    form.ShowDialog();
                }
                else
                {
                    Application.OpenForms[form.Name].Focus();
                }
            }
            else
            {
                //ClickSound sound = new ClickSound();
                //sound.RunClickSound();
                //var form = new Gallery.Vedios();
                //if (Application.OpenForms[form.Name] == null)
                //{
                //    form.ShowDialog();
                //}
                //else
                //{
                //    Application.OpenForms[form.Name].Focus();
                //}
                MessageBox.Show("معرض الفيديوهات في وضع الصيانة الان ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarGame_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            var form = new Game.Form1();
            if (Application.OpenForms[form.Name] == null)
            {
                form.ShowDialog();
            }
            else
            {
                Application.OpenForms[form.Name].Focus();
            }
        }
    }
}
