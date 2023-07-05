using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMS.Farm_Management.Billing
{
    public partial class Bill_Image : Form
    {
        Bitmap bitmap;
        Regex regex = new Regex(@"^-?\d+[.]?\d*$");
        public Bill_Image(DataTable InvoiceTable, string InvoiceType, string summary, string amount)
        {
            
            InitializeComponent();
            invoiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            InvoiceDetails.DataSource = InvoiceTable;
            this.InvoiceType.Text = InvoiceType;
            this.InvoiceSummary.Text = summary;
            this.amount.Text = amount;
            this.Amount2.Text = amount;
            CheckInvoiceID();
        }

       async void CheckInvoiceID()
        {
            while (true)
            {
                await Task.Delay(2000);
                if(Properties.Settings.Default.InvoiceID > 9)
                {
                    InvoiceID.Text = "0000" + Properties.Settings.Default.InvoiceID.ToString();
                }
                else if (Properties.Settings.Default.InvoiceID > 99)
                {
                    InvoiceID.Text = "000" + Properties.Settings.Default.InvoiceID.ToString();
                }
                else if (Properties.Settings.Default.InvoiceID > 999)
                {
                    InvoiceID.Text = "00" + Properties.Settings.Default.InvoiceID.ToString();
                }
                else
                {
                    InvoiceID.Text = "00000" + Properties.Settings.Default.InvoiceID.ToString();
                }

            }
        }

        private void CloseInvoice_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void secondAmount_TextChanged_1(object sender, EventArgs e)
        {
            if (secondAmount.Text == "")
            {
                secondAmount.Text = "0";
            }
            double getAmount = Convert.ToDouble(amount.Text);

            double getSecondAmount = Convert.ToDouble(secondAmount.Text);

            grandTotal.Text = (getAmount + getSecondAmount).ToString();

        }

        private void print_Click(object sender, EventArgs e)
        {
            try
            {
                print.Visible = false;
                var frm = Form.ActiveForm;
                Bitmap bitmapToPrint = new Bitmap(frm.Width, frm.Height);
                Graphics graphics = Graphics.FromImage(bitmapToPrint);
                frm.DrawToBitmap(bitmapToPrint, new Rectangle(0, 0, bitmapToPrint.Width, bitmapToPrint.Height));
                bitmap = new Bitmap(bitmapToPrint);
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDialog.Document = printDocument;
                    printDocument.Print();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                print.Visible = true;
            }

        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.DrawImage(bitmap, 0, 0);

        }

        private void secondAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar))
            {
                return;
            }
            if(!regex.IsMatch(secondAmount.Text.Insert(secondAmount.SelectionStart,e.KeyChar.ToString()+ "1")))
            {
                e.Handled = true;
            }
        }

        private void InvoiceTo_Text_TextChanged(object sender, EventArgs e)
        {
            invoiceTo.Text = InvoiceTo_Text.Text;            
        }

        private void InvoiceTo_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                InvoiceTo_Text.Visible = false;
            }         
        }
    }
}
