using AutoMapper;
using PracticeSystem.Dtos.BachelorsPredegreePracReportDto;

namespace PracticeSystem.Profiles
{
    public class BachelorsPredegreePracReportProfiles : Profile
    {
        public BachelorsPredegreePracReportProfiles()
        {
            CreateMap<Pracbpdp, BachelorsPredegreePracReportReadDto>();
            CreateMap<BachelorsPredegreePracReportReadDto, Pracbpdp>();
            CreateMap<BachelorsPredegreePracReportCreateDto, Pracbpdp>();
            CreateMap<BachelorsPredegreePracReportUpdateDto, Pracbpdp>();
            CreateMap<Pracbpdp, BachelorsPredegreePracReportUpdateDto>();
        }
    }
}