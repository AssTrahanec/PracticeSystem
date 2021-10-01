using AutoMapper;
using PracticeSystem.Dtos.PracticeHeadsDto;
using PracticeSystem.Models;

namespace PracticeSystem.Profiles
{
    public class PracticeHeadProfiles : Profile
    {
        public PracticeHeadProfiles()
        {
            CreateMap<PracticeHead, PracticeHeadReadDto>();
            CreateMap<PracticeHeadReadDto, PracticeHead>();
            CreateMap<PracticeHeadCreateDto, PracticeHead>();
            CreateMap<PracticeHeadUpdateDto, PracticeHead>();
            CreateMap<PracticeHead, PracticeHeadUpdateDto>();
        }
    }
}