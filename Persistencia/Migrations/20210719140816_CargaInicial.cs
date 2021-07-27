using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class CargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    ClienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "configuracions",
                columns: table => new
                {
                    ConfiguracionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreOrganizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoMaximoCredito = table.Column<int>(type: "int", nullable: false),
                    PlazoMaximoCredito = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracions", x => x.ConfiguracionId);
                });

            migrationBuilder.CreateTable(
                name: "Morosidad",
                columns: table => new
                {
                    MorosidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasAtraso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Morosidad", x => x.MorosidadId);
                });

            migrationBuilder.CreateTable(
                name: "tablaAmortizacions",
                columns: table => new
                {
                    TablaAmortizacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tablaAmortizacions", x => x.TablaAmortizacionId);
                });

            migrationBuilder.CreateTable(
                name: "tipoPagos",
                columns: table => new
                {
                    TipoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoPagos", x => x.TipoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "tipoCreditos",
                columns: table => new
                {
                    tipoCreditoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    interes = table.Column<double>(type: "float", nullable: false),
                    ConfiguracionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoCreditos", x => x.tipoCreditoId);
                    table.ForeignKey(
                        name: "FK_tipoCreditos_configuracions_ConfiguracionId",
                        column: x => x.ConfiguracionId,
                        principalTable: "configuracions",
                        principalColumn: "ConfiguracionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "creditos",
                columns: table => new
                {
                    CreditoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCredito = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoCreditoId = table.Column<int>(type: "int", nullable: false),
                    TablaAmortizacionID = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaPago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorCredito = table.Column<double>(type: "float", nullable: false),
                    PlazoAnios = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditos", x => x.CreditoId);
                    table.ForeignKey(
                        name: "FK_creditos_clientes_ClienteId1",
                        column: x => x.ClienteId1,
                        principalTable: "clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_creditos_tablaAmortizacions_TablaAmortizacionID",
                        column: x => x.TablaAmortizacionID,
                        principalTable: "tablaAmortizacions",
                        principalColumn: "TablaAmortizacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_creditos_tipoCreditos_TipoCreditoId",
                        column: x => x.TipoCreditoId,
                        principalTable: "tipoCreditos",
                        principalColumn: "tipoCreditoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPagoId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorPago = table.Column<double>(type: "float", nullable: false),
                    CreditoId = table.Column<int>(type: "int", nullable: false),
                    MorosidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_pagos_creditos_CreditoId",
                        column: x => x.CreditoId,
                        principalTable: "creditos",
                        principalColumn: "CreditoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pagos_Morosidad_MorosidadId",
                        column: x => x.MorosidadId,
                        principalTable: "Morosidad",
                        principalColumn: "MorosidadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_pagos_tipoPagos_TipoPagoId",
                        column: x => x.TipoPagoId,
                        principalTable: "tipoPagos",
                        principalColumn: "TipoPagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_creditos_ClienteId1",
                table: "creditos",
                column: "ClienteId1");

            migrationBuilder.CreateIndex(
                name: "IX_creditos_TablaAmortizacionID",
                table: "creditos",
                column: "TablaAmortizacionID");

            migrationBuilder.CreateIndex(
                name: "IX_creditos_TipoCreditoId",
                table: "creditos",
                column: "TipoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_CreditoId",
                table: "pagos",
                column: "CreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_MorosidadId",
                table: "pagos",
                column: "MorosidadId");

            migrationBuilder.CreateIndex(
                name: "IX_pagos_TipoPagoId",
                table: "pagos",
                column: "TipoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_tipoCreditos_ConfiguracionId",
                table: "tipoCreditos",
                column: "ConfiguracionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "creditos");

            migrationBuilder.DropTable(
                name: "Morosidad");

            migrationBuilder.DropTable(
                name: "tipoPagos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "tablaAmortizacions");

            migrationBuilder.DropTable(
                name: "tipoCreditos");

            migrationBuilder.DropTable(
                name: "configuracions");
        }
    }
}
