namespace evoWatch.Models
{
    public class HashResult
    {
        public string Hash;
        public byte[] Salt;
        
        public HashResult(string hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
