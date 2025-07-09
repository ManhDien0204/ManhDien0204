using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_WatchShop.Migrations
{
    /// <inheritdoc />
    public partial class data_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GiaKhuyenMai",
                table: "SanPhams",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhanTramKhuyenMai",
                table: "SanPhams",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaKhuyenMai",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "PhanTramKhuyenMai",
                table: "SanPhams");
        }
    }
}
