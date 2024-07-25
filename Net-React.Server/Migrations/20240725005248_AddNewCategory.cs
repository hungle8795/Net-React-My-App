using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net_React.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "description", "name" },
                values: new object[] { 5, "15m", "Category D" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}
