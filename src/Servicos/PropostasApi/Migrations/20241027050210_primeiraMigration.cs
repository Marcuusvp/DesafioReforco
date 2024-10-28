using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostasApi.Migrations
{
    /// <inheritdoc />
    public partial class primeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CpfCliente = table.Column<string>(type: "VARCHAR(11)", maxLength: 11, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Cep = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(2)", nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropostasCredito",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Rendimento = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    TipoAssinatura = table.Column<int>(type: "int", nullable: false),
                    Agente = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Conveniada = table.Column<string>(type: "VARCHAR(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropostasCredito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropostasCredito_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropostasCredito_EnderecoId",
                table: "PropostasCredito",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropostasCredito");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
