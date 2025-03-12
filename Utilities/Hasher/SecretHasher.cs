using Sodium;

namespace MassageApi_V1.Utilities.Hasher
{
    public class SecretHasher
    {
        public string Hash(string password)
        {
            string hash = PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Medium);
            return hash;
        }

        public bool Verify(string password,string hash)
        {
            return PasswordHash.ArgonHashStringVerify(hash, password);
        }
    }
}
