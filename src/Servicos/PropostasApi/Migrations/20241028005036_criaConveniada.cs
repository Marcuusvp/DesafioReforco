using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostasApi.Migrations
{
    /// <inheritdoc />
    public partial class criaConveniada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conveniadas",
                columns: table => new
                {
                    CodigoConveniada = table.Column<string>(type: "VARCHAR(6)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    PermiteRefin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conveniadas", x => x.CodigoConveniada);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conveniadas");
        }
    }
}
