using BlogApi.Models;

namespace BlogApi.Interfaces
{
    public interface IFiles
    {
        public  Task<FilesModel> UploadFile(FilesModel files);
        public Task<string> GetImage(IFormFile file);
    }
}
