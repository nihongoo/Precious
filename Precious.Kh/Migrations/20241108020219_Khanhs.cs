using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Precious.Kh.Migrations
{
    /// <inheritdoc />
    public partial class Khanhs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    IDBrand = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.IDBrand);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IDCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IDCategory);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    IDColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.IDColor);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.IDCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Meterials",
                columns: table => new
                {
                    IDMeterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meterials", x => x.IDMeterial);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    IDSale = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SaleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.IDSale);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.IDSize);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    IdStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateJoin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.IdStaff);
                });

            migrationBuilder.CreateTable(
                name: "TagetCustomers",
                columns: table => new
                {
                    IDTagetCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagetCustomers", x => x.IDTagetCustomer);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StartDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.IDVoucher);
                });

            migrationBuilder.CreateTable(
                name: "AddressCustomer",
                columns: table => new
                {
                    IDAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressCustomer", x => x.IDAddress);
                    table.ForeignKey(
                        name: "FK_AddressCustomer_Customer_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    IDCart = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.IDCart);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IDUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IDUser);
                    table.ForeignKey(
                        name: "FK_Account_Customer_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer");
                    table.ForeignKey(
                        name: "FK_Account_Staff_IDStaff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IdStaff");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianBaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDBrand = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDMeterial = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDTagetCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IDProduct);
                    table.ForeignKey(
                        name: "FK_Product_Brand_IDBrand",
                        column: x => x.IDBrand,
                        principalTable: "Brand",
                        principalColumn: "IDBrand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Category_IDCategory",
                        column: x => x.IDCategory,
                        principalTable: "Category",
                        principalColumn: "IDCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Meterials_IDMeterial",
                        column: x => x.IDMeterial,
                        principalTable: "Meterials",
                        principalColumn: "IDMeterial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_TagetCustomers_IDTagetCustomer",
                        column: x => x.IDTagetCustomer,
                        principalTable: "TagetCustomers",
                        principalColumn: "IDTagetCustomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    IDBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiaoHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayNhanHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SDTNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachThanhToan = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    PhiVanChuyen = table.Column<double>(type: "float", nullable: false),
                    LyDoKhachHuy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiHoaDon = table.Column<int>(type: "int", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDStaff = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.IDBill);
                    table.ForeignKey(
                        name: "FK_Bill_Customer_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Staff_IDStaff",
                        column: x => x.IDStaff,
                        principalTable: "Staff",
                        principalColumn: "IdStaff",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bill_Voucher_IDVoucher",
                        column: x => x.IDVoucher,
                        principalTable: "Voucher",
                        principalColumn: "IDVoucher",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCustomer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => new { x.IDProduct, x.IDCustomer });
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Customer_IDCustomer",
                        column: x => x.IDCustomer,
                        principalTable: "Customer",
                        principalColumn: "IDCustomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Product_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductDetailCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<double>(type: "float", nullable: false),
                    GiaBan = table.Column<double>(type: "float", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDProduct = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDColor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDSale = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IDSize = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.IDProductDetail);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Color_IDColor",
                        column: x => x.IDColor,
                        principalTable: "Color",
                        principalColumn: "IDColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_IDProduct",
                        column: x => x.IDProduct,
                        principalTable: "Product",
                        principalColumn: "IDProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Sale_IDSale",
                        column: x => x.IDSale,
                        principalTable: "Sale",
                        principalColumn: "IDSale");
                    table.ForeignKey(
                        name: "FK_ProductDetail_Size_IDSize",
                        column: x => x.IDSize,
                        principalTable: "Size",
                        principalColumn: "IDSize",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    IDBillDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDBill = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.IDBillDetail);
                    table.ForeignKey(
                        name: "FK_BillDetail_Bill_IDBill",
                        column: x => x.IDBill,
                        principalTable: "Bill",
                        principalColumn: "IDBill",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetail_ProductDetail_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetail",
                        principalColumn: "IDProductDetail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    IDCartDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IDCart = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.IDCartDetail);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_IDCart",
                        column: x => x.IDCart,
                        principalTable: "Cart",
                        principalColumn: "IDCart",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_ProductDetail_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetail",
                        principalColumn: "IDProductDetail",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageProductDetail",
                columns: table => new
                {
                    IDImageProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDProductDetail = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProductDetail", x => x.IDImageProductDetail);
                    table.ForeignKey(
                        name: "FK_ImageProductDetail_ProductDetail_IDProductDetail",
                        column: x => x.IDProductDetail,
                        principalTable: "ProductDetail",
                        principalColumn: "IDProductDetail",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AddressCustomer_IDCustomer",
                table: "AddressCustomer",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IDCustomer",
                table: "Bill",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IDStaff",
                table: "Bill",
                column: "IDStaff");

            migrationBuilder.CreateIndex(
                name: "IX_Bill_IDVoucher",
                table: "Bill",
                column: "IDVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IDBill",
                table: "BillDetail",
                column: "IDBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_IDProductDetail",
                table: "BillDetail",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_IDCustomer",
                table: "Cart",
                column: "IDCustomer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IDCart",
                table: "CartDetail",
                column: "IDCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_IDProductDetail",
                table: "CartDetail",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_IDCustomer",
                table: "FavoriteProducts",
                column: "IDCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_IDProduct",
                table: "FavoriteProducts",
                column: "IDProduct",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageProductDetail_IDProductDetail",
                table: "ImageProductDetail",
                column: "IDProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDBrand",
                table: "Product",
                column: "IDBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDCategory",
                table: "Product",
                column: "IDCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDMeterial",
                table: "Product",
                column: "IDMeterial");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IDTagetCustomer",
                table: "Product",
                column: "IDTagetCustomer");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IDColor",
                table: "ProductDetail",
                column: "IDColor");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IDProduct",
                table: "ProductDetail",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IDSale",
                table: "ProductDetail",
                column: "IDSale");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_IDSize",
                table: "ProductDetail",
                column: "IDSize");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AddressCustomer");

            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "ImageProductDetail");

            migrationBuilder.DropTable(
                name: "Bill");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Meterials");

            migrationBuilder.DropTable(
                name: "TagetCustomers");
        }
    }
}
