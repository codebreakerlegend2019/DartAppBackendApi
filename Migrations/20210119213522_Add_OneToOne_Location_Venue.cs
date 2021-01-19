using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Add_OneToOne_Location_Venue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Venues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venues_LocationId",
                table: "Venues",
                column: "LocationId");

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
                name: "FK_Venues_Locations_LocationId",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Venues_LocationId",
                table: "Venues");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Venues");
        }
    }
}
