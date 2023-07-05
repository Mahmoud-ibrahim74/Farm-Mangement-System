using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Windows.Forms;

namespace FMS.Hardware.Printing
{
    class CombinePDFs
    {


        private string pathDoc = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));  // get document path for any machine              
        public string PathDesktop
        {
            get { return pathDoc; }
        }




        public void Combine(OpenFileDialog openFileDialog)
        {
            PdfDocument one = PdfReader.Open(openFileDialog.FileNames[0], PdfDocumentOpenMode.Import);
            PdfDocument two = PdfReader.Open(openFileDialog.FileNames[1], PdfDocumentOpenMode.Import);
            PdfDocument outPdf = new PdfDocument();
            CopyPages(one, outPdf);
            CopyPages(two, outPdf);
            Random random = new Random();
            int rand = random.Next(1, 3000);
            if (File.Exists(pathDoc + @"\FMS.pdf"))
            {
                outPdf.Save(pathDoc + @"\FMS("+rand.ToString()+").pdf");
            }
            else
            {
                outPdf.Save(pathDoc + @"\FMS.pdf");

            }
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }
    }
}
