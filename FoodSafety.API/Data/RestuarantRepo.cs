using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodSafety.API.Helpers;
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

        public async Task<PagedList<Restuarant>> GetRestuarantsAsync(ListParams listParams)
        {
            var list =  _context.Restuarants.AsQueryable();

            return await PagedList<Restuarant>.CreateAsync(list, listParams.PageNumber, listParams.PageSize);
        }

        public async Task<IEnumerable<Inspection>> GetInspectionsAsync()
        {
            return await _context.Inspections.Include(i => i.Violations).ToListAsync();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Violation>> GetViolationsAsync()
        {
            return await _context.Violations.ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.Include(u => u.Favourites).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(u => u.Favourites).ToListAsync();
        }

        public async Task<Favourites> GetLike(int userId, string restuarantId)
        {
            return await _context.Favourites.FirstOrDefaultAsync(x => x.UserId == userId && x.BusinessId == restuarantId);
        }

        public async Task<Restuarant> GetRestuarant(string businessId)
        {
            return await _context.Restuarants.FirstOrDefaultAsync(r => r.BusinessID == businessId);
        }

        public async Task<IEnumerable<Favourites>> GetLikes(int userId)
        {
            return await _context.Favourites.Where(x => x.UserId == userId).Include(x => x.Restuarant).ToListAsync();
        }
    }
}