using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application.Interface.IDynamicContext.AssessmentTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsScorable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interface.IDynamicContext.AssessmentTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserResponse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Application.Interface.IDynamicContext.AssessmentQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Questions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    AssessmentTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application.Interface.IDynamicContext.AssessmentQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application.Interface.IDynamicContext.AssessmentQuestions_Application.Interface.IDynamicContext.AssessmentTables_AssessmentT~",
                        column: x => x.AssessmentTableId,
                        principalTable: "Application.Interface.IDynamicContext.AssessmentTables",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientToAssessmentsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: false),
                    AssessmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssessmentTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientToAssessmentsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentsTable_Application.Interface.IDynamicContext.AssessmentTables_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Application.Interface.IDynamicContext.AssessmentTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentsTable_Application.Interface.IDynamicContext.AssessmentTables_AssessmentTableId",
                        column: x => x.AssessmentTableId,
                        principalTable: "Application.Interface.IDynamicContext.AssessmentTables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentsTable_PatientsTable_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientToAssessmentDetailsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientAssessmentId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientToAssessmentDetailsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentDetailsTable_Application.Interface.IDynamicContext.AssessmentQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Application.Interface.IDynamicContext.AssessmentQuestions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PatientToAssessmentDetailsTable_PatientToAssessmentsTable_PatientAssessmentId",
                        column: x => x.PatientAssessmentId,
                        principalTable: "PatientToAssessmentsTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interface.IDynamicContext.AssessmentQuestions_AssessmentTableId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                column: "AssessmentTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentDetailsTable_PatientAssessmentId",
                table: "PatientToAssessmentDetailsTable",
                column: "PatientAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentDetailsTable_QuestionId",
                table: "PatientToAssessmentDetailsTable",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentsTable_AssessmentId",
                table: "PatientToAssessmentsTable",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentsTable_AssessmentTableId",
                table: "PatientToAssessmentsTable",
                column: "AssessmentTableId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientToAssessmentsTable_PatientId",
                table: "PatientToAssessmentsTable",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientToAssessmentDetailsTable");

            migrationBuilder.DropTable(
                name: "QuestionResponses");

            migrationBuilder.DropTable(
                name: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.DropTable(
                name: "PatientToAssessmentsTable");

            migrationBuilder.DropTable(
                name: "Application.Interface.IDynamicContext.AssessmentTables");

            migrationBuilder.DropTable(
                name: "PatientsTable");
        }
    }
}
