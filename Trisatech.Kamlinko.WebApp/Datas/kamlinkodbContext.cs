using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.Datas
{
    public partial class KamlinkoDbContext : DbContext
    {
        public KamlinkoDbContext()
        {
        }

        public KamlinkoDbContext(DbContextOptions<KamlinkoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Alamat> Alamats { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Kategori> Kategoris { get; set; } = null!;
        public virtual DbSet<Keranjang> Keranjangs { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Pembayaran> Pembayarans { get; set; } = null!;
        public virtual DbSet<Pengiriman> Pengirimen { get; set; } = null!;
        public virtual DbSet<Produk> Produks { get; set; } = null!;
        public virtual DbSet<ProdukKategori> ProdukKategoris { get; set; } = null!;
        public virtual DbSet<StatusOrder> StatusOrders { get; set; } = null!;
        public virtual DbSet<DetailOrder> DetailOrders { get; set; } = null!;
        public virtual DbSet<Ulasan> Ulasans { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.NomorHp)
                    .HasMaxLength(15)
                    .HasColumnName("nomor_hp");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
                
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");
                
            });

            modelBuilder.Entity<Alamat>(entity =>
            {
                entity.ToTable("alamat");

                entity.HasIndex(e => e.IdCustomer, "alamat_FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(255)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.IdCustomer)
                .HasColumnName("id_customer");

                entity.Property(e => e.Kecamatan)
                    .HasMaxLength(100)
                    .HasColumnName("kecamatan");

                entity.Property(e => e.Kelurahan)
                    .HasMaxLength(100)
                    .HasColumnName("kelurahan");

                entity.Property(e => e.KodePos)
                    .HasMaxLength(10)
                    .HasColumnName("kode_pos");

                entity.Property(e => e.Kota)
                    .HasMaxLength(100)
                    .HasColumnName("kota");

                entity.Property(e => e.Provinsi)
                    .HasMaxLength(100)
                    .HasColumnName("provinsi");

                entity.Property(e => e.Rt)
                    .HasMaxLength(10)
                    .HasColumnName("rt");

                entity.Property(e => e.Rw)
                    .HasMaxLength(10)
                    .HasColumnName("rw");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Alamats)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alamat_FK");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.GambarProfil)
                    .HasMaxLength(255)
                    .HasColumnName("gambar_profil");

                entity.Property(e => e.Nama)
                    .HasMaxLength(100)
                    .HasColumnName("nama");

                entity.Property(e => e.NomorHp)
                    .HasMaxLength(15)
                    .HasColumnName("nomor_hp");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("kategori");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(255)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .HasColumnName("icon");

                entity.Property(e => e.Nama).HasColumnName("nama");
            });

            modelBuilder.Entity<Keranjang>(entity =>
            {
                entity.ToTable("keranjang");

                entity.HasIndex(e => e.IdProduk, "keranjang_FK");

                entity.HasIndex(e => e.IdCustomer, "keranjang_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");

                entity.Property(e => e.JmlBarang)
                    .HasColumnName("jml_barang")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(10)
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Keranjangs)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("keranjang_FK_1");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.Keranjangs)
                    .HasForeignKey(d => d.IdProduk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("keranjang_FK");
            });

            modelBuilder.Entity<DetailOrder>(entity => {
                
                entity.ToTable("detail_order");

                entity.HasIndex(e => e.IdOrder, "detail_order_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");
                
                entity.Property(e => e.Harga).HasColumnName("harga")
                .HasPrecision(10);

                entity.Property(e => e.JmlBarang).HasColumnName("jml_barang");
                
                entity.Property(e => e.SubTotal).HasColumnName("subtotal")
                .HasPrecision(10);
                
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DetailOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("detail_order_FK_1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.IdCustomer, "order_FK_1");

                entity.HasIndex(e => e.IdAlamat, "order_FK_2");

                entity.HasIndex(e => e.Status, "order_FK_3");

                entity.HasIndex(e => e.IdTransaksiMirror, "order_FK_4");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAlamat).HasColumnName("id_alamat");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.JmlBayar)
                    .HasPrecision(10)
                    .HasColumnName("jml_bayar");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.IdTransaksiMirror)
                    .HasColumnName("id_transaksi_mirror");


                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TglTransaksi)
                    .HasColumnType("datetime")
                    .HasColumnName("tgl_transaksi");

                entity.HasOne(d => d.IdAlamatNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdAlamat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_2");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_1");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_3");

                entity.HasOne(d => d.TransksiMirror)
                    .WithOne(p => p.Order)
                    .HasForeignKey<Order>(e => e.IdTransaksiMirror)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_3");
            });

            modelBuilder.Entity<TrannsaksiMirror>(entity =>
            {
                entity.ToTable("transaksi_mirror");

                entity.HasIndex(e => e.IdOrder, "transaksi_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nama).HasColumnName("nama");

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.TransksiMirror)
                    .HasForeignKey<TrannsaksiMirror>(e => e.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_FK_2");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.ToTable("pembayaran");

                entity.HasIndex(e => e.IdOrder, "pembayaran_FK");

                entity.HasIndex(e => e.IdCustomer, "pembayaran_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdCustomer).HasColumnName("id_customer");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdTujuan)
                    .HasMaxLength(100)
                    .HasColumnName("id_tujuan");

                entity.Property(e => e.JmlBayar)
                    .HasPrecision(10)
                    .HasColumnName("jml_bayar");

                entity.Property(e => e.Metode)
                    .HasMaxLength(100)
                    .HasColumnName("metode");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.Pajak)
                    .HasPrecision(10)
                    .HasColumnName("pajak");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.TglBayar)
                    .HasColumnType("datetime")
                    .HasColumnName("tgl_bayar");

                entity.Property(e => e.FileBuktiBayar)
                    .HasMaxLength(255)
                    .HasColumnName("file_bukti_bayar");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pembayaran_FK_1");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pembayaran_FK");
            });

            modelBuilder.Entity<Pengiriman>(entity =>
            {
                entity.ToTable("pengiriman");

                entity.HasIndex(e => e.IdOrder, "pengiriman_FK");

                entity.HasIndex(e => e.IdAlamat, "pengiriman_FK_1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAlamat).HasColumnName("id_alamat");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.Keterangan)
                    .HasMaxLength(255)
                    .HasColumnName("keterangan");

                entity.Property(e => e.Kurir)
                    .HasMaxLength(255)
                    .HasColumnName("kurir");

                entity.Property(e => e.Ongkir)
                    .HasPrecision(10)
                    .HasColumnName("ongkir");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasColumnName("status");

                entity.Property(e => e.NoResi)
                    .HasMaxLength(100)
                    .HasColumnName("no_resi");

                entity.HasOne(d => d.IdAlamatNavigation)
                    .WithMany(p => p.Pengirimen)
                    .HasForeignKey(d => d.IdAlamat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pengiriman_FK_1");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.Pengirimen)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pengiriman_FK");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.ToTable("produk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(500)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Gambar)
                    .HasMaxLength(255)
                    .HasColumnName("gambar");

                entity.Property(e => e.Harga)
                    .HasPrecision(10)
                    .HasColumnName("harga");

                entity.Property(e => e.Nama)
                    .HasMaxLength(255)
                    .HasColumnName("nama");

                entity.Property(e => e.Stok).HasColumnName("stok");
            });

            modelBuilder.Entity<ProdukKategori>(entity =>
            {
                entity.ToTable("produk_kategori");

                entity.HasIndex(e => e.IdKategori, "produk_Kategori_FK_1");

                entity.HasIndex(e => e.IdProduk, "produk_kategori_FK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdKategori).HasColumnName("id_kategori");

                entity.Property(e => e.IdProduk).HasColumnName("id_produk");

                entity.HasOne(d => d.IdKategoriNavigation)
                    .WithMany(p => p.ProdukKategoris)
                    .HasForeignKey(d => d.IdKategori)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produk_Kategori_FK_1");

                entity.HasOne(d => d.IdProdukNavigation)
                    .WithMany(p => p.ProdukKategoris)
                    .HasForeignKey(d => d.IdProduk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produk_kategori_FK");
            });

            modelBuilder.Entity<StatusOrder>(entity =>
            {
                entity.ToTable("status_order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(255)
                    .HasColumnName("deskripsi");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .HasColumnName("nama");
            });

            modelBuilder.Entity<Ulasan>(entity => 
            {
                entity.ToTable("ulasan");

                entity.Property(e=>e.Id)
                .HasColumnName("id");

                entity.Property(e => e.IdOrder)
                .HasColumnName("id_order");

                entity.Property(e => e.IdCustomer)
                .HasColumnName("id_customer");

                entity.Property(e => e.Komentar)
                .HasMaxLength(1000)
                .HasColumnName("komentar");

                entity.Property(x=> x.Gambar)
                .HasMaxLength(100)
                .HasColumnName("gambar");

                entity.Property(e => e.Rating)
                .HasColumnName("rating");

                entity.HasIndex(e => e.IdOrder, "ulasan_fk1");

                entity.HasIndex(e => e.IdCustomer, "ulasan_fk2");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ulasans)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ulasan_fk1");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Ulasans)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ulasan_fk2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
