using AutoMapper;
using PracticeSystem.Dtos.MastersIntroductionPracReportDto;

namespace PracticeSystem.Profiles
{
    public class MastersIntroductionPracReportProfiles : Profile
    {
        public MastersIntroductionPracReportProfiles()
        {
            CreateMap<Pracmyop, MastersIntroductionPracReportReadDto>();
            CreateMap<MastersIntroductionPracReportReadDto, Pracmyop>();
            CreateMap<MastersIntroductionPracReportCreateDto, Pracmyop>();
            CreateMap<MastersIntroductionPracReportUpdateDto, Pracmyop>();
            CreateMap<Pracmyop, MastersIntroductionPracReportUpdateDto>();
        }
    }
}