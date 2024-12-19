namespace evoWatch.Services
{
    public interface IProfilePictureService
    {
        Task<FileStream> GetProfilePictureAsync(Guid userId);
        Task<Guid> AddProfilePictureAsync(Stream stream);
    }
}
