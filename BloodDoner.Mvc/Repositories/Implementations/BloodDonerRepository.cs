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
       public override async Task<BloodDonerEntity?>GetByIdAsync(int id)
        {
            return await _dbset
                .Include(b => b.DonerCampaigns)
                     .ThenInclude(dc => dc.Campaign)
                .Include(b => b.Donations)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

    }
}
