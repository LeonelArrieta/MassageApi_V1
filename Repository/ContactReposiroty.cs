using MassageApi_V1.DTOs;
using MassageApi_V1.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Repository
{
    public class ContactReposiroty : GenericRepository<Contact>, IContactRepository
    {
        private readonly MyDBContext _context;

        public ContactReposiroty(MyDBContext context):base(context) 
        {
            _context = context;
        }
    }
}
