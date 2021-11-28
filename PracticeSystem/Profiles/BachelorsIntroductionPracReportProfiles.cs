using AutoMapper;
using PracticeSystem.Dtos.BachelorsIntroductionPracReportDto;

namespace PracticeSystem.Profiles
{
    public class BachelorsIntroductionPracReportProfiles : Profile
    {
        public BachelorsIntroductionPracReportProfiles()
        {
            CreateMap<Pracbyop, BachelorsIntroductionPracReportReadDto>();
            CreateMap<BachelorsIntroductionPracReportReadDto, Pracbyop>();
            CreateMap<BachelorsIntroductionPracReportCreateDto, Pracbyop>();
            CreateMap<BachelorsIntroductionPracReportUpdateDto, Pracbyop>();
            CreateMap<Pracbyop, BachelorsIntroductionPracReportUpdateDto>();
        }
    }
}