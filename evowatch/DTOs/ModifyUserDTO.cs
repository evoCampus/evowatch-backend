
using System.Runtime.InteropServices;

namespace evoWatch.DTOs
{
    public class ModifyUserDTO
    {
        public string? NormalName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Nickname { get; set; }
        public string? ImageUrl { get; set; }
    }
}
