using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagement_and_CropMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class AddResourceUsageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "QuantityUsed",
                table: "ResourceUsages",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuantityUsed",
                table: "ResourceUsages",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
