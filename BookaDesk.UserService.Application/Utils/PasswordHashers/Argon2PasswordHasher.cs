using Isopoh.Cryptography.Argon2;

namespace BookaDesk.UserService.Application.Utils.PasswordHashers;

public class Argon2PasswordHasher: IPasswordHasher
{
    public string HashPassword(string password)
    {
        return Argon2.Hash(password);
    }

    public bool VerifyPassword(string hashedPassword, string inputPassword)
    {
        return Argon2.Verify(hashedPassword, inputPassword);
    }
}