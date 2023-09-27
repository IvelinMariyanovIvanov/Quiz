using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuotesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "AuthorId", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, 1, null, "Learn from yesterday, live for today, hope for tomorrow. The important thing is not to stop questioning." },
                    { 2, 1, null, "We cannot solve our problems with the same thinking we used when we created them." },
                    { 3, 1, null, "Life is like riding a bicycle. To keep your balance, you must keep moving." },
                    { 4, 2, null, "Do not dwell in the past, do not dream of the future, concentrate the mind on the present moment." },
                    { 5, 2, null, "Three things cannot be long hidden: the sun, the moon, and the truth." },
                    { 6, 2, null, "You will not be punished for your anger, you will be punished by your anger." },
                    { 7, 3, null, "In order to carry a positive action we must develop here a positive vision." },
                    { 8, 3, null, "Be kind whenever possible. It is always possible." },
                    { 9, 3, null, "A lack of transparency results in distrust and a deep sense of insecurity." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
