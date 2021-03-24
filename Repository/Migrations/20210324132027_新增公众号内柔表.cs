using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 新增公众号内柔表 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "createuserid",
                table: "t_wechatnopublictemplate",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "deleteuserid",
                table: "t_wechatnopublictemplate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "updateuserid",
                table: "t_wechatnopublictemplate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_wechatnopublictemplate_createuserid",
                table: "t_wechatnopublictemplate",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_wechatnopublictemplate_deleteuserid",
                table: "t_wechatnopublictemplate",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_wechatnopublictemplate_updateuserid",
                table: "t_wechatnopublictemplate",
                column: "updateuserid");

            migrationBuilder.AddForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_createuserid",
                table: "t_wechatnopublictemplate",
                column: "createuserid",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_deleteuserid",
                table: "t_wechatnopublictemplate",
                column: "deleteuserid",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_updateuserid",
                table: "t_wechatnopublictemplate",
                column: "updateuserid",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_createuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_deleteuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_t_wechatnopublictemplate_t_user_updateuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropIndex(
                name: "IX_t_wechatnopublictemplate_createuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropIndex(
                name: "IX_t_wechatnopublictemplate_deleteuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropIndex(
                name: "IX_t_wechatnopublictemplate_updateuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropColumn(
                name: "createuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropColumn(
                name: "deleteuserid",
                table: "t_wechatnopublictemplate");

            migrationBuilder.DropColumn(
                name: "updateuserid",
                table: "t_wechatnopublictemplate");
        }
    }
}
