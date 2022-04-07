﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trisatech.Kamlinko.WebApp.Datas;

#nullable disable

namespace Trisatech.Kamlinko.WebApp.Datas.Migrations
{
    [DbContext(typeof(KamlinkoDbContext))]
    [Migration("20220407075449_AddTableTransaksiMirror")]
    partial class AddTableTransaksiMirror
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama");

                    b.Property<string>("NomorHp")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("nomor_hp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("admin", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("id_customer");

                    b.Property<string>("Kecamatan")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("kecamatan");

                    b.Property<string>("Kelurahan")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("kelurahan");

                    b.Property<string>("KodePos")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("kode_pos");

                    b.Property<string>("Kota")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("kota");

                    b.Property<string>("Provinsi")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("provinsi");

                    b.Property<string>("Rt")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("rt");

                    b.Property<string>("Rw")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("rw");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdCustomer" }, "alamat_FK");

                    b.ToTable("alamat", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("email");

                    b.Property<string>("GambarProfil")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("gambar_profil");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nama");

                    b.Property<string>("NomorHp")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("nomor_hp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.DetailOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("Harga")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("harga");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("id_order");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int")
                        .HasColumnName("id_produk");

                    b.Property<int>("JmlBarang")
                        .HasColumnType("int")
                        .HasColumnName("jml_barang");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdOrder" }, "detail_order_FK_1");

                    b.ToTable("detail_order", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Icon")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("icon");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nama");

                    b.HasKey("Id");

                    b.ToTable("kategori", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Keranjang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int")
                        .HasColumnName("id_produk");

                    b.Property<int>("JmlBarang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("jml_barang")
                        .HasDefaultValueSql("'1'");

                    b.Property<decimal>("Subtotal")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("subtotal");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdProduk" }, "keranjang_FK");

                    b.HasIndex(new[] { "IdCustomer" }, "keranjang_FK_1");

                    b.ToTable("keranjang", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdAlamat")
                        .HasColumnType("int")
                        .HasColumnName("id_alamat");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("id_customer");

                    b.Property<int?>("IdTransaksiMirror")
                        .HasColumnType("int")
                        .HasColumnName("id_transaksi_mirror");

                    b.Property<decimal>("JmlBayar")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("jml_bayar");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("note");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("TglTransaksi")
                        .HasColumnType("datetime")
                        .HasColumnName("tgl_transaksi");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdCustomer" }, "order_FK_1");

                    b.HasIndex(new[] { "IdAlamat" }, "order_FK_2");

                    b.HasIndex(new[] { "Status" }, "order_FK_3");

                    b.HasIndex(new[] { "IdTransaksiMirror" }, "order_FK_4");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Pembayaran", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("FileBuktiBayar")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_bukti_bayar");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("id_order");

                    b.Property<string>("IdTujuan")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("id_tujuan");

                    b.Property<decimal>("JmlBayar")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("jml_bayar");

                    b.Property<string>("Metode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("metode");

                    b.Property<string>("Note")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("note");

                    b.Property<decimal>("Pajak")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("pajak");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("status");

                    b.Property<DateTime>("TglBayar")
                        .HasColumnType("datetime")
                        .HasColumnName("tgl_bayar");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdOrder" }, "pembayaran_FK");

                    b.HasIndex(new[] { "IdCustomer" }, "pembayaran_FK_1");

                    b.ToTable("pembayaran", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Pengiriman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdAlamat")
                        .HasColumnType("int")
                        .HasColumnName("id_alamat");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("id_order");

                    b.Property<string>("Keterangan")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("keterangan");

                    b.Property<string>("Kurir")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("kurir");

                    b.Property<string>("NoResi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("no_resi");

                    b.Property<decimal>("Ongkir")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("ongkir");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdOrder" }, "pengiriman_FK");

                    b.HasIndex(new[] { "IdAlamat" }, "pengiriman_FK_1");

                    b.ToTable("pengiriman", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Produk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Gambar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("gambar");

                    b.Property<decimal>("Harga")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("harga");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nama");

                    b.Property<int>("Stok")
                        .HasColumnType("int")
                        .HasColumnName("stok");

                    b.HasKey("Id");

                    b.ToTable("produk", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.ProdukKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdKategori")
                        .HasColumnType("int")
                        .HasColumnName("id_kategori");

                    b.Property<int>("IdProduk")
                        .HasColumnType("int")
                        .HasColumnName("id_produk");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdKategori" }, "produk_Kategori_FK_1");

                    b.HasIndex(new[] { "IdProduk" }, "produk_kategori_FK");

                    b.ToTable("produk_kategori", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.StatusOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Deskripsi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nama");

                    b.HasKey("Id");

                    b.ToTable("status_order", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.TrannsaksiMirror", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nama");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder")
                        .IsUnique();

                    b.HasIndex(new[] { "IdOrder" }, "transaksi_FK_1");

                    b.ToTable("transaksi_mirror", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Ulasan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Gambar")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("gambar");

                    b.Property<int>("IdCustomer")
                        .HasColumnType("int")
                        .HasColumnName("id_customer");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("id_order");

                    b.Property<string>("Komentar")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("komentar");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "IdOrder" }, "ulasan_fk1");

                    b.HasIndex(new[] { "IdCustomer" }, "ulasan_fk2");

                    b.ToTable("ulasan", (string)null);
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Alamats")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("alamat_FK");

                    b.Navigation("IdCustomerNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.DetailOrder", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", "Order")
                        .WithMany("DetailOrders")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("detail_order_FK_1");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Keranjang", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Keranjangs")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("keranjang_FK_1");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Produk", "IdProdukNavigation")
                        .WithMany("Keranjangs")
                        .HasForeignKey("IdProduk")
                        .IsRequired()
                        .HasConstraintName("keranjang_FK");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdProdukNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Alamat", "IdAlamatNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdAlamat")
                        .IsRequired()
                        .HasConstraintName("order_FK_2");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("order_FK_1");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.StatusOrder", "StatusNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Status")
                        .IsRequired()
                        .HasConstraintName("order_FK_3");

                    b.Navigation("IdAlamatNavigation");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("StatusNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Pembayaran", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", "IdCustomerNavigation")
                        .WithMany("Pembayarans")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("pembayaran_FK_1");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", "IdOrderNavigation")
                        .WithMany("Pembayarans")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("pembayaran_FK");

                    b.Navigation("IdCustomerNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Pengiriman", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Alamat", "IdAlamatNavigation")
                        .WithMany("Pengirimen")
                        .HasForeignKey("IdAlamat")
                        .IsRequired()
                        .HasConstraintName("pengiriman_FK_1");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", "IdOrderNavigation")
                        .WithMany("Pengirimen")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("pengiriman_FK");

                    b.Navigation("IdAlamatNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.ProdukKategori", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Kategori", "IdKategoriNavigation")
                        .WithMany("ProdukKategoris")
                        .HasForeignKey("IdKategori")
                        .IsRequired()
                        .HasConstraintName("produk_Kategori_FK_1");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Produk", "IdProdukNavigation")
                        .WithMany("ProdukKategoris")
                        .HasForeignKey("IdProduk")
                        .IsRequired()
                        .HasConstraintName("produk_kategori_FK");

                    b.Navigation("IdKategoriNavigation");

                    b.Navigation("IdProdukNavigation");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.TrannsaksiMirror", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", "Order")
                        .WithOne("TransksiMirror")
                        .HasForeignKey("Trisatech.Kamlinko.WebApp.Datas.Entities.TrannsaksiMirror", "IdOrder")
                        .IsRequired()
                        .HasConstraintName("order_FK_2");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Ulasan", b =>
                {
                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", "Customer")
                        .WithMany("Ulasans")
                        .HasForeignKey("IdCustomer")
                        .IsRequired()
                        .HasConstraintName("ulasan_fk2");

                    b.HasOne("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", "Order")
                        .WithMany("Ulasans")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("ulasan_fk1");

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Alamat", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Pengirimen");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Customer", b =>
                {
                    b.Navigation("Alamats");

                    b.Navigation("Keranjangs");

                    b.Navigation("Orders");

                    b.Navigation("Pembayarans");

                    b.Navigation("Ulasans");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Kategori", b =>
                {
                    b.Navigation("ProdukKategoris");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Order", b =>
                {
                    b.Navigation("DetailOrders");

                    b.Navigation("Pembayarans");

                    b.Navigation("Pengirimen");

                    b.Navigation("TransksiMirror")
                        .IsRequired();

                    b.Navigation("Ulasans");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.Produk", b =>
                {
                    b.Navigation("Keranjangs");

                    b.Navigation("ProdukKategoris");
                });

            modelBuilder.Entity("Trisatech.Kamlinko.WebApp.Datas.Entities.StatusOrder", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
