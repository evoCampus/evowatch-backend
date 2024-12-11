namespace evoWatch.Services
{
    public interface IProfilePictureService
    {
        Task<FileStream> GetProfilePictureAsync(Guid userId);
        Task SetProfilePictureAsync(Guid userId, FileStream stream);
    }
}
