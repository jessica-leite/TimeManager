using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeManager.Migrations
{
    public partial class answerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecretAnswer",
                table: "User",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecretAnswer",
                table: "User");
        }
    }
}
