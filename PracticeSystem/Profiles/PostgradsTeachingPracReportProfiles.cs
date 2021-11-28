using AutoMapper;
using PracticeSystem.Dtos.PostgradsTeachingPracReportDto;

namespace PracticeSystem.Profiles
{
    public class PostgradsTeachingPracReportProfiles : Profile
    {
        public PostgradsTeachingPracReportProfiles()
        {
            CreateMap<Pracapp, PostgradsTeachingPracReportReadDto>();
            CreateMap<PostgradsTeachingPracReportReadDto, Pracapp>();
            CreateMap<PostgradsTeachingPracReportCreateDto, Pracapp>();
            CreateMap<PostgradsTeachingPracReportUpdateDto, Pracapp>();
            CreateMap<Pracapp, PostgradsTeachingPracReportUpdateDto>();
        }
    }
}