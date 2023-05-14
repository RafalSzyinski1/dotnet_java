using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab4.Migrations
{
    public partial class mg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Beer",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Beer",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Alchool",
                table: "Beer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alchool",
                table: "Beer");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Beer",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Beer",
                newName: "Name");
        }
    }
}
