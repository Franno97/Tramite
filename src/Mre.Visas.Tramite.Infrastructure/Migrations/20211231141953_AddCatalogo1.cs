using Microsoft.EntityFrameworkCore.Migrations;

namespace Mre.Visas.Tramite.Infrastructure.Migrations
{
    public partial class AddCatalogo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoConvenioCodigo",
                table: "ActividadDesarrollar",
                newName: "TipoVisaCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoVisaCodigo",
                table: "ActividadDesarrollar",
                newName: "TipoConvenioCodigo");
        }
    }
}
