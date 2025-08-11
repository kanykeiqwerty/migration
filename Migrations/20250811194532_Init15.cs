using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationApi.Migrations
{
    /// <inheritdoc />
    public partial class Init15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Migrations_MigrationStatuses_MigrationStatusID",
                table: "Migrations");

            migrationBuilder.DropIndex(
                name: "IX_Migrations_MigrationStatusID",
                table: "Migrations");

            migrationBuilder.DropColumn(
                name: "MigrationStatusID",
                table: "Migrations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MigrationStatusID",
                table: "Migrations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Migrations_MigrationStatusID",
                table: "Migrations",
                column: "MigrationStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Migrations_MigrationStatuses_MigrationStatusID",
                table: "Migrations",
                column: "MigrationStatusID",
                principalTable: "MigrationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
