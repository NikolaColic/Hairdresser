using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hair.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetwork",
                columns: table => new
                {
                    SocialNetworkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetwork", x => x.SocialNetworkId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Hairdresser",
                columns: table => new
                {
                    HairdresserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Adress = table.Column<string>(nullable: false),
                    TaxId = table.Column<string>(maxLength: 12, nullable: false),
                    ParentId = table.Column<string>(maxLength: 12, nullable: false),
                    Number = table.Column<string>(nullable: false),
                    Gmail = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Rank = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Pricelist = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    MunicipalityId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairdresser", x => x.HairdresserId);
                    table.ForeignKey(
                        name: "FK_Hairdresser_Municipality_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hairdresser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteHairdresser",
                columns: table => new
                {
                    FavouriteHairdresserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairdresserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteHairdresser", x => x.FavouriteHairdresserId);
                    table.ForeignKey(
                        name: "FK_FavouriteHairdresser_Hairdresser_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdresser",
                        principalColumn: "HairdresserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouriteHairdresser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairdresserImage",
                columns: table => new
                {
                    HairdresserImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairdresserId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairdresserImage", x => x.HairdresserImageId);
                    table.ForeignKey(
                        name: "FK_HairdresserImage_Hairdresser_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdresser",
                        principalColumn: "HairdresserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairdresserId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    Mark = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Hairdresser_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdresser",
                        principalColumn: "HairdresserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialHairdresser",
                columns: table => new
                {
                    SocialHairdresserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HairdresserId = table.Column<int>(nullable: true),
                    SocialNetworkId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHairdresser", x => x.SocialHairdresserId);
                    table.ForeignKey(
                        name: "FK_SocialHairdresser_Hairdresser_HairdresserId",
                        column: x => x.HairdresserId,
                        principalTable: "Hairdresser",
                        principalColumn: "HairdresserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SocialHairdresser_SocialNetwork_SocialNetworkId",
                        column: x => x.SocialNetworkId,
                        principalTable: "SocialNetwork",
                        principalColumn: "SocialNetworkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteHairdresser_HairdresserId",
                table: "FavouriteHairdresser",
                column: "HairdresserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteHairdresser_UserId",
                table: "FavouriteHairdresser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hairdresser_MunicipalityId",
                table: "Hairdresser",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hairdresser_UserId",
                table: "Hairdresser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HairdresserImage_HairdresserId",
                table: "HairdresserImage",
                column: "HairdresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_HairdresserId",
                table: "Reservation",
                column: "HairdresserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserId",
                table: "Reservation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialHairdresser_HairdresserId",
                table: "SocialHairdresser",
                column: "HairdresserId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialHairdresser_SocialNetworkId",
                table: "SocialHairdresser",
                column: "SocialNetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteHairdresser");

            migrationBuilder.DropTable(
                name: "HairdresserImage");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "SocialHairdresser");

            migrationBuilder.DropTable(
                name: "Hairdresser");

            migrationBuilder.DropTable(
                name: "SocialNetwork");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
