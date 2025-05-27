using MassageApi_V1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MassageApi_V1.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyDBContext _context;
        protected DbSet<T> Entities => _context.Set<T>();


        public GenericRepository(MyDBContext context)
        {
            _context = context;
        }



        public async Task<T?> Delete(int id)
        {
            var result = await Entities.FindAsync(id);
            if (result != null)
            {
                Entities.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<List<T>> GetAll()
        {
            var result = await Entities.ToListAsync();
            return result;
        }

        public async Task<T?> GetById(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<T> Add(T value)
        {
            EntityEntry<T> result = await Entities.AddAsync(value);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T?> Update(T value)
        {
            try
            {
                Entities.Update(value);
                await _context.SaveChangesAsync();
                return value;
            }
            catch
            {
                return null;
            }
        }
    }
}
