using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace evoWatch.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNotNeededProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleMoviesConnections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleMoviesConnections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EpisodesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersoniD = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleMoviesConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleMoviesConnections_MoviesAndEpisodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "MoviesAndEpisodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleMoviesConnections_People_PersoniD",
                        column: x => x.PersoniD,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleMoviesConnections_EpisodesId",
                table: "PeopleMoviesConnections",
                column: "EpisodesId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleMoviesConnections_PersoniD",
                table: "PeopleMoviesConnections",
                column: "PersoniD");
        }
    }
}
