using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnqueteApi.Migrations
{
    public partial class SeedQuestionTypes : Migration
    {
        protected readonly string tableName = "question_types";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] questionTypes = {
                "select",
                "multiple",
                "short",
                "paragraph"
            };

            migrationBuilder.InsertData(this.tableName, "Name", questionTypes);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM {this.tableName}");
        }
    }
}
