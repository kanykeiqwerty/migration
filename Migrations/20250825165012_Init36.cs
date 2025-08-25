﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationApi.Migrations
{
    /// <inheritdoc />
    public partial class Init36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedByUserID",
                table: "CitizenForms",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms",
                column: "UpdatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedByUserID",
                table: "CitizenForms",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenForms_AspNetUsers_UpdatedByUserID",
                table: "CitizenForms",
                column: "UpdatedByUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
