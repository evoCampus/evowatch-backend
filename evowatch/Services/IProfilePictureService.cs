namespace evoWatch.Services
{
    public interface IProfilePictureService
    {
        Task<Stream> GetProfilePictureAsync(string username);
        Task SetProfilePictureAsync(string username, Stream stream);
    }
}
