using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using System.Text;
using WebApplication1.Models;
using WebApplication1.DataAccess;

namespace WebApplication1.Shared
{
    public class PasswordManager
    {
        private IConfiguration _Configuration;
        public PasswordManager(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public bool CheckPassword(string hashedPassword, string password)
        {
            string newHash = GeneratePassword(password);
            return hashedPassword == newHash;
        }

        public ClaimsIdentity GenerateClaims(User user)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, "user"),
                };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity
                (
                    claims, CookieAuthenticationDefaults.AuthenticationScheme
                );
            return claimsIdentity;
        }

        public string GeneratePassword(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes(_Configuration.GetValue<string>("Salt"));

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
