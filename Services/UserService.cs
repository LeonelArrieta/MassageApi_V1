using AutoMapper;
using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MassageApi_V1.Utilities.Hasher; 

namespace MassageApi_V1.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly MyDBContext _context;
        private readonly SecretHasher _hasher;
        private readonly IMapper _mapper;
        public UserService(IConfiguration configuration, MyDBContext context,IMapper mapper)
        {
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
            _hasher= new SecretHasher();
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

            var token = new JwtSecurityToken(
                             _configuration["Jwt:Issuer"],
                             _configuration["Jwt:Audience"],
                             claims,
                             expires: DateTime.Now.AddDays(1),
                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<HttpStatusCode> Register(UserNewDTO user)
        {
            //implementar isValid *******
            if (user == null || user.Email == "" || user.Password == null)
                return HttpStatusCode.BadRequest;

            var validate = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (validate != null && user.Email.Equals(validate.Email))
                return HttpStatusCode.Conflict;
            user.Password = _hasher.Hash(user.Password);
            _context.Users.Add(_mapper.Map<User>(user));
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        public async Task<string> Login(UserNewDTO user)
        {
            var userAuthenticate = await _context.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync();
            if (userAuthenticate != null)
            {
                if (_hasher.Verify(user.Password, userAuthenticate.Password))
                {                  
                    var token = GenerateToken(userAuthenticate);
                    return token;
                    
                    
                }
                return HttpStatusCode.BadRequest.ToString();
            }
           
            return HttpStatusCode.BadRequest.ToString();
        }


    }
}
