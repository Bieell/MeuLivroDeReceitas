using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;
using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALELISM = 1;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 20;
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        var hash = HashPassword(password, salt);       

        var combinedBytes = new byte[hash.Length + salt.Length];

        hash.CopyTo(combinedBytes);
        salt.CopyTo(combinedBytes, index: hash.Length);

        return Convert.ToBase64String(combinedBytes);
    }

    public bool VerifyPassword(string password, string passwordHash)
    {
        var combinedBytes = Convert.FromBase64String(passwordHash);

        var hash = new byte[HASH_SIZE];
        var salt = new byte[SALT_SIZE];

        Array.Copy(combinedBytes, hash, HASH_SIZE);
        Array.Copy(combinedBytes, HASH_SIZE, salt, 0, SALT_SIZE);

        var newHash = HashPassword(password, salt);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);
    }

    private byte[] HashPassword(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALELISM,
            Iterations = ITERATIONS,
            MemorySize = MEMORY_SIZE * 1024,
            Salt = salt
        };

        return hashAlgorithm.GetBytes(HASH_SIZE);
    }
}
