using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace BloodDoner.Mvc.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbset;
        public Repository(BloodDonerDbContext context)
        {
            _dbset = context.Set<T>();
        }

        public void Add(T bloodDoner)
        {
            _dbset.Add(bloodDoner);
        }

        public void Delete(T bloodDoner)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
         return await _dbset.FindAsync(id);
        }

        public IQueryable<T> Query() 
        {
            return _dbset.AsQueryable().AsNoTracking();
        }

        public void Update(T bloodDoner)
        {
            _dbset.Update(bloodDoner);
        }
    }
}
