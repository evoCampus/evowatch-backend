using System.Security.Cryptography;
using evoWatch.Models;

namespace evoWatch.Services.Implementations
{
    public class HashService : IHashService
    {
        private const int KEY_SIZE = 256 / 8;

        private const int ITERATIONS = 600000;

        public HashResult HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(KEY_SIZE);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, HashAlgorithmName.SHA256, KEY_SIZE);

            var result = new HashResult(Convert.ToBase64String(hash), salt);
            return result;
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, HashAlgorithmName.SHA256, KEY_SIZE);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromBase64String(hash));
        }
    }
}
