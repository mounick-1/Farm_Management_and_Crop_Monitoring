using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManagement_and_CropMonitoring.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixForSchedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "PlantSchedules");

            migrationBuilder.DropColumn(
                name: "TaskDescription",
                table: "PlantSchedules");

            migrationBuilder.RenameColumn(
                name: "TaskDate",
                table: "PlantSchedules",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "PlantSchedules",
                newName: "PlantScheduleId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "PlantSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "PlantSchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlantSchedules_FieldId",
                table: "PlantSchedules",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantSchedules_Fields_FieldId",
                table: "PlantSchedules",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "FieldId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantSchedules_Fields_FieldId",
                table: "PlantSchedules");

            migrationBuilder.DropIndex(
                name: "IX_PlantSchedules_FieldId",
                table: "PlantSchedules");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "PlantSchedules");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "PlantSchedules");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "PlantSchedules",
                newName: "TaskDate");

            migrationBuilder.RenameColumn(
                name: "PlantScheduleId",
                table: "PlantSchedules",
                newName: "ScheduleId");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "PlantSchedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                table: "PlantSchedules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
