using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditoCarteraAdmin_AbInBev.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarteraAnalytics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    NumeroCelular = table.Column<string>(nullable: true),
                    ValorCartera = table.Column<string>(nullable: true),
                    FechaVencimiento = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false),
                    SmsEnviados = table.Column<int>(nullable: false),
                    LlamadasHechas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarteraAnalytics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditoNuevo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(nullable: true),
                    CreditoAnterior = table.Column<int>(nullable: false),
                    CreditoNuevo = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ClienteNuevo = table.Column<bool>(nullable: false),
                    StatusCreditoNuevo = table.Column<bool>(nullable: false),
                    NumeroCelular = table.Column<string>(nullable: true),
                    NumeroEnvios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditoNuevo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrecuenciaNotificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCampaña = table.Column<string>(nullable: false),
                    DiasPrevios = table.Column<int>(nullable: false),
                    NumeroEnvios = table.Column<int>(nullable: false),
                    HoraEnvio = table.Column<string>(nullable: true),
                    CadaMinuto = table.Column<int>(nullable: false),
                    CadaHora = table.Column<int>(nullable: false),
                    RondasEnviadas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrecuenciaNotificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LlamadaNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false),
                    BlobStorageURL = table.Column<string>(nullable: false),
                    DiasPrevios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LlamadaNotificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MensajeNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false),
                    Mensaje = table.Column<string>(nullable: false),
                    DiasPrevios = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajeNotificacion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarteraAnalytics");

            migrationBuilder.DropTable(
                name: "CreditoNuevo");

            migrationBuilder.DropTable(
                name: "FrecuenciaNotificaciones");

            migrationBuilder.DropTable(
                name: "LlamadaNotificacion");

            migrationBuilder.DropTable(
                name: "MensajeNotificacion");
        }
    }
}
