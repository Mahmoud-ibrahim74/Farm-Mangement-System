using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace FMS.Farm_Management
{
    public partial class support : Form
    {
        private const string fromPass = "01284448287";

        public support()
        {
            InitializeComponent();
            helpProvider.SetHelpString(this, " *- you can send report with voice by clicking on open record button . \n\n" +
" *- Notes : you should check on {send with record} to perform action of record . \n\n" +
" *- you can send with no record by clicking on close record .\n\n" +
" *- Notes : when send with no record make sure your file is uploaded (Optional) .");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFile.ShowDialog();
            setPath.Text = openFile.FileName;
            setPath.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(toEmail.Text))
            {
                errorProvider.SetError(toEmail, "برجاء ملئ بريد المرسل");
            }
            else if (string.IsNullOrEmpty(subject.Text))
            {
                errorProvider.SetError(subject, "برجاء ملئ الموضوع");
            }
            else if (string.IsNullOrEmpty(bodyMessage.Text))
            {
                errorProvider.SetError(bodyMessage, "برجاء ملئ الرسالة");
            }
            else if (!toEmail.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("برجاء ادخال بريد صحيح" + "\n " + "ex@gmail.com :  مثال", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                if (!checkRecord.Checked)
                {
                    if (MessageBox.Show("هل تريد ارسال تقرير بدون تسجيل صوتي ؟؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (!backgroundWorker.IsBusy)
                        {
                            panelLoader.Visible = true;
                            backgroundWorker.RunWorkerAsync("sendMail");
                        }
                    }
                }
                else
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        panelLoader.Visible = true;
                        backgroundWorker.RunWorkerAsync("sendMailWithRecord");
                    }
                }

                
            }


        }
        private void SendMailAsync()
        {
            if (setPath.Text == "d" || openFile.FileName == "All Files")
            {
                try
                {

                    MailAddress fromMail = new MailAddress(fromEmail.Text, "Zedan Mahmoud");
                    MailAddress toMail = new MailAddress(toEmail.Text, "Mahmoud Ibrahim");
                    MailMessage m = new MailMessage(fromMail, toMail);
                    m.Subject = subject.Text;
                    m.Body = bodyMessage.Text;
                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail.Text, fromPass);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(m);
                    panelLoader.Visible = false;
                    MessageBox.Show("تم ارسال التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SmtpException)
                {
                    panelLoader.Visible = false;
                    MessageBox.Show("خطأ في الأرسال برجاء المحاولة مرة اخري", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    MailAddress fromMail = new MailAddress(fromEmail.Text, "Zedan Mahmoud");
                    MailAddress toMail = new MailAddress(toEmail.Text, "Mahmoud Ibrahim");
                    MailMessage m = new MailMessage(fromMail, toMail);
                    m.Subject = subject.Text;
                    m.Body = bodyMessage.Text;
                    m.Attachments.Add(new Attachment(openFile.FileName));

                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail.Text, fromPass);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(m);
                    panelLoader.Visible = false;
                    MessageBox.Show("تم ارسال التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SmtpException ex)
                {
                    panelLoader.Visible = false;
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void SendMailWithRecord()
        {
            if (setPath.Text == "d" || openFile.FileName == "All Files")
            {
                try
                {

                    MailAddress fromMail = new MailAddress(fromEmail.Text, "Zedan Mahmoud");
                    MailAddress toMail = new MailAddress(toEmail.Text, "Mahmoud Ibrahim");
                    MailMessage m = new MailMessage(fromMail, toMail);
                    m.Subject = subject.Text;
                    m.Body = bodyMessage.Text;
                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail.Text, fromPass);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(m);
                    panelLoader.Visible = false;
                    MessageBox.Show("تم ارسال التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SmtpException)
                {
                    panelLoader.Visible = false;
                    MessageBox.Show("خطأ في الأرسال برجاء المحاولة مرة اخري", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    MailAddress fromMail = new MailAddress(fromEmail.Text, "Zedan Mahmoud");
                    MailAddress toMail = new MailAddress(toEmail.Text, "Mahmoud Ibrahim");
                    MailMessage m = new MailMessage(fromMail, toMail);
                    m.Subject = subject.Text;
                    m.Body = bodyMessage.Text;
                    m.Attachments.Add(new Attachment(openFile.FileName));
                    m.Attachments.Add(new Attachment(Hardware.Record.RecordPath));

                    SmtpClient smtp = new SmtpClient();
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromEmail.Text, fromPass);
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(m);
                    panelLoader.Visible = false;
                    MessageBox.Show("تم ارسال التقرير", "تم", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (SmtpException ex)
                {
                    panelLoader.Visible = false;
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string getTask = (string)e.Argument;

            if (getTask == "sendMail")
            {
                SendMailAsync();
            }
            else if (getTask == "sendMailWithRecord")
            {
                SendMailWithRecord();
            }
            
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;

        }

        private void minimizer_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void makeRecord_Click(object sender, EventArgs e)
        {
            this.panelRecord.Visible = true;
           Hardware.Voice v = new Hardware.Voice() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelRecord.Controls.Add(v);
            v.Show();
        }

        private void closeRecord_Click(object sender, EventArgs e)
        {
            if (this.panelRecord.Visible == true)
            {
                this.panelRecord.Visible = false;

            }
        }

        private void checkRecord_CheckedChanged(object sender, EventArgs e)
        {
            if(!File.Exists(Hardware.Record.RecordPath))
            {
                
                MessageBox.Show("الملف غير موجود", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkRecord.Checked = false;
            }
        }

        private void support_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
