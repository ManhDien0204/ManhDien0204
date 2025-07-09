using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_WatchShop.Migrations
{
    /// <inheritdoc />
    public partial class updatePhanTramKhuyenMai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PhanTramKhuyenMai",
                table: "SanPhams",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PhanTramKhuyenMai",
                table: "SanPhams",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
