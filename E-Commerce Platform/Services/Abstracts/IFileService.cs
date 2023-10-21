using E_Commerce_Platform.Contracts;

namespace E_Commerce_Platform.Services.Abstracts
{
    public interface IFileService
    {

        string Upload(IFormFile file, string path);
        string Upload(IFormFile file, CustomUploadDirectories uploadDirectory);
        string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory);
        string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory, string fileName);
        string GetStaticFilesUrl(CustomUploadDirectories uploadDirectory, string fileName);
    }
}
