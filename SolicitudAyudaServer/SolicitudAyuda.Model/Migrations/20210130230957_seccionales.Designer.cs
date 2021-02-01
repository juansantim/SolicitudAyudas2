﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SolicitudAyuda.Model;

namespace SolicitudAyuda.Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210130230957_seccionales")]
    partial class seccionales
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Maestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Cargo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimeroApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeccionalId")
                        .HasColumnType("int");

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SeccionalId");

                    b.ToTable("Maestros");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nombre")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Seccional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PresidenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Seccionales");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Maestro", b =>
                {
                    b.HasOne("SolicitudAyuda.Model.Entities.Seccional", "Seccional")
                        .WithMany("Maestros")
                        .HasForeignKey("SeccionalId");

                    b.Navigation("Seccional");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Municipio", b =>
                {
                    b.HasOne("SolicitudAyuda.Model.Entities.Provincia", "Provincia")
                        .WithMany("Municipios")
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Seccional", b =>
                {
                    b.HasOne("SolicitudAyuda.Model.Entities.Municipio", "Municipio")
                        .WithMany()
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Provincia", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("SolicitudAyuda.Model.Entities.Seccional", b =>
                {
                    b.Navigation("Maestros");
                });
#pragma warning restore 612, 618
        }
    }
}
