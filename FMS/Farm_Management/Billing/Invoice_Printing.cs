using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FMS.Farm_Management.Billing
{
    class Invoice_Printing
    {
        Guna.UI2.WinForms.Guna2GradientPanel panel;
        public Invoice_Printing(Guna.UI2.WinForms.Guna2GradientPanel panel)
        {
            this.panel = panel;
        }
        public  void PrintPanel()
        {
            PrintDocument doc = new PrintDocument();
            PrintDialog dialog = new PrintDialog();
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                dialog.Document = doc;
                doc.Print();
            }
        }
        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel.Width-5, panel.Height, panel.CreateGraphics());
            panel.DrawToBitmap(bmp, new Rectangle(0, 0, panel.Width, panel.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top+100, bounds.Width, factor * bounds.Width);
        }

    }
}
