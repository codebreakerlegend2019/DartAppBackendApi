using Microsoft.EntityFrameworkCore.Migrations;

namespace DartAppSingapore.Migrations
{
    public partial class Rename_DateTimCreated_To_DateTimeCreated_Profiles_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimCreated",
                table: "Profiles",
                newName: "DateTimeCreated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "Profiles",
                newName: "DateTimCreated");
        }
    }
}
