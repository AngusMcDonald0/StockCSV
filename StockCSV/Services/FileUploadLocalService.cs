using StockCSV.Interfaces;

namespace StockCSV.Services
{
    public class FileUploadLocalService : IFileUploadService
    {
        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file is not null && Path.GetExtension(file.FileName) == ".csv")
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, Path.GetRandomFileName()), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
