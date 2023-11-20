using mariamikhailovakt_42_20.Database;
using mariamikhailovakt_42_20.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mariamikhailovakt_42_20.Filters.StudentLessonFilters;
using mariamikhailovakt_42_20.Interfaces;


namespace mariamikhailovakt_42_20.Controllers
{
    [ApiController]
    [Route("controller")]

    public class LessonsController : Controller
    {
        private readonly ILogger<LessonsController> _logger;
        private readonly ILessonsService _lessonsService;
        private StudentDbContext _context;

        public LessonsController(ILogger<LessonsController> logger, ILessonsService lessonService, StudentDbContext context)
        {
            _logger = logger;
            _lessonsService = lessonService;
            _context = context;
        }

        [HttpPost(Name = "GetStudentsByLesson")]
        public async Task<IActionResult> GetStudentsByLessonAsync(StudentLessonFilter filter, CancellationToken cancellationToken = default)
        {
            var lessons = await _lessonsService.GetStudentsByLessonAsync(filter, cancellationToken);

            return Ok(lessons);
        }

        [HttpPost("AddLesson", Name = "AddLesson")]
        public IActionResult CreateLesson([FromBody] Lessons lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return Ok(lesson);
        }

        [HttpPut("EditLesson")]
        public IActionResult UpdateLesson(string lessonname, [FromBody] Lessons updatedLesson)
        {
            var existingLesson = _context.Lessons.FirstOrDefault(g => g.LessonName == lessonname);

            if (existingLesson == null)
            {
                return NotFound();
            }

            existingLesson.LessonName = updatedLesson.LessonName;
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("DeleteLesson")]
        public IActionResult DeleteLesson(string lessonname, Lessons updatedLesson)
        {
            var existingLesson = _context.Lessons.FirstOrDefault(g => g.LessonName == lessonname);

            if (existingLesson == null)
            {
                return NotFound();
            }
            _context.Lessons.Remove(existingLesson);
            _context.SaveChanges();

            return Ok();
        }
    }
}
