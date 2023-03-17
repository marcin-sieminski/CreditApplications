using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditApplications.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ArticcleModelModification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkTitle",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ArticleId",
                table: "Roles",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Articles_ArticleId",
                table: "Roles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Articles_ArticleId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_ArticleId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Roles");

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LinkTitle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
