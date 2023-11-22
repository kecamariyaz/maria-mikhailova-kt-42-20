using mariamikhailovakt_42_20.Database;
using mariamikhailovakt_42_20.Filters.StudentGroupFilters;
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
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "stuent_db")
            .Options;
        }

        [Fact]
        public async Task GetStudentsByGroupAsync_KT4220_OneObjects()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var group = new List<Group>
            {
                new Group
                {
                    GroupId =1,
                    GroupName = "КТ-31-20"
                },
                new Group
                {
                    GroupId =2,
                    GroupName = "КТ-44-18"
                }
            };
            await ctx.Set<Group>().AddRangeAsync(group);

            await ctx.SaveChangesAsync();

            var lesson = new List<Lessons>
            {
                new Lessons
                {
                    LessonsId =1,
                    LessonName = "история"
                },
                new Lessons
                {
                    LessonsId =2,
                    LessonName = "физика"
                }
            };
            await ctx.Set<Lessons>().AddRangeAsync(lesson);

            await ctx.SaveChangesAsync();

            var students = new List<Student>
            {
                new Student
                {
                    FirstName = "123",
                    LastName = "123",
                    MiddleName = "123",
                    GroupId = 1,
                    LessonsId = 2
                },
                new Student
                {
                    FirstName = "mem",
                    LastName = "mem",
                    MiddleName = "mem",
                    GroupId = 1,
                    LessonsId = 1
                },
                new Student
                {
                    FirstName = "mem1",
                    LastName = "mem1",
                    MiddleName = "mem1",
                    GroupId = 2,
                    LessonsId = 2
                }
            };
            await ctx.Set<Student>().AddRangeAsync(students);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new StudentGroupFilter
            {
                GroupName = "КТ-31-20"
            };
            var studentsResult = await studentService.GetStudentsByGroupAsync(filter, CancellationToken.None);

            Assert.Equal(2, studentsResult.Length);
        }
    }

}