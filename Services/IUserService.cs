using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using System.CodeDom.Compiler;
using System.Net;

namespace MassageApi_V1.Services
{
    public interface IUserService
    {
      
        public string GenerateToken(User user);
        public string EncryptPassword(string password);

        public Task<HttpStatusCode> Register(UserNewDTO user);
        public Task<string> Login(UserNewDTO user);

    }
}
