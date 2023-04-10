using MassageApi_V1.Models;
using System.CodeDom.Compiler;

namespace MassageApi_V1.Services
{
    public interface IUserService
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string GenerateToken(User user);
        public string EncryptPassword(string password);

    }
}
