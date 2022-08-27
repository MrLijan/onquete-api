using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnqueteApi.Migrations
{
    public partial class UpdateSurveyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SurveyId",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_questions_SurveyId",
                table: "questions",
                column: "SurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_surveys_SurveyId",
                table: "questions",
                column: "SurveyId",
                principalTable: "surveys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_surveys_SurveyId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_SurveyId",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "SurveyId",
                table: "questions");
        }
    }
}
