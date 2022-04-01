using BreadingBread.Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace BreadingBread.Application.Interfaces
{
    public interface IExcelService
    {
        Stream AsStreamExcel(IEnumerable<ExcelCellAux> records, string plantilla);
        byte[] AsExcel(IEnumerable<ExcelCellAux> records, string plantilla);
        List<ExcelCellAux> FromObjectList(IEnumerable<object> records, int startRow = 1, int startCol = 1, bool includeIndex = false);
        List<ExcelCellAux> FromObjectMatrix(IEnumerable<IEnumerable<object>> records, int startRow = 1, int startCol = 1, bool includeIndex = false);
        List<ExcelCellAux> FromObjectByColumnList(IEnumerable<object> records, int startRow = 1, int startCol = 1, bool includeIndex = false);
    }
}
