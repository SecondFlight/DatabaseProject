using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DatabaseProjectTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bios",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    bio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bios", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    books = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    careerGoals = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    clubName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.clubName);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    Behance = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Linkedin = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    websiteURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    foods = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    hobbies = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    interestName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.interestName);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    state = table.Column<string>(nullable: true),
                    zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Majors",
                columns: table => new
                {
                    major = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Majors", x => x.major);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    movies = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    music = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Personality",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    personalityType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personality", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "PetPeeves",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    petPeeves = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetPeeves", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "RelationshipStatuses",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationshipStatuses", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    shows = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "UserClubs",
                columns: table => new
                {
                    clubName = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClubs", x => new { x.clubName, x.userName });
                });

            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    interestName = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => new { x.interestName, x.userName });
                });

            migrationBuilder.CreateTable(
                name: "UserMajors",
                columns: table => new
                {
                    major = table.Column<string>(nullable: false),
                    userName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMajors", x => new { x.major, x.userName });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userName = table.Column<string>(nullable: false),
                    birthdayDay = table.Column<int>(nullable: false),
                    birthdayMonth = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    standing = table.Column<string>(nullable: true),
                    workplace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bios");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Careers");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Majors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "Personality");

            migrationBuilder.DropTable(
                name: "PetPeeves");

            migrationBuilder.DropTable(
                name: "RelationshipStatuses");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "UserClubs");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "UserMajors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
