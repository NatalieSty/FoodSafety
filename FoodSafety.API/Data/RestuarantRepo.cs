using System.Collections.Generic;
using System.Threading.Tasks;
using FoodSafety.API.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Restuarant>> GetRestuarantsAsync()
        {
            return await _context.Restuarants.Include(i => i.Inspections).ToListAsync();
        }

        public async Task<IEnumerable<Inspection>> GetInspectionsAsync()
        {
            return await _context.Inspections.Include(i => i.Violations).Include(i => i.Restuarant).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Violation>> GetViolationsAsync()
        {
            return await _context.Violations.Include(i => i.Inspection).ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(u => u.Favourites).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}