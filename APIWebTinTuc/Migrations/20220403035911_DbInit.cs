using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWebTinTuc.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaiViet",
                columns: table => new
                {
                    MaBaiViet = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenBaiViet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenTacGia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiViet", x => x.MaBaiViet);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiViet");
        }
    }
}
