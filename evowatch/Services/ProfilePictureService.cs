
namespace evoWatch.Services
{
    internal class ProfilePictureService : IProfilePictureService
    {
        private readonly IFileSystemService _fileSystemService;
        internal ProfilePictureService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public FileStream GetProfilePicture(Guid imageId)
        {
            try
            {
                string filename = $"{imageId}.png";
                return  _fileSystemService.Read(filename);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            
        }

        public async Task<Guid> AddProfilePictureAsync(Stream stream)
        {
            Guid imageId = Guid.NewGuid();
            string filename = $"{imageId}.png";
            await _fileSystemService.WriteAsync(filename, stream);
            return imageId;
        }

        public async Task DeleteProfilePictureAsync(Guid imageId)
        {
            string filename = $"{imageId}.png";
            _fileSystemService.Delete(filename);
        }
    }
    
    }

