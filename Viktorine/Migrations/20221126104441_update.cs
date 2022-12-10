using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Viktorine.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Victorines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victorines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Victorines_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Victorines_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VariableQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsPrived = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableQuotes_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VictorineQuotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VictorineId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<int>(type: "INTEGER", nullable: false),
                    VariableQuoteVictoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPrived = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VictorineQuotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VictorineQuotes_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VictorineQuotes_VariableQuotes_VariableQuoteVictoryId",
                        column: x => x.VariableQuoteVictoryId,
                        principalTable: "VariableQuotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VictorineQuotes_Victorines_VictorineId",
                        column: x => x.VictorineId,
                        principalTable: "Victorines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_CategoryId",
                table: "Quotes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableQuotes_QuoteId",
                table: "VariableQuotes",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_VictorineQuotes_QuoteId",
                table: "VictorineQuotes",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_VictorineQuotes_VariableQuoteVictoryId",
                table: "VictorineQuotes",
                column: "VariableQuoteVictoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VictorineQuotes_VictorineId",
                table: "VictorineQuotes",
                column: "VictorineId");

            migrationBuilder.CreateIndex(
                name: "IX_Victorines_CategoryId",
                table: "Victorines",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Victorines_UserId",
                table: "Victorines",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VictorineQuotes");

            migrationBuilder.DropTable(
                name: "VariableQuotes");

            migrationBuilder.DropTable(
                name: "Victorines");

            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
