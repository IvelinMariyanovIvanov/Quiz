using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuuestionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAuthorId", "FalseAuthor1Id", "FalseAuthor2Id", "QuestionType", "QuoteId" },
                values: new object[,]
                {
                    { 1, 1, 2, 3, 0, 1 },
                    { 2, 1, 3, 4, 0, 2 },
                    { 3, 1, 4, 5, 0, 3 },
                    { 4, 2, 5, 5, 0, 4 },
                    { 5, 2, 6, 7, 0, 5 },
                    { 6, 2, 7, 8, 0, 6 },
                    { 7, 3, 8, 9, 0, 7 },
                    { 8, 3, 1, 2, 0, 8 },
                    { 9, 3, 2, 3, 0, 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
