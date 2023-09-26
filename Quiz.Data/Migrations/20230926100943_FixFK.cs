using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "FalseAuthor2Id",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "FalseAuthor2Id",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 5, 4 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 4, 3 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AuthorId",
                table: "Quotes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CorrectAuthorId",
                table: "Questions",
                column: "CorrectAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FalseAuthor1Id",
                table: "Questions",
                column: "FalseAuthor1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FalseAuthor2Id",
                table: "Questions",
                column: "FalseAuthor2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Authors_CorrectAuthorId",
                table: "Questions",
                column: "CorrectAuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Authors_FalseAuthor1Id",
                table: "Questions",
                column: "FalseAuthor1Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Authors_FalseAuthor2Id",
                table: "Questions",
                column: "FalseAuthor2Id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quotes_QuoteId",
                table: "Questions",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Authors_AuthorId",
                table: "Quotes",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Authors_CorrectAuthorId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Authors_FalseAuthor1Id",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Authors_FalseAuthor2Id",
                table: "Questions");

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
                name: "IX_Questions_CorrectAuthorId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FalseAuthor1Id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FalseAuthor2Id",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                column: "FalseAuthor2Id",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                column: "FalseAuthor2Id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 7, 8 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 8, 9 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "FalseAuthor1Id", "FalseAuthor2Id" },
                values: new object[] { 2, 3 });
        }
    }
}
