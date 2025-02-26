using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bilblioteca_LopezJuan.Migrations
{
    /// <inheritdoc />
    public partial class biblioteca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_FkRol",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "PkRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_roles_FkRol",
                table: "Usuario",
                column: "FkRol",
                principalTable: "roles",
                principalColumn: "PkRol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_roles_FkRol",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "Rol");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "PkRol");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_FkRol",
                table: "Usuario",
                column: "FkRol",
                principalTable: "Rol",
                principalColumn: "PkRol",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
