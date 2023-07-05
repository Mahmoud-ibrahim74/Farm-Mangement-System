using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Basic_Data
{
    public partial class Bankintializer : Form
    {
        private DataTable dt = new DataTable();
        private List<string> getRowData = new List<string>();


        public Bankintializer()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);
            datePanel.Text = DateTime.Now.ToLongDateString();
            tableB.BorderStyle = BorderStyle.None;
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
                backgroundWorker.RunWorkerAsync("DisplayBank");
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
                if (MessageBox.Show("هل تريد حذف بنك " + getRowData.ElementAt(0), "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("deleteBank");
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
            SQLSERVER_Queries.Basic_Data.BankIntializer bank = new SQLSERVER_Queries.Basic_Data.BankIntializer();


            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (ControlName == "DisplayBank")
            {
                dt.Clear();
                bank.DisplayData(dt);
                tableB.DataSource = dt;
            }
            else if (ControlName == "insertBank")
            {
                bank.InsertBank(bank_name, branch_name, account_number, bank_balance);
            }
            else if (ControlName == "updateBank")
            {
                bank.UpdateBank(getRowData.ElementAt(1), getRowData.ElementAt(2), getRowData.ElementAt(3), getRowData.ElementAt(0));
                dt.Clear();
                bank.DisplayData(dt);
                tableB.DataSource = dt;
            }
            else if (ControlName == "deleteBank")
            {
                bank.DeleteBank(getRowData.ElementAt(0));
                dt.Clear();
                bank.DisplayData(dt);
                tableB.DataSource = dt;
            }
            else
            {
                
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
                    backgroundWorker.RunWorkerAsync("updateBank");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(bank_name.Text))
            {
                errorProvider.SetError(bank_name, "برجاء ادخال اسم البنك");
            }
            else if (string.IsNullOrEmpty(branch_name.Text))
            {
                errorProvider.SetError(branch_name, "برجاء ادخال اسم الفرع");
            }
            else if (string.IsNullOrEmpty(account_number.Text))
            {
                errorProvider.SetError(account_number, "برجاء ادخال رقم البنك");
            }
            else if (string.IsNullOrEmpty(bank_balance.Text))
            {
                errorProvider.SetError(bank_balance, "برجاء ادخال رصيد البنك");
            }
            else
            {
                if(!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("insertBank");
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
                (tableB.DataSource as DataTable).DefaultView.RowFilter = string.Format("[اسم البنك] LIKE '%{0}%'", search.Text);
            }
        }

        private void account_number_TextChanged(object sender, EventArgs e)
        {
            account_number.Text = string.Concat(account_number.Text.Where(char.IsDigit));

        }

        private void bank_balance_TextChanged(object sender, EventArgs e)
        {
            bank_balance.Text = string.Concat(bank_balance.Text.Where(char.IsDigit));

        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
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

        private void Bankintializer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void Bankintializer_KeyDown(object sender, KeyEventArgs e)
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
