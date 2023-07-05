using FMS.Hardware.Printing;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FMS.storage_reports
{
    public partial class animalReports : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();


        public animalReports()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

            datePanel.Text = DateTime.Now.ToLongDateString();
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

        private void guna2Button5_Click(object sender, System.EventArgs e)
        {
            if (tableA.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                PrinterSender printer = new PrinterSender();
                printer.SendPRinter(" بيان بالشيكات", tableB);
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
            SQLSERVER_Queries.SotrageReports.AnavarScripts anavar = new SQLSERVER_Queries.SotrageReports.AnavarScripts();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (ControlName == "displayData")
            {
                dt.Clear();
                dt3.Clear();
                anavar.DisplayData(service_type, animal_type, getAnavar, dt, dt3);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else if (ControlName == "getAnimals")
            {
                anavar.getAnaverSetting(animal_type, getAnavar);
            }
            else if (ControlName == "displayByInterval")
            {
                dt.Clear();
                dt3.Clear();
                anavar.DisplayByInterval(service_type, animal_type, fromDate, toDate, getAnavar, dt, dt3);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }
            else

            {
                anavar.LoadData(getAnavar);

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
                double getNumbers = 0;

                double getTotal_Anavar = 0;
                double getTotal_Anavar_cost = 0;




                if (service_type.SelectedIndex == 0)
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();

                    calc.Columns.Add("total", "إجمالي العدد المشتري الي العنبر");
                    calc.Columns.Add("afterAdded", "إجمالي التكلفة الكلية للحيوانات المشترية");

                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        getTotal = getTotal + Convert.ToDouble(tableB[8, i].Value.ToString());
                        getNumbers = getNumbers + Convert.ToDouble(tableB[6, i].Value.ToString());


                    }
                    calc.Rows.Add(getNumbers.ToString(), getTotal.ToString());

                }

                else if (service_type.SelectedIndex == 1)
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();

                    calc.Columns.Add("total", "إجمالي عدد الحيوانات المباعة");
                    calc.Columns.Add("afterAdded", "إجمالي التكلفة الكلية للحيوانات المباعة");

                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        getTotal = getTotal + Convert.ToDouble(tableB[8, i].Value.ToString());  // التكلفة
                        getNumbers = getNumbers + Convert.ToDouble(tableB[6, i].Value.ToString());  // عدد الحيوانات


                    }
                    calc.Rows.Add(getNumbers.ToString(), getTotal.ToString());
                }

                else
                {
                    calc.Rows.Clear();
                    calc.Columns.Clear();
                    calc.Columns.Add("total", "إجمالي عدد الحيوانات المشترية");
                    calc.Columns.Add("total_minus", "إجمالي عدد الحيوانات المباعة");
                    calc.Columns.Add("status", "حالة اعداد العنبر");
                    calc.Columns.Add("status", "حالة تكلفة العنبر");



                    double getTotal_add_No = 0;
                    double getTotal_remove_No = 0;


                    double getTotal_add_cost = 0;
                    double getTotal_remove_cost = 0;


                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        if (tableB[9, i].Value.ToString() == "شراء")
                        {
                            getTotal_add_No = getTotal_add_No + Convert.ToDouble(tableB[6, i].Value.ToString());
                            getTotal_add_cost = getTotal_add_cost + Convert.ToDouble(tableB[8, i].Value.ToString());

                        }
                        else if (tableB[9, i].Value.ToString() == "بيع")
                        {
                            getTotal_remove_No = getTotal_remove_No + Convert.ToDouble(tableB[6, i].Value.ToString());
                            getTotal_remove_cost = getTotal_remove_cost + Convert.ToDouble(tableB[8, i].Value.ToString());
                        }
                    }
                    for (int i = 0; i < tableA.Rows.Count; i++)
                    {
                        getTotal_Anavar = getTotal_Anavar + Convert.ToDouble(tableA[3, i].Value.ToString());  // get number  of anavar
                        getTotal_Anavar_cost = getTotal_Anavar_cost + Convert.ToDouble(tableA[5, i].Value.ToString());  // get cost  of anavar


                    }


                    calc.Rows.Add(getTotal_add_No, getTotal_remove_No, ((getTotal_Anavar + getTotal_add_No) - getTotal_remove_No), (getTotal_Anavar_cost + getTotal_add_cost) - getTotal_remove_cost);


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

        private void getAnavar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("getAnimals");
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
                    printer.SendPRinter("بيان بحركة الحيوانات", tableA);
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
                    printer.SendPRinter("بيان بحركة الحيوانات", tableB);
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

        private void animalReports_KeyDown(object sender, KeyEventArgs e)
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

        private void animalReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
