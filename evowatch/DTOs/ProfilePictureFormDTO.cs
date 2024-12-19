namespace evoWatch.DTOs
{
    public class ProfilePictureFormDTO
    {
        public Guid userId { get; set; }
        public IFormFile file { get; set; }
    }
}
