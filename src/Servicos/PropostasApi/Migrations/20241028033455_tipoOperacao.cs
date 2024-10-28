using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostasApi.Migrations
{
    /// <inheritdoc />
    public partial class tipoOperacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoOperacao",
                table: "PropostasCredito",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoOperacao",
                table: "PropostasCredito");
        }
    }
}
