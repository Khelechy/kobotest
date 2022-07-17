using AutoMapper;
using KoboTest.Dtos;
using KoboTest.Interfaces;
using KoboTest.Models;
using KoboTest.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KoboTest.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        private readonly IStudentCourseRepository studentCourseRepo; 
        private IRepository<Course> courseRepo;
        private readonly IMapper mapper;
        public StudentsController(IStudentRepository studentRepository, IRepository<Course> courseRepo, IStudentCourseRepository studentCourseRepo, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.studentCourseRepo = studentCourseRepo;
            this.courseRepo = courseRepo;   
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetAll();
            var dto = mapper.Map<List<StudentDto>>(students);
            return Ok(dto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await studentRepository.Get(id);
            var dto = mapper.Map<StudentDto>(student);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentDto addStudentDto)
        {
            var student = mapper.Map<Student>(addStudentDto);
            var created = await studentRepository.Insert(student);
            var studentDto = mapper.Map<StudentDto>(created);  
            return Ok(studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await studentRepository.SoftDelete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditStudent(int id, [FromBody] EditStudentDto editStudentDto)
        {
            Student student = await studentRepository.Get(id);
            student.FirstName = string.IsNullOrEmpty(editStudentDto.FirstName) ? student.FirstName : editStudentDto.FirstName;
            student.LastName = string.IsNullOrEmpty(editStudentDto.LastName) ? student.LastName : editStudentDto.LastName;
            var updated = await studentRepository.Update(student);
            var studentDto = mapper.Map<StudentDto>(updated);
            return Ok(studentDto);
        }

        [HttpPost("{id}/add-course")]
        public async Task<IActionResult> AddCourse(int id, [FromBody] AddStudentCourseDto addStudentCourseDto)
        {
            var course = await courseRepo.Get(addStudentCourseDto.CourseId);
            if (course == null)
                return BadRequest();
            var studentCourses = await studentCourseRepo.GetStudentCourses(id);
            if(studentCourses.Count() == 3)
            {
                return BadRequest("Student already has 3 courses");
            }



            if(studentCourses.Any(x => x.CourseId == addStudentCourseDto.CourseId))
            {
                return BadRequest("Student already has course with this id");
            }
            StudentCourse studentCourse = new StudentCourse();
            studentCourse.CourseId = addStudentCourseDto.CourseId;
            studentCourse.StudentId = id;
            var entry = await studentCourseRepo.Insert(studentCourse);
            return Ok(entry);
        }

        [HttpPost("{id}/remove-course")]
        public async Task<IActionResult> RemoveCourse(int id, [FromBody] RemoveStudentCourseDto removeStudentCourseDto)
        {
            var course = await courseRepo.Get(removeStudentCourseDto.CourseId);
            if (course == null)
                return BadRequest();
            var studentCourse = await studentCourseRepo.GetStudentByCourseId(id, removeStudentCourseDto.CourseId);
            if(studentCourse == null)
            {
                return BadRequest("Student doesnt have course with this courseId");
            }
            await studentCourseRepo.HardDelete(studentCourse.Id);
            return Ok();
        }
    }
}
