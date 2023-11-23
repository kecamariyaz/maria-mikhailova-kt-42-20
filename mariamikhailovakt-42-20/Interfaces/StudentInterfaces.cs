using mariamikhailovakt_42_20.Database;
using mariamikhailovakt_42_20.Filters.StudentGroupFilters;
using mariamikhailovakt_42_20.Filters;
using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;


namespace mariamikhailovakt_42_20.Interfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var student = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return student;
        }
        public Task<Student[]> GetStudentsByFIOAsync(StudentFIOFilter filter, CancellationToken cancellationToken = default)
        {
            var student = _dbContext.Set<Student>().Where(w => (w.FirstName== filter.FirstName)|| (w.LastName == filter.LastName)|| (w.MiddleName == filter.MiddleName)).ToArrayAsync(cancellationToken);

            return student;
        }

    }
}