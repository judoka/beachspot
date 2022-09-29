using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeachSpot.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sightings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BeachId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Quote = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sightings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sightings_Beaches_BeachId",
                        column: x => x.BeachId,
                        principalTable: "Beaches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sightings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SightingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Sightings_SightingId",
                        column: x => x.SightingId,
                        principalTable: "Sightings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beaches",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("111e20b0-aac8-4a00-a578-234526349ac0"), "The Zlatni Rat, often referred to as the Golden Cape or Golden Horn (translated from the local Chakavian dialect), is a spit of land located about 2 kilometres (1 mile) west from the harbour town of Bol on the southern coast of the Croatian island of Brač, in the region of Dalmatia.", "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1c/Golden_Cape.jpg/260px-Golden_Cape.jpg", "Zlatni Rat" },
                    { new Guid("b76d2f50-81b3-479a-949e-b17d9a2d557d"), "Venice is a neighborhood of the city of Los Angeles within the Westside region of Los Angeles County, California.", "https://en.wikipedia.org/wiki/File:Beach_bikepath_in_the_Venice_Beach_park,_California.jpg", "Venice" },
                    { new Guid("f8aeab83-385d-4462-988f-d232bbf5727d"), "Copacabana (Portuguese pronunciation: [kɔpakaˈbɐ̃nɐ]) is a bairro (neighbourhood) located in the South Zone of the city of Rio de Janeiro, Brazil. It is most prominently known for its 4 km (2.5 miles) balneario beach, which is one of the most famous in the world.", "https://upload.wikimedia.org/wikipedia/commons/6/62/Praia_de_Copacabana_-_Rio_de_Janeiro%2C_Brasil.jpg", "Copacabana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_SightingId",
                table: "Likes",
                column: "SightingId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_BeachId",
                table: "Sightings",
                column: "BeachId");

            migrationBuilder.CreateIndex(
                name: "IX_Sightings_UserId",
                table: "Sightings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Sightings");

            migrationBuilder.DropTable(
                name: "Beaches");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
