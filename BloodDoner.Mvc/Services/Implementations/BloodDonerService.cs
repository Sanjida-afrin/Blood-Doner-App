using System.Net;
using BloodDoner.Mvc.Data;
using BloodDoner.Mvc.Data.UnitOfWork;
using BloodDoner.Mvc.Model;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;
using BloodDoner.Mvc.Repositories.Interfaces;
using BloodDoner.Mvc.Services.Interfaces;
using BloodDoner.Mvc.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BloodDoner.Mvc.Services.Implementations
{
    public class BloodDonerService : IBloodDonerService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private IBloodDonerService bloodDonerRepository;

        public BloodDonerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(BloodDonerEntity bloodDoner)
        {
            _unitOfWork.BloodDonerRepository.Add(bloodDoner);
             await _unitOfWork.SaveAsync();
        }

        public Task UpdateAsync(BloodDonerEntity bloodDoner)
        {
            _unitOfWork.BloodDonerRepository.Update(bloodDoner);
            return _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BloodDonerEntity>> GetAllAsync()
        {
          return await _unitOfWork.BloodDonerRepository.GetAllAsync();
        }

        public async Task<BloodDonerEntity?> GetByIdAsync(int id)
        {
            return await _unitOfWork.BloodDonerRepository.GetByIdAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var donor = await _unitOfWork.BloodDonerRepository.GetByIdAsync(id);
            if (donor != null)
            {
                _unitOfWork.BloodDonerRepository.Delete(donor);
                await _unitOfWork.SaveAsync();
            }
            
        }

        public async Task<List<BloodDonerEntity>> GetFilteredBloodDonerAsync(FilterDonerModel filter)
        {
            var query = _unitOfWork.BloodDonerRepository.Query();

            if (!string.IsNullOrEmpty(filter.bloodGroup))
                query = query.Where(d => d.BloodGroup.ToString() == filter.bloodGroup);
            if (!string.IsNullOrEmpty(filter.address))
                query = query.Where(d => d.Address != null && d.Address.Contains(filter.address));

           
            return await query.ToListAsync();
        }

        public Task<IEnumerable<BloodDonerEntity>> GetFilteredBloodDonerAsync()
        {
            throw new NotImplementedException();
        }

        public static bool IsEligible(BloodDonerEntity bloodDoner)
        {
            if(bloodDoner.Weight<=45 || bloodDoner.Weight>=200)
                return false;
            if(bloodDoner.LastDonationDate.HasValue)
            {
                var daysSinceLastDonation = (DateTime.Now - bloodDoner.LastDonationDate.Value).TotalDays;
                return daysSinceLastDonation >= 90;
            }
            return true;
        }
    }
}
