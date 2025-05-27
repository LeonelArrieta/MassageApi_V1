using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.EntityFrameworkCore;
using MassageApi_V1.Utilities.Hasher;
using MassageApi_V1.Utilities.Records;

namespace MassageApi_V1.Services
{
    public class UserService : IUserService
    {
        private readonly MyDBContext _context;
        private readonly ITokenService _tokenService;
        private readonly SecretHasher _hasher;
        private readonly IMapper _mapper;
     
        public UserService( MyDBContext context,IMapper mapper,ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
            _hasher= new SecretHasher();
        }
              
        
        public async Task<ServiceResult> Register(UserNewDTO user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                return new ServiceResult(false, "Usuario no válido.");
            var validate = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (validate!=null)
                return new ServiceResult(false, "El correo electrónico ya está registrado.");

            user.Password = _hasher.Hash(user.Password);
            _context.Users.Add(_mapper.Map<User>(user));
            try
            {
                await _context.SaveChangesAsync();
                return new ServiceResult(true, "Usuario registrado correctamente.");

            }
            catch
            {
                return new ServiceResult(false, "Error, prueba más tarde.");
            }
           
        }

        public async Task<ServiceResult> Login(UserNewDTO user)
        {
            var userAuthenticate = await _context.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();
            if (userAuthenticate != null && _hasher.Verify(user.Password, userAuthenticate.Password))
            {               
                  var token = _tokenService.Generate(userAuthenticate);
                  return new ServiceResult(true,token);
                    
            }
           
            return new ServiceResult(false, "Correo electrónico o contraseña incorrectos.");
        }


    }
}
