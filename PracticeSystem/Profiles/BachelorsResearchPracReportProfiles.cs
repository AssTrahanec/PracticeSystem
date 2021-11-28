using AutoMapper;
using PracticeSystem.Dtos.BachelorsResearchPracReportDto;

namespace PracticeSystem.Profiles
{
    public class BachelorsResearchPracReportProfiles : Profile
    {
        public BachelorsResearchPracReportProfiles()
        {
            CreateMap<Pracbynir, BachelorsResearchPracReportReadDto>();
            CreateMap<BachelorsResearchPracReportReadDto, Pracbynir>();
            CreateMap<BachelorsResearchPracReportCreateDto, Pracbynir>();
            CreateMap<BachelorsResearchPracReportUpdateDto, Pracbynir>();
            CreateMap<Pracbynir, BachelorsResearchPracReportUpdateDto>();
        }
    }
}