using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 新增上课记录表 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "courseupdate",
                table: "t_member",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "courseupdateuserid",
                table: "t_member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "t_menmbergolog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    memberid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    gocoursecount = table.Column<int>(type: "int", nullable: false),
                    lastcoursecount = table.Column<int>(type: "int", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    updateuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_menmbergolog", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_menmbergolog_t_member_memberid",
                        column: x => x.memberid,
                        principalTable: "t_member",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_menmbergolog_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_menmbergolog_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_menmbergolog_t_user_updateuserid",
                        column: x => x.updateuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_member_courseupdateuserid",
                table: "t_member",
                column: "courseupdateuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_menmbergolog_createuserid",
                table: "t_menmbergolog",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_menmbergolog_deleteuserid",
                table: "t_menmbergolog",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_menmbergolog_memberid",
                table: "t_menmbergolog",
                column: "memberid");

            migrationBuilder.CreateIndex(
                name: "IX_t_menmbergolog_updateuserid",
                table: "t_menmbergolog",
                column: "updateuserid");

            migrationBuilder.AddForeignKey(
                name: "FK_t_member_t_user_courseupdateuserid",
                table: "t_member",
                column: "courseupdateuserid",
                principalTable: "t_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_member_t_user_courseupdateuserid",
                table: "t_member");

            migrationBuilder.DropTable(
                name: "t_menmbergolog");

            migrationBuilder.DropIndex(
                name: "IX_t_member_courseupdateuserid",
                table: "t_member");

            migrationBuilder.DropColumn(
                name: "courseupdate",
                table: "t_member");

            migrationBuilder.DropColumn(
                name: "courseupdateuserid",
                table: "t_member");
        }
    }
}
