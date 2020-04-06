using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodSafety.API.Migrations
{
    public partial class AddedRestuarantEntity : Migration
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
                    Grade = table.Column<int>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
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
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    InspectionSerialNum = table.Column<string>(nullable: false),
                    BusinessID = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Inspection", x => x.InspectionSerialNum);
                    table.ForeignKey(
                        name: "FK_Inspection_Restuarants_RestuarantBusinessID",
                        column: x => x.RestuarantBusinessID,
                        principalTable: "Restuarants",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Violation",
                columns: table => new
                {
                    ViolationRecordId = table.Column<string>(nullable: false),
                    BusinessID = table.Column<string>(nullable: true),
                    ViolationType = table.Column<int>(nullable: false),
                    ViolationDescription = table.Column<string>(nullable: true),
                    ViolationPoints = table.Column<int>(nullable: false),
                    RestuarantBusinessID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Violation", x => x.ViolationRecordId);
                    table.ForeignKey(
                        name: "FK_Violation_Restuarants_RestuarantBusinessID",
                        column: x => x.RestuarantBusinessID,
                        principalTable: "Restuarants",
                        principalColumn: "BusinessID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_RestuarantBusinessID",
                table: "Inspection",
                column: "RestuarantBusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Violation_RestuarantBusinessID",
                table: "Violation",
                column: "RestuarantBusinessID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Violation");

            migrationBuilder.DropTable(
                name: "Restuarants");
        }
    }
}
