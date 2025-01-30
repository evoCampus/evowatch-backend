namespace evoWatch.Services
{
    public interface IProfilePictureService
    {
        FileStream GetProfilePicture(Guid userId);
        Task<Guid> AddProfilePictureAsync(Stream stream);
        Task DeleteProfilePictureAsync(Guid imageId);
    }
}
