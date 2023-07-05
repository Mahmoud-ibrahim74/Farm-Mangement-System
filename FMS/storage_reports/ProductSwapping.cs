using FMS.Hardware.Printing;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace FMS.storage_reports
{
    public partial class ProductSwapping : Form
    {
        DataTable dt = new DataTable();
        SQLSERVER_Queries.CloudConnection cloud = new SQLSERVER_Queries.CloudConnection();


        public ProductSwapping()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

            datePanel.Text = DateTime.Now.ToLongDateString();
            this.show_data.ScrollBars = ScrollBars.None;
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
            if (!backgroundWorker.IsBusy)
            {
                panelLoader.Visible = true;

                backgroundWorker.RunWorkerAsync("displayData");
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

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (ControlName == "displayData")
            {
                dt.Clear();
                DisplayData();
                show_data.DataSource = dt;
            }
            else

            {
                LoadData();
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

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            Farm_Management.ExportExcel excel = new Farm_Management.ExportExcel();
            Thread thread = new Thread(() => excel.ExcelExport(show_data, show_data, saveExcel));
            if (show_data.Rows.Count == 0)
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

        private void PrinterSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (PrinterSelection.SelectedIndex == 0)
            {
                if (show_data.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول اولا ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    PrinterSender printer = new PrinterSender();
                    printer.SendPRinter("بيان بتحويلات البضاعة", show_data);
                }
            }
        }

        private void productReports_KeyDown(object sender, KeyEventArgs e)
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
                show_data.Refresh();
            }
            else
            {
                show_data.Refresh();
            }
        }



        private void LoadData()
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select DISTINCT storage_name from storage", cn);
            SqlDataReader rd = cmd.ExecuteReader();
            fromStorage.Items.Clear();
            toStorage.Items.Clear();

            while (rd.Read())
            {
                fromStorage.Items.Add(rd[0].ToString());

                toStorage.Items.Add(rd[0].ToString());
            }
        }

        private void DisplayData()
        {
            SqlConnection cn = new SqlConnection(cloud.StartConnection);
            cn.Open();
            SqlCommand cmd = new SqlCommand("select working_number as [رقم الحركة],date as [التاريخ],from_storage as [من مخزن],to_storage as [الي مخزن],product_name as [اسم الصنف],product_unit as [الوحدة],amount as [الكمية] from swap_products  ", cn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
        }

        private void ProductSwapping_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
