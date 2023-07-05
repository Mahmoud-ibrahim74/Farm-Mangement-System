using DGVPrinterHelper;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace FMS.Hardware.Printing
{
    class PrinterSender
    {
        public PrinterSender()
        {

        }

        public void SendPRinter(string title, DataGridView table)
        {
            DGVPrinter p = new DGVPrinter();
            p.Title = title + "\n\n";
            p.PageNumbers = true;
            p.PageNumberInHeader = false;
            p.PorportionalColumns = true;
            p.PorportionalColumns = true;
            p.PageNumberInHeader = true;
            p.PageSeparator = "-";
            p.HeaderCellAlignment = StringAlignment.Center;
            p.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;
            p.PageNumberAlignment = StringAlignment.Center;
            p.PageNumberOnSeparateLine = true;
            p.PageNumberPrint = DGVPrinter.PrintLocation.All;
            p.PageText = title;
            p.ShowTotalPageNumber = true;
            p.Footer = "محمية المها الوضيحي";
            p.FooterSpacing = 15;
            p.PrintDataGridView(table);
        }

    }
}
