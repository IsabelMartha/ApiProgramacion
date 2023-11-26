using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_programacion_3.Migrations
{
    public partial class Cambios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "TipoProducto");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TipoProducto");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TipoProducto");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TipoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "TipoProducto",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TipoProducto",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "TipoProducto",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TipoProducto",
                type: "longtext",
                nullable: false);
        }
    }
}
