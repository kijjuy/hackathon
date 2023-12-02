using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon.Data.Migrations
{
    public partial class addedPrefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrefFriend",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrefHousing",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrefStudy",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrefFriend",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrefHousing",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrefStudy",
                table: "AspNetUsers");
        }
    }
}
