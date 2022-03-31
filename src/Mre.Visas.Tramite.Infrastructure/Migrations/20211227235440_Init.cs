using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mre.Visas.Tramite.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelefonoCelular = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelefonoDomicilio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasaportes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CiudadEmision = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaisEmision = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasaportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolEstado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreEstado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoEstado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigosEstadoSiguiente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solicitantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ConsuladoNombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ConsuladoPais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PoseeVisa = table.Column<bool>(type: "bit", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarnetConadis = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CiudadNacimiento = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CodigoMDG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DomicilioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", maxLength: 2147483647, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PaisNacimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasaporteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PorcentajeDiscapacidad = table.Column<int>(type: "int", nullable: false),
                    PoseeDiscapacidad = table.Column<bool>(type: "bit", nullable: false),
                    PrimerApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VisaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Domicilios_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Pasaportes_PasaporteId",
                        column: x => x.PasaporteId,
                        principalTable: "Pasaportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiarios_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Actividad = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    BeneficiarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalidadMigratoria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grupo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoVisa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramites_Beneficiarios_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "Beneficiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tramites_Solicitantes_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalTable: "Solicitantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Tramites_TramiteId",
                        column: x => x.TramiteId,
                        principalTable: "Tramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Orden = table.Column<int>(type: "int", maxLength: 256, nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadAdministrativaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadAdministrativaNombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Vigente = table.Column<bool>(type: "bit", nullable: false),
                    NombreRol = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ObservacionDatosPersonales = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ObservacionDomicilios = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ObservacionSoportesGestion = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ObservacionMovimientoMigratorio = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ObservacionMultas = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_Tramites_TramiteId",
                        column: x => x.TramiteId,
                        principalTable: "Tramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoporteGestiones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    TramiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoporteGestiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoporteGestiones_Tramites_TramiteId",
                        column: x => x.TramiteId,
                        principalTable: "Tramites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_DomicilioId",
                table: "Beneficiarios",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_PasaporteId",
                table: "Beneficiarios",
                column: "PasaporteId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiarios_VisaId",
                table: "Beneficiarios",
                column: "VisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TramiteId",
                table: "Documentos",
                column: "TramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TramiteId",
                table: "Movimientos",
                column: "TramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SoporteGestiones_TramiteId",
                table: "SoporteGestiones",
                column: "TramiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_BeneficiarioId",
                table: "Tramites",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramites_SolicitanteId",
                table: "Tramites",
                column: "SolicitanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "RolEstado");

            migrationBuilder.DropTable(
                name: "SoporteGestiones");

            migrationBuilder.DropTable(
                name: "Tramites");

            migrationBuilder.DropTable(
                name: "Beneficiarios");

            migrationBuilder.DropTable(
                name: "Solicitantes");

            migrationBuilder.DropTable(
                name: "Domicilios");

            migrationBuilder.DropTable(
                name: "Pasaportes");

            migrationBuilder.DropTable(
                name: "Visas");
        }
    }
}
