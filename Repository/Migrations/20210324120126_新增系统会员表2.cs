using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 新增系统会员表2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_member",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    @class = table.Column<string>(name: "class", type: "nvarchar(max)", nullable: true),
                    parentname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    childname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    schoolname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coursename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    coursecount = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_t_member", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_member_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_member_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_member_t_user_updateuserid",
                        column: x => x.updateuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_memberwxphone",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weixincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_memberwxphone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_wechatnopublictemplate",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_wechatnopublictemplate", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_memberwxphonemessgelog",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tmember_wx_phoneid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tmemberwxphoneid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_memberwxphonemessgelog", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_memberwxphonemessgelog_t_memberwxphone_tmember_wx_phoneid",
                        column: x => x.tmember_wx_phoneid,
                        principalTable: "t_memberwxphone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_member_createuserid",
                table: "t_member",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_member_deleteuserid",
                table: "t_member",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_member_updateuserid",
                table: "t_member",
                column: "updateuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_memberwxphonemessgelog_tmember_wx_phoneid",
                table: "t_memberwxphonemessgelog",
                column: "tmember_wx_phoneid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_member");

            migrationBuilder.DropTable(
                name: "t_memberwxphonemessgelog");

            migrationBuilder.DropTable(
                name: "t_wechatnopublictemplate");

            migrationBuilder.DropTable(
                name: "t_memberwxphone");
        }
    }
}
