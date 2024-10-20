using System.Security.Cryptography;
using static evoWatch.Models.Hash;

namespace evoWatch.Services.Implementations
{
    public class HashService
    {
        const int keySize = 256 / 8;

        const int iterations = 600000;

        public HashResult HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, keySize);

            var result = new HashResult
            {
                hash = Convert.ToBase64String(hash),
                salt = salt

            };
            return result;
        }

        public bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromBase64String(hash));
        }
    }
}
