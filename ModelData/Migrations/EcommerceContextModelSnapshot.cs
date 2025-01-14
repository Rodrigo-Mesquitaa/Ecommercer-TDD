﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelData.Context;
using System;

namespace ModelData.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModelData.Model.Categoria", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("DataDeCriacao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeEdicao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeRemocao")
                    .HasColumnType("datetime2");

                b.Property<string>("ImagemURL")
                    .IsRequired()
                    .HasColumnType("nvarchar(1000)")
                    .HasMaxLength(1000);

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("nvarchar(400)")
                    .HasMaxLength(400);

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Categoria");
            });

            modelBuilder.Entity("ModelData.Model.Cliente", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime>("DataDeCriacao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeEdicao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeRemocao")
                    .HasColumnType("datetime2");

                b.Property<string>("Nome")
                    .HasColumnType("nvarchar(400)")
                    .HasMaxLength(400);

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.ToTable("Cliente");
            });

            modelBuilder.Entity("ModelData.Model.Disco", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<long>("Categoria_Id")
                    .HasColumnType("bigint");

                b.Property<DateTime>("DataDeCriacao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeEdicao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeRemocao")
                    .HasColumnType("datetime2");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("nvarchar(400)")
                    .HasMaxLength(400);

                b.Property<decimal>("Preco")
                    .HasColumnType("decimal(10,2)");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("Categoria_Id");

                b.ToTable("Disco");
            });

            modelBuilder.Entity("ModelData.Model.Venda", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<decimal>("CashBackTotal")
                    .HasColumnType("decimal(10,2)");

                b.Property<long>("Cliente_Id")
                    .HasColumnType("bigint");

                b.Property<DateTime>("DataDeCriacao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeEdicao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeRemocao")
                    .HasColumnType("datetime2");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("Cliente_Id");

                b.ToTable("Venda");
            });

            modelBuilder.Entity("ModelData.Model.VendaItem", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("bigint")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<decimal>("CashBackUnitario")
                    .HasColumnType("decimal(10,2)");

                b.Property<DateTime>("DataDeCriacao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeEdicao")
                    .HasColumnType("datetime2");

                b.Property<DateTime?>("DataDeRemocao")
                    .HasColumnType("datetime2");

                b.Property<long>("Disco_Id")
                    .HasColumnType("bigint");

                b.Property<decimal>("PrecoUnitario")
                    .HasColumnType("decimal(10,2)");

                b.Property<int>("Quantidade")
                    .HasColumnType("int");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.Property<long>("Venda_Id")
                    .HasColumnType("bigint");

                b.HasKey("Id");

                b.HasIndex("Disco_Id");

                b.HasIndex("Venda_Id");

                b.ToTable("VendaItem");
            });

            modelBuilder.Entity("ModelData.Model.Disco", b =>
            {
                b.HasOne("ModelData.Model.Categoria", "Categoria")
                    .WithMany()
                    .HasForeignKey("Categoria_Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ModelData.Model.Venda", b =>
            {
                b.HasOne("ModelData.Model.Cliente", "Cliente")
                    .WithMany()
                    .HasForeignKey("Cliente_Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("ModelData.Model.VendaItem", b =>
            {
                b.HasOne("ModelData.Model.Disco", "Disco")
                    .WithMany()
                    .HasForeignKey("Disco_Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ModelData.Model.Venda", "Venda")
                    .WithMany("Itens")
                    .HasForeignKey("Venda_Id")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
