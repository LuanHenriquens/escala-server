using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace escala_server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 30, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    SecretWord = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Adm = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scale",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Day = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Singer = table.Column<string>(maxLength: 50, nullable: false),
                    Link = table.Column<string>(maxLength: 100, nullable: true),
                    Solo = table.Column<string>(maxLength: 20, nullable: true),
                    Tone = table.Column<string>(maxLength: 3, nullable: true),
                    Difficulty = table.Column<int>(nullable: true),
                    LastTime = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFunction",
                columns: table => new
                {
                    MemberId = table.Column<long>(nullable: false),
                    FunctionId = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFunction", x => new { x.MemberId, x.FunctionId });
                    table.ForeignKey(
                        name: "FK_MemberFunction_Function_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Function",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberFunction_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberGroup",
                columns: table => new
                {
                    MemberId = table.Column<long>(nullable: false),
                    GroupId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Adm = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGroup", x => new { x.MemberId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_MemberGroup_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberGroup_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberScale",
                columns: table => new
                {
                    ScaleId = table.Column<long>(nullable: false),
                    MemberId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberScale", x => new { x.MemberId, x.ScaleId });
                    table.ForeignKey(
                        name: "FK_MemberScale_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberScale_Scale_ScaleId",
                        column: x => x.ScaleId,
                        principalTable: "Scale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongScale",
                columns: table => new
                {
                    ScaleId = table.Column<long>(nullable: false),
                    SongId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongScale", x => new { x.SongId, x.ScaleId });
                    table.ForeignKey(
                        name: "FK_SongScale_Scale_ScaleId",
                        column: x => x.ScaleId,
                        principalTable: "Scale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongScale_Song_SongId",
                        column: x => x.SongId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberFunction_FunctionId",
                table: "MemberFunction",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroup_GroupId",
                table: "MemberGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberScale_ScaleId",
                table: "MemberScale",
                column: "ScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SongScale_ScaleId",
                table: "SongScale",
                column: "ScaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberFunction");

            migrationBuilder.DropTable(
                name: "MemberGroup");

            migrationBuilder.DropTable(
                name: "MemberScale");

            migrationBuilder.DropTable(
                name: "SongScale");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Scale");

            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
