using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using mariamikhailovakt_42_20.DataBase.Configurations;
using mariamikhailovakt_42_20.DataBase.Configuration;

namespace mariamikhailovakt_42_20.Database
{
    public class StudentDbContext : DbContext
    {
        //Добавляем таблицы
        public DbSet<Group> Group{ get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Lessons> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new LessonsConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}