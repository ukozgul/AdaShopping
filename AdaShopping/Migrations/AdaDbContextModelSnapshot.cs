﻿// <auto-generated />
using AdaShopping.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdaShopping.Migrations
{
    [DbContext(typeof(AdaDbContext))]
    partial class AdaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AdaShopping.Models.Musteri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sehir")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("AdaShopping.Models.Sepet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MusteriId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MusteriId");

                    b.ToTable("Sepetler");
                });

            modelBuilder.Entity("AdaShopping.Models.SepetUrun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SepetId")
                        .HasColumnType("int");

                    b.Property<int>("Tutar")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SepetId");

                    b.ToTable("SepetUrunler");
                });

            modelBuilder.Entity("AdaShopping.Models.Sepet", b =>
                {
                    b.HasOne("AdaShopping.Models.Musteri", "Musteri")
                        .WithMany("Sepet")
                        .HasForeignKey("MusteriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musteri");
                });

            modelBuilder.Entity("AdaShopping.Models.SepetUrun", b =>
                {
                    b.HasOne("AdaShopping.Models.Sepet", "Sepet")
                        .WithMany("SepetUrun")
                        .HasForeignKey("SepetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sepet");
                });

            modelBuilder.Entity("AdaShopping.Models.Musteri", b =>
                {
                    b.Navigation("Sepet");
                });

            modelBuilder.Entity("AdaShopping.Models.Sepet", b =>
                {
                    b.Navigation("SepetUrun");
                });
#pragma warning restore 612, 618
        }
    }
}
