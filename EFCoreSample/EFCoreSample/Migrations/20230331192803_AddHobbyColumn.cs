using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreSample.Migrations
{
    /// <inheritdoc />
    public partial class AddHobbyColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hobby",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hobby",
                table: "Users");
        }
    }
}
