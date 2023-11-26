using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_programacion_3.Migrations
{
    public partial class add_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TipoProducto",
                type: "longtext",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TipoProducto");
        }
    }
}
