using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace habitos_web_app.Migrations
{
    public partial class CreateHabitType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HabitTypeId",
                table: "Habit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Habit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HabitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habit_HabitTypeId",
                table: "Habit",
                column: "HabitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habit_HabitType_HabitTypeId",
                table: "Habit",
                column: "HabitTypeId",
                principalTable: "HabitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habit_HabitType_HabitTypeId",
                table: "Habit");

            migrationBuilder.DropTable(
                name: "HabitType");

            migrationBuilder.DropIndex(
                name: "IX_Habit_HabitTypeId",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "HabitTypeId",
                table: "Habit");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Habit");
        }
    }
}
