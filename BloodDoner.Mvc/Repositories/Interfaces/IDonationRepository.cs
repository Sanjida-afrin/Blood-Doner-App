using BloodDoner.Mvc.Models.Entities;
using System.Linq.Expressions;

namespace BloodDoner.Mvc.Repositories.Interfaces
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation?> GetByIdAsync(int id);
        Task<IEnumerable<Donation>> FindAllAsync(Expression<Func<BloodDonerEntity, bool>> predicate);

        void Add(Donation bloodDoner);
        void Update(Donation bloodDoner);
        void Delete(Donation bloodDoner);

    }
}
