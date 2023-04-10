using MassageApi_V1.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MassageApi_V1.Services
{
    public class UserService:IUserService
    {
        private readonly IConfiguration _configuration;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [PasswordPropertyText(true)]
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;


        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var token =     new JwtSecurityToken(
                             _configuration["Jwt:Issuer"],
                             _configuration["Jwt:Audience"],
                             claims,
                             expires: DateTime.Now.AddDays(1),
                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
