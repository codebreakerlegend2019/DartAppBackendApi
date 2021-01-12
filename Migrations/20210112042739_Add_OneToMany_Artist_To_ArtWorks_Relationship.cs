using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Add_OneToMany_Artist_To_ArtWorks_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "ArtWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ArtWorks_ArtistId",
                table: "ArtWorks",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtWorks_Artists_ArtistId",
                table: "ArtWorks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtWorks_Artists_ArtistId",
                table: "ArtWorks");

            migrationBuilder.DropIndex(
                name: "IX_ArtWorks_ArtistId",
                table: "ArtWorks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "ArtWorks");
        }
    }
}
