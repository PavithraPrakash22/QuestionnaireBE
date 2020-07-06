using Microsoft.EntityFrameworkCore.Migrations;

namespace QuestionnaireMW.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFName = table.Column<string>(maxLength: 10, nullable: false),
                    UserLName = table.Column<string>(nullable: false),
                    UserPassword = table.Column<string>(nullable: false),
                    UserEmail = table.Column<string>(nullable: false),
                    UserMobileNo = table.Column<string>(nullable: false),
                    UserResponseCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AnswerResponses",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserResponseCount = table.Column<int>(nullable: false),
                    ans1 = table.Column<string>(nullable: true),
                    ans2 = table.Column<string>(nullable: true),
                    ans3 = table.Column<string>(nullable: true),
                    ans4 = table.Column<string>(nullable: true),
                    ans5 = table.Column<string>(nullable: true),
                    ans6 = table.Column<string>(nullable: true),
                    ans7 = table.Column<string>(nullable: true),
                    ans8 = table.Column<string>(nullable: true),
                    ans9 = table.Column<string>(nullable: true),
                    ans10 = table.Column<string>(nullable: true),
                    ans11 = table.Column<string>(nullable: true),
                    ans12 = table.Column<string>(nullable: true),
                    ans13 = table.Column<string>(nullable: true),
                    ans14 = table.Column<string>(nullable: true),
                    ans15 = table.Column<string>(nullable: true),
                    ans16 = table.Column<string>(nullable: true),
                    ans17 = table.Column<string>(nullable: true),
                    ans18 = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerResponses", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_AnswerResponses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerResponses_UserId",
                table: "AnswerResponses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserEmail",
                table: "Users",
                column: "UserEmail",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerResponses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
