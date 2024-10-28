using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PropostasApi.Migrations
{
    /// <inheritdoc />
    public partial class terceiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "PropostasCredito",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumeroParcelas",
                table: "PropostasCredito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "UltimaParcela",
                table: "PropostasCredito",
                type: "DATE",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "PropostasCredito");

            migrationBuilder.DropColumn(
                name: "NumeroParcelas",
                table: "PropostasCredito");

            migrationBuilder.DropColumn(
                name: "UltimaParcela",
                table: "PropostasCredito");
        }
    }
}
