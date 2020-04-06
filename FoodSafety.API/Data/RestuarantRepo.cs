using System.Collections.Generic;
using System.Threading.Tasks;
using FoodSafety.API.Models;

namespace FoodSafety.API.Data
{
    public class RestuarantRepo : IRestuarantRepository
    {
        private readonly DataContext _context;

        public RestuarantRepo(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Task<IEnumerable<Restuarant>> GetRestuarantsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

       
    }
}