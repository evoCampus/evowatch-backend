namespace evoWatch.Services
{
    internal class FileSystemService : IFileSystemService
    {
        protected string? _basePath;

        public void Initialize(string basePath)
        {
            if (_basePath is not null)
            {
                throw new InvalidOperationException("FileSystemService has already been initialized.");
            }
            _basePath = Path.Combine("images", basePath);
            Directory.CreateDirectory(_basePath);
        }

        public async Task<FileStream> ReadAsync(string filename)
        {
            if(_basePath is null)
            {
                throw new InvalidOperationException("FileSystemService has not been initialized.");
            }

            throw new NotImplementedException();
        }
        public async Task WriteAsync(string filename, Stream stream)
        {
            if (_basePath is null)
            {
                throw new InvalidOperationException("FileSystemService has not been initialized.");
            }

            throw new NotImplementedException();
        }
    }
}
