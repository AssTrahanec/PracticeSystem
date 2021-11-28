using AutoMapper;
using PracticeSystem.Dtos.MastersManufacturePracReportDto;

namespace PracticeSystem.Profiles
{
    public class MastersManufacturePracReportProfiles : Profile
    {
        public MastersManufacturePracReportProfiles()
        {
            CreateMap<Pracmptp, MastersManufacturePracReportReadDto>();
            CreateMap<MastersManufacturePracReportReadDto, Pracmptp>();
            CreateMap<MastersManufacturePracReportCreateDto, Pracmptp>();
            CreateMap<MastersManufacturePracReportUpdateDto, Pracmptp>();
            CreateMap<Pracmptp, MastersManufacturePracReportUpdateDto>();
        }
    }
}