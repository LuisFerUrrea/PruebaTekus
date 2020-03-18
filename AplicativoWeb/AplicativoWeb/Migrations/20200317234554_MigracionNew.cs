using Microsoft.EntityFrameworkCore.Migrations;

namespace AplicativoWeb.Migrations
{
    public partial class MigracionNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteSevicioXPaisId",
                table: "Pais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteSevicioXPaisId",
                table: "Pais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
