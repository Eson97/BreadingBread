using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BreadingBread.Infraestructure
{
    public class ExcelService : IExcelService
    {
        public byte[] AsExcel(IEnumerable<ExcelCellAux> records, string plantilla)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                using (FileStream fs = File.OpenRead(plantilla))
                using (ExcelPackage excelPackage = new ExcelPackage(fs))
                {
                    ExcelWorkbook excelWorkBook = excelPackage.Workbook;
                    ExcelWorksheet excelWorksheet = excelWorkBook.Worksheets.FirstOrDefault();

                    foreach (var record in records)
                    {
                        excelWorksheet.Cells[record.Row, record.Col].Value = record.Value;
                        excelWorksheet.Cells[record.Row, record.Col].Style.Border.BorderAround((OfficeOpenXml.Style.ExcelBorderStyle)record.BorderStyle);
                    }
                    excelWorksheet.Cells[excelWorksheet.Dimension.Address].AutoFitColumns();
                    excelPackage.SaveAs(ms); // This is the important part.
                }

                ms.Position = 0;

                return ms.ToArray();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        public List<ExcelCellAux> FromObjectList(IEnumerable<object> records, int startRow = 1, int startCol = 1, bool includeIndex = false)
        {
            List<ExcelCellAux> result = new List<ExcelCellAux>();
            int currRow = startRow;
            foreach (var recordDyn in records)
            {

                int curCol = startCol;
                var properties = recordDyn.GetType().GetProperties();
                if (includeIndex)
                {
                    result.Add(new ExcelCellAux(currRow, curCol, currRow - startRow + 1));
                    curCol++;
                }
                foreach (var property in properties)
                {
                    var value = property.GetValue(recordDyn, null);
                    result.Add(new ExcelCellAux(currRow, curCol, value));
                    curCol++;
                }
                currRow++;
            }
            return result;
        }
    }
}

