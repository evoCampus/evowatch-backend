namespace evoWatch.Services
{
    public interface IFileSystemService
    {
        FileStream Read(string filename);
        Task WriteAsync(string filename, Stream stream);
        void Initialize(string basePath);
        void Delete(string filename);
    }
}
