﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP_Web.Models;

namespace TP_Web.Migrations.ContexteAutoLocoMigrations
{
    [DbContext(typeof(ContexteAutoLoco))]
    partial class ContexteAutoLocoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TP_Web.Models.Succursale", b =>
                {
                    b.Property<int>("SuccursaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CodeSuccursale")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("NomProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomRue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomVille")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("NuméroCivique")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("NuméroTéléphone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuccursaleId");

                    b.ToTable("Succursales");
                });

            modelBuilder.Entity("TP_Web.Models.Voiture", b =>
                {
                    b.Property<long>("VoitureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Année")
                        .HasColumnType("int");

                    b.Property<bool>("EstDisponible")
                        .HasColumnType("bit");

                    b.Property<int>("Groupe")
                        .HasColumnType("int");

                    b.Property<long>("Millage")
                        .HasColumnType("bigint");

                    b.Property<string>("Modèle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NuméroVoiture")
                        .HasColumnType("bigint");

                    b.Property<int?>("SuccursaleId")
                        .HasColumnType("int");

                    b.HasKey("VoitureId");

                    b.HasIndex("SuccursaleId");

                    b.ToTable("Voitures");
                });

            modelBuilder.Entity("TP_Web.Models.Voiture", b =>
                {
                    b.HasOne("TP_Web.Models.Succursale", "Succursale")
                        .WithMany("Voitures")
                        .HasForeignKey("SuccursaleId");
                });
#pragma warning restore 612, 618
        }
    }
}
