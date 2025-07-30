using System.Linq.Expressions;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Repositories.Interfaces;

namespace BloodDoner.Mvc.Repositories.Implementations
{
    public class DonationRepository : IDonationRepository
    {
        public void Add(Donation bloodDoner)
        {
            throw new NotImplementedException();
        }

        public void Delete(Donation bloodDoner)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Donation>> FindAllAsync(Expression<Func<BloodDonerEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Donation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Donation?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Donation bloodDoner)
        {
            throw new NotImplementedException();
        }
    }
}
