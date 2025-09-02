using BloodDoner.Mvc.Model;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;

namespace BloodDoner.Mvc.Services.Interfaces
{
    public interface IBloodDonerService
    {
        Task<IEnumerable<BloodDonerEntity>> GetAllAsync();
        Task<List<BloodDonerEntity>> GetFilteredBloodDonerAsync(FilterDonerModel filter);

        Task<BloodDonerEntity?> GetByIdAsync(int id);
        Task AddAsync(BloodDonerEntity bloodDoner);
        Task UpdateAsync(BloodDonerEntity bloodDoner);
        Task DeleteAsync(int id);




    }
}
