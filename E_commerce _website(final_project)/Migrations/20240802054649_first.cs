using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_commerce__website_final_project_.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    a_e_mail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    a_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.a_e_mail);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    c_e_mail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    c_address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    c_password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.c_e_mail);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    p_qty = table.Column<int>(type: "int", nullable: false),
                    p_price = table.Column<int>(type: "int", nullable: false),
                    p_pic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.p_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
