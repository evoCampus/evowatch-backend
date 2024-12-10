
namespace evoWatch.Services
{
    internal class ProfilePictureService : IProfilePictureService
    {
        private readonly IFileSystemService _fileSystemService;
        internal ProfilePictureService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public Task<Stream> GetProfilePictureAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task SetProfilePictureAsync(string username, Stream stream)
        {
            throw new NotImplementedException();
        }
    }
    
    }

