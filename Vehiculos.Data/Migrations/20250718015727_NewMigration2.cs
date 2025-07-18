using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehiculos.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuariaId",
                table: "Usuarios",
                newName: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Usuarios",
                newName: "UsuariaId");
        }
    }
}
