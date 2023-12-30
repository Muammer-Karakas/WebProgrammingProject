﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebProje.Utility;

#nullable disable

namespace WebProje.Migrations
{
    [DbContext(typeof(HastaneRandevuDbContext))]
    [Migration("20231225174309_vtreinstallislemi")]
    partial class vtreinstallislemi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebProje.Models.DoktorlarTablosu", b =>
                {
                    b.Property<int>("DoktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoktorId"), 1L, 1);

                    b.Property<TimeSpan>("BaslamaSaati")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("BitisSaati")
                        .HasColumnType("time");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GunHafta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlinikId")
                        .HasColumnType("int");

                    b.Property<string>("Uzmanlik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoktorId");

                    b.HasIndex("KlinikId");

                    b.ToTable("DoktorlarTablosu");
                });

            modelBuilder.Entity("WebProje.Models.KlinikTuru", b =>
                {
                    b.Property<int>("KlinikTuruId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlinikTuruId"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("KlinikTuruId");

                    b.ToTable("KlinikTurleri");
                });

            modelBuilder.Entity("WebProje.Models.DoktorlarTablosu", b =>
                {
                    b.HasOne("WebProje.Models.KlinikTuru", "KlinikTuru")
                        .WithMany()
                        .HasForeignKey("KlinikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KlinikTuru");
                });
#pragma warning restore 612, 618
        }
    }
}