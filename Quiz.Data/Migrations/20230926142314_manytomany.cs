using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Quiz.Data.Migrations
{
    /// <inheritdoc />
    public partial class manytomany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerUser_Answers_AnswersId",
                table: "AnswerUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerUser_AspNetUsers_UsersId",
                table: "AnswerUser");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "AnswerUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AnswersId",
                table: "AnswerUser",
                newName: "AnswerId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerUser_UsersId",
                table: "AnswerUser",
                newName: "IX_AnswerUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerUser_Answers_AnswerId",
                table: "AnswerUser",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerUser_AspNetUsers_UserId",
                table: "AnswerUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerUser_Answers_AnswerId",
                table: "AnswerUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerUser_AspNetUsers_UserId",
                table: "AnswerUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AnswerUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "AnswerUser",
                newName: "AnswersId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerUser_UserId",
                table: "AnswerUser",
                newName: "IX_AnswerUser_UsersId");

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerUser_Answers_AnswersId",
                table: "AnswerUser",
                column: "AnswersId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerUser_AspNetUsers_UsersId",
                table: "AnswerUser",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
