using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evoWatch.Database.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAndConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_MoviesAndEpisodes_MoviesAndEpisodesId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleMoviesConnection_MoviesAndEpisodes_MoviesAndEpisodesiD",
                table: "PeopleMoviesConnection");

            migrationBuilder.RenameColumn(
                name: "Episodes",
                table: "Seasons",
                newName: "EpisodeCount");

            migrationBuilder.RenameColumn(
                name: "MoviesAndEpisodesiD",
                table: "PeopleMoviesConnection",
                newName: "EpisodesId");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleMoviesConnection_MoviesAndEpisodesiD",
                table: "PeopleMoviesConnection",
                newName: "IX_PeopleMoviesConnection_EpisodesId");

            migrationBuilder.RenameColumn(
                name: "MoviesAndEpisodesId",
                table: "Characters",
                newName: "EpisodesId");

            migrationBuilder.RenameColumn(
                name: "MovieCharacterName",
                table: "Characters",
                newName: "CharacterName");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_MoviesAndEpisodesId",
                table: "Characters",
                newName: "IX_Characters_EpisodesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_MoviesAndEpisodes_EpisodesId",
                table: "Characters",
                column: "EpisodesId",
                principalTable: "MoviesAndEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleMoviesConnection_MoviesAndEpisodes_EpisodesId",
                table: "PeopleMoviesConnection",
                column: "EpisodesId",
                principalTable: "MoviesAndEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_MoviesAndEpisodes_EpisodesId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleMoviesConnection_MoviesAndEpisodes_EpisodesId",
                table: "PeopleMoviesConnection");

            migrationBuilder.RenameColumn(
                name: "EpisodeCount",
                table: "Seasons",
                newName: "Episodes");

            migrationBuilder.RenameColumn(
                name: "EpisodesId",
                table: "PeopleMoviesConnection",
                newName: "MoviesAndEpisodesiD");

            migrationBuilder.RenameIndex(
                name: "IX_PeopleMoviesConnection_EpisodesId",
                table: "PeopleMoviesConnection",
                newName: "IX_PeopleMoviesConnection_MoviesAndEpisodesiD");

            migrationBuilder.RenameColumn(
                name: "EpisodesId",
                table: "Characters",
                newName: "MoviesAndEpisodesId");

            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "Characters",
                newName: "MovieCharacterName");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_EpisodesId",
                table: "Characters",
                newName: "IX_Characters_MoviesAndEpisodesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_MoviesAndEpisodes_MoviesAndEpisodesId",
                table: "Characters",
                column: "MoviesAndEpisodesId",
                principalTable: "MoviesAndEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleMoviesConnection_MoviesAndEpisodes_MoviesAndEpisodesiD",
                table: "PeopleMoviesConnection",
                column: "MoviesAndEpisodesiD",
                principalTable: "MoviesAndEpisodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
