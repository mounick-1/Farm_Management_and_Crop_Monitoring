using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagement_and_CropMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddUnitToResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Resources");
        }
    }
}
