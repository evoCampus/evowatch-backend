namespace evoWatch.Services
{
    public interface IFileSystemService
    {
        Task<FileStream> ReadAsync(string filename);
        Task WriteAsync(string filename, Stream stream);

        void Initialize(string basePath);
    }
}
