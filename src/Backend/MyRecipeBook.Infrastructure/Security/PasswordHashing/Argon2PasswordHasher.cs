using MyRecipeBook.Domain.Security.PasswordHashing;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
    {
        throw new NotImplementedException();
    }

    public string VerifyPassword(string password, string passwordHash)
    {
        throw new NotImplementedException();
    }
}
