using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationApi.Migrations
{
    /// <inheritdoc />
    public partial class Init17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_Statuses_StatusID",
                table: "CitizenForms");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "CitizenForms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_Statuses_StatusID",
                table: "CitizenForms",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_Statuses_StatusID",
                table: "CitizenForms");

            migrationBuilder.AlterColumn<int>(
                name: "StatusID",
                table: "CitizenForms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_Statuses_StatusID",
                table: "CitizenForms",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
