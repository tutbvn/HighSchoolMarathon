using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAdminAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28db49e3-1498-4bda-a9d0-75883e88255d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40316be7-d8dc-4f06-b5ce-5d95ea9b3f85");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "daa58f09-2732-4f33-a63d-eab236c1dd80");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c48e7b05-558d-49c1-999b-efd771ac834b", 0, "5552392c-3a2e-4fd1-93a0-d977beee85c6", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOP6riFdPX4go6PJ/0SsMLx+t3jd/3Bxi+FQ3wsLws/tau9EMBttpL1S8T99zYFGcQ==", null, false, "7f5accaf-04c8-4e72-872e-dbf0bd616966", false, "admin@example.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c48e7b05-558d-49c1-999b-efd771ac834b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "28db49e3-1498-4bda-a9d0-75883e88255d", 0, "1ccd16bc-16af-4c07-b4dd-7ecbfc7d6a79", "user3@example.com", true, false, null, "USER3@EXAMPLE.COM", "USER3@EXAMPLE.COM", "AQAAAAIAAYagAAAAENupGvDTkCR1zo5LS/0xNd34cuvt1EPooBkb6pwGzRX7C/trleabfIotWMaNhqPOnA==", null, false, "9fb1b7ff-1f6c-4c91-9b1a-5a7aa2ef5ca1", false, "user3@example.com" },
                    { "40316be7-d8dc-4f06-b5ce-5d95ea9b3f85", 0, "be13ca44-261a-4a2d-8d9b-6f947fec9c7b", "user2@example.com", true, false, null, "USER2@EXAMPLE.COM", "USER2@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN1ICddxNoTU0RnnJRgEqwd96R7UkOBCulg6kHauA8GFMJsECyVrioMSvGokokyRGA==", null, false, "d6a15af9-ab62-4fe8-9dff-87210c09bc67", false, "user2@example.com" },
                    { "daa58f09-2732-4f33-a63d-eab236c1dd80", 0, "ff174445-ecba-4424-ae1a-d3086dcbba83", "user1@example.com", true, false, null, "USER1@EXAMPLE.COM", "USER1@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKn2OzmNHij3mwWvtSPiVcH6NxI/M7fU9xu3hMCWTKu7FY3oHfBKH2pf8a4QAoSr5Q==", null, false, "4c2e2a5e-18bf-404c-b818-0dee2c966c0d", false, "user1@example.com" }
                });
        }
    }
}
