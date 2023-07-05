using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FMS.Farm_Management.Billing
{
    public partial class Working_Invoices : Form
    {
        Bitmap bitmap;
        Regex regex = new Regex(@"^-?\d+[.]?\d*$");
        public Working_Invoices(string workType, string totAmount, DataTable tbl)
        {
            InitializeComponent();
            InvoiceID.Text = new Random().Next(1, 1000).ToString();
            invoiceDate.Text = DateTime.Now.ToString("yyyy-mm-dd");
            InvoiceType.Text = workType;
            InvoiceSummary.Text = workType + " to make invoices for Working";
            amount.Text = totAmount;
            Amount2.Text = totAmount;
            InvoiceDetails.DataSource = tbl;

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
            // Grap.CopyFromScreen(PointToScreen(this.Location).X, PointToScreen(this.Location).Y, 0, 0, this.Size, CopyPixelOperation.SourceCopy);
            var frm = Form.ActiveForm;
            Bitmap bitmapToPrint = new Bitmap(frm.Width - 61, frm.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmapToPrint);
            frm.DrawToBitmap(bitmapToPrint, new Rectangle(0, 0, bitmapToPrint.Width, bitmapToPrint.Height));
            bitmap = new Bitmap(bitmapToPrint);
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDialog.Document = printDocument;
                printDocument.Print();
                Properties.Settings.Default.InvoiceID++;
                Properties.Settings.Default.Save();
            }


        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void secondAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }
            if (!regex.IsMatch(secondAmount.Text.Insert(secondAmount.SelectionStart, e.KeyChar.ToString() + "1")))
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
            if (e.KeyCode == Keys.Enter)
            {
                InvoiceTo_Text.Visible = false;
            }
        }
    }
}
