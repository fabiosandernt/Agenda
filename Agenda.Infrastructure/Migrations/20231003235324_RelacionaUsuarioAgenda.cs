using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agenda.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionaUsuarioAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Agendas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_UsuarioId",
                table: "Agendas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendas_Usuarios_UsuarioId",
                table: "Agendas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendas_Usuarios_UsuarioId",
                table: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Agendas_UsuarioId",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Agendas");
        }
    }
}
