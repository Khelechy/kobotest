using AutoMapper;
using KoboTest.Dtos;
using KoboTest.Models;

namespace KoboTest.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<AddStudentDto, Student>();
            CreateMap<Student, StudentDto>();   
        }
    }
}
