using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BojoweZaby.Migrations
{
    /// <inheritdoc />
    public partial class migrate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "ItemModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "FrogModel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "ItemModel");

            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "FrogModel");
        }
    }
}
