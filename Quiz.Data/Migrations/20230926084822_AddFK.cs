using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quotes_QuoteId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Authors_AuthorId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quotes_QuoteId",
                table: "Questions",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Authors_AuthorId",
                table: "Quotes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
