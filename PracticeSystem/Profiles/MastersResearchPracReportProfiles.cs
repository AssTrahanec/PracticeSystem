using AutoMapper;
using PracticeSystem.Dtos.MastersResearchPracReportDto;

namespace PracticeSystem.Profiles
{
    public class MastersResearchPracReportProfiles : Profile
    {
        public MastersResearchPracReportProfiles()
        {
            CreateMap<Pracmpnir, MastersResearchPracReportReadDto>();
            CreateMap<MastersResearchPracReportReadDto, Pracmpnir>();
            CreateMap<MastersResearchPracReportCreateDto, Pracmpnir>();
            CreateMap<MastersResearchPracReportUpdateDto, Pracmpnir>();
            CreateMap<Pracmpnir, MastersResearchPracReportUpdateDto>();
        }
    }
}