using Microsoft.EntityFrameworkCore.Migrations;

namespace Equipment_Rental_Application.Migrations
{
    public partial class addType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EquipmentType",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentType",
                table: "History");
        }
    }
}
