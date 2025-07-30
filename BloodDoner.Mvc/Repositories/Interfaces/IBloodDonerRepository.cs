using System.Linq.Expressions;
using BloodDoner.Mvc.Models.Entities;

namespace BloodDoner.Mvc.Repositories.Interfaces
{
    public interface IBloodDonerRepository : IRepository<BloodDonerEntity>
    {
        //Task<IEnumerable<BloodDonerEntity>> GetAllAsync();
        //Task<BloodDonerEntity?> GetByIdAsync(int id);
        //Task<IEnumerable<BloodDonerEntity>> FindAllAsync(Expression<Func<BloodDonerEntity, bool>> predicate);

        //void Add(BloodDonerEntity bloodDoner);
        //void Update(BloodDonerEntity bloodDoner);
        //void Delete(BloodDonerEntity bloodDoner);
        //Task<BloodDonerEntity> GetByIdAsync(object id);

    }
}
