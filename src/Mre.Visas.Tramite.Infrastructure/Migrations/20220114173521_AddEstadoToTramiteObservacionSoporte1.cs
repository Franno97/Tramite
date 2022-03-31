using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mre.Visas.Tramite.Infrastructure.Migrations
{
    public partial class AddEstadoToTramiteObservacionSoporte1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnidadAdministrativaNombre",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "Cedula",
                table: "Solicitantes",
                newName: "Identificacion");

            migrationBuilder.AddColumn<bool>(
                name: "ConfirmacionVisa",
                table: "Visas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPais",
                table: "Tramites",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicioId",
                table: "Tramites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UnidadAdministrativaIdCEV",
                table: "Tramites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UnidadAdministrativaIdZonal",
                table: "Tramites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "SoporteGestiones",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Solicitantes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoIdentificacion",
                table: "Solicitantes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoDesistir",
                table: "RolEstado",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiasTranscurridos",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FechaCitaDesde",
                table: "Movimientos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaCitaHasta",
                table: "Movimientos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEstado",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Beneficiarios",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 2147483647);

            migrationBuilder.CreateTable(
                name: "HistorialMigratorio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApellidosNombres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CategoriaMigratoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoError = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaHoraMovimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Medio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotivoViaje = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NacionalidadDocumentoMovMigra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumentoMovMigra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisDestino = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisResidencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PuertoRegistro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TarjetaAndina = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TiempoDeclarado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoDocumentoMovMigra = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMigratorio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialMigratorio");

            migrationBuilder.DropColumn(
                name: "ConfirmacionVisa",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "CodigoPais",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "UnidadAdministrativaIdCEV",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "UnidadAdministrativaIdZonal",
                table: "Tramites");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "SoporteGestiones");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "TipoIdentificacion",
                table: "Solicitantes");

            migrationBuilder.DropColumn(
                name: "CodigoDesistir",
                table: "RolEstado");

            migrationBuilder.DropColumn(
                name: "DiasTranscurridos",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "FechaCitaDesde",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "FechaCitaHasta",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "NombreEstado",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Solicitantes",
                newName: "Cedula");

            migrationBuilder.AddColumn<string>(
                name: "UnidadAdministrativaNombre",
                table: "Movimientos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Foto",
                table: "Beneficiarios",
                type: "varbinary(max)",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647);
        }
    }
}
