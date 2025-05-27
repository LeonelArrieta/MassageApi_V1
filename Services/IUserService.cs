using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using MassageApi_V1.Utilities.Records;
using System.Net;

namespace MassageApi_V1.Services
{
    public interface IUserService
    {

        public Task<ServiceResult> Register(UserNewDTO user);
        public Task<ServiceResult> Login(UserNewDTO user);

    }
}
