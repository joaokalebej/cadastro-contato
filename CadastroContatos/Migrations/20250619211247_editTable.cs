using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class editTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "contatos");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "contatos");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "contatoemail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "contatos",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "contatos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "contatoemail",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
