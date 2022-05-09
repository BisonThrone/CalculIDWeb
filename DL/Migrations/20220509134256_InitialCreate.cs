using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    A = table.Column<double>(type: "float", nullable: false),
                    B = table.Column<double>(type: "float", nullable: false),
                    C = table.Column<double>(type: "float", nullable: false),
                    X1 = table.Column<double>(type: "float", nullable: true),
                    X2 = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calcs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calcs");
        }
    }
}
