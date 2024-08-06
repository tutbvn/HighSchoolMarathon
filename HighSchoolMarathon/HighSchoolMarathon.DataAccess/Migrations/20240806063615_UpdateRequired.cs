using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HighSchoolMarathon.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "580ca9ad-40d0-4946-b8ec-a6f7003c3b05", "AQAAAAIAAYagAAAAEEnhzjATWKH+EgO6YadLj/hQ+R1yR6Gql27yHOYBKiG94P6aCIAKnepmbeGUE5yRVw==", "74015cf2-aa6a-4a1f-8ac2-a6c784f07394" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8D679F63-72D2-4782-9717-5FE9E7CCA509",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "240d186c-c500-48e1-af85-4d0bd99b9834", "AQAAAAIAAYagAAAAEFDigjYGj9Wf/MVD67/RXQ70m2/zj7j3YyeGnn4H4g388zgBibcz/vgSP/BmenyNKA==", "d074f757-c7b0-48b7-a648-d1afd588c985" });
        }
    }
}
