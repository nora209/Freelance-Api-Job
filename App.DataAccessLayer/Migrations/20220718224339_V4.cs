using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.DataAccessLayer.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Issuepatient",
                columns: table => new
                {
                    IssuesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuepatient", x => new { x.IssuesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_Issuepatient_issues_IssuesId",
                        column: x => x.IssuesId,
                        principalTable: "issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Issuepatient_patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issuepatient_PatientsId",
                table: "Issuepatient",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issuepatient");

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
                    IssuesId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
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
    }
}
