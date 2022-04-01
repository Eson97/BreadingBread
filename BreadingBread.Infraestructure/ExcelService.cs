using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BreadingBread.Infraestructure
{
    public class ExcelService : IExcelService
    {
        public IDateTime CurrentDate { get; }
        public ExcelService(IDateTime dateTime)
        {
            this.CurrentDate = dateTime;
        }

        public byte[] AsExcel(IEnumerable<ExcelCellAux> records, string plantilla)
        {
            MemoryStream ms = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (FileStream fs = File.OpenRead(plantilla))
            using (ExcelPackage excelPackage = new ExcelPackage(fs))
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "BREAD SYSTEM";
                excelPackage.Workbook.Properties.Title = $"REPORTE DE VENTAS {CurrentDate.Now.ToShortDateString()}";
                excelPackage.Workbook.Properties.Subject = "Reporte de ventas";
                excelPackage.Workbook.Properties.Created = CurrentDate.Now;

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

        public Stream AsStreamExcel(IEnumerable<ExcelCellAux> records, string plantilla)
        {
            MemoryStream ms = new MemoryStream();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (FileStream fs = File.OpenRead(plantilla))
            using (ExcelPackage excelPackage = new ExcelPackage(fs))
            {
                //Set some properties of the Excel document
                excelPackage.Workbook.Properties.Author = "BREAD SYSTEM";
                excelPackage.Workbook.Properties.Title = $"REPORTE DE VENTAS {CurrentDate.Now.ToShortDateString()}";
                excelPackage.Workbook.Properties.Subject = "Reporte de ventas";
                excelPackage.Workbook.Properties.Created = CurrentDate.Now;

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

            return ms;
        }

        public List<ExcelCellAux> FromObjectByColumnList(IEnumerable<object> records, int startRow = 1, int startCol = 1, bool includeIndex = false)
        {
            List<ExcelCellAux> result = new List<ExcelCellAux>();
            int currCol = startRow;
            foreach (var recordDyn in records)
            {
                int currRow = startCol;
                var properties = recordDyn.GetType().GetProperties();
                if (includeIndex)
                {
                    result.Add(new ExcelCellAux(currCol, currRow, currCol - startRow + 1));
                    currRow++;
                }
                foreach (var property in properties)
                {
                    var value = property.GetValue(recordDyn, null);
                    result.Add(new ExcelCellAux(currCol, currRow, value));
                    currRow++;
                }
                currCol++;
            }
            return result;
        }

        public List<ExcelCellAux> FromObjectMatrix(IEnumerable<IEnumerable<object>> records, int startRow = 1, int startCol = 1, bool includeIndex = false)
        {
            List<ExcelCellAux> result = new List<ExcelCellAux>();
            int currRow = startRow;
            foreach (var curColumn in records)
            {
                int curCol = startCol;
                if (includeIndex)
                {
                    result.Add(new ExcelCellAux(currRow, curCol, currRow - startRow + 1));
                    curCol++;
                }

                foreach (var property in curColumn)
                {
                    result.Add(new ExcelCellAux(currRow, curCol, property));
                    curCol++;
                }
                currRow++;
            }
            return result;
        }
    }
}

