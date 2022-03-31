﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mre.Visas.Tramite.Infrastructure.Migrations
{
    public partial class AddConfiguracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configuracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfiguracionCodigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ValorCadena = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorEntero = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuracion", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuracion");
        }
    }
}
