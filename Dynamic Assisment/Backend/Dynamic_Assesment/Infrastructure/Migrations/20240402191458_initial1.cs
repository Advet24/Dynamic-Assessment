using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application.Interface.IDynamicContext.AssessmentQuestions_Application.Interface.IDynamicContext.AssessmentTables_AssessmentT~",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Application.Interface.IDynamicContext.AssessmentQuestions_AssessmentTableId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.DropColumn(
                name: "AssessmentTableId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Application.Interface.IDynamicContext.AssessmentTables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResponseType",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interface.IDynamicContext.AssessmentQuestions_AssessmentId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                column: "AssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application.Interface.IDynamicContext.AssessmentQuestions_Application.Interface.IDynamicContext.AssessmentTables_AssessmentId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                column: "AssessmentId",
                principalTable: "Application.Interface.IDynamicContext.AssessmentTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application.Interface.IDynamicContext.AssessmentQuestions_Application.Interface.IDynamicContext.AssessmentTables_AssessmentId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Application.Interface.IDynamicContext.AssessmentQuestions_AssessmentId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Application.Interface.IDynamicContext.AssessmentTables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseType",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AssessmentTableId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application.Interface.IDynamicContext.AssessmentQuestions_AssessmentTableId",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                column: "AssessmentTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application.Interface.IDynamicContext.AssessmentQuestions_Application.Interface.IDynamicContext.AssessmentTables_AssessmentT~",
                table: "Application.Interface.IDynamicContext.AssessmentQuestions",
                column: "AssessmentTableId",
                principalTable: "Application.Interface.IDynamicContext.AssessmentTables",
                principalColumn: "Id");
        }
    }
}
