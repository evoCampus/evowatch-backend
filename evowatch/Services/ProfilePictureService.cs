
namespace evoWatch.Services
{
    internal class ProfilePictureService : IProfilePictureService
    {
        private readonly IFileSystemService _fileSystemService;
        internal ProfilePictureService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public async Task<FileStream> GetProfilePictureAsync(Guid imageId)
        {
            try
            {
                string filename = $"{imageId}.png";
                return await _fileSystemService.ReadAsync(filename);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException($"Profile picture id {imageId} does not exist.");
            }
            
        }

        public async Task<Guid> AddProfilePictureAsync(Stream stream)
        {
            Guid imageId = Guid.NewGuid();
            string filename = $"{imageId}.png";
            await _fileSystemService.WriteAsync(filename, stream);
            return imageId;
        }
    }
    
    }

