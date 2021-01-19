using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Add_ManyToMany_Artist_To_ArtWorks_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistArtworks",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistArtworks", x => new { x.ArtworkId, x.ArtistId });
                    table.ForeignKey(
                        name: "FK_ArtistArtworks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtistArtworks_ArtWorks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "ArtWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistArtworks_ArtistId",
                table: "ArtistArtworks",
                column: "ArtistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistArtworks");
        }
    }
}
