namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale
{
    public class GetExcelByUserSaleResponse
    {
        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
