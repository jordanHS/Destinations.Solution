using Microsoft.EntityFrameworkCore.Migrations;

namespace Destinations.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "Text",
                value: "Beautiful city with lots of cool old architecture");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                columns: new[] { "Author", "DestinationId", "Text" },
                values: new object[] { "Jordan Safford", 2, "Best food ever!" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Author", "DestinationId", "Text" },
                values: new object[] { 4, "Richard Jones", 3, "Unique faerie tale like city with lots of castles" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "Text",
                value: "Beautiful city with lots of cool old architect");

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                columns: new[] { "Author", "DestinationId", "Text" },
                values: new object[] { "Richard Jones", 3, "Unique faerie tale like city with lots of castles" });
        }
    }
}
