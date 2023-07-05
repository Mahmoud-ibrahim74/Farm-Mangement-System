using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Basic_Data
{
    public partial class Accountinializer : Form
    {
        private DataTable dt = new DataTable();
        private List<string> getRowData = new List<string>();
        public Accountinializer()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);
            datePanel.Text = DateTime.Now.ToLongDateString();
            this.tableB.ScrollBars = ScrollBars.None;
        }

        private void employees_mangement_Load(object sender, System.EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void guna2Button3_Click(object sender, System.EventArgs e)
        {

            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (!backgroundWorker.IsBusy)
            {
                panelLoader.Visible = true;
                backgroundWorker.RunWorkerAsync("DisplayAccount");
            }

        }


        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                getRowData.Clear();
                for (int i = 0; i < tableB.Columns.Count; i++)
                {
                    getRowData.Add(tableB.SelectedRows[0].Cells[i].Value.ToString());

                }
                if (MessageBox.Show("هل تريد حذف حساب " + getRowData.ElementAt(0), "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("deleteAccount");
                    }
                }
            }

        }

        private void xuiBatteryPercentageAPI_Tick(object sender, System.EventArgs e)
        {
            batteryStatus.Value = xuiBatteryPercentageAPI.Value;
            ToolTip.SetToolTip(batteryStatus, "Battery Status : " + xuiBatteryPercentageAPI.Value);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ControlName = (string)e.Argument;
            SQLSERVER_Queries.Basic_Data.AccountIntial intial = new SQLSERVER_Queries.Basic_Data.AccountIntial();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            switch (ControlName)
            {
                case "DisplayAccount":
                    dt.Clear();
                    intial.DisplayData(dt);
                    tableB.DataSource = dt;
                    break;


                case "insertAccount":
                    intial.InsertAccount(account_name, main_account, person, address, phone, an_phone);
                    break;
                case "updateAccount":
                    intial.UpdateAccount(getRowData.ElementAt(1), getRowData.ElementAt(2), getRowData.ElementAt(3), getRowData.ElementAt(4), getRowData.ElementAt(5), getRowData.ElementAt(0));
                    dt.Clear();
                    intial.DisplayData(dt);
                    tableB.DataSource = dt;
                    break;

                case "deleteAccount":
                    intial.DeleteAccount(getRowData.ElementAt(0));
                    dt.Clear();
                    intial.DisplayData(dt);
                    tableB.DataSource = dt;
                    break;

                default:
                    break;
            }


        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                getRowData.Clear();
                for (int i = 0; i < tableB.Columns.Count; i++)
                {
                    getRowData.Add(tableB.SelectedRows[0].Cells[i].Value.ToString());
                    MessageBox.Show(getRowData.ElementAt(i));


                }

                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("updateAccount");
                }
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {

            if (tableB.DataSource != null)
            {
                if (search.Text == "")
                {
                    (tableB.DataSource as DataTable).DefaultView.RowFilter = null;
                }
                (tableB.DataSource as DataTable).DefaultView.RowFilter = string.Format("[اسم الحساب] LIKE '%{0}%'", search.Text);
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(account_name.Text))
            {
                errorProvider.SetError(account_name, "برجاء ادخال اسم الحساب");
            }
            else if (main_account.SelectedIndex == -1)
            {
                errorProvider.SetError(main_account, "برجاء ادخال اسم الحساب الرئيسي");
            }
            else if (string.IsNullOrEmpty(person.Text))
            {
                errorProvider.SetError(person, "برجاء ادخال اسم  الشخص المسؤول");
            }
            else if (string.IsNullOrEmpty(address.Text))
            {
                errorProvider.SetError(address, "برجاء ادخال العنوان");
            }
            else if (string.IsNullOrEmpty(phone.Text))
            {
                errorProvider.SetError(phone, "برجاء ادخال الهاتف");
            }
            else
            {

                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("insertAccount");
                }
            }
        }

        private void xRails_ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void phone_TextChanged(object sender, EventArgs e)
        {
            phone.Text = string.Concat(phone.Text.Where(char.IsDigit));
        }

        private void tableB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                tableB.Refresh();
            }
            else
            {
                tableB.Refresh();
            }
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        }

        private void Accountinializer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void Accountinializer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.E)
            {
                if (tableB.Rows.Count != 0)
                {
                    Farm_Management.ExportExcel excel = new Farm_Management.ExportExcel();
                    System.Threading.Thread thread = new System.Threading.Thread(() => excel.ExeclReportOne(tableB, saveExcel));

                    try
                    {
                        guna2GradientPanel1.Enabled = false;
                        var worker = new System.ComponentModel.BackgroundWorker();
                        worker.DoWork += (o, ea) =>
                        {
                            thread.SetApartmentState(System.Threading.ApartmentState.STA);
                            thread.Start();
                        };
                        worker.RunWorkerCompleted += (o, ea) =>
                        {
                        };
                        worker.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        guna2GradientPanel1.Enabled = true;

                    }
                    finally
                    {
                        guna2GradientPanel1.Enabled = true;

                    }
                }
            }
        }
    }
}
