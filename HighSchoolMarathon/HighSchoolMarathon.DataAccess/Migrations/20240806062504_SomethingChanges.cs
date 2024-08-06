using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SomethingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Runners");

            migrationBuilder.CreateTable(
                name: "RunningEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfRunners = table.Column<int>(type: "int", nullable: false),
                    EventStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RouteDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunnerRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BibNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    Ranking = table.Column<int>(type: "int", nullable: true),
                    RunningEventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunnerRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RunnerRegistrations_RunningEvents_RunningEventId",
                        column: x => x.RunningEventId,
                        principalTable: "RunningEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "240d186c-c500-48e1-af85-4d0bd99b9834", "AQAAAAIAAYagAAAAEFDigjYGj9Wf/MVD67/RXQ70m2/zj7j3YyeGnn4H4g388zgBibcz/vgSP/BmenyNKA==", "d074f757-c7b0-48b7-a648-d1afd588c985" });

            migrationBuilder.CreateIndex(
                name: "IX_RunnerRegistrations_RunningEventId",
                table: "RunnerRegistrations",
                column: "RunningEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunnerRegistrations");

            migrationBuilder.DropTable(
                name: "RunningEvents");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EventStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumberOfRunners = table.Column<int>(type: "int", nullable: false),
                    RegistrationEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RouteDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Runners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BibNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ranking = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runners", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fc7c03f-48b6-4e33-bdd7-3c24906ef1c0", "AQAAAAIAAYagAAAAEAPHIxjNEuwpUK0ncZvfHoGIK+Gqx6sdUj7PU1je9jBpnUHmMK3OkCPgjcKZCbzM/g==", "71f0a032-9563-4d71-921b-661db65d0795" });
        }
    }
}
