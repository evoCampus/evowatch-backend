using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evoWatch.Database.Migrations
{
    /// <inheritdoc />
    public partial class EditEpisodTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EpisodePerson",
                columns: table => new
                {
                    EpisodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodePerson", x => new { x.EpisodesId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_EpisodePerson_MoviesAndEpisodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "MoviesAndEpisodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodePerson_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodePerson_PersonId",
                table: "EpisodePerson",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodePerson");

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
    }
}
