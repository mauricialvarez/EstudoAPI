using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FilmesAPI.Migrations
{
    public partial class AdicionandorelacaoentreGerenteeCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteID",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas",
                column: "GerenteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas",
                column: "GerenteID",
                principalTable: "Gerentes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteID",
                table: "Cinemas");
        }
    }
}
