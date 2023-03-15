namespace BreadingBread.Application.UseCases.ReportSales.Queries.DownloadExcelByUserSale
{
    public class DownloadExcelByUserSaleResponse
    {
        public DownloadExcelByUserSaleResponse(string fileName, byte[] file)
        {
            FileName = fileName;
            File = file;
        }

        public string FileName { get; set; }
        public byte[] File { get; set; }
    }
}
