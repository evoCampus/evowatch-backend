namespace evoWatch.Database.Models
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string NormalName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public string Nickname { get; set; }
        public string ImageUrl { get; set; }
    }
}
