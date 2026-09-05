using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;
using System.Text;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    private const int DEGREE_OF_PARALELISM = 1;
    private const int ITERATIONS = 2;
    private const int MEMORY_SIZE = 20;

    public string HashPassword(string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DEGREE_OF_PARALELISM,
            Iterations = ITERATIONS,
            MemorySize = MEMORY_SIZE * 1024
        };

        return "";
    }

    public string VerifyPassword(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
