using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mre.Visas.Tramite.Infrastructure.Migrations
{
    public partial class AddCatalogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoporteGestiones_Tramites_TramiteId",
                table: "SoporteGestiones");

            migrationBuilder.AlterColumn<Guid>(
                name: "TramiteId",
                table: "SoporteGestiones",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ActividadDesarrollar",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoConvenioCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ActividadDesarrollarCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadDesarrollar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalidadMigratoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalidadMigratoriaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalidadMigratoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoConvenio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoConvenioCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConvenio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoVisa",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoConvenioCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoVisaCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVisa", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SoporteGestiones_Tramites_TramiteId",
                table: "SoporteGestiones",
                column: "TramiteId",
                principalTable: "Tramites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoporteGestiones_Tramites_TramiteId",
                table: "SoporteGestiones");

            migrationBuilder.DropTable(
                name: "ActividadDesarrollar");

            migrationBuilder.DropTable(
                name: "CalidadMigratoria");

            migrationBuilder.DropTable(
                name: "TipoConvenio");

            migrationBuilder.DropTable(
                name: "TipoVisa");

            migrationBuilder.AlterColumn<Guid>(
                name: "TramiteId",
                table: "SoporteGestiones",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_SoporteGestiones_Tramites_TramiteId",
                table: "SoporteGestiones",
                column: "TramiteId",
                principalTable: "Tramites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
