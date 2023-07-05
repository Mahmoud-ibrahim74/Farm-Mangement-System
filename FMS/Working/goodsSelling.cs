using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Working
{
    public partial class goodsSelling : Form
    {
        DataTable dt = new DataTable();
        DataTable dt3 = new DataTable();

        public goodsSelling()
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
            if (storage.SelectedIndex == -1)
            {

                MessageBox.Show("برجاء اختيار المخزن اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (product_name.SelectedIndex == -1)
            {

                MessageBox.Show("برجاء اختيار الصنف اولا", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SQLSERVER_Queries.workingScripts.ProductsWorkingScript product = new SQLSERVER_Queries.workingScripts.ProductsWorkingScript();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            if (ControlName == "displayData")
            {
                dt.Clear();
                dt3.Clear();
                product.DisplayData(storage, dt, dt3);
                product.getAmountGoods(amount, price, storage, product_name);
                tableB.DataSource = dt;
                tableA.DataSource = dt3;
            }

            else if (ControlName == "storageReterive")
            {
               product.StorageRetreive(product_name, storage);
            }
            else if (ControlName == "getAmount")
            {
                product.getAmountGoods(amount, price, storage, product_name);

                if(!string.IsNullOrEmpty(state.GoodsState(product_name)))
                {
                    AnavarState.Text = state.GoodsState(product_name);

                }
                else
                {
                    AnavarState.Text = "................";
                }
            }
            else if (ControlName == "insertPremession")
            {
                product.InsertPremession(getDate, anavar_name, storage, payment,treasury, product_name, unit, amount, price, total, notes);
                product.getAmountGoods(amount, price, storage, product_name);
            }         
            else if (ControlName == "deleteCols")
            {
                product.deleteColumns(tableB,product_name);
                product.getAmountGoods(amount, price, storage, product_name);
            }
          
            else if (ControlName == "saveBill")
            {
                product.SaveBill(product_name,product_value,transmit_value,added_tax,bill_value);
            }
            
            else
            {
                product.LoadData(treasury, storage, anavar_name);
            }



        }


        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            panelLoader.Visible = false;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
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
            if (storage.SelectedIndex == -1 || product_name.SelectedIndex == -1)
            {
                MessageBox.Show("برجاء اختيار المخزن والصنف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tableA.Rows.Count == 0)
            {
                MessageBox.Show("من فضلك اعرض الجدول أولا حتي تضيف", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (amount.Text == "")
            {
                errorProvider.SetError(amount, "ادخل الكمية");

            }
            else if (price.Text == "")
            {
                errorProvider.SetError(price, "ادخل السعر");


            }
            else if (unit.SelectedIndex == -1)
            {
                errorProvider.SetError(unit, "اختر وحدة الوزن ");


            }
            else if (anavar_name.SelectedIndex == -1)
            {
                errorProvider.SetError(anavar_name, "اختر العنبر ");


            }
            else if (payment.SelectedIndex == -1)
            {
                errorProvider.SetError(payment, "اختر طريقة الدفع ");


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

        private void storage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (storage.Items.Count > 0)
            {
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync("storageReterive");
                }
            }
        }

        private void product_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync("getAmount");
            }
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            amount.Text = string.Concat(amount.Text.Where(char.IsDigit));

            if (amount.Text == "" && price.Text == "")
            {
                amount.Text = "0";
                price.Text = "0";

            }
            else if (amount.Text == "" || price.Text == "")
            {
                amount.Text = "0";
                price.Text = "0";

            }
            else
            {
                double setTotal;
                double setPrice = Convert.ToDouble(price.Text);
                double setAmount = Convert.ToDouble(amount.Text);

                setTotal = setPrice * setAmount;
                total.Text = setTotal.ToString();
            }

        }

        private void price_TextChanged(object sender, EventArgs e)
        {

            if (amount.Text == "" && price.Text == "")
            {
                amount.Text = "0";
                price.Text = "0.0";

            }
            else if (amount.Text == "" || price.Text == "")
            {
                amount.Text = "0";
                price.Text = "0.0";

            }
            else
            {
                double setTotal;
                double setPrice = Convert.ToDouble(price.Text);
                double setAmount = Convert.ToDouble(amount.Text);

                setTotal = setPrice * setAmount;
                total.Text = setTotal.ToString();
            }
        }

        private void tableB_DataSourceChanged(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < tableB.Rows.Count - 1; i++)
            {
                sum += Convert.ToInt32(tableB[10, i].Value);
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

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            RegularExepression.ValidationofDecimalPoint(sender, e, price);

        }

        private void goodsSelling_KeyDown(object sender, KeyEventArgs e)
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
                for (int i = 0; i < tableB.Columns.Count; i++) // ADD Columns header of tableb into dt
                {
                    dt.Columns.Add(tableB.Columns[i].HeaderText);
                }
                //Adding selected rows of DGV to DataTable:
                for (int i = 0; i < tableB.SelectedRows.Count; i++)
                {
                    dt.Rows.Add();
                    for (int j = 0; j < tableB.Columns.Count; j++)
                    {
                        dt.Rows[i][j] = tableB.SelectedRows[i].Cells[j].Value;
                    }
                }

                var form = new Farm_Management.Billing.Working_Invoices("GOODS PURSHACE", product_value.Text, dt);
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
                sum += Convert.ToInt32(tableB[10, i].Value);
            }
            product_value.Text = sum.ToString();
        }

        private void goodsSelling_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void tableB_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < tableB.Rows.Count; i++)
            {
                sum += Convert.ToInt32(tableB[10, i].Value);
            }
            product_value.Text = sum.ToString();
        }
    }
}
