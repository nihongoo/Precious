﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Precious.Kh.Model;

#nullable disable

namespace Precious.Kh.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Precious.Kh.Model.Account", b =>
                {
                    b.Property<Guid>("IDUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDStaff")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("IDUser");

                    b.HasIndex("IDCustomer")
                        .IsUnique()
                        .HasFilter("[IDCustomer] IS NOT NULL");

                    b.HasIndex("IDStaff")
                        .IsUnique()
                        .HasFilter("[IDStaff] IS NOT NULL");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("Precious.Kh.Model.AddressCustomer", b =>
                {
                    b.Property<Guid>("IDAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IDCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDAddress");

                    b.HasIndex("IDCustomer");

                    b.ToTable("AddressCustomer");
                });

            modelBuilder.Entity("Precious.Kh.Model.Bill", b =>
                {
                    b.Property<Guid>("IDBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BillCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiaChiNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GiamGia")
                        .HasColumnType("float");

                    b.Property<string>("HinhThucThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IDCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDStaff")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDVoucher")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("KhachThanhToan")
                        .HasColumnType("float");

                    b.Property<int>("LoaiHoaDon")
                        .HasColumnType("int");

                    b.Property<string>("LyDoKhachHuy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayGiaoHang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayNhanHang")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<double>("PhiVanChuyen")
                        .HasColumnType("float");

                    b.Property<string>("SDTNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TenNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("IDBill");

                    b.HasIndex("IDCustomer");

                    b.HasIndex("IDStaff");

                    b.HasIndex("IDVoucher");

                    b.ToTable("Bill");
                });

            modelBuilder.Entity("Precious.Kh.Model.BillDetail", b =>
                {
                    b.Property<Guid>("IDBillDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDBillDetail");

                    b.HasIndex("IDBill");

                    b.HasIndex("IDProductDetail");

                    b.ToTable("BillDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Brand", b =>
                {
                    b.Property<Guid>("IDBrand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrandCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDBrand");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Precious.Kh.Model.Cart", b =>
                {
                    b.Property<Guid>("IDCart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IDCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("IDCart");

                    b.HasIndex("IDCustomer")
                        .IsUnique();

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Precious.Kh.Model.CartDetail", b =>
                {
                    b.Property<Guid>("IDCartDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDCart")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDCartDetail");

                    b.HasIndex("IDCart");

                    b.HasIndex("IDProductDetail");

                    b.ToTable("CartDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Category", b =>
                {
                    b.Property<Guid>("IDCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDCategory");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Precious.Kh.Model.Color", b =>
                {
                    b.Property<Guid>("IDColor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDColor");

                    b.ToTable("Color");
                });

            modelBuilder.Entity("Precious.Kh.Model.Customer", b =>
                {
                    b.Property<Guid>("IDCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<Guid>("IDUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDCustomer");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Precious.Kh.Model.FavoriteProducts", b =>
                {
                    b.Property<Guid>("IDProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDProduct", "IDCustomer");

                    b.HasIndex("IDCustomer");

                    b.HasIndex("IDProduct")
                        .IsUnique();

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("Precious.Kh.Model.ImageProductDetail", b =>
                {
                    b.Property<Guid>("IDImageProductDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDImageProductDetail");

                    b.HasIndex("IDProductDetail");

                    b.ToTable("ImageProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Product", b =>
                {
                    b.Property<Guid>("IDProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatLieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IDBrand")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDTagetCustomer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ThoiGianBaoHanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDProduct");

                    b.HasIndex("IDBrand");

                    b.HasIndex("IDCategory");

                    b.HasIndex("IDTagetCustomer");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Precious.Kh.Model.ProductDetail", b =>
                {
                    b.Property<Guid>("IDProductDetail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("GiaBan")
                        .HasColumnType("float");

                    b.Property<double>("GiaNhap")
                        .HasColumnType("float");

                    b.Property<Guid>("IDColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IDSale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductDetailCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDProductDetail");

                    b.HasIndex("IDColor");

                    b.HasIndex("IDProduct");

                    b.HasIndex("IDSale");

                    b.HasIndex("IDSize");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Sale", b =>
                {
                    b.Property<Guid>("IDSale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaleCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("IDSale");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("Precious.Kh.Model.Size", b =>
                {
                    b.Property<Guid>("IDSize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDSize");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("Precious.Kh.Model.Staff", b =>
                {
                    b.Property<Guid>("IdStaff")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateJoin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IDUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdStaff");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Precious.Kh.Model.TagetCustomers", b =>
                {
                    b.Property<Guid>("IDTagetCustomer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IDTagetCustomer");

                    b.ToTable("TagetCustomers");
                });

            modelBuilder.Entity("Precious.Kh.Model.Voucher", b =>
                {
                    b.Property<Guid>("IDVoucher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDVoucher");

                    b.ToTable("Voucher");
                });

            modelBuilder.Entity("Precious.Kh.Model.Account", b =>
                {
                    b.HasOne("Precious.Kh.Model.Customer", "Customer")
                        .WithOne("Account")
                        .HasForeignKey("Precious.Kh.Model.Account", "IDCustomer");

                    b.HasOne("Precious.Kh.Model.Staff", "Staff")
                        .WithOne("Account")
                        .HasForeignKey("Precious.Kh.Model.Account", "IDStaff");

                    b.Navigation("Customer");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Precious.Kh.Model.AddressCustomer", b =>
                {
                    b.HasOne("Precious.Kh.Model.Customer", "Customer")
                        .WithMany("Address")
                        .HasForeignKey("IDCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Precious.Kh.Model.Bill", b =>
                {
                    b.HasOne("Precious.Kh.Model.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("IDCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Staff", "Staff")
                        .WithMany("Bills")
                        .HasForeignKey("IDStaff")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Voucher", "Voucher")
                        .WithMany("Bill")
                        .HasForeignKey("IDVoucher")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Staff");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("Precious.Kh.Model.BillDetail", b =>
                {
                    b.HasOne("Precious.Kh.Model.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IDBill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.ProductDetail", "ProductDetail")
                        .WithMany("BillDetails")
                        .HasForeignKey("IDProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Cart", b =>
                {
                    b.HasOne("Precious.Kh.Model.Customer", "Customer")
                        .WithOne("Cart")
                        .HasForeignKey("Precious.Kh.Model.Cart", "IDCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Precious.Kh.Model.CartDetail", b =>
                {
                    b.HasOne("Precious.Kh.Model.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("IDCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.ProductDetail", "ProductDetail")
                        .WithMany("CartDetails")
                        .HasForeignKey("IDProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.FavoriteProducts", b =>
                {
                    b.HasOne("Precious.Kh.Model.Customer", "Customer")
                        .WithMany("FavoriteProducts")
                        .HasForeignKey("IDCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Product", "Product")
                        .WithOne("FavoriteProducts")
                        .HasForeignKey("Precious.Kh.Model.FavoriteProducts", "IDProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Precious.Kh.Model.ImageProductDetail", b =>
                {
                    b.HasOne("Precious.Kh.Model.ProductDetail", "ProductDetail")
                        .WithMany("ImageProductDetail")
                        .HasForeignKey("IDProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Product", b =>
                {
                    b.HasOne("Precious.Kh.Model.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("IDBrand")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IDCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.TagetCustomers", "TagetCustomer")
                        .WithMany("Products")
                        .HasForeignKey("IDTagetCustomer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("TagetCustomer");
                });

            modelBuilder.Entity("Precious.Kh.Model.ProductDetail", b =>
                {
                    b.HasOne("Precious.Kh.Model.Color", "Color")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IDColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Product", "Product")
                        .WithMany("ProductDetail")
                        .HasForeignKey("IDProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Precious.Kh.Model.Sale", "Sale")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IDSale");

                    b.HasOne("Precious.Kh.Model.Size", "Size")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IDSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Sale");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Precious.Kh.Model.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("Precious.Kh.Model.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Precious.Kh.Model.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("Precious.Kh.Model.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Precious.Kh.Model.Color", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Precious.Kh.Model.Customer", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Address");

                    b.Navigation("Bills");

                    b.Navigation("Cart");

                    b.Navigation("FavoriteProducts");
                });

            modelBuilder.Entity("Precious.Kh.Model.Product", b =>
                {
                    b.Navigation("FavoriteProducts");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");

                    b.Navigation("ImageProductDetail");
                });

            modelBuilder.Entity("Precious.Kh.Model.Sale", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Precious.Kh.Model.Size", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("Precious.Kh.Model.Staff", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Bills");
                });

            modelBuilder.Entity("Precious.Kh.Model.TagetCustomers", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Precious.Kh.Model.Voucher", b =>
                {
                    b.Navigation("Bill");
                });
#pragma warning restore 612, 618
        }
    }
}
