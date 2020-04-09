using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSafety.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restuarants",
                columns: table => new
                {
                    BusinessID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProgramIdentifier = table.Column<string>(nullable: true),
                    Desciption = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Longtitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restuarants", x => x.BusinessID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspections",
                columns: table => new
                {
                    InspectionSerialNum = table.Column<string>(nullable: false),
                    InspectionDate = table.Column<DateTime>(nullable: false),
                    InspectionBusinessName = table.Column<string>(nullable: true),
                    InspectionType = table.Column<int>(nullable: false),
                    InspectionScore = table.Column<int>(nullable: false),
                    InspectionResult = table.Column<int>(nullable: false),
                    InspectionClosedBusiness = table.Column<bool>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    RestuarantBusinessID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspections", x => x.InspectionSerialNum);
                    table.ForeignKey(
                        name: "FK_Inspections_Restuarants_RestuarantBusinessID",
                        column: x => x.RestuarantBusinessID,
                        principalTable: "Restuarants",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    BusinessId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.UserId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_Favourites_Restuarants_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Restuarants",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Violations",
                columns: table => new
                {
                    ViolationRecordId = table.Column<string>(nullable: false),
                    InspectionSerialNum = table.Column<string>(nullable: true),
                    ViolationType = table.Column<int>(nullable: false),
                    ViolationDescription = table.Column<string>(nullable: true),
                    ViolationPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violations", x => x.ViolationRecordId);
                    table.ForeignKey(
                        name: "FK_Violations_Inspections_InspectionSerialNum",
                        column: x => x.InspectionSerialNum,
                        principalTable: "Inspections",
                        principalColumn: "InspectionSerialNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_BusinessId",
                table: "Favourites",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspections_RestuarantBusinessID",
                table: "Inspections",
                column: "RestuarantBusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Violations_InspectionSerialNum",
                table: "Violations",
                column: "InspectionSerialNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "Violations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Inspections");

            migrationBuilder.DropTable(
                name: "Restuarants");
        }
    }
}
