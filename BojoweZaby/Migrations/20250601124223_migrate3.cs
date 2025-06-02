using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BojoweZaby.Migrations
{
    /// <inheritdoc />
    public partial class migrate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_FrogModel_FrogId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_ItemModel_ItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account1Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account2Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_FrogModel_Frog1Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_FrogModel_Frog2Id",
                table: "Fights");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "FrogModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "FrogId",
                table: "FrogModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Frog2Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Frog1Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Account2Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Account1Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Fights",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrogId",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Equipment",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "AccountModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_FrogModel_FrogId",
                table: "Equipment",
                column: "FrogId",
                principalTable: "FrogModel",
                principalColumn: "FrogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_ItemModel_ItemId",
                table: "Equipment",
                column: "ItemId",
                principalTable: "ItemModel",
                principalColumn: "ItemId",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_FrogModel_Frog1Id",
                table: "Fights",
                column: "Frog1Id",
                principalTable: "FrogModel",
                principalColumn: "FrogId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_FrogModel_Frog2Id",
                table: "Fights",
                column: "Frog2Id",
                principalTable: "FrogModel",
                principalColumn: "FrogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_FrogModel_FrogId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_ItemModel_ItemId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account1Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_AccountModel_Account2Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_FrogModel_Frog1Id",
                table: "Fights");

            migrationBuilder.DropForeignKey(
                name: "FK_Fights_FrogModel_Frog2Id",
                table: "Fights");

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "ItemModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "FrogModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FrogId",
                table: "FrogModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "Fights",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Frog2Id",
                table: "Fights",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Frog1Id",
                table: "Fights",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Account2Id",
                table: "Fights",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Account1Id",
                table: "Fights",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Fights",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemId",
                table: "Equipment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "FrogId",
                table: "Equipment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "AccountModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_FrogModel_FrogId",
                table: "Equipment",
                column: "FrogId",
                principalTable: "FrogModel",
                principalColumn: "FrogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_ItemModel_ItemId",
                table: "Equipment",
                column: "ItemId",
                principalTable: "ItemModel",
                principalColumn: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AccountModel_Account1Id",
                table: "Fights",
                column: "Account1Id",
                principalTable: "AccountModel",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_AccountModel_Account2Id",
                table: "Fights",
                column: "Account2Id",
                principalTable: "AccountModel",
                principalColumn: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_FrogModel_Frog1Id",
                table: "Fights",
                column: "Frog1Id",
                principalTable: "FrogModel",
                principalColumn: "FrogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fights_FrogModel_Frog2Id",
                table: "Fights",
                column: "Frog2Id",
                principalTable: "FrogModel",
                principalColumn: "FrogId");
        }
    }
}
