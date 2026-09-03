namespace MyRecipeBook.Domain.Security.PasswordHashing;

public interface IPasswordHasher
{
    string HashPassword(string password);
    string VerifyPassword(string password, string passwordHash);
}
