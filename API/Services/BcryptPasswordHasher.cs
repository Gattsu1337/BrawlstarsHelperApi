namespace API.Services
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string hash, string password) => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
