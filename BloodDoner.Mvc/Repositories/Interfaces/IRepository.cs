using BloodDoner.Mvc.Models.Entities;
using System.Linq.Expressions;

namespace BloodDoner.Mvc.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        IQueryable<T> Query();
        void Add(T bloodDoner);
        void Update(T bloodDoner);
        void Delete(T bloodDoner);
    }
}
