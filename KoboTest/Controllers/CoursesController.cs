using AutoMapper;
using KoboTest.Dtos;
using KoboTest.Interfaces;
using KoboTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoboTest.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private IRepository<Course> courseRepo;
        private readonly IMapper mapper;
        public CoursesController(IRepository<Course> courseRepo, IMapper mapper)
        {
            this.courseRepo = courseRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await courseRepo.GetAll();
            var dto = mapper.Map<List<CourseDto>>(courses);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await courseRepo.Get(id);
            var dto = mapper.Map<CourseDto>(course);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseDto addCourseDto)
        {
            var course = mapper.Map<Course>(addCourseDto);
            var created = await courseRepo.Insert(course);
            var courseDto = mapper.Map<CourseDto>(created);
            return Ok(courseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await courseRepo.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCourse(int id, [FromBody] EditCourseDto editCourseDto)
        {
            Course course = await courseRepo.Get(id);
            course.Code = string.IsNullOrEmpty(editCourseDto.Code) ? course.Code : editCourseDto.Code;
            course.Title = string.IsNullOrEmpty(editCourseDto.Title) ? course.Title : editCourseDto.Title;
            var updated = await courseRepo.Update(course);
            var courseDto = mapper.Map<CourseDto>(updated);
            return Ok(courseDto);
        }
    }
}
