using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Precious.Kh.Migrations
{
    /// <inheritdoc />
    public partial class Kh204116 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_IDCustomer",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Staff_IDStaff",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_IDCustomer",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_IDStaff",
                table: "Account");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDStaff",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDCustomer",
                table: "Account",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Account_IDCustomer",
                table: "Account",
                column: "IDCustomer",
                unique: true,
                filter: "[IDCustomer] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Account_IDStaff",
                table: "Account",
                column: "IDStaff",
                unique: true,
                filter: "[IDStaff] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_IDCustomer",
                table: "Account",
                column: "IDCustomer",
                principalTable: "Customer",
                principalColumn: "IDCustomer");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Staff_IDStaff",
                table: "Account",
                column: "IDStaff",
                principalTable: "Staff",
                principalColumn: "IdStaff");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Customer_IDCustomer",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_Staff_IDStaff",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_IDCustomer",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_IDStaff",
                table: "Account");

            migrationBuilder.AlterColumn<Guid>(
                name: "IDStaff",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "IDCustomer",
                table: "Account",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_IDCustomer",
                table: "Account",
                column: "IDCustomer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_IDStaff",
                table: "Account",
                column: "IDStaff",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Customer_IDCustomer",
                table: "Account",
                column: "IDCustomer",
                principalTable: "Customer",
                principalColumn: "IDCustomer",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Staff_IDStaff",
                table: "Account",
                column: "IDStaff",
                principalTable: "Staff",
                principalColumn: "IdStaff",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
