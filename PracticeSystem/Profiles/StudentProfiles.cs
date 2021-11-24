using AutoMapper;
using PracticeSystem.Dtos;
using PracticeSystem.Dtos.Student;

namespace PracticeSystem.Profiles
{
    public class StudentProfiles : Profile
    {
        public StudentProfiles()
        {
            CreateMap<Stud, StudentReadDto>();
            CreateMap<StudentReadDto, Stud>();
            CreateMap<StudentCreateDto, Stud>();
            CreateMap<StudentUpdateDto, Stud>();
            CreateMap<Stud, StudentUpdateDto>();
        }
    }
}