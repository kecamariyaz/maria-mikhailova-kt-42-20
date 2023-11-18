using mariamikhailovakt_42_20.Database;
using mariamikhailovakt_42_20.Filters.PrepodDegreeFilters;
using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;

namespace mariamikhailovakt_42_20.Interfaces
{
    
    public interface ILessonsService
    {
        public Task<Student[]> GetStudentsByLessonAsync(StudentLessonFilter filter, CancellationToken cancellationToken);
    }

    public class LessonService : ILessonsService
    {
        private readonly StudentDbContext _dbContext;
        public LessonService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByLessonAsync(StudentLessonFilter filter, CancellationToken cancellationToken = default)
        {
            var lessons = _dbContext.Set<Student>().Where(w => w.Lessons.LessonName == filter.LessonName).ToArrayAsync(cancellationToken);

            return lessons;
        }
    }
}