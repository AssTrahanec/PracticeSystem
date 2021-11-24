using AutoMapper;
using PracticeSystem.Dtos.PracticeReferalDto;

namespace PracticeSystem.Profiles
{
    public class PracticeReferalProfiles : Profile
    {
        public PracticeReferalProfiles()
        {
            CreateMap<Preferal, PracticeReferalReadDto>();
            CreateMap<PracticeReferalReadDto, Preferal>();
            CreateMap<PracticeReferalCreateDto, Preferal>();
            CreateMap<PracticeReferalUpdateDto, Preferal>();
            CreateMap<Preferal, PracticeReferalUpdateDto>();
        }
    }
}