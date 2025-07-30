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
        public Task AddAsync(BloodDonerEntity bloodDoner)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BloodDonerEntity bloodDoner)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BloodDonerEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public async Task<List<BloodDonerListViewModel>> GetFilteredBloodDonerAsync(FilterDonerModel filter)
        {
            var query = (await _unitOfWork.BloodDonerRepository.GetAllAsync()).AsEnumerable();

            if (!string.IsNullOrEmpty(filter.bloodGroup))
                query = query.Where(d => d.BloodGroup.ToString() == filter.bloodGroup);
            if (!string.IsNullOrEmpty(filter.address))
                query = query.Where(d => d.Address != null && d.Address.Contains(filter.address));

            var donors = query.Select(d => new BloodDonerListViewModel
            {
                Id = d.Id,
                FullName = d.FullName,
                ContactNumber = d.ContactNumber,
                Age = DateTime.Now.Year - d.DateofBirth.Year,
                Email = d.Email,
                BloodGroup = d.BloodGroup.ToString(),
                Address = d.Address,
                LastDonationDate = DateHelper.GetLastDonationDateString(d.LastDonationDate),
                ProfilePicture = d.ProfilePicture,
                IsEligible = (d.Weight > 45 && d.Weight < 200) && !d.LastDonationDate.HasValue || (DateTime.Now - d.LastDonationDate.Value).TotalDays >= 90

            }).ToList();

            if (filter.isEligible.HasValue)
            {
                donors = donors.Where(x => x.IsEligible == filter.isEligible).ToList();
            }
            return donors;
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
