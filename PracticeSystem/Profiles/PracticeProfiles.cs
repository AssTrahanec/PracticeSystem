using AutoMapper;
using PracticeSystem.Dtos.PracticeDto;
using PracticeSystem.Models;

namespace PracticeSystem.Profiles
{
    public class PracticeProfiles : Profile
    {
        public PracticeProfiles()
        {
            CreateMap<Practice, PracticeReadDto>();
            CreateMap<PracticeReadDto, Practice>();
            CreateMap<PracticeCreateDto, Practice>();
            CreateMap<PracticeUpdateDto, Practice>();
            CreateMap<Practice, PracticeUpdateDto>();
        }
    }
}