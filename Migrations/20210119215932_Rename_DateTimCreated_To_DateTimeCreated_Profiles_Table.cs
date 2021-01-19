using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Rename_DateTimCreated_To_DateTimeCreated_Profiles_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtwork_Artists_ArtistId",
                table: "ArtistArtwork");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtistArtwork_ArtWorks_ArtworkId",
                table: "ArtistArtwork");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkEvent_ArtWorks_ArtworkId",
                table: "ArtworkEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkEvent_Events_EventId",
                table: "ArtworkEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Locations_LocationId",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "DateTimCreated",
                table: "Profiles",
                newName: "DateTimeCreated");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkEvent_ArtWorks_ArtworkId",
                table: "ArtworkEvent",
                column: "ArtworkId",
                principalTable: "ArtWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkEvent_Events_EventId",
                table: "ArtworkEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Locations_LocationId",
                table: "Venues",
                column: "LocationId",
                principalTable: "Locations",
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

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkEvent_ArtWorks_ArtworkId",
                table: "ArtworkEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtworkEvent_Events_EventId",
                table: "ArtworkEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Venues_Locations_LocationId",
                table: "Venues");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "Profiles",
                newName: "DateTimCreated");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtwork_Artists_ArtistId",
                table: "ArtistArtwork",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistArtwork_ArtWorks_ArtworkId",
                table: "ArtistArtwork",
                column: "ArtworkId",
                principalTable: "ArtWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkEvent_ArtWorks_ArtworkId",
                table: "ArtworkEvent",
                column: "ArtworkId",
                principalTable: "ArtWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtworkEvent_Events_EventId",
                table: "ArtworkEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Venues_VenueId",
                table: "Events",
                column: "VenueId",
                principalTable: "Venues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Venues_Locations_LocationId",
                table: "Venues",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
