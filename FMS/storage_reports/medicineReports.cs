using FMS.Hardware.Printing;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FMS.storage_reports
{
    public partial class medicineReports : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();


        public medicineReports()
        {
            InitializeComponent();
            datePanel.Text = DateTime.Now.ToLongDateString();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

            this.tableB.ScrollBars = ScrollBars.None;
            helpProvider.SetHelpString(this, " *- Press (CTRL+P)  to print container panel :{'Blue Panel'}. \n\n" +
" *- Press (Excel Export)  Then Wait (4s) to Export Sheet. \n\n" +
" *- Press (Table Selection ComboBox)  to Print One By One table.\n\n" +
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
            if (getAnavar.SelectedIndex == -1 || service_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار العنبر ونوع الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void xuiBatteryPercentageAPI_Tick(object sender, System.EventArgs e)
        {
            batteryStatus.Value = xuiBatteryPercentageAPI.Value;
            ToolTip.SetToolTip(batteryStatus, "Battery Status : " + xuiBatteryPercentageAPI.Value);
        }


        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string ControlName = (string)e.Argument;
            SQLSERVER_Queries.SotrageReports.medcineScripts medcine = new SQLSERVER_Queries.SotrageReports.medcineScripts();
            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }


            if (ControlName == "displayData")
            {
                dt.Clear();
                dt3.Clear();
                medcine.DisplayData(getAnavar, service_type, med_type, dt, dt3);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else if (ControlName == "displayByInterval")
            {
                dt.Clear();
                dt3.Clear();
                medcine.InterlView(getAnavar, service_type, fromDate, toDate, med_type, dt, dt3);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else

            {
                medcine.LoadData(getAnavar, med_type);
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

            if (getAnavar.SelectedIndex == -1 || service_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار العنبر ونوع الخدمة اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (tableA.Rows.Count == 0)
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

                double getTotal_Storage = 0;
                double getTotal_Storage_cost = 0;




                if (service_type.SelectedIndex == 0)  // شراء
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();

                    calc.Columns.Add("total", "إجمالي عدد الشراء");
                    calc.Columns.Add("afterAdded", "إجمالي تكلفة الشراء");

                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {

                        getTotal = getTotal + Convert.ToDouble(tableB[7, i].Value.ToString());
                        getTotal_Storage_cost = getTotal_Storage_cost + Convert.ToDouble(tableB[10, i].Value.ToString());

                    }
                    calc.Rows.Add(getTotal, getTotal_Storage_cost);

                }

                else if (service_type.SelectedIndex == 1) // صرف
                {

                    calc.Rows.Clear();
                    calc.Columns.Clear();

                    calc.Columns.Add("total", "إجمالي عدد الصرف");
                    calc.Columns.Add("afterAdded", "إجمالي تكلفة الصرف");

                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {

                        getTotal = getTotal + Convert.ToDouble(tableB[7, i].Value.ToString());
                        getTotal_Storage_cost = getTotal_Storage_cost + Convert.ToDouble(tableB[10, i].Value.ToString());

                    }
                    calc.Rows.Add(getTotal, getTotal_Storage_cost);
                }

                else
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();
                    calc.Columns.Add("total", "إجمالي كمية البضاعة المشترية");
                    calc.Columns.Add("total_minus", "إجمالي كمية البضاعة المباعة");
                    calc.Columns.Add("status", "حالة البضاعة في المخزن");
                    calc.Columns.Add("status", "حالة التكلفة الكلية للمخزن");



                    double getTotal_add_am = 0;
                    double getTotal_remove_am = 0;


                    double getTotal_add_cost = 0;
                    double getTotal_remove_cost = 0;


                    calc.Rows.Clear();
                    calc.Columns.Clear();
                    calc.Columns.Add("total", "إجمالي عدد الشراء");
                    calc.Columns.Add("afterAdded", "إجمالي تكلفة الشراء");
                    calc.Columns.Add("total", "إجمالي عدد الصرف");
                    calc.Columns.Add("afterAdded", "إجمالي تكلفة الصرف");
                    calc.Columns.Add("total", "حالة العدد في المخزن");
                    calc.Columns.Add("afterAdded", "حالة تكلفة الحالية");
                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        if (tableB[11, i].Value.ToString() == "شراء")
                        {

                            getTotal_add_am = getTotal_add_am + Convert.ToDouble(tableB[7, i].Value.ToString());
                            getTotal_add_cost = getTotal_add_cost + Convert.ToDouble(tableB[10, i].Value.ToString());

                        }
                        else if (tableB[11, i].Value.ToString() == "صرف")
                        {
                            getTotal_remove_am = getTotal_remove_am + Convert.ToDouble(tableB[7, i].Value.ToString());
                            getTotal_remove_cost = getTotal_remove_cost + Convert.ToDouble(tableB[10, i].Value.ToString());
                        }
                    }
                    for (int i = 0; i < tableA.Rows.Count; i++)
                    {
                        getTotal_Storage = getTotal_Storage + Convert.ToDouble(tableA[2, i].Value.ToString());  // get numbers  of storage
                        getTotal_Storage_cost = getTotal_Storage_cost + Convert.ToDouble(tableA[4, i].Value.ToString());  // get Cost  of storage


                    }

                    calc.Rows.Add(getTotal_add_am, getTotal_add_cost, getTotal_remove_am, getTotal_remove_cost, (getTotal_Storage + getTotal_add_am) - getTotal_remove_am, (getTotal_add_cost + getTotal_Storage_cost) - getTotal_remove_cost);


                }

            }

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Farm_Management.ExportExcel excel = new Farm_Management.ExportExcel();
            Thread thread = new Thread(() => excel.ExcelExport(tableA, tableB, saveExcel));
            if (tableA.Rows.Count == 0)
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
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (calc.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                PrinterSender printer = new PrinterSender();
                printer.SendPRinter(" بيان بالعمليات", calc);

            }
        }

        private void PrinterSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (PrinterSelection.SelectedIndex == 0)
            {
                if (tableA.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    PrinterSender printer = new PrinterSender();
                    printer.SendPRinter("بيان بالادوية", tableA);
                }
            }
            else
            {
                if (tableA.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    PrinterSender printer = new PrinterSender();
                    printer.SendPRinter("بيان بالادوية", tableB);
                }
            }
        }

        private void emp_update_Click(object sender, EventArgs e)
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

        private void medicineReports_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                Farm_Management.Billing.Invoice_Printing _Printing = new Farm_Management.Billing.Invoice_Printing(guna2GradientPanel4);
                _Printing.PrintPanel();
            }
        }

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void tableA_DataError(object sender, DataGridViewDataErrorEventArgs e)
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

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (tableB.DataSource != null)
            {
                if (search.Text == "")
                {
                    (tableB.DataSource as DataTable).DefaultView.RowFilter = null;
                }
                String search_value = "CONVERT(العدد, System.String) LIKE '%{0}%'";
                (tableB.DataSource as DataTable).DefaultView.RowFilter = string.Format(search_value, search.Text);
            }
        }

        private void medicineReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
