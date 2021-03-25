using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 新增课程表 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_coursepackage",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_t_coursepackage", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_coursepackage_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_coursepackage_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_coursepackage_t_user_updateuserid",
                        column: x => x.updateuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_coursepackage_createuserid",
                table: "t_coursepackage",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_coursepackage_deleteuserid",
                table: "t_coursepackage",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_coursepackage_updateuserid",
                table: "t_coursepackage",
                column: "updateuserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_coursepackage");
        }
    }
}
