using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FMS.Farm_Management
{
    class ExportExcel
    {
        public void ExcelExport(DataGridView tableA, DataGridView tableB, SaveFileDialog saveExcel)
        {
            string pathDoc = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));  // get document path for any machine
            saveExcel.InitialDirectory = pathDoc;
            try
            {

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Cells[1, 1] = "Bold";
                worksheet.Name = "Records";
                app.Columns.ColumnWidth = 35;
                app.StandardFont = "Segoe UI Emoji";
                app.StandardFontSize = 15;
                Microsoft.Office.Interop.Excel.Range formatRange;
                formatRange = worksheet.get_Range("A1");
                formatRange.EntireRow.Font.Bold = true;
                formatRange.RowHeight = 35;
                formatRange.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                try
                {


                    for (int i = 0; i < tableA.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = tableA.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Aqua);
                    }

                    for (int i = 0; i < tableA.Rows.Count; i++)
                    {
                        for (int j = 0; j < tableA.Columns.Count; j++)
                        {
                            if (tableA.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = tableA.Rows[i].Cells[j].Value.ToString();

                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "-";
                            }
                        }
                    }




                    for (int i = 0; i < tableB.Columns.Count; i++)
                    {
                        worksheet.Cells[tableA.Rows.Count + 2, i + 1] = tableB.Columns[i].HeaderText;
                        worksheet.Cells[tableA.Rows.Count + 2, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PaleTurquoise);
                    }
                    for (int i = 0; i < tableB.Rows.Count; i++)
                    {
                        for (int j = 0; j < tableB.Columns.Count; j++)
                        {
                            if (tableB.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + tableA.Rows.Count + 3, j + 1] = tableB.Rows[i].Cells[j].Value.ToString();

                            }
                            else
                            {
                                worksheet.Cells[i + tableA.Rows.Count + 3, j + 1] = "-";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                finally
                {
                    saveExcel.FilterIndex = 2;

                    if (saveExcel.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveExcel.FileName);
                        if (MessageBox.Show("تم حفظ الملف هل تريد فتح الملف؟؟", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Process.Start(pathDoc);
                        }

                    }
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void ExeclReportOne(DataGridView show_data, SaveFileDialog saveExcel)
        {

            {
                string pathDoc = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));  // get document path for any machine
                saveExcel.InitialDirectory = pathDoc;
                saveExcel.Title = "Save As Excel File";
                saveExcel.FileName = "Sheet(1)";
                saveExcel.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                try
                {

                    Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                    worksheet = workbook.Sheets["Sheet1"];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Cells[1, 1] = "Bold";
                    worksheet.Name = "Records";
                    app.Columns.ColumnWidth = 35;
                    app.StandardFont = "Segoe UI Emoji";
                    app.StandardFontSize = 15;
                    Microsoft.Office.Interop.Excel.Range formatRange;
                    formatRange = worksheet.get_Range("A1");
                    formatRange.EntireRow.Font.Bold = true;
                    formatRange.RowHeight = 35;
                    formatRange.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


                    try
                    {
                        for (int i = 0; i < show_data.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1] = show_data.Columns[i].HeaderText;
                            worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.PaleVioletRed);

                        }
                        for (int i = 0; i < show_data.Rows.Count; i++)
                        {
                            for (int j = 0; j < show_data.Columns.Count; j++)
                            {
                                if (show_data.Rows[i].Cells[j].Value != null)
                                {
                                    worksheet.Cells[i + 2, j + 1] = show_data.Rows[i].Cells[j].Value.ToString();

                                }
                                else
                                {
                                    worksheet.Cells[i + 2, j + 1] = "-";
                                }
                            }
                        }

                        //Getting the location and file name of the excel to save from user. 
                       
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    finally
                    {
                        saveExcel.FilterIndex = 2;

                        if (saveExcel.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveExcel.FileName);
                            if (MessageBox.Show("تم حفظ الملف هل تريد فتح الملف؟؟", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                Process.Start(pathDoc);
                            }

                        }
                        app.Quit();
                        workbook = null;
                        worksheet = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }

        }
    }
}
