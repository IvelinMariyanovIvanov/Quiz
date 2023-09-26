using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuoteFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quotes_AskedQuoteId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quotes_CorrectQuoteId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Questions_QuestionId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuestionId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AskedQuoteId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AskedQuoteId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "CorrectQuoteId",
                table: "Questions",
                newName: "CorrectAnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CorrectQuoteId",
                table: "Questions",
                newName: "IX_Questions_CorrectAnswerId");

            migrationBuilder.AddColumn<int>(
                name: "QuoteId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "QuestionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_QuestionId",
                table: "Authors",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Questions_QuestionId",
                table: "Authors",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Authors_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quotes_QuoteId",
                table: "Questions",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Questions_QuestionId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Authors_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quotes_QuoteId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuoteId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Authors_QuestionId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "CorrectAnswerId",
                table: "Questions",
                newName: "CorrectQuoteId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_CorrectAnswerId",
                table: "Questions",
                newName: "IX_Questions_CorrectQuoteId");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Quotes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AskedQuoteId",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 6,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 7,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 8,
                column: "QuestionId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 9,
                column: "QuestionId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuestionId",
                table: "Quotes",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AskedQuoteId",
                table: "Questions",
                column: "AskedQuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quotes_AskedQuoteId",
                table: "Questions",
                column: "AskedQuoteId",
                principalTable: "Quotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quotes_CorrectQuoteId",
                table: "Questions",
                column: "CorrectQuoteId",
                principalTable: "Quotes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Questions_QuestionId",
                table: "Quotes",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
