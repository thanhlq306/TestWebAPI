using Microsoft.EntityFrameworkCore.Migrations;

namespace APIWebTinTuc.Migrations
{
    public partial class DbUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoai",
                table: "BaiViet",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_UserName",
                table: "UserTable",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet",
                column: "TheLoai",
                principalTable: "LoaiBV",
                principalColumn: "Maloai",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.AlterColumn<int>(
                name: "TheLoai",
                table: "BaiViet",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BaiViet_LoaiBV_TheLoai",
                table: "BaiViet",
                column: "TheLoai",
                principalTable: "LoaiBV",
                principalColumn: "Maloai",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
