using Microsoft.EntityFrameworkCore.Migrations;

namespace SWProvincias_Ceschan.Migrations
{
    public partial class CambioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudades_Provincia_ProvinciaId",
                table: "Ciudades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades");

            migrationBuilder.RenameTable(
                name: "Ciudades",
                newName: "Ciudad");

            migrationBuilder.RenameIndex(
                name: "IX_Ciudades_ProvinciaId",
                table: "Ciudad",
                newName: "IX_Ciudad_ProvinciaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad",
                column: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudad_Provincia_ProvinciaId",
                table: "Ciudad",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ciudad_Provincia_ProvinciaId",
                table: "Ciudad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciudad",
                table: "Ciudad");

            migrationBuilder.RenameTable(
                name: "Ciudad",
                newName: "Ciudades");

            migrationBuilder.RenameIndex(
                name: "IX_Ciudad_ProvinciaId",
                table: "Ciudades",
                newName: "IX_Ciudades_ProvinciaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciudades",
                table: "Ciudades",
                column: "IdCiudad");

            migrationBuilder.AddForeignKey(
                name: "FK_Ciudades_Provincia_ProvinciaId",
                table: "Ciudades",
                column: "ProvinciaId",
                principalTable: "Provincia",
                principalColumn: "IdProvincia",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
