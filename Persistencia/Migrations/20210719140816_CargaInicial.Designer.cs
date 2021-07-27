﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia;

namespace Persistencia.Migrations
{
    [DbContext(typeof(PrestamoContex))]
    [Migration("20210719140816_CargaInicial")]
    partial class CargaInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Modelo.ControlPrestamo.Cliente", b =>
                {
                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.HasKey("ClienteId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Configuracion", b =>
                {
                    b.Property<int>("ConfiguracionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MontoMaximoCredito")
                        .HasColumnType("int");

                    b.Property<string>("NombreOrganizacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlazoMaximoCredito")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConfiguracionId");

                    b.ToTable("configuracions");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Credito", b =>
                {
                    b.Property<int>("CreditoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("ClienteId1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaCredito")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrecuenciaPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlazoAnios")
                        .HasColumnType("int");

                    b.Property<int>("TablaAmortizacionID")
                        .HasColumnType("int");

                    b.Property<int>("TipoCreditoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorCredito")
                        .HasColumnType("float");

                    b.HasKey("CreditoId");

                    b.HasIndex("ClienteId1");

                    b.HasIndex("TablaAmortizacionID");

                    b.HasIndex("TipoCreditoId");

                    b.ToTable("creditos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Morosidad", b =>
                {
                    b.Property<int>("MorosidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiasAtraso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Interes")
                        .HasColumnType("int");

                    b.HasKey("MorosidadId");

                    b.ToTable("Morosidad");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MorosidadId")
                        .HasColumnType("int");

                    b.Property<int>("TipoPagoId")
                        .HasColumnType("int");

                    b.Property<double>("ValorPago")
                        .HasColumnType("float");

                    b.HasKey("PagoId");

                    b.HasIndex("CreditoId");

                    b.HasIndex("MorosidadId");

                    b.HasIndex("TipoPagoId");

                    b.ToTable("pagos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TablaAmortizacion", b =>
                {
                    b.Property<int>("TablaAmortizacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TablaAmortizacionId");

                    b.ToTable("tablaAmortizacions");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TipoCredito", b =>
                {
                    b.Property<int>("tipoCreditoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConfiguracionId")
                        .HasColumnType("int");

                    b.Property<double>("interes")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tipoCreditoId");

                    b.HasIndex("ConfiguracionId");

                    b.ToTable("tipoCreditos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TipoPago", b =>
                {
                    b.Property<int>("TipoPagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoPagoId");

                    b.ToTable("tipoPagos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Credito", b =>
                {
                    b.HasOne("Modelo.ControlPrestamo.Cliente", "Cliente")
                        .WithMany("Credito")
                        .HasForeignKey("ClienteId1");

                    b.HasOne("Modelo.ControlPrestamo.TablaAmortizacion", "TablaAmortizacion")
                        .WithMany("Creditos")
                        .HasForeignKey("TablaAmortizacionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.ControlPrestamo.TipoCredito", "TipoCredito")
                        .WithMany("Creditos")
                        .HasForeignKey("TipoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("TablaAmortizacion");

                    b.Navigation("TipoCredito");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Pago", b =>
                {
                    b.HasOne("Modelo.ControlPrestamo.Credito", "Credito")
                        .WithMany("Pagos")
                        .HasForeignKey("CreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Modelo.ControlPrestamo.Morosidad", "Morosidad")
                        .WithMany("Pagos")
                        .HasForeignKey("MorosidadId");

                    b.HasOne("Modelo.ControlPrestamo.TipoPago", "TipoPago")
                        .WithMany("Pagos")
                        .HasForeignKey("TipoPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credito");

                    b.Navigation("Morosidad");

                    b.Navigation("TipoPago");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TipoCredito", b =>
                {
                    b.HasOne("Modelo.ControlPrestamo.Configuracion", null)
                        .WithMany("TipoCreditos")
                        .HasForeignKey("ConfiguracionId");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Cliente", b =>
                {
                    b.Navigation("Credito");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Configuracion", b =>
                {
                    b.Navigation("TipoCreditos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Credito", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.Morosidad", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TablaAmortizacion", b =>
                {
                    b.Navigation("Creditos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TipoCredito", b =>
                {
                    b.Navigation("Creditos");
                });

            modelBuilder.Entity("Modelo.ControlPrestamo.TipoPago", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
