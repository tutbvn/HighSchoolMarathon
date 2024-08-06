using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Nothing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fc7c03f-48b6-4e33-bdd7-3c24906ef1c0", "AQAAAAIAAYagAAAAEAPHIxjNEuwpUK0ncZvfHoGIK+Gqx6sdUj7PU1je9jBpnUHmMK3OkCPgjcKZCbzM/g==", "71f0a032-9563-4d71-921b-661db65d0795" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee9afaf8-dae7-47ab-9cd5-98bdcc9045c1", "AQAAAAIAAYagAAAAEHWdUCrrBB1/Ez16Qe4Kb+5yB+i3IcYFYFVYliPwYdJ9lZ9zT+zfUaG9D2Z2CB+q7w==", "3c1a5105-4933-4208-9fa7-df39a6a26d6a" });
        }
    }
}
