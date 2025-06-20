using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class addView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                 DROP VIEW IF EXISTS "v_consultacontatos";
                                 
                                 CREATE VIEW "v_consultacontatos" AS SELECT DISTINCT
                                 ctt."Id",
                                 ctt."Nome",
                                 ctt."TelefoneComercial",
                                 ctt."TelefonePessoal",
                                 ctt."DataInclusao",
                                 ctt."Empresa" 
                                 FROM
                                   contatos ctt
                                   JOIN contatoemail cte ON cte."ContatoId" = ctt."Id" 
                                 WHERE
                                   ctt."Id" IS NOT NULL
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
