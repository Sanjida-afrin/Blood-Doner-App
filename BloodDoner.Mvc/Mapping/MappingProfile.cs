using AutoMapper;
using BloodDoner.Mvc.Models.Entities;
using BloodDoner.Mvc.Models.ViewModel;
using BloodDoner.Mvc.Services.Implementations;
using BloodDoner.Mvc.Utilities;
using System.Linq;

namespace BloodDoner.Mvc.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Donation, DonationListViewModel>()
                .ForMember(dest => dest.Campaign, opt => opt.MapFrom(src => src.Campaign.Title))
                .ForMember(dest => dest.DonerName, opt => opt.MapFrom(src => src.BloodDoner.FullName));

            CreateMap<CampaignEntity, CampaignListViewModel>()
                .ForMember(dest => dest.DonerCount, opt => opt.Ignore());

            CreateMap<BloodDonerEntity, BloodDonerListViewModel>()
                .ForMember(dest => dest.BloodGroup, opt => opt.MapFrom(src => src.BloodGroup.ToString()))
                .ForMember(dest => dest.Donations, opt => opt.MapFrom(src => src.Donations.Count))
                .ForMember(dest => dest.Campaigns, opt => opt.MapFrom(src => src.DonerCampaigns.Select(dc => dc.Campaign)))
                .ForMember(dest => dest.LastDonationDate, opt => opt.MapFrom(src => DateHelper.GetLastDonationDateString(src.LastDonationDate)))
                .ForMember(dest => dest.IsEligible, opt => opt.MapFrom(src => BloodDonerService.IsEligible(src)))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateHelper.CalculateAge(src.DateofBirth)));

            CreateMap<BloodDonerCreateViewModel, BloodDonerEntity>();

            CreateMap<BloodDonerEditViewModel, BloodDonerEntity>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.Ignore());

            CreateMap<BloodDonerEntity, BloodDonerEditViewModel>()
                .ForMember(dest => dest.ProfilePicture, opt => opt.Ignore())
                .ForMember(dest => dest.ExistingProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture));
        }
    }
}
