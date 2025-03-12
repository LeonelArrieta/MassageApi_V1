using MassageApi_V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MassageApi_V1.Repository
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
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

        public async Task<T?> GetbyId(int id)
        {
            var result = await Entities.FindAsync(id);
            if (result != null)
                return result;
            return null;
        }

        public async Task<T> Post(T value)
        {
            EntityEntry<T> result = await Entities.AddAsync(value);  
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T?> Update(T value)
        {
            EntityEntry<T> result = _context.Entry(value);
            if(result != null)
            {   
                _context.Update(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
                
            return null;
        }
    }
}
