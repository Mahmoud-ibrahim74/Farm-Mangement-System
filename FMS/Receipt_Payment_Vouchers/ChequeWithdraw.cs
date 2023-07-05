using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
namespace FMS.Receipt_Payment_Vouchers
{
    public partial class ChequeWithdraw : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();
        double GetBankBalance = 0.0;

        public ChequeWithdraw()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel5, bottomPanelTables, this.panel1, this.connection, backgroundWorker);

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

            if (Bank_Name.SelectedIndex == -1)
            {
                errorProvider.SetError(Bank_Name, "من فضلك اختر البنك اولا");
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    panelLoader.Visible = true;
                    backgroundWorker.RunWorkerAsync("cheque_display");
                }

            }

        }

        private void guna2Button4_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            double GetBankAmount = Convert.ToDouble(amount.Text);
            if (Bank_Name.SelectedIndex == -1)
            {
                errorProvider.SetError(Bank_Name, "من فضلك اختر البنك اولا");
            }

            else if (acc_name.SelectedIndex == -1)
            {
                errorProvider.SetError(acc_name, "برجاء اختيار الحساب");
            }
            else if (amount.Text == "")
            {
                errorProvider.SetError(amount, "ادخل المبلغ");
            }
            else if (cheque_number.Text == "")
            {
                errorProvider.SetError(cheque_number, "ادخل رقم الشيك");
            }
            else if (GetBankBalance <= 0)
            {
                MessageBox.Show("رصيد البنك الحالي لا يسمح \n برجاء ايداع رصيد", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (GetBankAmount > GetBankBalance)
            {
                MessageBox.Show("برجاء ادخال مبلغ اقل من رصيد البنك", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("cheuque_adding");
                }
            }

        }

        private void guna2Button6_Click(object sender, System.EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تحذف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("rollBack");
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
            SQLSERVER_Queries.PaymentVoucher_Scripts.ChecqueCashing cashing = new SQLSERVER_Queries.PaymentVoucher_Scripts.ChecqueCashing(Bank_Name, acc_name);
            switch (ControlName)
            {
                case "cheque_display":
                    dt.Clear();
                    dt3.Clear();
                    cashing.DisplayData(dt, dt3);
                    cashing.DisplayBalance(bank_balance);
                    tableB.DataSource = dt;
                    tableA.DataSource = dt3;
                    break;

                case "cheuque_adding":
                    cashing.InsertData(getDate, amount, cheque_number, cheque_date, notes);
                    cashing.DisplayBalance(bank_balance);
                    break;

                case "Bank_Name":
                    cashing.DisplayBalance(bank_balance);
                    break;

                case "rollBack":
                    cashing.RolledBack_Transaction(tableB);
                    dt.Clear();
                    dt3.Clear();
                    cashing.DisplayData(dt, dt3);
                    cashing.DisplayBalance(bank_balance);
                    tableB.DataSource = dt;
                    tableA.DataSource = dt3;
                    break;


                default:
                    cashing.LoadData();
                    break;
            }
        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }

        private void Bank_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("Bank_Name");

            }

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("calc.exe");

        }

        private void cheque_number_TextChanged(object sender, EventArgs e)
        {
            cheque_number.Text = string.Concat(cheque_number.Text.Where(char.IsDigit));

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

        private void bank_balance_TextChanged(object sender, EventArgs e)
        {
            if (bank_balance.Text != "")
            {
                GetBankBalance = Convert.ToDouble(bank_balance.Text);
            }

        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            RegularExepression.ValidationofDecimalPoint(sender, e, amount);
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

        private void CloseWorker_Click(object sender, EventArgs e)
        {
            panelLoader.Visible = false;
            backgroundWorker.CancelAsync();
        }

        private void ChequeWithdraw_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }
    }
}
