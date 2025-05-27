using MassageApi_V1.Models;

namespace MassageApi_V1.Services
{
    public interface ITokenService
    {
        string Generate(User user);
    }
}
