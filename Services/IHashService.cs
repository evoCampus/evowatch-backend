using static evoWatch.Models.Hash;

namespace evoWatch.Services
{
    public interface IHashService
    {
        HashResult HashPassword(string password);

        bool VerifyPassword(string password, string hash, byte[] salt);
    }
}
