using AutoMapper;
using PracticeSystem.Dtos.PracticeDto;

namespace PracticeSystem.Profiles
{
    public class PracticeProfiles : Profile
    {
        public PracticeProfiles()
        {
            CreateMap<Prac, PracticeReadDto>();
            CreateMap<PracticeReadDto, Prac>();
            CreateMap<PracticeCreateDto, Prac>();
            CreateMap<PracticeUpdateDto, Prac>();
            CreateMap<Prac, PracticeUpdateDto>();
        }
    }
}