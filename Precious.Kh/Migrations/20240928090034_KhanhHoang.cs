using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Precious.Kh.Migrations
{
    /// <inheritdoc />
    public partial class KhanhHoang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Voucher",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Voucher");
        }
    }
}
