using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeManager.Migrations
{
    public partial class CompletionTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedHours",
                table: "Activity");

            migrationBuilder.CreateTable(
                name: "CompletionTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    ActivityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletionTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompletionTime_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompletionTime_ActivityId",
                table: "CompletionTime",
                column: "ActivityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompletionTime");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CompletedHours",
                table: "Activity",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
