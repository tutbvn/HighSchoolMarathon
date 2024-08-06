using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c48e7b05-558d-49c1-999b-efd771ac834b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8cfdadcc-d451-48f7-9bfd-54e2c647b6d4", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1e89ab0f-46e4-4719-8464-8509b0ef5985", 0, "fdaba4f2-561a-4c7e-85a1-c0576ff3597a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAELD4S/TugJpCvycuU5qu3Wi5LOeDhp++jivRLWdCMB2An+tzqAGj/7Aral2Oe4hbxw==", null, false, "fc3dab2c-7b23-40de-82fd-220aaea63260", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8cfdadcc-d451-48f7-9bfd-54e2c647b6d4", "1e89ab0f-46e4-4719-8464-8509b0ef5985" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8cfdadcc-d451-48f7-9bfd-54e2c647b6d4", "1e89ab0f-46e4-4719-8464-8509b0ef5985" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cfdadcc-d451-48f7-9bfd-54e2c647b6d4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e89ab0f-46e4-4719-8464-8509b0ef5985");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c48e7b05-558d-49c1-999b-efd771ac834b", 0, "5552392c-3a2e-4fd1-93a0-d977beee85c6", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOP6riFdPX4go6PJ/0SsMLx+t3jd/3Bxi+FQ3wsLws/tau9EMBttpL1S8T99zYFGcQ==", null, false, "7f5accaf-04c8-4e72-872e-dbf0bd616966", false, "admin@example.com" });
        }
    }
}
