using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class addEmpresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "contatos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "contatos");
        }
    }
}
