using mariamikhailovakt_42_20.DataBase.Helpers;
using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace mariamikhailovakt_42_20.DataBase.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Индетификатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

            
            //group
            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Индетификатор группы")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_c_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_c_group_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();

            //lessons
            builder.Property(p => p.LessonsId)
                .HasColumnName("lesson_id")
                .HasComment("Индетификатор предмета")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Lessons)
                .WithMany()
                .HasForeignKey(p => p.LessonsId)
                .HasConstraintName("fk_c_lessons_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.LessonsId, $"idx_{TableName}_fk_c_lessons_id");

            //Добавим явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Lessons)
                .AutoInclude();
            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}