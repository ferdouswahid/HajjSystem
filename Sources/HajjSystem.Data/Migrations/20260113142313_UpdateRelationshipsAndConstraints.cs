using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HajjSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipsAndConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteFrom",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "RouteTo",
                table: "VehicleDetails");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Vehicles",
                newName: "Model");

            migrationBuilder.AddColumn<string>(
                name: "ChassisNumber",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EngineNumber",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteFromId",
                table: "VehicleDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RouteToId",
                table: "VehicleDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRoutes_Name",
                table: "VehicleRoutes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_RouteFromId",
                table: "VehicleDetails",
                column: "RouteFromId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDetails_RouteToId",
                table: "VehicleDetails",
                column: "RouteToId");

            migrationBuilder.CreateIndex(
                name: "IX_MealTypes_Name",
                table: "MealTypes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDetails_VehicleRoutes_RouteFromId",
                table: "VehicleDetails",
                column: "RouteFromId",
                principalTable: "VehicleRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDetails_VehicleRoutes_RouteToId",
                table: "VehicleDetails",
                column: "RouteToId",
                principalTable: "VehicleRoutes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDetails_VehicleRoutes_RouteFromId",
                table: "VehicleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDetails_VehicleRoutes_RouteToId",
                table: "VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehicleRoutes_Name",
                table: "VehicleRoutes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDetails_RouteFromId",
                table: "VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDetails_RouteToId",
                table: "VehicleDetails");

            migrationBuilder.DropIndex(
                name: "IX_MealTypes_Name",
                table: "MealTypes");

            migrationBuilder.DropColumn(
                name: "ChassisNumber",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "EngineNumber",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RouteFromId",
                table: "VehicleDetails");

            migrationBuilder.DropColumn(
                name: "RouteToId",
                table: "VehicleDetails");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Vehicles",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "RouteFrom",
                table: "VehicleDetails",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RouteTo",
                table: "VehicleDetails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
