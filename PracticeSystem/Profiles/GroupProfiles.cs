using AutoMapper;
using PracticeSystem.Dtos.Group;

namespace PracticeSystem.Profiles
{
    public class GroupProfiles : Profile
    {
        public GroupProfiles()
        {
            CreateMap<Groupp, GroupReadDto>();
            CreateMap<GroupReadDto, Groupp>();
            CreateMap<GroupCreateDto, Groupp>();
            CreateMap<GroupUpdateDto, Groupp>();
            CreateMap<Groupp, GroupUpdateDto>();
        }
    }
}