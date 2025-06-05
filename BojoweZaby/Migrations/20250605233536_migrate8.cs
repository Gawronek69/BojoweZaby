using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BojoweZaby.Migrations
{
    /// <inheritdoc />
    public partial class migrate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account1Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account2Id",
                table: "Fights");

            migrationBuilder.DropIndex(
                name: "IX_Fights_Account1Id",
                table: "Fights");

            migrationBuilder.DropIndex(
                name: "IX_Fights_Account2Id",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "Account1Id",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "Account2Id",
                table: "Fights");

            migrationBuilder.DropColumn(
                name: "WinnerId",
                table: "Fights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Account1Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Account2Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WinnerId",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Account1Id",
                table: "Fights",
                column: "Account1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Account2Id",
                table: "Fights",
                column: "Account2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AccountModel_Account1Id",
                table: "Fights",
                column: "Account1Id",
                principalTable: "AccountModel",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AccountModel_Account2Id",
                table: "Fights",
                column: "Account2Id",
                principalTable: "AccountModel",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
