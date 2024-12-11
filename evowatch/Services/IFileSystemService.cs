namespace evoWatch.Services
{
    public interface IFileSystemService
    {
        Task<FileStream> ReadAsync(string filename);
        Task WriteAsync(string filename, FileStream stream);

        void Initialize(string basePath);
    }
}
