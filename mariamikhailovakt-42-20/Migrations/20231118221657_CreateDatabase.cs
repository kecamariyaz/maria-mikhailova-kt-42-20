using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mariamikhailovakt_42_20.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    Идентификаторзаписигруппы = table.Column<int>(name: "Идентификатор записи группы", type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Названиегруппы = table.Column<string>(name: "Название группы", type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.Идентификаторзаписигруппы);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    lesson_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_lessonname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_lessons_lessons_id", x => x.lesson_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Индетификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    group_id = table.Column<int>(type: "int4", nullable: false, comment: "Индетификатор группы"),
                    lesson_id = table.Column<int>(type: "int4", nullable: false, comment: "Индетификатор предмета")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_c_group_id",
                        column: x => x.group_id,
                        principalTable: "cd_group",
                        principalColumn: "Идентификатор записи группы",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_c_lessons_id",
                        column: x => x.lesson_id,
                        principalTable: "Lessons",
                        principalColumn: "lesson_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_c_group_id",
                table: "cd_student",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_c_lessons_id",
                table: "cd_student",
                column: "lesson_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");

            migrationBuilder.DropTable(
                name: "Lessons");
        }
    }
}
