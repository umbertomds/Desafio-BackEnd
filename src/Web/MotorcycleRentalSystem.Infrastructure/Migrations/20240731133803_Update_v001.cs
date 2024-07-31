using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotorcycleRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Update_v001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_FinePlan_FinePlanId",
                table: "RentOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_Motorcycles_MotorcycleId",
                table: "RentOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_RentPlan_RentPlanId",
                table: "RentOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_Users_DeliverymanId",
                table: "RentOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DriverLicense_DriverLicenseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "DriverLicense");

            migrationBuilder.DropTable(
                name: "FinePlan");

            migrationBuilder.DropTable(
                name: "RentPlan");

            migrationBuilder.DropIndex(
                name: "IX_Users_DriverLicenseId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RentOrders_FinePlanId",
                table: "RentOrders");

            migrationBuilder.DropIndex(
                name: "IX_RentOrders_RentPlanId",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "DriverLicenseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FinePlanId",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "RentPlanId",
                table: "RentOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicense_Number",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverLicense_Picture",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverLicense_Type",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MotorcycleId",
                table: "RentOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DeliverymanId",
                table: "RentOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FinePlan_Days",
                table: "RentOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FinePlan_FineType",
                table: "RentOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "FinePlan_PerDay",
                table: "RentOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FinePlan_Total",
                table: "RentOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RentPlan_PerDayCost",
                table: "RentOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RentPlan_PlanPeriod",
                table: "RentOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "RentPlan_TotalCost",
                table: "RentOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "UserRole" },
                values: new object[] { "AQAAAAIAAYagAAAAEIEYZO/oTCCZg1r2Ljcw6bkyTw9Z2Piy131rGVQ0T/IK8WiTg97rPZTCccJMmg9cBw==", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_Motorcycles_MotorcycleId",
                table: "RentOrders",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_Users_DeliverymanId",
                table: "RentOrders",
                column: "DeliverymanId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_Motorcycles_MotorcycleId",
                table: "RentOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RentOrders_Users_DeliverymanId",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "DriverLicense_Number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DriverLicense_Picture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DriverLicense_Type",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FinePlan_Days",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "FinePlan_FineType",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "FinePlan_PerDay",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "FinePlan_Total",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "RentPlan_PerDayCost",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "RentPlan_PlanPeriod",
                table: "RentOrders");

            migrationBuilder.DropColumn(
                name: "RentPlan_TotalCost",
                table: "RentOrders");

            migrationBuilder.AlterColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<long>(
                name: "DriverLicenseId",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MotorcycleId",
                table: "RentOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DeliverymanId",
                table: "RentOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "FinePlanId",
                table: "RentOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RentPlanId",
                table: "RentOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "DriverLicense",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverLicense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinePlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Days = table.Column<int>(type: "integer", nullable: false),
                    FineType = table.Column<int>(type: "integer", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    PerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinePlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", rowVersion: true, nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    PerDayCost = table.Column<decimal>(type: "numeric", nullable: false),
                    PlanPeriod = table.Column<int>(type: "integer", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentPlan", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "UserRole" },
                values: new object[] { "admin@paswd24", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DriverLicenseId",
                table: "Users",
                column: "DriverLicenseId");

            migrationBuilder.CreateIndex(
                name: "IX_RentOrders_FinePlanId",
                table: "RentOrders",
                column: "FinePlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RentOrders_RentPlanId",
                table: "RentOrders",
                column: "RentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_FinePlan_FinePlanId",
                table: "RentOrders",
                column: "FinePlanId",
                principalTable: "FinePlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_Motorcycles_MotorcycleId",
                table: "RentOrders",
                column: "MotorcycleId",
                principalTable: "Motorcycles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_RentPlan_RentPlanId",
                table: "RentOrders",
                column: "RentPlanId",
                principalTable: "RentPlan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentOrders_Users_DeliverymanId",
                table: "RentOrders",
                column: "DeliverymanId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DriverLicense_DriverLicenseId",
                table: "Users",
                column: "DriverLicenseId",
                principalTable: "DriverLicense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
