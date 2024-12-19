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

            string filepath = Path.Combine(_basePath, filename);

            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException("File not found.", filepath);
            }

            return new FileStream(filepath, FileMode.Open, FileAccess.Read);
        }
        public async Task WriteAsync(string filename, Stream stream)
        {
            if (_basePath is null)
            {
                throw new InvalidOperationException("FileSystemService has not been initialized.");
            }

            
            string filepath = Path.Combine(_basePath, filename);

            using ( var fileStream = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
