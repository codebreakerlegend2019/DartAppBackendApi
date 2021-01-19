using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Add_ManyToMany_ArtworksToEvent_And_Add_ArtworkEvents_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtworks_Artists_ArtistId",
                table: "ArtistArtworks");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtworks_ArtWorks_ArtworkId",
                table: "ArtistArtworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistArtworks",
                table: "ArtistArtworks");

            migrationBuilder.RenameTable(
                name: "ArtistArtworks",
                newName: "ArtistArtwork");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistArtworks_ArtistId",
                table: "ArtistArtwork",
                newName: "IX_ArtistArtwork_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistArtwork",
                table: "ArtistArtwork",
                columns: new[] { "ArtworkId", "ArtistId" });

            migrationBuilder.CreateTable(
                name: "ArtworkEvent",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworkEvent", x => new { x.ArtworkId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ArtworkEvent_ArtWorks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "ArtWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArtworkEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtworkEvent_EventId",
                table: "ArtworkEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtwork_Artists_ArtistId",
                table: "ArtistArtwork",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtwork_ArtWorks_ArtworkId",
                table: "ArtistArtwork",
                column: "ArtworkId",
                principalTable: "ArtWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtwork_Artists_ArtistId",
                table: "ArtistArtwork");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtwork_ArtWorks_ArtworkId",
                table: "ArtistArtwork");

            migrationBuilder.DropTable(
                name: "ArtworkEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistArtwork",
                table: "ArtistArtwork");

            migrationBuilder.RenameTable(
                name: "ArtistArtwork",
                newName: "ArtistArtworks");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistArtwork_ArtistId",
                table: "ArtistArtworks",
                newName: "IX_ArtistArtworks_ArtistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistArtworks",
                table: "ArtistArtworks",
                columns: new[] { "ArtworkId", "ArtistId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtworks_Artists_ArtistId",
                table: "ArtistArtworks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtworks_ArtWorks_ArtworkId",
                table: "ArtistArtworks",
                column: "ArtworkId",
                principalTable: "ArtWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
