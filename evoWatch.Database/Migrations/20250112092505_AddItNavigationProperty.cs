using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evoWatch.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddItNavigationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "MoviesAndEpisodes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesAndEpisodes_PersonId",
                table: "MoviesAndEpisodes",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesAndEpisodes_People_PersonId",
                table: "MoviesAndEpisodes",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesAndEpisodes_People_PersonId",
                table: "MoviesAndEpisodes");

            migrationBuilder.DropIndex(
                name: "IX_MoviesAndEpisodes_PersonId",
                table: "MoviesAndEpisodes");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MoviesAndEpisodes");
        }
    }
}
