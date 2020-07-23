using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieRentalRazor.Migrations
{
    public partial class AddYearToFilmModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Film",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Film");
        }
    }
}
