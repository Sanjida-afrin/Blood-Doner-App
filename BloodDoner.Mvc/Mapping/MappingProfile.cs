using AutoMapper;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;
using BloodDoner.Mvc.Services.Implementations;
using BloodDoner.Mvc.Utilities;

namespace BloodDoner.Mvc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BloodDonerEntity, BloodDonerListViewModel>()
                .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()))
                .ForMember(dest => dest.LastDonationDate, opt => opt.MapFrom(src => DateHelper.GetLastDonationDateString(src.LastDonationDate)))
                .ForMember(dest => dest.IsEligible, opt => opt.MapFrom(src => BloodDonerService.IsEligible(src)))
                .ForMember(dest => dest.Age, opt=>opt.MapFrom(src=> DateHelper.CalculateAge(src.DateofBirth)));
        }
    }
}
