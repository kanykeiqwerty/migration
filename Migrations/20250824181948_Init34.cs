using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationApi.Migrations
{
    /// <inheritdoc />
    public partial class Init34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedByUserID",
                table: "CitizenForms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedByUserID",
                table: "CitizenForms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CitizenForms_CreatedByUserID",
                table: "CitizenForms",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenForms_UpdatedByUserID",
                table: "CitizenForms",
                column: "UpdatedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_AspNetUsers_CreatedByUserID",
                table: "CitizenForms",
                column: "CreatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms",
                column: "UpdatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_AspNetUsers_CreatedByUserID",
                table: "CitizenForms");

            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms");

            migrationBuilder.DropIndex(
                name: "IX_CitizenForms_CreatedByUserID",
                table: "CitizenForms");

            migrationBuilder.DropIndex(
                name: "IX_CitizenForms_UpdatedByUserID",
                table: "CitizenForms");

            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "CitizenForms");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserID",
                table: "CitizenForms");
        }
    }
}
