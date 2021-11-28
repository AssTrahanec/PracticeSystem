using AutoMapper;
using PracticeSystem.Dtos.PostgradsInvestigationReportDto;

namespace PracticeSystem.Profiles
{
    public class PostgradsInvestigationReportProfiles : Profile
    {
        public PostgradsInvestigationReportProfiles()
        {
            CreateMap<Pracani, PostgradsInvestigationReportReadDto>();
            CreateMap<PostgradsInvestigationReportReadDto, Pracani>();
            CreateMap<PostgradsInvestigationReportCreateDto, Pracani>();
            CreateMap<PostgradsInvestigationReportUpdateDto, Pracani>();
            CreateMap<Pracani, PostgradsInvestigationReportUpdateDto>();
        }
    }
}