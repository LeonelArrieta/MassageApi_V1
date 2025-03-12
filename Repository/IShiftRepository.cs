using MassageApi_V1.Models;

namespace MassageApi_V1.Repository
{
    public interface IShiftRepository:IGenericRepository<Shift>
    {
        public Task<List<Shift>> GetAllWhitRelations();
        public Task<List<DateTime>> GetAllDates();
    }
}
