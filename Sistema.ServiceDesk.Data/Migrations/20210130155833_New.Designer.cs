﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema.ServiceDesk.Data.Context;

namespace Sistema.ServiceDesk.Data.Migrations
{
    [DbContext(typeof(_Context))]
    [Migration("20210130155833_New")]
    partial class New
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Sistema.ServiceDesk.Data.Tabelas.TblFilial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("estabelecimento")
                        .HasColumnType("int");

                    b.Property<string>("filial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Filiais");
                });

            modelBuilder.Entity("Sistema.ServiceDesk.Data.TblDeltaLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("acao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("analista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("imei")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("motorista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("problema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shift")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AtendimentosDeltaLog");
                });

            modelBuilder.Entity("Sistema.ServiceDesk.Data.TblGeral", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("analista")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nomeDoUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ticket")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("AtendimentosGerais");
                });
#pragma warning restore 612, 618
        }
    }
}
