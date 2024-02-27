using MassageApi_V1.Models;
using Microsoft.EntityFrameworkCore;

namespace MassageApi_V1.Repository
{
    public class ShiftReposiroty : GenericRepository<Shift>, IShiftRepository
    {
        private readonly MyDBContext _context;

        public ShiftReposiroty(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Shift>> GetAllWhitRelations()
        {
            var result = await _context.Shifts
                .Include(x => x.Contact).Where(x => x.ContactId == x.Contact.Id)
                .Include(x=>x.MassageType).Where(x=>x.MassageTypeId==x.MassageType.Id).ToListAsync();
            return result;
        }
    }
}
