using Sodium;

namespace MassageApi_V1.Utilities.Hasher
{
    public class SecretHasher
    {
        public string Hash(string password)
        {
            // Asegúrate de que el password no sea null ni vacío
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía.", nameof(password));

            // Genera el hash usando Argon2id con fuerza media
            string hash = PasswordHash.ArgonHashString(password, PasswordHash.StrengthArgon.Medium);
            return hash;
        }

        public bool Verify(string password, string hash)
        {
            // Valida los parámetros de entrada
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
                return false;

            try
            {
                // Verifica el hash usando Argon2id
                return PasswordHash.ArgonHashStringVerify(hash, password);
            }
            catch
            {
                // Si ocurre una excepción, la verificación falla
                return false;
            }
        }
    }
}
