using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_commerce__website_final_project_.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "a_e_mail", "a_password" },
                values: new object[,]
                {
                    { "a@gmail.com", "1234" },
                    { "b@gmail.com", "5678" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "a_e_mail",
                keyValue: "a@gmail.com");

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "a_e_mail",
                keyValue: "b@gmail.com");
        }
    }
}
