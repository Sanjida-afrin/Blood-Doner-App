using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Exceptions;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace BloodDoner.Mvc.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbset;
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
            _dbset.Remove(bloodDoner);
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> result;
            //return await _dbset.ToListAsync();
            try
            {
                return await _dbset.ToListAsync();
            }
            catch (ArgumentNullException argEx)
            {
                // Log the database update exception (you can use any logging framework you prefer)
                Console.WriteLine($"Argument Null exception: {argEx.Message}");
                throw new RepositoryOpearationFailedException(""); // Re-throw the exception after logging it
            }
            catch (OperationCanceledException ex)
            {
                // Log the exception (you can use any logging framework you prefer)
                Console.WriteLine($"Invalid Operation exception: {ex.Message}");
                return null;// Re-throw the exception after logging it
            }
            catch (Exception ex)
            {
                // Log the exception (you can use any logging framework you prefer)
                Console.WriteLine($"An error occurred while retrieving data: {ex.Message}");
                throw;// Re-throw the exception after logging it
            }
            finally
            {
                result = new List<T>();
            }
            return result;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
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
