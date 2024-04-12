using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProjectX.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class CountryTileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTileData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Capital = table.Column<string>(type: "text", nullable: false),
                    XCapitalTileCoordinate = table.Column<int>(type: "integer", nullable: false),
                    YCapitalTileCoordinate = table.Column<int>(type: "integer", nullable: false),
                    ZCapitalTileCoordinate = table.Column<int>(type: "integer", nullable: false),
                    RColor = table.Column<byte>(type: "smallint", nullable: false),
                    GColor = table.Column<byte>(type: "smallint", nullable: false),
                    BColor = table.Column<byte>(type: "smallint", nullable: false),
                    AColor = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTileData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTileData");
        }
    }
}
