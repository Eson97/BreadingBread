using BreadingBread.Domain.Enums;

namespace BreadingBread.Domain.Entities
{
    /// <summary>
    /// Auxiliar para representar una celda de excel
    /// </summary>
    public class ExcelCellAux
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public object Value { get; private set; }
        public ExcelBorderStyle BorderStyle { get; }

        public ExcelCellAux(int row, int col, object value, ExcelBorderStyle borderStyle = ExcelBorderStyle.Thin)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
            BorderStyle = borderStyle;
        }
    }

}
