using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mariamikhailovakt_42_20.Filters.StudentGroupFilters;
using mariamikhailovakt_42_20.Database;
using Microsoft.EntityFrameworkCore;
using mariamikhailovakt_42_20.Models;
using mariamikhailovakt_42_20.Interfaces;

namespace mariamikhailovakt_42_20.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;
        private StudentDbContext _context;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService, StudentDbContext context)
        {
            _logger = logger;
            _studentService = studentService;
            _context = context;
        }

        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var student = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(student);
        }
        //добавление для студентов
        [HttpPost("AddStudent", Name = "AddStudent")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Student.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        [HttpPut("EditStudent")]
        public IActionResult UpdateStudent(string firstname, [FromBody] Student updatedStudent)
        {
            var existingStudent = _context.Student.FirstOrDefault(g => g.FirstName == firstname);

            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.MiddleName = updatedStudent.MiddleName;
            existingStudent.GroupId = updatedStudent.GroupId;
            existingStudent.LessonsId = updatedStudent.LessonsId;
            _context.SaveChanges();

            return Ok();
        }
        //добавление для группы
        [HttpPost("AddGroup", Name = "AddGroup")]
        public IActionResult CreateGroup([FromBody] mariamikhailovakt_42_20.Models.Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Group.Add(group);
            _context.SaveChanges();
            return Ok(group);
        }

        [HttpPut("EditGroup")]
        public IActionResult UpdateGroup(string groupname, [FromBody] Group updatedGroup)
        {
            var existingGroup = _context.Group.FirstOrDefault(g => g.GroupName == groupname);

            if (existingGroup == null)
            {
                return NotFound();
            }

            existingGroup.GroupName = updatedGroup.GroupName;
            _context.SaveChanges();

            return Ok();
        }
        //удаление для группы
        [HttpDelete("DeleteGroup")]
        public IActionResult DeleteGroup(string groupName, mariamikhailovakt_42_20.Models.Group updatedGroup)
        {
            var existingGroup = _context.Group.FirstOrDefault(g => g.GroupName == groupName);

            if (existingGroup == null)
            {
                return NotFound();
            }
            _context.Group.Remove(existingGroup);
            _context.SaveChanges();

            return Ok();
        }
    }
}