﻿// <auto-generated />
using System;
using Concessionaria.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Concessionaria.Data.Migrations
{
    [DbContext(typeof(ConcessionariaDbContext))]
    [Migration("20231215130734_AdicionarRelacionamentoCarroOpcional")]
    partial class AdicionarRelacionamentoCarroOpcional
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarroOpcional", b =>
                {
                    b.Property<int>("CarrosId")
                        .HasColumnType("int");

                    b.Property<int>("OpcionaisOpcionalId")
                        .HasColumnType("int");

                    b.HasKey("CarrosId", "OpcionaisOpcionalId");

                    b.HasIndex("OpcionaisOpcionalId");

                    b.ToTable("CarroOpcional");
                });

            modelBuilder.Entity("Concessionaria.Models.Carro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Preco")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Concessionaria.Models.Marca", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarcaId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcaId");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("Concessionaria.Models.Opcional", b =>
                {
                    b.Property<int>("OpcionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OpcionalId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OpcionalId");

                    b.ToTable("Opcional");
                });

            modelBuilder.Entity("CarroOpcional", b =>
                {
                    b.HasOne("Concessionaria.Models.Carro", null)
                        .WithMany()
                        .HasForeignKey("CarrosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Concessionaria.Models.Opcional", null)
                        .WithMany()
                        .HasForeignKey("OpcionaisOpcionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Concessionaria.Models.Carro", b =>
                {
                    b.HasOne("Concessionaria.Models.Marca", null)
                        .WithMany("Carros")
                        .HasForeignKey("MarcaId");
                });

            modelBuilder.Entity("Concessionaria.Models.Marca", b =>
                {
                    b.Navigation("Carros");
                });
#pragma warning restore 612, 618
        }
    }
}
