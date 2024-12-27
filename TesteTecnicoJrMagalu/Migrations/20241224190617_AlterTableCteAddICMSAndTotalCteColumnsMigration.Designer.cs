﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TesteTecnicoJrMagalu.Database;

#nullable disable

namespace TesteTecnicoJrMagalu.Migrations
{
    [DbContext(typeof(ConnectionContext))]
    [Migration("20241224190617_AlterTableCteAddICMSAndTotalCteColumnsMigration")]
    partial class AlterTableCteAddICMSAndTotalCteColumnsMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TesteTecnicoJrMagalu.Models.Cte", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("ICMS_CST")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ICMS_pICMS")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ICMS_vBC")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ICMS_vICMS")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TOTALvCTe")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TOTALvFrete")
                        .HasColumnType("numeric");

                    b.Property<int>("det_cMunFim")
                        .HasColumnType("integer");

                    b.Property<int?>("det_cMunIni")
                        .HasColumnType("integer");

                    b.Property<string>("det_xMunFim")
                        .HasColumnType("text");

                    b.Property<string>("det_xMunIni")
                        .HasColumnType("text");

                    b.Property<string>("ide_UFFim")
                        .HasColumnType("text");

                    b.Property<string>("ide_UFIni")
                        .HasColumnType("text");

                    b.Property<int>("ide_cMunEnv")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ide_dhEmi")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("ide_dist_KM")
                        .HasColumnType("numeric");

                    b.Property<string>("ide_xMunEnv")
                        .HasColumnType("text");

                    b.Property<decimal>("vFretePorTonelada")
                        .HasColumnType("numeric");

                    b.Property<decimal>("vOutrasDesp")
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.ToTable("Cte");
                });

            modelBuilder.Entity("TesteTecnicoJrMagalu.Models.CteInfCargaInfQ", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("id_cte")
                        .HasColumnType("integer");

                    b.Property<string>("infCarga_infQ_cUnid")
                        .HasColumnType("text");

                    b.Property<decimal?>("infCarga_infQ_qCarga")
                        .HasColumnType("numeric");

                    b.Property<string>("infCarga_infQ_tpMed")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("CteInfCargaInfQ");
                });
#pragma warning restore 612, 618
        }
    }
}