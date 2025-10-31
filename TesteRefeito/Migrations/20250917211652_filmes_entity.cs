using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteRefeito.Migrations
{
    /// <inheritdoc />
    public partial class filmes_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diretor",
                table: "Filmes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duracao",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FaixaEtaria",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diretor",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "Duracao",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "FaixaEtaria",
                table: "Filmes");
        }
    }
}
