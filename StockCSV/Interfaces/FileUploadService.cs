namespace StockCSV.Interfaces
{
    public interface IFileUploadService
    {
        Task<bool> UploadFile(IFormFile file);
    }
}
