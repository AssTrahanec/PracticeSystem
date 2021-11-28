using AutoMapper;
using PracticeSystem.Dtos.PostgradsResearchPracReportDto;

namespace PracticeSystem.Profiles
{
    public class PostgradsResearchPracReportProfiles : Profile
    {
        public PostgradsResearchPracReportProfiles()
        {
            CreateMap<Pracanip, PostgradsResearchPracReportReadDto>();
            CreateMap<PostgradsResearchPracReportReadDto, Pracanip>();
            CreateMap<PostgradsResearchPracReportCreateDto, Pracanip>();
            CreateMap<PostgradsResearchPracReportUpdateDto, Pracanip>();
            CreateMap<Pracanip, PostgradsResearchPracReportUpdateDto>();
        }
    }
}