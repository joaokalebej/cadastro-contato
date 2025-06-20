using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class CreateContatoEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "contatos");

            migrationBuilder.RenameColumn(
                name: "Excluir",
                table: "contatos",
                newName: "Excluido");

            migrationBuilder.CreateTable(
                name: "contatoemail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContatoId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Excluido = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contatoemail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contatoemail_contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "contatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contatoemail_ContatoId",
                table: "contatoemail",
                column: "ContatoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contatoemail");

            migrationBuilder.RenameColumn(
                name: "Excluido",
                table: "contatos",
                newName: "Excluir");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "contatos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
