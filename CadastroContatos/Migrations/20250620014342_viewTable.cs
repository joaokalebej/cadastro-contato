using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroContatos.Migrations
{
    /// <inheritdoc />
    public partial class viewTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                                 DROP VIEW IF EXISTS "v_consultacontatos";
                                 
                                 CREATE VIEW "v_consultacontatos" AS 
                                 SELECT ctt."Id",
                                        ctt."Nome",
                                        ctt."TelefoneComercial",
                                        ctt."TelefonePessoal",
                                        ctt."DataInclusao",
                                        ctt."Empresa",
                                        string_agg(cte."Email", ',' ORDER BY cte."Email") AS "Emails"
                                   FROM contatos ctt
                                   JOIN contatoemail cte ON cte."ContatoId" = ctt."Id"
                                 GROUP BY ctt."Id", ctt."Nome", ctt."TelefoneComercial", ctt."TelefonePessoal",
                                          ctt."DataInclusao", ctt."Empresa";
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
