using AutoMapper;
using PracticeSystem.Dtos.Group;
using PracticeSystem.Models;

namespace PracticeSystem.Profiles
{
    public class GroupProfiles : Profile
    {
        public GroupProfiles()
        {
            CreateMap<Group, GroupReadDto>();
            CreateMap<GroupReadDto, Group>();
            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupUpdateDto, Group>();
            CreateMap<Group, GroupUpdateDto>();
        }
    }
}