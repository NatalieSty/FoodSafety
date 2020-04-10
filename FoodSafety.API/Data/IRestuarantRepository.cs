using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodSafety.API.Models;

namespace FoodSafety.API.Data
{
    public interface IRestuarantRepository
    {
      void Add<T>(T entity) where T: class;

      void Delete<T>(T entity) where T: class;
      Task<IEnumerable<Restuarant>> GetRestuarantsAsync();
      Task<IEnumerable<Inspection>> GetInspectionsAsync();
      Task<IEnumerable<Violation>> GetViolationsAsync();
      Task<Restuarant> GetRestuarant(string businessId);
      Task<IEnumerable<User>> GetUsers();
      Task<User> GetUser(int id);
      Task<bool> SaveAll();
      Task<IEnumerable<Favourites>> GetLikes(int userId);
      Task<Favourites> GetLike(int userId, string restuarantId);
    }
}