using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class addTableAttendence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rank",
                columns: table => new
                {
                    studentid = table.Column<int>(type: "int", nullable: false),
                    classid = table.Column<int>(type: "int", nullable: false),
                    subjectid = table.Column<int>(type: "int", nullable: false),
                    marks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__rank__43ED70A705E1F5DA", x => new { x.studentid, x.classid, x.subjectid });
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Subject_Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SUBJECTS__AC1BA388ED887B27", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Teacher__EDF259440C5089D7", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    class_teacher_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class__CB1927A0D4362CD3", x => x.ClassID);
                    table.ForeignKey(
                        name: "Class_classTeacherID_FK",
                        column: x => x.class_teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Roll_No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Total_marks = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Student__28B6682D56D2E57C", x => x.Roll_No);
                    table.ForeignKey(
                        name: "Student_ClassID_FK",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ClassID");
                });

            migrationBuilder.CreateTable(
                name: "Attendence",
                columns: table => new
                {
                    Student_id = table.Column<int>(type: "int", nullable: false),
                    attendence = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attenden__2A33069A8E01A867", x => x.Student_id);
                    table.ForeignKey(
                        name: "FK_Attendence_Student_Student_id",
                        column: x => x.Student_id,
                        principalTable: "Student",
                        principalColumn: "Roll_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student_Subjects",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "StudentSubjects_StudentID_FK",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Roll_No");
                    table.ForeignKey(
                        name: "StudentSubjects_SubjectID_FK",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateTable(
                name: "Subject_Marks",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "SubjectMarks_StudentID_FK",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Roll_No");
                    table.ForeignKey(
                        name: "SubjectMarks_SubjectID_FK",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Class_class_teacher_id",
                table: "Class",
                column: "class_teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassID",
                table: "Student",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Subjects_StudentID",
                table: "Student_Subjects",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Subjects_SubjectID",
                table: "Student_Subjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Marks_StudentID",
                table: "Subject_Marks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Marks_SubjectID",
                table: "Subject_Marks",
                column: "SubjectID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendence");

            migrationBuilder.DropTable(
                name: "rank");

            migrationBuilder.DropTable(
                name: "Student_Subjects");

            migrationBuilder.DropTable(
                name: "Subject_Marks");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
