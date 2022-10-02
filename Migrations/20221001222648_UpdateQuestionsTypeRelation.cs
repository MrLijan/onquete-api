using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnqueteApi.Migrations
{
    public partial class UpdateQuestionsTypeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionTypeId",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTypeId",
                table: "questions");
        }
    }
}
