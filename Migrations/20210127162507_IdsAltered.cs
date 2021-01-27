using Microsoft.EntityFrameworkCore.Migrations;

namespace escala_server.Migrations
{
    public partial class IdsAltered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "SongScale");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberScale");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "SongScale",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "MemberScale",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "MemberGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
