using AutoMapper;
using DataAcesss.Data;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;

namespace DataAcesss.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Match, MatchVM>().ReverseMap();
            CreateMap<Bet, BetVM>().ReverseMap();
            CreateMap<CountryBet, CountryBetVM>().ReverseMap();
            CreateMap<Country, CountryBetVM>().ReverseMap();
            CreateMap<Country, ManageCountriesVM>().ReverseMap();
            CreateMap<ApplicationUser, UsersOverviewVM>().ReverseMap();
            CreateMap<Clan, ClanDropDown>().ReverseMap();
            CreateMap<IdentityRole, UserRoleDropDown>().ReverseMap();
        }
    }
}
