using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guardadito.Migrations
{
    /// <inheritdoc />
    public partial class fixUserUserRoleRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_UserRole_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
