using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FMS.Basic_Data
{
    public partial class AnimalsIntializer : Form
    {
        private DataTable dt = new DataTable();
        private List<string> getRowData = new List<string>();

        public AnimalsIntializer()
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
                backgroundWorker.RunWorkerAsync("DisplayAnimals");
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
                if (MessageBox.Show("هل تريد حذف حيوان رقم  " + getRowData.ElementAt(0), "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync("deleteAnimal");
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
            SQLSERVER_Queries.Basic_Data.AnimalIntilaizer animal = new SQLSERVER_Queries.Basic_Data.AnimalIntilaizer();

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (ControlName == "DisplayAnimals")
            {
                dt.Clear();
                animal.DisplayData(dt);
                tableB.DataSource = dt;


            }
            else if (ControlName == "insertAccount")
            {
                animal.InsertAnimal(animal_name, getSotrage, notes, numbers, price, total);
            }
            else if (ControlName == "updateAnimal")
            {
                animal.UpdateAnimal(getRowData.ElementAt(1), getRowData.ElementAt(2), getRowData.ElementAt(3), getRowData.ElementAt(4), getRowData.ElementAt(5), getRowData.ElementAt(6), getRowData.ElementAt(0));
                dt.Clear();
                animal.DisplayData(dt);
                tableB.DataSource = dt;
            }
            else if (ControlName == "deleteAnimal")
            {
                animal.DeleteAnimal(getRowData.ElementAt(0));
                dt.Clear();
                animal.DisplayData(dt);
                tableB.DataSource = dt;
            }
            else
            {
                animal.LoadData(getSotrage);
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
                    backgroundWorker.RunWorkerAsync("updateAnimal");
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClickSound sound = new ClickSound();
            sound.RunClickSound();
            if (string.IsNullOrEmpty(animal_name.Text))
            {
                errorProvider.SetError(animal_name, "برجاء ادخال اسم الحيوان");
            }
            else if (getSotrage.SelectedIndex == -1)
            {
                errorProvider.SetError(getSotrage, "برجاء ادخال العنبر");

            }
            else if (string.IsNullOrEmpty(numbers.Text))
            {
                errorProvider.SetError(numbers, "برجاء ادخال العدد");

            }
            else if (string.IsNullOrEmpty(price.Text))
            {
                errorProvider.SetError(price, "برجاء ادخال السعر");

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

        private void search_TextChanged_1(object sender, EventArgs e)
        {
            if (tableB.DataSource != null)
            {
                if (search.Text == "")
                {
                    (tableB.DataSource as DataTable).DefaultView.RowFilter = null;
                }
                (tableB.DataSource as DataTable).DefaultView.RowFilter = string.Format("[نوع الحيوان] LIKE '%{0}%'", search.Text);
            }
        }

        private void numbers_TextChanged(object sender, EventArgs e)
        {
            numbers.Text = string.Concat(numbers.Text.Where(char.IsDigit));

            if (numbers.Text == "" && price.Text == "")
            {
                numbers.Text = "0";
                price.Text = "0";

            }
            else if (numbers.Text == "" || price.Text == "")
            {
                numbers.Text = "0";
                price.Text = "0";

            }
            else
            {
                double setTotal;
                double setPrice = Convert.ToDouble(price.Text);
                double setAmount = Convert.ToDouble(numbers.Text);

                setTotal = setPrice * setAmount;
                total.Text = setTotal.ToString();
            }
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            if (numbers.Text == "" && price.Text == "")
            {
                numbers.Text = "0";
                price.Text = "0.0";
            }
            else if (numbers.Text == "" || price.Text == "")
            {
                numbers.Text = "0";
                price.Text = "0.0";

            }
            else
            {
                double setTotal;
                double setPrice = Convert.ToDouble(price.Text);
                double setAmount = Convert.ToDouble(numbers.Text);

                setTotal = setPrice * setAmount;
                total.Text = setTotal.ToString();
            }
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            RegularExepression.ValidationofDecimalPoint(sender, e, price);
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

        private void AnimalsIntializer_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();

        }

        private void AnimalsIntializer_KeyDown(object sender, KeyEventArgs e)
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
