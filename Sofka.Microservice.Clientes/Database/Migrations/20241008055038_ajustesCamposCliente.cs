using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sofka.Microservice.Clientes.Migrations
{
    /// <inheritdoc />
    public partial class ajustesCamposCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Identificacion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Cliente",
                newName: "Contrasenia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "Cliente",
                newName: "Telefono");

            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Identificacion",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
