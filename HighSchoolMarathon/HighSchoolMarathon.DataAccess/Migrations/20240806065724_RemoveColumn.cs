using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRunners",
                table: "RunningEvents");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "894b227d-812f-4fb1-b882-3542418bb2e3", "AQAAAAIAAYagAAAAEEorrm853aFoLc/iE+VemwQAq1k7HB8djeNfpW8uUCxiAzCy9Fy25q1hX8rGBhQ3og==", "ed9fb677-ac8e-4038-81eb-b2f70b45998d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRunners",
                table: "RunningEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "580ca9ad-40d0-4946-b8ec-a6f7003c3b05", "AQAAAAIAAYagAAAAEEnhzjATWKH+EgO6YadLj/hQ+R1yR6Gql27yHOYBKiG94P6aCIAKnepmbeGUE5yRVw==", "74015cf2-aa6a-4a1f-8ac2-a6c784f07394" });
        }
    }
}
