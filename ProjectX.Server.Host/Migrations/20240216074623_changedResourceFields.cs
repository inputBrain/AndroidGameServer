using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectX.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class changedResourceFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResourceType",
                table: "Resource",
                newName: "Silver");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Resource",
                newName: "Gold");

            migrationBuilder.AddColumn<int>(
                name: "Bronze",
                table: "Resource",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonatCrystal",
                table: "Resource",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bronze",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "DonatCrystal",
                table: "Resource");

            migrationBuilder.RenameColumn(
                name: "Silver",
                table: "Resource",
                newName: "ResourceType");

            migrationBuilder.RenameColumn(
                name: "Gold",
                table: "Resource",
                newName: "Amount");
        }
    }
}
