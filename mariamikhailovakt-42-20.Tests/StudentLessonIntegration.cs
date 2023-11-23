using mariamikhailovakt_42_20.Database;
using mariamikhailovakt_42_20.Filters.StudentLessonFilters;
using mariamikhailovakt_42_20.Interfaces;
using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mariamikhailovakt_42_20.Tests
{
    public class StudentLessonIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentLessonIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByLessonAsync_KT4220_TwoObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var lessonService = new LessonService(ctx);



            await ctx.SaveChangesAsync();

            // Act
            var filter = new StudentLessonFilter
            {
                LessonName = "физика"
            };
            var studentsResult = await lessonService.GetStudentsByLessonAsync(filter, CancellationToken.None);

            Assert.Equal(2, studentsResult.Length);
        }
    }
}