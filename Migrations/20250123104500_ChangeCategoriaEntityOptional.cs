using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardadito.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoriaEntityOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias",
                column: "TipoCategoriaId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_CategoryType_TipoCategoriaId",
                table: "Categorias",
                column: "TipoCategoriaId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
