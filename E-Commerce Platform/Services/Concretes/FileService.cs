using E_Commerce_Platform.Contracts;
using E_Commerce_Platform.Services.Abstracts;

namespace E_Commerce_Platform.Services.Concretes
{
    public class FileService : IFileService
    {

        public string Upload(IFormFile file, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(path, uniqueFileName);

            using var fileStream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(fileStream);

            return uniqueFileName;
        }

        public string Upload(IFormFile file, CustomUploadDirectories uploadDirectory)
        {
            var path = GetStaticFilesDirectory(uploadDirectory);

            return Upload(file, path);
        }

        public string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", uploadDirectory.ToString());
        }

        public string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory, string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images", uploadDirectory.ToString(), fileName);
        }

        public string GetStaticFilesUrl(CustomUploadDirectories uploadDirectory, string fileName)
        {
            return $"/uploads/images/{uploadDirectory.ToString()}/{fileName}";
        }
    }
}
