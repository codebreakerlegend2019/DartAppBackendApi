using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Add_OneToOne_Zones_Locations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZoneId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ZoneId",
                table: "Locations",
                column: "ZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Zones_ZoneId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_ZoneId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ZoneId",
                table: "Locations");
        }
    }
}
