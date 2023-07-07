using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VinylTap.Migrations
{
    /// <inheritdoc />
    public partial class mgwconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlbumArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumArtist = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumYear = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumName = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumDescription = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumGenre = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumLabel = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumCover = table.Column<string>(type: "TEXT", nullable: true),
                    NumAlbumsAvailableForSale = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: true),
                    AlbumPrice = table.Column<double>(type: "REAL", nullable: true),
                    CurrencyType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConsumerKey = table.Column<string>(type: "TEXT", nullable: false),
                    ConsumerSecret = table.Column<string>(type: "TEXT", nullable: false),
                    OAuthToken = table.Column<string>(type: "TEXT", nullable: false),
                    OAuthTokenSecret = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_AlbumId",
                table: "Albums",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
