using System.Linq.Expressions;
using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BloodDoner.Mvc.Repositories.Implementations
{
    public class BloodDonerRepository : Repository<BloodDonerEntity>, IBloodDonerRepository

    {
        public BloodDonerRepository(BloodDonerDbContext context) : base(context)
        {
        }
        //private readonly BloodDonerDbContext   _context;
        // public BloodDonerRepository(BloodDonerDbContext context)
        //  {
        //      _context = context;
        //  }
        //  public void Add(BloodDonerEntity bloodDoner)
        //  {
        //      _context.BloodDoners.Add(bloodDoner);
        //  }

        //  public void Delete(BloodDonerEntity bloodDoner)
        //  {
        //      _context.BloodDoners.Remove(bloodDoner);
        //  }

        //  public Task<IEnumerable<BloodDonerEntity>> FindAllAsync(Expression<Func<BloodDonerEntity, bool>> predicate)
        //  {
        //      throw new NotImplementedException();
        //  }

        //  public async Task<IEnumerable<BloodDonerEntity>> GetAllAsync()
        //  {
        //   return await _context.BloodDoners.ToListAsync();
        //  }

        //  public async Task<BloodDonerEntity?> GetByIdAsync(int id)
        //  {
        //    return await _context.BloodDoners.FindAsync(id);
        //  }

        //  public void Update(BloodDonerEntity bloodDoner)
        //  {
        //      _context.BloodDoners.Update(bloodDoner);
        //  }

    }
}
