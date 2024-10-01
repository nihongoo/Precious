using System;
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
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetail_Sale_IDSale",
                table: "ProductDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDSale",
                table: "ProductDetail",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetail_Sale_IDSale",
                table: "ProductDetail",
                column: "IDSale",
                principalTable: "Sale",
                principalColumn: "IDSale");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetail_Sale_IDSale",
                table: "ProductDetail");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDSale",
                table: "ProductDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetail_Sale_IDSale",
                table: "ProductDetail",
                column: "IDSale",
                principalTable: "Sale",
                principalColumn: "IDSale",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
