using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BojoweZaby.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountModel",
                columns: table => new
                {
                    AccountId = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountModel", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseDefense = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "FrogModel",
                columns: table => new
                {
                    FrogId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseAttack = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseDefense = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrogModel", x => x.FrogId);
                    table.ForeignKey(
                        name: "FK_FrogModel_AccountModel_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AccountModel",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FrogId = table.Column<string>(type: "TEXT", nullable: true),
                    ItemId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_FrogModel_FrogId",
                        column: x => x.FrogId,
                        principalTable: "FrogModel",
                        principalColumn: "FrogId");
                    table.ForeignKey(
                        name: "FK_Equipment_ItemModel_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemModel",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "Fights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Account1Id = table.Column<string>(type: "TEXT", nullable: true),
                    Account2Id = table.Column<string>(type: "TEXT", nullable: true),
                    Frog1Id = table.Column<string>(type: "TEXT", nullable: true),
                    Frog2Id = table.Column<string>(type: "TEXT", nullable: true),
                    WinnerId = table.Column<string>(type: "TEXT", nullable: true),
                    Round = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fights_AccountModel_Account1Id",
                        column: x => x.Account1Id,
                        principalTable: "AccountModel",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Fights_AccountModel_Account2Id",
                        column: x => x.Account2Id,
                        principalTable: "AccountModel",
                        principalColumn: "AccountId");
                    table.ForeignKey(
                        name: "FK_Fights_FrogModel_Frog1Id",
                        column: x => x.Frog1Id,
                        principalTable: "FrogModel",
                        principalColumn: "FrogId");
                    table.ForeignKey(
                        name: "FK_Fights_FrogModel_Frog2Id",
                        column: x => x.Frog2Id,
                        principalTable: "FrogModel",
                        principalColumn: "FrogId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_FrogId",
                table: "Equipment",
                column: "FrogId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ItemId",
                table: "Equipment",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Account1Id",
                table: "Fights",
                column: "Account1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Account2Id",
                table: "Fights",
                column: "Account2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Frog1Id",
                table: "Fights",
                column: "Frog1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fights_Frog2Id",
                table: "Fights",
                column: "Frog2Id");

            migrationBuilder.CreateIndex(
                name: "IX_FrogModel_AccountId",
                table: "FrogModel",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Fights");

            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "FrogModel");

            migrationBuilder.DropTable(
                name: "AccountModel");
        }
    }
}
