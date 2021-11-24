using AutoMapper;
using PracticeSystem.Dtos.PracticeHeadsDto;

namespace PracticeSystem.Profiles
{
    public class PracticeHeadProfiles : Profile
    {
        public PracticeHeadProfiles()
        {
            CreateMap<Phead, PracticeHeadReadDto>();
            CreateMap<PracticeHeadReadDto, Phead>();
            CreateMap<PracticeHeadCreateDto, Phead>();
            CreateMap<PracticeHeadUpdateDto, Phead>();
            CreateMap<Phead, PracticeHeadUpdateDto>();
        }
    }
}