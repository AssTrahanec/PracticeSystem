using AutoMapper;
using PracticeSystem.Dtos.PracticeDiaryDto;

namespace PracticeSystem.Profiles
{
    public class PracticeDiaryProfiles : Profile
    {
        public PracticeDiaryProfiles() 
        {
            CreateMap<Pd, PracticeDiaryReadDto>();
            CreateMap<PracticeDiaryReadDto, Pd>();
            CreateMap<PracticeDiaryCreateDto, Pd>();
            CreateMap<PracticeDiaryUpdateDto, Pd>();
            CreateMap<Pd, PracticeDiaryUpdateDto>();
        }
    }
}