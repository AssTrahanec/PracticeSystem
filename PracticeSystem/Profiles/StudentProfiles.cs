using AutoMapper;
using PracticeSystem.Dtos;
using PracticeSystem.Dtos.Student;
using PracticeSystem.Models;

namespace PracticeSystem.Profiles
{
    public class StudentProfiles : Profile
    {
        public StudentProfiles()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentReadDto, Student>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
    }
}