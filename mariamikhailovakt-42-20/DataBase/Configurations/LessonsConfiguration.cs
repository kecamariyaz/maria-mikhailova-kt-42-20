using mariamikhailovakt_42_20.DataBase.Helpers;
using mariamikhailovakt_42_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mariamikhailovakt_42_20.DataBase.Configurations
{
    public class LessonsConfiguration : IEntityTypeConfiguration<Lessons>
    {
        private const string TableName = "cd_lessons";

        public void Configure(EntityTypeBuilder<Lessons> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.LessonsId)
                .HasName($"pk_{TableName}_lessons_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.LessonsId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.LessonsId)
                .HasColumnName("lesson_id")
                .HasComment("Идентификатор записи предмета");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.LessonName)
                .IsRequired()
                .HasColumnName("c_lessonname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");


        }
    }
}