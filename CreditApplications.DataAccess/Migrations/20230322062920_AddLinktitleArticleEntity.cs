using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditApplications.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLinktitleArticleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollateralCreditApplication_Collateral_CollateralsId",
                table: "CollateralCreditApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collateral",
                table: "Collateral");

            migrationBuilder.RenameTable(
                name: "Collateral",
                newName: "Collaterals");

            migrationBuilder.AddColumn<string>(
                name: "LinkTitle",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collaterals",
                table: "Collaterals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollateralCreditApplication_Collaterals_CollateralsId",
                table: "CollateralCreditApplication",
                column: "CollateralsId",
                principalTable: "Collaterals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollateralCreditApplication_Collaterals_CollateralsId",
                table: "CollateralCreditApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collaterals",
                table: "Collaterals");

            migrationBuilder.DropColumn(
                name: "LinkTitle",
                table: "Articles");

            migrationBuilder.RenameTable(
                name: "Collaterals",
                newName: "Collateral");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collateral",
                table: "Collateral",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollateralCreditApplication_Collateral_CollateralsId",
                table: "CollateralCreditApplication",
                column: "CollateralsId",
                principalTable: "Collateral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
