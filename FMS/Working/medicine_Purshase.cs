using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Working
{
    public partial class medicine_Purshase : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();

        public medicine_Purshase()
        {
            InitializeComponent();
            ConnectionTimeOut.CheckConenction(this.guna2GradientPanel3, bottomPanelTables, this.panel1, this.connection, backgroundWorker);
            datePanel.Text = DateTime.Now.ToLongDateString();
            helpProvider.SetHelpString(this, " *- Press (CTRL+P)  to print permission Working . \n\n" +
          " *- Press (Save Permission Button) to save permission of Working  . \n\n" +
          " *- Notes : this window show only  dialy working .\n\n" +
          " *- Notes : By(Delete Permission Button ) you can remove dialy working row in table.\n\n" +
          " *- Notes : to display State of working you should refresh server by clicking in comboBox of Working ex => (combo : {Animal Name,Product Name,etc...}) .\n\n" +
          " *- Notes : you can add one or more rows in (Invoice of Working) .\n\n" +
          " *- Notes : you should remove only one selected row . \n\n" +
          " *- Notes : to make invoice for multi rows press (CTRL+R) to select rows then (CTRL+P) to print permission Working.\n\n" +
          " *- Notes : Press (CTRL+A) to select all rows");
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
            if (medicine.SelectedIndex == -1)
            {
                MessageBox.Show("من فضلك اختر الدواء", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SQLSERVER_Queries.WorkingState state = new SQLSERVER_Queries.WorkingState();
            SQLSERVER_Queries.workingScripts.medicine_Purshase purshase = new SQLSERVER_Queries.workingScripts.medicine_Purshase();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (ControlName == "displayData")
            {
                dt.Clear();
                dt3.Clear();
                purshase.DisplayData(medicine, dt, dt3);
                purshase.getMedecineLoad(medicine, numbers, unit, cost, total);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;

            }

            else if (ControlName == "getMedicine")
            {
                purshase.getMedecineLoad(medicine, numbers, unit, cost, total);
            }
            else if (ControlName == "getAnimal")
            {
                purshase.getAnavarAnimals(animals_type, anavar);
                if (!string.IsNullOrEmpty(state.MedicineState(medicine, anavar)))
                {
                    storageState.Text = state.MedicineState(medicine, anavar);
                }
                else
                {
                    storageState.Text = "................";
                }
            }

            else if (ControlName == "insertPremession")
            {
                purshase.InsertPremession(getDate, medicine, storage, anavar, desease, animals_type, numbers, unit, cost, total);
                purshase.getMedecineLoad(medicine, numbers, unit, cost, total);
            }

            else if (ControlName == "deleteCols")
            {
                purshase.deleteColumns(tableB, medicine);
                purshase.getMedecineLoad(medicine, numbers, unit, cost, total);
            }
            else if (ControlName == "saveBill")
            {
                purshase.SaveBill(medicine, product_value, transmit_value, added_tax, bill_value);
            }

            else
            {
                purshase.LoadData(medicine, anavar);
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
            if (tableB.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تحذف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("deleteCols");
                }
            }
        }

        private void added_tax_TextChanged(object sender, EventArgs e)
        {
            if (transmit_value.Text == "")
            {
                transmit_value.Text = "0";
            }
            if (added_tax.Text == "")
            {
                added_tax.Text = "0";
            }


            double calcTotal = 0;

            calcTotal = Convert.ToDouble(product_value.Text) + Convert.ToDouble(transmit_value.Text) + Convert.ToDouble(added_tax.Text);

            bill_value.Text = calcTotal.ToString();
        }

        private void transmit_value_TextChanged(object sender, EventArgs e)
        {

            if (transmit_value.Text == "")
            {
                transmit_value.Text = "0";
            }
            if (added_tax.Text == "")
            {
                added_tax.Text = "0";
            }

            double calcTotal = 0;

            calcTotal = Convert.ToDouble(product_value.Text) + Convert.ToDouble(transmit_value.Text) + Convert.ToDouble(added_tax.Text);

            bill_value.Text = calcTotal.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (medicine.SelectedIndex == -1 || medicine.SelectedIndex == -1 || anavar.SelectedIndex == -1 || string.IsNullOrEmpty(desease.Text) || animals_type.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء إدخال جميع البيانات", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("insertPremession");
                }
            }


        }



        private void stop_CheckedChanged(object sender, EventArgs e)
        {
            if (stop.Checked)
            {
                bill_value.Enabled = false;
                transmit_value.Enabled = false;
                added_tax.Enabled = false;
                product_value.Enabled = false;
                saveBill.Enabled = false;

            }
            else
            {
                bill_value.Enabled = true;
                transmit_value.Enabled = true;
                added_tax.Enabled = true;
                product_value.Enabled = true;
                saveBill.Enabled = true;
            }
        }


        private void saveBill_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (product_value.Text == "" || transmit_value.Text == "" || bill_value.Text == "" || added_tax.Text == "")
            {
                MessageBox.Show("برجاء ادخال قيم الفاتورة", "تم", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("saveBill");
                }
            }
        }

        private void medicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("getMedicine");
            }
        }

        private void anavar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("getAnimal");
            }
        }

        private void cost_TextChanged(object sender, EventArgs e)
        {
            if (cost.Text == "")
            {
                cost.Text = "0.0";
            }

            double setTotal;
            double setPrice = Convert.ToDouble(cost.Text);
            double setAmount = Convert.ToDouble(numbers.Text);

            setTotal = setPrice * setAmount;
            total.Text = setTotal.ToString();
        }

        private void numbers_TextChanged(object sender, EventArgs e)
        {
            numbers.Text = string.Concat(numbers.Text.Where(char.IsDigit));

            if (numbers.Text == "")
            {
                numbers.Text = "0";
            }

            double setTotal;
            double setPrice = Convert.ToDouble(cost.Text);
            double setAmount = Convert.ToDouble(numbers.Text);

            setTotal = setPrice * setAmount;
            total.Text = setTotal.ToString();
        }

        private void tableB_DataSourceChanged(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < tableB.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(tableB[9, i].Value);
            }
            product_value.Text = sum.ToString();
        }

        private void added_tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!RegularExepression.PostiveOrNegative.IsMatch(added_tax.Text.Insert(added_tax.SelectionStart, e.KeyChar.ToString() + "1")))
            {
                e.Handled = true;
            }
        }

        private void transmit_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!RegularExepression.PostiveOrNegative.IsMatch(transmit_value.Text.Insert(transmit_value.SelectionStart, e.KeyChar.ToString() + "1")))
            {
                e.Handled = true;
            }
        }

        private void cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            RegularExepression.ValidationofDecimalPoint(sender, e, cost);

        }

        private void medicine_Purshase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.P)
            {
                if (tableB.Rows.Count == 0)
                {
                    MessageBox.Show("من فضلك اعرض الجدول أولا حتي تطبع", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tableB.SelectedRows.Count > 3)
                {
                    MessageBox.Show("برجاء تحديد 3 صفوف فقط", "تم", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = new DataTable();
                for (int i = 0; i < tableB.Columns.Count - 1; i++) // ADD Columns header of tableb into dt
                {
                    dt.Columns.Add(tableB.Columns[i].HeaderText);
                }
                //Adding selected rows of DGV to DataTable:
                for (int i = 0; i < tableB.SelectedRows.Count; i++)
                {
                    dt.Rows.Add();
                    for (int j = 0; j < tableB.Columns.Count - 1; j++)
                    {
                        dt.Rows[i][j] = tableB.SelectedRows[i].Cells[j].Value;
                    }
                }

                var form = new Farm_Management.Billing.Working_Invoices("MEDICINE PURSHACE", product_value.Text, dt);
                if (Application.OpenForms[form.Name] == null)
                {
                    form.Show();
                }
                else
                {
                    Application.OpenForms[form.Name].Focus();
                }
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                Billing.Bill_Reports _Reports = new Billing.Bill_Reports();
                _Reports.getSelectedRows(tableB);

            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                if (tableB.Rows.Count > 1)
                    tableB.SelectAll();
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

        private void product_value_TextChanged(object sender, EventArgs e)
        {
            if (product_value.Text == "")
            {
                product_value.Text = "0";
            }
        }

        private void tableB_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < tableB.Rows.Count; i++)
            {
                sum += Convert.ToInt32(tableB[9, i].Value);
            }
            product_value.Text = sum.ToString();
        }

        private void medicine_Purshase_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void tableB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < tableB.Rows.Count; i++)
            {
                sum += Convert.ToInt32(tableB[9, i].Value);
            }
            product_value.Text = sum.ToString();
        }
    }
}
