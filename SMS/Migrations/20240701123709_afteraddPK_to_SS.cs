using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Migrations
{
    /// <inheritdoc />
    public partial class afteraddPK_to_SS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Student_Subjects_StudentID",
                table: "Student_Subjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student_Subjects",
                table: "Student_Subjects",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student_Subjects",
                table: "Student_Subjects");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Subjects_StudentID",
                table: "Student_Subjects",
                column: "StudentID");
        }
    }
}
