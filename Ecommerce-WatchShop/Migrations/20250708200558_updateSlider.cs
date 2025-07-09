using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_WatchShop.Migrations
{
    /// <inheritdoc />
    public partial class updateSlider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HienThiTrangChu",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HienThiTrangSanPham",
                table: "Sliders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HienThiTrangChu",
                table: "Sliders");

            migrationBuilder.DropColumn(
                name: "HienThiTrangSanPham",
                table: "Sliders");
        }
    }
}
