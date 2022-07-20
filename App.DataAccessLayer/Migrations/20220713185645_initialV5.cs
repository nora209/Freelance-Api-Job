using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DataAccessLayer.Migrations
{
    public partial class initialV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientIssuesId",
                table: "patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientIssuesId",
                table: "issues",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PatientIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IssuesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientIssues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_PatientIssuesId",
                table: "patients",
                column: "PatientIssuesId");

            migrationBuilder.CreateIndex(
                name: "IX_issues_PatientIssuesId",
                table: "issues",
                column: "PatientIssuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_issues_PatientIssues_PatientIssuesId",
                table: "issues",
                column: "PatientIssuesId",
                principalTable: "PatientIssues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_PatientIssues_PatientIssuesId",
                table: "patients",
                column: "PatientIssuesId",
                principalTable: "PatientIssues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_issues_PatientIssues_PatientIssuesId",
                table: "issues");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_PatientIssues_PatientIssuesId",
                table: "patients");

            migrationBuilder.DropTable(
                name: "PatientIssues");

            migrationBuilder.DropIndex(
                name: "IX_patients_PatientIssuesId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_issues_PatientIssuesId",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "PatientIssuesId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "PatientIssuesId",
                table: "issues");
        }
    }
}
