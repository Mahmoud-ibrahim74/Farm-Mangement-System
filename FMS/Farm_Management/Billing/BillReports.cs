using System;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using FMS.Billing;

namespace FMS.Farm_Management.Billing
{
    public partial class BillReports : Form
    {
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();
        DataTable dt_Index0 = new DataTable();
        DataTable dt_Index1 = new DataTable();
        DataTable dt_Index2 = new DataTable();
        ExportExcel excel = new ExportExcel();
        public BillReports()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(panel1, guna2GradientPanel4, connection, backgroundWorker);
            datePanel.Text = DateTime.Now.ToLongDateString();
            this.tableB.ScrollBars = ScrollBars.None;
            helpProvider.SetHelpString(this, " *- Press (Excel Export) Then Wait (4s) to Export Sheet \n" +
                " *- Press (Invoice Selection) and Select Invoices you want then Click (Printer Button) \n " +
                "");

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

            if (bill_type.SelectedIndex == -1)
            {
                errorProvider.SetError(bill_type, "من فضلك اختر الدواء");
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    tableB.DataSource = null;
                    backgroundWorker.RunWorkerAsync("DisplayData");
                }
            }

        }


        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add("NAME");
                dt.Columns.Add("PRICE");
                dt.Columns.Add("TRANSMIT");
                dt.Columns.Add("TAX");
                dt.Columns.Add("TOTAL");
                for (int i = 0; i < tableB.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    for (int j = 1; j < tableB.Columns.Count-1; j++) // 1 doesn't allow to take ID
                    {
                        dr[dt.Columns[j - 1].ColumnName] = tableB[j, i].Value;
                    }
                    dt.Rows.Add(dr);
                }
                Form form;
                if (bill_type.SelectedIndex == 0)
                {
                    form = new Bill_Image(dt, "GOODS INVOICES", "Make Your Invoice For Goods", totalBills.Text);
                    if (Application.OpenForms[form.Name] == null)
                    {
                        form.Show();
                    }
                    else
                    {
                        Application.OpenForms[form.Name].Focus();
                    }
                }
                else if (bill_type.SelectedIndex == 1)
                {
                    form = new Bill_Image(dt, "Animal Invoices", "Make Your Invoice For Animals", totalBills.Text);
                    if (Application.OpenForms[form.Name] == null)
                    {
                        form.Show();
                    }
                    else
                    {
                        Application.OpenForms[form.Name].Focus();
                    }
                }
                else
                {
                    form = new Bill_Image(dt, "Medcine Invoices", "Make Your Invoice For Medcine", totalBills.Text);
                    if (Application.OpenForms[form.Name] == null)
                    {
                        form.Show();
                    }
                    else
                    {
                        Application.OpenForms[form.Name].Focus();
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
            Bill_Reports _Reports = new Bill_Reports();
            string ControlName = (string)e.Argument;

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (ControlName == "DisplayData")
            {
                dt_Index0.Clear();
                dt_Index1.Clear();
                dt_Index2.Clear();
                _Reports.DisplayTables(bill_type, dt_Index0, dt_Index1, dt_Index2);
            }


        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;

            if (dt_Index0.Rows.Count > 0)
            {
                tableB.DataSource = dt_Index0;
            }
            else if (dt_Index1.Rows.Count > 0)
            {
                tableB.DataSource = dt_Index1;
            }
            else if (dt_Index2.Rows.Count > 0)
            {
                tableB.DataSource = dt_Index2;
            }
          
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تطبع", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                 Bill_Reports _Reports = new Bill_Reports();
                _Reports.getSelectedRows(tableB);
            }
        }

        private void guna2Button3_Click_2(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Thread thread = new Thread(() => excel.ExeclReportOne(tableB, saveExcel));
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تطبع", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var worker = new BackgroundWorker();
                worker.DoWork += (o, ea) =>
                {
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                };
                worker.RunWorkerCompleted += (o, ea) =>
                {
                };
                worker.RunWorkerAsync();
            }


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

        private void tableB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
             Bill_Reports _Reports = new Bill_Reports();
            _Reports.TotalAlogrithm(tableB, totalBills);
        }

        private void tableB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
               Bill_Reports _Reports = new Bill_Reports();
              _Reports.TotalAlogrithm(tableB, totalBills);
        }

        private void BillReports_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void BillReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
