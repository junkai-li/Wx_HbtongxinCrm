using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 修改会员信息表 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coursename",
                table: "t_member");

            migrationBuilder.AddColumn<Guid>(
                name: "coursepackageid",
                table: "t_member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_member_coursepackageid",
                table: "t_member",
                column: "coursepackageid");

            migrationBuilder.AddForeignKey(
                name: "FK_t_member_t_coursepackage_coursepackageid",
                table: "t_member",
                column: "coursepackageid",
                principalTable: "t_coursepackage",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_member_t_coursepackage_coursepackageid",
                table: "t_member");

            migrationBuilder.DropIndex(
                name: "IX_t_member_coursepackageid",
                table: "t_member");

            migrationBuilder.DropColumn(
                name: "coursepackageid",
                table: "t_member");

            migrationBuilder.AddColumn<string>(
                name: "coursename",
                table: "t_member",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
