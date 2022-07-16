using AutoMapper;
using KoboTest.Dtos;
using KoboTest.Models;

namespace KoboTest.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {

            CreateMap<AddCourseDto, Course>();
            CreateMap<Course, CourseDto>();
        }
    }
}
