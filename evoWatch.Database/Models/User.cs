using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace evoWatch.Database.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Required]
        [MaxLength(30, ErrorMessage = "NormalName cannot be longer than: 30")]
        public string NormalName { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Email cannot be longer than: 32")]
        public string Email { get; set; }
        [MaxLength(16, ErrorMessage = "Nickname cannot be longer than: 16")]
        public string Nickname { get; set; }
        [MaxLength(2048, ErrorMessage = "ImageUrl cannot be longer than: 2048")]
        public string? ImageUrl { get; set; }
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public string Nickname { get; set; }
        public string ImageId { get; set; }
    }
}