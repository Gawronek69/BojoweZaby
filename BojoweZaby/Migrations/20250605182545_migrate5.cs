using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BojoweZaby.Migrations
{
    /// <inheritdoc />
    public partial class migrate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxHp",
                table: "FrogModel",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxHp",
                table: "FrogModel");
        }
    }
}
