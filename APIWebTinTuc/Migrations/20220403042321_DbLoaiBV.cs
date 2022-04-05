using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWebTinTuc.Migrations
{
    public partial class DbLoaiBV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheLoai",
                table: "BaiViet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LoaiBV",
                columns: table => new
                {
                    Maloai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiBV", x => x.Maloai);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaiViet_TheLoai",
                table: "BaiViet",
                column: "TheLoai");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet",
                column: "TheLoai",
                principalTable: "LoaiBV",
                principalColumn: "Maloai",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet");

            migrationBuilder.DropTable(
                name: "LoaiBV");

            migrationBuilder.DropIndex(
                name: "IX_BaiViet_TheLoai",
                table: "BaiViet");

            migrationBuilder.DropColumn(
                name: "TheLoai",
                table: "BaiViet");
        }
    }
}
