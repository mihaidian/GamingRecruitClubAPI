using AutoMapper;
using GamingRecruitClubAPI.DTOs;
using GamingRecruitClubAPI.DTOs.CreateUpdatedInfos;

namespace FirstAPIApp
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<DevInfoDTO, DevInfoUpdate>().ReverseMap();
            CreateMap<GameInfoDTO, GameInfoUpdate>().ReverseMap();
            CreateMap<TesterInfoDTO, TesterInfoUpdate>().ReverseMap();
            CreateMap<CompanyInfoDTO, CompanyInfoUpdate>().ReverseMap();
        }
        
    }
}
