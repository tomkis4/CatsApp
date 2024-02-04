using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatsModelEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatsModelEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatsModelEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatImage_CatsModelEntity_CatsModelEntityId",
                        column: x => x.CatsModelEntityId,
                        principalTable: "CatsModelEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGalleryImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CatsModelEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGalleryImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGalleryImage_CatImage_CatImageId",
                        column: x => x.CatImageId,
                        principalTable: "CatImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGalleryImage_CatsModelEntity_CatsModelEntityId",
                        column: x => x.CatsModelEntityId,
                        principalTable: "CatsModelEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatImage_CatsModelEntityId",
                table: "CatImage",
                column: "CatsModelEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGalleryImage_CatImageId",
                table: "UserGalleryImage",
                column: "CatImageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGalleryImage_CatsModelEntityId",
                table: "UserGalleryImage",
                column: "CatsModelEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGalleryImage");

            migrationBuilder.DropTable(
                name: "CatImage");

            migrationBuilder.DropTable(
                name: "CatsModelEntity");
        }
    }
}
