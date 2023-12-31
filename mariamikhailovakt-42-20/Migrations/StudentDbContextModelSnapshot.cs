﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mariamikhailovakt_42_20.Database;

#nullable disable

namespace mariamikhailovakt_42_20.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    partial class StudentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("mariamikhailovakt_42_20.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("Идентификатор записи группы")
                        .HasComment("Идентификатор записи группы");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Название группы")
                        .HasComment("Название группы");

                    b.HasKey("GroupId")
                        .HasName("pk_cd_group_group_id");

                    b.ToTable("cd_group", (string)null);
                });

            modelBuilder.Entity("mariamikhailovakt_42_20.Models.Lessons", b =>
                {
                    b.Property<int>("LessonsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("lesson_id")
                        .HasComment("Идентификатор записи предмета");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonsId"));

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_lessonname")
                        .HasComment("Название предмета");

                    b.HasKey("LessonsId")
                        .HasName("pk_cd_lessons_lessons_id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("mariamikhailovakt_42_20.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("student_id")
                        .HasComment("Индетификатор записи студента");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_firstname")
                        .HasComment("Имя студента");

                    b.Property<int>("GroupId")
                        .HasColumnType("int4")
                        .HasColumnName("group_id")
                        .HasComment("Индетификатор группы");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_lastname")
                        .HasComment("Фамилия студента");

                    b.Property<int>("LessonsId")
                        .HasColumnType("int4")
                        .HasColumnName("lesson_id")
                        .HasComment("Индетификатор предмета");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_student_middlename")
                        .HasComment("Отчество студента");

                    b.HasKey("StudentId")
                        .HasName("pk_cd_student_student_id");

                    b.HasIndex(new[] { "GroupId" }, "idx_cd_student_fk_c_group_id");

                    b.HasIndex(new[] { "LessonsId" }, "idx_cd_student_fk_c_lessons_id");

                    b.ToTable("cd_student", (string)null);
                });

            modelBuilder.Entity("mariamikhailovakt_42_20.Models.Student", b =>
                {
                    b.HasOne("mariamikhailovakt_42_20.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_c_group_id");

                    b.HasOne("mariamikhailovakt_42_20.Models.Lessons", "Lessons")
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_c_lessons_id");

                    b.Navigation("Group");

                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
