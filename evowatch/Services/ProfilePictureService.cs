
namespace evoWatch.Services
{
    internal class ProfilePictureService : IProfilePictureService
    {
        private readonly IFileSystemService _fileSystemService;
        internal ProfilePictureService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        public async Task<FileStream> GetProfilePictureAsync(Guid userId)
        {
            try
            {
                string filename = $"{userId}.png";
                return await _fileSystemService.ReadAsync(filename);
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException($"Profile picture for user with id {userId} does not exist.");
            }
            
        }

        public async Task SetProfilePictureAsync(Guid userId, FileStream stream)
        {
            string filename = $"{userId}.png";
            await _fileSystemService.WriteAsync(filename, stream);
        }
    }
    
    }

