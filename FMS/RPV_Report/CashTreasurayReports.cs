using FMS.Hardware.Printing;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FMS.RPV_Report
{
    public partial class CashTreasurayReports : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();

        public CashTreasurayReports()
        {
          
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

            datePanel.Text = DateTime.Now.ToLongDateString();
            this.tableB.ScrollBars = ScrollBars.None;
            helpProvider.SetHelpString(this, " *- Press (CTRL+P)  to print container panel :{'Blue Panel'}. \n\n" +
           " *- Press (Excel Export)  Then Wait (4s) to Export Sheet. \n\n"+
           " *- Press (Table Selection ComboBox)  to Print One By One table.\n\n"+
           " *- Press (Merge Button)  to merge two or more PDF files in one PDF file.");

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

            if (getTreasure.SelectedIndex == -1 || service_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار الخزينة  ونوع الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;

                    backgroundWorker.RunWorkerAsync("displayData");
                }
            }

        }

        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                CombinePDFs combinePDFs = new CombinePDFs();
                combinePDFs.Combine(openFileDialog);
                if (MessageBox.Show("تم حفظ الملف هل تريد فتح الملف؟؟", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process.Start(combinePDFs.PathDesktop);
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
            SQLSERVER_Queries.RPV_Report_Scripts.CT_Reports cT = new SQLSERVER_Queries.RPV_Report_Scripts.CT_Reports();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (ControlName == "displayData")
            {
                dt.Clear();
                dt3.Clear();
                cT.DisplayData(service_type, dt, dt3, getTreasure);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else if (ControlName == "displayByInterval")
            {
                dt.Clear();
                dt3.Clear();
                cT.DisplayByInterval(service_type, fromDate, toDate, getTreasure, dt, dt3);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else
            {
                cT.LoadData(getTreasure);
            }


        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("calc.exe");

        }

        private void view_Intervals_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (getTreasure.SelectedIndex == -1 || service_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار البنك  ونوع الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("displayByInterval");
                }
            }



        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("برجاء طباعة الجدول اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (service_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                double getTotal = 0;
                double getTotal_Tre = 0;

                if (service_type.SelectedIndex == 0)
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();

                    calc.Columns.Add("total", "إجمالي الإيداعات");
                    calc.Columns.Add("afterAdded", "رصيد الخزينة بعد الإيداعات");
                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        getTotal = getTotal + Convert.ToDouble(tableB[3, i].Value.ToString());

                    }
                    getTotal_Tre = Convert.ToDouble(tableA[2, 0].Value.ToString());    // get balance of Tresuary

                    calc.Rows.Add(getTotal, getTotal_Tre);

                }

                else if (service_type.SelectedIndex == 1)
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();
                    calc.Columns.Add("total", "إجمالي الصرف");
                    calc.Columns.Add("afterAdded", "رصيد الخزينة بعد الصرف");
                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        getTotal = getTotal + Convert.ToDouble(tableB[3, i].Value.ToString());

                    }
                    getTotal_Tre = Convert.ToDouble(tableA[2, 0].Value.ToString());    // get balance of Tresuary

                    calc.Rows.Add(getTotal, getTotal_Tre);

                }

                else
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();
                    calc.Columns.Add("total", "إجمالي الإيداعات");
                    calc.Columns.Add("total_minus", "إجمالي الصرف");
                    calc.Columns.Add("status", "حالة الخزينة الحالية");


                    double getTotal_add = 0;
                    double getTotal_remove = 0;


                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        if (tableB[5, i].Value.ToString() == "توريد")
                        {
                            getTotal_add = getTotal_add + Convert.ToDouble(tableB[3, i].Value.ToString());
                        }
                        else if (tableB[5, i].Value.ToString() == "صرف")
                        {
                            getTotal_remove = getTotal_remove + Convert.ToDouble(tableB[3, i].Value.ToString());

                        }
                    }
                    getTotal_Tre = Convert.ToDouble(tableA[2, 0].Value.ToString());    // get balance of Tresuary

                    calc.Rows.Add(getTotal_add, getTotal_remove, getTotal_Tre);


                }




            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Farm_Management.ExportExcel excel = new Farm_Management.ExportExcel();
            Thread thread = new Thread(() => excel.ExcelExport(tableA, tableB, saveExcel));
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

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (calc.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                new PrinterSender().SendPRinter(" بيان بالعمليات", calc);
            }
        }

        private void PrinterSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (PrinterSelection.SelectedIndex == 0)
            {
                if (tableB.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    PrinterSender printer = new PrinterSender();
                    printer.SendPRinter("بيان بالخزيـــنة", tableA);
                }
            }
            else
            {
                if (tableB.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    PrinterSender printer = new PrinterSender();
                    printer.SendPRinter("بيان بالخزيـــنة", tableB);
                }
            }
        }


        private void CashTreasurayReports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                Farm_Management.Billing.Invoice_Printing _Printing = new Farm_Management.Billing.Invoice_Printing(guna2GradientPanel4);
                _Printing.PrintPanel();
            }

        }

        private void tableB_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex == 0)
            {
                tableB.Refresh();
                tableA.Refresh();
            }
            else
            {
                tableB.Refresh();
                tableA.Refresh();
            }
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (tableB.DataSource != null)
            {
                if (search.Text == "")
                {
                    (tableB.DataSource as DataTable).DefaultView.RowFilter = null;
                }
                String search_value = "CONVERT(المبلغ, System.String) LIKE '%{0}%'";
                (tableB.DataSource as DataTable).DefaultView.RowFilter = string.Format(search_value, search.Text);
            }
        }

        private void CashTreasurayReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
