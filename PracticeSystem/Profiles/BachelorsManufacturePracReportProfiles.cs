using AutoMapper;
using PracticeSystem.Dtos.BachelorsManufacturePracReportDto;

namespace PracticeSystem.Profiles
{
    public class BachelorsManufacturePracReportProfiles : Profile
    {
        public BachelorsManufacturePracReportProfiles()
        {
            CreateMap<Pracbptp, BachelorsManufacturePracReportReadDto>();
            CreateMap<BachelorsManufacturePracReportReadDto, Pracbptp>();
            CreateMap<BachelorsManufacturePracReportCreateDto, Pracbptp>();
            CreateMap<BachelorsManufacturePracReportUpdateDto, Pracbptp>();
            CreateMap<Pracbptp, BachelorsManufacturePracReportUpdateDto>();
        }
    }
}