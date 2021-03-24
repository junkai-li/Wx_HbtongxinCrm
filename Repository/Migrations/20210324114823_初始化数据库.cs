using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class 初始化数据库 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_alipaykey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    appid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appprivatekey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    alipaypublickey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aeskey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_alipaykey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_count",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_count", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_dictionary",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_dictionary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_guidtoint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_guidtoint", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_log",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_regionprovince",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    province = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_regionprovince", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_webinfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weburl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    managername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manageraddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    managerphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manageremail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recordnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seotitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seokeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seodescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    footcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_webinfo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_weixinkey",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    wxappid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wxappsecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mchid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mchkey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_weixinkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_regioncity",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provinceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_regioncity", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_regioncity_t_regionprovince_provinceid",
                        column: x => x.provinceid,
                        principalTable: "t_regionprovince",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_user_t_role_roleid",
                        column: x => x.roleid,
                        principalTable: "t_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_regionarea",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cityid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_regionarea", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_regionarea_t_regioncity_cityid",
                        column: x => x.cityid,
                        principalTable: "t_regioncity",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_channel",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_channel", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_channel_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_channel_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_file",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tableid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_file", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_file_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_file_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_link",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_link", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_link_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_link_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    serialno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paytype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paystate = table.Column<bool>(type: "bit", nullable: false),
                    paytime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    payprice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_t_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_order_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_order_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_order_t_user_updateuserid",
                        column: x => x.updateuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(38,2)", nullable: false),
                    detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_t_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_product_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_product_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_product_t_user_updateuserid",
                        column: x => x.updateuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_sign",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    table = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tableid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_sign", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_sign_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_sign_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_userbindalipay",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    alipaykeyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    alipayuserid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_userbindalipay", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_userbindalipay_t_alipaykey_alipaykeyid",
                        column: x => x.alipaykeyid,
                        principalTable: "t_alipaykey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_userbindalipay_t_user_userid",
                        column: x => x.userid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_userbindweixin",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weixinkeyid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    weixinopenid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_userbindweixin", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_userbindweixin_t_user_userid",
                        column: x => x.userid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_userbindweixin_t_weixinkey_weixinkeyid",
                        column: x => x.weixinkeyid,
                        principalTable: "t_weixinkey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_usertoken",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_usertoken", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_usertoken_t_user_userid",
                        column: x => x.userid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_regiontown",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    areaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_regiontown", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_regiontown_t_regionarea_areaid",
                        column: x => x.areaid,
                        principalTable: "t_regionarea",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_userinfo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    regionareaid = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sex = table.Column<bool>(type: "bit", nullable: true),
                    company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wechat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_userinfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_userinfo_t_regionarea_regionareaid",
                        column: x => x.regionareaid,
                        principalTable: "t_regionarea",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_userinfo_t_user_userid",
                        column: x => x.userid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    channelid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sort = table.Column<int>(type: "int", nullable: false),
                    parentid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_category_t_category_parentid",
                        column: x => x.parentid,
                        principalTable: "t_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_category_t_channel_channelid",
                        column: x => x.channelid,
                        principalTable: "t_channel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_category_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_category_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_filegroup",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    slicing = table.Column<int>(type: "int", nullable: false),
                    issynthesis = table.Column<bool>(type: "bit", nullable: false),
                    isfull = table.Column<bool>(type: "bit", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_filegroup", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_filegroup_t_file_fileid",
                        column: x => x.fileid,
                        principalTable: "t_file",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_filegroupfile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    index = table.Column<int>(type: "int", nullable: false),
                    path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_filegroupfile", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_filegroupfile_t_file_fileid",
                        column: x => x.fileid,
                        principalTable: "t_file",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_imgbaiduai",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updatetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_imgbaiduai", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_imgbaiduai_t_file_fileid",
                        column: x => x.fileid,
                        principalTable: "t_file",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_orderdetail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    orderid1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    productid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number = table.Column<int>(type: "int", nullable: false),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_orderdetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_orderdetail_t_order_orderid1",
                        column: x => x.orderid1,
                        principalTable: "t_order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_article",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    categoryid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isrecommend = table.Column<bool>(type: "bit", nullable: false),
                    isdisplay = table.Column<bool>(type: "bit", nullable: false),
                    sort = table.Column<int>(type: "int", nullable: false),
                    clickcount = table.Column<int>(type: "int", nullable: false),
                    @abstract = table.Column<string>(name: "abstract", type: "nvarchar(max)", nullable: true),
                    createtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isdelete = table.Column<bool>(type: "bit", nullable: false),
                    deletetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    deleteuserid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_article", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_article_t_category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "t_category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_article_t_user_createuserid",
                        column: x => x.createuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_t_article_t_user_deleteuserid",
                        column: x => x.deleteuserid,
                        principalTable: "t_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_article_categoryid",
                table: "t_article",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_t_article_createuserid",
                table: "t_article",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_article_deleteuserid",
                table: "t_article",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_category_channelid",
                table: "t_category",
                column: "channelid");

            migrationBuilder.CreateIndex(
                name: "IX_t_category_createuserid",
                table: "t_category",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_category_deleteuserid",
                table: "t_category",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_category_parentid",
                table: "t_category",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_t_channel_createuserid",
                table: "t_channel",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_channel_deleteuserid",
                table: "t_channel",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_file_createuserid",
                table: "t_file",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_file_deleteuserid",
                table: "t_file",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_file_tableid",
                table: "t_file",
                column: "tableid");

            migrationBuilder.CreateIndex(
                name: "IX_t_filegroup_fileid",
                table: "t_filegroup",
                column: "fileid");

            migrationBuilder.CreateIndex(
                name: "IX_t_filegroupfile_fileid",
                table: "t_filegroupfile",
                column: "fileid");

            migrationBuilder.CreateIndex(
                name: "IX_t_imgbaiduai_fileid",
                table: "t_imgbaiduai",
                column: "fileid");

            migrationBuilder.CreateIndex(
                name: "IX_t_link_createuserid",
                table: "t_link",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_link_deleteuserid",
                table: "t_link",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_order_createuserid",
                table: "t_order",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_order_deleteuserid",
                table: "t_order",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_order_updateuserid",
                table: "t_order",
                column: "updateuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_orderdetail_orderid1",
                table: "t_orderdetail",
                column: "orderid1");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_createuserid",
                table: "t_product",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_deleteuserid",
                table: "t_product",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_product_updateuserid",
                table: "t_product",
                column: "updateuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_regionarea_cityid",
                table: "t_regionarea",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_t_regioncity_provinceid",
                table: "t_regioncity",
                column: "provinceid");

            migrationBuilder.CreateIndex(
                name: "IX_t_regiontown_areaid",
                table: "t_regiontown",
                column: "areaid");

            migrationBuilder.CreateIndex(
                name: "IX_t_sign_createuserid",
                table: "t_sign",
                column: "createuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_sign_deleteuserid",
                table: "t_sign",
                column: "deleteuserid");

            migrationBuilder.CreateIndex(
                name: "IX_t_sign_tableid",
                table: "t_sign",
                column: "tableid");

            migrationBuilder.CreateIndex(
                name: "IX_t_user_roleid",
                table: "t_user",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userbindalipay_alipaykeyid",
                table: "t_userbindalipay",
                column: "alipaykeyid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userbindalipay_userid",
                table: "t_userbindalipay",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userbindweixin_userid",
                table: "t_userbindweixin",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userbindweixin_weixinkeyid",
                table: "t_userbindweixin",
                column: "weixinkeyid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userinfo_regionareaid",
                table: "t_userinfo",
                column: "regionareaid");

            migrationBuilder.CreateIndex(
                name: "IX_t_userinfo_userid",
                table: "t_userinfo",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_t_usertoken_userid",
                table: "t_usertoken",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_article");

            migrationBuilder.DropTable(
                name: "t_count");

            migrationBuilder.DropTable(
                name: "t_dictionary");

            migrationBuilder.DropTable(
                name: "t_filegroup");

            migrationBuilder.DropTable(
                name: "t_filegroupfile");

            migrationBuilder.DropTable(
                name: "t_guidtoint");

            migrationBuilder.DropTable(
                name: "t_imgbaiduai");

            migrationBuilder.DropTable(
                name: "t_link");

            migrationBuilder.DropTable(
                name: "t_log");

            migrationBuilder.DropTable(
                name: "t_orderdetail");

            migrationBuilder.DropTable(
                name: "t_product");

            migrationBuilder.DropTable(
                name: "t_regiontown");

            migrationBuilder.DropTable(
                name: "t_sign");

            migrationBuilder.DropTable(
                name: "t_userbindalipay");

            migrationBuilder.DropTable(
                name: "t_userbindweixin");

            migrationBuilder.DropTable(
                name: "t_userinfo");

            migrationBuilder.DropTable(
                name: "t_usertoken");

            migrationBuilder.DropTable(
                name: "t_webinfo");

            migrationBuilder.DropTable(
                name: "t_category");

            migrationBuilder.DropTable(
                name: "t_file");

            migrationBuilder.DropTable(
                name: "t_order");

            migrationBuilder.DropTable(
                name: "t_alipaykey");

            migrationBuilder.DropTable(
                name: "t_weixinkey");

            migrationBuilder.DropTable(
                name: "t_regionarea");

            migrationBuilder.DropTable(
                name: "t_channel");

            migrationBuilder.DropTable(
                name: "t_regioncity");

            migrationBuilder.DropTable(
                name: "t_user");

            migrationBuilder.DropTable(
                name: "t_regionprovince");

            migrationBuilder.DropTable(
                name: "t_role");
        }
    }
}
