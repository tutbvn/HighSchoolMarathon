using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6CCD5657-FAA2-4CC8-ACD9-71145E60BE9E", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8D679F63-72D2-4782-9717-5FE9E7CCA509", 0, "ee9afaf8-dae7-47ab-9cd5-98bdcc9045c1", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHWdUCrrBB1/Ez16Qe4Kb+5yB+i3IcYFYFVYliPwYdJ9lZ9zT+zfUaG9D2Z2CB+q7w==", null, false, "3c1a5105-4933-4208-9fa7-df39a6a26d6a", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6CCD5657-FAA2-4CC8-ACD9-71145E60BE9E", "8D679F63-72D2-4782-9717-5FE9E7CCA509" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6CCD5657-FAA2-4CC8-ACD9-71145E60BE9E", "8D679F63-72D2-4782-9717-5FE9E7CCA509" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6CCD5657-FAA2-4CC8-ACD9-71145E60BE9E");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509");

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
    }
}
